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
	public partial class ExInfoIndexCalcForm : Form
	{

		void calculateExpandedInfoIndex(int soundbankIDIn, int infoIndexIn)
		{
			int result = int.MaxValue;

			// Note: Code ripped directly from BrawlCrate, then adapted to relevant variable names.
			int a5Mult = 0;
			if (checkBoxPPEXMode.Checked)
			{
				soundbankIDIn += 7;
			}
			if (soundbankIDIn >= 331 && soundbankIDIn <= 587)
			{
				a5Mult = soundbankIDIn - 331;
			}

			if (infoIndexIn >= 0xA34 && infoIndexIn <= 0xA62)
			{
				result = infoIndexIn + 0x35CC + (0xA5 * a5Mult);
			}

			if (infoIndexIn >= 0x18D8 && infoIndexIn <= 0x194D)
			{
				result = infoIndexIn + 0x2757 + (0xA5 * a5Mult);
			}

			if (result != int.MaxValue)
			{
				textBoxEInfoIndexOut.Text = "0x" + result.ToString("X8");
			}
			else
			{
				textBoxEInfoIndexOut.Clear();
			}
		}
		void updateExpandedInfoIndexBox()
		{
			if (treeViewBankContents.SelectedNode != null)
			{
				MappingItem selectedItem = treeViewBankContents.SelectedNode as MappingItem;
				if (selectedItem.wavID != -1 && selectedItem.infoIndex != -1)
				{
					calculateExpandedInfoIndex(((int)numericUpDownSoundbankID.Value), selectedItem.infoIndex);
				}
				else
				{
					textBoxEInfoIndexOut.Clear();
				}
			}
			else
			{
				textBoxEInfoIndexOut.Clear();
			}
		}

		public ExInfoIndexCalcForm(MappingItem groupIn)
		{
			InitializeComponent();
			// If default Sawnd Export Naming Scheme is set to Project+...
			if (Properties.Settings.Default.DefaultSAWNDExportNameScheme == 2)
			{
				// ...toggle on Hex Input and P+EX Mode.
				checkBoxHexInput.Checked = true;
				checkBoxPPEXMode.Checked = true;
			}
			treeViewBankContents.Nodes.Add(groupIn);
		}

		private void numericUpDown1_ValueChanged(object sender, EventArgs e)
		{
			updateExpandedInfoIndexBox();
		}

		private void checkBox1_CheckedChanged(object sender, EventArgs e)
		{
			numericUpDownSoundbankID.Hexadecimal = checkBoxHexInput.Checked;
		}

		private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
		{
			if (treeViewBankContents.SelectedNode != null)
			{
				MappingItem selectedItem = treeViewBankContents.SelectedNode as MappingItem;
				audioPlaybackPanelBankContents.TargetSource = selectedItem as BrawlLib.Internal.Audio.IAudioSource;
				audioPlaybackPanelBankContents.TargetSource.CreateStreams();
				audioPlaybackPanelBankContents.Play();
			}
			updateExpandedInfoIndexBox();
		}

		private void checkBox2_CheckedChanged(object sender, EventArgs e)
		{
			if (checkBoxPPEXMode.Checked)
			{
				numericUpDownSoundbankID.Maximum -= 7;
				numericUpDownSoundbankID.Minimum -= 7;
			}
			else
			{
				numericUpDownSoundbankID.Maximum += 7;
				numericUpDownSoundbankID.Minimum += 7;
			}
			updateExpandedInfoIndexBox();
		}

		private void numericUpDownSoundbankID_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Enter)
			{
				e.SuppressKeyPress = true;
			}
		}

		private void treeViewBankContents_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Enter && audioPlaybackPanelBankContents.TargetSource != null)
			{
				audioPlaybackPanelBankContents.Play();
				e.SuppressKeyPress = true;
			}
		}
	}
}
