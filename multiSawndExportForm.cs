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
		public multiSawndExportForm()
		{
			InitializeComponent();
			brsar.LoadCheckedList(checkedListBox1);
			checkedListBox1.CheckOnClick = true;
			radioButtonNameDefault.Checked = true;
		}

		private void buttonBrowse_Click(object sender, EventArgs e)
		{
			VistaFolderBrowserDialog fbd = new VistaFolderBrowserDialog();
			if (fbd.ShowDialog() == DialogResult.OK)
			{
				textBoxExportDirectory.Text = fbd.SelectedPath;
				if (checkedListBox1.CheckedItems.Count > 0)
				{
					buttonExport.Enabled = true;
				}
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
					foreach (MappingItem item in checkedListBox1.CheckedItems)
					{
						exportList.WriteLine("\"" + item.groupID.ToString("D3") + ".sawnd" + "\" = " + item.groupID.ToString());
					}
				}
				else if (radioButtonNamePP.Checked)
				{
					foreach (MappingItem item in checkedListBox1.CheckedItems)
					{
						exportList.WriteLine("\"" + (item.groupID - 7).ToString("X3") + ".sawnd" + "\" = " + item.groupID.ToString());
					}
				}
				else if (radioButtonNameManual.Checked)
				{
					nameInputForm nif = new nameInputForm();
					foreach (MappingItem item in checkedListBox1.CheckedItems)
					{
						TreeNode currNode = nif.treeViewNames.Nodes.Add(item.ToString());
						currNode.Text += ".sawnd";
						currNode.Tag = item.groupID.ToString();
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
					foreach (MappingItem item in checkedListBox1.CheckedItems)
					{
						exportList.WriteLine("\"" + item.name + ".sawnd" + "\" = " + item.groupID.ToString());
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

		private void checkedListBox1_KeyPress(object sender, KeyPressEventArgs e)
		{
			int currentlySelectedIndex = checkedListBox1.SelectedIndex;
			if (currentlySelectedIndex >= 0 && currentlySelectedIndex < checkedListBox1.Items.Count)
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
		private void checkedListBox1_DoubleClick(object sender, EventArgs e)
		{
			int currentlySelectedIndex = checkedListBox1.SelectedIndex;
			if (currentlySelectedIndex >= 0 && currentlySelectedIndex < checkedListBox1.Items.Count)
			{
				checkedListBox1.SetItemChecked(currentlySelectedIndex, !checkedListBox1.GetItemChecked(currentlySelectedIndex));
			}
		}
		private void checkedListBox1_ItemCheck(object sender, ItemCheckEventArgs e)
		{
			if (textBoxExportDirectory.Text.Length > 0)
			{
				if (e.NewValue == CheckState.Checked)
				{
					buttonExport.Enabled = true;
				}
				else
				{
					if (checkedListBox1.CheckedItems.Count <= 1)
					{
						buttonExport.Enabled = false;
					}
				}
			}
			else
			{
				buttonExport.Enabled = false;
			}
		}
	}
}
