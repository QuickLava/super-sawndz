using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace BrawlSoundConverter
{
	public partial class SettingsForm : Form
	{
		public bool defaultBrsarPathIsValid = true;
		public SettingsForm()
		{
			InitializeComponent();
			textBoxDefaultBrsar.Text = brsar.RSAR_FileName;
			switch (Properties.Settings.Default.DefaultMultiExportNameScheme)
			{
				case 0:
					radioButtonNameDefault.Checked = true;
					break;
				case 1:
					radioButtonNamePM.Checked = true;
					break;
				case 2:
					radioButtonNamePP.Checked = true;
					break;
				case 3:
					radioButtonNameManual.Checked = true;
					break;
				default:
					radioButtonNameDefault.Checked = true;
					break;
			}
			if (Properties.Settings.Default.DefaultMultiWAVExportCreateGroupDirectory)
			{
				radioButtonGroupDirEnable.Checked = true;
			}
			else
			{
				radioButtonGroupDirDisable.Checked = true;
			}
		}

		private void buttonBrowse_Click(object sender, EventArgs e)
		{
			OpenFileDialog ofd = new OpenFileDialog();
			ofd.Filter = "Sound Archive(*.brsar)|*.brsar";
			if (ofd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
			{
				textBoxDefaultBrsar.Text = ofd.FileName;
			}
		}

		private void buttonSave_Click(object sender, EventArgs e)
		{
			Properties.Settings.Default.DefaultBrsarFilePath = textBoxDefaultBrsar.Text;

			if (radioButtonNamePM.Checked)
			{
				Properties.Settings.Default.DefaultMultiExportNameScheme = 1;
			}
			else if (radioButtonNamePP.Checked)
			{
				Properties.Settings.Default.DefaultMultiExportNameScheme = 2;
			}
			else if (radioButtonNameManual.Checked)
			{
				Properties.Settings.Default.DefaultMultiExportNameScheme = 3;
			}
			else
			{
				Properties.Settings.Default.DefaultMultiExportNameScheme = 0;
			}

			Properties.Settings.Default.DefaultMultiWAVExportCreateGroupDirectory = radioButtonGroupDirEnable.Checked;

			DialogResult = DialogResult.OK;
			Close();
		}

		private void textBoxDefaultBrsar_TextChanged(object sender, EventArgs e)
		{
			if (!string.IsNullOrEmpty(textBoxDefaultBrsar.Text) && File.Exists(textBoxDefaultBrsar.Text))
			{
				defaultBrsarPathIsValid = true;
			}
			else
			{
				defaultBrsarPathIsValid = false;
			}
			label1.Visible = !defaultBrsarPathIsValid;
		}
	}
}
