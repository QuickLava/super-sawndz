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
	public partial class FindAllForm : Form
	{
		public FindAllForm(List<KeyValuePair<string, MappingItem>> searchResultsIn)
		{
			InitializeComponent();

			foreach (KeyValuePair<string, MappingItem> entry in searchResultsIn)
			{
				treeViewMapping.Nodes.Add(new MappingItem(entry.Value.name, entry.Value.groupID, entry.Value.collectionID, entry.Value.wavID));
			}

		}

		private void button1_Click(object sender, EventArgs e)
		{
			DialogResult = DialogResult.OK;
			Close();
		}

		private void button2_Click(object sender, EventArgs e)
		{
			DialogResult = DialogResult.Cancel;
			Close();
		}

		private void treeViewMapping_AfterSelect(object sender, TreeViewEventArgs e)
		{
			audioPlaybackPanel1.TargetSource = null;
			MappingItem item = e.Node as MappingItem;
			if (item == null)
			{
				return;
			}
			if (item.wavID > -1)
			{
				audioPlaybackPanel1.TargetSource = item as BrawlLib.Internal.Audio.IAudioSource;
				audioPlaybackPanel1.TargetSource.CreateStreams();
				audioPlaybackPanel1.Play();
			}
		}

		private void treeViewMapping_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
		{
			DialogResult = DialogResult.OK;
			Close();
		}

		private void FindAllForm_FormClosed(object sender, FormClosedEventArgs e)
		{
			audioPlaybackPanel1.TargetSource = null;
		}
	}
}
