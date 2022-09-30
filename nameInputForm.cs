using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace BrawlSoundConverter
{
	public partial class nameInputForm : Form
	{
		NamingSchemeStruct namingScheme = null;
		string blacklistedChars = NamingSchemeBlacklists.IllegalFilepathCharacters;

		public nameInputForm(NamingSchemeStruct schemeIn)
		{
			InitializeComponent();
			treeViewNames.LabelEdit = true;

			namingScheme = schemeIn;
			textBox1.Text = namingScheme.baseString;

			int index = 0;
			foreach (KeyValuePair<string, NamingSchemeWildcardEntry> entry in namingScheme.wildCards)
			{
				TreeNode currNode = treeView1.Nodes.Add(entry.Key + ": " + entry.Value.wildcardText);
				currNode.Tag = index;
				index++;
			}
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
		private void treeViewNames_KeyDown(object sender, KeyEventArgs e)
		{
			TreeNode selectedNode = treeViewNames.SelectedNode;
			if (selectedNode != null)
			{
				if (e.KeyCode == Keys.Enter)
				{
					selectedNode.BeginEdit();
					e.SuppressKeyPress = true;
				}
			}
		}
		private void treeViewNames_DoubleClick(object sender, EventArgs e)
		{
			TreeNode selectedNode = treeViewNames.SelectedNode;
			if (selectedNode != null)
			{
				selectedNode.BeginEdit();
			}
		}

		public void applyBaseString()
		{
			namingScheme.baseString = textBox1.Text;
			foreach (TreeNode item in treeViewNames.Nodes)
			{
				item.Text = namingScheme.getName(item);
			}
		}
		private void button3_Click(object sender, EventArgs e)
		{
			applyBaseString();
		}

		private void insertSelectedNodeWildCardText()
		{
			if (treeView1.SelectedNode != null)
			{
				int insertLoc = textBox1.SelectionStart;
				string toInsert = namingScheme.wildCards.ElementAt((int)treeView1.SelectedNode.Tag).Value.wildcardText;
				if (insertLoc < 0 || insertLoc > textBox1.Text.Length)
				{
					insertLoc = (textBox1.Text.Length > 0) ? textBox1.Text.Length - 1 : 0;
				}
				textBox1.Text = textBox1.Text.Insert(insertLoc, toInsert);
				textBox1.SelectionStart += toInsert.Length;
			}
		}


		private void treeView1_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
		{
			insertSelectedNodeWildCardText();
		}

		private void treeView1_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Enter)
			{
				insertSelectedNodeWildCardText();
			}
		}

		private void textBox1_TextChanged(object sender, EventArgs e)
		{
			int selectedIndex = textBox1.SelectionStart;
			int stringSizeDifference = textBox1.Text.Length;
			string bufferStr = "";
			foreach (char character in textBox1.Text)
			{
				if (!blacklistedChars.Contains(character))
				{
					bufferStr += character;
				}
			}
			stringSizeDifference -= bufferStr.Length;
			textBox1.Text = bufferStr;
			textBox1.SelectionStart = selectedIndex - stringSizeDifference;
		}
	}
}
