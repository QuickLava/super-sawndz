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
			textBoxDefaultBrsar.Text = Properties.Settings.Default.DefaultBrsarFilePath;
			if (Properties.Settings.Default.EnableFullLengthNames)
			{
				radioButtonFullNameEnable.Checked = true;
			}
			else
			{
				radioButtonFullNameDisable.Checked = true;
			}
			switch (Properties.Settings.Default.DefaultSAWNDExportNameScheme)
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
			if (File.Exists(brsar.RSAR_FileName))
			{
				buttonBRSARPathUseCurrent.Enabled = true;
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

			Properties.Settings.Default.EnableFullLengthNames = radioButtonFullNameEnable.Checked;

			if (radioButtonNamePM.Checked)
			{
				Properties.Settings.Default.DefaultSAWNDExportNameScheme = 1;
			}
			else if (radioButtonNamePP.Checked)
			{
				Properties.Settings.Default.DefaultSAWNDExportNameScheme = 2;
			}
			else if (radioButtonNameManual.Checked)
			{
				Properties.Settings.Default.DefaultSAWNDExportNameScheme = 3;
			}
			else
			{
				Properties.Settings.Default.DefaultSAWNDExportNameScheme = 0;
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

		private void button1_Click(object sender, EventArgs e)
		{
			textBoxDefaultBrsar.Text = Path.GetFullPath(brsar.RSAR_FileName);
		}
	}
}
