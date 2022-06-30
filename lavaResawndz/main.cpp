#include "lavaResawndz.h"

const std::string targetBrsarName = "smashbros_sound";

// Switches the Resawndz .brsar export to output to its own file, instead of overwriting the original.
#define ENABLE_BRSAR_EXPORT_REROUTE false
const std::string resawndzRerouteSuffix = "_edit.brsar";
// Test which exports a sawnd file of the specified name for the specified group.
#define ENABLE_SAWND_EXPORT_TEST true
// Test which imports a sawnd file, then exports the .brsar.
#define ENABLE_SAWND_IMPORT_TEST true
const unsigned long sawndTestsTargetGroupID = 0x11;
const std::string sawndTestsFilename = "sawnd.sawnd";

// Default Argument Constants
const std::string brsarDefaultFilename = targetBrsarName + ".brsar";
const std::string sawndDefaultFilename = "sawnd.sawnd";
const std::string wavDefaultFilename = "sound.wav";
const std::string nullArgumentString = "-";
bool isNullArg(const char* argIn)
{
	return (argIn != nullptr) ? (strcmp(argIn, nullArgumentString.c_str()) == 0) : 0;
}

// Export Func
bool exportBRSAR(lava::brawl::brsar& brsarIn, std::string pathOut)
{
	bool result = 0;
#if ENABLE_BRSAR_EXPORT_REROUTE == false
	result = brsarIn.exportContents(pathOut);
#else
	result = brsarIn.exportContents(lava::pruneFileExtension(pathOut) + resawndzRerouteSuffix);
#endif
	return result;
}


int testmain()
{
	lava::brawl::brsar testBrsar;
	testBrsar.init(targetBrsarName + ".brsar");
#if ENABLE_SAWND_EXPORT_TEST
	lava::brawl::exportSawnd(testBrsar, sawndTestsTargetGroupID, sawndTestsFilename);
#endif
#if ENABLE_SAWND_IMPORT_TEST
	lava::brawl::importSawnd(testBrsar, sawndTestsFilename);
	testBrsar.exportContents(targetBrsarName + "_sawndimport.brsar");
#endif
	return 0;
}

int main(int argc, char** argv)
{
	srand(time(0));
	std::cout << "Resawndz " << lava::brawl::resawndzVersion << "\n";
	std::cout << "Written by QuickLava\n";
	std::cout << "Based directly on work by:\n";
	std::cout << " - Jaklub and Agoaj, as well as mstaklo, ssbbtailsfan, stickman and VILE (Sawndz, Super Sawndz)\n";
	std::cout << " - Soopercool101, as well as Kryal, BlackJax96, and libertyernie (BrawlLib, BrawlBox, BrawlCrate)\n\n";
	try
	{
		if (argc >= 2)
		{
			if (strcmp("sawndcreate", argv[1]) == 0 && argc >= 3)
			{
				lava::brawl::brsar sourceBrsar;
				std::string activeBrsarName = targetBrsarName + ".brsar";
				std::string targetFileName = sawndDefaultFilename;
				if (argc >= 4 && !isNullArg(argv[3]))
				{
					activeBrsarName = argv[3];
				}
				if (argc >= 5 && !isNullArg(argv[4]))
				{
					targetFileName = argv[4];
				}
				if (sourceBrsar.init(activeBrsarName))
				{
					lava::brawl::exportSawnd(sourceBrsar, std::stoi(argv[2]), targetFileName);
				}
				else
				{
					std::cerr << "[ERROR] Failed to initialize .brsar struct! Operation aborted!\n";
				}
				return 0;
			}
			else if (strcmp("sawnd", argv[1]) == 0 && argc >= 2)
			{
				lava::brawl::brsar sourceBrsar;
				std::string activeBrsarName = targetBrsarName + ".brsar";
				std::string targetFileName = sawndDefaultFilename;
				if (argc >= 3 && !isNullArg(argv[2]))
				{
					activeBrsarName = argv[2];
				}
				if (argc >= 4 && !isNullArg(argv[3]))
				{
					targetFileName = argv[3];
				}
				if (sourceBrsar.init(activeBrsarName))
				{
					if (lava::brawl::importSawnd(sourceBrsar, targetFileName))
					{
						exportBRSAR(sourceBrsar, activeBrsarName);
					}
				}
				else
				{
					std::cerr << "[ERROR] Failed to initialize .brsar struct! Operation aborted!\n";
				}
				return 0;
			}
			else if (strcmp("insert", argv[1]) == 0 && argc >= 8)
			{
				lava::brawl::brsar sourceBrsar;
				std::string activeBrsarName = targetBrsarName + ".brsar";
				std::string wavPath = wavDefaultFilename;
				if (argc >= 8 && !isNullArg(argv[7]))
				{
					activeBrsarName = argv[7];
				}
				if (argc >= 9 && !isNullArg(argv[8]))
				{
					wavPath = argv[8];
				}
				unsigned long targetGroupID = std::stoi(argv[2]);
				unsigned long targetFileID = std::stoi(argv[3]);
				unsigned long targetWaveID = std::stoi(argv[4]);
				unsigned long frequency = std::stoi(argv[5]);
				unsigned long basewave = -1;
				unsigned long loop = std::stoi(argv[6]);
				if (sourceBrsar.init(activeBrsarName))
				{
					lava::brawl::rwsd tempRWSD;
					if (tempRWSD.populate(*sourceBrsar.fileSection.getFileContentsPointer(targetFileID)))
					{
						if (tempRWSD.overwriteWaveRawDataWithWAV(targetWaveID, wavPath))
						{
							if (sourceBrsar.overwriteFile(tempRWSD.fileSectionToVec(), tempRWSD.rawDataSectionToVec(), targetFileID))
							{
								exportBRSAR(sourceBrsar, activeBrsarName);
							}
							else
							{
								std::cout << "[ERROR] Failed to overwrite file in .brsar struct! Operation aborted!\n";
							}
						}
						else
						{
							std::cout << "[ERROR] Failed to import .dsp! Operation aborted!\n";
						}
					}
					else
					{
						std::cout << "[ERROR] Failed to parse RWSD! Operation aborted!\n";
					}
				}
				else
				{
					std::cout << "[ERROR] Failed to initialize .brsar struct! Operation aborted!\n";
				}
				return 0;
			}
			else if (strcmp("wavcreate", argv[1]) == 0 && argc >= 5)
			{
				lava::brawl::brsar sourceBrsar;
				std::string activeBrsarName = targetBrsarName + ".brsar";
				std::string wavPath = wavDefaultFilename;
				if (argc >= 6 && !isNullArg(argv[5]))
				{
					activeBrsarName = argv[5];
				}
				if (argc >= 7 && !isNullArg(argv[6]))
				{
					wavPath = argv[6];
				}
				unsigned long targetGroupID = std::stoi(argv[2]);
				unsigned long targetFileID = std::stoi(argv[3]);
				unsigned long targetWaveID = std::stoi(argv[4]);
				std::cout << "Exporting Wave #" << targetWaveID << " from File #" << targetFileID << " in Group #" << targetGroupID << "...\n";
				if (sourceBrsar.init(activeBrsarName))
				{
					lava::brawl::rwsd tempRWSD;
					if (tempRWSD.populate(*sourceBrsar.fileSection.getFileContentsPointer(targetFileID)))
					{
						if (tempRWSD.exportWaveRawDataToWAV(targetWaveID, wavPath))
						{
							std::cout << "Success!\n";
						}
						else
						{
							std::cout << "[ERROR] Failed to export WAV! Operation aborted!\n";
						}
					}
					else
					{
						std::cout << "[ERROR] Failed to parse RWSD! Operation aborted!\n";
					}
				}
				else
				{
					std::cout << "[ERROR] Failed to initialize .brsar struct! Operation aborted!\n";
				}
				return 0;
			}
		}
		std::cout << "Invalid operation argument set supplied:\n";
		for (unsigned long i = 0; i < argc; i++)
		{
			std::cout << "\tArgv[" << i << "]: " << argv[i] << "\n";
		}
		std::cout << "Please provide one of the following sets of arguments!\n";
		std::cout << "To export a .sawnd:\n";
		std::cout << "\tsawndcreate {GROUP_ID} {BRSAR_PATH, optional} {OUTPUT_PATH, opt}\n";
		std::cout << "To import a .sawnd:\n";
		std::cout << "\tsawnd {BRSAR_PATH, optional} {INPUT_PATH, optional}\n";
		std::cout << "To import a .wav:\n";
		std::cout << "\tinsert {GROUP_ID} {FILE_ID} {WAVE_ID} {FREQUENCY} {LOOP} {BRSAR_PATH, optional} {WAV_PATH, opt}\n";
		std::cout << "To export a .wav:\n";
		std::cout << "\twavcreate {GROUP_ID} {FILE_ID} {WAVE_ID} {BRSAR_PATH, optional} {WAV_PATH, opt}\n";
		std::cout << "Note: Default BRSAR_PATH is \"" << brsarDefaultFilename << "\", default IN/OUTPUT_PATH is \"" << sawndDefaultFilename << "\".\n";
		std::cout << "Note: Default WAV_PATH is \"" << wavDefaultFilename << "\".\n";
		std::cout << "Note: To explicitly use one of the above defaults, specify \"" << nullArgumentString << "\" for that argument.\n";
	}
	catch (std::exception e)
	{
		std::cerr << "EXCEPTION: ";
		std::cerr << e.what();
	}
	return 0;
}