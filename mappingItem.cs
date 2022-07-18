using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Collections.Generic;
using System.ComponentModel;

namespace BrawlSoundConverter
{
	/// <summary>
	/// Represents rsar nodes in a treeview
	/// </summary>
	class MappingItem : TreeNode, BrawlLib.Internal.Audio.IAudioSource
	{
		public int groupID, collectionID, wavID;
		public BrawlLib.Internal.Audio.IAudioStream sound;
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
				if( _fileSize >= 0xDDDDD )
					this.BackColor = System.Drawing.Color.Red;
				else
					this.BackColor = System.Drawing.Color.White;
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

			BrawlLib.SSBB.ResourceNodes.RWSDSoundNode sound = brsar.GetNode( groupID, collectionID, wavID ) as BrawlLib.SSBB.ResourceNodes.RWSDSoundNode;

			unsafe
			{
				int samples = sound.Header->NumSamples;
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
			brsar.CloseRSAR();
			this.TreeView.Invalidate();
		}
		public override string ToString()
		{
			return name;
		}
		public MappingItem(string name, int group = -1, int collection = -1, int wave = -1, bool sharesWave = false)
		{
			this.name = name;
			this.Text = name;
			this.groupID = group;
			this.collectionID = collection;
			this.wavID = wave;
			sound = null;
			_sharesWave = sharesWave;
			_fileSize = 0;
		}

		#region IAudioSource Members

		static int soundBufferSize = 1024 * 2000; //Allocate 2 MB buffer for sound caching, just to be safe
		static unsafe BrawlLib.Internal.VoidPtr soundData = Memory.Alloc( soundBufferSize );

		public unsafe BrawlLib.Internal.Audio.IAudioStream CreateStream()
		{
			//If this isn't connected to an RWSD SoundNode then return null
			if(wavID == -1)
				return null;

			BrawlLib.SSBB.ResourceNodes.RWSDSoundNode sound = brsar.GetNode( groupID, collectionID, wavID ) as BrawlLib.SSBB.ResourceNodes.RWSDSoundNode;
			BrawlLib.Wii.Audio.ADPCMStream stream;
			BrawlLib.SSBBTypes.RWSD_WAVEEntry header = new BrawlLib.SSBBTypes.RWSD_WAVEEntry();
			header = *sound.Header;
			if( header.NumSamples > soundBufferSize )
			{
				int breakpoint = 324;
				System.Windows.Forms.MessageBox.Show( "Sound file is too big for playback: " + header.NumSamples.ToString() + "b / " + soundBufferSize.ToString() + "b" );
				sound.Dispose();
				return null;
			}
			//Copy the sound data
			Memory.Copy( sound._dataAddr, soundData, header.NumSamples );
			stream = new BrawlLib.Wii.Audio.ADPCMStream( &header, soundData );
			brsar.CloseRSAR();
			return stream;
		}

		#endregion
	}
}
