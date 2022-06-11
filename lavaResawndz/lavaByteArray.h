#ifndef LAVA_BYTE_ARRAY_H_V2
#define LAVA_BYTE_ARRAY_H_V2

#include <vector>
#include <algorithm>
#include <iostream>
#include <fstream>
#include "lavaUtility.h"

namespace lava
{
	template<endType defaultEndian = endType::et_BIG_ENDIAN>
	struct _byteArray
	{
	private:
		bool _populated = 0;
		std::vector<char> body = {};
	private:

		template<typename objectType>
		objectType getFundamental(std::size_t startIndex, std::size_t* nextIndexOut = nullptr, endType endianIn = defaultEndian) const
		{
			objectType result = ULLONG_MAX;
			if ((startIndex + sizeof(objectType)) <= body.size())
			{
				result = bytesToFundamental<objectType>(((unsigned char*)body.data()) + startIndex, endianIn);
				if (nextIndexOut != nullptr)
				{
					*nextIndexOut = startIndex + sizeof(objectType);
				}
			}
			else
			{
				if (nextIndexOut != nullptr)
				{
					*nextIndexOut = SIZE_MAX;
				}
			}
			return result;
		}
		template<>
		unsigned char getFundamental<unsigned char>(std::size_t startIndex, std::size_t* nextIndexOut, endType endianIn) const
		{
			unsigned char result = UCHAR_MAX;
			if (startIndex < body.size())
			{
				result = body[startIndex];
				if (nextIndexOut != nullptr)
				{
					*nextIndexOut = startIndex + sizeof(unsigned char);
				}
			}
			else
			{
				if (nextIndexOut != nullptr)
				{
					*nextIndexOut = SIZE_MAX;
				}
			}
			return result;
		}

		template<typename objectType>
		bool setFundamental(const objectType& objectIn, std::size_t startIndex, std::size_t* nextIndexOut = nullptr, endType endianIn = defaultEndian)
		{
			bool result = 0;
			if (startIndex + sizeof(objectType) <= body.size())
			{
				result = 1;
				unsigned char* startingPtr = ((unsigned char*)body.data()) + startIndex;
				writeFundamentalToBuffer<objectType>(objectIn, startingPtr, endianIn);
				if (nextIndexOut != nullptr)
				{
					*nextIndexOut = startIndex + sizeof(objectType);
				}
			}
			else
			{
				if (nextIndexOut != nullptr)
				{
					*nextIndexOut = body.size();
				}
			}
			return result;
		}
		template<>
		bool setFundamental<unsigned char>(const unsigned char& objectIn, std::size_t startIndex, std::size_t* nextIndexOut, endType endianIn)
		{
			bool result = 0;
			if (startIndex < body.size())
			{
				result = 1;
				body[startIndex] = objectIn;
				if (nextIndexOut != nullptr)
				{
					*nextIndexOut = startIndex + sizeof(unsigned char);
				}
			}
			else
			{
				if (nextIndexOut != nullptr)
				{
					*nextIndexOut = SIZE_MAX;
				}
			}
			return result;
		}

		template<typename objectType>
		bool insertFundamental(const objectType& objectIn, std::size_t startIndex, endType endianIn = defaultEndian)
		{
			bool result = 0;
			if (startIndex < body.size())
			{
				body.insert(body.begin() + startIndex, sizeof(objectIn), 0x00);
				result = setFundamental<objectType>(objectIn, startIndex, nullptr, endianIn);
			}
			return result;
		}

		template<typename objectType>
		std::size_t findFundamental(const objectType& objectIn, std::size_t startItr = 0, std::size_t endItr = SIZE_MAX, endType endianIn = defaultEndian) const
		{
			std::size_t result = SIZE_MAX;
			if (startItr < body.size())
			{
				result = search(lava::fundamentalToBytes(objectIn, endianIn), startItr, endItr);
			}
			return result;
		}
		template<typename objectType>

		std::vector<std::size_t> findFundamentalMultiple(const objectType& objectIn, std::size_t startItr = 0, std::size_t endItr = SIZE_MAX, endType endianIn = defaultEndian) const
		{
			std::vector<std::size_t> result{};
			if (startItr < body.size())
			{
				result = searchMultiple(lava::fundamentalToBytes(objectIn, endianIn), startItr, endItr);
			}
			return result;
		}

	public:
		_byteArray(std::size_t lengthIn = 0x00, char defaultChar = 0x00) 
		{
			populate(lengthIn, defaultChar);
		};
		_byteArray(const unsigned char* dataIn, std::size_t lengthIn)
		{
			populate((const char*)dataIn, lengthIn);
		}
		_byteArray(const char* dataIn, std::size_t lengthIn)
		{
			populate(dataIn, lengthIn);
		}
		_byteArray(std::vector<char>& sourceVec)
		{
			populate(sourceVec);
		}
		_byteArray(std::istream& sourceStream)
		{
			populate(sourceStream);
		}

		void populate(std::size_t lengthIn, char defaultChar = 0x00)
		{
			if (_populated)
			{
				body.clear();
			}
			_populated = 1;
			body.resize(lengthIn, defaultChar);
		}
		void populate(const char* sourceData, std::size_t lengthIn)
		{
			_populated = 1;
			body = std::vector<char>(sourceData, sourceData + lengthIn);
		}
		void populate(std::vector<char>& sourceVec)
		{
			_populated = 1;
			body = sourceVec;
		}
		void populate(std::istream& sourceStream)
		{
			if (_populated)
			{
				body.clear();
			}
			_populated = 1;
			sourceStream.seekg(0, sourceStream.end);
			std::size_t sourceSize(sourceStream.tellg());
			sourceStream.seekg(0, sourceStream.beg);
			body.resize(sourceSize);
			sourceStream.read(body.data(), sourceSize);
		}
		bool populated() const
		{
			return _populated;
		}

		const char* data() const
		{
			return body.data();
		}
		std::size_t size() const
		{
			return body.size();
		}
		const std::vector<char>::const_iterator begin() const
		{
			return body.begin();
		}
		const std::vector<char>::const_iterator end() const
		{
			return body.end();
		}
		const char& front() const
		{
			return body.front();
		}
		const char& back() const
		{
			return body.back();
		}

		std::vector<unsigned char> getBytes(std::size_t numToGet, std::size_t startIndex, std::size_t& numGotten = nullptr) const
		{
			numGotten = SIZE_MAX;
			if (startIndex < body.size())
			{
				if (numToGet >= body.size() || startIndex + numToGet >= body.size())
				{
					numToGet = body.size() - startIndex;
				}
				numGotten = numToGet;
				/*if (nextIndexOut != nullptr)
				{
					*nextIndexOut = startIndex + numToGet;
				}*/
				return std::vector<unsigned char>(body.begin() + startIndex, body.begin() + startIndex + numToGet);
			}
			else
			{
				/*if (nextIndexOut != nullptr)
				{
					*nextIndexOut = SIZE_MAX;
				}*/
				std::cerr << "[ERROR] Requested region startpoint was invalid. Specified index was [" << startIndex << "], max valid index is [" << body.size() - 1 << "].\n";
			}
			return std::vector<unsigned char>();
		}
		unsigned long long int getLLong(std::size_t startIndex, std::size_t* nextIndexOut = nullptr, endType endianIn = defaultEndian) const
		{
			return getFundamental<unsigned long long int>(startIndex, nextIndexOut, endianIn);
		}
		unsigned long int getLong(std::size_t startIndex, std::size_t* nextIndexOut = nullptr, endType endianIn = defaultEndian) const
		{
			return getFundamental<unsigned long int>(startIndex, nextIndexOut, endianIn);
		}
		unsigned short int getShort(std::size_t startIndex, std::size_t* nextIndexOut = nullptr, endType endianIn = defaultEndian) const
		{
			return getFundamental<unsigned short int>(startIndex, nextIndexOut, endianIn);
		}
		unsigned char getChar(std::size_t startIndex, std::size_t* nextIndexOut = nullptr, endType endianIn = defaultEndian) const
		{
			return getFundamental<unsigned char>(startIndex, nextIndexOut, endianIn);
		}
		double getDouble(std::size_t startIndex, std::size_t* nextIndexOut = nullptr, endType endianIn = defaultEndian) const
		{
			unsigned long long tempRes = getLLong(startIndex, nextIndexOut, endianIn);
			return *(double*)(&tempRes);
		}
		float getFloat(std::size_t startIndex, std::size_t* nextIndexOut = nullptr, endType endianIn = defaultEndian, float* floatOut = nullptr) const
		{
			unsigned long tempRes = getLong(startIndex, nextIndexOut, endianIn);
			return *(float*)(&tempRes);
		}

		bool setBytes(std::vector<unsigned char> bytesIn, std::size_t atIndex, std::size_t* nextIndexOut = nullptr)
		{
			bool result = 0;
			if ((atIndex + bytesIn.size()) >= atIndex && atIndex + bytesIn.size() <= body.size())
			{
				/*int tempInt = 0;
				char* tempPtr = body.data() + atIndex;
				std::cout << "Original Value: " << std::hex;
				for (int i = 0; i < bytesIn.size(); i++)
				{
					tempInt = *(tempPtr + i);
					tempInt &= 0x000000FF;
					std::cout << ((tempInt < 0x10) ? "0" : "") << tempInt;
				}
				std::cout << "\n" << std::dec;*/
				std::memcpy(body.data() + atIndex, bytesIn.data(), bytesIn.size());
				if (nextIndexOut != nullptr)
				{
					*nextIndexOut += bytesIn.size();
				}
				/*tempInt = 0;
				tempPtr = body.data() + atIndex;
				std::cout << "Modified Value: " << std::hex;
				for (int i = 0; i < bytesIn.size(); i++)
				{
					tempInt = *(tempPtr + i);
					tempInt &= 0x000000FF;
					std::cout << ((tempInt < 0x10) ? "0" : "") << tempInt;
				}
				std::cout << "\n" << std::dec;*/
				result = 1;
			}
			else
			{
				if (nextIndexOut != nullptr)
				{
					*nextIndexOut = SIZE_MAX;
				}
			}

			return result;
		}
		bool setLLong(unsigned long long int valueIn, std::size_t atIndex, std::size_t* nextIndexOut = nullptr, endType endianIn = defaultEndian)
		{
			return setFundamental<unsigned long long int>(valueIn, atIndex, nextIndexOut, endianIn);
		}
		bool setLong(unsigned long int valueIn, std::size_t atIndex, std::size_t* nextIndexOut = nullptr, endType endianIn = defaultEndian)
		{
			return setFundamental<unsigned long int>(valueIn, atIndex, nextIndexOut, endianIn);
		}
		bool setShort(unsigned short int valueIn, std::size_t atIndex, std::size_t* nextIndexOut = nullptr, endType endianIn = defaultEndian)
		{
			return setFundamental<unsigned short int>(valueIn, atIndex, nextIndexOut, endianIn);
		}
		bool setChar(unsigned char valueIn, std::size_t atIndex, std::size_t* nextIndexOut = nullptr, endType endianIn = defaultEndian)
		{
			return setFundamental<unsigned char>(valueIn, atIndex, nextIndexOut, endianIn);
		}
		bool setDouble(double valueIn, std::size_t atIndex, std::size_t* nextIndexOut = nullptr, endType endianIn = defaultEndian)
		{
			unsigned long long tempVal = *(unsigned long long*)(&valueIn);
			return setFundamental<unsigned long long>(tempVal, atIndex, nextIndexOut, endianIn);
		}
		bool setFloat(float valueIn, std::size_t atIndex, std::size_t* nextIndexOut = nullptr, endType endianIn = defaultEndian)
		{
			unsigned long tempVal = *((unsigned long*)(&valueIn));
			return setFundamental<unsigned long>(tempVal, atIndex, nextIndexOut, endianIn);
		}

		bool insertBytes(std::vector<unsigned char> bytesIn, std::size_t atIndex)
		{
			bool result = 0;
			if (atIndex < body.size())
			{
				result = 1;
				body.insert(body.begin() + atIndex, bytesIn.begin(), bytesIn.end());
			}
			return result;
		}
		bool insertLLong(unsigned long long int valueIn, std::size_t atIndex, endType endianIn = defaultEndian)
		{
			return insertFundamental<unsigned long long int>(valueIn, atIndex, endianIn);
		}
		bool insertLong(unsigned long int valueIn, std::size_t atIndex, endType endianIn = defaultEndian)
		{
			return insertFundamental<unsigned long int>(valueIn, atIndex, endianIn);
		}
		bool insertShort(unsigned short int valueIn, std::size_t atIndex, endType endianIn = defaultEndian)
		{
			return insertFundamental<unsigned short int>(valueIn, atIndex, endianIn);
		}
		bool insertChar(unsigned char valueIn, std::size_t atIndex, endType endianIn = defaultEndian)
		{
			return insertFundamental<unsigned char>(valueIn, atIndex, endianIn);
		}
		bool insertDouble(double valueIn, std::size_t atIndex, endType endianIn = defaultEndian)
		{
			unsigned long long tempVal = *(unsigned long long*)(&valueIn);
			return insertFundamental<unsigned long long>(tempVal, atIndex, endianIn);
		}
		bool insertFloat(float valueIn, std::size_t atIndex, endType endianIn = defaultEndian)
		{
			unsigned long tempVal = *(unsigned long*)(&valueIn);
			return insertFundamental<unsigned long>(tempVal, atIndex, endianIn);
		}

		std::size_t search(const std::vector<unsigned char>& searchCriteria, std::size_t startItr = 0, std::size_t endItr = SIZE_MAX) const
		{
			std::vector<char>::const_iterator itr = body.end();
			std::vector<char>* searchCriteriaSigned = ((std::vector<char>*) & searchCriteria);
			if (endItr < startItr)
			{
				endItr = SIZE_MAX;
			}
			if (endItr > body.size())
			{
				endItr = body.size();
			}
			if (body.size() && startItr < body.size() && searchCriteria.size())
			{
				itr = std::search(body.begin() + startItr, body.begin() + endItr, searchCriteriaSigned->begin(), searchCriteriaSigned->end());
			}
			return (itr != body.end()) ? itr - body.begin() : SIZE_MAX;
		}
		std::size_t searchLLong(unsigned long long int searchCriteria, std::size_t startItr = 0, std::size_t endItr = SIZE_MAX, endType endianIn = defaultEndian) const
		{
			return findFundamental<unsigned long long int>(searchCriteria, startItr, endItr, endianIn);
		}
		std::size_t searchLong(unsigned long int searchCriteria, std::size_t startItr = 0, std::size_t endItr = SIZE_MAX, endType endianIn = defaultEndian) const
		{
			return findFundamental<unsigned long int>(searchCriteria, startItr, endItr, endianIn);
		}
		std::size_t searchShort(unsigned short int searchCriteria, std::size_t startItr = 0, std::size_t endItr = SIZE_MAX, endType endianIn = defaultEndian) const
		{
			return findFundamental<unsigned short>(searchCriteria, startItr, endItr, endianIn);
		}
		std::size_t searchChar(unsigned char searchCriteria, std::size_t startItr = 0, std::size_t endItr = SIZE_MAX, endType endianIn = defaultEndian) const
		{
			return findFundamental<unsigned char>(searchCriteria, startItr, endItr, endianIn);
		}
		std::size_t searchDouble(double searchCriteria, std::size_t startItr = 0, std::size_t endItr = SIZE_MAX, endType endianIn = defaultEndian) const
		{
			return findFundamental<double>(searchCriteria, startItr, endItr, endianIn);
		}
		std::size_t searchFloat(float searchCriteria, std::size_t startItr = 0, std::size_t endItr = SIZE_MAX, endType endianIn = defaultEndian) const
		{
			return findFundamental<float>(searchCriteria, startItr, endItr, endianIn);
		}

		std::vector<std::size_t> searchMultiple(const std::vector<unsigned char>& searchCriteria, std::size_t startItr = 0, std::size_t endItr = SIZE_MAX) const
		{
			std::size_t cursor = startItr;
			std::vector<std::size_t> result;
			std::size_t critSize = searchCriteria.size();
			bool done = 0;
			while (!done && cursor <= endItr)
			{
				cursor = search(searchCriteria, cursor);
				if (cursor != SIZE_MAX)
				{
					result.push_back(cursor);
					if ((cursor + critSize) > cursor)
					{
						cursor += critSize;
					}
				}
				else
				{
					done = 1;
				}
			}
			return result;
		}
		std::vector<std::size_t> searchMultipleLLong(unsigned long long int searchCriteria, std::size_t startItr = 0, std::size_t endItr = SIZE_MAX, endType endianIn = defaultEndian) const
		{
			return findFundamentalMultiple<unsigned long long int>(searchCriteria, startItr, endItr, endianIn);
		}
		std::vector<std::size_t> searchMultipleLong(unsigned long int searchCriteria, std::size_t startItr = 0, std::size_t endItr = SIZE_MAX, endType endianIn = defaultEndian) const
		{
			return findFundamentalMultiple<unsigned long int>(searchCriteria, startItr, endItr, endianIn);
		}
		std::vector<std::size_t> searchMultipleShort(unsigned short int searchCriteria, std::size_t startItr = 0, std::size_t endItr = SIZE_MAX, endType endianIn = defaultEndian) const
		{
			return findFundamentalMultiple<unsigned short>(searchCriteria, startItr, endItr, endianIn);
		}
		std::vector<std::size_t> searchMultipleChar(unsigned char searchCriteria, std::size_t startItr = 0, std::size_t endItr = SIZE_MAX, endType endianIn = defaultEndian) const
		{
			return findFundamentalMultiple<unsigned char>(searchCriteria, startItr, endItr, endianIn);
		}
		std::vector<std::size_t> searchMultipleDouble(double searchCriteria, std::size_t startItr = 0, std::size_t endItr = SIZE_MAX, endType endianIn = defaultEndian) const
		{
			return findFundamentalMultiple<double>(searchCriteria, startItr, endItr, endianIn);
		}
		std::vector<std::size_t> searchMultipleFloat(float searchCriteria, std::size_t startItr = 0, std::size_t endItr = SIZE_MAX, endType endianIn = defaultEndian) const
		{
			return findFundamentalMultiple<float>(searchCriteria, startItr, endItr, endianIn);
		}

		bool dumpToStream(std::ostream& outputStream, std::size_t startIndex = 0x00, std::size_t endIndex = SIZE_MAX) const
		{
			bool result = 0;
			if (outputStream.good())
			{
				if (startIndex < body.size())
				{
					if (endIndex > startIndex)
					{
						if (endIndex > body.size())
						{
							endIndex = body.size();
						}
						outputStream.write(body.data() + startIndex, endIndex - startIndex);
						result = outputStream.good();
					}
				}
			}
			return result;
		}
		bool dumpToFile(std::string targetPath, std::size_t startIndex = 0x00, std::size_t endIndex = SIZE_MAX) const
		{
			bool result = 0;
			std::ofstream output;
			output.open(targetPath, std::ios_base::binary | std::ios_base::out);
			if (output.is_open())
			{
				result = dumpToStream(output, startIndex, endIndex);
				std::cout << "Dumped body to \"" << targetPath << "\".\n";
			}
			return result;
		}
	};
	// Byte Array (Big Endian Default)
	typedef _byteArray<endType::et_BIG_ENDIAN> byteArray;
	// Byte Array (Little Endian Default)
	typedef _byteArray<endType::et_LITTLE_ENDIAN> byteArray_LE;

	// Old Testing Stuff
	/*const std::string testFileName = "testFile";
	const std::string testFileSuffix = ".dat";
	const std::string testFilePath = testFileName + testFileSuffix;
	const std::string testFileOutputPath = testFileName + "_edit" + testFileSuffix;
	int makeTestFile()
	{
		std::ofstream testFileOut(testFilePath, std::ios_base::out | std::ios_base::binary);
		for (std::size_t i = 0; i < USHRT_MAX; i++)
		{
			lava::writeRawDataToStream(testFileOut, i | (i << 0x10));
		}
		return 0;
	}
	int unitTest()
	{
		makeTestFile();
		lava::byteArray testFile;
		std::ifstream testFileIn(testFilePath, std::ios_base::in | std::ios_base::binary);
		testFile.populate(testFileIn);
		testFileIn.close();

		std::size_t cursor = 0x00;
		while (cursor < testFile.body.size())
		{
			double temp = testFile.getDouble(cursor, nullptr);
			testFile.setDouble(temp, cursor, &cursor);
		}
		testFile.dumpToFile(testFileOutputPath);
		return 0;
	}*/
}

#endif