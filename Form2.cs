using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace BrawlSoundConverter
{
	public partial class nameInputForm : Form
	{
		public nameInputForm()
		{
			InitializeComponent();
			treeViewNames.LabelEdit = true;
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
		private void treeViewNames_KeyDown(object sender, KeyEventArgs e)
		{
			TreeNode selectedNode = treeViewNames.SelectedNode;
			if (selectedNode != null)
			{
				if (e.KeyCode == Keys.Enter)
				{
					selectedNode.BeginEdit();
					e.SuppressKeyPress = true;
				}
			}
		}
		private void treeViewNames_DoubleClick(object sender, EventArgs e)
		{
			TreeNode selectedNode = treeViewNames.SelectedNode;
			if (selectedNode != null)
			{
				selectedNode.BeginEdit();
			}
		}
	}
}
