using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using BrawlLib.Internal.Windows.Forms.Ookii.Dialogs;



namespace BrawlSoundConverter
{
	public partial class multiSawndExportForm : Form
	{
		public static string getNameNodeGroupIDHex(TreeNode nodeIn)
		{
			string result = "";

			BrawlLib.SSBB.ResourceNodes.RSARGroupNode attachedFile = nodeIn.Tag as BrawlLib.SSBB.ResourceNodes.RSARGroupNode;
			if (attachedFile != null)
			{
				result = attachedFile.StringId.ToString("X3");
			}

			return result;
		}
		public static string getNameNodeGroupIDDec(TreeNode nodeIn)
		{
			string result = "";

			BrawlLib.SSBB.ResourceNodes.RSARGroupNode attachedFile = nodeIn.Tag as BrawlLib.SSBB.ResourceNodes.RSARGroupNode;
			if (attachedFile != null)
			{
				result = attachedFile.StringId.ToString("D3");
			}

			return result;
		}
		public static string getNameNodeGroupInfoIndexHex(TreeNode nodeIn)
		{
			string result = "";

			BrawlLib.SSBB.ResourceNodes.RSARGroupNode attachedFile = nodeIn.Tag as BrawlLib.SSBB.ResourceNodes.RSARGroupNode;
			if (attachedFile != null)
			{
				result = attachedFile.InfoIndex.ToString("X3");
			}

			return result;
		}
		public static string getNameNodeGroupInfoIndexDec(TreeNode nodeIn)
		{
			string result = "";

			BrawlLib.SSBB.ResourceNodes.RSARGroupNode attachedFile = nodeIn.Tag as BrawlLib.SSBB.ResourceNodes.RSARGroupNode;
			if (attachedFile != null)
			{
				result = attachedFile.InfoIndex.ToString("D3");
			}

			return result;
		}
		public static string getNameNodeGroupNameShort(TreeNode nodeIn)
		{
			string result = "";

			BrawlLib.SSBB.ResourceNodes.RSARGroupNode attachedFile = nodeIn.Tag as BrawlLib.SSBB.ResourceNodes.RSARGroupNode;
			if (attachedFile != null)
			{
				result = attachedFile.Name;
			}

			return result;
		}
		public static string getNameNodeGroupNameLong(TreeNode nodeIn)
		{
			string result = "";

			BrawlLib.SSBB.ResourceNodes.RSARGroupNode attachedFile = nodeIn.Tag as BrawlLib.SSBB.ResourceNodes.RSARGroupNode;
			if (attachedFile != null)
			{
				result = attachedFile.TreePath.Replace('/', '_');
			}

			return result;
		}


		public multiSawndExportForm(TreeView sourceTree)
		{
			InitializeComponent();
			brsar.LoadMultiSawndExportTreeView(treeViewGroups, sourceTree);
			buttonCancel.Enabled = true;
			treeViewGroups.CheckBoxes = true;
			switch (Properties.Settings.Default.DefaultSAWNDExportNameScheme)
			{
				case 0:
					radioButtonNameDefault.Checked = true;
					break;
				case 1:
					radioButtonNamePM.Checked = true;
					break;
				case 2:
					radioButtonNamePP.Checked = true;
					break;
				case 3:
					radioButtonNameManual.Checked = true;
					break;
				default:
					radioButtonNameDefault.Checked = true;
					break;
			}
			toolTipNameDefault.SetToolTip(radioButtonNameDefault, "Names exported files according to their appearance in the below \"Groups\" list.");
			toolTipNamePM.SetToolTip(radioButtonNamePM, "Names exported files according to their Group ID (in decimal).");
			toolTipNamePP.SetToolTip(radioButtonNamePP, "Names exported files according to their Internal ID (Group ID minus 7, in hexadecimal).");
			toolTipNameManual.SetToolTip(radioButtonNameManual, "Presents a menu in which you may specify the filenames to be used by each selected group.");

			setNumCheckedText();
		}

		private uint numTreeNodesChecked()
		{
			uint numChecked = 0;
			foreach (TreeNode currNode in treeViewGroups.Nodes)
			{
				if (currNode.Checked)
				{
					numChecked++;
				}
			}
			return numChecked;
		}
		private void setNumCheckedText()
		{
			label2.Text = "Groups (" + numTreeNodesChecked().ToString() + " out of " + treeViewGroups.Nodes.Count.ToString() + " checked)";
		}

		private void buttonBrowse_Click(object sender, EventArgs e)
		{
			VistaFolderBrowserDialog fbd = new VistaFolderBrowserDialog();
			if (fbd.ShowDialog() == DialogResult.OK)
			{
				textBoxExportDirectory.Text = fbd.SelectedPath;
				buttonSelectAll.Enabled = true;
				buttonDeselectAll.Enabled = true;
				buttonInvertSelection.Enabled = true;
			} 
		}
		private void buttonExport_Click(object sender, EventArgs e)
		{
			bool doExport = true;
			if (textBoxExportDirectory.Text.Length > 0)
			{
				StreamWriter exportList = File.CreateText("toExport.txt");
				if (radioButtonNamePM.Checked)
				{
					foreach (MappingItem item in treeViewGroups.Nodes)
					{
						if (item.Checked)
						{
							exportList.WriteLine("\"" + item.groupID.ToString("D3") + ".sawnd" + "\" = " + item.groupID.ToString());
						}
					}
				}
				else if (radioButtonNamePP.Checked)
				{
					foreach (MappingItem item in treeViewGroups.Nodes)
					{
						if (item.Checked)
						{
							exportList.WriteLine("\"" + item.infoIndex.ToString("X3") + ".sawnd" + "\" = " + item.groupID.ToString());
						}
					}
				}
				else if (radioButtonNameManual.Checked)
				{
					string initialBaseString = "";
					if (Properties.Settings.Default.EnableFullLengthNames)
					{
						initialBaseString = "[${GRP_ID_HEX}] ${GRP_NAME_L}.sawnd";
					}
					else
					{
						initialBaseString = "[${GRP_ID_HEX}] ${GRP_NAME_S}.sawnd";
					}
					NamingSchemeStruct wildCardStruct = new NamingSchemeStruct(initialBaseString);
					wildCardStruct.blacklistedChars = NamingSchemeBlacklists.IllegalFilepathCharacters;
					wildCardStruct.wildCards.Add("Group ID (Hex)", new NamingSchemeWildcardEntry("${GRP_ID_HEX}", getNameNodeGroupIDHex));
					wildCardStruct.wildCards.Add("Group ID (Dec)", new NamingSchemeWildcardEntry("${GRP_ID_DEC}", getNameNodeGroupIDDec));
					wildCardStruct.wildCards.Add("Group Info Index (Hex)", new NamingSchemeWildcardEntry("${GRP_INFO_ID_HEX}", getNameNodeGroupInfoIndexHex));
					wildCardStruct.wildCards.Add("Group Info Index (Dec)", new NamingSchemeWildcardEntry("${GRP_INFO_ID_DEC}", getNameNodeGroupInfoIndexDec));
					wildCardStruct.wildCards.Add("Group Name (Short)", new NamingSchemeWildcardEntry("${GRP_NAME_S}", getNameNodeGroupNameShort));
					wildCardStruct.wildCards.Add("Group Name (Long)", new NamingSchemeWildcardEntry("${GRP_NAME_L}", getNameNodeGroupNameLong));

					nameInputForm nif = new nameInputForm(wildCardStruct);
					foreach (MappingItem item in treeViewGroups.Nodes)
					{
						if (item.Checked)
						{
							TreeNode currNode = nif.treeViewNames.Nodes.Add(item.ToString());
							currNode.Text += ".sawnd";
							currNode.Tag = brsar.GetNode(item.groupID) as BrawlLib.SSBB.ResourceNodes.RSARGroupNode;
						}
					}
					nif.applyBaseString();
					if (nif.ShowDialog() == DialogResult.OK)
					{
						foreach (TreeNode item in nif.treeViewNames.Nodes)
						{
							exportList.WriteLine("\"" + item.Text + "\" = " + (item.Tag as BrawlLib.SSBB.ResourceNodes.RSARGroupNode).StringId.ToString());
						}
					}
					else
					{
						doExport = false;
					}
				}
				else
				{
					foreach (MappingItem item in treeViewGroups.Nodes)
					{
						if (item.Checked)
						{
							exportList.WriteLine("\"" + NamingSchemeBlacklists.scrubString(item.name, NamingSchemeBlacklists.IllegalFilepathCharacters) + ".sawnd" + "\" = " + item.groupID.ToString());
						}
					}
				}
				exportList.Close();
				if (doExport)
				{
					Sawndz.multiCreateSawnd(textBoxExportDirectory.Text);
					DialogResult = DialogResult.OK;
					this.Close();
				}
			}
		}
		private void buttonSelectAll_Click(object sender, EventArgs e)
		{
			treeViewGroups.SuspendLayout();
			treeViewGroups.AfterCheck -= treeViewGroups_AfterCheck;
			foreach (TreeNode group in treeViewGroups.Nodes)
			{
				group.Checked = true;
			}
			treeViewGroups.AfterCheck += treeViewGroups_AfterCheck;
			treeViewGroups.ResumeLayout();
			handleCheckUIUpdates();
		}
		private void buttonDeselectAll_Click(object sender, EventArgs e)
		{
			treeViewGroups.SuspendLayout();
			treeViewGroups.AfterCheck -= treeViewGroups_AfterCheck;
			foreach (TreeNode group in treeViewGroups.Nodes)
			{
				group.Checked = false;
			}
			treeViewGroups.AfterCheck += treeViewGroups_AfterCheck;
			treeViewGroups.ResumeLayout();
			handleCheckUIUpdates();
		}
		private void buttonInvertSelection_Click(object sender, EventArgs e)
		{
			treeViewGroups.SuspendLayout();
			treeViewGroups.AfterCheck -= treeViewGroups_AfterCheck;
			foreach (TreeNode group in treeViewGroups.Nodes)
			{
				group.Checked = !group.Checked;
			}
			treeViewGroups.AfterCheck += treeViewGroups_AfterCheck;
			treeViewGroups.ResumeLayout();
			handleCheckUIUpdates();
		}

		private void handleCheckUIUpdates()
		{
			if (textBoxExportDirectory.Text.Length > 0)
			{
				if (numTreeNodesChecked() > 0)
				{
					buttonExport.Enabled = true;
				}
				else
				{
					buttonExport.Enabled = false;
				}
			}
			else
			{
				buttonExport.Enabled = false;
			}
			setNumCheckedText();
		}
		private void treeViewGroups_AfterCheck(object sender, TreeViewEventArgs e)
		{
			handleCheckUIUpdates();
		}
		private void treeViewGroups_KeyDown(object sender, KeyEventArgs e)
		{
			TreeNode currNode = treeViewGroups.SelectedNode;
			if (currNode != null && e.KeyCode == Keys.Enter)
			{
				currNode.Checked = !currNode.Checked;
				e.SuppressKeyPress = true;
			}
		}
		private void treeViewGroups_DoubleClick(object sender, EventArgs e)
		{
			TreeNode currNode = treeViewGroups.SelectedNode;
			if (currNode != null)
			{
				currNode.Checked = !currNode.Checked;
			}
		}

		private void buttonCancel_Click(object sender, EventArgs e)
		{
			DialogResult = DialogResult.Cancel;
			Close();
		}

		private void textBoxExportDirectory_TextChanged(object sender, EventArgs e)
		{
			if (numTreeNodesChecked() > 0)
			{
				buttonExport.Enabled = true;
			}
		}
	}
}
