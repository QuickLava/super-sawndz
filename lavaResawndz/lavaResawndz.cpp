#include "lavaResawndz.h"

namespace lava
{
	namespace brawl
	{
		bool sawnd::populate(const lava::byteArray& bodyIn, unsigned long addressIn)
		{
			bool result = 0;

			if (bodyIn.populated())
			{
				address = addressIn;

				sawndVersion = bodyIn.getChar(address);
				groupID = bodyIn.getLong(address + 0x01);
				dataSectionLength = bodyIn.getLong(address + 0x05);

				bool firstEntryReached = 0;
				std::size_t cursor = address + 0x09;
				std::vector<unsigned long> currFileTriple(3, ULONG_MAX);
				unsigned long currFileTripleSlot = 0;
				while (!firstEntryReached)
				{
					unsigned long harvestedLong = bodyIn.getLong(cursor);
					if (!(validateHexTag(harvestedLong) == brsarHexTagType::bhtt_FILE_SECTION))
					{
						currFileTriple[currFileTripleSlot] = harvestedLong;
						currFileTripleSlot++;
						if (currFileTripleSlot >= 3)
						{
							fileEntries.push_back(sawndFileEntry());
							fileEntries.back().fileID = currFileTriple[0];
							fileEntries.back().dataOffset = currFileTriple[1];
							fileEntries.back().dataLength = currFileTriple[2];
							currFileTripleSlot = 0;
							currFileTriple = { ULONG_MAX, ULONG_MAX, ULONG_MAX };
						}
						cursor += 0x4;
					}
					else
					{
						firstEntryReached = 1;
					}
				}
				headerSectionOffset = cursor - address;
				headerSectionLength = 0;
				for (unsigned long currFileIndex = 0; cursor < bodyIn.size() && currFileIndex < fileEntries.size(); currFileIndex++)
				{
					if (validateHexTag(bodyIn.getLong(cursor)) == brsarHexTagType::bhtt_FILE_SECTION)
					{
						sawndFileEntry* currEntry = &fileEntries[currFileIndex];
						currEntry->headerOffset = (cursor - address) - headerSectionOffset;
						currEntry->headerLength = bodyIn.getLong(cursor + 0x08);
						headerSectionLength += currEntry->headerLength;
						std::size_t numGotten = SIZE_MAX;
						currEntry->headerContent = bodyIn.getBytes(currEntry->headerLength, address + headerSectionOffset + currEntry->headerOffset, numGotten);
						cursor += currEntry->headerLength;
					}
					else
					{
						cursor = SIZE_MAX;
					}
				}
				dataSectionOffset = cursor - address;
				for (unsigned long currFileIndex = 0; currFileIndex < fileEntries.size(); currFileIndex++)
				{
					sawndFileEntry* currEntry = &fileEntries[currFileIndex];
					std::size_t numGotten = SIZE_MAX;
					currEntry->dataContent = bodyIn.getBytes(currEntry->dataLength, address + dataSectionOffset + currEntry->dataOffset, numGotten);
				}
				result = 1;
			}
			return result;
		}
		bool sawnd::exportContents(std::ostream& destinationStream)
		{
			bool result = 0;

			if (destinationStream.good())
			{
				switch (sawndVersion)
				{
				case 0x02:
				{
					byteArray bodyArray(headerSectionOffset + headerSectionLength + dataSectionLength, 0xCC);
					std::size_t cursor = 0x00;
					bodyArray.setChar(sawndVersion, cursor, &cursor);
					bodyArray.setLong(groupID, cursor, &cursor);
					bodyArray.setLong(dataSectionLength, cursor, &cursor);
					for (std::size_t i = 0; i < fileEntries.size(); i++)
					{
						sawndFileEntry* currEntry = &fileEntries[i];
						bodyArray.setLong(currEntry->fileID, cursor, &cursor);
						bodyArray.setLong(currEntry->dataOffset, cursor, &cursor);
						bodyArray.setLong(currEntry->dataLength, cursor, &cursor);
					}
					for (std::size_t i = 0; i < fileEntries.size(); i++)
					{
						sawndFileEntry* currEntry = &fileEntries[i];
						bodyArray.setBytes(currEntry->headerContent, headerSectionOffset + currEntry->headerOffset);
						bodyArray.setBytes(currEntry->dataContent, dataSectionOffset + currEntry->dataOffset);
					}
					bodyArray.dumpToStream(destinationStream);
					result = destinationStream.good();
					break;
				}
				default:
				{
					std::cerr << "Unsupported .sawnd version detected. Export aborted!\n";
					break;
				}
				}
			}

			return result;
		}

		std::vector<sawnd> parseSawndFie(std::string fileIn)
		{
			std::vector<sawnd> result{};

			std::ifstream fileStream(fileIn, std::ios_base::in | std::ios_base::binary);
			if (fileStream.is_open())
			{
				byteArray fileByteArr(fileStream);
				if (fileByteArr.populated())
				{
					std::size_t cursor = 0x00;
					while (cursor < fileByteArr.size())
					{
						sawnd temp;
						temp.populate(fileByteArr, cursor);
						if (temp.sawndVersion <= _MAX_SUPPORTED_SAWND_VERSION && !temp.fileEntries.empty())
						{
							if (detectHexTags(fileByteArr, temp.address + temp.dataSectionOffset + temp.dataSectionLength))
							{
								cursor = temp.address + temp.dataSectionOffset + temp.dataSectionLength;
							}
							else
							{
								cursor = ULONG_MAX;
							}
							result.push_back(temp);
						}
						else
						{
							cursor = ULONG_MAX;
						}
					}
				}
			}

			return result;
		}
		bool exportSawnd(brsar& sourceBrsar, std::size_t groupID, std::string targetFilePath)
		{
			bool result = 0;
			std::cout << "Creating \"" << targetFilePath << "\" from Group #" << numToDecStringWithPadding(groupID, 0x03) << " / 0x" << numToHexStringWithPadding(groupID, 0x03) << "...";

			std::ofstream sawndOutput;
			sawndOutput.open(targetFilePath, std::ios_base::out | std::ios_base::binary);
			if (sawndOutput.is_open())
			{
				const brsarInfoGroupHeader* targetGroup = sourceBrsar.infoSection.getGroupWithID(groupID);
				if (targetGroup != nullptr)
				{
					sawndOutput.put(2);
					lava::writeRawDataToStream(sawndOutput, groupID);
					lava::writeRawDataToStream(sawndOutput, targetGroup->dataLength);

					for (std::size_t i = 0; i < targetGroup->entries.size(); i++)
					{
						const brsarInfoGroupEntry* currEntry = &targetGroup->entries[i];
						//std::cout << "Collection #" << i << " (@ 0x" << numToHexStringWithPadding(currEntry->address, 8) << ")\n";
						//std::cout << "\tFile ID: 0x" << numToHexStringWithPadding(currEntry->fileID, 4) << "\n";
						//std::cout << "\tHeader Offset: 0x" << numToHexStringWithPadding(currEntry->headerOffset, 4) << "\n";
						//std::cout << "\tHeader Length: 0x" << numToHexStringWithPadding(currEntry->headerLength, 4) << "\n";
						//std::cout << "\tData Offset: 0x" << numToHexStringWithPadding(currEntry->dataOffset, 4) << "\n";
						//std::cout << "\tData Length: 0x" << numToHexStringWithPadding(currEntry->dataLength, 4) << "\n";
						lava::writeRawDataToStream(sawndOutput, currEntry->fileID);
						lava::writeRawDataToStream(sawndOutput, currEntry->dataOffset);
						lava::writeRawDataToStream(sawndOutput, currEntry->dataLength);
					}
					byteArray fileContentsExportArr(targetGroup->dataLength + targetGroup->headerLength);
					for (std::size_t i = 0; i < targetGroup->entries.size(); i++)
					{
						const brsarInfoGroupEntry* currEntry = &targetGroup->entries[i];
						const brsarFileFileContents* currFileContentsPtr = sourceBrsar.fileSection.getFileContentsPointer(currEntry->fileID, targetGroup->groupID);
						fileContentsExportArr.setBytes(currFileContentsPtr->header, currEntry->headerOffset);
						fileContentsExportArr.setBytes(currFileContentsPtr->data, targetGroup->headerLength + currEntry->dataOffset);
					}
					fileContentsExportArr.dumpToStream(sawndOutput);
					result = sawndOutput.good();
				}
				else
				{
					std::cerr << "[ERROR] Provided group ID couldn't be located. Aborting export.\n";
					remove(targetFilePath.c_str());
				}
			}
			else
			{
				std::cerr << "[ERROR] Couldn't write to target file location (\"" << targetFilePath << "\").\n";
			}
			if (result)
			{
				std::cout << " Success!\n";
			}
			else
			{
				std::cout << " Failure!\n";
			}
			return result;
		}
		bool importSawnd(brsar& sourceBrsar, std::string sourceFilePath)
		{
			bool result = 0;

			std::ifstream sawndIn(sourceFilePath, std::ios_base::in | std::ios_base::binary);
			if (sawndIn.is_open())
			{
				byteArray sawndBody(sawndIn);
				sawndIn.close();
				if (sawndBody.populated())
				{
					std::vector<sawnd> sawndFileContents = parseSawndFie(sourceFilePath);
					if (sawndFileContents.size() == 1)
					{
						const sawnd& sawndContent = sawndFileContents.front();
						const brsarInfoGroupHeader* targetGroupHeader = sourceBrsar.infoSection.getGroupWithID(sawndContent.groupID);
						std::cout << "Importing \"" << sourceFilePath << "\" (for Group #" << lava::numToDecStringWithPadding(sawndContent.groupID, 0x03) << " / 0x" << lava::numToHexStringWithPadding(sawndContent.groupID, 0x03) << ")...\n";
						if (targetGroupHeader != nullptr)
						{
							if (targetGroupHeader->entries.size() == sawndContent.fileEntries.size())
							{
								if (!sawndContent.fileEntries.empty())
								{
									for (unsigned long i = 0; i < sawndContent.fileEntries.size(); i++)
									{
										const sawndFileEntry* currEntry = &sawndContent.fileEntries[i];
										if (targetGroupHeader->usesFileID(currEntry->fileID))
										{
											std::cout << "\tOverwriting File (ID: " << lava::numToDecStringWithPadding(currEntry->fileID, 0x03) << " / 0x" << lava::numToHexStringWithPadding(currEntry->fileID, 0x03) << ")...";
											if (sourceBrsar.overwriteFile(currEntry->headerContent, currEntry->dataContent, currEntry->fileID))
											{
												result = 1;
												std::cout << " Success!\n";
											}
											else
											{
												std::cerr << " Failure! Something has gone wrong!\n";
											}
										}
										else
										{
											unsigned long synonymousID = targetGroupHeader->getSynonymFileID(currEntry->headerLength);
											if (synonymousID != ULONG_MAX)
											{
												std::cout << "\t[WARNING] This File's ID isn't used in this group, but one with the same header length is.\n";
												std::cout << "\tThe two files are likely different-region versions of each other: import will continue.\n";
												std::cout << "\tOverwriting File (ID: " << lava::numToDecStringWithPadding(synonymousID, 0x03) << " / 0x" << lava::numToHexStringWithPadding(synonymousID, 0x03) << ")...";
												if (sourceBrsar.overwriteFile(currEntry->headerContent, currEntry->dataContent, synonymousID))
												{
													result = 1;
													std::cout << " Success!\n";
												}
												else
												{
													std::cerr << " Failure! Something has gone wrong!\n";
												}
											}
											else
											{
												std::cout << "\t[ERROR] Unable to import File (ID: " << lava::numToDecStringWithPadding(currEntry->fileID, 0x03) << " / 0x" << lava::numToHexStringWithPadding(currEntry->fileID, 0x03) << ") from \"" << sourceFilePath << "\" into Group (" << lava::numToDecStringWithPadding(targetGroupHeader->groupID, 0x03) << " / 0x" << lava::numToHexStringWithPadding(targetGroupHeader->groupID, 0x03) << ")! The specified file isn't used in the target group!\n";
											}
										}
									}
								}
								else
								{
									std::cout << "\t[WARNING] Successfully loaded provided .sawnd, but no file entries could be found!\n";
								}
							}
							else
							{
								std::cout << "\t[ERROR] Unable to import content of \"" << sourceFilePath << "\"! The targeted Group (" << lava::numToDecStringWithPadding(sawndContent.groupID, 0x03) << " / 0x" << lava::numToHexStringWithPadding(sawndContent.groupID, 0x03) << ") contains a different number of files (" << targetGroupHeader->entries.size() << ") than the provided .sawnd (" << sawndContent.fileEntries.size() << ")!\n";
							}
						}
						else
						{
							std::cout << "\t[ERROR] Unable to import content of \"" << sourceFilePath << "\"! The targeted Group (" << lava::numToDecStringWithPadding(sawndContent.groupID, 0x03) << " / 0x" << lava::numToHexStringWithPadding(sawndContent.groupID, 0x03) << ") couldn't be found in this .brsar!\n";
						}
					}
					else if (!sawndFileContents.empty())
					{
						std::cout << "[ERROR] The provided .sawnd file had additional .sawnd files appended to it.\n";
						std::cout << "None of the files will be imported, they will instead be split into the following files:\n";
						unsigned char rand1 = rand();
						unsigned char rand2 = rand();
						unsigned short randNum = (unsigned short(rand1) << 0x08) | rand2;
						std::string splitBaseName = "ResawndzSplit_" + numToHexStringWithPadding(randNum, 0x04);
						for (std::size_t i = 0; i < sawndFileContents.size(); i++)
						{
							sawnd* currSawnd = &sawndFileContents[i];
							std::string groupIDStr = "(Group_" + lava::numToDecStringWithPadding(currSawnd->groupID, 0x03) + "_0x" + lava::numToHexStringWithPadding(currSawnd->groupID, 0x03) + ")";
							std::string fullName = splitBaseName + "_" + numToDecStringWithPadding(i, 2) + "_" + groupIDStr + ".sawnd";
							std::cout << " - \"" << fullName << "\"... ";
							std::ofstream splitOutput(fullName, std::ios_base::out | std::ios_base::binary);
							if (currSawnd->exportContents(splitOutput))
							{
								std::cout << "Export successful!\n";
							}
							else
							{
								std::cout << "Export failed!\n";
							}
						}
						std::cout << "You can find the produced files in this program's directory.\n";
					}
					else
					{
						std::cout << "[ERROR] Was able to open \"" << sourceFilePath << "\", but its contents couldn't be parsed correctly!\n";
					}
				}
				else
				{
					std::cout << "[ERROR] Was able to open \"" << sourceFilePath << "\", but was unable to build a byteArray!\n";
				}
			}
			else
			{
				std::cout << "[ERROR] Unable to open \"" << sourceFilePath << "\" for import!\n";
			}

			return result;
		}
	}
}