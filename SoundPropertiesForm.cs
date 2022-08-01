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
	public partial class SoundPropertiesForm : Form
	{
		BrawlLib.SSBB.ResourceNodes.RWSDDataNode sourceNode;
		public bool initSuccessful = false;
		public SoundPropertiesForm(int groupID, int fileID, int infoIndex)
		{
			InitializeComponent();
			sourceNode = brsar.GetRWSDDataNode(groupID, fileID, infoIndex);
			if (sourceNode != null)
			{
				initSuccessful = true;
				textBox1.Text = sourceNode.Name;
				textBox2.Text = "Decimal: " + infoIndex.ToString("D4") + " / Hexadecimal: 0x" + infoIndex.ToString("X4");
				textBox3.Text = sourceNode.NumSamples.ToString();
				textBox4.Text = sourceNode.SampleRate.ToString();
				textBox5.Text = sourceNode.LoopStartSample.ToString() + (sourceNode.IsLooped ? "" : " (Disabled)");
				textBox6.Text = sourceNode.Channels.ToString();
				numericUpDownVol.Value = (sourceNode.MainSend < numericUpDownVol.Maximum) ? sourceNode.MainSend : numericUpDownVol.Maximum;
				numericUpDownPitch.Value = (new Decimal(sourceNode.Pitch) < numericUpDownPitch.Maximum) ? new Decimal(sourceNode.Pitch) : numericUpDownPitch.Maximum;
				numericUpDownPan.Value = (sourceNode.Pan < numericUpDownPan.Maximum) ? sourceNode.Pan : numericUpDownPan.Maximum;
				numericUpDownFX1.Value = (sourceNode.FxSendA < numericUpDownFX1.Maximum) ? sourceNode.FxSendA : numericUpDownFX1.Maximum;
				numericUpDownFX2.Value = (sourceNode.FxSendB < numericUpDownFX2.Maximum) ? sourceNode.FxSendB : numericUpDownFX2.Maximum;
				numericUpDownFX3.Value = (sourceNode.FxSendC < numericUpDownFX3.Maximum) ? sourceNode.FxSendC : numericUpDownFX3.Maximum;
			}
		}

		private void button1_Click(object sender, EventArgs e)
		{
			sourceNode.MainSend = ((byte)numericUpDownVol.Value);
			sourceNode.Pan = ((byte)numericUpDownPan.Value);
			sourceNode.Pitch = ((float)numericUpDownPitch.Value);
			sourceNode.FxSendA = ((byte)numericUpDownFX1.Value);
			sourceNode.FxSendB = ((byte)numericUpDownFX2.Value);
			sourceNode.FxSendC = ((byte)numericUpDownFX3.Value);

			DialogResult = DialogResult.OK;
			Close();
		}

		private void button2_Click(object sender, EventArgs e)
		{
			DialogResult = DialogResult.Cancel;
			Close();
		}
	}
}
