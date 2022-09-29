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

		private void buildCollectionView()
		{
			treeViewCollections.Nodes.Clear();
			treeViewSounds.Nodes.Clear();
			treeViewCollectionDetails.Nodes.Clear();
			currSelectedFile = null;
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

				string displayString = "[" + file.FileNodeIndex.ToString("X3") + "] " + file.ResourceFileType + " - in \"[" + file.GroupRefNodes[0].StringId.ToString("X3") + "] " + file.GroupRefNodes[0].TreePath.Replace('/', '_') + "\"";

				List<int> usedStringIDs = new List<int> { file.GroupRefNodes[0].StringId };
				for (int i = 1; i < file.GroupRefNodes.Length; i++)
				{
					BrawlLib.SSBB.ResourceNodes.RSARGroupNode group = file.GroupRefNodes[i];
					if (usedStringIDs.Contains(group.StringId))
						continue;
					usedStringIDs.Add(group.StringId);
				}

				if (usedStringIDs.Count > 1)
				{
					displayString += " and " + (usedStringIDs.Count - 1).ToString() + " other(s)" ;
				}

				TreeNode newNode = new TreeNode(displayString);
				newNode.Tag = file._fileIndex;
				treeViewCollections.Nodes.Add(newNode);
			}
		}

		public multiCollectionExportForm()
		{
			InitializeComponent();
			currRSAR = brsar.GetRSAR();

			checkBox1.Checked = true;
			checkBox2.Checked = true;
			checkBox3.Checked = true;

			buildCollectionView();

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
				foreach (TreeNode collection in treeViewCollections.Nodes)
				{
					if (collection.Checked)
					{
						BrawlLib.SSBB.ResourceNodes.RSARFileNode targetFile = currRSAR.Files[(int)collection.Tag];
						string exportName = targetFile.TreePath.Replace('/', '_').Replace("<", "").Replace(">", "");
						exportName += ".b" + targetFile.ResourceFileType.ToString().ToLower();
						targetFile.Export(textBoxExportDirectory.Text + "\\" + exportName);
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
			currSelectedFile = currRSAR.Files[(int)treeViewCollections.SelectedNode.Tag];

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
			buildCollectionView();
		}

		private void checkBox2_CheckedChanged(object sender, EventArgs e)
		{
			buildCollectionView();
		}

		private void checkBox3_CheckedChanged(object sender, EventArgs e)
		{
			buildCollectionView();
		}
	}
}
