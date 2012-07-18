﻿using System;
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
		string VERSION = "1.0.1";
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
			audioPlaybackBRSARSound.TargetSource = null;
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
				textBoxCollectionID.Text = item.collectionID.ToString();
			else
				textBoxCollectionID.Text = "";
			if( item.wavID > -1 )
			{
				textBoxWavID.Text = item.wavID.ToString();
				audioPlaybackBRSARSound.TargetSource = item as System.Audio.IAudioSource;
				audioPlaybackBRSARSound.Play();
			}
			else
				textBoxWavID.Text = "";
		}

		//Play sound if enter/return is pressed.
		private void treeViewMapping_KeyPress( object sender, KeyPressEventArgs e )
		{
			if(e.KeyChar == '\r' && audioPlaybackBRSARSound.TargetSource != null )
				audioPlaybackBRSARSound.Play();
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
						audioPlaybackPanelWav.TargetSource = new StreamSource( System.Audio.WAV.FromFile( ofd.FileName ) );
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
									Console.WriteLine( "Inserting wav " + Path.GetFileName(textBoxInputFile.Text) );
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
			audioPlaybackBRSARSound.Stop();
			textBoxGroupID.Enabled = false;
			textBoxCollectionID.Enabled = false;
			textBoxWavID.Enabled = false;
			audioPlaybackPanelWav.Stop();
			buttonBrowse.Enabled = false;
			buttonCreateSawnd.Enabled = false;
			buttonInsert.Enabled = false;
			treeViewMapping.Enabled = false;
			audioPlaybackPanelWav.Enabled = false;
			audioPlaybackBRSARSound.Enabled = false;
			brsar.CloseRSAR();
		}
		//Enable stuff again
		private void enableStuff()
		{
			buttonInsert.Enabled = true;
			textBoxGroupID.Enabled = true;
			textBoxCollectionID.Enabled = true;
			textBoxWavID.Enabled = true;
			treeViewMapping.Enabled = true;
			audioPlaybackPanelWav.Enabled = true;
			buttonBrowse.Enabled = true;
			audioPlaybackBRSARSound.Enabled = true;

			//Make sure that we have a group id before turning on create sawnd button
			int gid;
			buttonCreateSawnd.Enabled = int.TryParse( textBoxGroupID.Text, out gid );
		}

		//Called when the insert thread completes. Reloads the tree view or updates the specific node.
		private void backgroundWorkerInsert_RunWorkerCompleted( object sender, RunWorkerCompletedEventArgs e )
		{
			enableStuff();
			if( textBoxWavID.Text.Length > 0 && treeViewMapping.SelectedNode != null && Path.GetExtension( textBoxInputFile.Text ).CompareTo( ".wav" ) == 0 )
			{
				MappingItem item = treeViewMapping.SelectedNode as MappingItem;
				item.updateSize();
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
			MessageBox.Show( "Super Sawndz Version:" + VERSION +"\nCreated by Agoaj\nwww.agoaj.com\n" + 
				"Uses BrawlLib: http://code.google.com/p/brawltools2/ \n" + 
				"Based off of Sawndz 0.12\n2010-2011 Jaklub\nspecial thanks to mastaklo, ssbbtailsfan, stickman, VILE\n");
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

		//Check if we need to enable the create sawnd button, need Group ID for that to work.
		private void textBoxGroupID_TextChanged( object sender, EventArgs e )
		{
			int gid;
			buttonCreateSawnd.Enabled = int.TryParse( textBoxGroupID.Text, out gid );
		}

		private void backgroundWorkerCreateSawnd_RunWorkerCompleted( object sender, RunWorkerCompletedEventArgs e )
		{
			enableStuff();
		}
	}
}
