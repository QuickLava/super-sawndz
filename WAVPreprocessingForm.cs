using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Media;
using System.IO;

namespace BrawlSoundConverter
{
	public partial class WAVPreprocessingForm : Form
	{
		bool queueAudioRegen = false;

		string originalFilepath = "";
		int originalSampleRate = int.MaxValue;
		int originalChannelCount = int.MaxValue;

		bool setValueAndClamp(NumericUpDown destination, decimal value)
		{
			destination.Value = Math.Min(Math.Max(value, destination.Minimum), destination.Maximum);

			return value != destination.Value;
		}
		private bool applySettings()
		{
			bool success = false;

			string soxArguments = "";

			if (checkBoxNormalize.Checked)
			{
				soxArguments += " norm";
			}
			else if (numericUpDownVolume.Value != (decimal)1.0)
			{
				soxArguments += " vol " + numericUpDownVolume.Value.ToString();
			}

			if (numericUpDownTrimInit.Value != 0 || numericUpDownTrimFinal.Value != 0)
			{
				double prefixLengthInSeconds = ((double)numericUpDownTrimInit.Value) / 1000.0;
				double suffixLengthInSeconds = ((double)numericUpDownTrimFinal.Value) / 1000.0;

				soxArguments += " trim";
				if (numericUpDownTrimInit.Value > 0)
				{
					soxArguments += " " + prefixLengthInSeconds.ToString();
				}
				else
				{
					soxArguments += " 0.0";
				}
				if (numericUpDownTrimFinal.Value > 0)
				{
					suffixLengthInSeconds *= -1;
					soxArguments += " " + suffixLengthInSeconds.ToString();
				}
				else
				{
					soxArguments += " -0.0";
				}
			}

			if (numericUpDownTempo.Value != (decimal)1.0)
			{
				soxArguments += " tempo " + numericUpDownTempo.Value.ToString();
			}

			if (numericUpDownPitch.Value != (decimal)0.0)
			{
				soxArguments += " pitch " + (numericUpDownPitch.Value * 100).ToString();
			}

			if (numericUpDownPadInit.Value != 0 || numericUpDownPadFinal.Value != 0)
			{
				double prefixLengthInSeconds = ((double)numericUpDownPadInit.Value) / 1000.0;
				double suffixLengthInSeconds = ((double)numericUpDownPadFinal.Value) / 1000.0;

				soxArguments += " pad";
				if (numericUpDownPadInit.Value > 0)
				{
					soxArguments += " " + prefixLengthInSeconds.ToString();
				}
				else
				{
					soxArguments += " 0";
				}
				if (numericUpDownPadFinal.Value > 0)
				{
					soxArguments += " " + suffixLengthInSeconds.ToString();
				}
				else
				{
					soxArguments += " 0";
				}
			}

			if (numericUpDownChannelCount.Value != originalChannelCount)
			{
				soxArguments += " channels " + numericUpDownChannelCount.Value.ToString();
			}

			if (numericUpDownSampleRate.Value != originalSampleRate)
			{
				soxArguments += " rate " + numericUpDownSampleRate.Value.ToString();
			}

			File.Delete(Properties.Resources.tempAudioResamplePath);
			if (!String.IsNullOrEmpty(soxArguments))
			{
				Sawndz.runSoX("-V3 \"" + originalFilepath + "\" \"" + Properties.Resources.tempAudioResamplePath + "\"" + soxArguments);
			}
			else
			{
				File.Copy(originalFilepath, Properties.Resources.tempAudioResamplePath, true);
			}

			if (File.Exists(Properties.Resources.tempAudioResamplePath))
			{
				success = true;
			}
			else
			{
				File.Copy(originalFilepath, Properties.Resources.tempAudioResamplePath, true);
			}

			audioPlaybackPanelProcessed.TargetSource = new StreamSource(BrawlLib.Internal.Audio.WAV.FromFile(Properties.Resources.tempAudioResamplePath));

			int sampleCount = audioPlaybackPanelProcessed.TargetStreams.First().Samples;
			textBoxProcessedSize.Text = ((sampleCount / 2 * 2) / 2).ToString("X");

			return success;
		}

		public WAVPreprocessingForm(int destinationGroupID, string filePath, 
			float volumeMultIn = float.MaxValue, bool normalizeVolumeIn = false, float tempoMultIn = float.MaxValue, float pitchShiftIn = float.MaxValue,
			int paddingInitIn = int.MaxValue, int paddingFinalIn = int.MaxValue,
			int trimInitIn = int.MaxValue, int trimFinalIn = int.MaxValue,
			int channelCountIn = int.MaxValue, int sampleRateIn = int.MaxValue)
		{
			InitializeComponent();

			brsar.LoadSpecificGroupTreeView(treeViewMapping, destinationGroupID);
			if (treeViewMapping.Nodes.Count <= 0)
			{
				DialogResult = DialogResult.Abort;
				Close();
			}
			else
			{
				treeViewMapping.Nodes[0].Expand();
			}

			originalFilepath = filePath;

			audioPlaybackPanelProcessed.TargetSource = new StreamSource(BrawlLib.Internal.Audio.WAV.FromFile(filePath));

			if (volumeMultIn != float.MaxValue)
			{
				setValueAndClamp(numericUpDownVolume, (decimal)volumeMultIn);
			}
			checkBoxNormalize.Checked = normalizeVolumeIn;
			if (tempoMultIn != float.MaxValue)
			{
				setValueAndClamp(numericUpDownTempo, (decimal)tempoMultIn);
			}
			if (pitchShiftIn != float.MaxValue)
			{
				setValueAndClamp(numericUpDownPitch, (decimal)pitchShiftIn);
			}
			if (trimInitIn != int.MaxValue)
			{
				setValueAndClamp(numericUpDownTrimInit, (decimal)trimInitIn);
			}
			if (trimFinalIn != int.MaxValue)
			{
				setValueAndClamp(numericUpDownTrimFinal, (decimal)trimFinalIn);
			}
			if (paddingInitIn != int.MaxValue)
			{
				setValueAndClamp(numericUpDownPadInit, (decimal)paddingInitIn);
			}
			if (paddingFinalIn != int.MaxValue)
			{
				setValueAndClamp(numericUpDownPadFinal, (decimal)paddingFinalIn);
			}

			if (channelCountIn != int.MaxValue)
			{
				originalChannelCount = channelCountIn;
			}
			else
			{
				originalChannelCount = audioPlaybackPanelProcessed.TargetStreams.First().Channels;
			}
			setValueAndClamp(numericUpDownChannelCount, originalChannelCount);
			if (sampleRateIn != int.MaxValue)
			{
				originalSampleRate = sampleRateIn;
			}
			else
			{
				originalSampleRate = audioPlaybackPanelProcessed.TargetStreams.First().Frequency;
			}
			setValueAndClamp(numericUpDownSampleRate, originalSampleRate);

			if (applySettings())
			{
				audioPlaybackPanelProcessed.TargetSource = new StreamSource(BrawlLib.Internal.Audio.WAV.FromFile(Properties.Resources.tempAudioResamplePath));
			}
			else
			{
				DialogResult = DialogResult.Abort;
				Close();
			}
		}

		private void buttonResetVolume_Click(object sender, EventArgs e)
		{
			numericUpDownVolume.Value = (Decimal)1.00;
		}

		private void buttonResetSampleRate_Click(object sender, EventArgs e)
		{
			numericUpDownSampleRate.Value = originalSampleRate;
		}

		private void buttonResetChannelCount_Click(object sender, EventArgs e)
		{
			numericUpDownChannelCount.Value = originalChannelCount;
		}

		private void buttonResetTempo_Click(object sender, EventArgs e)
		{
			numericUpDownTempo.Value = (decimal)1.00;
		}

		private void buttonResetPitch_Click(object sender, EventArgs e)
		{
			numericUpDownPitch.Value = (decimal)0.00;
		}

		private void buttonResetPadInit_Click(object sender, EventArgs e)
		{
			numericUpDownPadInit.Value = (decimal)0;
		}

		private void buttonResetPadFinal_Click(object sender, EventArgs e)
		{
			numericUpDownPadFinal.Value = (decimal)0;
		}

		private void buttonApply_Click(object sender, EventArgs e)
		{
			if (applySettings())
			{
				audioPlaybackPanelProcessed.Play();
			}
			else
			{
				SystemSounds.Exclamation.Play();
			}
		}

		private void treeViewMapping_AfterSelect(object sender, TreeViewEventArgs e)
		{
			audioPlaybackBRSARSound.TargetSource = null;
			MappingItem item = e.Node as MappingItem;
			if (item == null)
			{
				return;
			}
			if (item.wavID > -1)
			{
				audioPlaybackBRSARSound.TargetSource = item as BrawlLib.Internal.Audio.IAudioSource;
				audioPlaybackBRSARSound.TargetSource.CreateStreams();
				audioPlaybackBRSARSound.Play();
			}
		}

		private void buttonReset_Click(object sender, EventArgs e)
		{
			numericUpDownVolume.Value = (decimal)1.0;
			numericUpDownChannelCount.Value = originalChannelCount;
			numericUpDownSampleRate.Value = originalSampleRate;
			numericUpDownTempo.Value = (decimal)1.0;
			numericUpDownPitch.Value = (decimal)0.0;
			numericUpDownTrimInit.Value = (decimal)0.0;
			numericUpDownTrimFinal.Value = (decimal)0.0;
			numericUpDownPadInit.Value = (decimal)0.0;
			numericUpDownPadFinal.Value = (decimal)0.0;
		}

		private void buttonSave_Click(object sender, EventArgs e)
		{
			DialogResult = DialogResult.OK;
			Close();
		}

		private void buttonCancel_Click(object sender, EventArgs e)
		{
			DialogResult = DialogResult.Cancel;
			Close();
		}

		private void buttonResetTrimInit_Click(object sender, EventArgs e)
		{
			numericUpDownTrimInit.Value = (decimal)0.0;
		}

		private void buttonResetTrimFinal_Click(object sender, EventArgs e)
		{
			numericUpDownTrimFinal.Value = (decimal)0.0;
		}

		private void checkBoxAllowClipping_CheckedChanged(object sender, EventArgs e)
		{
			numericUpDownVolume.Enabled = !checkBoxNormalize.Checked;
		}
	}
}
