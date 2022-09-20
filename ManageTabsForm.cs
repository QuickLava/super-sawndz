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
	public partial class ManageTabsForm : Form
	{
		public TabConfiguration loadedTabs = null;

		private void populateTreeView()
		{
			treeView1.Nodes.Clear();
			loadedTabs.populateTreeView(treeView1);
		}

		public ManageTabsForm(TabConfiguration currTabs)
		{
			InitializeComponent();
			loadedTabs = currTabs;
			populateTreeView();
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

		private void buttonMergeUp_Click(object sender, EventArgs e)
		{
			TreeNode currNode = treeView1.SelectedNode;
			if (currNode != null && currNode.Index > 0)
			{
				int targetIndex = currNode.Index - 1;
				TabConfigurationTabEntry currTab = loadedTabs.tabEntries[currNode.Index];
				TabConfigurationTabEntry targetTab = loadedTabs.tabEntries[targetIndex];
				targetTab.includedGroupIDs.AddRange(currTab.includedGroupIDs);
				targetTab.includedGroupIDs.Sort();
				loadedTabs.tabEntries.Remove(currTab);
				populateTreeView();
				treeView1.SelectedNode = treeView1.Nodes[targetIndex];
			}
		}

		private void buttonMergeDown_Click(object sender, EventArgs e)
		{
			TreeNode currNode = treeView1.SelectedNode;
			if (currNode != null && currNode.Index < (treeView1.Nodes.Count - 1))
			{
				int targetIndex = currNode.Index + 1;
				TabConfigurationTabEntry currTab = loadedTabs.tabEntries[currNode.Index];
				TabConfigurationTabEntry targetTab = loadedTabs.tabEntries[targetIndex];
				targetTab.includedGroupIDs.AddRange(currTab.includedGroupIDs);
				targetTab.includedGroupIDs.Sort();
				loadedTabs.tabEntries.Remove(currTab);
				populateTreeView();
				treeView1.SelectedNode = treeView1.Nodes[targetIndex - 1];
			}
		}

		private void buttonDeleteTab_Click(object sender, EventArgs e)
		{
			TreeNode currNode = treeView1.SelectedNode;
			if (currNode != null)
			{
				loadedTabs.tabEntries.RemoveAt(currNode.Index);
				treeView1.Nodes.Remove(currNode);
			}
		}

		private void buttonDeleteAll_Click(object sender, EventArgs e)
		{
			loadedTabs.tabEntries.Clear();
			populateTreeView();
		}

		private void buttonRenameTab_Click(object sender, EventArgs e)
		{
			TreeNode selectedNode = treeView1.SelectedNode;
			if (selectedNode != null)
			{
				TextInputForm nameInputForm = new TextInputForm("" + TabConfiguration.GroupDelimiter + TabConfiguration.TabDelimiter);
				if (nameInputForm.ShowDialog() == DialogResult.OK)
				{
					loadedTabs.tabEntries[selectedNode.Index].tabName = nameInputForm.textBox1.Text;
					populateTreeView();
				}
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

		private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
		{
			TreeNode selectedNode = treeView1.SelectedNode;
			if (selectedNode != null)
			{
				buttonMoveUp.Enabled = selectedNode.Index > 0;
				buttonMergeUp.Enabled = selectedNode.Index > 0;
				buttonMoveDown.Enabled = selectedNode.Index < (treeView1.Nodes.Count - 1);
				buttonMergeDown.Enabled = selectedNode.Index < (treeView1.Nodes.Count - 1);
			}
			else
			{
				buttonMoveUp.Enabled = false;
				buttonMoveDown.Enabled = false;
				buttonMergeUp.Enabled = false;
				buttonMergeDown.Enabled = false;
				buttonDeleteTab.Enabled = false;
				buttonRenameTab.Enabled = false;
			}
		}

		
	}
}
