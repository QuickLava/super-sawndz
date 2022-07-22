using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
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

		//Fill out treeViewMapping with data from the brsar
		private void loadTreeView()
		{
			try
			{
				if( treeViewMapping.Nodes.Count > 0 )
					treeViewMapping.Nodes.Clear();
				brsar.LoadTreeView( treeViewMapping );
				treeViewMapping.Invalidate();
			}
			catch( Exception ex )
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
				brsar.GetRSAR();
				loadTreeView();
				enableStuff();
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
			audioPlaybackPanelWav.VolumePercent = 0.66;
			audioPlaybackBRSARSound.TargetSource = null;
			audioPlaybackBRSARSound.VolumePercent = 0.66;
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
				else if (Path.GetExtension(textBoxInputFile.Text).CompareTo(".wav") == 0)
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

		/*Called when a node is selected.
		 * Sets the textBox's for group id etc.
		 * autoplays the sound if there is one.
		*/
		private void treeViewMapping_AfterSelect( object sender, TreeViewEventArgs e )
		{
			audioPlaybackBRSARSound.TargetSource = null;
			MappingItem item = e.Node as MappingItem;
			if( item == null )
				return;
			if( item.groupID > -1 )
				textBoxGroupID.Text = item.groupID.ToString();
			else
				textBoxGroupID.Text = "";
			if( item.collectionID > -1 )
			{
				textBoxCollectionID.Text = item.collectionID.ToString();
				//buttonMultiCreateWAV.Enabled = true;
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
				textBoxWavID.Text = "";
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
			ofd.Filter = "Sound|*.wav;*.sawnd|Wave File(*.wav)|*.wav|Sawndz File(*.sawnd)|*.sawnd";

			if( ofd.ShowDialog() == System.Windows.Forms.DialogResult.OK )
			{
				textBoxInputFile.Text = ofd.FileName;
				if( Path.GetExtension( ofd.FileName ).CompareTo( ".wav" ) == 0 )
				{
					//If it's not a standard PCM style wav it'll throw an exception
					try
					{
						audioPlaybackPanelWav.TargetSource = new StreamSource( BrawlLib.Internal.Audio.WAV.FromFile( ofd.FileName ) );
					}
					catch( Exception ex )
					{
						Console.WriteLine( ex.ToString() );
					}
				}
				else
					audioPlaybackPanelWav.TargetSource = null;
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
					Console.WriteLine( "Inserting Sawnd " + Path.GetFileName( textBoxInputFile.Text ) );
					Sawndz.insertSawnd( textBoxInputFile.Text );
				}
				else if( Path.GetExtension( textBoxInputFile.Text ).CompareTo( ".wav" ) == 0 )
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

		//Disables buttons and treeview while sawndz is being run
		private void disableStuff()
		{
			textBoxGroupID.Enabled = false;
			textBoxCollectionID.Enabled = false;
			textBoxWavID.Enabled = false;
			buttonBrowse.Enabled = false;
			buttonCreateSawnd.Enabled = false;
			buttonCreateWAV.Enabled = false;
			buttonMultiCreateWAV.Enabled = false;
			buttonMultiExportSawnd.Enabled = false;
			buttonMultiInsertSawnd.Enabled = false;
			buttonInsert.Enabled = false;
			treeViewMapping.Enabled = false;
			audioPlaybackPanelWav.Enabled = false;
			audioPlaybackBRSARSound.Enabled = false;
			brsar.CloseRSAR();
		}
		//Enable stuff again
		private void enableStuff()
		{
			setInsertButtonState();
			textBoxGroupID.Enabled = true;
			textBoxCollectionID.Enabled = true;
			textBoxWavID.Enabled = true;
			treeViewMapping.Enabled = true;
			audioPlaybackPanelWav.Enabled = true;
			buttonBrowse.Enabled = true;
			audioPlaybackBRSARSound.Enabled = true;
			buttonMultiExportSawnd.Enabled = true;
			buttonMultiInsertSawnd.Enabled = true;

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
			if( textBoxWavID.Text.Length > 0 && treeViewMapping.SelectedNode != null && Path.GetExtension( textBoxInputFile.Text ).CompareTo( ".wav" ) == 0 )
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
				loadTreeView();
		}

		//Insert the wav or sawnd file
		private void backgroundWorkerInsert_DoWork( object sender, DoWorkEventArgs e )
		{
			insert();
		}

		//About window
		private void aboutToolStripMenuItem_Click( object sender, EventArgs e )
		{
			MessageBox.Show( "Super Sawndz Version: " + Properties.Resources.Version + "\n" +
				"Created by Agoaj (http://http://agoaj.com/blog)\n" +
				"Modified by QuickLava (https://github.com/QuickLava)\n" +
				"Uses BrawlLib: https://github.com/soopercool101/BrawlCrate \n" + 
				"Formerly Based off of Sawndz 0.12 (2010-2011 Jaklub)\n" +
				"Currently Based off of lavaResawndz 1.2.8 (2022 QuickLava)\n" +
				"Special thanks to mastaklo, ssbbtailsfan, stickman, VILE\n");
		}

		//Lets the user select a specific .brsar file
		private void openBRSARToolStripMenuItem_Click( object sender, EventArgs e )
		{
			OpenFileDialog ofd = new OpenFileDialog();
			ofd.Filter = "Sound Archive(*.brsar)|*.brsar";
			if( ofd.ShowDialog() == System.Windows.Forms.DialogResult.OK )
			{
				brsar.CloseRSAR();
				brsar.RSAR_FileName = ofd.FileName;
				loadTreeView();
				enableStuff();
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
			SaveFileDialog sfd = new SaveFileDialog();
			sfd.Filter = "*Sawnd File(*.sawnd)|*.sawnd";
			if( sfd.ShowDialog() == DialogResult.OK )
			{
				disableStuff();
				textBoxOutput.Clear();
				backgroundWorkerCreateSawnd.RunWorkerAsync(sfd.FileName);
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
			if (!int.TryParse(textBoxCollectionID.Text, out wid))
			{
				MessageBox.Show("WAV ID is not valid");
				return;
			}
			SaveFileDialog sfd = new SaveFileDialog();
			sfd.Filter = "*WAV File(*.wav)|*.wav";
			if (sfd.ShowDialog() == DialogResult.OK)
			{
				disableStuff();
				textBoxOutput.Clear();
				backgroundWorkerCreateWAV.RunWorkerAsync(sfd.FileName);
			}
		}
		private void buttonMultiExportSawnd_Click(object sender, EventArgs e)
		{
			textBoxOutput.Clear();
			multiSawndExportForm tempForm = new multiSawndExportForm(treeViewMapping);
			tempForm.ShowDialog();
		}
		private void buttonMultiImportSawnd_Click(object sender, EventArgs e)
		{
			OpenFileDialog ofd = new OpenFileDialog();
			ofd.Multiselect = true;
			ofd.Filter = "*Sawnd File(*.sawnd)|*.sawnd";
			if (ofd.ShowDialog() == DialogResult.OK)
			{
				StreamWriter importList = File.CreateText("toImport.txt");
				foreach (string str in ofd.FileNames)
				{
					importList.WriteLine(str);
				}
				importList.Close();
				backgroundWorkerMultiInsertSawnd.RunWorkerAsync();
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
			loadTreeView();
		}
		private void setCurrentBRSARAsDefaultToolStripMenuItem_Click(object sender, EventArgs e)
		{
			SettingsForm settings = new SettingsForm();
			if (settings.ShowDialog() == DialogResult.OK)
			{
				Properties.Settings.Default.Save();
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
			tempForm.ShowDialog();
		}

		private void buttonMultiInsertWAV_Click(object sender, EventArgs e)
		{
			OpenFileDialog ofd = new OpenFileDialog();
			ofd.Filter = "WAVE Map File(*.xml)|*.xml";

			if (ofd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
			{
				backgroundWorkerMultiInsertWAV.RunWorkerAsync(ofd.FileName);
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
	}
}
