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
				numericUpDownVol.Value = sourceNode.MainSend;
				numericUpDownPitch.Value = new Decimal(sourceNode.Pitch);
				numericUpDownPan.Value = sourceNode.Pan;
				numericUpDownFX1.Value = sourceNode.FxSendA;
				numericUpDownFX2.Value = sourceNode.FxSendB;
				numericUpDownFX3.Value = sourceNode.FxSendC;
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
