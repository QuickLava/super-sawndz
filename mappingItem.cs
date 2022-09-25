using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.ComponentModel;

namespace BrawlSoundConverter
{
	/// <summary>
	/// Represents rsar nodes in a treeview
	/// </summary>
	public class MappingItem : TreeNode, BrawlLib.Internal.Audio.IAudioSource
	{
		public int groupID, collectionID, wavID, infoIndex;
		public BrawlLib.Internal.Audio.IAudioStream[] streams;
		public string name;
		int _fileSize;
		// Controls whether or not a sounds filesize propogates to its parents.
		// This is necessary to prevent inflated filesize reports for banks in which many sounds share a wavID.
		bool _sharesWave = false;
		public int fileSize
		{
			get
			{
				return _fileSize;
			}
			set
			{
				//Propagate size changes
				MappingItem p = Parent as MappingItem;
				if(p != null && !_sharesWave)
					p.sizeOfChildChanged( value - _fileSize );
				_fileSize = value;
				
				//Color the node red if it goes over the usual character filesize limit
				if(Properties.Settings.Default.GroupSizeWarningThreshold > 0 && _fileSize >= Properties.Settings.Default.GroupSizeWarningThreshold )
					this.BackColor = System.Drawing.Color.Red;
				//Update the name with the new filesize in it
				generateName();
			}
		}

		//Propagates size changes
		void sizeOfChildChanged( int diff )
		{
			fileSize += diff;
		}
		int _prevFileSize = 0;

		//Loads Text with the name and filesize, run after adding child nodes/setting size
		public void generateName()
		{
			if( fileSize != _prevFileSize )
			{
				Text = name + " (" + _fileSize.ToString( "X" ) + ")";
				_prevFileSize = fileSize;
			}
		}

		//Gets the size of an RWSD Sound node
		//Doesn't include the header, so it's probably off by a little
		public void updateSize()
		{
			if(wavID == -1)
				return;

			BrawlLib.SSBB.ResourceNodes.RSARFileAudioNode sound = brsar.GetNode( groupID, collectionID, wavID ) as BrawlLib.SSBB.ResourceNodes.RSARFileAudioNode;

			unsafe
			{
				int samples = sound.NumSamples;
				if( ( samples / 2 * 2 ) == samples )
				{
					fileSize = samples / 2;
				}
				else
				{
					fileSize = samples / 2 + 1;
				}
			}
			MappingItem p = this;
			this.TreeView.Invalidate();
		}
		public override string ToString()
		{
			return name;
		}
		public MappingItem(string name, int group = -1, int collection = -1, int wave = -1, int infoIndexIn = -1, bool sharesWave = false)
		{
			this.name = name;
			this.Text = name;
			this.groupID = group;
			this.collectionID = collection;
			this.wavID = wave;
			this.infoIndex = infoIndexIn;
			_sharesWave = sharesWave;
			streams = null;
			_fileSize = 0;
		}

		#region IAudioSource Members

		public bool IsLooped => (streams == null) ? 
			false : 
			(streams.Length <= 0) ? false : streams[0].IsLooping;
		public unsafe BrawlLib.Internal.Audio.IAudioStream[] CreateStreams()
		{
			//If this isn't connected to an RWSD SoundNode then return null
			if(wavID == -1)
				return null;

			BrawlLib.SSBB.ResourceNodes.RSARFileAudioNode sound = brsar.GetNode( groupID, collectionID, wavID ) as BrawlLib.SSBB.ResourceNodes.RSARFileAudioNode;
			streams = sound.CreateStreams();
			return streams;
		}


		#endregion

		public static int compareMappingItems(MappingItem x, MappingItem y)
		{
			int result = 0;
			if (x == null)
			{
				if (y == null)
				{
					result = 0;
				}
				else
				{
					result = -1;
				}
			}
			else
			{
				if (y == null)
				{
					result = 1;
				}
				else
				{
					int xCompVal = (x.groupID < 0) ? int.MaxValue : x.groupID;
					int yCompVal = (y.groupID < 0) ? int.MaxValue : y.groupID;
					result = xCompVal.CompareTo(yCompVal);
					if (result == 0)
					{
						result = x.Text.CompareTo(y.Text);
					}
				}
			}
			return result;
		}
	}
}
