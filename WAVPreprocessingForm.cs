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
		int trueOriginalSampleRate = int.MaxValue;
		int trueOriginalChannelCount = int.MaxValue;
		int defaultSampleRate = int.MaxValue;
		int defaultChannelCount = int.MaxValue;


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

			if (numericUpDownChannelCount.Value != trueOriginalChannelCount)
			{
				soxArguments += " channels " + numericUpDownChannelCount.Value.ToString();
			}

			if (numericUpDownSampleRate.Value != trueOriginalSampleRate)
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

		public WAVPreprocessingForm(int destinationGroupID, int destinationCollectionID, int destinationWaveID, string filePath, 
			float volumeMultIn = float.MaxValue, bool normalizeVolumeIn = false, float tempoMultIn = float.MaxValue, float pitchShiftIn = float.MaxValue,
			int paddingInitIn = int.MaxValue, int paddingFinalIn = int.MaxValue,
			int trimInitIn = int.MaxValue, int trimFinalIn = int.MaxValue,
			int channelCountIn = int.MaxValue, int sampleRateIn = int.MaxValue, bool suppressSettingsMenuAffects = false)
		{
			InitializeComponent();

			int targetWAVChannelCount = int.MaxValue;
			int targetWAVSampleRate = int.MaxValue;

			brsar.LoadSpecificGroupTreeView(treeViewMapping, destinationGroupID);
			if (treeViewMapping.Nodes.Count <= 0)
			{
				DialogResult = DialogResult.Abort;
				Close();
			}
			else
			{
				TreeNode targetBankNode = treeViewMapping.Nodes[0];
				foreach(MappingItem collection in targetBankNode.Nodes)
				{
					if (collection.collectionID == destinationCollectionID)
					{
						foreach (MappingItem wav in collection.Nodes)
						{
							if (wav.wavID == destinationWaveID)
							{
								treeViewMapping.SelectedNode = wav;
								wav.CreateStreams();
								if (wav.streams[0] != null)
								{
									targetWAVChannelCount = wav.streams[0].Channels;
									targetWAVSampleRate = wav.streams[0].Frequency;
								}
								break;
							}
						}
						break;
					}
				}
			}

			originalFilepath = filePath;

			audioPlaybackPanelProcessed.TargetSource = new StreamSource(BrawlLib.Internal.Audio.WAV.FromFile(filePath));
			trueOriginalChannelCount = audioPlaybackPanelProcessed.TargetStreams.First().Channels;
			trueOriginalSampleRate = audioPlaybackPanelProcessed.TargetStreams.First().Frequency;

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
				defaultChannelCount = channelCountIn;
			}
			else
			{
				// Set our initial value to the true original channel count.
				defaultChannelCount = trueOriginalChannelCount;
				// Apply Settings menu options:
				if (targetWAVChannelCount != int.MaxValue)
				{
					// Default to mono if the Settings Menu says to ALWAYS convert to mono...
					bool doOverrideChannelCount = Properties.Settings.Default.ConvertToMono == 2;
					// ... or if it's set to convert to match other mono sounds, AND the target sound is mono.
					doOverrideChannelCount |= (Properties.Settings.Default.ConvertToMono == 1) && (targetWAVChannelCount < 2);
					// AND that together with whether or not the sourceWAV is mono or not, since we don't need to worry about this otherwise.
					doOverrideChannelCount &= trueOriginalChannelCount > 1;
					if (doOverrideChannelCount)
					{
						defaultChannelCount = 1;
					}
				}
			}
			setValueAndClamp(numericUpDownChannelCount, defaultChannelCount);
			if (sampleRateIn != int.MaxValue)
			{
				defaultSampleRate = sampleRateIn;
			}
			else
			{
				// Set our initial value to the true original rate.
				defaultSampleRate = trueOriginalSampleRate;
				// Apply Settings menu options:
				if (targetWAVSampleRate != int.MaxValue)
				{
					// We'll override the original sound's sample rate if the settings menu is set to ALWAYS override it...
					bool doOverrideSampleRate = Properties.Settings.Default.MatchSampleRate == 2;
					// ... or if we're set to override if we're downsampling, and our source sample rate is higher than the destination.
					doOverrideSampleRate |= (Properties.Settings.Default.MatchSampleRate == 1) && 
						(trueOriginalSampleRate > targetWAVSampleRate);
					// If we're set to do the override, we take the target sound's sample rate. Otherwise, we maintain the original.
					defaultSampleRate = (doOverrideSampleRate) ? targetWAVSampleRate : trueOriginalSampleRate;
					// Lastly, we apply the maximum sample rate limiter if it's enabled.
					if (Properties.Settings.Default.MaximumSampleRate > 0)
					{
						defaultSampleRate = Math.Min(defaultSampleRate, Properties.Settings.Default.MaximumSampleRate);
					}
				}
			}
			setValueAndClamp(numericUpDownSampleRate, defaultSampleRate);

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
			setValueAndClamp(numericUpDownVolume, (decimal)1.00);
		}

		private void buttonResetSampleRate_Click(object sender, EventArgs e)
		{
			setValueAndClamp(numericUpDownSampleRate, (decimal)defaultSampleRate);
		}

		private void buttonResetChannelCount_Click(object sender, EventArgs e)
		{
			setValueAndClamp(numericUpDownChannelCount, (decimal)defaultChannelCount);
		}

		private void buttonResetTempo_Click(object sender, EventArgs e)
		{
			setValueAndClamp(numericUpDownTempo, (decimal)1.00);
		}

		private void buttonResetPitch_Click(object sender, EventArgs e)
		{
			setValueAndClamp(numericUpDownPitch, (decimal)0.00);
		}

		private void buttonResetPadInit_Click(object sender, EventArgs e)
		{
			setValueAndClamp(numericUpDownPadInit, (decimal)0);
		}

		private void buttonResetPadFinal_Click(object sender, EventArgs e)
		{
			setValueAndClamp(numericUpDownPadFinal, (decimal)0);
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
			checkBoxNormalize.Checked = false;
			numericUpDownVolume.Value = (decimal)1.0;
			numericUpDownChannelCount.Value = defaultChannelCount;
			numericUpDownSampleRate.Value = defaultSampleRate;
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
			setValueAndClamp(numericUpDownTrimInit, (decimal)0);
		}

		private void buttonResetTrimFinal_Click(object sender, EventArgs e)
		{
			setValueAndClamp(numericUpDownTrimFinal, (decimal)0);
		}

		private void checkBoxNormalize_CheckedChanged(object sender, EventArgs e)
		{
			numericUpDownVolume.Enabled = !checkBoxNormalize.Checked;
		}
	}
}
