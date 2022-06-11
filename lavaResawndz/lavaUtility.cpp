#include "lavaUtility.h"

namespace lava
{
	std::string stringToUpper(const std::string& stringIn)
	{
		std::string result = stringIn;
		for (std::size_t i = 0; i < result.size(); i++)
		{
			result[i] = toupper(result[i]);
		}
		return result;
	}
	std::string numToHexStringWithPadding(unsigned long numIn, unsigned long paddingLength)
	{
		std::stringstream convBuff;
		convBuff << std::hex << numIn;
		std::string result = convBuff.str();
		for (int i = 0; i < result.size(); i++)
		{
			result[i] = std::toupper(result[i]);
		}
		if (result.size() < paddingLength)
		{
			result = std::string(paddingLength - result.size(), '0') + result;
		}
		return result;
	}
	std::string numToDecStringWithPadding(unsigned long numIn, unsigned long paddingLength)
	{
		std::string result = std::to_string(numIn);
		if (result.size() < paddingLength)
		{
			result = std::string(paddingLength - result.size(), '0') + result;
		}
		return result;
	}
	std::string doubleToStringWithPadding(double dblIn, unsigned long paddingLength, unsigned long precisionIn)
	{
		std::string result = "";

		std::ostringstream out;
		out.precision(precisionIn);
		out << std::fixed << dblIn;
		result = out.str();
		if (result.size() < paddingLength)
		{
			result = std::string(paddingLength - result.size(), '0') + result;
		}

		return result;
	}
	std::string floatToStringWithPadding(float fltIn, unsigned long paddingLength, unsigned long precisionIn)
	{
		return doubleToStringWithPadding(fltIn, paddingLength, precisionIn);
	}
	std::string numberToOrdinal(unsigned int numberIn)
	{
		std::string result = std::to_string(numberIn);
		numberIn = numberIn % 100;
		if (numberIn >= 10 && numberIn < 20)
		{
			result += "th";
		}
		else
		{
			switch (numberIn % 10)
			{
				case 1:
				{
					result += "st";
					break;
				}
				case 2:
				{
					result += "nd";
					break;
				}
				case 3:
				{
					result += "rd";
					break;
				}
				default:
				{
					result += "th";
					break;
				}
			}
		}
		return result;
	}
	std::string pruneFileExtension(std::string filepathIn)
	{
		std::string result = filepathIn;
		std::size_t finalPeriodPos = filepathIn.rfind('.');
		if (finalPeriodPos != std::string::npos)
		{
			result = result.substr(0, finalPeriodPos);
		}
		return result;
	}

	double bytesToHigherBytes(long long int bytesIn, char byteLevel)
	{
		if (byteLevel == CHAR_MAX)
		{
			byteLevel = log(bytesIn) / 10;
		}
		for (int i = byteLevel; i > 1; i--)
		{
			bytesIn = bytesIn >> 10;
			byteLevel--;
		}
		return (byteLevel > 0) ? double(bytesIn) / 1024 : bytesIn;
	}
	std::string bytesToFileSizeString(long long int bytesIn, char byteLevel, bool abbrv)
	{
		static std::vector<std::string> byteLevelDictionary{};
		if (byteLevelDictionary.empty())
		{
			byteLevelDictionary.resize(byteLevels::_count, " ");
			byteLevelDictionary[byteLevels::BYT] = "";
			byteLevelDictionary[byteLevels::KILO] = "kilo";
			byteLevelDictionary[byteLevels::MEGA] = "mega";
			byteLevelDictionary[byteLevels::GIGA] = "giga";
			byteLevelDictionary[byteLevels::TERA] = "tera";
			byteLevelDictionary[byteLevels::PETA] = "peta";
			byteLevelDictionary[byteLevels::EXA] = "exa";
			byteLevelDictionary[byteLevels::ZETTA] = "zetta";
			byteLevelDictionary[byteLevels::YOTTA] = "yotta";
		}

		std::string temp = "";
		if (byteLevel == CHAR_MAX)
		{
			byteLevel = log2(bytesIn) / 10;
		}
		temp = lava::doubleToStringWithPadding(bytesToHigherBytes(std::max(0ll, bytesIn - 1), byteLevel), 0x02) + " ";
		if (abbrv)
		{
			temp += ((byteLevel) ? std::string(1, std::toupper(byteLevelDictionary[byteLevel][0])) : "") + "B";
		}
		else
		{
			temp += byteLevelDictionary[byteLevel] + "bytes";
		}
		return temp;
	}

	std::vector<unsigned char> streamContentsToVec(std::istream& streamIn)
	{
		std::vector<unsigned char> result;

		std::streampos currPos = streamIn.tellg();
		streamIn.seekg(0, std::ios::end);
		unsigned long streamLength = streamIn.tellg();
		streamIn.seekg(0, std::ios::beg);
		result.resize(streamLength, 0x00);
		streamIn.read((char*)result.data(), result.size());
		streamIn.seekg(currPos);

		return result;
	}

	template<>
	bool writeFundamentalToBuffer<float>(float objectIn, unsigned char* destinationBuffer, endType endianIn)
	{
		return writeFundamentalToBuffer<unsigned long>(*(unsigned long*)&objectIn, destinationBuffer, endianIn);
	}
	template<>
	bool writeFundamentalToBuffer<double>(double objectIn, unsigned char* destinationBuffer, endType endianIn)
	{
		return writeFundamentalToBuffer<unsigned long long>(*(unsigned long long*) & objectIn, destinationBuffer, endianIn);
	}
}