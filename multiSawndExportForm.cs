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
					nameInputForm nif = new nameInputForm();
					foreach (MappingItem item in treeViewGroups.Nodes)
					{
						if (item.Checked)
						{
							TreeNode currNode = nif.treeViewNames.Nodes.Add(item.ToString());
							currNode.Text += ".sawnd";
							currNode.Tag = item.groupID.ToString();
						}
					}
					if (nif.ShowDialog() == DialogResult.OK)
					{
						foreach (TreeNode item in nif.treeViewNames.Nodes)
						{
							exportList.WriteLine("\"" + item.Text + "\" = " + item.Tag);
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
							exportList.WriteLine("\"" + item.name + ".sawnd" + "\" = " + item.groupID.ToString());
						}
					}
				}
				exportList.Close();
				if (doExport)
				{
					Sawndz.multiCreateSawnd(textBoxExportDirectory.Text);
					this.Close();
				}
			}
		}
		private void buttonSelectAll_Click(object sender, EventArgs e)
		{
			foreach (TreeNode group in treeViewGroups.Nodes)
			{
				group.Checked = true;
			}
		}
		private void buttonDeselectAll_Click(object sender, EventArgs e)
		{
			foreach (TreeNode group in treeViewGroups.Nodes)
			{
				group.Checked = false;
			}
		}
		private void buttonInvertSelection_Click(object sender, EventArgs e)
		{
			foreach (TreeNode group in treeViewGroups.Nodes)
			{
				group.Checked = !group.Checked;
			}
		}

		private void treeViewGroups_AfterCheck(object sender, TreeViewEventArgs e)
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
