using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Microsoft.WindowsAPICodePack.Dialogs;
using System.IO;

namespace BrawlSoundConverter
{
	public partial class multiSawndExportForm : Form
	{
		public multiSawndExportForm()
		{
			InitializeComponent();
			brsar.LoadCheckedList(checkedListBox1);
			checkedListBox1.CheckOnClick = true;
		}

		private void buttonBrowse_Click(object sender, EventArgs e)
		{
			CommonOpenFileDialog fbd = new CommonOpenFileDialog();
			fbd.IsFolderPicker = true;
			if (fbd.ShowDialog() == CommonFileDialogResult.Ok)
			{
				textBoxExportDirectory.Text = fbd.FileName;
				buttonExport.Enabled = true;
				buttonSelectAll.Enabled = true;
				buttonDeselectAll.Enabled = true;
				buttonInvertSelection.Enabled = true;
			} 
		}
		private void buttonExport_Click(object sender, EventArgs e)
		{
			if (textBoxExportDirectory.Text.Length > 0)
			{
				StreamWriter exportList = File.CreateText("toExport.txt");
				foreach (MappingItem item in checkedListBox1.CheckedItems)
				{
					exportList.WriteLine("\"" + item.name + ".sawnd" + "\" = " + item.groupID.ToString());
				}
				exportList.Close();
				Sawndz.multiCreateSawnd(textBoxExportDirectory.Text);
				if (File.Exists("toExport.txt"))
				{
					File.Delete("toExport.txt");
				}
				this.Close();
			}
		}
		private void buttonSelectAll_Click(object sender, EventArgs e)
		{
			for (int i = 0; i < checkedListBox1.Items.Count; i++)
			{
				checkedListBox1.SetItemChecked(i, true);
			}
		}
		private void buttonDeselectAll_Click(object sender, EventArgs e)
		{
			for (int i = 0; i < checkedListBox1.Items.Count; i++)
			{
				checkedListBox1.SetItemChecked(i, false);
			}
		}
		private void buttonInvertSelection_Click(object sender, EventArgs e)
		{
			for (int i = 0; i < checkedListBox1.Items.Count; i++)
			{
				checkedListBox1.SetItemChecked(i, !checkedListBox1.GetItemChecked(i));
			}
		}

		//Play sound if enter/return is pressed.
		private void checkedListBox1_KeyPress(object sender, KeyPressEventArgs e)
		{
			int currentlySelectedIndex = checkedListBox1.SelectedIndex;
			if (currentlySelectedIndex >= 0 && currentlySelectedIndex < checkedListBox1.Items.Count && e.KeyChar == '\r')
			{
				switch (e.KeyChar)
				{
					case '\r':
					{
						checkedListBox1.SetItemChecked(currentlySelectedIndex, !checkedListBox1.GetItemChecked(currentlySelectedIndex));
						break;
					}
				}
			}
		}
	}
}
