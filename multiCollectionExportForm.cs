using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using BrawlLib.Internal.Windows.Forms.Ookii.Dialogs;



namespace BrawlSoundConverter
{
	public partial class multiCollectionExportForm : Form
	{
		BrawlLib.SSBB.ResourceNodes.RSARNode currRSAR = null;
		BrawlLib.SSBB.ResourceNodes.RSARFileNode currSelectedFile = null;

		public static int compareFilesByFirstParentGroupName(BrawlLib.SSBB.ResourceNodes.RSARFileNode x, BrawlLib.SSBB.ResourceNodes.RSARFileNode y)
		{
			int result = 0;
			if (x == null)
			{
				if (y == null)
				{
					result = 0;
				}
				else
				{
					result = -1;
				}
			}
			else
			{
				if (y == null)
				{
					result = 1;
				}
				else
				{
					if (Properties.Settings.Default.EnableFullLengthNames)
					{
						result = x.GroupRefNodes[0].TreePath.CompareTo(y.GroupRefNodes[0].TreePath);
					}
					else
					{
						result = x.GroupRefNodes[0].Name.CompareTo(y.GroupRefNodes[0].Name);
					}
				}
			}
			return result;
		}
		public static int compareFilesByFirstParentGroupID(BrawlLib.SSBB.ResourceNodes.RSARFileNode x, BrawlLib.SSBB.ResourceNodes.RSARFileNode y)
		{
			int result = 0;
			if (x == null)
			{
				if (y == null)
				{
					result = 0;
				}
				else
				{
					result = -1;
				}
			}
			else
			{
				if (y == null)
				{
					result = 1;
				}
				else
				{
					int xCompVal = (x.GroupRefNodes[0].StringId < 0) ? int.MaxValue : x.GroupRefNodes[0].StringId;
					int yCompVal = (y.GroupRefNodes[0].StringId < 0) ? int.MaxValue : y.GroupRefNodes[0].StringId;
					result = xCompVal.CompareTo(yCompVal);
				}
			}
			return result;
		}
		public static int compareFilesByFileID(BrawlLib.SSBB.ResourceNodes.RSARFileNode x, BrawlLib.SSBB.ResourceNodes.RSARFileNode y)
		{
			int result = 0;
			if (x == null)
			{
				if (y == null)
				{
					result = 0;
				}
				else
				{
					result = -1;
				}
			}
			else
			{
				if (y == null)
				{
					result = 1;
				}
				else
				{
					int xCompVal = (x.FileNodeIndex < 0) ? int.MaxValue : x.FileNodeIndex;
					int yCompVal = (y.FileNodeIndex < 0) ? int.MaxValue : y.FileNodeIndex;
					result = xCompVal.CompareTo(yCompVal);
				}
			}
			return result;
		}
		public class FirstParentGroupNameNodeSorter : System.Collections.IComparer
		{
			public FirstParentGroupNameNodeSorter() { }

			public int Compare(object x, object y)
			{
				TreeNode nodeX = x as TreeNode;
				TreeNode nodeY = y as TreeNode;
				BrawlLib.SSBB.ResourceNodes.RSARFileNode fileX = nodeX.Tag as BrawlLib.SSBB.ResourceNodes.RSARFileNode;
				BrawlLib.SSBB.ResourceNodes.RSARFileNode fileY = nodeY.Tag as BrawlLib.SSBB.ResourceNodes.RSARFileNode;

				return compareFilesByFirstParentGroupName(fileX, fileY);
			}
		}
		public class FirstParentGroupNameDescNodeSorter : System.Collections.IComparer
		{
			public FirstParentGroupNameDescNodeSorter() { }

			public int Compare(object x, object y)
			{
				TreeNode nodeX = x as TreeNode;
				TreeNode nodeY = y as TreeNode;
				BrawlLib.SSBB.ResourceNodes.RSARFileNode fileX = nodeX.Tag as BrawlLib.SSBB.ResourceNodes.RSARFileNode;
				BrawlLib.SSBB.ResourceNodes.RSARFileNode fileY = nodeY.Tag as BrawlLib.SSBB.ResourceNodes.RSARFileNode;

				return 0 - compareFilesByFirstParentGroupName(fileX, fileY);
			}
		}
		public class FirstParentGroupIDNodeSorter : System.Collections.IComparer
		{
			public FirstParentGroupIDNodeSorter() { }

			public int Compare(object x, object y)
			{
				TreeNode nodeX = x as TreeNode;
				TreeNode nodeY = y as TreeNode;
				BrawlLib.SSBB.ResourceNodes.RSARFileNode fileX = nodeX.Tag as BrawlLib.SSBB.ResourceNodes.RSARFileNode;
				BrawlLib.SSBB.ResourceNodes.RSARFileNode fileY = nodeY.Tag as BrawlLib.SSBB.ResourceNodes.RSARFileNode;

				return compareFilesByFirstParentGroupID(fileX, fileY);
			}
		}
		public class FirstParentGroupIDDescNodeSorter : System.Collections.IComparer
		{
			public FirstParentGroupIDDescNodeSorter() { }

			public int Compare(object x, object y)
			{
				TreeNode nodeX = x as TreeNode;
				TreeNode nodeY = y as TreeNode;
				BrawlLib.SSBB.ResourceNodes.RSARFileNode fileX = nodeX.Tag as BrawlLib.SSBB.ResourceNodes.RSARFileNode;
				BrawlLib.SSBB.ResourceNodes.RSARFileNode fileY = nodeY.Tag as BrawlLib.SSBB.ResourceNodes.RSARFileNode;

				return 0 - compareFilesByFirstParentGroupID(fileX, fileY);
			}
		}
		public class FileIDNodeSorter : System.Collections.IComparer
		{
			public FileIDNodeSorter() { }

			public int Compare(object x, object y)
			{
				TreeNode nodeX = x as TreeNode;
				TreeNode nodeY = y as TreeNode;
				BrawlLib.SSBB.ResourceNodes.RSARFileNode fileX = nodeX.Tag as BrawlLib.SSBB.ResourceNodes.RSARFileNode;
				BrawlLib.SSBB.ResourceNodes.RSARFileNode fileY = nodeY.Tag as BrawlLib.SSBB.ResourceNodes.RSARFileNode;

				return compareFilesByFileID(fileX, fileY);
			}
		}
		public class FileIDDescNodeSorter : System.Collections.IComparer
		{
			public FileIDDescNodeSorter() { }

			public int Compare(object x, object y)
			{
				TreeNode nodeX = x as TreeNode;
				TreeNode nodeY = y as TreeNode;
				BrawlLib.SSBB.ResourceNodes.RSARFileNode fileX = nodeX.Tag as BrawlLib.SSBB.ResourceNodes.RSARFileNode;
				BrawlLib.SSBB.ResourceNodes.RSARFileNode fileY = nodeY.Tag as BrawlLib.SSBB.ResourceNodes.RSARFileNode;

				return 0 - compareFilesByFileID(fileX, fileY);
			}
		}

		public static string getNameNodeFileType(TreeNode nodeIn)
		{
			string result = "";

			BrawlLib.SSBB.ResourceNodes.RSARFileNode attachedFile = nodeIn.Tag as BrawlLib.SSBB.ResourceNodes.RSARFileNode;
			if (attachedFile != null)
			{
				result = attachedFile.ResourceFileType.ToString();
			}

			return result;
		}
		public static string getNameNodeFileExt(TreeNode nodeIn)
		{
			string result = "";

			BrawlLib.SSBB.ResourceNodes.RSARFileNode attachedFile = nodeIn.Tag as BrawlLib.SSBB.ResourceNodes.RSARFileNode;
			if (attachedFile != null)
			{
				result = "b" + attachedFile.ResourceFileType.ToString().ToLower();
			}

			return result;
		}
		public static string getNameNodeFileIDDec(TreeNode nodeIn)
		{
			string result = "";

			BrawlLib.SSBB.ResourceNodes.RSARFileNode attachedFile = nodeIn.Tag as BrawlLib.SSBB.ResourceNodes.RSARFileNode;
			if (attachedFile != null)
			{
				result = attachedFile.FileNodeIndex.ToString("D3");
			}

			return result;
		}
		public static string getNameNodeFileIDHex(TreeNode nodeIn)
		{
			string result = "";

			BrawlLib.SSBB.ResourceNodes.RSARFileNode attachedFile = nodeIn.Tag as BrawlLib.SSBB.ResourceNodes.RSARFileNode;
			if (attachedFile != null)
			{
				result = attachedFile.FileNodeIndex.ToString("X3");
			}

			return result;
		}
		public static string getNameNodeFileParentGroupNameLong(TreeNode nodeIn)
		{
			string result = "";

			BrawlLib.SSBB.ResourceNodes.RSARFileNode attachedFile = nodeIn.Tag as BrawlLib.SSBB.ResourceNodes.RSARFileNode;
			if (attachedFile != null)
			{
				result = attachedFile.GroupRefNodes[0].TreePath.Replace('/', '_');
			}

			return result;
		}
		public static string getNameNodeFileParentGroupNameShort(TreeNode nodeIn)
		{
			string result = "";

			BrawlLib.SSBB.ResourceNodes.RSARFileNode attachedFile = nodeIn.Tag as BrawlLib.SSBB.ResourceNodes.RSARFileNode;
			if (attachedFile != null)
			{
				result = attachedFile.GroupRefNodes[0].Name;
			}

			return result;
		}
		public static string getNameNodeFileParentGroupIDDec(TreeNode nodeIn)
		{
			string result = "";

			BrawlLib.SSBB.ResourceNodes.RSARFileNode attachedFile = nodeIn.Tag as BrawlLib.SSBB.ResourceNodes.RSARFileNode;
			if (attachedFile != null)
			{
				result = attachedFile.GroupRefNodes[0].StringId.ToString("D3");
			}

			return result;
		}
		public static string getNameNodeFileParentGroupIDHex(TreeNode nodeIn)
		{
			string result = "";

			BrawlLib.SSBB.ResourceNodes.RSARFileNode attachedFile = nodeIn.Tag as BrawlLib.SSBB.ResourceNodes.RSARFileNode;
			if (attachedFile != null)
			{
				result = attachedFile.GroupRefNodes[0].StringId.ToString("X3");
			}

			return result;
		}


		private void buildCollectionView(bool refreshFileList)
		{
			treeViewCollections.Nodes.Clear();
			treeViewSounds.Nodes.Clear();
			treeViewCollectionDetails.Nodes.Clear();
			currSelectedFile = null;
			buttonExport.Enabled = false;
			audioPlaybackPanel1.TargetSource = null;
			foreach (BrawlLib.SSBB.ResourceNodes.RSARFileNode file in currRSAR.Files)
			{
				if (file.GroupRefNodes.Length == 0 || Convert.ToInt32(file.DataOffset, 16) == 0x00)
					continue;
				switch (file.ResourceFileType)
				{
					case BrawlLib.SSBB.ResourceNodes.ResourceType.RWSD:
						{
							if (!checkBox1.Checked)
								continue;
							break;
						}
					case BrawlLib.SSBB.ResourceNodes.ResourceType.RBNK:
						{
							if (!checkBox2.Checked)
								continue;
							break;
						}
					case BrawlLib.SSBB.ResourceNodes.ResourceType.RSEQ:
						{
							if (!checkBox3.Checked)
								continue;
							break;
						}
					default:
						{
							continue;
							break;
						}
				}

				string displayString = "[" + file.FileNodeIndex.ToString("X3") + "] " + file.ResourceFileType + " - in \"[" + file.GroupRefNodes[0].StringId.ToString("X3") + "] ";
				if (Properties.Settings.Default.EnableFullLengthNames)
				{
					displayString += file.GroupRefNodes[0].TreePath.Replace('/', '_') + "\"";
				}
				else
				{
					displayString += file.GroupRefNodes[0].Name + "\"";
				}
				List<int> usedStringIDs = new List<int> { file.GroupRefNodes[0].StringId };
				for (int u = 1; u < file.GroupRefNodes.Length; u++)
				{
					BrawlLib.SSBB.ResourceNodes.RSARGroupNode group = file.GroupRefNodes[u];
					if (usedStringIDs.Contains(group.StringId))
						continue;
					usedStringIDs.Add(group.StringId);
				}
				if (usedStringIDs.Count > 1)
				{
					displayString += " and " + (usedStringIDs.Count - 1).ToString() + " other(s)";
				}

				TreeNode newNode = new TreeNode(displayString);
				newNode.Tag = file;
				treeViewCollections.Nodes.Add(newNode);
			}
			reorderCollectionView();

			setNumCheckedText();
		}
		private void reorderCollectionView()
		{
			treeViewCollections.Sort();
		}

		public multiCollectionExportForm()
		{
			InitializeComponent();
			currRSAR = brsar.GetRSAR();

			comboBoxSortMode.SelectedIndex = 0;

			switch (Properties.Settings.Default.DefaultCollectionExportNameScheme)
			{
				case 1:
					{
						radioButtonNameDecimalID.Checked = true;
						break;
					}
				case 2:
					{
						radioButtonNameHexID.Checked = true;
						break;
					}
				case 3:
					{
						radioButtonNameManual.Checked = true;
						break;
					}
				default:
					{
						radioButtonNameDefault.Checked = true;
						break;
					}
			}

			buildCollectionView(true);

			buttonCancel.Enabled = true;

			toolTipNameDefault.SetToolTip(radioButtonNameDefault, "Names exported files according to their appearance in the below \"Collections\" list.");
			toolTipNameFID.SetToolTip(radioButtonNameDecimalID, "Names exported files according to their Collection ID (in decimal).");
			toolTipNameFIDHex.SetToolTip(radioButtonNameHexID, "Names exported files according to their Collection ID (in hexadecimal).");
			toolTipNameManual.SetToolTip(radioButtonNameManual, "Presents a menu in which you may specify the filenames to be used by each selected collection.");
		}

		private uint numTreeNodesChecked()
		{
			uint numChecked = 0;
			foreach (TreeNode currNode in treeViewCollections.Nodes)
			{
				if (currNode.Checked)
				{
					numChecked++;
				}
			}
			return numChecked;
		}

		private void setExportButtonState()
		{
			if (textBoxExportDirectory.Text.Length > 0)
			{
				if (numTreeNodesChecked() > 0)
				{
					buttonExport.Enabled = true;
				}
				else
				{
					buttonExport.Enabled = false;
				}
			}
			else
			{
				buttonExport.Enabled = false;
			}
		}
		private void setNumCheckedText()
		{
			label2.Text = "Collections (" + numTreeNodesChecked().ToString() + " out of " + treeViewCollections.Nodes.Count.ToString() + " checked)";
		}

		private void buttonBrowse_Click(object sender, EventArgs e)
		{
			VistaFolderBrowserDialog fbd = new VistaFolderBrowserDialog();
			if (fbd.ShowDialog() == DialogResult.OK)
			{
				textBoxExportDirectory.Text = fbd.SelectedPath;
				buttonSelectAll.Enabled = true;
				buttonDeselectAll.Enabled = true;
				buttonInvertSelection.Enabled = true;
			} 
		}
		private void buttonExport_Click(object sender, EventArgs e)
		{
			bool didExport = false;
			if (textBoxExportDirectory.Text.Length > 0)
			{
				if (radioButtonNameManual.Checked)
				{
					string initialBaseString = "[${COLL_ID_HEX}] ";
					if (Properties.Settings.Default.EnableFullLengthNames)
					{
						initialBaseString += "${COLL_P_GRP_NAME_L}";
					}
					else
					{
						initialBaseString += "${COLL_P_GRP_NAME_S}";
					}
					initialBaseString += ".${COLL_EXT}";
					NamingSchemeStruct wildCardStruct = new NamingSchemeStruct(initialBaseString);
					wildCardStruct.blacklistedChars = NamingSchemeBlacklists.IllegalFilepathCharacters;
					wildCardStruct.wildCards.Add("Collection Type", new NamingSchemeWildcardEntry("${COLL_TYPE}", getNameNodeFileType));
					wildCardStruct.wildCards.Add("Collection ID (Hex)", new NamingSchemeWildcardEntry("${COLL_ID_HEX}", getNameNodeFileIDHex));
					wildCardStruct.wildCards.Add("Collection ID (Dec)", new NamingSchemeWildcardEntry("${COLL_ID_DEC}", getNameNodeFileIDDec));
					wildCardStruct.wildCards.Add("Parent Group Short Name", new NamingSchemeWildcardEntry("${COLL_P_GRP_NAME_S}", getNameNodeFileParentGroupNameShort));
					wildCardStruct.wildCards.Add("Parent Group Long Name", new NamingSchemeWildcardEntry("${COLL_P_GRP_NAME_L}", getNameNodeFileParentGroupNameLong));
					wildCardStruct.wildCards.Add("Parent Group ID (Hex)", new NamingSchemeWildcardEntry("${COLL_P_GRP_ID_HEX}", getNameNodeFileParentGroupIDHex));
					wildCardStruct.wildCards.Add("Parent Group ID (Dec)", new NamingSchemeWildcardEntry("${COLL_P_GRP_ID_DEC}", getNameNodeFileParentGroupIDDec));
					wildCardStruct.wildCards.Add("Collection Extension", new NamingSchemeWildcardEntry("${COLL_EXT}", getNameNodeFileExt));

					nameInputForm nif = new nameInputForm(wildCardStruct);
					foreach (TreeNode item in treeViewCollections.Nodes)
					{
						if (item.Checked)
						{
							BrawlLib.SSBB.ResourceNodes.RSARFileNode targetFile = item.Tag as BrawlLib.SSBB.ResourceNodes.RSARFileNode;
							TreeNode currNode = nif.treeViewNames.Nodes.Add(targetFile.FileNodeIndex.ToString("X3"));
							currNode.Text += ".b" + targetFile.ResourceFileType.ToString().ToLower();
							currNode.Tag = targetFile;
						}
					}
					nif.applyBaseString();
					if (nif.ShowDialog() == DialogResult.OK)
					{
						foreach (TreeNode item in nif.treeViewNames.Nodes)
						{
							BrawlLib.SSBB.ResourceNodes.RSARFileNode targetFile = item.Tag as BrawlLib.SSBB.ResourceNodes.RSARFileNode;
							string exportName = item.Text;
							targetFile.Export(textBoxExportDirectory.Text + "\\" + exportName);
						}
						didExport = true;
					}
				}
				else
				{
					foreach (TreeNode collection in treeViewCollections.Nodes)
					{
						if (collection.Checked)
						{
							BrawlLib.SSBB.ResourceNodes.RSARFileNode targetFile = collection.Tag as BrawlLib.SSBB.ResourceNodes.RSARFileNode;
							string exportName = "";
							if (radioButtonNameDecimalID.Checked)
							{
								exportName = targetFile.FileNodeIndex.ToString("D3");
							}
							else if (radioButtonNameHexID.Checked)
							{
								exportName = targetFile.FileNodeIndex.ToString("X3");
							}
							else
							{
								exportName = NamingSchemeBlacklists.scrubString(targetFile.TreePath.Replace('/', '_'), NamingSchemeBlacklists.IllegalFilepathCharacters);
							}
							exportName += ".b" + targetFile.ResourceFileType.ToString().ToLower();
							targetFile.Export(textBoxExportDirectory.Text + "\\" + exportName);
							didExport = true;
						}
					}
				}
			}

			if (didExport)
			{
				DialogResult = DialogResult.OK;
				Close();
			}
		}
		private void buttonSelectAll_Click(object sender, EventArgs e)
		{
			treeViewCollections.SuspendLayout();
			treeViewCollections.AfterCheck -= treeViewCollections_AfterCheck;
			foreach (TreeNode collection in treeViewCollections.Nodes)
			{
				collection.Checked = true;
			}
			treeViewCollections.AfterCheck += treeViewCollections_AfterCheck;
			treeViewCollections.ResumeLayout();
			handleCheckUIUpdates();
		}
		private void buttonDeselectAll_Click(object sender, EventArgs e)
		{
			treeViewCollections.SuspendLayout();
			treeViewCollections.AfterCheck -= treeViewCollections_AfterCheck;
			foreach (TreeNode collection in treeViewCollections.Nodes)
			{
				collection.Checked = false;
			}
			treeViewCollections.AfterCheck += treeViewCollections_AfterCheck;
			treeViewCollections.ResumeLayout();
			handleCheckUIUpdates();
		}
		private void buttonInvertSelection_Click(object sender, EventArgs e)
		{
			treeViewCollections.SuspendLayout();
			treeViewCollections.AfterCheck -= treeViewCollections_AfterCheck;
			foreach (TreeNode collection in treeViewCollections.Nodes)
			{
				collection.Checked = !collection.Checked;
			}
			treeViewCollections.AfterCheck += treeViewCollections_AfterCheck;
			treeViewCollections.ResumeLayout();
			handleCheckUIUpdates();
		}

		private void handleCheckUIUpdates()
		{
			setExportButtonState();
			setNumCheckedText();
		}
		private void treeViewCollections_AfterCheck(object sender, TreeViewEventArgs e)
		{
			handleCheckUIUpdates();
		}
		private void treeViewCollections_KeyDown(object sender, KeyEventArgs e)
		{
			TreeNode currNode = treeViewCollections.SelectedNode;
			if (currNode != null && e.KeyCode == Keys.Enter)
			{
				currNode.Checked = !currNode.Checked;
				e.SuppressKeyPress = true;
			}
		}
		private void treeViewCollections_DoubleClick(object sender, EventArgs e)
		{
			TreeNode currNode = treeViewCollections.SelectedNode;
			if (currNode != null)
			{
				currNode.Checked = !currNode.Checked;
			}
		}
		private void treeViewCollections_AfterSelect(object sender, TreeViewEventArgs e)
		{
			currSelectedFile = treeViewCollections.SelectedNode.Tag as BrawlLib.SSBB.ResourceNodes.RSARFileNode;

			treeViewSounds.Nodes.Clear();
			brsar.CollectSoundNodesFromSubfile(currSelectedFile.GroupRefNodes[0].StringId, currSelectedFile.FileNodeIndex, treeViewSounds.Nodes);
			treeViewSounds.SelectedNode = null;
			audioPlaybackPanel1.TargetSource = null;

			treeViewCollectionDetails.Nodes.Clear();

			TreeNode usedInNode = new TreeNode("Used in ");
			List<int> usedStringIDs = new List<int>();
			for (int i = 0; i < currSelectedFile.GroupRefNodes.Length; i++)
			{
				BrawlLib.SSBB.ResourceNodes.RSARGroupNode group = currSelectedFile.GroupRefNodes[i];
				if (usedStringIDs.Contains(group.StringId))
					continue;
				usedStringIDs.Add(group.StringId);
				usedInNode.Nodes.Add(new TreeNode("[" + group.StringId.ToString("X3") + "] " + group.TreePath.Replace('/', '_')));
			}
			usedInNode.Text += usedStringIDs.Count.ToString() + " group(s)";
			treeViewCollectionDetails.Nodes.Add(usedInNode);
			usedInNode.Expand();

			treeViewCollectionDetails.Nodes.Add(new TreeNode("Uncompressed Size (Bytes, Dec.): " + currSelectedFile.UncompressedSize.ToString()));
			treeViewCollectionDetails.Nodes.Add(new TreeNode("Data Length (Bytes, Hex.): " + currSelectedFile.DataLength));
			treeViewCollectionDetails.Nodes.Add(new TreeNode("Data Offset: 0x" + currSelectedFile.DataOffset));
			treeViewCollectionDetails.Nodes.Add(new TreeNode("Audio Length (Bytes, Hex.): " + currSelectedFile.AudioLength));
			treeViewCollectionDetails.Nodes.Add(new TreeNode("Audio Offset: 0x" + currSelectedFile.AudioOffset));
		}


		private void buttonCancel_Click(object sender, EventArgs e)
		{
			DialogResult = DialogResult.Cancel;
			Close();
		}

		private void textBoxExportDirectory_TextChanged(object sender, EventArgs e)
		{
			if (numTreeNodesChecked() > 0)
			{
				buttonExport.Enabled = true;
			}
		}

		
		private void treeViewSounds_AfterSelect(object sender, TreeViewEventArgs e)
		{
			audioPlaybackPanel1.TargetSource = treeViewSounds.SelectedNode as BrawlLib.Internal.Audio.IAudioSource;
			audioPlaybackPanel1.TargetSource.CreateStreams();
			audioPlaybackPanel1.Play();
		}

		private void checkBox1_CheckedChanged(object sender, EventArgs e)
		{
			buildCollectionView(true);
		}
		private void checkBox2_CheckedChanged(object sender, EventArgs e)
		{
			buildCollectionView(true);
		}
		private void checkBox3_CheckedChanged(object sender, EventArgs e)
		{
			buildCollectionView(true);
		}

		private void comboBoxSortMode_SelectedIndexChanged(object sender, EventArgs e)
		{
			switch (comboBoxSortMode.SelectedIndex % 3)
			{
				case 0:
					{
						if (comboBoxSortMode.SelectedIndex < 3)
						{
							treeViewCollections.TreeViewNodeSorter = new FileIDNodeSorter();
						}
						else
						{
							treeViewCollections.TreeViewNodeSorter = new FileIDDescNodeSorter();
						}
						break;
					}
				case 1:
					{
						if (comboBoxSortMode.SelectedIndex < 3)
						{
							treeViewCollections.TreeViewNodeSorter = new FirstParentGroupIDNodeSorter();
						}
						else
						{
							treeViewCollections.TreeViewNodeSorter = new FirstParentGroupIDDescNodeSorter();
						}
						break;
					}
				case 2:
					{
						if (comboBoxSortMode.SelectedIndex < 3)
						{
							treeViewCollections.TreeViewNodeSorter = new FirstParentGroupNameNodeSorter();
						}
						else
						{
							treeViewCollections.TreeViewNodeSorter = new FirstParentGroupNameDescNodeSorter();
						}
						break;
					}
				default:
					break;
			}
			reorderCollectionView();
		}
	}
}
