using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BrawlSoundConverter
{
	public class StreamSource : BrawlLib.Internal.Audio.IAudioSource
	{
		public BrawlLib.Internal.Audio.IAudioStream stream;
		public StreamSource()
		{
			stream = null;
		}
		public StreamSource(BrawlLib.Internal.Audio.IAudioStream istream)
		{
			stream = istream;
		}
		#region IAudioSource Members
		public BrawlLib.Internal.Audio.IAudioStream CreateStream()
		{
			return stream;
		}
		public BrawlLib.Internal.Audio.IAudioStream[] CreateStreams()
		{
			return new BrawlLib.Internal.Audio.IAudioStream[] { stream };
		}
		public bool IsLooped => (stream == null) ? false : stream.IsLooping;
		#endregion
	}
}
