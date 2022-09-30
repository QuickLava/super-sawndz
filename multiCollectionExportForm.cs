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
	public partial class multiCollectionExportForm : Form
	{
		BrawlLib.SSBB.ResourceNodes.RSARNode currRSAR = null;
		BrawlLib.SSBB.ResourceNodes.RSARFileNode currSelectedFile = null;
		List<BrawlLib.SSBB.ResourceNodes.RSARFileNode> fileList = new List<BrawlLib.SSBB.ResourceNodes.RSARFileNode>();

		public static int compareFilesByFirstParentGroupName(BrawlLib.SSBB.ResourceNodes.RSARFileNode x, BrawlLib.SSBB.ResourceNodes.RSARFileNode y)
		{
			int result = 0;
			if (x == null)
			{
				if (y == null)
				{
					result = 0;
				}
				else
				{
					result = -1;
				}
			}
			else
			{
				if (y == null)
				{
					result = 1;
				}
				else
				{
					result = x.GroupRefNodes[0].Name.CompareTo(y.GroupRefNodes[0].Name);
				}
			}
			return result;
		}
		public static int compareFilesByFirstParentGroupID(BrawlLib.SSBB.ResourceNodes.RSARFileNode x, BrawlLib.SSBB.ResourceNodes.RSARFileNode y)
		{
			int result = 0;
			if (x == null)
			{
				if (y == null)
				{
					result = 0;
				}
				else
				{
					result = -1;
				}
			}
			else
			{
				if (y == null)
				{
					result = 1;
				}
				else
				{
					int xCompVal = (x.GroupRefNodes[0].StringId < 0) ? int.MaxValue : x.GroupRefNodes[0].StringId;
					int yCompVal = (y.GroupRefNodes[0].StringId < 0) ? int.MaxValue : y.GroupRefNodes[0].StringId;
					result = xCompVal.CompareTo(yCompVal);
				}
			}
			return result;
		}
		public static int compareFilesByFileID(BrawlLib.SSBB.ResourceNodes.RSARFileNode x, BrawlLib.SSBB.ResourceNodes.RSARFileNode y)
		{
			int result = 0;
			if (x == null)
			{
				if (y == null)
				{
					result = 0;
				}
				else
				{
					result = -1;
				}
			}
			else
			{
				if (y == null)
				{
					result = 1;
				}
				else
				{
					int xCompVal = (x.FileNodeIndex < 0) ? int.MaxValue : x.FileNodeIndex;
					int yCompVal = (y.FileNodeIndex < 0) ? int.MaxValue : y.FileNodeIndex;
					result = xCompVal.CompareTo(yCompVal);
				}
			}
			return result;
		}

		private void buildCollectionView(bool refreshFileList)
		{
			treeViewCollections.Nodes.Clear();
			treeViewSounds.Nodes.Clear();
			treeViewCollectionDetails.Nodes.Clear();
			currSelectedFile = null;
			buttonExport.Enabled = false;
			audioPlaybackPanel1.TargetSource = null;

			if (refreshFileList)
			{
				fileList.Clear();
				foreach (BrawlLib.SSBB.ResourceNodes.RSARFileNode file in currRSAR.Files)
				{
					if (file.GroupRefNodes.Length == 0 || Convert.ToInt32(file.DataOffset, 16) == 0x00)
						continue;
					switch (file.ResourceFileType)
					{
						case BrawlLib.SSBB.ResourceNodes.ResourceType.RWSD:
							{
								if (!checkBox1.Checked)
									continue;
								break;
							}
						case BrawlLib.SSBB.ResourceNodes.ResourceType.RBNK:
							{
								if (!checkBox2.Checked)
									continue;
								break;
							}
						case BrawlLib.SSBB.ResourceNodes.ResourceType.RSEQ:
							{
								if (!checkBox3.Checked)
									continue;
								break;
							}
						default:
							{
								continue;
								break;
							}
					}

					fileList.Add(file);
				}
			}

			switch (comboBoxSortMode.SelectedIndex % 3)
			{
				case 0:
					{
						if (!refreshFileList)
						{
							fileList.Sort(compareFilesByFileID);
						}
						break;
					}
				case 1:
					{
						fileList.Sort(compareFilesByFirstParentGroupID);
						break;
					}
				case 2:
					{
						fileList.Sort(compareFilesByFirstParentGroupName);
						break;
					}
				default:
					break;
			}

			if (comboBoxSortMode.SelectedIndex > 2)
			{
				fileList.Reverse();
			}

			for (int i = 0; i < fileList.Count; i++)
			{
				BrawlLib.SSBB.ResourceNodes.RSARFileNode file = fileList[i];

				string displayString = "[" + file.FileNodeIndex.ToString("X3") + "] " + file.ResourceFileType + " - in \"[" + file.GroupRefNodes[0].StringId.ToString("X3") + "] " + file.GroupRefNodes[0].TreePath.Replace('/', '_') + "\"";
				List<int> usedStringIDs = new List<int> { file.GroupRefNodes[0].StringId };
				for (int u = 1; u < file.GroupRefNodes.Length; u++)
				{
					BrawlLib.SSBB.ResourceNodes.RSARGroupNode group = file.GroupRefNodes[u];
					if (usedStringIDs.Contains(group.StringId))
						continue;
					usedStringIDs.Add(group.StringId);
				}
				if (usedStringIDs.Count > 1)
				{
					displayString += " and " + (usedStringIDs.Count - 1).ToString() + " other(s)";
				}

				TreeNode newNode = new TreeNode(displayString);
				newNode.Tag = i;
				treeViewCollections.Nodes.Add(newNode);
			}

			setNumCheckedText();
		}

		public multiCollectionExportForm()
		{
			InitializeComponent();
			currRSAR = brsar.GetRSAR();

			checkBox1.Checked = true;
			checkBox2.Checked = true;
			checkBox3.Checked = true;
			comboBoxSortMode.SelectedIndex = 0;

			radioButtonNameDefault.Checked = true;

			buildCollectionView(true);

			buttonCancel.Enabled = true;
		}

		private uint numTreeNodesChecked()
		{
			uint numChecked = 0;
			foreach (TreeNode currNode in treeViewCollections.Nodes)
			{
				if (currNode.Checked)
				{
					numChecked++;
				}
			}
			return numChecked;
		}

		private void setExportButtonState()
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
		private void setNumCheckedText()
		{
			label2.Text = "Collections (" + numTreeNodesChecked().ToString() + " out of " + treeViewCollections.Nodes.Count.ToString() + " checked)";
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
				if (radioButtonNameManual.Checked)
				{
					nameInputForm nif = new nameInputForm();
					foreach (TreeNode item in treeViewCollections.Nodes)
					{
						if (item.Checked)
						{
							BrawlLib.SSBB.ResourceNodes.RSARFileNode targetFile = fileList[(int)item.Tag];
							TreeNode currNode = nif.treeViewNames.Nodes.Add(targetFile.GroupRefNodes[0].TreePath.Replace('/', '_').Replace("<", "").Replace(">", ""));
							currNode.Text += ".b" + targetFile.ResourceFileType.ToString().ToLower();
							currNode.Tag = item.Tag;
						}
					}
					if (nif.ShowDialog() == DialogResult.OK)
					{
						foreach (TreeNode item in nif.treeViewNames.Nodes)
						{
							BrawlLib.SSBB.ResourceNodes.RSARFileNode targetFile = fileList[(int)item.Tag];
							string exportName = item.Text;
							targetFile.Export(textBoxExportDirectory.Text + "\\" + exportName);
						}
					}
				}
				else
				{
					foreach (TreeNode collection in treeViewCollections.Nodes)
					{
						if (collection.Checked)
						{
							BrawlLib.SSBB.ResourceNodes.RSARFileNode targetFile = fileList[(int)collection.Tag];
							string exportName = "";
							if (radioButtonNameDecimalID.Checked)
							{
								exportName = targetFile.FileNodeIndex.ToString("D3");
							}
							else if (radioButtonNameHexID.Checked)
							{
								exportName = targetFile.FileNodeIndex.ToString("X3");
							}
							else
							{
								exportName = targetFile.TreePath.Replace('/', '_').Replace("<", "").Replace(">", "");
							}
							exportName += ".b" + targetFile.ResourceFileType.ToString().ToLower();
							targetFile.Export(textBoxExportDirectory.Text + "\\" + exportName);
						}
					}
				}
			}

			DialogResult = DialogResult.OK;
			Close();
		}
		private void buttonSelectAll_Click(object sender, EventArgs e)
		{
			foreach (TreeNode group in treeViewCollections.Nodes)
			{
				group.Checked = true;
			}
		}
		private void buttonDeselectAll_Click(object sender, EventArgs e)
		{
			foreach (TreeNode group in treeViewCollections.Nodes)
			{
				group.Checked = false;
			}
		}
		private void buttonInvertSelection_Click(object sender, EventArgs e)
		{
			foreach (TreeNode group in treeViewCollections.Nodes)
			{
				group.Checked = !group.Checked;
			}
		}

		private void treeViewGroups_AfterCheck(object sender, TreeViewEventArgs e)
		{
			setExportButtonState();
			setNumCheckedText();
		}
		private void treeViewCollections_KeyDown(object sender, KeyEventArgs e)
		{
			TreeNode currNode = treeViewCollections.SelectedNode;
			if (currNode != null && e.KeyCode == Keys.Enter)
			{
				currNode.Checked = !currNode.Checked;
				e.SuppressKeyPress = true;
			}
		}
		private void treeViewGroups_DoubleClick(object sender, EventArgs e)
		{
			TreeNode currNode = treeViewCollections.SelectedNode;
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

		private void treeViewCollections_AfterSelect(object sender, TreeViewEventArgs e)
		{
			currSelectedFile = fileList[(int)treeViewCollections.SelectedNode.Tag];

			treeViewSounds.Nodes.Clear();
			brsar.CollectSoundNodesFromSubfile(currSelectedFile.GroupRefNodes[0].StringId, currSelectedFile.FileNodeIndex, treeViewSounds.Nodes);
			treeViewSounds.SelectedNode = null;
			audioPlaybackPanel1.TargetSource = null;

			treeViewCollectionDetails.Nodes.Clear();

			TreeNode usedInNode = new TreeNode("Used in ") ;
			List<int> usedStringIDs = new List<int>();
			for (int i = 0; i < currSelectedFile.GroupRefNodes.Length; i++)
			{
				BrawlLib.SSBB.ResourceNodes.RSARGroupNode group = currSelectedFile.GroupRefNodes[i];
				if (usedStringIDs.Contains(group.StringId))
					continue;
				usedStringIDs.Add(group.StringId);
				usedInNode.Nodes.Add(new TreeNode("[" + group.StringId.ToString("X3") + "] " + group.TreePath.Replace('/', '_')));
			}
			usedInNode.Text += usedStringIDs.Count.ToString() + " group(s)";
			treeViewCollectionDetails.Nodes.Add(usedInNode);
			usedInNode.Expand();

			treeViewCollectionDetails.Nodes.Add(new TreeNode("Uncompressed Size (Bytes, Dec.): " + currSelectedFile.UncompressedSize.ToString()));
			treeViewCollectionDetails.Nodes.Add(new TreeNode("Data Length (Bytes, Hex.): " + currSelectedFile.DataLength));
			treeViewCollectionDetails.Nodes.Add(new TreeNode("Data Offset: 0x" + currSelectedFile.DataOffset));
			treeViewCollectionDetails.Nodes.Add(new TreeNode("Audio Length (Bytes, Hex.): " + currSelectedFile.AudioLength));
			treeViewCollectionDetails.Nodes.Add(new TreeNode("Audio Offset: 0x" + currSelectedFile.AudioOffset));
		}

		private void treeViewSounds_AfterSelect(object sender, TreeViewEventArgs e)
		{
			audioPlaybackPanel1.TargetSource = treeViewSounds.SelectedNode as BrawlLib.Internal.Audio.IAudioSource;
			audioPlaybackPanel1.TargetSource.CreateStreams();
			audioPlaybackPanel1.Play();
		}

		private void checkBox1_CheckedChanged(object sender, EventArgs e)
		{
			buildCollectionView(true);
		}
		private void checkBox2_CheckedChanged(object sender, EventArgs e)
		{
			buildCollectionView(true);
		}
		private void checkBox3_CheckedChanged(object sender, EventArgs e)
		{
			buildCollectionView(true);
		}

		private void comboBoxSortMode_SelectedIndexChanged(object sender, EventArgs e)
		{
			buildCollectionView(false);
		}
	}
}
