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
			this.Focus();
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

		private void activateTextInputBox(TreeNode selectedNode)
		{
			textBoxTextInput.Location = new Point(treeViewNames.Location.X + selectedNode.Bounds.Left, treeViewNames.Location.Y + selectedNode.Bounds.Top);
			textBoxTextInput.Visible = true;
			textBoxTextInput.Focus();
			textBoxTextInput.Text = selectedNode.Text;
		}

		private void treeViewNames_KeyDown(object sender, KeyEventArgs e)
		{
			TreeNode selectedNode = treeViewNames.SelectedNode;
			if (selectedNode != null)
			{
				if (e.KeyCode == Keys.Enter)
				{
					e.SuppressKeyPress = true;
					activateTextInputBox(selectedNode);
				}
			}
		}
		private void treeViewNames_DoubleClick(object sender, EventArgs e)
		{
			TreeNode selectedNode = treeViewNames.SelectedNode;
			if (selectedNode != null)
			{
				activateTextInputBox(selectedNode);
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
				textBox1.SelectionStart = insertLoc + toInsert.Length;
				textBox1.Focus();
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

		private string scrubText(string textIn)
		{
			string result = "";

			foreach (char character in textIn)
			{
				if (!blacklistedChars.Contains(character))
				{
					result += character;
				}
			}

			return result;
		}
		private void textBox1_TextChanged(object sender, EventArgs e)
		{
			int selectedIndex = textBox1.SelectionStart;
			string bufferStr = scrubText(textBox1.Text);
			int stringSizeDifference = textBox1.Text.Length - bufferStr.Length;
			textBox1.Text = bufferStr;
			textBox1.SelectionStart = selectedIndex - stringSizeDifference;
		}

		private void textBoxTextInput_VisibleChanged(object sender, EventArgs e)
		{
			textBoxTextInput.Clear();
		}

		private void textBoxTextInput_Leave(object sender, EventArgs e)
		{
			textBoxTextInput.Visible = false;
		}

		private void textBoxTextInput_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Enter)
			{
				treeViewNames.SelectedNode.Text = textBoxTextInput.Text;
				textBoxTextInput.Visible = false;
				e.SuppressKeyPress = true;
			}
			else if (e.KeyCode == Keys.Escape)
			{
				textBoxTextInput.Visible = false;
				e.SuppressKeyPress = true;
			}
		}

		private void textBoxTextInput_TextChanged(object sender, EventArgs e)
		{
			int selectedIndex = textBoxTextInput.SelectionStart;
			string bufferStr = scrubText(textBoxTextInput.Text);
			int stringSizeDifference = textBoxTextInput.Text.Length - bufferStr.Length;
			textBoxTextInput.Text = bufferStr;
			textBoxTextInput.SelectionStart = selectedIndex - stringSizeDifference;
		}

		private void nameInputForm_KeyDown(object sender, KeyEventArgs e)
		{
			if (!textBoxTextInput.Focused && e.KeyCode == Keys.Escape)
			{
				DialogResult = DialogResult.Cancel;
				Close();
			}
		}
	}
}
