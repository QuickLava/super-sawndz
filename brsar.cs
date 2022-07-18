using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BrawlLib;
namespace BrawlSoundConverter
{
	/// <summary>
	/// Interfaces with .brsar files
	/// </summary>
	class brsar
	{
		//The current rsar filename
		public static string RSAR_FileName = Properties.Settings.Default.DefaultBrsarFilePath;
		//The current rsar itself
		static BrawlLib.SSBB.ResourceNodes.RSARNode _rsar;

		//Returns the rsar node, opens it if it is closed
		public static BrawlLib.SSBB.ResourceNodes.RSARNode GetRSAR()
		{
			if( _rsar == null )
			{
				_rsar = new BrawlLib.SSBB.ResourceNodes.RSARNode();
				_rsar.Replace( RSAR_FileName );
				_rsar._origPath = RSAR_FileName;
			}
			return _rsar;
		}

		//Closes the rsar if it's still open
		public static void CloseRSAR()
		{
			if( _rsar != null )
			{
				_rsar.Dispose();
				_rsar = null;
			}
		}

		//Returns an rsargroup, rsarfile, or rwsdsound node
		public static BrawlLib.SSBB.ResourceNodes.ResourceNode GetNode(int gid, int colid = -1, int wavid = -1)
		{
			BrawlLib.SSBB.ResourceNodes.RSARNode rsar = GetRSAR();
			BrawlLib.SSBB.ResourceNodes.ResourceNode[] groups = rsar.FindChildrenByType("", BrawlLib.SSBB.ResourceNodes.ResourceType.RSARGroup);
			BrawlLib.SSBB.ResourceNodes.RSARGroupNode group = null;
			foreach( BrawlLib.SSBB.ResourceNodes.RSARGroupNode g in groups )
			{
				if( g.StringId == gid )
				{
					group = g;
					break;
				}
			}
			if( colid == -1 )
				return group;
			BrawlLib.SSBB.ResourceNodes.RSARFileNode collection = null;
			foreach( BrawlLib.SSBB.ResourceNodes.RSARFileNode file in group._files )
			{
				if( file.FileNodeIndex == colid )
				{
					collection = file;
					break;
				}
			}
			if( wavid == -1 )
				return collection;
			BrawlLib.SSBB.ResourceNodes.ResourceNode audioFolder = ( BrawlLib.SSBB.ResourceNodes.ResourceNode ) collection.FindChild( "audio", false );
			return audioFolder.Children[ wavid ];
		}

		//Populates a treeView with MappingItem nodes from the current rsar
		public static void LoadTreeView( TreeView treeView )
		{
			//Only used to count the number of nodes added, no actual function in the program
			int nodeCount = 0;

			BrawlLib.SSBB.ResourceNodes.RSARNode rsar = GetRSAR();
			BrawlLib.SSBB.ResourceNodes.ResourceNode[] groups = rsar.FindChildrenByType("", BrawlLib.SSBB.ResourceNodes.ResourceType.RSARGroup);
			
			//Create root node and add all nodes to it.
			//Adding to the treeView collection directly will raise events, causing super slowdown when setting Text property.
			TreeNode root = new TreeNode();
			TreeNodeCollection nodes = root.Nodes;
			foreach( BrawlLib.SSBB.ResourceNodes.RSARGroupNode group in groups )
			{
				string name = "[" + group.StringId.ToString("X3") + "] " + group.Name;
				
				int groupID = group.StringId;
				MappingItem groupMap = new MappingItem( name, groupID );
				nodes.Add( groupMap );
				nodeCount++;
				
				foreach( BrawlLib.SSBB.ResourceNodes.RSARFileNode file in group._files )
				{
					if (file.NodeType != "BrawlLib.SSBB.ResourceNodes.RWSDNode")
						continue;
					string fName = file.Name;
					int collectionID = file.FileNodeIndex;
					BrawlLib.SSBB.ResourceNodes.ResourceNode audioFolder = ( BrawlLib.SSBB.ResourceNodes.ResourceNode) file.FindChild( "audio", false );
					BrawlLib.SSBB.ResourceNodes.RWSDDataGroupNode dataFolder = ( BrawlLib.SSBB.ResourceNodes.RWSDDataGroupNode) file.FindChild( "data", false );
					
					if (audioFolder == null || audioFolder.Children.Count == 0)
						continue;
					if (dataFolder == null || dataFolder.Children.Count == 0)
						continue;
					
					MappingItem colMap = new MappingItem( fName, groupID, collectionID );
					groupMap.Nodes.Add( colMap );
					nodeCount++;

					if( audioFolder == null )
						continue;

					//Same as nodeCount, used to track total size of sounds in collection. No actual function.
					int addUpSoundSize = 0;

					List<int> usedWaveIndeces = new List<int>();
					for (int i = 0; i < dataFolder.Children.Count; i++)
					{
						if (!(dataFolder.Children[i] is BrawlLib.SSBB.ResourceNodes.RWSDDataNode))
							continue;
						BrawlLib.SSBB.ResourceNodes.RWSDDataNode data = (BrawlLib.SSBB.ResourceNodes.RWSDDataNode)dataFolder.Children[i];
						int waveIndex = data._part3._waveIndex;

						if (audioFolder.Children.Count() <= waveIndex)
							continue;
						if (!(audioFolder.Children[waveIndex] is BrawlLib.SSBB.ResourceNodes.RSARFileAudioNode))
							continue;
						BrawlLib.SSBB.ResourceNodes.RSARFileAudioNode sound = (BrawlLib.SSBB.ResourceNodes.RSARFileAudioNode)audioFolder.Children[waveIndex];

						int soundSize = 0;
						unsafe
						{
							int samples = sound.NumSamples;
							if ((samples / 2 * 2) == samples)
							{
								soundSize = samples / 2;
							}
							else
							{
								soundSize = samples / 2 + 1;
							}
						}
						addUpSoundSize += soundSize;

						string sName = "[" + waveIndex.ToString("X3") + "] " + data.Name;
						MappingItem soundMap = new MappingItem(sName, groupID, collectionID, waveIndex, usedWaveIndeces.Contains(waveIndex));
						colMap.Nodes.Add(soundMap);
						soundMap.fileSize = soundSize;
						nodeCount++;

						//child node must have a parent in order for size to propogate correctly.
						if (!usedWaveIndeces.Contains(waveIndex))
						{
							usedWaveIndeces.Add(waveIndex);
						}
                    }
					for (int i = 0; i < audioFolder.Children.Count(); i++)
                    {
						if (usedWaveIndeces.Contains(i))
							continue;
						BrawlLib.SSBB.ResourceNodes.RSARFileAudioNode sound = (BrawlLib.SSBB.ResourceNodes.RSARFileAudioNode)audioFolder.Children[i];

						int soundSize = 0;
						unsafe
						{
							int samples = sound.NumSamples;
							if ((samples / 2 * 2) == samples)
							{
								soundSize = samples / 2;
							}
							else
							{
								soundSize = samples / 2 + 1;
							}
						}
						addUpSoundSize += soundSize;

						string sName = "[" + i.ToString("X3") + "] ORPHANED";
						MappingItem soundMap = new MappingItem(sName, groupID, collectionID, i, false);
						colMap.Nodes.Add(soundMap);
						soundMap.fileSize = soundSize;
						nodeCount++;
					}
				}

				//If the group doesn't have any collections then it doesn't have any sounds, remove it
				if( groupMap.Nodes.Count == 0 )
				{
					nodes.Remove( groupMap );
					nodeCount -= 2;
					continue;
				}
				
			}

			//Add the top level nodes to the treeview collection now that we're done.
			foreach( TreeNode node in nodes )
				treeView.Nodes.Add( node );
			CloseRSAR();
		}

		public static void LoadMultiExportTreeView(TreeView treeView)
		{
			//Only used to count the number of nodes added, no actual function in the program
			int nodeCount = 0;

			BrawlLib.SSBB.ResourceNodes.RSARNode rsar = GetRSAR();
			BrawlLib.SSBB.ResourceNodes.ResourceNode[] groups = rsar.FindChildrenByType("", BrawlLib.SSBB.ResourceNodes.ResourceType.RSARGroup);

			TreeNodeCollection objects = treeView.Nodes;

			foreach (BrawlLib.SSBB.ResourceNodes.RSARGroupNode group in groups)
			{
				if (group._files.Count > 0)
				{
					string name = "[" + group.StringId.ToString("X3") + "] " + group.Name;
					int groupID = group.StringId;
					MappingItem groupMap = new MappingItem(name, groupID);
					objects.Add(groupMap);
					nodeCount++;
				}
			}

			CloseRSAR();
		}
	}
}
