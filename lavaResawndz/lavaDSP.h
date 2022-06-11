#ifndef LAVA_DSP_V1_H
#define LAVA_DSP_V1_H

#include <string>
#include <array>
#include "lavaByteArray.h"

namespace lava
{
	namespace brawl
	{
		// Ported Directly from the VGAudio Source Code to ensure compatibility
		// See here: https://github.com/Thealexbarney/VGAudio/blob/9d8f6ea04c83cccccb3dd7851a631bbd53a8dbbe/src/VGAudio/Codecs/GcAdpcm/GcAdpcmMath.cs
		unsigned long nibblesToSamples(unsigned long nibblesIn);
		unsigned long nibblesToBytes(unsigned long nibblesIn);
		unsigned long samplesToNibbles(unsigned long samplesIn);
		unsigned long samplesToBytes(unsigned long samplesIn);

		struct channelInfo
		{
			unsigned long address = ULONG_MAX;

			unsigned long channelDataOffset = ULONG_MAX;
			unsigned long adpcmInfoOffset = ULONG_MAX;
			unsigned long volFrontLeft = ULONG_MAX;
			unsigned long volFrontRight = ULONG_MAX;
			unsigned long volBackLeft = ULONG_MAX;
			unsigned long volBackRight = ULONG_MAX;
			unsigned long reserved = ULONG_MAX;

			bool populate(const lava::byteArray& bodyIn, unsigned long addressIn);
			bool exportContents(std::ostream& destinationStream);
		};
		struct adpcmInfo
		{
			unsigned long address = ULONG_MAX;

			std::array<unsigned short, 0x10> coefficients;
			unsigned short gain = USHRT_MAX;
			unsigned short ps = USHRT_MAX;
			unsigned short yn1 = USHRT_MAX;
			unsigned short yn2 = USHRT_MAX;
			unsigned short lps = USHRT_MAX;
			unsigned short lyn1 = USHRT_MAX;
			unsigned short lyn2 = USHRT_MAX;
			unsigned short pad = 0x00;

			bool populate(const lava::byteArray& bodyIn, unsigned long addressIn);
			bool exportContents(std::ostream& destinationStream) const;
		};

		/*
		dspHeader and SPT Structures adapted from the following:
		- VGMStream SPD+SPT Source: https://github.com/vgmstream/vgmstream/blob/37cc12295c92ec6aa874118fb237bd3821970836/src/meta/spt_spd.c
		- SPTex Source: https://hcs64.com/vgm_ripping.html
		*/
		struct dsp
		{
			unsigned long sampleCount = ULONG_MAX;
			unsigned long nibbleCount = ULONG_MAX;
			unsigned long sampleRate = ULONG_MAX;
			unsigned short loops = USHRT_MAX;
			unsigned short padding1 = 0x00;
			unsigned long loopStart = ULONG_MAX;
			unsigned long loopEnd = ULONG_MAX;
			unsigned long padding2 = 0x02;
			adpcmInfo soundInfo{};
			std::array<unsigned short, 0xA> padding3{};

			std::vector<unsigned char> body{};

			bool populate(const byteArray& bodyIn, unsigned long addressIn);
			bool populate(std::string pathIn, unsigned long addressIn);
			bool exportContents(std::ostream& destinationStream) const;
		};
		struct spt
		{
			unsigned long format = ULONG_MAX;
			unsigned long sampleRate = ULONG_MAX;
			unsigned long loopStartOffset = ULONG_MAX;
			unsigned long loopEndOffset = ULONG_MAX;
			unsigned long streamEnd = ULONG_MAX;
			unsigned long streamStart = ULONG_MAX;
			unsigned long padding = 0x00;
			adpcmInfo soundInfo{};
			bool populate(const byteArray& bodyIn, unsigned long addressIn);
			bool populate(std::string pathIn, unsigned long addressIn);
		};

		dsp sptToDSPHeader(const spt& sptIn);
	}
}

#endif