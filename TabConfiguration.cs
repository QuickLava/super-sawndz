using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrawlSoundConverter
{
	public class TabConfigurationTabEntry
	{
		public string tabName = "";
		public List<int> includedGroupIDs = new List<int>();
		public TabConfigurationTabEntry(string stringIn)
		{
			string[] minorSplit = stringIn.Split(TabConfiguration.GroupDelimiter);
			if (minorSplit.Length >= 1)
			{
				tabName = minorSplit[0].Substring(1, minorSplit[0].Length - 2);
				for (int i = 1; i < minorSplit.Length; i++)
				{
					includedGroupIDs.Add(Convert.ToInt32(minorSplit[i], 16));
				}
			}
		}
	}

	public class TabConfiguration
	{
		public int brsarGroupCount = -1;
		public int brsarFileCount = -1;

		public static char TabDelimiter = '$';
		public static char GroupDelimiter = '-';

		public List<TabConfigurationTabEntry> tabEntries = new List<TabConfigurationTabEntry>();
		public TabConfiguration(string stringIn)
		{
			string[] majorSplit = stringIn.Split('$');
			if (majorSplit.Length >= 2)
			{
				string[] countSplit = majorSplit[0].Split('_');
				if (countSplit.Length == 2)
				{
					brsarGroupCount = Convert.ToInt32(countSplit[0], 16);
					brsarFileCount = Convert.ToInt32(countSplit[1], 16);
					for (int i = 1; i < majorSplit.Length; i++)
					{
						tabEntries.Add(new TabConfigurationTabEntry(majorSplit[i]));
					}
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
