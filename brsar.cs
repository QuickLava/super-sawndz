﻿using System;
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
		public static string RSAR_FileName = "smashbros_sound.brsar";
		//The current rsar itself
		static BrawlLib.SSBB.ResourceNodes.RSARNode _rsar;

		//Returns the rsar node, opens it if it is closed
		public static BrawlLib.SSBB.ResourceNodes.RSARNode GetRSAR()
		{
			if( _rsar == null )
			{
				_rsar = new BrawlLib.SSBB.ResourceNodes.RSARNode();
				_rsar.Replace( RSAR_FileName );
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
			BrawlLib.SSBB.ResourceNodes.RSARFolderNode folder = ( BrawlLib.SSBB.ResourceNodes.RSARFolderNode ) rsar.FindChild( "Info/snd/group", false );
			BrawlLib.SSBB.ResourceNodes.ResourceNode[] groups = folder.FindChildrenByType( "", BrawlLib.SSBB.ResourceNodes.ResourceType.RSARGroup );
			BrawlLib.SSBB.ResourceNodes.RSARGroupNode group = null;
			foreach( BrawlLib.SSBB.ResourceNodes.RSARGroupNode g in groups )
			{
				if( g.Id == gid )
				{
					group = g;
					break;
				}
			}
			if( colid == -1 )
				return group;
			BrawlLib.SSBB.ResourceNodes.RSARFileNode collection = null;
			foreach( BrawlLib.SSBB.ResourceNodes.RSARFileNode file in group.Files )
			{
				if( file.FileNodeIndex == colid )
				{
					collection = file;
					break;
				}
			}
			if( wavid == -1 )
				return collection;
			BrawlLib.SSBB.ResourceNodes.RWSDGroupNode audioFolder = ( BrawlLib.SSBB.ResourceNodes.RWSDGroupNode ) collection.FindChild( "audio", false );
			return audioFolder.Children[ wavid ];

		}

		//Populates a treeView with MappingItem nodes from the current rsar
		public static void LoadTreeView( TreeView treeView )
		{
			//Only used to count the number of nodes added, no actual function in the program
			int nodeCount = 0;

			StringBuilder sb = new StringBuilder();
			BrawlLib.SSBB.ResourceNodes.RSARNode rsar = GetRSAR();
			BrawlLib.SSBB.ResourceNodes.RSARFolderNode folder = (BrawlLib.SSBB.ResourceNodes.RSARFolderNode)rsar.FindChild("Info/snd/group",false);
			BrawlLib.SSBB.ResourceNodes.ResourceNode[] groups = folder.FindChildrenByType( "", BrawlLib.SSBB.ResourceNodes.ResourceType.RSARGroup );
			
			//Create root node and add all nodes to it.
			//Adding to the treeView collection directly will raise events, causing super slowdown when setting Text property.
			TreeNode root = new TreeNode();
			TreeNodeCollection nodes = root.Nodes;
			foreach( BrawlLib.SSBB.ResourceNodes.RSARGroupNode group in groups )
			{
				string name = group.Name;
				
				int groupID = group.Id;
				MappingItem groupMap = new MappingItem( name, groupID );
				nodes.Add( groupMap );
				nodeCount++;
				
				foreach( BrawlLib.SSBB.ResourceNodes.RSARFileNode file in group.Files )
				{
					string fName = file.Name;
					int collectionID = file.FileNodeIndex;
					BrawlLib.SSBB.ResourceNodes.RWSDGroupNode audioFolder = ( BrawlLib.SSBB.ResourceNodes.RWSDGroupNode ) file.FindChild( "audio", false );
					
					if( audioFolder == null || audioFolder.Children.Count == 0 )
						continue;
					
					MappingItem colMap = new MappingItem( fName, groupID, collectionID );
					groupMap.Nodes.Add( colMap );
					nodeCount++;

					if( audioFolder == null )
						continue;

					//Same as nodeCount, used to track total size of sounds in collection. No actual function.
					int addUpSoundSize = 0;

					for(int i = 0; i < audioFolder.Children.Count; i++)
					{
						if(!(audioFolder.Children[i] is BrawlLib.SSBB.ResourceNodes.RWSDSoundNode))
							continue;
						BrawlLib.SSBB.ResourceNodes.RWSDSoundNode sound = (BrawlLib.SSBB.ResourceNodes.RWSDSoundNode)audioFolder.Children[i];
						int soundSize = 0;
						unsafe
						{
							int samples = sound.Header->NumSamples;
							if( ( samples / 2 * 2 ) == samples )
							{
								soundSize = samples / 2;
							}
							else
							{
								soundSize = samples / 2 + 1;
							}
						}
						addUpSoundSize += soundSize;
						
						MappingItem soundMap = new MappingItem(sound.Name, groupID, collectionID,i);

						colMap.Nodes.Add( soundMap );
						nodeCount++;
						//child node must have a parent in order for size to propogate correctly.
						soundMap.fileSize = soundSize;
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

	}
}
