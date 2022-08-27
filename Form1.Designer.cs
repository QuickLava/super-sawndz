namespace BrawlSoundConverter
{
	partial class Form1
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose( bool disposing )
		{
			if( disposing && ( components != null ) )
			{
				components.Dispose();
			}
			base.Dispose( disposing );
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			this.textBoxOutput = new System.Windows.Forms.TextBox();
			this.treeViewMapping = new System.Windows.Forms.TreeView();
			this.textBoxGroupID = new System.Windows.Forms.TextBox();
			this.textBoxCollectionID = new System.Windows.Forms.TextBox();
			this.textBoxWavID = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.textBoxInputFile = new System.Windows.Forms.TextBox();
			this.buttonBrowse = new System.Windows.Forms.Button();
			this.buttonInsert = new System.Windows.Forms.Button();
			this.label4 = new System.Windows.Forms.Label();
			this.backgroundWorkerInsert = new System.ComponentModel.BackgroundWorker();
			this.buttonCreateSawnd = new System.Windows.Forms.Button();
			this.backgroundWorkerCreateSawnd = new System.ComponentModel.BackgroundWorker();
			this.buttonCreateWAV = new System.Windows.Forms.Button();
			this.backgroundWorkerCreateWAV = new System.ComponentModel.BackgroundWorker();
			this.buttonMultiExportSawnd = new System.Windows.Forms.Button();
			this.buttonMultiInsertSawnd = new System.Windows.Forms.Button();
			this.backgroundWorkerMultiInsertSawnd = new System.ComponentModel.BackgroundWorker();
			this.buttonMultiCreateWAV = new System.Windows.Forms.Button();
			this.buttonMultiInsertWAV = new System.Windows.Forms.Button();
			this.backgroundWorkerMultiInsertWAV = new System.ComponentModel.BackgroundWorker();
			this.contextMenuStripWAV = new System.Windows.Forms.ContextMenuStrip(this.components);
			this.toolStripMenuItemSoundProps = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripMenuItemWAVEID = new System.Windows.Forms.ToolStripMenuItem();
			this.editLoopPropertiesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.contextMenuStripCollection = new System.Windows.Forms.ContextMenuStrip(this.components);
			this.toolStripMenuItemBRWSDExport = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripMenuItemBRWSDReplace = new System.Windows.Forms.ToolStripMenuItem();
			this.backgroundWorkerCreateBRWSD = new System.ComponentModel.BackgroundWorker();
			this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.openBRSARToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.toolsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.ChangeSettingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripMenuItemHelp = new System.Windows.Forms.ToolStripMenuItem();
			this.aboutToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
			this.menuStrip1 = new System.Windows.Forms.MenuStrip();
			this.label5 = new System.Windows.Forms.Label();
			this.textBoxSearchBar = new System.Windows.Forms.TextBox();
			this.label6 = new System.Windows.Forms.Label();
			this.comboBox1 = new System.Windows.Forms.ComboBox();
			this.checkBoxSearchGroups = new System.Windows.Forms.CheckBox();
			this.checkBoxSearchWAV = new System.Windows.Forms.CheckBox();
			this.checkBoxSearchCase = new System.Windows.Forms.CheckBox();
			this.audioPlaybackBRSARSound = new BrawlLib.Internal.Windows.Controls.AudioPlaybackPanel();
			this.audioPlaybackPanelWav = new BrawlLib.Internal.Windows.Controls.AudioPlaybackPanel();
			this.buttonFind = new System.Windows.Forms.Button();
			this.buttonFindAll = new System.Windows.Forms.Button();
			this.contextMenuStripWAV.SuspendLayout();
			this.contextMenuStripCollection.SuspendLayout();
			this.menuStrip1.SuspendLayout();
			this.SuspendLayout();
			// 
			// textBoxOutput
			// 
			this.textBoxOutput.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.textBoxOutput.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
			this.textBoxOutput.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
			this.textBoxOutput.Location = new System.Drawing.Point(20, 297);
			this.textBoxOutput.Margin = new System.Windows.Forms.Padding(4);
			this.textBoxOutput.Multiline = true;
			this.textBoxOutput.Name = "textBoxOutput";
			this.textBoxOutput.ReadOnly = true;
			this.textBoxOutput.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.textBoxOutput.Size = new System.Drawing.Size(883, 536);
			this.textBoxOutput.TabIndex = 1;
			// 
			// treeViewMapping
			// 
			this.treeViewMapping.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.treeViewMapping.FullRowSelect = true;
			this.treeViewMapping.HideSelection = false;
			this.treeViewMapping.Location = new System.Drawing.Point(933, 80);
			this.treeViewMapping.Margin = new System.Windows.Forms.Padding(4);
			this.treeViewMapping.Name = "treeViewMapping";
			this.treeViewMapping.Size = new System.Drawing.Size(629, 617);
			this.treeViewMapping.TabIndex = 3;
			this.treeViewMapping.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeViewMapping_AfterSelect);
			this.treeViewMapping.KeyDown += new System.Windows.Forms.KeyEventHandler(this.treeViewMapping_KeyDown);
			// 
			// textBoxGroupID
			// 
			this.textBoxGroupID.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.textBoxGroupID.Location = new System.Drawing.Point(771, 16);
			this.textBoxGroupID.Margin = new System.Windows.Forms.Padding(4);
			this.textBoxGroupID.Name = "textBoxGroupID";
			this.textBoxGroupID.Size = new System.Drawing.Size(132, 22);
			this.textBoxGroupID.TabIndex = 4;
			this.textBoxGroupID.TextChanged += new System.EventHandler(this.textBoxGroupID_TextChanged);
			// 
			// textBoxCollectionID
			// 
			this.textBoxCollectionID.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.textBoxCollectionID.Location = new System.Drawing.Point(771, 48);
			this.textBoxCollectionID.Margin = new System.Windows.Forms.Padding(4);
			this.textBoxCollectionID.Name = "textBoxCollectionID";
			this.textBoxCollectionID.Size = new System.Drawing.Size(132, 22);
			this.textBoxCollectionID.TabIndex = 5;
			this.textBoxCollectionID.TextChanged += new System.EventHandler(this.textBoxCollectionID_TextChanged);
			// 
			// textBoxWavID
			// 
			this.textBoxWavID.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.textBoxWavID.Location = new System.Drawing.Point(771, 80);
			this.textBoxWavID.Margin = new System.Windows.Forms.Padding(4);
			this.textBoxWavID.Name = "textBoxWavID";
			this.textBoxWavID.Size = new System.Drawing.Size(132, 22);
			this.textBoxWavID.TabIndex = 6;
			this.textBoxWavID.TextChanged += new System.EventHandler(this.textBoxWavID_TextChanged);
			// 
			// label1
			// 
			this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(692, 20);
			this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(65, 17);
			this.label1.TabIndex = 8;
			this.label1.Text = "Group ID";
			// 
			// label2
			// 
			this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(673, 52);
			this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(86, 17);
			this.label2.TabIndex = 9;
			this.label2.Text = "Collection ID";
			// 
			// label3
			// 
			this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(696, 84);
			this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(56, 17);
			this.label3.TabIndex = 10;
			this.label3.Text = "WAV ID";
			// 
			// textBoxInputFile
			// 
			this.textBoxInputFile.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.textBoxInputFile.Enabled = false;
			this.textBoxInputFile.Location = new System.Drawing.Point(23, 48);
			this.textBoxInputFile.Margin = new System.Windows.Forms.Padding(4);
			this.textBoxInputFile.Name = "textBoxInputFile";
			this.textBoxInputFile.Size = new System.Drawing.Size(565, 22);
			this.textBoxInputFile.TabIndex = 11;
			this.textBoxInputFile.TextChanged += new System.EventHandler(this.textBoxInputFile_TextChanged);
			// 
			// buttonBrowse
			// 
			this.buttonBrowse.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.buttonBrowse.Location = new System.Drawing.Point(597, 48);
			this.buttonBrowse.Margin = new System.Windows.Forms.Padding(4);
			this.buttonBrowse.Name = "buttonBrowse";
			this.buttonBrowse.Size = new System.Drawing.Size(33, 24);
			this.buttonBrowse.TabIndex = 12;
			this.buttonBrowse.Text = "...";
			this.buttonBrowse.UseVisualStyleBackColor = true;
			this.buttonBrowse.Click += new System.EventHandler(this.buttonBrowse_Click);
			// 
			// buttonInsert
			// 
			this.buttonInsert.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.buttonInsert.Enabled = false;
			this.buttonInsert.Location = new System.Drawing.Point(506, 81);
			this.buttonInsert.Margin = new System.Windows.Forms.Padding(4);
			this.buttonInsert.Name = "buttonInsert";
			this.buttonInsert.Size = new System.Drawing.Size(125, 28);
			this.buttonInsert.TabIndex = 13;
			this.buttonInsert.Text = "Insert";
			this.buttonInsert.UseVisualStyleBackColor = true;
			this.buttonInsert.Click += new System.EventHandler(this.buttonInsert_Click);
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(20, 28);
			this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(65, 17);
			this.label4.TabIndex = 15;
			this.label4.Text = "Input File";
			// 
			// backgroundWorkerInsert
			// 
			this.backgroundWorkerInsert.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorkerInsert_DoWork);
			this.backgroundWorkerInsert.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorkerInsert_RunWorkerCompleted);
			// 
			// buttonCreateSawnd
			// 
			this.buttonCreateSawnd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.buttonCreateSawnd.Enabled = false;
			this.buttonCreateSawnd.Location = new System.Drawing.Point(770, 116);
			this.buttonCreateSawnd.Margin = new System.Windows.Forms.Padding(4);
			this.buttonCreateSawnd.Name = "buttonCreateSawnd";
			this.buttonCreateSawnd.Size = new System.Drawing.Size(133, 28);
			this.buttonCreateSawnd.TabIndex = 17;
			this.buttonCreateSawnd.Text = "Create Sawnd";
			this.buttonCreateSawnd.UseVisualStyleBackColor = true;
			this.buttonCreateSawnd.Click += new System.EventHandler(this.buttonCreateSawnd_Click);
			// 
			// backgroundWorkerCreateSawnd
			// 
			this.backgroundWorkerCreateSawnd.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorkerCreateSawnd_DoWork);
			this.backgroundWorkerCreateSawnd.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorkerCreateSawnd_RunWorkerCompleted);
			// 
			// buttonCreateWAV
			// 
			this.buttonCreateWAV.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.buttonCreateWAV.Enabled = false;
			this.buttonCreateWAV.Location = new System.Drawing.Point(770, 186);
			this.buttonCreateWAV.Margin = new System.Windows.Forms.Padding(4);
			this.buttonCreateWAV.Name = "buttonCreateWAV";
			this.buttonCreateWAV.Size = new System.Drawing.Size(133, 28);
			this.buttonCreateWAV.TabIndex = 19;
			this.buttonCreateWAV.Text = "Create WAV";
			this.buttonCreateWAV.UseVisualStyleBackColor = true;
			this.buttonCreateWAV.Click += new System.EventHandler(this.buttonCreateWAV_Click);
			// 
			// backgroundWorkerCreateWAV
			// 
			this.backgroundWorkerCreateWAV.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorkerCreateWAV_DoWork);
			this.backgroundWorkerCreateWAV.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorkerCreateWAV_RunWorkerCompleted);
			// 
			// buttonMultiExportSawnd
			// 
			this.buttonMultiExportSawnd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.buttonMultiExportSawnd.Enabled = false;
			this.buttonMultiExportSawnd.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.7F);
			this.buttonMultiExportSawnd.Location = new System.Drawing.Point(770, 151);
			this.buttonMultiExportSawnd.Margin = new System.Windows.Forms.Padding(4);
			this.buttonMultiExportSawnd.Name = "buttonMultiExportSawnd";
			this.buttonMultiExportSawnd.Size = new System.Drawing.Size(132, 28);
			this.buttonMultiExportSawnd.TabIndex = 20;
			this.buttonMultiExportSawnd.Text = "Multi Create Sawnd";
			this.buttonMultiExportSawnd.UseVisualStyleBackColor = true;
			this.buttonMultiExportSawnd.Click += new System.EventHandler(this.buttonMultiExportSawnd_Click);
			// 
			// buttonMultiInsertSawnd
			// 
			this.buttonMultiInsertSawnd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.buttonMultiInsertSawnd.Enabled = false;
			this.buttonMultiInsertSawnd.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.4F);
			this.buttonMultiInsertSawnd.Location = new System.Drawing.Point(506, 116);
			this.buttonMultiInsertSawnd.Margin = new System.Windows.Forms.Padding(4);
			this.buttonMultiInsertSawnd.Name = "buttonMultiInsertSawnd";
			this.buttonMultiInsertSawnd.Size = new System.Drawing.Size(125, 28);
			this.buttonMultiInsertSawnd.TabIndex = 21;
			this.buttonMultiInsertSawnd.Text = "Multi Insert Sawnd";
			this.buttonMultiInsertSawnd.UseVisualStyleBackColor = true;
			this.buttonMultiInsertSawnd.Click += new System.EventHandler(this.buttonMultiImportSawnd_Click);
			// 
			// backgroundWorkerMultiInsertSawnd
			// 
			this.backgroundWorkerMultiInsertSawnd.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorkerMultiInsertSawnd_DoWork);
			this.backgroundWorkerMultiInsertSawnd.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorkerMultiInsertSawnd_RunWorkerCompleted);
			// 
			// buttonMultiCreateWAV
			// 
			this.buttonMultiCreateWAV.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.buttonMultiCreateWAV.Enabled = false;
			this.buttonMultiCreateWAV.Location = new System.Drawing.Point(770, 221);
			this.buttonMultiCreateWAV.Margin = new System.Windows.Forms.Padding(4);
			this.buttonMultiCreateWAV.Name = "buttonMultiCreateWAV";
			this.buttonMultiCreateWAV.Size = new System.Drawing.Size(133, 28);
			this.buttonMultiCreateWAV.TabIndex = 22;
			this.buttonMultiCreateWAV.Text = "Multi Create WAV";
			this.buttonMultiCreateWAV.UseVisualStyleBackColor = true;
			this.buttonMultiCreateWAV.Click += new System.EventHandler(this.buttonMultiCreateWAV_Click);
			// 
			// buttonMultiInsertWAV
			// 
			this.buttonMultiInsertWAV.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.buttonMultiInsertWAV.Enabled = false;
			this.buttonMultiInsertWAV.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.4F);
			this.buttonMultiInsertWAV.Location = new System.Drawing.Point(506, 151);
			this.buttonMultiInsertWAV.Margin = new System.Windows.Forms.Padding(4);
			this.buttonMultiInsertWAV.Name = "buttonMultiInsertWAV";
			this.buttonMultiInsertWAV.Size = new System.Drawing.Size(125, 28);
			this.buttonMultiInsertWAV.TabIndex = 23;
			this.buttonMultiInsertWAV.Text = "Multi Insert WAV";
			this.buttonMultiInsertWAV.UseVisualStyleBackColor = true;
			this.buttonMultiInsertWAV.Click += new System.EventHandler(this.buttonMultiInsertWAV_Click);
			// 
			// backgroundWorkerMultiInsertWAV
			// 
			this.backgroundWorkerMultiInsertWAV.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorkerMultiInsertWAV_DoWork);
			this.backgroundWorkerMultiInsertWAV.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorkerMultiInsertWAV_RunWorkerCompleted);
			// 
			// contextMenuStripWAV
			// 
			this.contextMenuStripWAV.ImageScalingSize = new System.Drawing.Size(20, 20);
			this.contextMenuStripWAV.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItemSoundProps,
            this.toolStripMenuItemWAVEID,
            this.editLoopPropertiesToolStripMenuItem});
			this.contextMenuStripWAV.Name = "contextMenuStripWAV";
			this.contextMenuStripWAV.Size = new System.Drawing.Size(262, 76);
			// 
			// toolStripMenuItemSoundProps
			// 
			this.toolStripMenuItemSoundProps.Name = "toolStripMenuItemSoundProps";
			this.toolStripMenuItemSoundProps.Size = new System.Drawing.Size(261, 24);
			this.toolStripMenuItemSoundProps.Text = "Edit Sound Properties";
			this.toolStripMenuItemSoundProps.Click += new System.EventHandler(this.toolStripMenuItemSoundProps_Click);
			// 
			// toolStripMenuItemWAVEID
			// 
			this.toolStripMenuItemWAVEID.Name = "toolStripMenuItemWAVEID";
			this.toolStripMenuItemWAVEID.Size = new System.Drawing.Size(261, 24);
			this.toolStripMenuItemWAVEID.Text = "Edit Associated WAVE ID";
			this.toolStripMenuItemWAVEID.Click += new System.EventHandler(this.toolStripMenuItemWAVEID_Click);
			// 
			// editLoopPropertiesToolStripMenuItem
			// 
			this.editLoopPropertiesToolStripMenuItem.Name = "editLoopPropertiesToolStripMenuItem";
			this.editLoopPropertiesToolStripMenuItem.Size = new System.Drawing.Size(261, 24);
			this.editLoopPropertiesToolStripMenuItem.Text = "Edit Associated WAVE Loop";
			this.editLoopPropertiesToolStripMenuItem.Click += new System.EventHandler(this.editLoopPropertiesToolStripMenuItem_Click);
			// 
			// contextMenuStripCollection
			// 
			this.contextMenuStripCollection.ImageScalingSize = new System.Drawing.Size(20, 20);
			this.contextMenuStripCollection.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItemBRWSDExport,
            this.toolStripMenuItemBRWSDReplace});
			this.contextMenuStripCollection.Name = "contextMenuStripCollection";
			this.contextMenuStripCollection.Size = new System.Drawing.Size(219, 52);
			// 
			// toolStripMenuItemBRWSDExport
			// 
			this.toolStripMenuItemBRWSDExport.Name = "toolStripMenuItemBRWSDExport";
			this.toolStripMenuItemBRWSDExport.Size = new System.Drawing.Size(218, 24);
			this.toolStripMenuItemBRWSDExport.Text = "Export as BRWSD";
			this.toolStripMenuItemBRWSDExport.Click += new System.EventHandler(this.toolStripMenuItemBRWSDExport_Click);
			// 
			// toolStripMenuItemBRWSDReplace
			// 
			this.toolStripMenuItemBRWSDReplace.Name = "toolStripMenuItemBRWSDReplace";
			this.toolStripMenuItemBRWSDReplace.Size = new System.Drawing.Size(218, 24);
			this.toolStripMenuItemBRWSDReplace.Text = "Replace with BRWSD";
			this.toolStripMenuItemBRWSDReplace.Click += new System.EventHandler(this.toolStripMenuItemBRWSDReplace_Click);
			// 
			// backgroundWorkerCreateBRWSD
			// 
			this.backgroundWorkerCreateBRWSD.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorkerCreateBRWSD_DoWork);
			this.backgroundWorkerCreateBRWSD.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorkerCreateBRWSD_RunWorkerCompleted);
			// 
			// fileToolStripMenuItem
			// 
			this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openBRSARToolStripMenuItem});
			this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
			this.fileToolStripMenuItem.Size = new System.Drawing.Size(46, 24);
			this.fileToolStripMenuItem.Text = "File";
			// 
			// openBRSARToolStripMenuItem
			// 
			this.openBRSARToolStripMenuItem.Name = "openBRSARToolStripMenuItem";
			this.openBRSARToolStripMenuItem.Size = new System.Drawing.Size(177, 26);
			this.openBRSARToolStripMenuItem.Text = "Open BRSAR";
			this.openBRSARToolStripMenuItem.Click += new System.EventHandler(this.openBRSARToolStripMenuItem_Click);
			// 
			// toolsToolStripMenuItem
			// 
			this.toolsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ChangeSettingsToolStripMenuItem});
			this.toolsToolStripMenuItem.Name = "toolsToolStripMenuItem";
			this.toolsToolStripMenuItem.Size = new System.Drawing.Size(58, 24);
			this.toolsToolStripMenuItem.Text = "Tools";
			// 
			// ChangeSettingsToolStripMenuItem
			// 
			this.ChangeSettingsToolStripMenuItem.Name = "ChangeSettingsToolStripMenuItem";
			this.ChangeSettingsToolStripMenuItem.Size = new System.Drawing.Size(199, 26);
			this.ChangeSettingsToolStripMenuItem.Text = "Change Settings";
			this.ChangeSettingsToolStripMenuItem.Click += new System.EventHandler(this.setCurrentBRSARAsDefaultToolStripMenuItem_Click);
			// 
			// toolStripMenuItemHelp
			// 
			this.toolStripMenuItemHelp.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aboutToolStripMenuItem1});
			this.toolStripMenuItemHelp.Name = "toolStripMenuItemHelp";
			this.toolStripMenuItemHelp.Size = new System.Drawing.Size(55, 24);
			this.toolStripMenuItemHelp.Text = "Help";
			// 
			// aboutToolStripMenuItem1
			// 
			this.aboutToolStripMenuItem1.Name = "aboutToolStripMenuItem1";
			this.aboutToolStripMenuItem1.Size = new System.Drawing.Size(133, 26);
			this.aboutToolStripMenuItem1.Text = "About";
			this.aboutToolStripMenuItem1.Click += new System.EventHandler(this.aboutToolStripMenuItem1_Click);
			// 
			// menuStrip1
			// 
			this.menuStrip1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.menuStrip1.Dock = System.Windows.Forms.DockStyle.None;
			this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
			this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.toolsToolStripMenuItem,
            this.toolStripMenuItemHelp});
			this.menuStrip1.Location = new System.Drawing.Point(0, 0);
			this.menuStrip1.Name = "menuStrip1";
			this.menuStrip1.Size = new System.Drawing.Size(167, 28);
			this.menuStrip1.TabIndex = 16;
			this.menuStrip1.Text = "menuStrip1";
			// 
			// label5
			// 
			this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.label5.AutoSize = true;
			this.label5.Location = new System.Drawing.Point(933, 19);
			this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(53, 17);
			this.label5.TabIndex = 25;
			this.label5.Text = "Search";
			// 
			// textBoxSearchBar
			// 
			this.textBoxSearchBar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.textBoxSearchBar.Location = new System.Drawing.Point(994, 16);
			this.textBoxSearchBar.Margin = new System.Windows.Forms.Padding(4);
			this.textBoxSearchBar.Name = "textBoxSearchBar";
			this.textBoxSearchBar.Size = new System.Drawing.Size(385, 22);
			this.textBoxSearchBar.TabIndex = 24;
			this.textBoxSearchBar.TextChanged += new System.EventHandler(this.textBoxSearchBar_TextChanged);
			this.textBoxSearchBar.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBoxSearchBar_KeyDown);
			// 
			// label6
			// 
			this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.label6.AutoSize = true;
			this.label6.Location = new System.Drawing.Point(1387, 52);
			this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(47, 17);
			this.label6.TabIndex = 26;
			this.label6.Text = "Mode:";
			// 
			// comboBox1
			// 
			this.comboBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.comboBox1.FormattingEnabled = true;
			this.comboBox1.Items.AddRange(new object[] {
            "Contains",
            "Starts With",
            "Ends With",
            "RegEx"});
			this.comboBox1.Location = new System.Drawing.Point(1441, 48);
			this.comboBox1.Name = "comboBox1";
			this.comboBox1.Size = new System.Drawing.Size(121, 24);
			this.comboBox1.TabIndex = 27;
			this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
			// 
			// checkBoxSearchGroups
			// 
			this.checkBoxSearchGroups.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.checkBoxSearchGroups.AutoSize = true;
			this.checkBoxSearchGroups.Checked = true;
			this.checkBoxSearchGroups.CheckState = System.Windows.Forms.CheckState.Checked;
			this.checkBoxSearchGroups.Location = new System.Drawing.Point(933, 50);
			this.checkBoxSearchGroups.Name = "checkBoxSearchGroups";
			this.checkBoxSearchGroups.Size = new System.Drawing.Size(126, 21);
			this.checkBoxSearchGroups.TabIndex = 28;
			this.checkBoxSearchGroups.Text = "Search Groups";
			this.checkBoxSearchGroups.UseVisualStyleBackColor = true;
			this.checkBoxSearchGroups.CheckedChanged += new System.EventHandler(this.checkBoxSearchGroups_CheckedChanged);
			// 
			// checkBoxSearchWAV
			// 
			this.checkBoxSearchWAV.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.checkBoxSearchWAV.AutoSize = true;
			this.checkBoxSearchWAV.Checked = true;
			this.checkBoxSearchWAV.CheckState = System.Windows.Forms.CheckState.Checked;
			this.checkBoxSearchWAV.Location = new System.Drawing.Point(1065, 50);
			this.checkBoxSearchWAV.Name = "checkBoxSearchWAV";
			this.checkBoxSearchWAV.Size = new System.Drawing.Size(127, 21);
			this.checkBoxSearchWAV.TabIndex = 29;
			this.checkBoxSearchWAV.Text = "Search Sounds";
			this.checkBoxSearchWAV.UseVisualStyleBackColor = true;
			this.checkBoxSearchWAV.CheckedChanged += new System.EventHandler(this.checkBoxSearchSounds_CheckedChanged);
			// 
			// checkBoxSearchCase
			// 
			this.checkBoxSearchCase.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.checkBoxSearchCase.AutoSize = true;
			this.checkBoxSearchCase.Checked = true;
			this.checkBoxSearchCase.CheckState = System.Windows.Forms.CheckState.Checked;
			this.checkBoxSearchCase.Location = new System.Drawing.Point(1198, 50);
			this.checkBoxSearchCase.Name = "checkBoxSearchCase";
			this.checkBoxSearchCase.Size = new System.Drawing.Size(177, 21);
			this.checkBoxSearchCase.TabIndex = 30;
			this.checkBoxSearchCase.Text = "Enable Case Sensitivity";
			this.checkBoxSearchCase.UseVisualStyleBackColor = true;
			this.checkBoxSearchCase.CheckedChanged += new System.EventHandler(this.checkBoxSearchCase_CheckedChanged);
			// 
			// audioPlaybackBRSARSound
			// 
			this.audioPlaybackBRSARSound.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.audioPlaybackBRSARSound.Location = new System.Drawing.Point(924, 705);
			this.audioPlaybackBRSARSound.Margin = new System.Windows.Forms.Padding(4);
			this.audioPlaybackBRSARSound.Name = "audioPlaybackBRSARSound";
			this.audioPlaybackBRSARSound.Size = new System.Drawing.Size(640, 133);
			this.audioPlaybackBRSARSound.TabIndex = 18;
			this.audioPlaybackBRSARSound.TargetStreams = null;
			// 
			// audioPlaybackPanelWav
			// 
			this.audioPlaybackPanelWav.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.audioPlaybackPanelWav.Location = new System.Drawing.Point(19, 182);
			this.audioPlaybackPanelWav.Margin = new System.Windows.Forms.Padding(4);
			this.audioPlaybackPanelWav.Name = "audioPlaybackPanelWav";
			this.audioPlaybackPanelWav.Size = new System.Drawing.Size(611, 105);
			this.audioPlaybackPanelWav.TabIndex = 14;
			this.audioPlaybackPanelWav.TargetStreams = null;
			// 
			// buttonFind
			// 
			this.buttonFind.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.buttonFind.Location = new System.Drawing.Point(1390, 13);
			this.buttonFind.Name = "buttonFind";
			this.buttonFind.Size = new System.Drawing.Size(75, 27);
			this.buttonFind.TabIndex = 31;
			this.buttonFind.Text = "Find";
			this.buttonFind.UseVisualStyleBackColor = true;
			this.buttonFind.Click += new System.EventHandler(this.buttonFind_Click);
			// 
			// buttonFindAll
			// 
			this.buttonFindAll.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.buttonFindAll.Location = new System.Drawing.Point(1471, 13);
			this.buttonFindAll.Name = "buttonFindAll";
			this.buttonFindAll.Size = new System.Drawing.Size(91, 27);
			this.buttonFindAll.TabIndex = 32;
			this.buttonFindAll.Text = "Find All";
			this.buttonFindAll.UseVisualStyleBackColor = true;
			this.buttonFindAll.Click += new System.EventHandler(this.buttonFindAll_Click);
			// 
			// Form1
			// 
			this.AllowDrop = true;
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(1580, 846);
			this.Controls.Add(this.buttonFindAll);
			this.Controls.Add(this.buttonFind);
			this.Controls.Add(this.checkBoxSearchCase);
			this.Controls.Add(this.checkBoxSearchWAV);
			this.Controls.Add(this.checkBoxSearchGroups);
			this.Controls.Add(this.comboBox1);
			this.Controls.Add(this.label6);
			this.Controls.Add(this.label5);
			this.Controls.Add(this.textBoxSearchBar);
			this.Controls.Add(this.buttonMultiInsertWAV);
			this.Controls.Add(this.buttonMultiCreateWAV);
			this.Controls.Add(this.buttonMultiInsertSawnd);
			this.Controls.Add(this.buttonMultiExportSawnd);
			this.Controls.Add(this.buttonCreateWAV);
			this.Controls.Add(this.audioPlaybackBRSARSound);
			this.Controls.Add(this.buttonCreateSawnd);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.audioPlaybackPanelWav);
			this.Controls.Add(this.buttonInsert);
			this.Controls.Add(this.buttonBrowse);
			this.Controls.Add(this.textBoxInputFile);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.textBoxWavID);
			this.Controls.Add(this.textBoxCollectionID);
			this.Controls.Add(this.textBoxGroupID);
			this.Controls.Add(this.treeViewMapping);
			this.Controls.Add(this.textBoxOutput);
			this.Controls.Add(this.menuStrip1);
			this.MainMenuStrip = this.menuStrip1;
			this.Margin = new System.Windows.Forms.Padding(4);
			this.Name = "Form1";
			this.Text = "Super Sawndz";
			this.Load += new System.EventHandler(this.Form1_Load);
			this.DragDrop += new System.Windows.Forms.DragEventHandler(this.Form1_DragDrop);
			this.DragEnter += new System.Windows.Forms.DragEventHandler(this.Form1_DragEnter);
			this.DragLeave += new System.EventHandler(this.Form1_DragLeave);
			this.contextMenuStripWAV.ResumeLayout(false);
			this.contextMenuStripCollection.ResumeLayout(false);
			this.menuStrip1.ResumeLayout(false);
			this.menuStrip1.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.TextBox textBoxOutput;
		private System.Windows.Forms.TreeView treeViewMapping;
		private System.Windows.Forms.TextBox textBoxGroupID;
		private System.Windows.Forms.TextBox textBoxCollectionID;
		private System.Windows.Forms.TextBox textBoxWavID;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.TextBox textBoxInputFile;
		private System.Windows.Forms.Button buttonBrowse;
		private System.Windows.Forms.Button buttonInsert;
		private BrawlLib.Internal.Windows.Controls.AudioPlaybackPanel audioPlaybackPanelWav;
		private System.Windows.Forms.Label label4;
		private System.ComponentModel.BackgroundWorker backgroundWorkerInsert;
		private System.Windows.Forms.Button buttonCreateSawnd;
        private System.Windows.Forms.Button buttonCreateWAV;
		private BrawlLib.Internal.Windows.Controls.AudioPlaybackPanel audioPlaybackBRSARSound;
		private System.ComponentModel.BackgroundWorker backgroundWorkerCreateSawnd;
		private System.ComponentModel.BackgroundWorker backgroundWorkerCreateWAV;
		private System.Windows.Forms.Button buttonMultiExportSawnd;
		private System.Windows.Forms.Button buttonMultiInsertSawnd;
		private System.ComponentModel.BackgroundWorker backgroundWorkerMultiInsertSawnd;
		private System.Windows.Forms.Button buttonMultiCreateWAV;
		private System.Windows.Forms.Button buttonMultiInsertWAV;
		private System.ComponentModel.BackgroundWorker backgroundWorkerMultiInsertWAV;
		private System.Windows.Forms.ContextMenuStrip contextMenuStripWAV;
		private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemSoundProps;
		private System.Windows.Forms.ContextMenuStrip contextMenuStripCollection;
		private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemBRWSDExport;
		private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemBRWSDReplace;
		private System.ComponentModel.BackgroundWorker backgroundWorkerCreateBRWSD;
		private System.Windows.Forms.ToolStripMenuItem editLoopPropertiesToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem openBRSARToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem toolsToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem ChangeSettingsToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemHelp;
		private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem1;
		private System.Windows.Forms.MenuStrip menuStrip1;
		private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemWAVEID;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.TextBox textBoxSearchBar;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.ComboBox comboBox1;
		private System.Windows.Forms.CheckBox checkBoxSearchGroups;
		private System.Windows.Forms.CheckBox checkBoxSearchWAV;
		private System.Windows.Forms.CheckBox checkBoxSearchCase;
		private System.Windows.Forms.Button buttonFind;
		private System.Windows.Forms.Button buttonFindAll;
	}
}

