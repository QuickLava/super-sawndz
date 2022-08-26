﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using BrawlLib;
using KTrie;
namespace BrawlSoundConverter
{
	/// <summary>
	/// Interfaces with .brsar files
	/// </summary>
	class brsar
	{
		//The current rsar filename
		public static string RSAR_FileName = Properties.Settings.Default.DefaultBrsarFilePath;
		public static KTrie.StringTrie<MappingItem> groupTrie;
		public static KTrie.StringTrie<MappingItem> soundTrie;
		//The current rsar itself
		static BrawlLib.SSBB.ResourceNodes.RSARNode _rsar;

		//Returns the rsar node, opens it if it is closed
		public static BrawlLib.SSBB.ResourceNodes.RSARNode GetRSAR()
		{
			if( _rsar == null )
			{
				_rsar = new BrawlLib.SSBB.ResourceNodes.RSARNode();
				_rsar.Replace( RSAR_FileName );
				_rsar._origPath = Path.GetFullPath(RSAR_FileName);
				groupTrie = new KTrie.StringTrie<MappingItem>();
				soundTrie = new KTrie.StringTrie<MappingItem>();
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
		public static void SaveRSAR(bool forceSave = false)
		{
			if (forceSave || _rsar.IsDirty)
			{
				_rsar.Rebuild(forceSave);
				_rsar.Export(_rsar._origPath);
			}
		}
		public static void ReloadRSAR(bool forceSave = true)
		{
			SaveRSAR(forceSave);
			CloseRSAR();
			GetRSAR();
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
		public static BrawlLib.SSBB.ResourceNodes.RWSDDataNode GetRWSDDataNode(int groupID, int collectionID, int infoIndex)
		{
			BrawlLib.SSBB.ResourceNodes.RWSDDataNode result = null;
			BrawlLib.SSBB.ResourceNodes.RSARFileNode file = GetNode(groupID, collectionID) as BrawlLib.SSBB.ResourceNodes.RSARFileNode;
			if (file != null)
			{
				BrawlLib.SSBB.ResourceNodes.RWSDDataGroupNode dataFolder = (BrawlLib.SSBB.ResourceNodes.RWSDDataGroupNode)file.FindChild("data", false);
				if (dataFolder != null)
				{
					foreach(BrawlLib.SSBB.ResourceNodes.RWSDDataNode data in dataFolder.Children)
					{
						if (data._refs.Count > 0 && data._refs[0].InfoIndex == infoIndex)
						{
							result = data;
							break;
						}
					}
				}
			}
			return result;
		}

		//public static BrawlLib.SSBB.Types.Audio.SYMBMaskEntry FindStringInSymbTrie(string toFind, BrawlLib.SSBB.Types.Audio.SYMBMaskHeader toSearch)
		//{
		//	BrawlLib.SSBB.Types.Audio.SYMBMaskEntry result = new BrawlLib.SSBB.Types.Audio.SYMBMaskEntry();
		//	result._index = int.MaxValue;
		//	unsafe
		//	{
		//		if (toSearch._rootId < toSearch._numEntries)
		//		{
		//			BrawlLib.SSBB.Types.Audio.SYMBMaskEntry currEntry = toSearch.Entries[toSearch._rootId];
		//			while(currEntry._flags == 0)
		//			{
		//				if ((currEntry._bit >> 3) >= toFind.Length)
		//				{
		//					currEntry = toSearch.Entries[currEntry._leftId];
		//					continue;
		//				}
		//				if (BrawlLib.SSBB.Types.Audio.SYMBMaskEntry.CheckBit(toFind, currEntry._bit))
		//				{
		//					currEntry = toSearch.Entries[currEntry._rightId];
		//				}
		//				else
		//				{
		//					currEntry = toSearch.Entries[currEntry._leftId];
		//				}
		//			}
		//			result = currEntry;
		//		}
		//	}
		//	return result;
		//}
		//public static List<int> GetStringsFromSymbEntry(BrawlLib.SSBB.Types.Audio.SYMBMaskEntry entry, BrawlLib.SSBB.Types.Audio.SYMBMaskHeader header, List<int> idList = null)
		//{
		//	if (idList == null)
		//	{
		//		idList = new List<int>();
		//	}

		//	List<int> result = null;
		//	unsafe
		//	{
		//		if (entry._index < header._numEntries)
		//		{
		//			if (entry._flags == 1)
		//			{
		//				idList.Add(entry._stringId);
		//			}
		//		}
		//		else
		//		{
		//			GetStringsFromSymbEntry(*(header.Entries + entry._leftId), header, idList);
		//			GetStringsFromSymbEntry(*(header.Entries + entry._rightId), header, idList);
		//		}
		//	}

		//	return idList;
		//}
		//public static MappingItem FindNodeFromString(string toFind)
		//{
		//	MappingItem result = null;

		//	BrawlLib.SSBB.ResourceNodes.RSARNode currRSAR = GetRSAR();
		//	unsafe
		//	{
		//		if (currRSAR != null && currRSAR.Header != null)
		//		{
		//			BrawlLib.SSBB.Types.Audio.RSARHeader* currRSARHeader = currRSAR.Header;
		//			BrawlLib.SSBB.Types.Audio.SYMBHeader* currRSARSymb = currRSARHeader->SYMBBlock;
		//			List<int> test1 = GetStringsFromSymbEntry(FindStringInSymbTrie(toFind, *currRSARSymb->MaskData3), *currRSARSymb->MaskData3, null);
		//		}
		//	}

		//	return result;
		//}


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
				string name = "[" + group.StringId.ToString("X3") + "] ";
				if (Properties.Settings.Default.EnableFullLengthNames)
				{
					name += group.TreePath.Replace('/', '_');
				}
				else
				{
					name += group.Name;
				}
				
				int groupID = group.StringId;
				MappingItem groupMap = new MappingItem( name, groupID, -1, -1, group.InfoIndex );
				nodes.Add( groupMap );
				if (!groupTrie.ContainsKey(group.Name))
				{
					groupTrie.Add(group.Name, groupMap);
				}
				nodeCount++;
				
				foreach( BrawlLib.SSBB.ResourceNodes.RSARFileNode file in group._files )
				{
					if (file.NodeType != "BrawlLib.SSBB.ResourceNodes.RWSDNode")
						continue;
					int collectionID = file.FileNodeIndex;
					string fName = "[" + collectionID.ToString("X3") + "] RWSD";
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
						int infoIndex = -1;
						if (data._refs.Count > 0)
						{
							infoIndex = data._refs[0].InfoIndex;
						}
						else
						{
							infoIndex = -1;
						}
						MappingItem soundMap = new MappingItem(sName, groupID, collectionID, waveIndex, infoIndex, usedWaveIndeces.Contains(waveIndex));
						colMap.Nodes.Add(soundMap);
						if (!soundTrie.ContainsKey(data.Name))
						{
							soundTrie.Add(data.Name, soundMap);
						}
						soundMap.fileSize = soundSize;
						if (infoIndex == -1)
						{
							groupMap.BackColor = System.Drawing.Color.Yellow;
							colMap.BackColor = System.Drawing.Color.Yellow;
							soundMap.BackColor = System.Drawing.Color.Yellow;
						}
						nodeCount++;

						//child node must have a parent in order for size to propogate correctly.
						if (!usedWaveIndeces.Contains(waveIndex))
						{
							usedWaveIndeces.Add(waveIndex);
						}
                    }
					for (int i = 0; i < audioFolder.Children.Count; i++)
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
						MappingItem soundMap = new MappingItem(sName, groupID, collectionID, i, -1, false);
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
		}

		public static void LoadMultiExportTreeView(TreeView destView, TreeView sourceView)
		{
			foreach (MappingItem sourceNode in sourceView.Nodes)
			{
				destView.Nodes.Add(new MappingItem(sourceNode.name, sourceNode.groupID, -1, -1, sourceNode.infoIndex));
			}
		}
		public static void LoadMultiWAVExportTreeView(TreeView treeView, int targetGroupID, int targetFileID)
		{
			BrawlLib.SSBB.ResourceNodes.RSARNode rsar = GetRSAR();
			BrawlLib.SSBB.ResourceNodes.ResourceNode[] groups = rsar.FindChildrenByType("", BrawlLib.SSBB.ResourceNodes.ResourceType.RSARGroup);

			//Create root node and add all nodes to it.
			//Adding to the treeView collection directly will raise events, causing super slowdown when setting Text property.
			TreeNode root = new TreeNode();
			TreeNodeCollection nodes = root.Nodes;
			foreach (BrawlLib.SSBB.ResourceNodes.RSARGroupNode group in groups)
			{
				if (group.StringId == targetGroupID)
				{
					foreach (BrawlLib.SSBB.ResourceNodes.RSARFileNode file in group._files)
					{
						if (file.NodeType != "BrawlLib.SSBB.ResourceNodes.RWSDNode")
							continue;
						if (file.FileNodeIndex != targetFileID)
							continue;
						BrawlLib.SSBB.ResourceNodes.ResourceNode audioFolder = (BrawlLib.SSBB.ResourceNodes.ResourceNode)file.FindChild("audio", false);
						if (audioFolder == null || audioFolder.Children.Count == 0)
							continue;

						for (int i = 0; i < audioFolder.Children.Count(); i++)
						{
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

							MappingItem soundMap = new MappingItem("Audio[" + i.ToString("X3") + "]", targetGroupID, targetFileID, i, -1, false);
							root.Nodes.Add(soundMap);
							soundMap.fileSize = soundSize;
						}
						break;
					}
					break;
				}
			}

			//Add the top level nodes to the treeview collection now that we're done.
			foreach (TreeNode node in nodes)
				treeView.Nodes.Add(node);
		}
		public static void LoadMultiWAVExportInfoTreeView(TreeView treeView, int targetGroupID, int targetFileID)
		{
			BrawlLib.SSBB.ResourceNodes.RSARNode rsar = GetRSAR();
			BrawlLib.SSBB.ResourceNodes.ResourceNode[] groups = rsar.FindChildrenByType("", BrawlLib.SSBB.ResourceNodes.ResourceType.RSARGroup);

			//Create root node and add all nodes to it.
			//Adding to the treeView collection directly will raise events, causing super slowdown when setting Text property.
			TreeNode root = new TreeNode();
			TreeNodeCollection nodes = root.Nodes;
			foreach (BrawlLib.SSBB.ResourceNodes.RSARGroupNode group in groups)
			{
				if (group.StringId == targetGroupID)
				{
					foreach (BrawlLib.SSBB.ResourceNodes.RSARFileNode file in group._files)
					{
						if (file.NodeType != "BrawlLib.SSBB.ResourceNodes.RWSDNode")
							continue;
						if (file.FileNodeIndex != targetFileID)
							continue;

						BrawlLib.SSBB.ResourceNodes.RWSDDataGroupNode dataFolder = (BrawlLib.SSBB.ResourceNodes.RWSDDataGroupNode)file.FindChild("data", false);
						if (dataFolder == null || dataFolder.Children.Count == 0)
							continue;
						BrawlLib.SSBB.ResourceNodes.ResourceNode audioFolder = (BrawlLib.SSBB.ResourceNodes.ResourceNode)file.FindChild("audio", false);
						if (audioFolder == null || audioFolder.Children.Count == 0)
							continue;

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

							string sName = data.Name + " - Using Audio[" + waveIndex.ToString("X3") + "]";
							int infoIndex = -1;
							if (data._refs.Count > 0)
							{
								infoIndex = data._refs[0].InfoIndex;
							}
							else
							{
								infoIndex = -1;
							}
							MappingItem soundMap = new MappingItem(sName, targetGroupID, targetFileID, waveIndex, infoIndex, usedWaveIndeces.Contains(waveIndex));
							root.Nodes.Add(soundMap);
							soundMap.fileSize = soundSize;
							if (infoIndex == -1)
							{
								soundMap.BackColor = System.Drawing.Color.Yellow;
							}

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

							string sName = "ORPHANED - Using Audio[" + i.ToString("X3") + "]";
							MappingItem soundMap = new MappingItem( sName, targetGroupID, targetFileID, i, -1, false);
							root.Nodes.Add(soundMap);
							soundMap.fileSize = soundSize;
						}
						break;
					}
					break;
				}
			}

			//Add the top level nodes to the treeview collection now that we're done.
			foreach (TreeNode node in nodes)
				treeView.Nodes.Add(node);
		}

	}
}
