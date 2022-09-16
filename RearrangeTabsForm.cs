using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BrawlSoundConverter
{
	public partial class RearrangeTabsForm : Form
	{
		public TabConfiguration loadedTabs = null;

		public RearrangeTabsForm(TabConfiguration currTabs)
		{
			InitializeComponent();
			loadedTabs = currTabs;
			foreach (TabConfigurationTabEntry tab in loadedTabs.tabEntries)
			{
				treeView1.Nodes.Add(tab.tabName);
			}
		}

		private void buttonMoveUp_Click(object sender, EventArgs e)
		{
			TreeNode currNode = treeView1.SelectedNode;
			if (currNode != null && currNode.Index > 0)
			{
				int targetIndex = currNode.Index - 1;
				TabConfigurationTabEntry currTab = loadedTabs.tabEntries[currNode.Index];
				treeView1.Nodes.Remove(currNode);
				treeView1.Nodes.Insert(targetIndex, currNode);
				loadedTabs.tabEntries.Remove(currTab);
				loadedTabs.tabEntries.Insert(targetIndex, currTab);
				treeView1.SelectedNode = currNode;
			}
		}

		private void buttonMoveDown_Click(object sender, EventArgs e)
		{
			TreeNode currNode = treeView1.SelectedNode;
			if (currNode != null && currNode.Index < (treeView1.Nodes.Count - 1))
			{
				int targetIndex = currNode.Index + 1;
				TabConfigurationTabEntry currTab = loadedTabs.tabEntries[currNode.Index];
				treeView1.Nodes.Remove(currNode);
				treeView1.Nodes.Insert(targetIndex, currNode);
				loadedTabs.tabEntries.Remove(currTab);
				loadedTabs.tabEntries.Insert(targetIndex, currTab);
				treeView1.SelectedNode = currNode;
			}
		}

		private void buttonSave_Click(object sender, EventArgs e)
		{
			DialogResult = DialogResult.OK;
			Close();
		}

		private void buttonCancel_Click(object sender, EventArgs e)
		{
			DialogResult = DialogResult.Cancel;
			Close();
		}
	}
}
