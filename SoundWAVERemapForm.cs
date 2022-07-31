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
	public partial class SoundWAVERemapForm : Form
	{
		int groupID, fileID;
		BrawlLib.SSBB.ResourceNodes.RWSDDataNode sourceNode;
		BrawlLib.SSBB.ResourceNodes.RSARFileNode sourceFile;
		public bool initSuccessful = false;
		public SoundWAVERemapForm(int groupIDIn, int fileIDIn, int infoIndex)
		{
			InitializeComponent();
			groupID = groupIDIn;
			fileID = fileIDIn;
			sourceNode = brsar.GetRWSDDataNode(groupID, fileID, infoIndex);
			sourceFile = brsar.GetNode(groupID, fileID) as BrawlLib.SSBB.ResourceNodes.RSARFileNode;
			if (sourceNode != null && sourceFile != null)
			{
				brsar.LoadMultiWAVExportTreeView(treeView1, groupID, fileID);
				if (treeView1.Nodes.Count > 0)
				{
					initSuccessful = true;
					textBox1.Text = sourceNode.Name;

					label9.Text = "WAVE Entries in Collection 0x" + fileID.ToString("X3") + ":";

					numericUpDownWAVID.Value = sourceNode.Sound.Index;
					numericUpDownWAVID.Minimum = 0;
					numericUpDownWAVID.Maximum = treeView1.Nodes.Count - 1;
				}
			}
		}

		private void button1_Click(object sender, EventArgs e)
		{
		 	BrawlLib.SSBB.ResourceNodes.RSARFileAudioNode temp =  brsar.GetNode(groupID, fileID, ((int)numericUpDownWAVID.Value)) as BrawlLib.SSBB.ResourceNodes.RSARFileAudioNode;
			if (temp != null)
			{
				sourceNode.Wave = temp.Name;
			}
			DialogResult = DialogResult.OK;
			Close();
		}

		private void button2_Click(object sender, EventArgs e)
		{
			DialogResult = DialogResult.Cancel;
			Close();
		}

		private void button3_Click(object sender, EventArgs e)
		{
			MappingItem item = treeView1.SelectedNode as MappingItem;
			if (item != null)
			{
				numericUpDownWAVID.Value = item.Index;
			}
		}

		private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
		{
			MappingItem item = treeView1.SelectedNode as MappingItem;
			if (item != null)
			{
				audioPlaybackPanel1.TargetSource = item as BrawlLib.Internal.Audio.IAudioSource;
				audioPlaybackPanel1.TargetSource.CreateStreams();
				audioPlaybackPanel1.Play();
			}
		}

		private void numericUpDownWAVID_ValueChanged(object sender, EventArgs e)
		{
			treeView1.SelectedNode = treeView1.Nodes[((int)numericUpDownWAVID.Value)];
		}

		private void treeView1_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Enter && treeView1.SelectedNode != null)
			{
				numericUpDownWAVID.Value = treeView1.SelectedNode.Index;
				audioPlaybackPanel1.Play();
				e.SuppressKeyPress = true;
			}
		}

		private void treeView1_DoubleClick(object sender, EventArgs e)
		{
			if (treeView1.SelectedNode != null)
			{
				numericUpDownWAVID.Value = treeView1.SelectedNode.Index;
				audioPlaybackPanel1.Play();
			}
		}

		private void numericUpDownWAVID_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Enter)
			{
				decimal temp = numericUpDownWAVID.Value;
				numericUpDownWAVID.Value = 0;
				numericUpDownWAVID.Value = temp;
				e.SuppressKeyPress = true;
			}
		}
	}
}
