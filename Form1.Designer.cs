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
			this.bulkCollectionExportToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripMenuItemHelp = new System.Windows.Forms.ToolStripMenuItem();
			this.aboutToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
			this.menuStrip1 = new System.Windows.Forms.MenuStrip();
			this.label5 = new System.Windows.Forms.Label();
			this.textBoxSearchBar = new System.Windows.Forms.TextBox();
			this.label6 = new System.Windows.Forms.Label();
			this.comboBoxSearchMode = new System.Windows.Forms.ComboBox();
			this.checkBoxSearchGroups = new System.Windows.Forms.CheckBox();
			this.checkBoxSearchSounds = new System.Windows.Forms.CheckBox();
			this.checkBoxSearchCase = new System.Windows.Forms.CheckBox();
			this.buttonFind = new System.Windows.Forms.Button();
			this.buttonFindAll = new System.Windows.Forms.Button();
			this.buttonCollapse = new System.Windows.Forms.Button();
			this.buttonExpand = new System.Windows.Forms.Button();
			this.label7 = new System.Windows.Forms.Label();
			this.buttonFindBack = new System.Windows.Forms.Button();
			this.label8 = new System.Windows.Forms.Label();
			this.textBoxInfoIndex = new System.Windows.Forms.TextBox();
			this.tabControl1 = new System.Windows.Forms.TabControl();
			this.tabPage1 = new System.Windows.Forms.TabPage();
			this.tabPage2 = new System.Windows.Forms.TabPage();
			this.contextMenuStripGroup = new System.Windows.Forms.ContextMenuStrip(this.components);
			this.moveToToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.contextMenuStripTab = new System.Windows.Forms.ContextMenuStrip(this.components);
			this.renameToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.closeTabToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.audioPlaybackBRSARSound = new BrawlLib.Internal.Windows.Controls.AudioPlaybackPanel();
			this.audioPlaybackPanelWav = new BrawlLib.Internal.Windows.Controls.AudioPlaybackPanel();
			this.buttonRearrangeTabs = new System.Windows.Forms.Button();
			this.contextMenuStripWAV.SuspendLayout();
			this.contextMenuStripCollection.SuspendLayout();
			this.menuStrip1.SuspendLayout();
			this.tabControl1.SuspendLayout();
			this.contextMenuStripGroup.SuspendLayout();
			this.contextMenuStripTab.SuspendLayout();
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
			this.textBoxOutput.TabIndex = 22;
			// 
			// treeViewMapping
			// 
			this.treeViewMapping.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.treeViewMapping.FullRowSelect = true;
			this.treeViewMapping.HideSelection = false;
			this.treeViewMapping.Location = new System.Drawing.Point(930, 105);
			this.treeViewMapping.Margin = new System.Windows.Forms.Padding(4);
			this.treeViewMapping.Name = "treeViewMapping";
			this.treeViewMapping.Size = new System.Drawing.Size(629, 550);
			this.treeViewMapping.TabIndex = 18;
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
			this.textBoxGroupID.TabIndex = 39;
			this.textBoxGroupID.TabStop = false;
			this.textBoxGroupID.TextChanged += new System.EventHandler(this.textBoxGroupID_TextChanged);
			// 
			// textBoxCollectionID
			// 
			this.textBoxCollectionID.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.textBoxCollectionID.Location = new System.Drawing.Point(771, 48);
			this.textBoxCollectionID.Margin = new System.Windows.Forms.Padding(4);
			this.textBoxCollectionID.Name = "textBoxCollectionID";
			this.textBoxCollectionID.Size = new System.Drawing.Size(132, 22);
			this.textBoxCollectionID.TabIndex = 38;
			this.textBoxCollectionID.TabStop = false;
			this.textBoxCollectionID.TextChanged += new System.EventHandler(this.textBoxCollectionID_TextChanged);
			// 
			// textBoxWavID
			// 
			this.textBoxWavID.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.textBoxWavID.Location = new System.Drawing.Point(771, 80);
			this.textBoxWavID.Margin = new System.Windows.Forms.Padding(4);
			this.textBoxWavID.Name = "textBoxWavID";
			this.textBoxWavID.Size = new System.Drawing.Size(132, 22);
			this.textBoxWavID.TabIndex = 37;
			this.textBoxWavID.TabStop = false;
			this.textBoxWavID.TextChanged += new System.EventHandler(this.textBoxWavID_TextChanged);
			// 
			// label1
			// 
			this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.label1.Location = new System.Drawing.Point(670, 20);
			this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(90, 17);
			this.label1.TabIndex = 36;
			this.label1.Text = "Group ID";
			this.label1.TextAlign = System.Drawing.ContentAlignment.TopRight;
			// 
			// label2
			// 
			this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.label2.Location = new System.Drawing.Point(670, 52);
			this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(90, 17);
			this.label2.TabIndex = 35;
			this.label2.Text = "Collection ID";
			this.label2.TextAlign = System.Drawing.ContentAlignment.TopRight;
			// 
			// label3
			// 
			this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.label3.Location = new System.Drawing.Point(670, 84);
			this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(90, 17);
			this.label3.TabIndex = 34;
			this.label3.Text = "WAV ID";
			this.label3.TextAlign = System.Drawing.ContentAlignment.TopRight;
			// 
			// textBoxInputFile
			// 
			this.textBoxInputFile.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.textBoxInputFile.Enabled = false;
			this.textBoxInputFile.Location = new System.Drawing.Point(20, 51);
			this.textBoxInputFile.Margin = new System.Windows.Forms.Padding(4);
			this.textBoxInputFile.Name = "textBoxInputFile";
			this.textBoxInputFile.Size = new System.Drawing.Size(569, 22);
			this.textBoxInputFile.TabIndex = 33;
			this.textBoxInputFile.TabStop = false;
			this.textBoxInputFile.TextChanged += new System.EventHandler(this.textBoxInputFile_TextChanged);
			// 
			// buttonBrowse
			// 
			this.buttonBrowse.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.buttonBrowse.Location = new System.Drawing.Point(598, 48);
			this.buttonBrowse.Margin = new System.Windows.Forms.Padding(4);
			this.buttonBrowse.Name = "buttonBrowse";
			this.buttonBrowse.Size = new System.Drawing.Size(33, 28);
			this.buttonBrowse.TabIndex = 0;
			this.buttonBrowse.Text = "...";
			this.buttonBrowse.UseVisualStyleBackColor = true;
			this.buttonBrowse.Click += new System.EventHandler(this.buttonBrowse_Click);
			// 
			// buttonInsert
			// 
			this.buttonInsert.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.buttonInsert.Enabled = false;
			this.buttonInsert.Location = new System.Drawing.Point(497, 81);
			this.buttonInsert.Margin = new System.Windows.Forms.Padding(4);
			this.buttonInsert.Name = "buttonInsert";
			this.buttonInsert.Size = new System.Drawing.Size(134, 28);
			this.buttonInsert.TabIndex = 1;
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
			this.label4.TabIndex = 29;
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
			this.buttonCreateSawnd.Location = new System.Drawing.Point(770, 140);
			this.buttonCreateSawnd.Margin = new System.Windows.Forms.Padding(4);
			this.buttonCreateSawnd.Name = "buttonCreateSawnd";
			this.buttonCreateSawnd.Size = new System.Drawing.Size(134, 28);
			this.buttonCreateSawnd.TabIndex = 4;
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
			this.buttonCreateWAV.Location = new System.Drawing.Point(770, 210);
			this.buttonCreateWAV.Margin = new System.Windows.Forms.Padding(4);
			this.buttonCreateWAV.Name = "buttonCreateWAV";
			this.buttonCreateWAV.Size = new System.Drawing.Size(134, 28);
			this.buttonCreateWAV.TabIndex = 6;
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
			this.buttonMultiExportSawnd.Location = new System.Drawing.Point(770, 175);
			this.buttonMultiExportSawnd.Margin = new System.Windows.Forms.Padding(4);
			this.buttonMultiExportSawnd.Name = "buttonMultiExportSawnd";
			this.buttonMultiExportSawnd.Size = new System.Drawing.Size(134, 28);
			this.buttonMultiExportSawnd.TabIndex = 5;
			this.buttonMultiExportSawnd.Text = "Multi Create Sawnd";
			this.buttonMultiExportSawnd.UseVisualStyleBackColor = true;
			this.buttonMultiExportSawnd.Click += new System.EventHandler(this.buttonMultiExportSawnd_Click);
			// 
			// buttonMultiInsertSawnd
			// 
			this.buttonMultiInsertSawnd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.buttonMultiInsertSawnd.Enabled = false;
			this.buttonMultiInsertSawnd.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.4F);
			this.buttonMultiInsertSawnd.Location = new System.Drawing.Point(497, 116);
			this.buttonMultiInsertSawnd.Margin = new System.Windows.Forms.Padding(4);
			this.buttonMultiInsertSawnd.Name = "buttonMultiInsertSawnd";
			this.buttonMultiInsertSawnd.Size = new System.Drawing.Size(134, 28);
			this.buttonMultiInsertSawnd.TabIndex = 2;
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
			this.buttonMultiCreateWAV.Location = new System.Drawing.Point(770, 245);
			this.buttonMultiCreateWAV.Margin = new System.Windows.Forms.Padding(4);
			this.buttonMultiCreateWAV.Name = "buttonMultiCreateWAV";
			this.buttonMultiCreateWAV.Size = new System.Drawing.Size(134, 28);
			this.buttonMultiCreateWAV.TabIndex = 7;
			this.buttonMultiCreateWAV.Text = "Multi Create WAV";
			this.buttonMultiCreateWAV.UseVisualStyleBackColor = true;
			this.buttonMultiCreateWAV.Click += new System.EventHandler(this.buttonMultiCreateWAV_Click);
			// 
			// buttonMultiInsertWAV
			// 
			this.buttonMultiInsertWAV.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.buttonMultiInsertWAV.Enabled = false;
			this.buttonMultiInsertWAV.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.4F);
			this.buttonMultiInsertWAV.Location = new System.Drawing.Point(497, 151);
			this.buttonMultiInsertWAV.Margin = new System.Windows.Forms.Padding(4);
			this.buttonMultiInsertWAV.Name = "buttonMultiInsertWAV";
			this.buttonMultiInsertWAV.Size = new System.Drawing.Size(134, 28);
			this.buttonMultiInsertWAV.TabIndex = 3;
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
			this.contextMenuStripCollection.Size = new System.Drawing.Size(173, 52);
			// 
			// toolStripMenuItemBRWSDExport
			// 
			this.toolStripMenuItemBRWSDExport.Name = "toolStripMenuItemBRWSDExport";
			this.toolStripMenuItemBRWSDExport.Size = new System.Drawing.Size(172, 24);
			this.toolStripMenuItemBRWSDExport.Text = "Export as...";
			this.toolStripMenuItemBRWSDExport.Click += new System.EventHandler(this.toolStripMenuItemBRWSDExport_Click);
			// 
			// toolStripMenuItemBRWSDReplace
			// 
			this.toolStripMenuItemBRWSDReplace.Name = "toolStripMenuItemBRWSDReplace";
			this.toolStripMenuItemBRWSDReplace.Size = new System.Drawing.Size(172, 24);
			this.toolStripMenuItemBRWSDReplace.Text = "Replace with...";
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
			this.openBRSARToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
			this.openBRSARToolStripMenuItem.Size = new System.Drawing.Size(230, 26);
			this.openBRSARToolStripMenuItem.Text = "Open BRSAR";
			this.openBRSARToolStripMenuItem.Click += new System.EventHandler(this.openBRSARToolStripMenuItem_Click);
			// 
			// toolsToolStripMenuItem
			// 
			this.toolsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ChangeSettingsToolStripMenuItem,
            this.bulkCollectionExportToolStripMenuItem});
			this.toolsToolStripMenuItem.Name = "toolsToolStripMenuItem";
			this.toolsToolStripMenuItem.Size = new System.Drawing.Size(58, 24);
			this.toolsToolStripMenuItem.Text = "Tools";
			// 
			// ChangeSettingsToolStripMenuItem
			// 
			this.ChangeSettingsToolStripMenuItem.Name = "ChangeSettingsToolStripMenuItem";
			this.ChangeSettingsToolStripMenuItem.Size = new System.Drawing.Size(238, 26);
			this.ChangeSettingsToolStripMenuItem.Text = "Change Settings";
			this.ChangeSettingsToolStripMenuItem.Click += new System.EventHandler(this.ChangeSettingsToolStripMenuItem_Click);
			// 
			// bulkCollectionExportToolStripMenuItem
			// 
			this.bulkCollectionExportToolStripMenuItem.Name = "bulkCollectionExportToolStripMenuItem";
			this.bulkCollectionExportToolStripMenuItem.Size = new System.Drawing.Size(238, 26);
			this.bulkCollectionExportToolStripMenuItem.Text = "Bulk Collection Export";
			this.bulkCollectionExportToolStripMenuItem.Click += new System.EventHandler(this.bulkCollectionExportToolStripMenuItem_Click);
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
			this.menuStrip1.TabIndex = 41;
			this.menuStrip1.Text = "menuStrip1";
			// 
			// label5
			// 
			this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.label5.AutoSize = true;
			this.label5.Location = new System.Drawing.Point(930, 20);
			this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(53, 17);
			this.label5.TabIndex = 20;
			this.label5.Text = "Search";
			// 
			// textBoxSearchBar
			// 
			this.textBoxSearchBar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.textBoxSearchBar.Location = new System.Drawing.Point(991, 16);
			this.textBoxSearchBar.Margin = new System.Windows.Forms.Padding(4);
			this.textBoxSearchBar.Name = "textBoxSearchBar";
			this.textBoxSearchBar.Size = new System.Drawing.Size(370, 22);
			this.textBoxSearchBar.TabIndex = 8;
			this.textBoxSearchBar.TextChanged += new System.EventHandler(this.textBoxSearchBar_TextChanged);
			this.textBoxSearchBar.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBoxSearchBar_KeyDown);
			// 
			// label6
			// 
			this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.label6.AutoSize = true;
			this.label6.Location = new System.Drawing.Point(1384, 52);
			this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(47, 17);
			this.label6.TabIndex = 19;
			this.label6.Text = "Mode:";
			// 
			// comboBoxSearchMode
			// 
			this.comboBoxSearchMode.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.comboBoxSearchMode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.comboBoxSearchMode.FormattingEnabled = true;
			this.comboBoxSearchMode.Items.AddRange(new object[] {
            "Contains",
            "Starts With",
            "Ends With",
            "RegEx"});
			this.comboBoxSearchMode.Location = new System.Drawing.Point(1438, 48);
			this.comboBoxSearchMode.Name = "comboBoxSearchMode";
			this.comboBoxSearchMode.Size = new System.Drawing.Size(121, 24);
			this.comboBoxSearchMode.TabIndex = 15;
			this.comboBoxSearchMode.SelectedIndexChanged += new System.EventHandler(this.comboBoxSearchMode_SelectedIndexChanged);
			// 
			// checkBoxSearchGroups
			// 
			this.checkBoxSearchGroups.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.checkBoxSearchGroups.AutoSize = true;
			this.checkBoxSearchGroups.Checked = true;
			this.checkBoxSearchGroups.CheckState = System.Windows.Forms.CheckState.Checked;
			this.checkBoxSearchGroups.Location = new System.Drawing.Point(930, 51);
			this.checkBoxSearchGroups.Name = "checkBoxSearchGroups";
			this.checkBoxSearchGroups.Size = new System.Drawing.Size(126, 21);
			this.checkBoxSearchGroups.TabIndex = 12;
			this.checkBoxSearchGroups.Text = "Search Groups";
			this.checkBoxSearchGroups.UseVisualStyleBackColor = true;
			this.checkBoxSearchGroups.CheckedChanged += new System.EventHandler(this.checkBoxSearchGroups_CheckedChanged);
			this.checkBoxSearchGroups.KeyDown += new System.Windows.Forms.KeyEventHandler(this.checkBoxSearchGroups_KeyDown);
			// 
			// checkBoxSearchSounds
			// 
			this.checkBoxSearchSounds.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.checkBoxSearchSounds.AutoSize = true;
			this.checkBoxSearchSounds.Checked = true;
			this.checkBoxSearchSounds.CheckState = System.Windows.Forms.CheckState.Checked;
			this.checkBoxSearchSounds.Location = new System.Drawing.Point(1062, 51);
			this.checkBoxSearchSounds.Name = "checkBoxSearchSounds";
			this.checkBoxSearchSounds.Size = new System.Drawing.Size(127, 21);
			this.checkBoxSearchSounds.TabIndex = 13;
			this.checkBoxSearchSounds.Text = "Search Sounds";
			this.checkBoxSearchSounds.UseVisualStyleBackColor = true;
			this.checkBoxSearchSounds.CheckedChanged += new System.EventHandler(this.checkBoxSearchSounds_CheckedChanged);
			this.checkBoxSearchSounds.KeyDown += new System.Windows.Forms.KeyEventHandler(this.checkBoxSearchSounds_KeyDown);
			// 
			// checkBoxSearchCase
			// 
			this.checkBoxSearchCase.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.checkBoxSearchCase.AutoSize = true;
			this.checkBoxSearchCase.Checked = true;
			this.checkBoxSearchCase.CheckState = System.Windows.Forms.CheckState.Checked;
			this.checkBoxSearchCase.Location = new System.Drawing.Point(1195, 51);
			this.checkBoxSearchCase.Name = "checkBoxSearchCase";
			this.checkBoxSearchCase.Size = new System.Drawing.Size(177, 21);
			this.checkBoxSearchCase.TabIndex = 14;
			this.checkBoxSearchCase.Text = "Enable Case Sensitivity";
			this.checkBoxSearchCase.UseVisualStyleBackColor = true;
			this.checkBoxSearchCase.CheckedChanged += new System.EventHandler(this.checkBoxSearchCase_CheckedChanged);
			this.checkBoxSearchCase.KeyDown += new System.Windows.Forms.KeyEventHandler(this.checkBoxSearchCase_KeyDown);
			// 
			// buttonFind
			// 
			this.buttonFind.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.buttonFind.Location = new System.Drawing.Point(1389, 13);
			this.buttonFind.Name = "buttonFind";
			this.buttonFind.Size = new System.Drawing.Size(75, 28);
			this.buttonFind.TabIndex = 10;
			this.buttonFind.Text = "Find";
			this.buttonFind.UseVisualStyleBackColor = true;
			this.buttonFind.Click += new System.EventHandler(this.buttonFind_Click);
			// 
			// buttonFindAll
			// 
			this.buttonFindAll.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.buttonFindAll.Location = new System.Drawing.Point(1469, 13);
			this.buttonFindAll.Name = "buttonFindAll";
			this.buttonFindAll.Size = new System.Drawing.Size(91, 28);
			this.buttonFindAll.TabIndex = 11;
			this.buttonFindAll.Text = "Find All";
			this.buttonFindAll.UseVisualStyleBackColor = true;
			this.buttonFindAll.Click += new System.EventHandler(this.buttonFindAll_Click);
			// 
			// buttonCollapse
			// 
			this.buttonCollapse.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.buttonCollapse.Location = new System.Drawing.Point(1469, 672);
			this.buttonCollapse.Name = "buttonCollapse";
			this.buttonCollapse.Size = new System.Drawing.Size(91, 28);
			this.buttonCollapse.TabIndex = 20;
			this.buttonCollapse.Text = "Collapse All";
			this.buttonCollapse.UseVisualStyleBackColor = true;
			this.buttonCollapse.Click += new System.EventHandler(this.buttonCollapse_Click);
			// 
			// buttonExpand
			// 
			this.buttonExpand.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.buttonExpand.Location = new System.Drawing.Point(1373, 672);
			this.buttonExpand.Name = "buttonExpand";
			this.buttonExpand.Size = new System.Drawing.Size(91, 28);
			this.buttonExpand.TabIndex = 19;
			this.buttonExpand.Text = "Expand All";
			this.buttonExpand.UseVisualStyleBackColor = true;
			this.buttonExpand.Click += new System.EventHandler(this.buttonExpand_Click);
			// 
			// label7
			// 
			this.label7.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.label7.AutoSize = true;
			this.label7.Location = new System.Drawing.Point(925, 681);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(61, 17);
			this.label7.TabIndex = 10;
			this.label7.Text = "Preview:";
			// 
			// buttonFindBack
			// 
			this.buttonFindBack.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.buttonFindBack.Location = new System.Drawing.Point(1367, 13);
			this.buttonFindBack.Name = "buttonFindBack";
			this.buttonFindBack.Size = new System.Drawing.Size(23, 28);
			this.buttonFindBack.TabIndex = 9;
			this.buttonFindBack.Text = "<";
			this.buttonFindBack.UseVisualStyleBackColor = true;
			this.buttonFindBack.Click += new System.EventHandler(this.buttonFindBack_Click);
			// 
			// label8
			// 
			this.label8.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.label8.Location = new System.Drawing.Point(670, 114);
			this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(90, 17);
			this.label8.TabIndex = 7;
			this.label8.Text = "Info Index";
			this.label8.TextAlign = System.Drawing.ContentAlignment.TopRight;
			// 
			// textBoxInfoIndex
			// 
			this.textBoxInfoIndex.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.textBoxInfoIndex.Location = new System.Drawing.Point(771, 110);
			this.textBoxInfoIndex.Margin = new System.Windows.Forms.Padding(4);
			this.textBoxInfoIndex.Name = "textBoxInfoIndex";
			this.textBoxInfoIndex.Size = new System.Drawing.Size(132, 22);
			this.textBoxInfoIndex.TabIndex = 8;
			this.textBoxInfoIndex.TabStop = false;
			// 
			// tabControl1
			// 
			this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.tabControl1.Controls.Add(this.tabPage1);
			this.tabControl1.Controls.Add(this.tabPage2);
			this.tabControl1.Location = new System.Drawing.Point(930, 80);
			this.tabControl1.Name = "tabControl1";
			this.tabControl1.SelectedIndex = 0;
			this.tabControl1.Size = new System.Drawing.Size(600, 26);
			this.tabControl1.TabIndex = 16;
			this.tabControl1.SelectedIndexChanged += new System.EventHandler(this.tabControl1_SelectedIndexChanged);
			this.tabControl1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.tabControl1_MouseDown);
			// 
			// tabPage1
			// 
			this.tabPage1.Location = new System.Drawing.Point(4, 25);
			this.tabPage1.Name = "tabPage1";
			this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
			this.tabPage1.Size = new System.Drawing.Size(592, 0);
			this.tabPage1.TabIndex = 0;
			this.tabPage1.Text = "Tab 1";
			this.tabPage1.UseVisualStyleBackColor = true;
			// 
			// tabPage2
			// 
			this.tabPage2.Location = new System.Drawing.Point(4, 25);
			this.tabPage2.Name = "tabPage2";
			this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
			this.tabPage2.Size = new System.Drawing.Size(592, 0);
			this.tabPage2.TabIndex = 1;
			this.tabPage2.Text = "Add Tab";
			this.tabPage2.UseVisualStyleBackColor = true;
			// 
			// contextMenuStripGroup
			// 
			this.contextMenuStripGroup.ImageScalingSize = new System.Drawing.Size(20, 20);
			this.contextMenuStripGroup.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.moveToToolStripMenuItem});
			this.contextMenuStripGroup.Name = "contextMenuStripGroup";
			this.contextMenuStripGroup.Size = new System.Drawing.Size(143, 28);
			// 
			// moveToToolStripMenuItem
			// 
			this.moveToToolStripMenuItem.Name = "moveToToolStripMenuItem";
			this.moveToToolStripMenuItem.Size = new System.Drawing.Size(142, 24);
			this.moveToToolStripMenuItem.Text = "Move to...";
			this.moveToToolStripMenuItem.Click += new System.EventHandler(this.moveToToolStripMenuItem_Click);
			// 
			// contextMenuStripTab
			// 
			this.contextMenuStripTab.ImageScalingSize = new System.Drawing.Size(20, 20);
			this.contextMenuStripTab.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.renameToolStripMenuItem,
            this.closeTabToolStripMenuItem});
			this.contextMenuStripTab.Name = "contextMenuStripTab";
			this.contextMenuStripTab.Size = new System.Drawing.Size(142, 52);
			this.contextMenuStripTab.Closed += new System.Windows.Forms.ToolStripDropDownClosedEventHandler(this.contextMenuStripTab_Closed);
			// 
			// renameToolStripMenuItem
			// 
			this.renameToolStripMenuItem.Name = "renameToolStripMenuItem";
			this.renameToolStripMenuItem.Size = new System.Drawing.Size(141, 24);
			this.renameToolStripMenuItem.Text = "Rename";
			this.renameToolStripMenuItem.Click += new System.EventHandler(this.renameToolStripMenuItem_Click);
			// 
			// closeTabToolStripMenuItem
			// 
			this.closeTabToolStripMenuItem.Name = "closeTabToolStripMenuItem";
			this.closeTabToolStripMenuItem.Size = new System.Drawing.Size(141, 24);
			this.closeTabToolStripMenuItem.Text = "Close Tab";
			this.closeTabToolStripMenuItem.Click += new System.EventHandler(this.closeTabToolStripMenuItem_Click);
			// 
			// audioPlaybackBRSARSound
			// 
			this.audioPlaybackBRSARSound.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.audioPlaybackBRSARSound.Location = new System.Drawing.Point(916, 705);
			this.audioPlaybackBRSARSound.Margin = new System.Windows.Forms.Padding(4);
			this.audioPlaybackBRSARSound.Name = "audioPlaybackBRSARSound";
			this.audioPlaybackBRSARSound.Size = new System.Drawing.Size(640, 133);
			this.audioPlaybackBRSARSound.TabIndex = 27;
			this.audioPlaybackBRSARSound.TabStop = false;
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
			this.audioPlaybackPanelWav.TabIndex = 30;
			this.audioPlaybackPanelWav.TabStop = false;
			this.audioPlaybackPanelWav.TargetStreams = null;
			// 
			// buttonRearrangeTabs
			// 
			this.buttonRearrangeTabs.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.buttonRearrangeTabs.Location = new System.Drawing.Point(1534, 78);
			this.buttonRearrangeTabs.Name = "buttonRearrangeTabs";
			this.buttonRearrangeTabs.Size = new System.Drawing.Size(26, 26);
			this.buttonRearrangeTabs.TabIndex = 17;
			this.buttonRearrangeTabs.Text = "⏣";
			this.buttonRearrangeTabs.UseVisualStyleBackColor = true;
			this.buttonRearrangeTabs.Click += new System.EventHandler(this.buttonRearrangeTabs_Click);
			// 
			// Form1
			// 
			this.AllowDrop = true;
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(1580, 846);
			this.Controls.Add(this.treeViewMapping);
			this.Controls.Add(this.buttonRearrangeTabs);
			this.Controls.Add(this.tabControl1);
			this.Controls.Add(this.label8);
			this.Controls.Add(this.textBoxInfoIndex);
			this.Controls.Add(this.buttonFindBack);
			this.Controls.Add(this.label7);
			this.Controls.Add(this.buttonCollapse);
			this.Controls.Add(this.buttonExpand);
			this.Controls.Add(this.buttonFindAll);
			this.Controls.Add(this.buttonFind);
			this.Controls.Add(this.checkBoxSearchCase);
			this.Controls.Add(this.checkBoxSearchSounds);
			this.Controls.Add(this.checkBoxSearchGroups);
			this.Controls.Add(this.comboBoxSearchMode);
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
			this.Controls.Add(this.textBoxOutput);
			this.Controls.Add(this.menuStrip1);
			this.KeyPreview = true;
			this.MainMenuStrip = this.menuStrip1;
			this.Margin = new System.Windows.Forms.Padding(4);
			this.Name = "Form1";
			this.Text = "Super Sawndz";
			this.Activated += new System.EventHandler(this.Form1_Activated);
			this.Deactivate += new System.EventHandler(this.Form1_Deactivate);
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
			this.Load += new System.EventHandler(this.Form1_Load);
			this.Shown += new System.EventHandler(this.Form1_Shown);
			this.DragDrop += new System.Windows.Forms.DragEventHandler(this.Form1_DragDrop);
			this.DragEnter += new System.Windows.Forms.DragEventHandler(this.Form1_DragEnter);
			this.DragLeave += new System.EventHandler(this.Form1_DragLeave);
			this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);
			this.contextMenuStripWAV.ResumeLayout(false);
			this.contextMenuStripCollection.ResumeLayout(false);
			this.menuStrip1.ResumeLayout(false);
			this.menuStrip1.PerformLayout();
			this.tabControl1.ResumeLayout(false);
			this.contextMenuStripGroup.ResumeLayout(false);
			this.contextMenuStripTab.ResumeLayout(false);
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
		private System.Windows.Forms.ComboBox comboBoxSearchMode;
		private System.Windows.Forms.CheckBox checkBoxSearchGroups;
		private System.Windows.Forms.CheckBox checkBoxSearchSounds;
		private System.Windows.Forms.CheckBox checkBoxSearchCase;
		private System.Windows.Forms.Button buttonFind;
		private System.Windows.Forms.Button buttonFindAll;
		private System.Windows.Forms.Button buttonCollapse;
		private System.Windows.Forms.Button buttonExpand;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.Button buttonFindBack;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.TextBox textBoxInfoIndex;
		private System.Windows.Forms.TabControl tabControl1;
		private System.Windows.Forms.TabPage tabPage1;
		private System.Windows.Forms.TabPage tabPage2;
		private System.Windows.Forms.ContextMenuStrip contextMenuStripGroup;
		private System.Windows.Forms.ToolStripMenuItem moveToToolStripMenuItem;
		private System.Windows.Forms.ContextMenuStrip contextMenuStripTab;
		private System.Windows.Forms.ToolStripMenuItem renameToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem closeTabToolStripMenuItem;
		private System.Windows.Forms.Button buttonRearrangeTabs;
		private System.Windows.Forms.ToolStripMenuItem bulkCollectionExportToolStripMenuItem;
	}
}

