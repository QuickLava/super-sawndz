﻿using System;
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
	public partial class TextInputForm : Form
	{
		string blacklistedChars = "";

		public TextInputForm(string blacklistIn = "")
		{
			blacklistedChars = blacklistIn;
			InitializeComponent();
		}

		private void button1_Click(object sender, EventArgs e)
		{
			DialogResult = DialogResult.OK;
			Close();
		}

		private void button2_Click(object sender, EventArgs e)
		{
			DialogResult = DialogResult.Cancel;
			Close();
		}

		private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
		{
			if (blacklistedChars.Contains(e.KeyChar))
			{
				e.Handled = true;
			}
		}

		private void textBox1_TextChanged(object sender, EventArgs e)
		{
			int selectedIndex = textBox1.SelectionStart;
			string bufferStr = NamingSchemeBlacklists.scrubString(textBox1.Text, blacklistedChars);
			int stringSizeDifference = textBox1.Text.Length - bufferStr.Length;
			textBox1.Text = bufferStr;
			textBox1.SelectionStart = selectedIndex - stringSizeDifference;
		}
	}
}
