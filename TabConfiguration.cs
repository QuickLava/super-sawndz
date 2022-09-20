using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BrawlSoundConverter
{
	public class TabConfigurationTabEntry
	{
		public string tabName = "";
		public List<uint> includedGroupIDs = new List<uint>();
		public TabConfigurationTabEntry() { }
		public TabConfigurationTabEntry(string stringIn, int maxGroups = int.MaxValue)
		{
			string[] minorSplit = stringIn.Split(TabConfiguration.GroupDelimiter);
			if (minorSplit.Length >= 1 && (minorSplit.Length - 1) <= maxGroups)
			{
				tabName = minorSplit[0].Substring(1, minorSplit[0].Length - 2);
				for (int i = 1; i < minorSplit.Length && (includedGroupIDs.Count < maxGroups); i++)
				{
					includedGroupIDs.Add(Convert.ToUInt32(minorSplit[i], 16));
				}
			}
		}
	}

	public class TabConfiguration
	{
		public int brsarGroupCount = -1;
		public int brsarFileCount = -1;

		public static char BRSARDataDelimiter = '_';
		public static char TabDelimiter = '$';
		public static char GroupDelimiter = '-';
		public static string configFileExtension = ".tcfg";

		public List<TabConfigurationTabEntry> tabEntries = new List<TabConfigurationTabEntry>();
		public TabConfiguration() { }
		public TabConfiguration(string stringIn)
		{
			string[] majorSplit = stringIn.Split(TabDelimiter);
			if (majorSplit.Length >= 1)
			{
				string[] countSplit = majorSplit[0].Split(BRSARDataDelimiter);
				if (countSplit.Length == 2)
				{
					brsarGroupCount = Convert.ToInt32(countSplit[0], 16);
					brsarFileCount = Convert.ToInt32(countSplit[1], 16);
					int groupBudget = brsarGroupCount;
					for (int i = 1; i < majorSplit.Length; i++)
					{
						tabEntries.Add(new TabConfigurationTabEntry(majorSplit[i], groupBudget));
						groupBudget -= tabEntries.Last().includedGroupIDs.Count;
						tabEntries.Last().includedGroupIDs.Sort();
					}
				}
			}
		}
		public string getIDString()
		{
			string result = "";

			if (brsarGroupCount > 0 && brsarFileCount > 0)
			{
				result = brsarGroupCount.ToString("X3") + BRSARDataDelimiter + brsarFileCount.ToString("X3");
			}

			return result;
		}
		public string serialize()
		{
			string result = "";

			if (brsarGroupCount > 0 && brsarFileCount > 0)
			{
				result = getIDString();
				string dataString = "";
				foreach (TabConfigurationTabEntry tabEntry in tabEntries)
				{
					string entry = TabDelimiter + "\"" + tabEntry.tabName + "\"";
					foreach (int groupID in tabEntry.includedGroupIDs)
					{
						entry += GroupDelimiter + groupID.ToString("X3");
					}
					dataString += entry;
				}
				result += dataString;
			}
			
			return result;
		}

		public void populateTreeView(TreeView destinationView)
		{
			BrawlLib.SSBB.ResourceNodes.RSARNode currRSAR = brsar.GetRSAR();
			if (currRSAR != null)
			{
				BrawlLib.SSBB.ResourceNodes.ResourceNode[] groups = currRSAR.FindChildrenByType("", BrawlLib.SSBB.ResourceNodes.ResourceType.RSARGroup);
				foreach (TabConfigurationTabEntry tab in tabEntries)
				{
					int groupArrItr = 0;
					TreeNode tabNode = new TreeNode("Tab: \"" + tab.tabName + "\", Containing ");
					for (int i = 0; i < tab.includedGroupIDs.Count; i++)
					{
						BrawlLib.SSBB.ResourceNodes.RSARGroupNode currGroup = groups[groupArrItr] as BrawlLib.SSBB.ResourceNodes.RSARGroupNode;
						if ((uint)currGroup.StringId > tab.includedGroupIDs[i])
						{
							break;
						}
						bool foundTargetGroup = false;
						while (!foundTargetGroup && groupArrItr < groups.Length)
						{
							currGroup = groups[groupArrItr] as BrawlLib.SSBB.ResourceNodes.RSARGroupNode;
							if ((uint)currGroup.StringId == tab.includedGroupIDs[i])
							{
								tabNode.Nodes.Add("[" + currGroup.StringId.ToString("X3") + "] " + currGroup._name);
								foundTargetGroup = true;
							}
							groupArrItr++;
						}
						if (groupArrItr >= groups.Length)
						{
							break;
						}
					}
					tabNode.Text += tabNode.Nodes.Count.ToString() + " Group(s)";
					destinationView.Nodes.Add(tabNode);
				}
			}
		}
		
		public static int getCurrentBRSARSettingsIndex(BrawlLib.SSBB.ResourceNodes.RSARNode rsarIn)
		{
			int index = -1;

			if (rsarIn != null)
			{
				string tabDataIDString = 
					rsarIn.FindChildrenByType("", BrawlLib.SSBB.ResourceNodes.ResourceType.RSARGroup).Length.ToString("X3") + "_" + 
					rsarIn.Files.Count.ToString("X3");
				for (int i = 0; i < Properties.Settings.Default.TabSettings.Count; i++)
				{
					if (Properties.Settings.Default.TabSettings[i].StartsWith(tabDataIDString))
					{
						index = i;
						break;
					}
				}
			}

			return index;
		}
	}
}
