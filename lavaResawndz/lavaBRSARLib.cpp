#include "lavaBRSARLib.h"

namespace lava
{
	namespace brawl
	{
		std::string generateVGAudioWavToDSPCommand(std::string wavFilePath, std::string outputFilePath)
		{
			return "\"\"" + VGAudioMainExePath + "\" -c -i:0 \"" + wavFilePath + "\" -o \"" + outputFilePath + "\"\"";
		}
		std::string generateVGAudioDSPToWavCommand(std::string dspFilePath, std::string outputFilePath)
		{
			return "\"\"" + VGAudioMainExePath + "\" -c -i \"" + dspFilePath + "\" -o \"" + outputFilePath + "\"\"";
		}

		/* Misc. */

		unsigned long validateHexTag(unsigned long tagIn)
		{
			unsigned long result = 0;

			switch (tagIn)
			{
				case brsarHexTags::bht_RSAR:
				case brsarHexTags::bht_SYMB:
				case brsarHexTags::bht_INFO:
				case brsarHexTags::bht_FILE:
				{
					result = brsarHexTagType::bhtt_RSAR_SECTION;
					break;
				}
				case brsarHexTags::bht_RWSD:
				case brsarHexTags::bht_RBNK:
				case brsarHexTags::bht_RSEQ:
				case brsarHexTags::bht_RWAR:
				{
					result = brsarHexTagType::bhtt_FILE_SECTION;
					break;
				}
			}

			return result;
		}
		bool detectHexTags(const byteArray& bodyIn, unsigned long startingAddress)
		{
			bool result = 0;

			if (startingAddress < bodyIn.size())
			{
				std::vector<std::size_t> findResults = bodyIn.searchMultipleChar('R', startingAddress);
				if (!findResults.empty())
				{
					for (std::size_t i = 0; !result && i < findResults.size(); i++)
					{
						unsigned long harvestedLong = bodyIn.getLong(findResults[i]);
						result = validateHexTag(harvestedLong);
					}
				}
			}

			return result;
		}
		bool adjustOffset(unsigned long relativeBaseOffset, unsigned long& offsetIn, signed long adjustmentAmount, unsigned long startingAddress)
		{
			bool result = 0;

			if (startingAddress < relativeBaseOffset + offsetIn)
			{
				offsetIn += adjustmentAmount;
				result = 1;
			}

			return result;
		}

		/* Misc. */



		/* Brawl Reference */

		brawlReference::brawlReference(unsigned long long valueIn)
		{
			addressType = valueIn >> 0x20;
			address = valueIn & 0x00000000FFFFFFFF;
		}
		bool brawlReference::isOffset()
		{
			return addressType & 0x01000000;
		}
		unsigned long brawlReference::getAddress(unsigned long relativeToIn)
		{
			unsigned long result = address;
			if (isOffset())
			{
				if (relativeToIn != ULONG_MAX)
				{
					result += relativeToIn;
				}
			}
			return result;
		}
		std::string brawlReference::getAddressString(unsigned long relativeToIn)
		{
			return numToHexStringWithPadding(getAddress(relativeToIn), 8);
		}
		unsigned long long brawlReference::getHex()
		{
			unsigned long long result = address | (unsigned long long(addressType) << 0x20);
			return result;
		}

		bool brawlReferenceVector::populate(const lava::byteArray& bodyIn, std::size_t addressIn)
		{
			bool result = 0;

			if (bodyIn.populated() && (addressIn < bodyIn.size()))
			{
				std::size_t count = bodyIn.getLong(addressIn);
				refs.resize(count);
				unsigned long cursor = addressIn + 0x04;
				for (std::size_t i = 0; i < count; i++)
				{
					refs[i] = brawlReference(bodyIn.getLLong(cursor));
					cursor += 0x08;
				}
				result = 1;
			}

			return result;
		}
		std::vector<unsigned long> brawlReferenceVector::getHex()
		{
			std::vector<unsigned long> result{};

			result.push_back(refs.size());
			for (std::size_t i = 0; i < refs.size(); i++)
			{
				unsigned long long temp = refs[i].getHex();
				result.push_back(temp >> 0x20);
				result.push_back(temp);
			}

			return result;
		}
		bool brawlReferenceVector::exportContents(std::ostream& destinationStream)
		{
			bool result = 0;

			if (destinationStream.good())
			{
				std::vector<unsigned long> hexBufferVector = getHex();
				for (std::size_t i = 0; i < hexBufferVector.size(); i++)
				{
					lava::writeRawDataToStream(destinationStream, hexBufferVector[i]);
				}
				result = destinationStream.good();
			}

			return result;
		}

		/* Brawl Reference */



		/*Sound Data Structs*/

		bool wavePacket::populate(const lava::byteArray& bodyIn, unsigned long addressIn, unsigned long dataLengthIn, unsigned long paddingLengthIn)
		{
			bool result = 0;

			if (bodyIn.populated() && (addressIn + dataLengthIn + paddingLengthIn) <= bodyIn.size())
			{
				address = addressIn;

				result = 1;
				std::size_t numGotten = SIZE_MAX;
				if (dataLengthIn != 0)
				{
					body = bodyIn.getBytes(dataLengthIn, addressIn, numGotten);
					result &= numGotten == dataLengthIn;
				}
				if (paddingLengthIn != 0 && result)
				{
					padding = bodyIn.getBytes(paddingLengthIn, addressIn + dataLengthIn, numGotten);
					result &= numGotten == paddingLengthIn;
				}

				populated = result;
				if (!result)
				{
					address = ULONG_MAX;
					body.clear();
				}
			}

			return result;
		}

		unsigned long waveInfo::getLengthInBytes() const
		{
			unsigned long result = ULONG_MAX;

			if (address != ULONG_MAX)
			{
				auto divResult = ldiv(nibbles, 2);
				result = divResult.quot + divResult.rem;
			}

			return result;
		}
		void waveInfo::copyOverWaveInfoProperties(const waveInfo& sourceInfo)
		{
			address = brsarAddressConsts::bac_NOT_IN_FILE;

			encoding = sourceInfo.encoding;
			looped = sourceInfo.looped;
			channels = sourceInfo.channels;
			sampleRate24 = sourceInfo.sampleRate24;
			sampleRate = sourceInfo.sampleRate;
			pad = sourceInfo.pad;
			loopStartSample = sourceInfo.loopStartSample;
			nibbles = sourceInfo.nibbles;
			channelInfoTableOffset = sourceInfo.channelInfoTableOffset;
			reserved = sourceInfo.reserved;
			channelInfoTable = sourceInfo.channelInfoTable;
			channelInfoEntries = sourceInfo.channelInfoEntries;
			adpcmInfoEntries = sourceInfo.adpcmInfoEntries;
		}

		bool waveInfo::populate(const lava::byteArray& bodyIn, unsigned long addressIn)
		{
			bool result = 0;

			if (bodyIn.populated())
			{
				address = addressIn;

				std::size_t cursor = address;
				encoding = bodyIn.getChar(cursor, &cursor);
				looped = bodyIn.getChar(cursor, &cursor);
				channels = bodyIn.getChar(cursor, &cursor);
				sampleRate24 = bodyIn.getChar(cursor, &cursor);
				sampleRate = bodyIn.getShort(cursor, &cursor);
				dataLocationType = bodyIn.getChar(cursor, &cursor);
				pad = bodyIn.getChar(cursor, &cursor);
				loopStartSample = bodyIn.getLong(cursor, &cursor);
				nibbles = bodyIn.getLong(cursor, &cursor);
				channelInfoTableOffset = bodyIn.getLong(cursor, &cursor);
				dataLocation = bodyIn.getLong(cursor, &cursor);
				reserved = bodyIn.getLong(cursor, &cursor);

				for (unsigned long i = 0; i < channels; i++)
				{
					channelInfoTable.push_back(bodyIn.getLong(cursor, &cursor));
					channelInfoEntries.push_back(channelInfo());
					unsigned long infoAddress = address + channelInfoTable.back();
					channelInfoEntries.back().populate(bodyIn, infoAddress);
					if (encoding == 2)
					{
						adpcmInfoEntries.push_back(adpcmInfo());
						adpcmInfoEntries.back().populate(bodyIn, infoAddress + 0x1C);
					}
				}
				result = 1;
			}

			return result;
		}
		bool waveInfo::exportContents(std::ostream& destinationStream)
		{
			bool result = 0;
			if (destinationStream.good())
			{
				lava::writeRawDataToStream(destinationStream, encoding);
				lava::writeRawDataToStream(destinationStream, looped);
				lava::writeRawDataToStream(destinationStream, channels);
				lava::writeRawDataToStream(destinationStream, sampleRate24);
				lava::writeRawDataToStream(destinationStream, sampleRate);
				lava::writeRawDataToStream(destinationStream, dataLocationType);
				lava::writeRawDataToStream(destinationStream, pad);
				lava::writeRawDataToStream(destinationStream, loopStartSample);
				lava::writeRawDataToStream(destinationStream, nibbles);
				lava::writeRawDataToStream(destinationStream, channelInfoTableOffset);
				lava::writeRawDataToStream(destinationStream, dataLocation);
				lava::writeRawDataToStream(destinationStream, reserved);

				for (unsigned long i = 0x0; i < channelInfoTable.size(); i++)
				{
					lava::writeRawDataToStream(destinationStream, channelInfoTable[i]);
				}
				for (unsigned long i = 0x0; i < channelInfoEntries.size(); i++)
				{
					channelInfoEntries[i].exportContents(destinationStream);
					if (encoding == 2)
					{
						adpcmInfoEntries[i].exportContents(destinationStream);
					}
				}

				result = destinationStream.good();
			}
			return result;
		}

		void dataInfo::copyOverDataInfoProperties(const dataInfo& sourceInfo)
		{
			address = brsarAddressConsts::bac_NOT_IN_FILE;

			wsdPitch = sourceInfo.wsdPitch;
			wsdPan = sourceInfo.wsdPan;
			wsdSurroundPan = sourceInfo.wsdSurroundPan;
			wsdFxSendA = sourceInfo.wsdFxSendA;
			wsdFxSendB = sourceInfo.wsdFxSendB;
			wsdFxSendC = sourceInfo.wsdFxSendC;
			wsdMainSend = sourceInfo.wsdMainSend;
			wsdPad1 = sourceInfo.wsdPad1;
			wsdPad2 = sourceInfo.wsdPad2;

			ttPosition = sourceInfo.ttPosition;
			ttLength = sourceInfo.ttLength;
			ttNoteIndex = sourceInfo.ttNoteIndex;

			ntAttack = sourceInfo.ntAttack;
			ntDecay = sourceInfo.ntDecay;
			ntSustain = sourceInfo.ntSustain;
			ntRelease = sourceInfo.ntRelease;
			ntHold = sourceInfo.ntHold;
			ntPad1 = sourceInfo.ntPad1;
			ntPad2 = sourceInfo.ntPad2;
			ntPad3 = sourceInfo.ntPad3;
			ntOriginalKey = sourceInfo.ntOriginalKey;
			ntVolume = sourceInfo.ntVolume;
			ntPan = sourceInfo.ntPan;
			ntSurroundPan = sourceInfo.ntSurroundPan;
			ntPitch = sourceInfo.ntPitch;
		}
		bool dataInfo::populate(const lava::byteArray& bodyIn, std::size_t addressIn)
		{
			bool result = 0;

			if (bodyIn.populated())
			{
				address = addressIn;
				wsdInfo = brawlReference(bodyIn.getLLong(address));
				trackTable = brawlReference(bodyIn.getLLong(address + 0x08));
				noteTable = brawlReference(bodyIn.getLLong(address + 0x10));

				wsdPitch = bodyIn.getFloat(address + 0x18);
				wsdPan = bodyIn.getChar(address + 0x1C);
				wsdSurroundPan = bodyIn.getChar(address + 0x1D);
				wsdFxSendA = bodyIn.getChar(address + 0x1E);
				wsdFxSendB = bodyIn.getChar(address + 0x1F);
				wsdFxSendC = bodyIn.getChar(address + 0x20);
				wsdMainSend = bodyIn.getChar(address + 0x21);
				wsdPad1 = bodyIn.getChar(address + 0x22);
				wsdPad2 = bodyIn.getChar(address + 0x23);
				wsdGraphEnvTableRef = brawlReference(bodyIn.getLLong(address + 0x24));
				wsdRandomizerTableRef = brawlReference(bodyIn.getLLong(address + 0x2C));
				wsdPadding = bodyIn.getLong(address + 0x34);

				ttReferenceList1.populate(bodyIn, address + 0x38);
				ttIntermediateReference = brawlReference(bodyIn.getLLong(address + 0x44));
				ttReferenceList2.populate(bodyIn, address + 0x4C);
				ttPosition = bodyIn.getFloat(address + 0x58);
				ttLength = bodyIn.getFloat(address + 0x5C);
				ttNoteIndex = bodyIn.getLong(address + 0x60);
				ttReserved = bodyIn.getLong(address + 0x64);

				ntReferenceList.populate(bodyIn, address + 0x68);
				ntWaveIndex = bodyIn.getLong(address + 0x74);
				ntAttack = bodyIn.getChar(address + 0x78);
				ntDecay = bodyIn.getChar(address + 0x79);
				ntSustain = bodyIn.getChar(address + 0x7A);
				ntRelease = bodyIn.getChar(address + 0x7B);
				ntHold = bodyIn.getChar(address + 0x7C);
				ntPad1 = bodyIn.getChar(address + 0x7D);
				ntPad2 = bodyIn.getChar(address + 0x7E);
				ntPad3 = bodyIn.getChar(address + 0x7F);
				ntOriginalKey = bodyIn.getChar(address + 0x80);
				ntVolume = bodyIn.getChar(address + 0x81);
				ntPan = bodyIn.getChar(address + 0x82);
				ntSurroundPan = bodyIn.getChar(address + 0x83);
				ntPitch = bodyIn.getFloat(address + 0x84);
				ntIfoTableRef = brawlReference(bodyIn.getLLong(address + 0x88));
				ntGraphEnvTableRef = brawlReference(bodyIn.getLLong(address + 0x90));
				ntRandomizerTableRef = brawlReference(bodyIn.getLLong(address + 0x98));
				ntReserved = bodyIn.getLong(address + 0xA0);

				result = 1;
			}

			return result;
		}
		bool dataInfo::exportContents(std::ostream& destinationStream)
		{
			bool result = 0;
			if (destinationStream.good())
			{
				lava::writeRawDataToStream(destinationStream, wsdInfo.getHex());
				lava::writeRawDataToStream(destinationStream, trackTable.getHex());
				lava::writeRawDataToStream(destinationStream, noteTable.getHex());
				lava::writeRawDataToStream(destinationStream, wsdPitch);
				lava::writeRawDataToStream(destinationStream, wsdPan);
				lava::writeRawDataToStream(destinationStream, wsdSurroundPan);
				lava::writeRawDataToStream(destinationStream, wsdFxSendA);
				lava::writeRawDataToStream(destinationStream, wsdFxSendB);
				lava::writeRawDataToStream(destinationStream, wsdFxSendC);
				lava::writeRawDataToStream(destinationStream, wsdMainSend);
				lava::writeRawDataToStream(destinationStream, wsdPad1);
				lava::writeRawDataToStream(destinationStream, wsdPad2);
				lava::writeRawDataToStream(destinationStream, wsdGraphEnvTableRef.getHex());
				lava::writeRawDataToStream(destinationStream, wsdRandomizerTableRef.getHex());
				lava::writeRawDataToStream(destinationStream, wsdPadding);

				ttReferenceList1.exportContents(destinationStream);
				lava::writeRawDataToStream(destinationStream, ttIntermediateReference.getHex());
				ttReferenceList2.exportContents(destinationStream);
				lava::writeRawDataToStream(destinationStream, ttPosition);
				lava::writeRawDataToStream(destinationStream, ttLength);
				lava::writeRawDataToStream(destinationStream, ttNoteIndex);
				lava::writeRawDataToStream(destinationStream, ttReserved);

				ntReferenceList.exportContents(destinationStream);
				lava::writeRawDataToStream(destinationStream, ntWaveIndex);
				lava::writeRawDataToStream(destinationStream, ntAttack);
				lava::writeRawDataToStream(destinationStream, ntDecay);
				lava::writeRawDataToStream(destinationStream, ntSustain);
				lava::writeRawDataToStream(destinationStream, ntRelease);
				lava::writeRawDataToStream(destinationStream, ntHold);
				lava::writeRawDataToStream(destinationStream, ntPad1);
				lava::writeRawDataToStream(destinationStream, ntPad2);
				lava::writeRawDataToStream(destinationStream, ntPad3);
				lava::writeRawDataToStream(destinationStream, ntOriginalKey);
				lava::writeRawDataToStream(destinationStream, ntVolume);
				lava::writeRawDataToStream(destinationStream, ntPan);
				lava::writeRawDataToStream(destinationStream, ntSurroundPan);
				lava::writeRawDataToStream(destinationStream, ntPitch);
				lava::writeRawDataToStream(destinationStream, ntIfoTableRef.getHex());
				lava::writeRawDataToStream(destinationStream, ntGraphEnvTableRef.getHex());
				lava::writeRawDataToStream(destinationStream, ntRandomizerTableRef.getHex());
				lava::writeRawDataToStream(destinationStream, ntReserved);

				result = destinationStream.good();
			}
			return result;
		}

		/*Sound Data Structs*/



		/* BRSAR Symb Section */

		bool brsarSymbPTrieNode::populate(lava::byteArray& bodyIn, unsigned long addressIn)
		{
			bool result = 0;

			if (bodyIn.populated())
			{
				address = addressIn;

				isLeaf = bodyIn.getShort(addressIn);
				posAndBit = bodyIn.getShort(addressIn + 0x02);
				leftID = bodyIn.getLong(address + 0x04);
				rightID = bodyIn.getLong(address + 0x08);
				stringID = bodyIn.getLong(address + 0x0C);
				infoID = bodyIn.getLong(address + 0x10);

				result = 1;
			}

			return result;
		}
		bool brsarSymbPTrieNode::exportContents(std::ostream& destinationStream) const
		{
			bool result = 0;
			if (destinationStream.good())
			{
				lava::writeRawDataToStream(destinationStream, isLeaf);
				lava::writeRawDataToStream(destinationStream, posAndBit);
				lava::writeRawDataToStream(destinationStream, leftID);
				lava::writeRawDataToStream(destinationStream, rightID);
				lava::writeRawDataToStream(destinationStream, stringID);
				lava::writeRawDataToStream(destinationStream, infoID);

				result = destinationStream.good();
			}
			return result;
		}
		unsigned long brsarSymbPTrieNode::getBit() const
		{
			return posAndBit & 0b00000111;
		}
		unsigned long brsarSymbPTrieNode::getPos() const
		{
			return posAndBit >> 3;
		}
		bool brsarSymbPTrieNode::compareCharAndBit(char charIn) const
		{
			unsigned char comparisonTerm = 1 << (7 - getBit());
			return charIn & comparisonTerm;
		}

		bool brsarSymbPTrie::populate(lava::byteArray& bodyIn, unsigned long addressIn)
		{
			bool result = 0;

			if (bodyIn.populated())
			{
				address = addressIn;

				rootID = bodyIn.getLong(address);
				numEntries = bodyIn.getLong(address + 0x04);

				unsigned long cursor = address + 0x08;
				unsigned long cursorMax = cursor + (0x14 * numEntries);

				std::size_t i = 0;
				entries.resize(numEntries);

				while (cursor < cursorMax)
				{
					entries[i].populate(bodyIn, cursor);
					cursor += 0x14;
					i++;
				}

				result = 1;
			}

			return result;
		}
		bool brsarSymbPTrie::exportContents(std::ostream& destinationStream) const
		{
			bool result = 0;
			if (destinationStream.good())
			{
				lava::writeRawDataToStream(destinationStream, rootID);
				lava::writeRawDataToStream(destinationStream, numEntries);

				for (std::size_t i = 0; i < numEntries; i++)
				{
					entries[i].exportContents(destinationStream);
				}

				result = destinationStream.good();
			}
			return result;
		}
		brsarSymbPTrieNode brsarSymbPTrie::findString(std::string stringIn) const
		{
			if (rootID < numEntries)
			{
				const brsarSymbPTrieNode* currentNode = &entries[rootID];

				while (!currentNode->isLeaf)
				{
					int pos = currentNode->getPos();
					int bit = currentNode->getBit();
					if (pos < stringIn.size() && currentNode->compareCharAndBit(stringIn[pos]))
					{
						currentNode = &entries[currentNode->rightID];
					}
					else
					{
						currentNode = &entries[currentNode->leftID];
					}
				}

				return *currentNode;
			}
			return brsarSymbPTrieNode();
		}

		bool brsarSymbSection::populate(lava::byteArray& bodyIn, std::size_t addressIn)
		{
			bool result = 0;

			if (bodyIn.populated() && bodyIn.getLong(addressIn) == brsarHexTags::bht_SYMB)
			{
				result = 1;
				address = addressIn;

				std::size_t cursor1 = address + 0x04;

				length = bodyIn.getLong(cursor1, &cursor1);
				stringListOffset = bodyIn.getLong(cursor1, &cursor1);

				soundTrieOffset = bodyIn.getLong(cursor1, &cursor1);
				playerTrieOffset = bodyIn.getLong(cursor1, &cursor1);
				groupTrieOffset = bodyIn.getLong(cursor1, &cursor1);
				bankTrieOffset = bodyIn.getLong(cursor1, &cursor1);

				result &= soundTrie.populate(bodyIn, address + 0x08 + soundTrieOffset);
				result &= playerTrie.populate(bodyIn, address + 0x08 + playerTrieOffset);
				result &= groupTrie.populate(bodyIn, address + 0x08 + groupTrieOffset);
				result &= bankTrie.populate(bodyIn, address + 0x08 + bankTrieOffset);

				std::size_t cursor = address + 0x08 + stringListOffset;
				stringEntryOffsets.resize(bodyIn.getLong(cursor), ULONG_MAX);
				cursor += 0x04;
				for (std::size_t i = 0; i < stringEntryOffsets.size(); i++)
				{
					stringEntryOffsets[i] = bodyIn.getLong(cursor);
					cursor += 0x04;
				}
				if (stringEntryOffsets.size())
				{
					unsigned long stringBlockStartAddr = address + 0x08 + stringEntryOffsets.front();
					unsigned long stringBlockEndAddr = address + 0x08 + soundTrieOffset;
					if (stringBlockStartAddr < stringBlockEndAddr)
					{
						std::size_t numGotten = SIZE_MAX;
						stringBlock = bodyIn.getBytes(stringBlockEndAddr - stringBlockStartAddr, stringBlockStartAddr, numGotten);
					}
				}
			}

			return result;
		}
		bool brsarSymbSection::exportContents(std::ostream& destinationStream) const
		{
			bool result = 0;
			if (destinationStream.good())
			{
				result = 1;
				unsigned long initialStreamPos = destinationStream.tellp();

				lava::writeRawDataToStream(destinationStream, brsarHexTags::bht_SYMB);
				lava::writeRawDataToStream(destinationStream, length);
				lava::writeRawDataToStream(destinationStream, stringListOffset);
				lava::writeRawDataToStream(destinationStream, soundTrieOffset);
				lava::writeRawDataToStream(destinationStream, playerTrieOffset);
				lava::writeRawDataToStream(destinationStream, groupTrieOffset);
				lava::writeRawDataToStream(destinationStream, bankTrieOffset);

				/*for (std::size_t i = 0; i < trieOffsets.size(); i++)
				{
					lava::writeRawDataToStream(destinationStream, trieOffsets[i]);
				}*/

				lava::writeRawDataToStream(destinationStream, stringEntryOffsets.size());
				for (std::size_t i = 0; i < stringEntryOffsets.size(); i++)
				{
					lava::writeRawDataToStream(destinationStream, stringEntryOffsets[i]);
				}
				destinationStream.write((char*)stringBlock.data(), stringBlock.size());

				soundTrie.exportContents(destinationStream);
				playerTrie.exportContents(destinationStream);
				groupTrie.exportContents(destinationStream);
				bankTrie.exportContents(destinationStream);

				/*for (std::size_t i = 0; i < tries.size(); i++)
				{
					result &= tries[i].exportContents(destinationStream);
				}*/

				unsigned long finalStreamPos = destinationStream.tellp();
				unsigned long amountWritten = finalStreamPos - initialStreamPos;
				if (length > amountWritten)
				{
					std::vector<char> finalPadding(length - amountWritten, 0x00);
					destinationStream.write(finalPadding.data(), finalPadding.size());
				}

				result &= destinationStream.good();
			}
			return result;
		}
		std::string brsarSymbSection::getString(std::size_t idIn) const
		{
			std::string result = "";
			if (idIn < stringEntryOffsets.size())
			{
				unsigned long stringAddr = (stringEntryOffsets[idIn] - stringEntryOffsets.front());
				result = (char*)(stringBlock.data() + stringAddr);
			}
			return result;
		}
		bool brsarSymbSection::dumpTrieStrings(std::ostream& destinationStream, const brsarSymbPTrie& sourceTrie) const
		{
			bool result = 0;

			if (destinationStream.good())
			{
				for (std::size_t i = 0; i < sourceTrie.entries.size(); i++)
				{
					const brsarSymbPTrieNode* currNode = &sourceTrie.entries[i];
					if (currNode->isLeaf)
					{
						destinationStream << "[StrID: 0x" << numToHexStringWithPadding(currNode->stringID, 0x04) << ", InfoID: 0x" << numToHexStringWithPadding(currNode->infoID, 0x04) << "] " << getString(currNode->stringID) << "\n";
					}
				}
				result = destinationStream.good();
			}

			return result;
		}
		bool brsarSymbSection::dumpStrings(std::ostream& destinationStream) const
		{
			bool result = 0;

			if (destinationStream.good())
			{
				dumpTrieStrings(destinationStream, playerTrie);
				dumpTrieStrings(destinationStream, groupTrie);
				dumpTrieStrings(destinationStream, bankTrie);
				dumpTrieStrings(destinationStream, soundTrie);
				result = destinationStream.good();
			}

			return result;
		}

		/* BRSAR Symb Section */



		/* BRSAR Info Section */

		bool brsarInfo3DSoundInfo::populate(lava::byteArray& bodyIn, std::size_t addressIn)
		{
			bool result = 0;

			if (bodyIn.populated())
			{
				result = 1;
				address = addressIn;

				std::size_t cursor = address;
				flags = bodyIn.getLong(cursor, &cursor);
				decayCurve = bodyIn.getChar(cursor, &cursor);
				decayRatio = bodyIn.getChar(cursor, &cursor);
				dopplerFactor = bodyIn.getChar(cursor, &cursor);
				padding = bodyIn.getChar(cursor, &cursor);
				reserved = bodyIn.getLong(cursor, &cursor);
			}

			return result;
		}
		bool brsarInfo3DSoundInfo::exportContents(std::ostream& destinationStream)
		{
			bool result = 0;
			if (destinationStream.good())
			{
				lava::writeRawDataToStream(destinationStream, flags);
				lava::writeRawDataToStream(destinationStream, decayCurve);
				lava::writeRawDataToStream(destinationStream, decayRatio);
				lava::writeRawDataToStream(destinationStream, dopplerFactor);
				lava::writeRawDataToStream(destinationStream, padding);
				lava::writeRawDataToStream(destinationStream, reserved);

				result = destinationStream.good();
			}
			return result;
		}

		bool brsarInfoSequenceSoundInfo::populate(lava::byteArray& bodyIn, std::size_t addressIn)
		{
			bool result = 0;

			if (bodyIn.populated())
			{
				result = 1;
				address = addressIn;

				std::size_t cursor = address;
				dataID = bodyIn.getLong(cursor, &cursor);
				bankID = bodyIn.getLong(cursor, &cursor);
				allocTrack = bodyIn.getLong(cursor, &cursor);
				channelPriority = bodyIn.getChar(cursor, &cursor);
				releasePriorityFix = bodyIn.getChar(cursor, &cursor);
				pad1 = bodyIn.getChar(cursor, &cursor);
				pad2 = bodyIn.getChar(cursor, &cursor);
				reserved = bodyIn.getLong(cursor, &cursor);
			}

			return result;
		}
		bool brsarInfoSequenceSoundInfo::exportContents(std::ostream& destinationStream)
		{
			bool result = 0;
			if (destinationStream.good())
			{
				lava::writeRawDataToStream(destinationStream, dataID);
				lava::writeRawDataToStream(destinationStream, bankID);
				lava::writeRawDataToStream(destinationStream, allocTrack);
				lava::writeRawDataToStream(destinationStream, channelPriority);
				lava::writeRawDataToStream(destinationStream, releasePriorityFix);
				lava::writeRawDataToStream(destinationStream, pad1);
				lava::writeRawDataToStream(destinationStream, pad2);
				lava::writeRawDataToStream(destinationStream, reserved);

				result = destinationStream.good();
			}
			return result;
		}

		bool brsarInfoStreamSoundInfo::populate(lava::byteArray& bodyIn, std::size_t addressIn)
		{
			bool result = 0;

			if (bodyIn.populated())
			{
				result = 1;
				address = addressIn;

				std::size_t cursor = address;
				startPosition = bodyIn.getLong(cursor, &cursor);
				allocChannelCount = bodyIn.getShort(cursor, &cursor);
				allocTrackFlag = bodyIn.getShort(cursor, &cursor);
				reserved = bodyIn.getLong(cursor, &cursor);
			}

			return result;
		}
		bool brsarInfoStreamSoundInfo::exportContents(std::ostream& destinationStream)
		{
			bool result = 0;
			if (destinationStream.good())
			{
				lava::writeRawDataToStream(destinationStream, startPosition);
				lava::writeRawDataToStream(destinationStream, allocChannelCount);
				lava::writeRawDataToStream(destinationStream, allocTrackFlag);
				lava::writeRawDataToStream(destinationStream, reserved);

				result = destinationStream.good();
			}
			return result;
		}

		bool brsarInfoWaveSoundInfo::populate(lava::byteArray& bodyIn, std::size_t addressIn)
		{
			bool result = 0;

			if (bodyIn.populated())
			{
				result = 1;
				address = addressIn;

				std::size_t cursor = address;
				soundIndex = bodyIn.getLong(cursor, &cursor);
				allocTrack = bodyIn.getLong(cursor, &cursor);
				channelPriority = bodyIn.getChar(cursor, &cursor);
				releasePriorityFix = bodyIn.getChar(cursor, &cursor);
				pad1 = bodyIn.getChar(cursor, &cursor);
				pad2 = bodyIn.getChar(cursor, &cursor);
				reserved = bodyIn.getLong(cursor, &cursor);
			}

			return result;
		}
		bool brsarInfoWaveSoundInfo::exportContents(std::ostream& destinationStream)
		{
			bool result = 0;
			if (destinationStream.good())
			{
				lava::writeRawDataToStream(destinationStream, soundIndex);
				lava::writeRawDataToStream(destinationStream, allocTrack);
				lava::writeRawDataToStream(destinationStream, channelPriority);
				lava::writeRawDataToStream(destinationStream, releasePriorityFix);
				lava::writeRawDataToStream(destinationStream, pad1);
				lava::writeRawDataToStream(destinationStream, pad2);
				lava::writeRawDataToStream(destinationStream, reserved);

				result = destinationStream.good();
			}
			return result;
		}

		bool brsarInfoSoundEntry::populate(lava::byteArray& bodyIn, std::size_t addressIn)
		{
			bool result = 0;

			if (bodyIn.populated())
			{
				result = 1;
				address = addressIn;

				stringID = bodyIn.getLong(address);
				fileID = bodyIn.getLong(address + 0x04);
				playerID = bodyIn.getLong(address + 0x08);
				param3DRefOffset = brawlReference(bodyIn.getLLong(address + 0x0C));
				volume = bodyIn.getChar(address + 0x14);
				playerPriority = bodyIn.getChar(address + 0x15);
				soundType = bodyIn.getChar(address + 0x16);
				remoteFilter = bodyIn.getChar(address + 0x17);
				soundInfoRef = brawlReference(bodyIn.getLLong(address + 0x18));
				userParam1 = bodyIn.getLong(address + 0x20);
				userParam2 = bodyIn.getLong(address + 0x24);
				panMode = bodyIn.getChar(address + 0x28);
				panCurve = bodyIn.getChar(address + 0x29);
				actorPlayerID = bodyIn.getChar(address + 0x2A);
				reserved = bodyIn.getChar(address + 0x2B);
			}

			return result;
		}
		bool brsarInfoSoundEntry::exportContents(std::ostream& destinationStream)
		{
			bool result = 0;
			if (destinationStream.good())
			{
				lava::writeRawDataToStream(destinationStream, stringID);
				lava::writeRawDataToStream(destinationStream, fileID);
				lava::writeRawDataToStream(destinationStream, playerID);
				lava::writeRawDataToStream(destinationStream, param3DRefOffset.getHex());
				lava::writeRawDataToStream(destinationStream, volume);
				lava::writeRawDataToStream(destinationStream, playerPriority);
				lava::writeRawDataToStream(destinationStream, soundType);
				lava::writeRawDataToStream(destinationStream, remoteFilter);
				lava::writeRawDataToStream(destinationStream, soundInfoRef.getHex());
				lava::writeRawDataToStream(destinationStream, userParam1);
				lava::writeRawDataToStream(destinationStream, userParam2);
				lava::writeRawDataToStream(destinationStream, panMode);
				lava::writeRawDataToStream(destinationStream, panCurve);
				lava::writeRawDataToStream(destinationStream, actorPlayerID);
				lava::writeRawDataToStream(destinationStream, reserved);
				switch (soundType)
				{
					case sit_SEQUENCE:
					{
						seqSoundInfo.exportContents(destinationStream);
						break;
					}
					case sit_STREAM:
					{
						streamSoundInfo.exportContents(destinationStream);
						break;
					}
					case sit_WAVE:
					{
						waveSoundInfo.exportContents(destinationStream);
						break;
					}
					default:
					{
						break;
					}
				}
				sound3DInfo.exportContents(destinationStream);
				result = destinationStream.good();
			}
			return result;
		}

		bool brsarInfoBankEntry::populate(lava::byteArray& bodyIn, std::size_t addressIn)
		{
			bool result = 0;

			if (bodyIn.populated())
			{
				result = 1;
				address = addressIn;

				std::size_t cursor = address;
				stringID = bodyIn.getLong(cursor, &cursor);
				fileID = bodyIn.getLong(cursor, &cursor);
				padding = bodyIn.getLong(cursor, &cursor);
			}

			return result;
		}
		bool brsarInfoBankEntry::exportContents(std::ostream& destinationStream)
		{
			bool result = 0;
			if (destinationStream.good())
			{
				lava::writeRawDataToStream(destinationStream, stringID);
				lava::writeRawDataToStream(destinationStream, fileID);
				lava::writeRawDataToStream(destinationStream, padding);

				result = destinationStream.good();
			}
			return result;
		}

		bool brsarInfoPlayerEntry::populate(lava::byteArray& bodyIn, std::size_t addressIn)
		{
			bool result = 0;

			if (bodyIn.populated())
			{
				result = 1;
				address = addressIn;

				std::size_t cursor = address;
				stringID = bodyIn.getLong(cursor, &cursor);
				playableSoundCount = bodyIn.getChar(cursor, &cursor);
				padding = bodyIn.getChar(cursor, &cursor);
				padding2 = bodyIn.getShort(cursor, &cursor);
				heapSize = bodyIn.getLong(cursor, &cursor);
				reserved = bodyIn.getLong(cursor, &cursor);
			}

			return result;
		}
		bool brsarInfoPlayerEntry::exportContents(std::ostream& destinationStream)
		{
			bool result = 0;
			if (destinationStream.good())
			{
				lava::writeRawDataToStream(destinationStream, stringID);
				lava::writeRawDataToStream(destinationStream, playableSoundCount);
				lava::writeRawDataToStream(destinationStream, padding);
				lava::writeRawDataToStream(destinationStream, padding2);
				lava::writeRawDataToStream(destinationStream, heapSize);
				lava::writeRawDataToStream(destinationStream, reserved);

				result = destinationStream.good();
			}
			return result;
		}

		bool brsarInfoFileEntry::populate(lava::byteArray& bodyIn, std::size_t addressIn)
		{
			bool result = 0;

			if (bodyIn.populated())
			{
				result = 1;
				address = addressIn;

				groupID = bodyIn.getLong(address);
				index = bodyIn.getLong(address + 0x04);
			}

			return result;
		}
		bool brsarInfoFileEntry::exportContents(std::ostream& destinationStream)
		{
			bool result = 0;
			if (destinationStream.good())
			{
				lava::writeRawDataToStream(destinationStream, groupID);
				lava::writeRawDataToStream(destinationStream, index);

				result = destinationStream.good();
			}
			return result;
		}
		bool brsarInfoFileHeader::populate(lava::byteArray& bodyIn, std::size_t addressIn)
		{
			bool result = 0;

			if (bodyIn.populated())
			{
				result = 1;
				address = addressIn;

				headerLength = bodyIn.getLong(address);
				dataLength = bodyIn.getLong(address + 0x04);
				entryNumber = bodyIn.getLong(address + 0x08);
				stringOffset = brawlReference(bodyIn.getLLong(address + 0x0C));
				listOffset = brawlReference(bodyIn.getLLong(address + 0x14));
			}

			return result;
		}
		bool brsarInfoFileHeader::exportContents(std::ostream& destinationStream)
		{
			bool result = 0;
			if (destinationStream.good())
			{
				result = 1;
				lava::writeRawDataToStream(destinationStream, headerLength);
				lava::writeRawDataToStream(destinationStream, dataLength);
				lava::writeRawDataToStream(destinationStream, entryNumber);
				lava::writeRawDataToStream(destinationStream, stringOffset.getHex());
				lava::writeRawDataToStream(destinationStream, listOffset.getHex());
				destinationStream.write((char*)stringContent.data(), stringContent.size());
				result &= entryReferenceList.exportContents(destinationStream);
				for (std::size_t i = 0; i < entries.size(); i++)
				{
					result &= entries[i].exportContents(destinationStream);
				}
				result &= destinationStream.good();
			}
			return result;
		}

		bool brsarInfoGroupEntry::populate(lava::byteArray& bodyIn, std::size_t addressIn)
		{
			bool result = 0;

			if (bodyIn.populated())
			{
				address = addressIn;

				fileID = bodyIn.getLong(address);
				headerOffset = bodyIn.getLong(address + 0x04);
				headerLength = bodyIn.getLong(address + 0x08);
				dataOffset = bodyIn.getLong(address + 0x0C);
				dataLength = bodyIn.getLong(address + 0x10);
				reserved = bodyIn.getLong(address + 0x14);

				result = 1;
			}

			return result;
		}
		bool brsarInfoGroupEntry::exportContents(std::ostream& destinationStream)
		{
			bool result = 0;
			if (destinationStream.good())
			{
				lava::writeRawDataToStream(destinationStream, fileID);
				lava::writeRawDataToStream(destinationStream, headerOffset);
				lava::writeRawDataToStream(destinationStream, headerLength);
				lava::writeRawDataToStream(destinationStream, dataOffset);
				lava::writeRawDataToStream(destinationStream, dataLength);
				lava::writeRawDataToStream(destinationStream, reserved);

				result = destinationStream.good();
			}
			return result;
		}
		unsigned long brsarInfoGroupHeader::getSynonymFileID(std::size_t headerLengthIn) const
		{
			unsigned long result = ULONG_MAX;

			for (unsigned long i = 0; result == ULONG_MAX && i < entries.size(); i++)
			{
				if (headerLengthIn == entries[i].headerLength)
				{
					result = entries[i].fileID;
				}
			}

			return result;
		}
		bool brsarInfoGroupHeader::usesFileID(unsigned long fileIDIn) const
		{
			bool result = 0;

			for (unsigned long i = 0; !result && i < entries.size(); i++)
			{
				result = fileIDIn == entries[i].fileID;
			}

			return result;
		}
		bool brsarInfoGroupHeader::populate(lava::byteArray& bodyIn, std::size_t addressIn)
		{
			bool result = 0;

			if (bodyIn.populated())
			{
				address = addressIn;

				groupID = bodyIn.getLong(address);
				entryNum = bodyIn.getLong(address + 0x04);
				extFilePathRef = brawlReference(bodyIn.getLLong(address + 0x08));
				headerAddress = bodyIn.getLong(address + 0x10);
				headerLength = bodyIn.getLong(address + 0x14);
				dataAddress = bodyIn.getLong(address + 0x18);
				dataLength = bodyIn.getLong(address + 0x1C);
				listOffset = brawlReference(bodyIn.getLLong(address + 0x20));

				result = 1;
			}

			return result;
		}
		bool brsarInfoGroupHeader::exportContents(std::ostream& destinationStream)
		{
			bool result = 0;
			if (destinationStream.good())
			{
				result = 1;
				lava::writeRawDataToStream(destinationStream, groupID);
				lava::writeRawDataToStream(destinationStream, entryNum);
				lava::writeRawDataToStream(destinationStream, extFilePathRef.getHex());
				lava::writeRawDataToStream(destinationStream, headerAddress);
				lava::writeRawDataToStream(destinationStream, headerLength);
				lava::writeRawDataToStream(destinationStream, dataAddress);
				lava::writeRawDataToStream(destinationStream, dataLength);
				lava::writeRawDataToStream(destinationStream, listOffset.getHex());
				result &= entryReferenceList.exportContents(destinationStream);
				for (std::size_t i = 0; i < entries.size(); i++)
				{
					result &= entries[i].exportContents(destinationStream);
				}
				result &= destinationStream.good();
			}
			return result;
		}

		brsarInfoGroupHeader* brsarInfoSection::getGroupWithID(unsigned long groupIDIn)
		{
			brsarInfoGroupHeader* result = nullptr;

			unsigned long i = 0;

			while (result == nullptr && i < groupHeaders.size())
			{
				if (groupIDIn == groupHeaders[i].groupID)
				{
					result = &groupHeaders[i];
				}
				i++;
			}

			return result;
		}
		brsarInfoGroupHeader* brsarInfoSection::getGroupWithInfoIndex(unsigned long infoIndexIn)
		{
			brsarInfoGroupHeader* result = nullptr;

			if (infoIndexIn < groupHeaders.size())
			{
				result = &groupHeaders[infoIndexIn];
			}

			return result;
		}

		std::vector<brsarInfoFileHeader*> brsarInfoSection::getFilesWithGroupID(unsigned long groupIDIn)
		{
			std::vector<brsarInfoFileHeader*> result{};

			brsarInfoGroupHeader* targetGroupHeader = getGroupWithID(groupIDIn);
			if (targetGroupHeader != nullptr)
			{
				for (unsigned long i = 0; i < targetGroupHeader->entries.size(); i++)
				{
					brsarInfoGroupEntry* currentGroupEntry = &targetGroupHeader->entries[i];
					if (currentGroupEntry->fileID < fileHeaders.size())
					{
						result.push_back( &fileHeaders[currentGroupEntry->fileID]);
					}
				}
			}

			return result;
		}
		brsarInfoFileHeader* brsarInfoSection::getFileHeaderPointer(unsigned long fileID)
		{
			brsarInfoFileHeader* result = nullptr;

			if (fileID < fileHeaders.size())
			{
				result = &fileHeaders[fileID];
			}

			return result;
		}


		bool brsarInfoSection::summarizeFileEntryData(std::ostream& output)
		{
			bool result = 0;
			if (output.good())
			{
				output << "There are " << fileHeaders.size() << " File Info Entries(s) in this BRSAR:\n";
				for (unsigned long i = 0; i < fileHeaders.size(); i++)
				{
					brsarInfoFileHeader* currHeaderPtr = &fileHeaders[i];
					output << "File Info #" << i << " (@ 0x" << numToHexStringWithPadding(currHeaderPtr->address, 0x08) << "):\n";
					output << "\tFile String: \"";
					if (!currHeaderPtr->stringContent.empty())
					{
						output << std::string((char*)currHeaderPtr->stringContent.data());
					}
					output << "\"\n";
					output << "\tFile Header Length: " << currHeaderPtr->headerLength << " byte(s)\n";
					output << "\tFile Data Length: " << currHeaderPtr->dataLength << " byte(s)\n";
					output << "\tFile Entry Number: " << currHeaderPtr->entryNumber << "\n";
					output << "\tFile Entries:\n";
					for (unsigned long u = 0; u < currHeaderPtr->entries.size(); u++)
					{
						brsarInfoFileEntry* currEntryPtr = &currHeaderPtr->entries[u];
						output << "\tEntry #" << u << " (@ 0x" << numToHexStringWithPadding(currEntryPtr->address, 0x08) << "):\n";
						output << "\t\tEntry Index: " << currEntryPtr->index << "\n";
						output << "\t\tGroup ID: " << currEntryPtr->groupID << "\n";
					}
				}
				result = output.good();
			}
			return result;
		}
		bool brsarInfoSection::populate(lava::byteArray& bodyIn, std::size_t addressIn)
		{
			bool result = 0;

			if (bodyIn.populated() && bodyIn.getLong(addressIn) == brsarHexTags::bht_INFO)
			{
				result = 1;
				address = addressIn;

				length = bodyIn.getLong(address + 0x04);
				soundsSectionReference = brawlReference(bodyIn.getLLong(address + 0x08));
				banksSectionReference = brawlReference(bodyIn.getLLong(address + 0x10));
				playerSectionReference = brawlReference(bodyIn.getLLong(address + 0x18));
				filesSectionReference = brawlReference(bodyIn.getLLong(address + 0x20));
				groupsSectionReference = brawlReference(bodyIn.getLLong(address + 0x28));
				footerReference = brawlReference(bodyIn.getLLong(address + 0x30));

				result &= soundsSection.populate(bodyIn, soundsSectionReference.getAddress(address + 0x08));
				result &= banksSection.populate(bodyIn, banksSectionReference.getAddress(address + 0x08));
				result &= playerSection.populate(bodyIn, playerSectionReference.getAddress(address + 0x08));
				result &= filesSection.populate(bodyIn, filesSectionReference.getAddress(address + 0x08));
				result &= groupsSection.populate(bodyIn, groupsSectionReference.getAddress(address + 0x08));

				brsarInfoSoundEntry* currSoundEntry = nullptr;
				soundEntries.resize(soundsSection.refs.size());
				for (std::size_t i = 0; i < soundsSection.refs.size(); i++)
				{
					currSoundEntry = &soundEntries[i];
					result &= currSoundEntry->populate(bodyIn, soundsSection.refs[i].getAddress(address + 0x08));
					currSoundEntry->sound3DInfo.populate(bodyIn, currSoundEntry->param3DRefOffset.getAddress(address + 0x08));
					switch (currSoundEntry->soundType)
					{
						case sit_SEQUENCE:
						{
							currSoundEntry->seqSoundInfo.populate(bodyIn, currSoundEntry->soundInfoRef.getAddress(address + 0x08));
							break;
						}
						case sit_STREAM:
						{
							currSoundEntry->streamSoundInfo.populate(bodyIn, currSoundEntry->soundInfoRef.getAddress(address + 0x08));
							break;
						}
						case sit_WAVE:
						{
							currSoundEntry->waveSoundInfo.populate(bodyIn, currSoundEntry->soundInfoRef.getAddress(address + 0x08));
							break;
						}
						default:
						{
							break;
						}
					}
				}

				bankEntries.resize(banksSection.refs.size());
				for (std::size_t i = 0; i < banksSection.refs.size(); i++)
				{
					result &= bankEntries[i].populate(bodyIn, banksSection.refs[i].getAddress(address + 0x08));
				}

				playerEntries.resize(playerSection.refs.size());
				for (std::size_t i = 0; i < playerSection.refs.size(); i++)
				{
					result &= playerEntries[i].populate(bodyIn, playerSection.refs[i].getAddress(address + 0x08));
				}

				fileHeaders.resize(filesSection.refs.size());
				brsarInfoFileHeader* currFileHeader = nullptr;
				for (std::size_t i = 0; i < filesSection.refs.size(); i++)
				{
					currFileHeader = &fileHeaders[i];
					currFileHeader->populate(bodyIn, filesSection.refs[i].getAddress(address + 0x08));
					if (currFileHeader->stringOffset.getAddress() != 0x00)
					{
						std::size_t numGotten = SIZE_MAX;
						std::string measurementString = bodyIn.data() + (currFileHeader->stringOffset.getAddress(address + 0x08));
						std::size_t sizePrescription = measurementString.size() + (0x04 - (measurementString.size() % 0x04));
						currFileHeader->stringContent = bodyIn.getBytes(sizePrescription, currFileHeader->stringOffset.getAddress(address + 0x08), numGotten);
						result &= numGotten == sizePrescription;
					}
					if (currFileHeader->listOffset.getAddress() != 0x00)
					{
						result &= currFileHeader->entryReferenceList.populate(bodyIn, currFileHeader->listOffset.getAddress(address + 0x08));
						for (std::size_t u = 0; u < currFileHeader->entryReferenceList.refs.size(); u++)
						{
							currFileHeader->entries.push_back(brsarInfoFileEntry());
							result &= currFileHeader->entries.back().populate(bodyIn, currFileHeader->entryReferenceList.refs[u].getAddress(address + 0x08));
						}
					}
				}

				groupHeaders.resize(groupsSection.refs.size());
				brsarInfoGroupHeader* currGroupHeader = nullptr;
				for (std::size_t i = 0; i < groupsSection.refs.size(); i++)
				{
					currGroupHeader = &groupHeaders[i];
					currGroupHeader->populate(bodyIn, groupsSection.refs[i].getAddress(address + 0x08));
					result &= currGroupHeader->entryReferenceList.populate(bodyIn, currGroupHeader->listOffset.getAddress(address + 0x08));

					for (std::size_t u = 0; u < currGroupHeader->entryReferenceList.refs.size(); u++)
					{
						currGroupHeader->entries.push_back(brsarInfoGroupEntry());
						result &= currGroupHeader->entries.back().populate(bodyIn, currGroupHeader->entryReferenceList.refs[u].getAddress(address + 0x08));
					}
				}

				std::size_t cursor = footerReference.getAddress(address + 0x08);
				sequenceMax = bodyIn.getShort(cursor, &cursor);
				sequenceTrackMax = bodyIn.getShort(cursor, &cursor);
				streamMax = bodyIn.getShort(cursor, &cursor);
				streamTrackMax = bodyIn.getShort(cursor, &cursor);
				streamChannelsMax = bodyIn.getShort(cursor, &cursor);
				waveMax = bodyIn.getShort(cursor, &cursor);
				waveTrackMax = bodyIn.getShort(cursor, &cursor);
				padding = bodyIn.getShort(cursor, &cursor);
				reserved = bodyIn.getLong(cursor, &cursor);
			}

			return result;
		}
		bool brsarInfoSection::exportContents(std::ostream& destinationStream)
		{
			bool result = 0;
			if (destinationStream.good())
			{
				result = 1;
				unsigned long initialStreamPos = destinationStream.tellp();

				lava::writeRawDataToStream(destinationStream, brsarHexTags::bht_INFO);
				lava::writeRawDataToStream(destinationStream, length);
				lava::writeRawDataToStream(destinationStream, soundsSectionReference.getHex());
				lava::writeRawDataToStream(destinationStream, banksSectionReference.getHex());
				lava::writeRawDataToStream(destinationStream, playerSectionReference.getHex());
				lava::writeRawDataToStream(destinationStream, filesSectionReference.getHex());
				lava::writeRawDataToStream(destinationStream, groupsSectionReference.getHex());
				lava::writeRawDataToStream(destinationStream, footerReference.getHex());
				soundsSection.exportContents(destinationStream);
				for (std::size_t i = 0; i < soundEntries.size(); i++)
				{
					soundEntries[i].exportContents(destinationStream);
				}
				banksSection.exportContents(destinationStream);
				for (std::size_t i = 0; i < bankEntries.size(); i++)
				{
					bankEntries[i].exportContents(destinationStream);
				}
				playerSection.exportContents(destinationStream);
				for (std::size_t i = 0; i < playerEntries.size(); i++)
				{
					playerEntries[i].exportContents(destinationStream);
				}
				filesSection.exportContents(destinationStream);
				for (std::size_t i = 0; i < fileHeaders.size(); i++)
				{
					fileHeaders[i].exportContents(destinationStream);
				}
				groupsSection.exportContents(destinationStream);
				for (std::size_t i = 0; i < groupHeaders.size(); i++)
				{
					groupHeaders[i].exportContents(destinationStream);
				}
				unsigned long pos = destinationStream.tellp();

				lava::writeRawDataToStream(destinationStream, sequenceMax);
				lava::writeRawDataToStream(destinationStream, sequenceTrackMax);
				lava::writeRawDataToStream(destinationStream, streamMax);
				lava::writeRawDataToStream(destinationStream, streamTrackMax);
				lava::writeRawDataToStream(destinationStream, streamChannelsMax);
				lava::writeRawDataToStream(destinationStream, waveMax);
				lava::writeRawDataToStream(destinationStream, waveTrackMax);
				lava::writeRawDataToStream(destinationStream, padding);
				lava::writeRawDataToStream(destinationStream, reserved);

				unsigned long finalStreamPos = destinationStream.tellp();
				unsigned long amountWritten = finalStreamPos - initialStreamPos;
				if (length > amountWritten)
				{
					std::vector<char> finalPadding(length - amountWritten, 0x00);
					destinationStream.write(finalPadding.data(), finalPadding.size());
				}

				result = destinationStream.good();
			}
			return result;
		}

		/* BRSAR Info Section */



		/* BRSAR File Section */

		std::vector<brsarFileFileContents*> brsarFileSection::getFileContentsPointerVector(unsigned long fileID)
		{
			std::vector<brsarFileFileContents*> result{};

			auto findRes = fileIDToIndex.find(fileID);
			if (findRes != fileIDToIndex.end())
			{
				std::vector<std::size_t>* indexVecPtr = &findRes->second;
				for (unsigned long i = 0; i < indexVecPtr->size(); i++)
				{
					brsarFileFileContents* currFileContentsPtr = &fileContents[(*indexVecPtr)[i]];
					result.push_back(currFileContentsPtr);
				}
			}

			return result;
		}
		brsarFileFileContents* brsarFileSection::getFileContentsPointer(unsigned long fileID, unsigned long groupID)
		{
			brsarFileFileContents* result = nullptr;

			std::vector<brsarFileFileContents*> pointerVec = getFileContentsPointerVector(fileID);
			unsigned long i = 0;
			while (result == nullptr && i < pointerVec.size())
			{
				if (groupID == ULONG_MAX || pointerVec[i]->groupID == groupID)
				{
					result = pointerVec[i];
				}
				i++;
			}

			return result;
		}
		bool brsarFileSection::propogateFileLengthChange(signed long changeAmount, unsigned long pastThisAddress)
		{
			bool result = 1;

			length += changeAmount;
			for (unsigned long i = 0; i < fileContents.size(); i++)
			{
				brsarFileFileContents* currFile = &fileContents[i];
				adjustOffset(0x00, currFile->headerAddress, changeAmount, pastThisAddress);
				adjustOffset(0x00, currFile->dataAddress, changeAmount, pastThisAddress);
			}

			return result;
		}
		bool brsarFileSection::populate(lava::byteArray& bodyIn, std::size_t addressIn, brsarInfoSection& infoSectionIn)
		{
			bool result = 0;

			if (bodyIn.populated() && bodyIn.getLong(addressIn) == brsarHexTags::bht_FILE)
			{
				address = addressIn;
				length = bodyIn.getLong(address + 0x04);
				brsarInfoGroupHeader* currHeader = nullptr;
				brsarInfoGroupEntry* currEntry = nullptr;
				for (std::size_t i = 0; i < infoSectionIn.groupHeaders.size(); i++)
				{
					currHeader = &infoSectionIn.groupHeaders[i];
					for (std::size_t u = 0; u < currHeader->entries.size(); u++)
					{
						currEntry = &currHeader->entries[u];
						std::size_t numGotten = ULONG_MAX;
						fileContents.push_back(brsarFileFileContents());
						fileContents.back().fileID = currEntry->fileID;
						fileContents.back().groupInfoIndex = i;
						fileContents.back().groupID = currHeader->groupID;
						fileContents.back().headerAddress = currHeader->headerAddress + currEntry->headerOffset;
						fileContents.back().header = bodyIn.getBytes(currEntry->headerLength, currHeader->headerAddress + currEntry->headerOffset, numGotten);
						fileContents.back().dataAddress = currHeader->dataAddress + currEntry->dataOffset;
						fileContents.back().data = bodyIn.getBytes(currEntry->dataLength, currHeader->dataAddress + currEntry->dataOffset, numGotten);
						fileIDToIndex[currEntry->fileID].push_back(fileContents.size() - 1);
					}
				}
				result = 1;
			}

			return result;
		}
		bool brsarFileSection::exportContents(std::ostream& destinationStream)
		{
			bool result = 0;

			if (destinationStream.good())
			{
				byteArray tempArray(length, 0x00);
				tempArray.setLong(brsarHexTags::bht_FILE, 0x00);
				tempArray.setLong(length, 0x04);
				for (unsigned long i = 0; i < fileContents.size(); i++)
				{
					brsarFileFileContents* currFilePtr = &fileContents[i];
					if (currFilePtr->headerAddress > address)
					{
						tempArray.setBytes(currFilePtr->header, currFilePtr->headerAddress - address);
					}
					else
					{
						std::cerr << "Invalid header address!\n";
					}
					if (currFilePtr->dataAddress > address)
					{
						tempArray.setBytes(currFilePtr->data, currFilePtr->dataAddress - address);
					}
					else
					{
						std::cerr << "Invalid data address!\n";
					}
				}
				tempArray.dumpToStream(destinationStream);
				result = destinationStream.good();
			}

			return result;
		}

		/* RWSD */

		bool rwsdWaveSection::populate(const lava::byteArray& bodyIn, std::size_t addressIn)
		{
			bool result = 0;

			if (bodyIn.populated())
			{
				address = addressIn;

				length = bodyIn.getLong(addressIn + 0x04);
				unsigned long entryCount = bodyIn.getLong(addressIn + 0x08);

				for (unsigned long cursor = 0x0; cursor < (entryCount * 4); cursor += 0x04)
				{
					entryOffsets.push_back(bodyIn.getLong(address + 0x0C + cursor));
					entries.push_back(waveInfo());
					entries.back().populate(bodyIn, address + entryOffsets.back());
				}

				result = 1;
			}

			return result;
		}
		bool rwsdWaveSection::exportContents(std::ostream& destinationStream)
		{
			bool result = 0;
			if (destinationStream.good())
			{
				unsigned long initialStreamPos = destinationStream.tellp();

				destinationStream << "WAVE";
				lava::writeRawDataToStream(destinationStream, length);
				lava::writeRawDataToStream<unsigned long>(destinationStream, entries.size());

				for (unsigned long i = 0x0; i < entryOffsets.size(); i++)
				{
					lava::writeRawDataToStream(destinationStream, entryOffsets[i]);
				}
				for (unsigned long i = 0x0; i < entries.size(); i++)
				{
					entries[i].exportContents(destinationStream);
				}

				unsigned long finalStreamPos = destinationStream.tellp();
				unsigned long lengthOfExport = finalStreamPos - initialStreamPos;
				if (lengthOfExport != length)
				{
					if (lengthOfExport < length)
					{
						std::vector<char> padding{};
						padding.resize(length - lengthOfExport, 0x00);
						destinationStream.write(padding.data(), padding.size());
					}
				}

				result = destinationStream.good();
			}
			return result;
		}
		bool rwsdDataSection::hasExclusiveWave(unsigned long dataSectionIndex)
		{
			bool result = 1;
			if (dataSectionIndex < entries.size())
			{
				dataInfo* dataInfoEntry = &entries[dataSectionIndex];
				unsigned long dataWaveIndex = dataInfoEntry->ntWaveIndex;

				std::size_t i = 0;
				while (result && i < entries.size())
				{
					if (i != dataSectionIndex)
					{
						result = dataWaveIndex != entries[i].ntWaveIndex;
					}
					i++;
				}
			}
			return result;
		}
		bool rwsdDataSection::isFirstToUseWave(unsigned long dataSectionIndex)
		{
			bool result = 1;
			if (dataSectionIndex < entries.size())
			{
				dataInfo* dataInfoEntry = &entries[dataSectionIndex];
				unsigned long dataWaveIndex = dataInfoEntry->ntWaveIndex;

				std::size_t i = 0;
				while (result && i < dataSectionIndex)
				{
					result = dataWaveIndex != entries[i].ntWaveIndex;
					i++;
				}
			}
			return result;
		}
		bool rwsdDataSection::populate(const lava::byteArray& bodyIn, std::size_t addressIn)
		{
			bool result = 0;

			if (bodyIn.populated())
			{
				address = addressIn;
				length = bodyIn.getLong(addressIn + 0x04);
				entryReferences.populate(bodyIn, addressIn + 0x08);
				std::vector<brawlReference>* refVecPtr = &entryReferences.refs;
				std::size_t entryCount = refVecPtr->size();
				unsigned long entryTargetAddress = ULONG_MAX;
				entries.resize(entryCount);
				for (std::size_t i = 0; i < entryCount; i++)
				{
					entryTargetAddress = address + 0x08 + refVecPtr->at(i).getAddress();
					if (bodyIn.getLong(entryTargetAddress) == 0x01000000)
					{
						entries[i].populate(bodyIn, entryTargetAddress);
					}
					else
					{
						std::cerr << "Skipping Data Entry @ " << entryTargetAddress << "\n";
					}
				}

				result = 1;
			}

			return result;
		}
		bool rwsdDataSection::exportContents(std::ostream& destinationStream)
		{
			bool result = 0;
			if (destinationStream.good())
			{
				unsigned long initialStreamPos = destinationStream.tellp();
				destinationStream << "DATA";
				lava::writeRawDataToStream(destinationStream, length);
				entryReferences.exportContents(destinationStream);
				for (std::size_t i = 0; i < entries.size(); i++)
				{
					entries[i].exportContents(destinationStream);
				}
				unsigned long finalStreamPos = destinationStream.tellp();
				unsigned long lengthOfExport = finalStreamPos - initialStreamPos;
				if (lengthOfExport != length)
				{
					if (lengthOfExport < length)
					{
						std::vector<char> padding{};
						padding.resize(length - lengthOfExport, 0x00);
						destinationStream.write(padding.data(), padding.size());
					}
				}
				result = destinationStream.good();
			}
			return result;
		}

		bool rwsdHeader::populate(const lava::byteArray& bodyIn, std::size_t addressIn)
		{
			bool result = 0;

			if (bodyIn.populated())
			{
				address = addressIn;
				endianType = bodyIn.getShort(addressIn + 0x04);
				version = bodyIn.getShort(addressIn + 0x06);
				headerLength = bodyIn.getLong(addressIn + 0x08);
				entriesOffset = bodyIn.getShort(addressIn + 0x0C);
				entriesCount = bodyIn.getShort(addressIn + 0x0E);

				dataOffset = bodyIn.getLong(addressIn + 0x10);
				dataLength = bodyIn.getLong(addressIn + 0x14);
				waveOffset = bodyIn.getLong(addressIn + 0x18);
				waveLength = bodyIn.getLong(addressIn + 0x1C);
				result = 1;
			}

			return result;
		}
		bool rwsdHeader::exportContents(std::ostream& destinationStream)
		{
			bool result = 0;
			if (destinationStream.good())
			{
				destinationStream << "RWSD";
				lava::writeRawDataToStream(destinationStream, endianType);
				lava::writeRawDataToStream(destinationStream, version);
				lava::writeRawDataToStream(destinationStream, headerLength);
				lava::writeRawDataToStream(destinationStream, entriesOffset);
				lava::writeRawDataToStream(destinationStream, entriesCount);
				lava::writeRawDataToStream(destinationStream, dataOffset);
				lava::writeRawDataToStream(destinationStream, dataLength);
				lava::writeRawDataToStream(destinationStream, waveOffset);
				lava::writeRawDataToStream(destinationStream, waveLength);

				result = destinationStream.good();
			}
			return result;
		}

		bool rwsd::updateWaveEntryDataLocations()
		{
			bool result = 1;

			unsigned long positionAccumulator = 0x00;
			for (unsigned long i = 0; i < waveSection.entries.size(); i++)
			{
				waveInfo* currEntry = &waveSection.entries[i];
				currEntry->dataLocation = positionAccumulator;
				positionAccumulator += currEntry->packetContents.body.size() + currEntry->packetContents.padding.size();
			}

			return result;
		}
		waveInfo* rwsd::getWaveInfoAssociatedWithDataInfo(unsigned long dataSectionIndex)
		{
			waveInfo* result = nullptr;

			if (dataSectionIndex < dataSection.entries.size())
			{
				unsigned long waveIndex = dataSection.entries[dataSectionIndex].ntWaveIndex;
				if (waveIndex < waveSection.entries.size())
				{
					result = &waveSection.entries[waveIndex];
				}
			}

			return result;
		}
		bool rwsd::overwriteWaveRawData(unsigned long waveSectionIndex, const std::vector<unsigned char>& rawDataIn)
		{
			bool result = 0;

			if (waveSectionIndex < waveSection.entries.size())
			{
				waveInfo* targetWaveInfo = &waveSection.entries[waveSectionIndex];
				targetWaveInfo->packetContents.body = rawDataIn;
				targetWaveInfo->packetContents.padding = std::vector<unsigned char> (0x10 - (targetWaveInfo->packetContents.body.size() % 0x10), 0x00);
				targetWaveInfo->nibbles = targetWaveInfo->packetContents.body.size() * 2;
				result = updateWaveEntryDataLocations();
			}

			return result;
		}
		bool rwsd::overwriteWaveRawDataWithDSP(unsigned long waveSectionIndex, const dsp& dspIn)
		{
			bool result = 0;

			if (waveSectionIndex < waveSection.entries.size())
			{
				waveInfo* targetWaveInfo = &waveSection.entries[waveSectionIndex];
				targetWaveInfo->encoding = 2;
				targetWaveInfo->channels = 1;
				targetWaveInfo->looped = dspIn.loops;
				targetWaveInfo->loopStartSample = dspIn.loopStart;
				targetWaveInfo->nibbles = dspIn.nibbleCount;
				targetWaveInfo->sampleRate24 = dspIn.sampleRate >> 16;
				targetWaveInfo->sampleRate = 0x0000FFFF & dspIn.sampleRate;
				targetWaveInfo->channelInfoTable.resize(1);
				targetWaveInfo->channelInfoEntries.resize(1);
				targetWaveInfo->adpcmInfoEntries.resize(1);
				targetWaveInfo->adpcmInfoEntries.back() = dspIn.soundInfo;
				result = overwriteWaveRawData(waveSectionIndex, dspIn.body);
			}

			return result;
		}
		bool rwsd::overwriteWaveRawDataWithDSP(unsigned long waveSectionIndex, std::string dspPathIn)
		{
			bool result = 0;

			if (std::filesystem::is_regular_file(dspPathIn))
			{
				dsp tempDSP;
				if (tempDSP.populate(dspPathIn, 0x00))
				{
					result = overwriteWaveRawDataWithDSP(waveSectionIndex, tempDSP);
				}
			}

			return result;
		}
		bool rwsd::overwriteWaveRawDataWithWAV(unsigned long waveSectionIndex, std::string wavPathIn)
		{
			bool result = 0;

			if (std::filesystem::is_regular_file(wavPathIn))
			{
				system(lava::brawl::generateVGAudioWavToDSPCommand(wavPathIn, VGAudioTempConvFilename).c_str());
				if (std::filesystem::is_regular_file(VGAudioTempConvFilename))
				{
					result = overwriteWaveRawDataWithDSP(waveSectionIndex, VGAudioTempConvFilename);
					std::filesystem::remove(VGAudioTempConvFilename);
				}
			}

			return result;
		}

		bool rwsd::populateWavePacket(const lava::byteArray& bodyIn, unsigned long waveIndex, unsigned long rawDataAddressIn, unsigned long specificDataEndAddressIn)
		{
			bool result = 0;

			if (bodyIn.populated())
			{
				result = 1;
				waveInfo* currWave = &waveSection.entries[waveIndex];
				unsigned long length = currWave->getLengthInBytes();
				unsigned long paddingLength = 0x00;
				unsigned long currWaveDataEndpoint = rawDataAddressIn + currWave->dataLocation + length;
				if (currWaveDataEndpoint <= specificDataEndAddressIn)
				{
					paddingLength = specificDataEndAddressIn - currWaveDataEndpoint;
				}
				else
				{
					unsigned long overflowAmount = currWaveDataEndpoint - specificDataEndAddressIn;
					length -= overflowAmount;
					currWave->nibbles -= overflowAmount * 2;
				}
				result &= currWave->packetContents.populate(bodyIn, rawDataAddressIn + currWave->dataLocation, length, paddingLength);
			}

			return result;
		}
		bool rwsd::populateWavePackets(const lava::byteArray& bodyIn, unsigned long waveDataAddressIn, unsigned long waveDataLengthIn)
		{
			bool result = 0;

			if (bodyIn.populated())
			{
				result = 1;
				for (std::size_t i = 0; i < (waveSection.entries.size() - 1); i++)
				{
					waveInfo* currWave = &waveSection.entries[i];
					waveInfo* nextWave = &waveSection.entries[i + 1];
					result &= populateWavePacket(bodyIn, i, waveDataAddressIn, waveDataAddressIn + nextWave->dataLocation);
				}
				waveInfo* finalWave = &waveSection.entries.back();
				result &= populateWavePacket(bodyIn, waveSection.entries.size() - 1, waveDataAddressIn, waveDataAddressIn + waveDataLengthIn);
			}

			return result;
		}
		bool rwsd::populate(const byteArray& fileBodyIn, unsigned long fileBodyAddressIn, const byteArray& rawDataIn, unsigned long rawDataAddressIn, unsigned long rawDataLengthIn)
		{
			bool result = 0;

			if (fileBodyIn.getLong(fileBodyAddressIn) == brsarHexTags::bht_RWSD)
			{
				if (header.populate(fileBodyIn, fileBodyAddressIn))
				{
					result = dataSection.populate(fileBodyIn, fileBodyAddressIn + header.dataOffset);
					result &= waveSection.populate(fileBodyIn, fileBodyAddressIn + header.waveOffset);
					if (result)
					{
						result &= populateWavePackets(rawDataIn, rawDataAddressIn, rawDataLengthIn);
					}
				}
			}

			return result;
		}
		bool rwsd::populate(const brsarFileFileContents& fileContentsIn)
		{
			bool result = 0;

			if (bytesToFundamental<unsigned long>(fileContentsIn.header.data()) == brsarHexTags::bht_RWSD)
			{
				byteArray headerArr(fileContentsIn.header.data(), fileContentsIn.header.size());
				byteArray dataArr(fileContentsIn.data.data(), fileContentsIn.data.size());
				result = populate(headerArr, 0x00, dataArr, 0x00, dataArr.size());
			}

			return result;
		}

		dsp rwsd::exportWaveRawDataToDSP(unsigned long waveSectionIndex)
		{
			dsp result;

			if (waveSectionIndex < waveSection.entries.size())
			{
				const waveInfo* targetWaveInfo = &waveSection.entries[waveSectionIndex];
				result.nibbleCount = targetWaveInfo->nibbles;
				result.sampleCount = nibblesToSamples(result.nibbleCount);
				result.sampleRate = unsigned long(targetWaveInfo->sampleRate24) << 16;
				result.sampleRate |= targetWaveInfo->sampleRate;
				result.loops = targetWaveInfo->looped;
				result.loopStart = targetWaveInfo->loopStartSample;
				if (result.loops)
				{
					result.loopEnd = result.sampleCount - 1;
				}
				else
				{
					result.loopEnd = 0x00;
				}
				result.soundInfo = targetWaveInfo->adpcmInfoEntries.back();
				result.body = targetWaveInfo->packetContents.body;
				unsigned long desiredLength = nibblesToBytes(result.nibbleCount);
				if (result.body.size() < desiredLength)
				{
					result.body.resize(desiredLength);
				}
			}

			return result;
		}
		bool rwsd::exportWaveRawDataToWAV(unsigned long waveSectionIndex, std::string wavOutputPath)
		{
			bool result = 0;

			dsp conversionDSP = exportWaveRawDataToDSP(waveSectionIndex);
			if (!conversionDSP.body.empty())
			{
				std::ofstream convDSPOut(VGAudioTempConvFilename, std::ios_base::out | std::ios_base::binary);
				if (convDSPOut.is_open())
				{
					if (conversionDSP.exportContents(convDSPOut))
					{
						convDSPOut.close();
						system(lava::brawl::generateVGAudioDSPToWavCommand(VGAudioTempConvFilename, wavOutputPath).c_str());
						result = 1;
					}
					std::filesystem::remove(VGAudioTempConvFilename);
				}
			}

			return result;
		}
		bool rwsd::exportFileSection(std::ostream& destinationStream)
		{
			bool result = 0;

			if (destinationStream.good())
			{
				result = 1;
				result &= header.exportContents(destinationStream);
				result &= dataSection.exportContents(destinationStream);
				result &= waveSection.exportContents(destinationStream);
			}

			return result;
		}
		bool rwsd::exportRawDataSection(std::ostream& destinationStream)
		{
			bool result = 0;

			if (destinationStream.good())
			{
				for (unsigned long i = 0; i < waveSection.entries.size(); i++)
				{
					waveInfo* currWave = &waveSection.entries[i];
					destinationStream.write((const char*)currWave->packetContents.body.data(), currWave->packetContents.body.size());
					destinationStream.write((const char*)currWave->packetContents.padding.data(), currWave->packetContents.padding.size());
				}
				result = destinationStream.good();
			}

			return result;
		}
		std::vector<unsigned char> rwsd::fileSectionToVec()
		{
			std::vector<unsigned char> result;

			std::stringstream tempStream(std::ios_base::in | std::ios_base::out | std::ios_base::binary);
			if (exportFileSection(tempStream))
			{
				result = streamContentsToVec(tempStream);
			}

			return result;
		}
		std::vector<unsigned char> rwsd::rawDataSectionToVec()
		{
			std::vector<unsigned char> result;

			std::stringstream tempStream(std::ios_base::in | std::ios_base::out | std::ios_base::binary);
			if (exportRawDataSection(tempStream))
			{
				result = streamContentsToVec(tempStream);
			}

			return result;
		}

		/* RWSD */

		/* BRSAR File Section */



		/* BRSAR */

		bool brsar::init(std::string filePathIn)
		{
			bool result = 0;
			std::ifstream fileIn;
			fileIn.open(filePathIn, std::ios_base::in | std::ios_base::binary);
			if (fileIn.is_open())
			{
				std::cout << "Parsing \"" << filePathIn << "\"...\n";
				byteArray contents(fileIn);
				fileIn.close();
				if (contents.populated() && contents.getLong(0x00) == brsarHexTags::bht_RSAR)
				{
					std::size_t cursor = 0x04;
					result = 1;
					byteOrderMarker = contents.getShort(cursor, &cursor);
					version = contents.getShort(cursor, &cursor);
					length = contents.getLong(cursor, &cursor);
					headerLength = contents.getShort(cursor, &cursor);
					sectionCount = contents.getShort(cursor, &cursor);

					result &= symbSection.populate(contents, contents.getLong(0x10));
					result &= infoSection.populate(contents, contents.getLong(0x18));
					result &= fileSection.populate(contents, contents.getLong(0x20), infoSection);
				}
			}
			return result;
		}
		bool brsar::exportContents(std::ostream& destinationStream)
		{
			bool result = 1;

			writeRawDataToStream(destinationStream, brsarHexTags::bht_RSAR);
			writeRawDataToStream(destinationStream, byteOrderMarker);
			writeRawDataToStream(destinationStream, version);
			writeRawDataToStream(destinationStream, length);
			writeRawDataToStream(destinationStream, headerLength);
			writeRawDataToStream(destinationStream, sectionCount);
			writeRawDataToStream(destinationStream, symbSection.address);
			writeRawDataToStream(destinationStream, symbSection.length);
			writeRawDataToStream(destinationStream, infoSection.address);
			writeRawDataToStream(destinationStream, infoSection.length);
			writeRawDataToStream(destinationStream, fileSection.address);
			writeRawDataToStream(destinationStream, fileSection.length);
			if (headerLength > destinationStream.tellp())
			{
				std::vector<char> padding(headerLength - destinationStream.tellp(), 0x00);
				destinationStream.write(padding.data(), padding.size());
			}
			result &= symbSection.exportContents(destinationStream);
			result &= infoSection.exportContents(destinationStream);
			result &= fileSection.exportContents(destinationStream);

			return result;
		}
		bool brsar::exportContents(std::string outputFilename)
		{
			bool result = 0;

			std::ofstream output(outputFilename, std::ios_base::out | std::ios_base::binary);
			if (output.is_open())
			{
				result = exportContents(output);
			}

			return result;
		}

		std::string brsar::getSymbString(unsigned long indexIn)
		{
			return symbSection.getString(indexIn);
		}
		unsigned long brsar::getGroupOffset(unsigned long groupIDIn)
		{
			std::size_t result = SIZE_MAX;

			std::size_t i = 0;
			bool done = 0;

			const brsarInfoGroupHeader* currentGroup = nullptr;
			while (!done && i < infoSection.groupHeaders.size())
			{
				currentGroup = &infoSection.groupHeaders[i];
				if (groupIDIn == currentGroup->groupID)
				{
					result = currentGroup->address;
					done = 1;
				}
				else
				{
					i++;
				}
			}

			return result;
		}

		bool brsar::updateInfoSectionFileOffsets()
		{
			bool result = 1;
			// Update each groupHeader and its entries with current file location info
			for (unsigned long i = 0; i < infoSection.groupHeaders.size(); i++)
			{
				// Grab a pointer to a given header
				brsarInfoGroupHeader* currGroupHeader = &infoSection.groupHeaders[i];
				// Reset its lengths to 0, because we'll be using this and building it as we go.
				currGroupHeader->headerLength = 0x00;
				currGroupHeader->dataLength = 0x00;
				// If there are entries to iterate through...
				if (!currGroupHeader->entries.empty())
				{
					// Iterate through each of this headers entries, and update its info.
					for (unsigned long u = 0; u < currGroupHeader->entries.size(); u++)
					{
						// Grab a pointer to the entry
						brsarInfoGroupEntry* currGroupEntry = &currGroupHeader->entries[u];
						// Grab a pointer to the relevant fileContents entry
						brsarFileFileContents* currFileContents = fileSection.getFileContentsPointer(currGroupEntry->fileID, currGroupHeader->groupID);
						// If we grabbed the pointer successfully (this shouldn't ever fail, though)
						if (currFileContents != nullptr)
						{
							// If this is the first entry...
							if (u == 0)
							{
								// ... update the header and data address values to point to the right spots.
								currGroupHeader->headerAddress = currFileContents->headerAddress;
								currGroupHeader->dataAddress = currFileContents->dataAddress;
							}
							// Additionally, we'll always update the offset values if we're on the first entry.
							if (u == 0)
							{
								// Update the offset values.
								// These are tied to the current groupHeader's length values, which we update every run of this loop.
								// As a result, each offset points to right after the previous item.
								currGroupEntry->headerOffset = currGroupHeader->headerLength;
								currGroupEntry->dataOffset = currGroupHeader->dataLength;
							}
							// We won't, however, always update them otherwise.
							else
							{
								// In some instances, an entry after the first will have offsets of 0x00.
								// We need to maintain this in the modified file, so we only update the offsets otherwise.
								if (currGroupEntry->headerOffset != 0x00000000)
								{
									currGroupEntry->headerOffset = currGroupHeader->headerLength;
								}
								if (currGroupEntry->dataOffset != 0x00000000)
								{
									currGroupEntry->dataOffset = currGroupHeader->dataLength;
								}
							}
							// Update the length values. Self explanatory.
							currGroupEntry->headerLength = currFileContents->header.size();
							currGroupEntry->dataLength = currFileContents->data.size();
							// Update the groupHeader's length values. See above explanation.
							currGroupHeader->headerLength += currGroupEntry->headerLength;
							currGroupHeader->dataLength += currGroupEntry->dataLength;

						}
						else
						{
							result = 0;
						}
					}
				}
				else
				{
					// Otherwise, just point the header and data address fields to just after the previous data section.
					// I don't expect that this actually has any practical effect, since I don't expect the addresses of an empty group to ever be called.
					// However, vBrawl handles it this way, so that's how we'll do it as well.
					if (i > 0)
					{
						brsarInfoGroupHeader* prevGroupHeader = &infoSection.groupHeaders[i - 1];
						currGroupHeader->headerAddress = prevGroupHeader->dataAddress + prevGroupHeader->dataLength;
						currGroupHeader->dataAddress = currGroupHeader->headerAddress;
					}
				}
			}
			return result;
		}
		bool brsar::overwriteFile(const std::vector<unsigned char>& headerIn, const std::vector<unsigned char>& dataIn, unsigned long fileIDIn)
		{
			bool result = 0;

			std::vector<brsarFileFileContents*> fileOccurences = fileSection.getFileContentsPointerVector(fileIDIn);
			if (!fileOccurences.empty())
			{
				brsarInfoFileHeader* fileHeaderPtr = infoSection.getFileHeaderPointer(fileIDIn);
				if (fileHeaderPtr != nullptr)
				{
					result = 1;
					// Handle File Section Adjustments
					for (unsigned long i = 0; i < fileOccurences.size(); i++)
					{
						// Replace the header and data
						brsarFileFileContents* currOccurence = fileOccurences[i];
						signed long headerLengthChange = signed long(headerIn.size()) - signed long(currOccurence->header.size());
						signed long dataLengthChange = signed long(dataIn.size()) - signed long(currOccurence->data.size());
						currOccurence->header = headerIn;
						currOccurence->data = dataIn;
						// Propogate the changes in size across the fileSection
						// Note that this needs to be done in two steps, because the dataAddress will likely change after the first step.
						result &= fileSection.propogateFileLengthChange(headerLengthChange, currOccurence->headerAddress);
						result &= fileSection.propogateFileLengthChange(dataLengthChange, currOccurence->dataAddress);
						// Update BRSAR's length value.
						// Note that the above propogation functions will update the FILE section's length.
						length += headerLengthChange + dataLengthChange;
					}
					// Update this file's fileHeader (it's the only one that needs its length updated)
					fileHeaderPtr->headerLength = headerIn.size();
					fileHeaderPtr->dataLength = dataIn.size();
					// Update the rest of the infoSection to correct the changes to file locations
					result &= updateInfoSectionFileOffsets();
				}
			}

			return result;
		}

		bool brsar::summarizeSymbStringData(std::ostream& output)
		{
			return symbSection.dumpStrings(output);
		}
		bool brsar::outputConsecutiveSoundEntryStringsWithSameFileID(unsigned long startingIndex, std::ostream& output)
		{
			bool result = 0;

			if (output.good() && symbSection.address != ULONG_MAX)
			{
				unsigned long fileID = infoSection.soundEntries[startingIndex].fileID;
				std::size_t i = startingIndex;
				while (i < infoSection.soundEntries.size() && infoSection.soundEntries[i].fileID == fileID)
				{
					output << "\t[String 0x" << numToHexStringWithPadding(i, 0x04) << "] " << getSymbString(i) << "\n";
					i++;
				}
			}

			return result;
		}
		bool brsar::doFileDump(std::string dumpRootFolder, bool joinHeaderAndData)
		{
			bool result = 0;

			std::filesystem::create_directories(dumpRootFolder);
			brsarInfoGroupHeader* currHeader = nullptr;
			brsarInfoGroupEntry* currEntry = nullptr;
			std::ofstream metadataOutput(dumpRootFolder + "summary.txt");
			metadataOutput << "lavaBRSARLib " << version << "\n\n";
			metadataOutput << "BRSAR File Dump Summary:\n";
			MD5 md5Object;
			for (std::size_t i = 0; i < infoSection.groupHeaders.size(); i++)
			{
				currHeader = &infoSection.groupHeaders[i];
				std::string groupName = symbSection.getString(currHeader->groupID);
				if (groupName.size() == 0x00)
				{
					groupName = "[NAMELESS]";
				}
				std::string groupFolder = dumpRootFolder + groupName + "/";
				std::filesystem::create_directory(groupFolder);
				metadataOutput << "File(s) in \"" << groupName << "\" (Raw ID: " 
					<< numToDecStringWithPadding(currHeader->groupID, 0x03) << " / 0x" << numToHexStringWithPadding(currHeader->groupID, 0x03) << 
					", Info Index: " << numToDecStringWithPadding(i, 0x03) << " / 0x" << numToHexStringWithPadding(i, 0x03) << ")...\n";
				for (std::size_t u = 0; u < currHeader->entries.size(); u++)
				{
					currEntry = &currHeader->entries[u];
					std::vector<std::size_t>* idToIndexVecPtr = &fileSection.fileIDToIndex[currEntry->fileID];
					std::string fileBaseName = numToDecStringWithPadding(currEntry->fileID, 0x03) + "_(0x" + numToHexStringWithPadding(currEntry->fileID, 0x03) + ")";
					bool entryExported = 0;
					std::size_t y = 0;
					while(!entryExported)
					{
						brsarFileFileContents* fileContentsPtr = &fileSection.fileContents[(*idToIndexVecPtr)[y]];
						if (fileContentsPtr->groupID == currHeader->groupID)
						{
							metadataOutput << "\tFile " << numToDecStringWithPadding(currEntry->fileID, 0x03) << " (0x" << numToHexStringWithPadding(currEntry->fileID, 0x03) << ") @ 0x" << numToHexStringWithPadding(fileContentsPtr->headerAddress, 0x08) << "\n";
							metadataOutput << "\t\tFile Type: ";
							if (fileContentsPtr->header.size() >= 0x04)
							{
								metadataOutput << fileContentsPtr->header[0] << fileContentsPtr->header[1] << fileContentsPtr->header[2] << fileContentsPtr->header[3] << "\n";
							}
							else
							{
								metadataOutput << "----\n";
							}
							metadataOutput << "\t\tHeader Size: " << fileContentsPtr->header.size() << " byte(s) (" << bytesToFileSizeString(fileContentsPtr->header.size()) << ")\n";
							metadataOutput << "\t\tData Size: " << fileContentsPtr->data.size() << " byte(s) (" << bytesToFileSizeString(fileContentsPtr->data.size()) << ")\n";
							metadataOutput << "\t\tTotal Size: " << fileContentsPtr->header.size() + fileContentsPtr->data.size() << " byte(s) (" << bytesToFileSizeString(fileContentsPtr->header.size() + fileContentsPtr->data.size()) << ")\n";
							metadataOutput << "\t\tNumber Times File Occurs in BRSAR: " << idToIndexVecPtr->size() << "\n";
							metadataOutput << "\t\tNumber of Current Occurence: " << numberToOrdinal(y + 1) << " (Suffixed with \"_" << std::string(1, 'A' + y) << "\")\n";
							metadataOutput << "\t\tHeader MD5 Hash: " << md5Object((char*)fileContentsPtr->header.data(), fileContentsPtr->header.size()) << "\n";
							metadataOutput << "\t\tData MD5 Hash: " << md5Object((char*)fileContentsPtr->data.data(), fileContentsPtr->data.size()) << "\n";

							std::string headerFilename = "";
							std::string dataFilename = "";
							headerFilename += "_" + std::string(1, 'A' + y);
							dataFilename += "_" + std::string(1, 'A' + y);
							if (joinHeaderAndData)
							{
								headerFilename += "_joined.dat";
								std::ofstream headerOutput(groupFolder + fileBaseName + headerFilename, std::ios_base::out | std::ios_base::binary);
								if (headerOutput.is_open())
								{
									headerOutput.write((char*)fileContentsPtr->header.data(), fileContentsPtr->header.size());
									headerOutput.write((char*)fileContentsPtr->data.data(), fileContentsPtr->data.size());
									headerOutput.close();
								}
							}
							else
							{
								headerFilename += "_header.dat";
								dataFilename += "_data.dat";
								std::ofstream headerOutput(groupFolder + fileBaseName + headerFilename, std::ios_base::out | std::ios_base::binary);
								if (headerOutput.is_open())
								{
									headerOutput.write((char*)fileContentsPtr->header.data(), fileContentsPtr->header.size());
									headerOutput.close();
								}
								std::ofstream dataOutput(groupFolder + fileBaseName + dataFilename, std::ios_base::out | std::ios_base::binary);
								if (dataOutput.is_open())
								{
									dataOutput.write((char*)fileContentsPtr->data.data(), fileContentsPtr->data.size());
									dataOutput.close();
								}
							}
							entryExported = 1;
						}
						y++;
					}
				}
			}

			return result = 1;
		}

		/* BRSAR */
	}
}