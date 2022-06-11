#include "lavaDSP.h"

namespace lava
{
	namespace brawl
	{
		unsigned long nibblesToSamples(unsigned long nibblesIn)
		{
			int frames = nibblesIn / 0x10;
			int extraNibbles = nibblesIn % 0x10;
			int extraSamples = extraNibbles < 2 ? 0 : extraNibbles - 2;
			return (0xE * frames) + extraSamples;
		}
		unsigned long nibblesToBytes(unsigned long nibblesIn)
		{
			ldiv_t temp = ldiv(nibblesIn, 2);
			return temp.quot + temp.rem;
		}
		unsigned long samplesToNibbles(unsigned long samplesIn)
		{
			int frames = samplesIn / 0x0E;
			int extraSamples = samplesIn % 0x0E;
			int extraNibbles = extraSamples == 0 ? 0 : extraSamples + 2;
			return 0x10 * frames + extraNibbles;
		}
		unsigned long samplesToBytes(unsigned long samplesIn)
		{
			return nibblesToBytes(samplesToNibbles(samplesIn));
		}

		bool channelInfo::populate(const lava::byteArray& bodyIn, unsigned long addressIn)
		{
			bool result = 0;

			if (bodyIn.populated() && (addressIn + 0x1C) <= bodyIn.size())
			{
				result = 1;
				address = addressIn;

				std::size_t cursor = addressIn;
				channelDataOffset = bodyIn.getLong(cursor, &cursor);
				adpcmInfoOffset = bodyIn.getLong(cursor, &cursor);
				volFrontLeft = bodyIn.getLong(cursor, &cursor);
				volFrontRight = bodyIn.getLong(cursor, &cursor);
				volBackLeft = bodyIn.getLong(cursor, &cursor);
				volBackRight = bodyIn.getLong(cursor, &cursor);
				reserved = bodyIn.getLong(cursor, &cursor);
			}

			return result;
		}
		bool channelInfo::exportContents(std::ostream& destinationStream)
		{
			bool result = 0;
			if (destinationStream.good())
			{
				lava::writeRawDataToStream(destinationStream, channelDataOffset);
				lava::writeRawDataToStream(destinationStream, adpcmInfoOffset);
				lava::writeRawDataToStream(destinationStream, volFrontLeft);
				lava::writeRawDataToStream(destinationStream, volFrontRight);
				lava::writeRawDataToStream(destinationStream, volBackLeft);
				lava::writeRawDataToStream(destinationStream, volBackRight);
				lava::writeRawDataToStream(destinationStream, reserved);
				result = destinationStream.good();
			}
			return result;
		}

		bool adpcmInfo::populate(const lava::byteArray& bodyIn, unsigned long addressIn)
		{
			bool result = 0;

			if (bodyIn.populated() && (addressIn + 0x2E) <= bodyIn.size())
			{
				result = 1;
				address = addressIn;

				std::size_t cursor = addressIn;
				for (unsigned long i = 0; i < coefficients.size(); i++)
				{
					coefficients[i] = bodyIn.getShort(cursor, &cursor);
				}
				gain = bodyIn.getShort(cursor, &cursor);
				ps = bodyIn.getShort(cursor, &cursor);
				yn1 = bodyIn.getShort(cursor, &cursor);
				yn2 = bodyIn.getShort(cursor, &cursor);
				lps = bodyIn.getShort(cursor, &cursor);
				lyn1 = bodyIn.getShort(cursor, &cursor);
				lyn2 = bodyIn.getShort(cursor, &cursor);
			}

			return result;
		}
		bool adpcmInfo::exportContents(std::ostream& destinationStream) const
		{
			bool result = 0;
			if (destinationStream.good())
			{
				for (std::size_t i = 0; i < coefficients.size(); i++)
				{
					lava::writeRawDataToStream(destinationStream, coefficients[i]);
				}
				lava::writeRawDataToStream(destinationStream, gain);
				lava::writeRawDataToStream(destinationStream, ps);
				lava::writeRawDataToStream(destinationStream, yn1);
				lava::writeRawDataToStream(destinationStream, yn2);
				lava::writeRawDataToStream(destinationStream, lps);
				lava::writeRawDataToStream(destinationStream, lyn1);
				lava::writeRawDataToStream(destinationStream, lyn2);
				lava::writeRawDataToStream(destinationStream, pad);
				result = destinationStream.good();
			}
			return result;
		}

		bool dsp::populate(const byteArray& bodyIn, unsigned long addressIn)
		{
			bool result = 0;

			if (bodyIn.populated())
			{
				std::size_t cursor = addressIn;
				sampleCount = bodyIn.getLong(cursor, &cursor);
				nibbleCount = bodyIn.getLong(cursor, &cursor);
				sampleRate = bodyIn.getLong(cursor, &cursor); 
				loops = bodyIn.getShort(cursor, &cursor);
				padding1 = bodyIn.getShort(cursor, &cursor);
				loopStart = bodyIn.getLong(cursor, &cursor);
				loopEnd = bodyIn.getLong(cursor, &cursor);
				padding2 = bodyIn.getLong(cursor, &cursor);
				soundInfo.populate(bodyIn, cursor);
				cursor += 0x30;
				for (unsigned long i = 0; i < padding3.size(); i++)
				{
					padding3[i] = bodyIn.getShort(cursor, &cursor);
				}
				std::size_t numGotten = SIZE_MAX;
				body = bodyIn.getBytes(SIZE_MAX, cursor, numGotten);
				result = cursor != SIZE_MAX && numGotten != SIZE_MAX;
			}

			return result;
		}
		bool dsp::populate(std::string pathIn, unsigned long addressIn)
		{
			bool result = 0;

			std::ifstream dspStream(pathIn, std::ios_base::in | std::ios_base::binary);
			if (dspStream.is_open())
			{
				byteArray tempArr(dspStream);
				result = populate(tempArr, addressIn);
			}

			return result;
		}
		bool dsp::exportContents(std::ostream& destinationStream) const
		{
			bool result = 0;

			if (destinationStream.good())
			{
				writeRawDataToStream(destinationStream, sampleCount);
				writeRawDataToStream(destinationStream, nibbleCount);
				writeRawDataToStream(destinationStream, sampleRate);
				writeRawDataToStream(destinationStream, loops);
				writeRawDataToStream(destinationStream, padding1);
				writeRawDataToStream(destinationStream, loopStart);
				writeRawDataToStream(destinationStream, loopEnd);
				writeRawDataToStream(destinationStream, padding2);
				soundInfo.exportContents(destinationStream);
				for (unsigned long i = 0; i < padding3.size(); i++)
				{
					writeRawDataToStream(destinationStream, padding3[i]);
				}
				destinationStream.write((char*)body.data(), body.size());
				result = destinationStream.good();
			}

			return result;
		}

		bool spt::populate(const byteArray& bodyIn, unsigned long addressIn)
		{
			bool result = 0;

			if (bodyIn.populated())
			{
				std::size_t cursor = addressIn;
				format = bodyIn.getLong(cursor, &cursor);
				sampleRate = bodyIn.getLong(cursor, &cursor);
				loopStartOffset = bodyIn.getLong(cursor, &cursor);
				loopEndOffset = bodyIn.getLong(cursor, &cursor);
				streamEnd = bodyIn.getLong(cursor, &cursor);
				streamStart = bodyIn.getLong(cursor, &cursor);
				padding = bodyIn.getLong(cursor, &cursor);
				soundInfo.populate(bodyIn, cursor);
				cursor += 0x30;
				result = cursor != SIZE_MAX;
			}

			return result;
		}
		bool spt::populate(std::string pathIn, unsigned long addressIn)
		{
			bool result = 0;

			std::ifstream sptStream(pathIn, std::ios_base::in | std::ios_base::binary);
			if (sptStream.is_open())
			{
				byteArray tempArr(sptStream);
				result = populate(tempArr, addressIn);
			}

			return result;
		}

		dsp sptToDSPHeader(const spt& sptIn)
		{
			dsp result;

			unsigned long dataStart = (sptIn.streamStart / 2) - 1;
			unsigned long dataEnd = (sptIn.streamEnd / 2) + 1;

			result.nibbleCount = (dataEnd - dataStart) * 2;
			result.sampleCount = nibblesToSamples(result.nibbleCount);
			result.sampleRate = sptIn.sampleRate;
			result.loops = sptIn.format & 1;
			result.padding1 = 0;
			result.loopStart = sptIn.loopStartOffset - dataStart;
			result.loopEnd = sptIn.loopEndOffset - dataStart;
			result.padding2 = 2;
			result.soundInfo = sptIn.soundInfo;
			result.padding3.fill(0);
			return result;
		}
	}
}