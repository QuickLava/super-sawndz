#ifndef LAVA_RESAWNDZ_V1_H
#define LAVA_RESAWNDZ_V1_H

#include "lavaBRSARLib.h"

namespace lava
{
	namespace brawl
	{
		const std::string resawndzVersion = "v1.2.8";
		const unsigned long _MAX_SUPPORTED_SAWND_VERSION = 0x0002;

		struct sawndFileEntry
		{
			unsigned long fileID = ULONG_MAX;
			unsigned long headerOffset = ULONG_MAX;
			unsigned long headerLength = ULONG_MAX;
			std::vector<unsigned char> headerContent{};
			unsigned long dataOffset = ULONG_MAX;
			unsigned long dataLength = ULONG_MAX;
			std::vector<unsigned char> dataContent{};
		};
		struct sawnd
		{
		public:
			unsigned long address = ULONG_MAX;

			unsigned char sawndVersion = ULONG_MAX;
			unsigned long groupID = ULONG_MAX;
			unsigned long headerSectionOffset = ULONG_MAX;
			unsigned long headerSectionLength = ULONG_MAX;
			unsigned long dataSectionOffset = ULONG_MAX;
			unsigned long dataSectionLength = ULONG_MAX;

			std::vector<sawndFileEntry> fileEntries{};
		public:
			bool populate(const lava::byteArray& bodyIn, unsigned long addressIn);
			bool exportContents(std::ostream& destinationStream);
		};

		std::vector<sawnd> parseSawndFie(std::string fileIn);
		bool exportSawnd(brsar& sourceBrsar, std::size_t groupID, std::string targetFilePath);
		bool importSawnd(brsar& sourceBrsar, std::string sourceFilePath);
	}
}

#endif