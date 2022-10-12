using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Media;
using System.Xml;
using System.IO;


namespace BrawlSoundConverter
{
	public partial class Form1 : Form
	{
		public Form1()
		{
			InitializeComponent();
		}

		int currSearchResultIndex = 0;
		List<KeyValuePair<string, MappingItem>> currSearchResults = null;

		TabConfiguration currTabSettings = null;

		List<List<MappingItem>> reserveCollections = new List<List<MappingItem>>();
		int currCollectionIndex = 0;
		int currRightClickedTab = -1;

		List<int> selectedSawndFileInfo = null;
		
		bool interruptedImportAudioPanelPlayback = false;
		bool interruptedMainAudioPanelPlayback = false;

		private bool loadBRSAR(string pathIn)
		{
			bool result = false;

			if (String.IsNullOrEmpty(pathIn))
			{
				pathIn = brsar.RSAR_FileName;
			}
			else
			{
				textBoxOutput.Clear();
				currTabSettings = null;
			}
			if (File.Exists(pathIn))
			{
				textBoxGroupID.Clear();
				textBoxCollectionID.Clear();
				textBoxWavID.Clear();
				textBoxInfoIndex.Clear();
				treeViewMapping.SelectedNode = null;
				brsar.CloseRSAR();
				brsar.RSAR_FileName = pathIn;
				loadTreeView();

				enableStuff();
				result = true;
			}

			return result;
		}

		//Fill out treeViewMapping with data from the brsar
		private void loadTreeView()
		{
			try
			{
				if (brsar.GetRSAR() != null)
				{
					if (treeViewMapping.Nodes.Count > 0)
					{
						treeViewMapping.Nodes.Clear();
					}
					brsar.LoadTreeView(treeViewMapping);
					// Assign appropriate context menus to all nodes.
					foreach (TreeNode node in treeViewMapping.Nodes)
					{
						node.ContextMenuStrip = contextMenuStripGroup;
						foreach (TreeNode collNode in node.Nodes)
						{
							collNode.ContextMenuStrip = contextMenuStripCollection;
							foreach (TreeNode wavNode in collNode.Nodes)
							{
								wavNode.ContextMenuStrip = contextMenuStripWAV;
							}
						}
					}
					applyRelevantTabSettings(currTabSettings == null);
					treeViewMapping.Invalidate();

				}
			}
			catch ( Exception ex )
			{
				Console.WriteLine( ex.ToString() );
			}
		}

		private void Form1_Load( object sender, EventArgs e )
		{
			//Redirect console output to our textbox
			Console.SetOut( new TextBoxWriter( textBoxOutput ) );
			//If sawndz.exe is still running from a previous instance, ask if use wants to kill it.
			foreach(System.Diagnostics.Process p in System.Diagnostics.Process.GetProcesses())
			{
				if( p.ProcessName.CompareTo( "sawndz" ) == 0 )
				{
					if(DialogResult.Yes == MessageBox.Show( "Detected an instance of sawndz.exe running in the background. This may be from a previous crash of this program. Do you want to stop it?(Yes, you probably do)", "Sawndz.exe is running in the background", MessageBoxButtons.YesNo))
						p.Kill();
				}
			}
			//Try to load the default smashbros_sound.brsar from the default directory.
			try
			{
				//If it doesn't exist this will throw an exception
				if (loadBRSAR(""))
				{
					enableStuff();
				}
				else
				{
					disableStuff();
					Console.WriteLine("Select File->Open BRSAR to begin.");
				}
			}
			catch( Exception ex )
			{
				//no RSAR in directory
				disableStuff();
				Console.WriteLine( "Select File->Open BRSAR to begin." );
			}

			//These are not the crossthread calls you are looking for
			Control.CheckForIllegalCrossThreadCalls = false;
			audioPlaybackPanelWav.TargetSource = null;
			audioPlaybackPanelWav.VolumePercent = 0.33;
			audioPlaybackBRSARSound.TargetSource = null;
			audioPlaybackBRSARSound.VolumePercent = 0.33;

			comboBoxSearchMode.SelectedIndex = 0;

			tabControl1.TabPages[0].ContextMenuStrip = contextMenuStripTab;
		}

		private void setInsertButtonState()
		{
			buttonInsert.Enabled = false;
			if (!string.IsNullOrEmpty(textBoxInputFile.Text))
			{
				if (Path.GetExtension(textBoxInputFile.Text).CompareTo(".sawnd") == 0)
				{
					buttonInsert.Enabled = true;
				}
				else if (Path.GetExtension(textBoxInputFile.Text) == ".wav")
				{
					int gid, cid, wid;
					if (int.TryParse(textBoxGroupID.Text, out gid))
					{
						if (int.TryParse(textBoxCollectionID.Text, out cid))
						{
							if (int.TryParse(textBoxWavID.Text, out wid))
							{
								if (gid > -1 && cid > -1 && wid > -1)
								{
									buttonInsert.Enabled = true;
								}
							}
						}
					}
				}
			}
		}
		private void setTabRearrangeButtonState()
		{
			buttonRearrangeTabs.Enabled = tabControl1.TabCount > 3;
		}

		/*Called when a node is selected.
		 * Sets the textBox's for group id etc.
		 * autoplays the sound if there is one.
		*/
		private void treeViewMapping_AfterSelect( object sender, TreeViewEventArgs e )
		{
			audioPlaybackBRSARSound.TargetSource = null;
			MappingItem item = e.Node as MappingItem;
			if (item == null)
			{
				textBoxGroupID.Clear();
				textBoxCollectionID.Clear();
				textBoxWavID.Clear();
				textBoxInfoIndex.Clear();
				return;
			}
			if( item.groupID > -1 )
			{
				textBoxGroupID.Text = item.groupID.ToString();
			}
			else
			{
				textBoxGroupID.Text = "";
			}
			if( item.collectionID > -1 )
			{
				textBoxCollectionID.Text = item.collectionID.ToString();
			}
			else
			{
				textBoxCollectionID.Text = "";
			}
			if ( item.wavID > -1 )
			{
				textBoxWavID.Text = item.wavID.ToString();
				audioPlaybackBRSARSound.TargetSource = item as BrawlLib.Internal.Audio.IAudioSource;
				audioPlaybackBRSARSound.TargetSource.CreateStreams();
				audioPlaybackBRSARSound.Play();
			}
			else
			{
				textBoxWavID.Text = "";
			}
			if (item.infoIndex > -1)
			{
				textBoxInfoIndex.Text = item.infoIndex.ToString() + " (0x" + item.infoIndex.ToString("X4") + ")";
			}
			else
			{
				textBoxInfoIndex.Text = "";
			}
			contextMenuStripWAV.Items[0].Enabled = item.infoIndex > -1;
			contextMenuStripWAV.Items[1].Enabled = item.infoIndex > -1;
			if (item.groupID > -1 && item.collectionID > -1 && item.wavID <= -1)
			{
				string type = "B" + e.Node.Text.Substring(6, 4);
				contextMenuStripCollection.Items[0].Text = "Export as " + type;
				contextMenuStripCollection.Items[1].Text = "Replace with " + type;
			}
			setInsertButtonState();
		}

		//Play sound if enter/return is pressed.
		private void treeViewMapping_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Enter && audioPlaybackBRSARSound.TargetSource != null)
			{
				audioPlaybackBRSARSound.Play();
				e.SuppressKeyPress = true;
			}
		}

		//Called when the ... button is pressed to get the input file.
		//If it's a wav it's loaded for playback.
		private void buttonBrowse_Click( object sender, EventArgs e )
		{
			OpenFileDialog ofd = new OpenFileDialog();
			ofd.Filter = "Sound|*.wav;*.mp3;*.ogg;*.flac;*.sawnd|Audio File|*.wav;*.mp3;*.ogg;*.flac|Sawndz File(*.sawnd)|*.sawnd";
			if ( ofd.ShowDialog() == System.Windows.Forms.DialogResult.OK )
			{
				textBoxInputFile.Text = ofd.FileName;
				string extension = Path.GetExtension(textBoxInputFile.Text);
				if (extension == ".sawnd")
				{
					audioPlaybackPanelWav.TargetSource = null;
				}
				else if (extension == ".wav")
				{
					try
					{
						audioPlaybackPanelWav.TargetSource = new StreamSource(BrawlLib.Internal.Audio.WAV.FromFile(textBoxInputFile.Text));
					}
					catch (Exception ex)
					{
						Console.WriteLine(ex.ToString());
					}
				}
				else if (Sawndz.convertAudioToTempWav(textBoxInputFile.Text))
				{
					textBoxInputFile.Text = Properties.Resources.tempAudioTypeConvPath;
					try
					{
						audioPlaybackPanelWav.TargetSource = new StreamSource(BrawlLib.Internal.Audio.WAV.FromFile(textBoxInputFile.Text));
					}
					catch (Exception ex)
					{
						Console.WriteLine(ex.ToString());
					}
				}
				else
				{
					textBoxInputFile.Text = "";
					audioPlaybackPanelWav.TargetSource = null;
				}
			}
		}

		//Insert wav/sound
		//This is called by a background worker.
		private void insert()
		{
			try
			{
				if( Path.GetExtension( textBoxInputFile.Text ).CompareTo( ".sawnd" ) == 0 )
				{
					selectedSawndFileInfo = Sawndz.getSawndFileInfo(textBoxInputFile.Text);
					Console.WriteLine( "Inserting Sawnd " + Path.GetFileName( textBoxInputFile.Text ) );
					Sawndz.insertSawnd( textBoxInputFile.Text );
				}
				else if (Path.GetExtension(textBoxInputFile.Text) == ".wav")
				{
					int gid, cid, wid;
					if( int.TryParse( textBoxGroupID.Text, out gid ) )
					{
						if( int.TryParse( textBoxCollectionID.Text, out cid ) )
						{
							if( int.TryParse( textBoxWavID.Text, out wid ) )
							{
								if( gid > -1 && cid > -1 && wid > -1 )
								{
									Sawndz.insertWav( textBoxInputFile.Text, gid, cid, wid );
								}
							}
						}
					}
				}
			}
			catch( Exception e )
			{
				Console.WriteLine( e.ToString() );
			}
		}

		//Called when the insert button is pressed, starts a background process to call insert()
		private void buttonInsert_Click( object sender, EventArgs e )
		{
			disableStuff();
			textBoxOutput.Clear();
			backgroundWorkerInsert.RunWorkerAsync();
		}

		private int findTabContainingGroup(int groupID)
		{
			int result = int.MaxValue;

			int currCollItr = 0;
			bool found = false;
			while (!found && currCollItr < reserveCollections.Count)
			{
				List<MappingItem> currColl = reserveCollections[currCollItr];
				for (int i = 0; !found && i < currColl.Count; i++)
				{
					if (currColl[i].groupID == groupID)
					{
						found = true;
						result = currCollItr;
					}
				}
				currCollItr++;
			}

			return result;
		}
		private void selectNode(int groupID, int collectionID = -1, int infoIndex = -1)
		{
			int relevantTab = findTabContainingGroup(groupID);
			if (relevantTab != int.MaxValue)
			{
				tabControl1.SelectedIndex = relevantTab;
			}

			foreach (MappingItem groupNode in treeViewMapping.Nodes)
			{
				if (groupNode.groupID == groupID)
				{
					if (collectionID >= 0)
					{
						foreach (MappingItem collNode in groupNode.Nodes)
						{
							if (collNode.collectionID == collectionID)
							{
								if (infoIndex >= 0)
								{
									foreach(MappingItem soundNode in collNode.Nodes)
									{
										if (soundNode.infoIndex == infoIndex)
										{
											treeViewMapping.SelectedNode = soundNode;
											break;
										}
									}
								}
								else
								{
									treeViewMapping.SelectedNode = collNode;
								}
								break;
							}
						}
					}
					else
					{
						treeViewMapping.SelectedNode = groupNode;
					}
					break;
				}
			}
			if (treeViewMapping.SelectedNode != null)
			{
				treeViewMapping.SelectedNode.Expand();
				treeViewMapping.Select();
			}
		}

		//Disables buttons and treeview while sawndz is being run
		private void disableStuff()
		{
			textBoxGroupID.Enabled = false;
			textBoxCollectionID.Enabled = false;
			textBoxWavID.Enabled = false;
			textBoxInfoIndex.Enabled = false;
			textBoxSearchBar.Enabled = false;
			buttonBrowse.Enabled = false;
			buttonCreateSawnd.Enabled = false;
			buttonCreateWAV.Enabled = false;
			buttonMultiCreateWAV.Enabled = false;
			buttonMultiInsertWAV.Enabled = false;
			buttonMultiExportSawnd.Enabled = false;
			buttonMultiInsertSawnd.Enabled = false;
			buttonInsert.Enabled = false;
			buttonFind.Enabled = false;
			buttonFindAll.Enabled = false;
			buttonFindBack.Enabled = false;
			buttonExpand.Enabled = false;
			buttonCollapse.Enabled = false;
			buttonRearrangeTabs.Enabled = false;
			checkBoxSearchCase.Enabled = false;
			checkBoxSearchGroups.Enabled = false;
			checkBoxSearchSounds.Enabled = false;
			comboBoxSearchMode.Enabled = false;
			treeViewMapping.Enabled = false;
			audioPlaybackPanelWav.Enabled = false;
			audioPlaybackBRSARSound.Enabled = false;
			tabControl1.Enabled = false;
			bulkCollectionExportToolStripMenuItem.Enabled = false;
		}
		//Enable stuff again
		private void enableStuff()
		{
			setInsertButtonState();
			textBoxGroupID.Enabled = true;
			textBoxCollectionID.Enabled = true;
			textBoxWavID.Enabled = true;
			textBoxInfoIndex.Enabled = true;
			textBoxSearchBar.Enabled = true;
			treeViewMapping.Enabled = true;
			audioPlaybackPanelWav.Enabled = true;
			buttonBrowse.Enabled = true;
			audioPlaybackBRSARSound.Enabled = true;
			buttonMultiExportSawnd.Enabled = true;
			buttonMultiInsertSawnd.Enabled = true;
			buttonMultiInsertWAV.Enabled = true;
			buttonFind.Enabled = true;
			buttonFindAll.Enabled = true;
			buttonFindBack.Enabled = true;
			buttonExpand.Enabled = true;
			buttonCollapse.Enabled = true;
			setTabRearrangeButtonState();
			checkBoxSearchCase.Enabled = true;
			checkBoxSearchGroups.Enabled = true;
			checkBoxSearchSounds.Enabled = true;
			comboBoxSearchMode.Enabled = true;
			tabControl1.Enabled = true;
			bulkCollectionExportToolStripMenuItem.Enabled = true;

			//Make sure that we have a group id before turning on create sawnd button
			int gid, cid, wid;
			buttonCreateSawnd.Enabled = int.TryParse( textBoxGroupID.Text, out gid );
			buttonMultiCreateWAV.Enabled = int.TryParse( textBoxCollectionID.Text, out cid );
			buttonCreateWAV.Enabled = int.TryParse( textBoxWavID.Text, out wid );
		}

		//Called when the insert thread completes. Reloads the tree view or updates the specific node.
		private void backgroundWorkerInsert_RunWorkerCompleted( object sender, RunWorkerCompletedEventArgs e )
		{
			enableStuff();
			// If we just inserted a .wav file specifically, not a .sawnd.
			if (textBoxWavID.Text.Length > 0 && treeViewMapping.SelectedNode != null && Path.GetExtension(textBoxInputFile.Text).CompareTo(".wav") == 0)
			{
				// Get the selected node.
				MappingItem item = treeViewMapping.SelectedNode as MappingItem;

				// Get the selected node's parent, and use that to get its first child.
				MappingItem currGroupParent = treeViewMapping.SelectedNode.Parent as MappingItem;
				MappingItem currGroupChild = currGroupParent.FirstNode as MappingItem;
				// Loop through all the children...
				while (currGroupChild != null)
				{
					//... and for each which has the same wavID as the selected ID, update its size
					if (currGroupChild.wavID == item.wavID)
						currGroupChild.updateSize();
					currGroupChild = currGroupChild.NextNode as MappingItem;
				}

				//Reset the node selection to trigger treeViewMapping_AfterSelect()
				//That will reload the sound data from the brsar.
				treeViewMapping.SelectedNode = null;
				treeViewMapping.SelectedNode = item;
			}
			else
			{
				DateTime bufferBrsarLastWriteTime = brsar.currLoadedRsarLastWriteTime;
				if (loadBRSAR(""))
				{
					bool doSelect = brsar.currLoadedRsarLastWriteTime > bufferBrsarLastWriteTime;
					if (doSelect && selectedSawndFileInfo != null && selectedSawndFileInfo.Count >= 1)
					{
						selectNode(selectedSawndFileInfo[0]);
					}
				}
				else
				{
					MessageBox.Show("Unable to reload BRSAR: it doesn't appear to exist anymore!");
				}
			}
		}

		//Insert the wav or sawnd file
		private void backgroundWorkerInsert_DoWork( object sender, DoWorkEventArgs e )
		{
			insert();
		}


		//Lets the user select a specific .brsar file
		private void openBRSARToolStripMenuItem_Click( object sender, EventArgs e )
		{
			OpenFileDialog ofd = new OpenFileDialog();
			ofd.Filter = "Sound Archive(*.brsar)|*.brsar";
			if( ofd.ShowDialog() == System.Windows.Forms.DialogResult.OK )
			{
				loadBRSAR(ofd.FileName);
			}
		}

		//Called when CreateSawnd button is clicked
		private void buttonCreateSawnd_Click( object sender, EventArgs e )
		{
			//Make sure group id is valid
			int gid;
			if( !int.TryParse( textBoxGroupID.Text, out gid ) )
			{
				MessageBox.Show( "Group ID is not valid" );
				return;
			}
			textBoxOutput.Clear();
			Console.Write("Creating Sawnd File... ");
			SaveFileDialog sfd = new SaveFileDialog();
			sfd.Filter = "*Sawnd File(*.sawnd)|*.sawnd";

			MappingItem item = treeViewMapping.SelectedNode as MappingItem;
			if (item == null)
			{
				Console.WriteLine("No node selected!");
				return;
			}
			if (item.wavID != -1)
			{
				item = item.Parent as MappingItem;
			}
			if (item.collectionID != -1)
			{
				item = item.Parent as MappingItem;
			}
			
			switch (Properties.Settings.Default.DefaultSAWNDExportNameScheme)
			{
				case 0:
					sfd.FileName = item.name + ".sawnd";
					break;
				case 1:
					sfd.FileName = item.groupID.ToString("D3") + ".sawnd";
					break;
				case 2:
					sfd.FileName = item.infoIndex.ToString("X3") + ".sawnd";
					break;
				default:
					sfd.FileName = "";
					break;
			}

			if( sfd.ShowDialog() == DialogResult.OK )
			{
				Console.WriteLine("");
				disableStuff();
				textBoxOutput.Clear();
				backgroundWorkerCreateSawnd.RunWorkerAsync(sfd.FileName);
			}
			else
			{
				Console.WriteLine("Operation Cancelled!");
			}
		}

		private void backgroundWorkerCreateSawnd_DoWork( object sender, DoWorkEventArgs e )
		{
			Sawndz.createSawnd( int.Parse( textBoxGroupID.Text ), e.Argument as string );
		}
		private void backgroundWorkerCreateWAV_DoWork(object sender, DoWorkEventArgs e)
		{
			Sawndz.createWAV(int.Parse(textBoxGroupID.Text), int.Parse(textBoxCollectionID.Text), int.Parse(textBoxWavID.Text), e.Argument as string);
		}

		//Check if we need to enable the create sawnd button, need Group ID for that to work.
		private void textBoxGroupID_TextChanged( object sender, EventArgs e )
		{
			int gid;
			buttonCreateSawnd.Enabled = int.TryParse( textBoxGroupID.Text, out gid );
		}
		//Check if we need to enable the multi create wav button, need Collection ID for that to work.
		private void textBoxCollectionID_TextChanged(object sender, EventArgs e)
		{
			int cid;
			buttonMultiCreateWAV.Enabled = int.TryParse(textBoxCollectionID.Text, out cid);
		}
		//Check if we need to enable the create WAV button, need WAV ID for that to work.
		private void textBoxWavID_TextChanged(object sender, EventArgs e)
		{
			int gid;
			buttonCreateWAV.Enabled = int.TryParse(textBoxWavID.Text, out gid);
		}
		private void textBoxInputFile_TextChanged(object sender, EventArgs e)
		{
			selectedSawndFileInfo = null;
			setInsertButtonState();
		}

		private void backgroundWorkerCreateSawnd_RunWorkerCompleted( object sender, RunWorkerCompletedEventArgs e )
		{
			enableStuff();
		}
		private void backgroundWorkerCreateWAV_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
		{
			enableStuff();
		}

        private void buttonCreateWAV_Click(object sender, EventArgs e)
        {
			//Make sure group, collection, and wave ids are all valid
			int gid, cid, wid;
			if (!int.TryParse(textBoxGroupID.Text, out gid))
			{
				MessageBox.Show("Group ID is not valid");
				return;
			}
			if (!int.TryParse(textBoxCollectionID.Text, out cid))
			{
				MessageBox.Show("Collection ID is not valid");
				return;
			}
			if (!int.TryParse(textBoxWavID.Text, out wid))
			{
				MessageBox.Show("WAV ID is not valid");
				return;
			}
			textBoxOutput.Clear();
			SaveFileDialog sfd = new SaveFileDialog();
			sfd.Filter = "*WAV File(*.wav)|*.wav";
			sfd.FileName = Sawndz.getDefaultWAVEName(gid, cid, wid);
			if (sfd.ShowDialog() == DialogResult.OK)
			{
				disableStuff();
				textBoxOutput.Clear();
				backgroundWorkerCreateWAV.RunWorkerAsync(sfd.FileName);
			}
			else
			{
				Console.WriteLine("Creating WAV File... Operation Cancelled!");
			}
		}
		private void buttonMultiExportSawnd_Click(object sender, EventArgs e)
		{
			textBoxOutput.Clear();
			multiSawndExportForm tempForm = new multiSawndExportForm(treeViewMapping);
			if (tempForm.ShowDialog() == DialogResult.Cancel)
			{
				Console.WriteLine("Creating Sawnd Files... Operation Cancelled!");
			}
		}
		private void buttonMultiImportSawnd_Click(object sender, EventArgs e)
		{
			OpenFileDialog ofd = new OpenFileDialog();
			ofd.Multiselect = true;
			ofd.Filter = "*Sawnd File(*.sawnd)|*.sawnd";
			textBoxOutput.Clear();
			if (ofd.ShowDialog() == DialogResult.OK)
			{
				if (Sawndz.createSAWNDToImportList("toImport.txt", ofd.FileNames))
				{
					backgroundWorkerMultiInsertSawnd.RunWorkerAsync();
				}
				else
				{
					Console.WriteLine("Unable to import .sawnd files, couldn't generate list!");
				}
			}
			else
			{
				Console.WriteLine("Importing Sawnd files... Operation Cancelled!");
			}
		}
		private void backgroundWorkerMultiInsertSawnd_DoWork(object sender, DoWorkEventArgs e)
		{
			disableStuff();
			textBoxOutput.Clear();
			Sawndz.multiInsertSawnd();
		}
		private void backgroundWorkerMultiInsertSawnd_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
		{
			enableStuff();
			loadBRSAR("");
		}

		private void ChangeSettingsToolStripMenuItem_Click(object sender, EventArgs e)
		{
			SettingsForm settings = new SettingsForm(currTabSettings);
			if (settings.ShowDialog() == DialogResult.OK)
			{
				Properties.Settings.Default.Save();
				textBoxGroupID.Clear();
				textBoxCollectionID.Clear();
				textBoxWavID.Clear();
				if (settings.checkBoxSaveAsDefault.Checked)
				{
					currTabSettings = null;
				}
				currSearchResults = null;
				loadTreeView();
			}
		}

		private void buttonMultiCreateWAV_Click(object sender, EventArgs e)
		{
			int gid, cid;
			if (!int.TryParse(textBoxGroupID.Text, out gid))
			{
				MessageBox.Show("Group ID is not valid");
				return;
			}
			if (!int.TryParse(textBoxCollectionID.Text, out cid))
			{
				MessageBox.Show("Collection ID is not valid");
				return;
			}
			textBoxOutput.Clear();
			multiWAVExportForm tempForm = new multiWAVExportForm(gid, cid);
			if (tempForm.ShowDialog() == DialogResult.Cancel)
			{
				Console.WriteLine("Creating WAV Files... Operation Cancelled!");
			}
		}

		private void buttonMultiInsertWAV_Click(object sender, EventArgs e)
		{
			textBoxOutput.Clear();
			OpenFileDialog ofd = new OpenFileDialog();
			ofd.Filter = "WAVE Map File(*.xml)|*.xml";

			Console.Write("Importing WAVE Map... ");
			if (ofd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
			{
				Console.WriteLine("");
				backgroundWorkerMultiInsertWAV.RunWorkerAsync(ofd.FileName);
			}
			else
			{
				Console.WriteLine("Operation cancelled!");
				Console.WriteLine("Note: To use this functionality, use the \"Multi Create WAV\" button first!");
				Console.WriteLine("That will generate a WAVE Map file along with the sound files, which is used with this button to re-import the exported sounds!");
			}
		}

		private void backgroundWorkerMultiInsertWAV_DoWork(object sender, DoWorkEventArgs e)
		{
			disableStuff();
			Sawndz.multiInsertWAV(e.Argument as string);
		}

		private void backgroundWorkerMultiInsertWAV_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
		{
			loadTreeView();
			enableStuff();
		}

		private void toolStripMenuItemSoundProps_Click(object sender, EventArgs e)
		{
			MappingItem selectedNode = treeViewMapping.SelectedNode as MappingItem;
			if (selectedNode != null)
			{
				textBoxOutput.Clear();
				Console.Write("Editing Sound Properties... ");
				SoundPropertiesForm soundProps = new SoundPropertiesForm(selectedNode.groupID, selectedNode.collectionID, selectedNode.infoIndex);
				if (soundProps.initSuccessful)
				{
					if (soundProps.ShowDialog() == DialogResult.OK)
					{
						Console.WriteLine("Success!");
						brsar.ReloadRSAR(true);
					}
					else
					{
						Console.WriteLine("Operation Cancelled!");
					}
				}
			}
		}

		private void toolStripMenuItemBRWSDExport_Click(object sender, EventArgs e)
		{
			int gid, cid;
			if (!int.TryParse(textBoxGroupID.Text, out gid))
			{
				MessageBox.Show("Group ID is not valid");
				return;
			}
			if (!int.TryParse(textBoxCollectionID.Text, out cid))
			{
				MessageBox.Show("Collection ID is not valid");
				return;
			}
			textBoxOutput.Clear();
			string nodeType = treeViewMapping.SelectedNode.Text.Substring(6, 4);
			string nodeExportType = "b" + nodeType.ToLower();
			Console.Write("Exporting " + nodeType + " file... ");
			SaveFileDialog sfd = new SaveFileDialog();
			sfd.FileName = "[" + gid.ToString("D3") + "_" + cid.ToString("X3") + "] " + nodeType + "." + nodeExportType;
			sfd.Filter = nodeExportType.ToUpper() + " File(*." + nodeExportType + ")|*." + nodeExportType;
			if (sfd.ShowDialog() == DialogResult.OK)
			{
				Console.WriteLine("");
				backgroundWorkerCreateBRWSD.RunWorkerAsync(sfd.FileName);
			}
			else
			{
				Console.WriteLine("Operation Cancelled!");
			}
		}

		private void toolStripMenuItemBRWSDReplace_Click(object sender, EventArgs e)
		{
			textBoxOutput.Clear();
			int gid, cid;
			if (!int.TryParse(textBoxGroupID.Text, out gid))
			{
				MessageBox.Show("Group ID is not valid");
				return;
			}
			if (!int.TryParse(textBoxCollectionID.Text, out cid))
			{
				MessageBox.Show("Collection ID is not valid");
				return;
			}
			string nodeType = treeViewMapping.SelectedNode.Text.Substring(6, 4);
			string nodeExportType = "b" + nodeType.ToLower();
			OpenFileDialog ofd = new OpenFileDialog();
			ofd.Filter = nodeType + " File(*." + nodeExportType + ")|*." + nodeExportType;
			if (ofd.ShowDialog() == DialogResult.OK)
			{
				Console.Write("Inserting " + nodeType + " File (\"" + Path.GetFileName(ofd.FileName) + "\")... ");
				Sawndz.replaceBRSARSubfile(ofd.FileName, gid, cid);
				loadTreeView();
				selectNode(gid, cid);
			}
			else
			{
				Console.WriteLine("Importing " + nodeType + " File... Operation Cancelled!");
			}
		}

		private void backgroundWorkerCreateBRWSD_DoWork(object sender, DoWorkEventArgs e)
		{
			Sawndz.createBRSARSubfile(int.Parse(textBoxGroupID.Text), int.Parse(textBoxCollectionID.Text), e.Argument as string);
		}
		private void backgroundWorkerCreateBRWSD_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
		{
			enableStuff();
		}

		private void Form1_DragEnter(object sender, DragEventArgs e)
		{
			if (!this.CanFocus)
			{
				this.Cursor = Cursors.No;
				e.Effect = DragDropEffects.None;
				return;
			}
			if (e.Data.GetDataPresent(DataFormats.FileDrop))
			{
				e.Effect = DragDropEffects.All;
			}
			else
			{
				e.Effect = DragDropEffects.None;
			}
			disableStuff();
		}

		private void Form1_DragLeave(object sender, EventArgs e)
		{
			if (!this.CanFocus)
			{
				this.Cursor = Cursors.Default;
				return;
			}
			enableStuff();
		}

		private void Form1_DragDrop(object sender, DragEventArgs e)
		{
			if (!this.CanFocus)
			{
				this.Cursor = Cursors.Default;
				return;
			}
			string[] strings = (string[])e.Data.GetData(DataFormats.FileDrop, false);

			if (strings.Length > 0)
			{
				string fileKind = Path.GetExtension(strings[0]);
				bool doProcess = true;
				foreach (string fileName in strings)
				{
					if (Path.GetExtension(fileName) != fileKind)
					{
						doProcess = false;
						break;
					}
				}
				if (doProcess)
				{
					if (fileKind == ".brsar")
					{
						loadBRSAR(strings[0]);
					}
					else if (fileKind == ".sawnd")
					{
						if (brsar.GetRSAR() != null)
						{
							if (strings.Length == 1)
							{
								textBoxInputFile.Text = strings[0];
								audioPlaybackPanelWav.TargetSource = null;
								buttonInsert_Click(this, EventArgs.Empty);
							}
							else
							{
								if (Sawndz.createSAWNDToImportList("toImport.txt", strings))
								{
									backgroundWorkerMultiInsertSawnd.RunWorkerAsync();
									enableStuff();
								}
								else
								{
									Console.WriteLine("Unable to import .sawnd file(s), couldn't generate list!");
								}
							}
						}
						else
						{
							Console.WriteLine("Unable to import .sawnd file(s), no BRSAR is loaded!");
						}
					}
					else
					{
						MessageBox.Show("Note: There is no drag and drop functionality for this file type (\"" + fileKind + "\")!");
					}
				}
				else
				{
					MessageBox.Show("Error: Drag only one type of file (eg. .brsar or .sawnd) at a time!");
				}
			}
		}
		private void editLoopPropertiesToolStripMenuItem_Click(object sender, EventArgs e)
		{
			MappingItem selectedNode = treeViewMapping.SelectedNode as MappingItem;
			if (selectedNode != null)
			{
				textBoxOutput.Clear();
				if (Sawndz.reloopWAV(selectedNode.groupID, selectedNode.collectionID, selectedNode.wavID))
				{
					brsar.ReloadRSAR(true);
					treeViewMapping.SelectedNode = null;
					treeViewMapping.SelectedNode = selectedNode;
				}
			}
		}

		//About window
		private void aboutToolStripMenuItem1_Click(object sender, EventArgs e)
		{
			MessageBox.Show("Super Sawndz Version: " + Properties.Resources.Version + "\n" +
				"Created by Agoaj (http://http://agoaj.com/blog)\n" +
				"Modified by QuickLava (https://github.com/QuickLava)\n" +
				"Uses BrawlLib: https://github.com/soopercool101/BrawlCrate \n" +
				"Formerly Based off of Sawndz 0.12 (2010-2011 Jaklub)\n" +
				"Currently Based off of lavaResawndz 1.2.8 (2022 QuickLava)\n" +
				"Special thanks to mastaklo, ssbbtailsfan, stickman, VILE\n");
		}

		private void toolStripMenuItemWAVEID_Click(object sender, EventArgs e)
		{
			MappingItem selectedNode = treeViewMapping.SelectedNode as MappingItem;
			if (selectedNode != null)
			{
				textBoxOutput.Clear();
				Console.Write("Editing Associated WAVE ID... ");
				SoundWAVERemapForm soundProps = new SoundWAVERemapForm(selectedNode.groupID, selectedNode.collectionID, selectedNode.infoIndex);
				if (soundProps.initSuccessful)
				{
					if (soundProps.ShowDialog() == DialogResult.OK)
					{
						Console.WriteLine("Success!");
						brsar.ReloadRSAR(true);
						int selectedGroupID = selectedNode.groupID;
						int selectedCollID = selectedNode.collectionID;
						int selectedInfoIndex = selectedNode.infoIndex;
						loadTreeView();
						selectNode(selectedGroupID, selectedCollID, selectedInfoIndex);
					}
					else
					{
						Console.WriteLine("Operation Cancelled!");
					}
				}
			}
		}

		private void comboBoxSearchMode_SelectedIndexChanged(object sender, EventArgs e)
		{
			currSearchResults = null;
		}

		private void collectSearchResultsFromDict(Dictionary<string, List<MappingItem>> toSearch, string searchCriteria, int searchMethod, bool ignoreCase)
		{
			string evalString;
			bool evalResult = false;
			foreach (var entry in toSearch)
			{
				evalString = entry.Key;
				if (ignoreCase)
				{
					evalString = evalString.ToLower();
				}
				switch (searchMethod)
				{
					case 0:
						{
							evalResult = evalString.Contains(searchCriteria);
							break;
						}
					case 1:
						{
							evalResult = evalString.StartsWith(searchCriteria);
							break;
						}
					case 2:
						{
							evalResult = evalString.EndsWith(searchCriteria);
							break;
						}
					case 3:
						{
							try
							{
								System.Text.RegularExpressions.Regex expression = new System.Text.RegularExpressions.Regex(searchCriteria);
							}
							catch
							{
								MessageBox.Show("Provided Regular Expression:\n\t" + searchCriteria + "\nwas invalid! Skipping search.");
								return;
							}
							evalResult = System.Text.RegularExpressions.Regex.IsMatch(evalString, searchCriteria);
							break;
						}
					default:
						{
							break;
						}
				}

				if (evalResult)
				{
					foreach (MappingItem match in entry.Value)
					{
						MappingItem matchGroupEval = match;
						while (matchGroupEval.Parent != null)
						{
							matchGroupEval = matchGroupEval.Parent as MappingItem;
						}
						if (treeViewMapping.Nodes.Contains(matchGroupEval))
						{
							currSearchResults.Add(new KeyValuePair<string, MappingItem>(entry.Key, match));
						}
					}
				}
			}
		}
		private bool populateSearchResults()
		{
			bool somethingFound = false;
			if (!string.IsNullOrEmpty(textBoxSearchBar.Text) && treeViewMapping.Nodes.Count > 0)
			{
				string searchCriteria = textBoxSearchBar.Text;
				if ((comboBoxSearchMode.SelectedItem.ToString() != "RegEx") && !checkBoxSearchCase.Checked)
				{
					searchCriteria = searchCriteria.ToLower();
				}

				if (currSearchResults == null)
				{
					currSearchResults = new List<KeyValuePair<string, MappingItem>>();
					if (checkBoxSearchGroups.Checked)
					{
						collectSearchResultsFromDict(brsar.groupDict, searchCriteria, comboBoxSearchMode.SelectedIndex, !checkBoxSearchCase.Checked);
					}
					if (checkBoxSearchSounds.Checked)
					{
						collectSearchResultsFromDict(brsar.soundDict, searchCriteria, comboBoxSearchMode.SelectedIndex, !checkBoxSearchCase.Checked);
					}
					currSearchResultIndex = int.MaxValue;
				}
				
				somethingFound = currSearchResults.Count > 0;
			}
			return somethingFound;
		}
		private bool selectNextSearchResult(bool goBackwards = false)
		{
			bool result = false;

			if (currSearchResults != null && currSearchResults.Count > 0)
			{
				if (currSearchResultIndex == int.MaxValue)
				{
					if (goBackwards)
					{
						currSearchResultIndex = currSearchResults.Count - 1;
					}
					else
					{
						currSearchResultIndex = 0;
					}
				}
				else
				{
					if (goBackwards)
					{
						currSearchResultIndex--;
					}
					else
					{
						currSearchResultIndex++;
					}
				}
				if (currSearchResultIndex >= currSearchResults.Count())
				{
					currSearchResultIndex = 0;
				}
				if (currSearchResultIndex < 0)
				{
					currSearchResultIndex = currSearchResults.Count - 1;
				}
				treeViewMapping.SelectedNode = null;
				treeViewMapping.SelectedNode = currSearchResults.ElementAt(currSearchResultIndex).Value;
				result = true;
			}

			return result;
		}
		private bool doFind(bool goBackwards = false)
		{
			bool result = false;
			if (populateSearchResults())
			{
				result = selectNextSearchResult(goBackwards);
			}
			return result;
		}
		private void textBoxSearchBar_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Enter)
			{
				if ((Control.ModifierKeys & Keys.Control) == Keys.Control)
				{
					e.SuppressKeyPress = true;
					this.BeginInvoke(new Action(() => buttonFindAll_Click(null, null)));
				}
				else if (doFind((Control.ModifierKeys & Keys.Shift) == Keys.Shift))
				{
					e.SuppressKeyPress = true;
				}
			}
		}

		private void textBoxSearchBar_TextChanged(object sender, EventArgs e)
		{
			currSearchResults = null;
		}

		private void checkBoxSearchGroups_CheckedChanged(object sender, EventArgs e)
		{
			currSearchResults = null;
		}

		private void checkBoxSearchSounds_CheckedChanged(object sender, EventArgs e)
		{
			currSearchResults = null;
		}

		private void checkBoxSearchCase_CheckedChanged(object sender, EventArgs e)
		{
			currSearchResults = null;
		}

		private void buttonFind_Click(object sender, EventArgs e)
		{
			if (!doFind())
			{
				SystemSounds.Exclamation.Play();
			}
		}

		private void buttonFindBack_Click(object sender, EventArgs e)
		{
			if (!doFind(true))
			{
				SystemSounds.Exclamation.Play();
			}
		}

		private void buttonFindAll_Click(object sender, EventArgs e)
		{
			if (populateSearchResults())
			{
				FindAllForm fAF = new FindAllForm(currSearchResults);
				if (fAF.ShowDialog() == DialogResult.OK)
				{
					treeViewMapping.SelectedNode = null;
					treeViewMapping.SelectedNode = currSearchResults[fAF.treeViewMapping.SelectedNode.Index].Value;
				}
			}
			else
			{
				SystemSounds.Exclamation.Play();
			}
		}

		private void buttonExpand_Click(object sender, EventArgs e)
		{
			treeViewMapping.ExpandAll();
			treeViewMapping.SelectedNode = null;
		}

		private void buttonCollapse_Click(object sender, EventArgs e)
		{
			treeViewMapping.CollapseAll();
			treeViewMapping.SelectedNode = null;
		}

		private void Form1_Activated(object sender, EventArgs e)
		{
			if (interruptedMainAudioPanelPlayback)
			{
				audioPlaybackBRSARSound.Play();
				interruptedMainAudioPanelPlayback = false;
			}
			if (interruptedImportAudioPanelPlayback)
			{
				audioPlaybackPanelWav.Play();
				interruptedImportAudioPanelPlayback = false;
			}
		}
		private void Form1_Deactivate(object sender, EventArgs e)
		{
			if (!CanFocus)
			{
				if (audioPlaybackBRSARSound.IsPlaying)
				{
					audioPlaybackBRSARSound.Stop();
					interruptedMainAudioPanelPlayback = true;
				}
				if (audioPlaybackPanelWav.IsPlaying)
				{
					audioPlaybackPanelWav.Stop();
					interruptedImportAudioPanelPlayback = true;
				}
			}
		}


		// Tab-Related Functions
		// Managing Tab Settings
		private bool getCurrTabSettingsFromSettings()
		{
			bool success = false;

			int tabConfigIndex = TabConfiguration.getCurrentBRSARSettingsIndex(brsar.GetRSAR());
			if (tabConfigIndex >= 0 && tabConfigIndex < Properties.Settings.Default.TabSettings.Count)
			{
				currTabSettings = new TabConfiguration(Properties.Settings.Default.TabSettings[tabConfigIndex]);
				success = true;
			}

			return success;
		}
		private void buildCurrTabSettings()
		{
			BrawlLib.SSBB.ResourceNodes.RSARNode currRSAR = brsar.GetRSAR();
			if (currRSAR != null)
			{
				if (currTabSettings == null)
				{
					currTabSettings = new TabConfiguration();
				}
				currTabSettings.brsarGroupCount = currRSAR.FindChildrenByType("", BrawlLib.SSBB.ResourceNodes.ResourceType.RSARGroup).Length;
				currTabSettings.brsarFileCount = currRSAR.Files.Count;
				currTabSettings.tabEntries.Clear();
				for (int i = 1; i < tabControl1.TabPages.Count - 1; i++)
				{
					currTabSettings.tabEntries.Add(new TabConfigurationTabEntry());
					currTabSettings.tabEntries.Last().tabName = tabControl1.TabPages[i].Text;
					foreach (MappingItem groupInTab in reserveCollections[i])
					{
						currTabSettings.tabEntries.Last().includedGroupIDs.Add((uint)groupInTab.groupID);
					}
				}
			}
		}
		private void applyRelevantTabSettings(bool reloadTabSettings = false)
		{
			BrawlLib.SSBB.ResourceNodes.RSARNode currRSAR = brsar.GetRSAR();
			if (currRSAR != null)
			{
				reserveCollections.Clear();
				reserveCollections.Add(new List<MappingItem>());
				reserveCollections[0].AddRange(treeViewMapping.Nodes.Cast<MappingItem>().ToList());
				int toRemove = tabControl1.TabPages.Count - 2;
				for (int i = 0; i < toRemove; i++)
				{
					tabControl1.TabPages.RemoveAt(1);
				}

				if (reloadTabSettings)
				{
					if (!getCurrTabSettingsFromSettings())
					{
						buildCurrTabSettings();
					}
				}

				// For each tab in the loaded config...
				foreach (TabConfigurationTabEntry tab in currTabSettings.tabEntries)
				{
					// Add a node list for it.
					reserveCollections.Add(new List<MappingItem>());
					// Then, initialize an iterator for going through the initial list containing all nodes.
					int baseNodeListItr = 0;
					// Then iterate through the current tabs list of Group IDs...
					for (int i = 0; i < tab.includedGroupIDs.Count; i++)
					{
						// ... and make sure the current group ID isn't somehow lower than the current main list ID.
						// The IDs in the main list are strictly increasing, so if this is the case you'll never find a match.
						if ((uint)reserveCollections[0][baseNodeListItr].groupID > tab.includedGroupIDs[i])
						{
							// Thus, we can safely abort.
							break;
						}
						// Otherwise, we can simply continue iterating through the full list until we find the ID we're looking for.
						bool foundTargetGroup = false;
						while (!foundTargetGroup && baseNodeListItr < reserveCollections[0].Count)
						{
							if ((uint)reserveCollections[0][baseNodeListItr].groupID == tab.includedGroupIDs[i])
							{
								reserveCollections.Last().Add(reserveCollections[0][baseNodeListItr]);
								foundTargetGroup = true;
							}
							baseNodeListItr++;
						}
					}
					foreach (MappingItem inTab in reserveCollections.Last())
					{
						reserveCollections[0].Remove(inTab);
						treeViewMapping.Nodes.Remove(inTab);
					}
					tabControl1.TabPages.Insert(tabControl1.TabCount - 1, tab.tabName);
					tabControl1.TabPages[tabControl1.TabCount - 2].ContextMenuStrip = contextMenuStripTab;
				}
				generateGroupContextMenuItems();
				setTabRearrangeButtonState();
			}
		}
		// Managing Underlying Group-Collections
		private void loadActiveCollectionIntoTreeview()
		{
			if (currCollectionIndex < reserveCollections.Count)
			{
				treeViewMapping.Nodes.Clear();
				treeViewMapping.Nodes.AddRange(reserveCollections[currCollectionIndex].Cast<MappingItem>().ToArray());
				currSearchResults = null;
			}
		}
		private void setLoadedCollection(int index)
		{
			if (index >= reserveCollections.Count)
			{
				index = reserveCollections.Count;
				reserveCollections.Add(new List<MappingItem>());
			}
			if (index != currCollectionIndex)
			{
				List<MappingItem> temp = new List<MappingItem>();
				temp.AddRange(treeViewMapping.Nodes.Cast<MappingItem>().ToList());
				if (currCollectionIndex < reserveCollections.Count)
				{
					reserveCollections[currCollectionIndex] = temp;
				}
				currCollectionIndex = index;
				loadActiveCollectionIntoTreeview();
			}
		}
		private void mergeCollectionIntoLowerNeighbor(int index)
		{
			if (index > 0 && index < reserveCollections.Count)
			{
				reserveCollections[index - 1].AddRange(reserveCollections[index]);
				reserveCollections[index - 1].Sort(MappingItem.compareMappingItems);
				if (currCollectionIndex == (index - 1))
				{
					loadActiveCollectionIntoTreeview();
				}
			}
		}
		private void closeCollection(int index)
		{
			if (index > 0 && index < reserveCollections.Count)
			{
				mergeCollectionIntoLowerNeighbor(index);
				reserveCollections.RemoveAt(index);
				generateGroupContextMenuItems();
				if (currCollectionIndex == index)
				{
					setLoadedCollection(index - 1);
				}
			}
		}
		private void closeAllButFirstCollection()
		{
			for (int i = reserveCollections.Count - 1; i > 0; i--)
			{
				closeCollection(i);
			}
		}

		private bool moveSelectedItemToCollection(int index)
		{
			bool result = false;
			if (index >= reserveCollections.Count)
			{
				index = reserveCollections.Count;
				reserveCollections.Add(new List<MappingItem>());
			}
			if (index != currCollectionIndex)
			{
				MappingItem selected = treeViewMapping.SelectedNode as MappingItem;
				treeViewMapping.Nodes.Remove(selected);
				reserveCollections[index].Add(selected);
				reserveCollections[index].Sort(MappingItem.compareMappingItems);
			}
			return result;
		}
		// Managing Context Menus
		private void generateGroupContextMenuItems()
		{
			contextMenuStripGroup.Items.Clear();
			for (int i = 0; i < (tabControl1.TabCount - 1); i++)
			{
				if (i != tabControl1.SelectedIndex)
				{
					System.Windows.Forms.ToolStripMenuItem temp = new System.Windows.Forms.ToolStripMenuItem("Move to \'" + tabControl1.TabPages[i].Text + "\'", null, moveToToolStripMenuItem_Click);
					temp.Tag = i;
					contextMenuStripGroup.Items.Add(temp);
				}
			}
		}
		// Managing Tab UI
		private void createTab()
		{
			tabControl1.TabPages.Insert(tabControl1.TabCount - 1, "Tab " + tabControl1.TabCount.ToString());
			tabControl1.SelectedIndex = tabControl1.TabCount - 2;
			tabControl1.TabPages[tabControl1.SelectedIndex].ContextMenuStrip = contextMenuStripTab;
			generateGroupContextMenuItems();
			buildCurrTabSettings();
			setTabRearrangeButtonState();
		}
		private void closeTab(int tabIndex)
		{
			if (tabIndex > 0 && tabIndex < (tabControl1.TabCount - 1))
			{
				if (tabIndex == currCollectionIndex)
				{
					tabControl1.SelectedIndex = tabIndex - 1;
				}
				closeCollection(tabIndex);
				tabControl1.TabPages.Remove(tabControl1.TabPages[tabIndex]);
				generateGroupContextMenuItems();
				buildCurrTabSettings();
			}
			setTabRearrangeButtonState();
		}
		private void renameTab(int tabIndex)
		{
			if (tabIndex > 0 && tabIndex < (tabControl1.TabCount - 1))
			{
				TextInputForm testForm = new TextInputForm("" + TabConfiguration.GroupDelimiter + TabConfiguration.TabDelimiter);
				testForm.textBox1.Text = tabControl1.TabPages[tabIndex].Text;
				if (testForm.ShowDialog() == DialogResult.OK)
				{
					tabControl1.TabPages[tabIndex].Text = testForm.textBox1.Text;
					buildCurrTabSettings();
					generateGroupContextMenuItems();
				}
			}
		}
		private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (tabControl1.SelectedIndex == (tabControl1.TabCount - 1))
			{
				createTab();
			}
			else
			{
				setLoadedCollection(tabControl1.SelectedIndex);
				textBoxGroupID.Clear();
				textBoxCollectionID.Clear();
				textBoxWavID.Clear();
				textBoxInfoIndex.Clear();
				generateGroupContextMenuItems();
			}
		}
		private void moveToToolStripMenuItem_Click(object sender, EventArgs e)
		{
			moveSelectedItemToCollection((int)((System.Windows.Forms.ToolStripMenuItem)sender).Tag);
			buildCurrTabSettings();
		}
		private void tabControl1_MouseDown(object sender, MouseEventArgs e)
		{
			if (e.Button == MouseButtons.Right)
			{
				int targetTab = -1;
				for (int i = 0; i < tabControl1.TabCount - 1; i++)
				{
					if (tabControl1.GetTabRect(i).Contains(e.Location))
					{
						targetTab = i;
						break;
					}
				}
				if (targetTab != -1)
				{
					contextMenuStripTab.Items[0].Enabled = targetTab > 0;
					contextMenuStripTab.Items[1].Enabled = targetTab > 0;
					TabPage targetTabPage = tabControl1.TabPages[targetTab];
					Point contextMenuSpawnOffset = new Point(tabControl1.GetTabRect(targetTab).Left, tabControl1.GetTabRect(targetTab).Top);
					targetTabPage.ContextMenuStrip.Show(targetTabPage, contextMenuSpawnOffset);
					currRightClickedTab = targetTab;
				}
			}
		}
		private void closeTabToolStripMenuItem_Click(object sender, EventArgs e)
		{
			closeTab(currRightClickedTab);
			currRightClickedTab = -1;
		}
		private void contextMenuStripTab_Closed(object sender, ToolStripDropDownClosedEventArgs e)
		{
			if (e.CloseReason != ToolStripDropDownCloseReason.ItemClicked)
			{
				currRightClickedTab = -1;
			}
		}
		private void renameToolStripMenuItem_Click(object sender, EventArgs e)
		{
			if (currRightClickedTab > 0 && currRightClickedTab < (tabControl1.TabCount - 1))
			{
				renameTab(currRightClickedTab);
			}
		}
		private void buttonRearrangeTabs_Click(object sender, EventArgs e)
		{
			if (currTabSettings != null)
			{
				ManageTabsForm rtf = new ManageTabsForm(currTabSettings);
				if (rtf.ShowDialog() == DialogResult.OK)
				{
					currTabSettings = rtf.loadedTabs;
					loadTreeView();
				}
			}
		}


		private void Form1_KeyDown(object sender, KeyEventArgs e)
		{
			if ((Control.ModifierKeys & Keys.Control) == Keys.Control)
			{
				if (e.KeyCode == Keys.F)
				{
					textBoxSearchBar.Select();
					textBoxSearchBar.SelectAll();
				}
				else if (e.KeyCode == Keys.R)
				{
					if (tabControl1.SelectedIndex > 0 && tabControl1.SelectedIndex < (tabControl1.TabCount - 1))
					{
						e.SuppressKeyPress = true;
						this.BeginInvoke(new Action(() => renameTab(tabControl1.SelectedIndex)));
					}
				}
				else if (e.KeyCode == Keys.W)
				{
					if (tabControl1.SelectedIndex > 0 && tabControl1.SelectedIndex < (tabControl1.TabCount - 1))
					{
						closeTab(tabControl1.SelectedIndex);
						treeViewMapping.Select();
						e.SuppressKeyPress = true;
					}
				}
				else if (e.KeyCode == Keys.T)
				{
					createTab();
					treeViewMapping.Select();
					e.SuppressKeyPress = true;
				}
				else if (e.KeyCode == Keys.Left || ((Control.ModifierKeys & Keys.Shift) == Keys.Shift && e.KeyCode == Keys.Tab))
				{
					if (tabControl1.SelectedIndex > 0)
					{
						tabControl1.SelectedIndex--;
						treeViewMapping.Select();
					}
					else if (tabControl1.TabCount > 2)
					{
						tabControl1.SelectedIndex = tabControl1.TabCount - 2;
						treeViewMapping.Select();
					}
					e.SuppressKeyPress = true;
				}
				else if (e.KeyCode == Keys.Right || e.KeyCode == Keys.Tab)
				{
					if (tabControl1.SelectedIndex < (tabControl1.TabCount - 2))
					{
						tabControl1.SelectedIndex++;
						treeViewMapping.Select();
					}
					else if (tabControl1.TabCount > 2)
					{
						tabControl1.SelectedIndex = 0;
						treeViewMapping.Select();
					}
					e.SuppressKeyPress = true;
				}
				else if (e.KeyCode == Keys.Up)
				{
					tabControl1.SelectedIndex = 0;
					treeViewMapping.Select();
					e.SuppressKeyPress = true;
				}
				else if (e.KeyCode == Keys.Down)
				{
					tabControl1.SelectedIndex = tabControl1.TabCount - 2;
					treeViewMapping.Select();
					e.SuppressKeyPress = true;
				}
			}
		}

		void deleteTemporaryWavs()
		{
			if (File.Exists(Properties.Resources.tempAudioTypeConvPath))
			{
				File.Delete(Properties.Resources.tempAudioTypeConvPath);
			}
			if (File.Exists(Properties.Resources.tempAudioResamplePath))
			{
				File.Delete(Properties.Resources.tempAudioResamplePath);
			}
		}

		private void Form1_FormClosing(object sender, FormClosingEventArgs e)
		{
			deleteTemporaryWavs();
		}
		private void Form1_Shown(object sender, EventArgs e)
		{
			deleteTemporaryWavs();
		}

		private void bulkCollectionExportToolStripMenuItem_Click(object sender, EventArgs e)
		{
			multiCollectionExportForm mCEF = new multiCollectionExportForm();
			textBoxOutput.Clear();
			Console.Write("Exporting Collections... ");
			if (mCEF.ShowDialog() == DialogResult.OK)
			{
				Console.WriteLine("Success!");
			}
			else
			{
				Console.WriteLine("Operation cancelled!");
			}
		}
	}
}
