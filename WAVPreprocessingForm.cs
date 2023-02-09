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
	public partial class WAVPreprocessingForm : Form
	{
		bool queueAudioRegen = false;

		string originalFilepath = "";
		int originalSampleRate = int.MaxValue;
		int originalChannelCount = int.MaxValue;

		public WAVPreprocessingForm(int destinationGroupID, string filePath)
		{
			InitializeComponent();

			if (destinationGroupID == -1)
			{
				destinationGroupID = 0;
			}

			brsar.LoadSpecificGroupTreeView(treeViewMapping, destinationGroupID);

			originalFilepath = filePath;

			File.Copy(filePath, Properties.Resources.tempAudioResamplePath, true);
			audioPlaybackPanelProcessed.TargetSource = new StreamSource(BrawlLib.Internal.Audio.WAV.FromFile(Properties.Resources.tempAudioResamplePath));
			originalSampleRate = audioPlaybackPanelProcessed.TargetStreams.First().Frequency;
			originalChannelCount = audioPlaybackPanelProcessed.TargetStreams.First().Channels;

			numericUpDownSampleRate.Value = originalSampleRate;
			numericUpDownChannelCount.Value = originalChannelCount;
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
			string soxArguments = "";

			if (numericUpDownVolume.Value != (decimal)1.0)
			{
				soxArguments += " vol " + numericUpDownVolume.Value.ToString();
			}

			if (numericUpDownChannelCount.Value != originalChannelCount)
			{
				soxArguments += " channels " + numericUpDownChannelCount.Value.ToString();
			}

			if (numericUpDownSampleRate.Value != originalSampleRate)
			{
				soxArguments += " rate " + numericUpDownSampleRate.Value.ToString();
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
				soxArguments += " pad " + prefixLengthInSeconds.ToString() + " " + suffixLengthInSeconds.ToString();
			}

			if (!String.IsNullOrEmpty(soxArguments))
			{
				Sawndz.runSoX("-V3 \"" + originalFilepath + "\" \"" + Properties.Resources.tempAudioResamplePath + "\"" + soxArguments);
			}
			else
			{
				File.Copy(originalFilepath, Properties.Resources.tempAudioResamplePath, true);
			}
			audioPlaybackPanelProcessed.TargetSource = new StreamSource(BrawlLib.Internal.Audio.WAV.FromFile(Properties.Resources.tempAudioResamplePath));
			audioPlaybackPanelProcessed.Play();
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
	}
}
