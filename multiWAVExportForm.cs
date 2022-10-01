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
	public partial class multiWAVExportForm : Form
	{
		int _targetGroupID;
		int _targetCollectionID;
		string selectedFolder;
		string groupName;

		public multiWAVExportForm(int targetGroupID, int targetFileID)
		{
			InitializeComponent();
			_targetGroupID = targetGroupID;
			_targetCollectionID = targetFileID;
			selectedFolder = "";
			brsar.LoadMultiWAVExportTreeView(treeViewAudio, targetGroupID, targetFileID);
			brsar.LoadMultiWAVExportInfoTreeView(treeViewSoundInfo, targetGroupID, targetFileID);

			audioPlaybackPanel1.VolumePercent = 0.66;
			BrawlLib.SSBB.ResourceNodes.RSARGroupNode targetGroup = brsar.GetNode(targetGroupID) as BrawlLib.SSBB.ResourceNodes.RSARGroupNode;
			if (Properties.Settings.Default.EnableFullLengthNames)
			{
				groupName = NamingSchemeBlacklists.scrubString(targetGroup.TreePath.Replace('/', '_'), NamingSchemeBlacklists.IllegalFilepathCharacters);
			}
			else
			{
				groupName = NamingSchemeBlacklists.scrubString(targetGroup.Name, NamingSchemeBlacklists.IllegalFilepathCharacters);
			}
			labelFileLabel.Text = "Sounds in Collection 0x" + targetFileID.ToString("X3") + " from Group 0x" + targetGroupID.ToString("X3") + " (\"" + groupName + "\"):";
			buttonCancel.Enabled = true;
			treeViewAudio.CheckBoxes = true;
			checkBox1.Checked = Properties.Settings.Default.DefaultMultiWAVExportCreateGroupDirectory;

			setNumCheckedText();
		}

		private void setTextBox(string folderIn)
		{
			selectedFolder = folderIn;
			if (checkBox1.Checked)
			{
				textBoxExportDirectory.Text = folderIn + "\\" + groupName;
			}
			else
			{
				textBoxExportDirectory.Text = folderIn;
			}
		}

		private uint numTreeNodesChecked()
		{
			uint numChecked = 0;
			foreach (TreeNode currNode in treeViewAudio.Nodes)
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
			label2.Text = "WAVs (" + numTreeNodesChecked().ToString() + " out of " + treeViewAudio.Nodes.Count.ToString() + " checked)";
		}

		private void buttonBrowse_Click(object sender, EventArgs e)
		{
			VistaFolderBrowserDialog fbd = new VistaFolderBrowserDialog();
			if (fbd.ShowDialog() == DialogResult.OK)
			{
				setTextBox(fbd.SelectedPath);
				buttonSelectAll.Enabled = true;
				buttonDeselectAll.Enabled = true;
				buttonInvertSelection.Enabled = true;
			} 
		}
		private void buttonExport_Click(object sender, EventArgs e)
		{
			if (textBoxExportDirectory.Text.Length > 0)
			{
				if (checkBox1.Checked)
				{
					Directory.CreateDirectory(textBoxExportDirectory.Text);
				}

				string exportDirectory = textBoxExportDirectory.Text + "\\";
				string mapFilename = "Audio[" + _targetGroupID.ToString("D3") + "_" + _targetCollectionID.ToString("D3") + "]_Map.xml";
				List<int> exportedIndeces = new List<int>();
				foreach (MappingItem waveEntry in treeViewAudio.Nodes)
				{
					if (!waveEntry.Checked)
						continue;
					string exportFilename = "Audio[" + waveEntry.groupID.ToString("D3") + "_" + waveEntry.collectionID.ToString("D3") + "_" + waveEntry.wavID.ToString("D3") + "].wav";
					if (Sawndz.createWAV(waveEntry.groupID, waveEntry.collectionID, waveEntry.wavID, textBoxExportDirectory.Text + "\\" + exportFilename))
					{
						exportedIndeces.Add(waveEntry.wavID);
					}
				}
				if (Sawndz.createWAVEMap(exportDirectory + mapFilename, _targetGroupID, _targetCollectionID, exportedIndeces, true))
				{
					Console.WriteLine("Successfully built Wave Map (\"" + mapFilename + "\").");
					Console.WriteLine("Use it with the Multi Insert WAV button to re-import the sounds you just exported.");
				}
			}
			DialogResult = DialogResult.OK;
			Close();
		}
		private void buttonSelectAll_Click(object sender, EventArgs e)
		{
			treeViewAudio.SuspendLayout();
			treeViewAudio.AfterCheck -= treeViewAudio_AfterCheck;
			foreach (TreeNode group in treeViewAudio.Nodes)
			{
				group.Checked = true;
			}
			treeViewAudio.AfterCheck += treeViewAudio_AfterCheck;
			treeViewAudio.ResumeLayout();
			handleCheckUIUpdates();
		}
		private void buttonDeselectAll_Click(object sender, EventArgs e)
		{
			treeViewAudio.SuspendLayout();
			treeViewAudio.AfterCheck -= treeViewAudio_AfterCheck;
			foreach (TreeNode group in treeViewAudio.Nodes)
			{
				group.Checked = false;
			}
			treeViewAudio.AfterCheck += treeViewAudio_AfterCheck;
			treeViewAudio.ResumeLayout();
			handleCheckUIUpdates();
		}
		private void buttonInvertSelection_Click(object sender, EventArgs e)
		{
			treeViewAudio.SuspendLayout();
			treeViewAudio.AfterCheck -= treeViewAudio_AfterCheck;
			foreach (TreeNode group in treeViewAudio.Nodes)
			{
				group.Checked = !group.Checked;
			}
			treeViewAudio.AfterCheck += treeViewAudio_AfterCheck;
			treeViewAudio.ResumeLayout();
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
		private void treeViewAudio_AfterCheck(object sender, TreeViewEventArgs e)
		{
			handleCheckUIUpdates();
		}
		private void treeViewAudio_KeyDown(object sender, KeyEventArgs e)
		{
			TreeNode currNode = treeViewAudio.SelectedNode;
			if (currNode != null && e.KeyCode == Keys.Enter)
			{
				currNode.Checked = !currNode.Checked;
				e.SuppressKeyPress = true;
			}
		}
		private void treeViewAudio_DoubleClick(object sender, EventArgs e)
		{
			TreeNode currNode = treeViewAudio.SelectedNode;
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
			checkBox1.Enabled = true;
		}

		private void treeView1_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
		{
			int referencedWAVEID = (e.Node as MappingItem).wavID;
			treeViewAudio.SelectedNode = null;
			treeViewAudio.SelectedNode = treeViewAudio.Nodes[referencedWAVEID];
			treeViewAudio.Focus();
		}

		private void treeViewSoundInfo_KeyDown(object sender, KeyEventArgs e)
		{
			TreeNode currNode = treeViewSoundInfo.SelectedNode;
			if (currNode != null && e.KeyCode == Keys.Enter)
			{
				int referencedWAVEID = (currNode as MappingItem).wavID;
				treeViewAudio.SelectedNode = null;
				treeViewAudio.SelectedNode = treeViewAudio.Nodes[referencedWAVEID];
				treeViewAudio.Focus();
				e.SuppressKeyPress = true;
			}
		}
		private void treeViewAudio_AfterSelect(object sender, TreeViewEventArgs e)
		{
			audioPlaybackPanel1.TargetSource = null;
			MappingItem item = e.Node as MappingItem;
			if (item == null)
				return;
			if (item.wavID > -1)
			{
				audioPlaybackPanel1.TargetSource = item as BrawlLib.Internal.Audio.IAudioSource;
				audioPlaybackPanel1.TargetSource.CreateStreams();
				audioPlaybackPanel1.Play();
			}
		}

		private void checkBox1_CheckedChanged(object sender, EventArgs e)
		{
			if (checkBox1.Enabled)
			{
				setTextBox(selectedFolder);
			}
		}

		private void multiWAVExportForm_FormClosed(object sender, FormClosedEventArgs e)
		{
			audioPlaybackPanel1.TargetSource = null;
		}
	}
}
