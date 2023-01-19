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
	public partial class AboutForm : Form
	{
		public AboutForm()
		{
			InitializeComponent();
			labelSuperSawndz.Text = "Super Sawndz - Version " + Properties.Resources.Version;
			treeView1.Tag = 0x00;
			TreeNode currNode = treeView1.Nodes.Add("Program Homepage: https://github.com/QuickLava/super-sawndz");
			currNode = treeView1.Nodes.Add("Created by: Agoaj");
			currNode.Nodes.Add("Homepage: http://agoaj.com/blog/");
			currNode.Nodes.Add("Github: https://github.com/agoaj");
			currNode = treeView1.Nodes.Add("Modified by: QuickLava");
			currNode.Nodes.Add("Github: https://github.com/QuickLava");
			currNode = treeView1.Nodes.Add("Powered by BrawlLib v0.38:");
			currNode.Nodes.Add("BrawlLib Authors: soopercool101, Simon381, Onium");
			currNode.Nodes.Add("BrawlLib Homepage: https://github.com/soopercool101/BrawlCrate");
			currNode = treeView1.Nodes.Add("Additionally Utilizing:");
			currNode.Nodes.Add("Sound eXchange (SoX) v14.4.2: https://sox.sourceforge.net/ (1998−2013 Bagwell)");
			currNode.Nodes.Add("lavaResawndz v1.2.8: https://github.com/QuickLava/lavaResawndz (2022 QuickLava)");
			currNode = treeView1.Nodes.Add("Formerly Utilizing:");
			currNode.Nodes.Add("sawndz 0.13: (2010-2011 Jaklub)");
			currNode = treeView1.Nodes.Add("Special Thanks (Sawndz Contributions):");
			currNode.Nodes.Add("mastaklo, ssbbtailsfan, stickman, VILE ");
			currNode = treeView1.Nodes.Add("Special Thanks (Super Sawndz Testing, Feedback, and Suggestions):");
			currNode.Nodes.Add("GoldenNickXT, Tatsuya, Burrotis, MarioDox, WarioTails358, KingJigglypuff");
			treeView1.ExpandAll();
		}

		private void labelSuperSawndz_Click(object sender, EventArgs e)
		{
			treeView1.Tag = ((int)treeView1.Tag) + 1;
			if ((int)treeView1.Tag == 0xA)
			{
				this.FormBorderStyle = FormBorderStyle.Sizable;
				this.MinimumSize = this.Size;
				this.MaximumSize = new Size(this.Width, this.Height + 0x20);
				toolTip1.SetToolTip(labelSuperSawndz, "It's a secret to everybody.");
			}
		}
	}
}
