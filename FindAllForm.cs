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
	}
}
