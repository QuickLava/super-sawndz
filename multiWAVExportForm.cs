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

		public multiWAVExportForm(int targetGroupID, int targetFileID)
		{
			InitializeComponent();
			_targetGroupID = targetGroupID;
			_targetCollectionID = targetFileID;
			brsar.LoadMultiWAVExportTreeView(treeViewAudio, targetGroupID, targetFileID);
			brsar.LoadMultiWAVExportInfoTreeView(treeViewSoundInfo, targetGroupID, targetFileID);

			audioPlaybackPanel1.VolumePercent = 0.66;
			BrawlLib.SSBB.ResourceNodes.RSARGroupNode targetGroup = brsar.GetNode(targetGroupID) as BrawlLib.SSBB.ResourceNodes.RSARGroupNode;
			labelFileLabel.Text = "Sounds in Collection #" + targetFileID.ToString("X3") + " from Group #" + targetGroupID.ToString("X3") + " (\"" + targetGroup.Name + "\"):";
			buttonCancel.Enabled = true;
			treeViewAudio.CheckBoxes = true;
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
			if (textBoxExportDirectory.Text.Length > 0)
			{
				string exportDirectory = textBoxExportDirectory.Text + "\\";
				string mapFilename = "Audio[" + _targetGroupID.ToString("D3") + "_" + _targetCollectionID.ToString("D3") + "]_Map.xml";
				System.Xml.XmlWriterSettings exportMapSettings = new System.Xml.XmlWriterSettings();
				exportMapSettings.Indent = true;
				exportMapSettings.IndentChars = "\t";
				System.Xml.XmlWriter exportMap = System.Xml.XmlWriter.Create(exportDirectory + mapFilename, exportMapSettings);
				exportMap.WriteStartElement("superSawndzWAVEMap");
				exportMap.WriteAttributeString("version", Properties.Resources.Version);
				exportMap.WriteAttributeString("targetGroup", _targetGroupID.ToString("D3"));
				exportMap.WriteAttributeString("targetCollection", _targetCollectionID.ToString("D3"));
				foreach (MappingItem waveEntry in treeViewAudio.Nodes)
				{
					if (!waveEntry.Checked)
						continue;
					string exportFilename = "Audio[" + waveEntry.groupID.ToString("D3") + "_" + waveEntry.collectionID.ToString("D3") + "_" + waveEntry.wavID.ToString("D3") + "].wav";
					if (Sawndz.createWAV(waveEntry.groupID, waveEntry.collectionID, waveEntry.wavID, textBoxExportDirectory.Text + "\\" + exportFilename))
					{
						string elementName = "Audio_" + waveEntry.groupID.ToString("D3") + "_" + waveEntry.collectionID.ToString("D3") + "_" + waveEntry.wavID.ToString("D3");
						exportMap.WriteStartElement("wave");
						exportMap.WriteAttributeString("name", elementName);
						exportMap.WriteStartElement("filename");
						exportMap.WriteAttributeString("val", exportFilename);
						exportMap.WriteEndElement();
						exportMap.WriteStartElement("wavID");
						exportMap.WriteAttributeString("val", waveEntry.wavID.ToString("D3"));
						exportMap.WriteEndElement();
						exportMap.WriteEndElement();
					}
				}
				exportMap.WriteEndElement();
				exportMap.Close();
			}
			DialogResult = DialogResult.OK;
			Close();
		}
		private void buttonSelectAll_Click(object sender, EventArgs e)
		{
			foreach (TreeNode group in treeViewAudio.Nodes)
			{
				group.Checked = true;
			}
		}
		private void buttonDeselectAll_Click(object sender, EventArgs e)
		{
			foreach (TreeNode group in treeViewAudio.Nodes)
			{
				group.Checked = false;
			}
		}
		private void buttonInvertSelection_Click(object sender, EventArgs e)
		{
			foreach (TreeNode group in treeViewAudio.Nodes)
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
	}
}
