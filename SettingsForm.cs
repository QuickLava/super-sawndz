﻿using System;
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

		public TabConfiguration activeTabConfig = null;

		private void populateTreeView()
		{
			treeView2.Nodes.Clear();
			activeTabConfig.populateTreeView(treeView2);
		}

		public SettingsForm(TabConfiguration activeTabConfigIn)
		{
			InitializeComponent();

			activeTabConfig = activeTabConfigIn;

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

			switch (Properties.Settings.Default.DefaultCollectionExportNameScheme)
			{
				case 1:
					radioButtonCollNameID.Checked = true;
					break;
				case 2:
					radioButtonCollNameIDHex.Checked = true;
					break;
				case 3:
					radioButtonCollNameCustom.Checked = true;
					break;
				default:
					radioButtonCollNameDefault.Checked = true;
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

			switch (Properties.Settings.Default.ConvertToMono)
			{
				case 0:
					radioButtonStereoConvNever.Checked = true;
					break;
				case 1:
					radioButtonStereoConvSometimes.Checked = true;
					break;
				case 2:
					radioButtonStereoConvAlways.Checked = true;
					break;
				default:
					radioButtonStereoConvSometimes.Checked = true;
					break;
			}

			if (File.Exists(brsar.RSAR_FileName))
			{
				buttonBRSARPathUseCurrent.Enabled = true;
			}

			if (activeTabConfig != null)
			{
				populateTreeView();
			}
			else
			{
				treeView2.Enabled = false;
				buttonConfigSave.Enabled = false;
			}

			switch (Properties.Settings.Default.MatchSampleRate)
			{
				case 0:
					radioButtonMatchSRNever.Checked = true;
					break;
				case 1:
					radioButtonMatchSRSometimes.Checked = true;
					break;
				case 2:
					radioButtonMatchSRAlways.Checked = true;
					break;
				default:
					radioButtonMatchSRNever.Checked = true;
					break;
			}
			if (Properties.Settings.Default.MaximumSampleRate > 0)
			{
				numericUpDownMaxSampRate.Value = Math.Min(Properties.Settings.Default.MaximumSampleRate, numericUpDownMaxSampRate.Maximum);
			}
			else
			{
				numericUpDownMaxSampRate.Value = 0;
			}

			if (Properties.Settings.Default.GroupSizeWarningThreshold > 0)
			{
				numericUpDownGroupSizeThresh.Value = Math.Min(Properties.Settings.Default.GroupSizeWarningThreshold, numericUpDownGroupSizeThresh.Maximum);
			}
			else
			{
				numericUpDownGroupSizeThresh.Value = 0;
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

			if (radioButtonCollNameID.Checked)
			{
				Properties.Settings.Default.DefaultCollectionExportNameScheme = 1;
			}
			else if (radioButtonCollNameIDHex.Checked)
			{
				Properties.Settings.Default.DefaultCollectionExportNameScheme = 2;
			}
			else if (radioButtonCollNameCustom.Checked)
			{
				Properties.Settings.Default.DefaultCollectionExportNameScheme = 3;
			}
			else
			{
				Properties.Settings.Default.DefaultCollectionExportNameScheme = 0;
			}

			Properties.Settings.Default.DefaultMultiWAVExportCreateGroupDirectory = radioButtonGroupDirEnable.Checked;

			if (radioButtonStereoConvAlways.Checked)
			{
				Properties.Settings.Default.ConvertToMono = 2;
			}
			else if (radioButtonStereoConvSometimes.Checked)
			{
				Properties.Settings.Default.ConvertToMono = 1;
			}
			else
			{
				Properties.Settings.Default.ConvertToMono = 0;
			}

			BrawlLib.SSBB.ResourceNodes.RSARNode currRSAR = brsar.GetRSAR();
			if (checkBoxSaveAsDefault.Checked && currRSAR != null)
			{
				int tabSettingIndex = TabConfiguration.getCurrentBRSARSettingsIndex(currRSAR);
				if (tabSettingIndex > -1 && tabSettingIndex < Properties.Settings.Default.TabSettings.Count)
				{
					Properties.Settings.Default.TabSettings[tabSettingIndex] = activeTabConfig.serialize();
				}
				else
				{
					Properties.Settings.Default.TabSettings.Add(activeTabConfig.serialize());
				}
			}
			if (radioButtonMatchSRAlways.Checked)
			{
				Properties.Settings.Default.MatchSampleRate = 2;
			}
			else if (radioButtonMatchSRSometimes.Checked)
			{
				Properties.Settings.Default.MatchSampleRate = 1;
			}
			else
			{
				Properties.Settings.Default.MatchSampleRate = 0;
			}
			Properties.Settings.Default.MaximumSampleRate = ((int)numericUpDownMaxSampRate.Value);

			Properties.Settings.Default.GroupSizeWarningThreshold = ((int)numericUpDownGroupSizeThresh.Value);

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

		private void buttonBRSARPathUseCurrent_Click(object sender, EventArgs e)
		{
			textBoxDefaultBrsar.Text = Path.GetFullPath(brsar.RSAR_FileName);
		}

		private void buttonSaveConfig_Click(object sender, EventArgs e)
		{
			SaveFileDialog sfd = new SaveFileDialog();
			if (!Directory.Exists("./Config/"))
			{
				Directory.CreateDirectory("./Config/");
			}
			sfd.InitialDirectory = Path.GetFullPath("./Config/");
			sfd.Filter = "Tab COnfiguration File(*" + TabConfiguration.configFileExtension + ")|*" + TabConfiguration.configFileExtension;
			if (sfd.ShowDialog() == DialogResult.OK)
			{
				StreamWriter temp = File.CreateText(sfd.FileName);
				temp.WriteLine(activeTabConfig.serialize());
				temp.Close();
			}
		}

		private void buttonConfigLoad_Click(object sender, EventArgs e)
		{
			OpenFileDialog ofd = new OpenFileDialog();
			if (!Directory.Exists("./Config/"))
			{
				Directory.CreateDirectory("./Config/");
			}
			ofd.InitialDirectory = Path.GetFullPath("./Config/");
			ofd.Filter = "Tab COnfiguration File(*" + TabConfiguration.configFileExtension + ")|*" + TabConfiguration.configFileExtension;
			if (ofd.ShowDialog() == DialogResult.OK)
			{
				StreamReader temp = File.OpenText(ofd.FileName);
				string line = temp.ReadLine();
				bool success = false;
				bool validForWrongBRSAR = false;
				while (!success && line != null)
				{
					if (!line.StartsWith("/") && !line.StartsWith("\\") && !line.StartsWith("#"))
					{
						TabConfiguration testConfig = new TabConfiguration(line);
						if (testConfig.brsarGroupCount == activeTabConfig.brsarGroupCount && testConfig.brsarFileCount == activeTabConfig.brsarFileCount)
						{
							activeTabConfig = testConfig;
							populateTreeView();
							line = null;
							success = true;
							checkBoxSaveAsDefault.Checked = true;
						}
						else
						{
							validForWrongBRSAR = true;
							line = temp.ReadLine();
						}
					}
					else
					{
						line = temp.ReadLine();
					}
				}
				if (!success)
				{
					if (validForWrongBRSAR)
					{
						MessageBox.Show("Unable to load provided tab configuration: File is valid, but isn't for this BRSAR!");
					}
					else
					{
						MessageBox.Show("Unable to load provided tab configuration: No valid configuration found!");
					}
				}
			}
		}

		private void buttonResetGroupThresh_Click(object sender, EventArgs e)
		{
			numericUpDownGroupSizeThresh.Value = 950000;
		}

		private void buttonResetMaxSampRate_Click(object sender, EventArgs e)
		{
			numericUpDownMaxSampRate.Value = 44100;
		}
	}
}
