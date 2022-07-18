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
			this.menuStrip1 = new System.Windows.Forms.MenuStrip();
			this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.openBRSARToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.toolsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.buttonCreateSawnd = new System.Windows.Forms.Button();
			this.backgroundWorkerCreateSawnd = new System.ComponentModel.BackgroundWorker();
			this.buttonCreateWAV = new System.Windows.Forms.Button();
			this.backgroundWorkerCreateWAV = new System.ComponentModel.BackgroundWorker();
			this.buttonMultiExportSawnd = new System.Windows.Forms.Button();
			this.buttonMultiInsertSawnd = new System.Windows.Forms.Button();
			this.backgroundWorkerMultiInsertSawnd = new System.ComponentModel.BackgroundWorker();
			this.audioPlaybackBRSARSound = new BrawlLib.Internal.Windows.Controls.AudioPlaybackPanel();
			this.audioPlaybackPanelWav = new BrawlLib.Internal.Windows.Controls.AudioPlaybackPanel();
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
			this.textBoxOutput.Location = new System.Drawing.Point(20, 252);
			this.textBoxOutput.Margin = new System.Windows.Forms.Padding(4);
			this.textBoxOutput.Multiline = true;
			this.textBoxOutput.Name = "textBoxOutput";
			this.textBoxOutput.ReadOnly = true;
			this.textBoxOutput.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.textBoxOutput.Size = new System.Drawing.Size(883, 578);
			this.textBoxOutput.TabIndex = 1;
			// 
			// treeViewMapping
			// 
			this.treeViewMapping.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.treeViewMapping.FullRowSelect = true;
			this.treeViewMapping.HideSelection = false;
			this.treeViewMapping.Location = new System.Drawing.Point(933, 16);
			this.treeViewMapping.Margin = new System.Windows.Forms.Padding(4);
			this.treeViewMapping.Name = "treeViewMapping";
			this.treeViewMapping.Size = new System.Drawing.Size(629, 681);
			this.treeViewMapping.TabIndex = 3;
			this.treeViewMapping.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeViewMapping_AfterSelect);
			this.treeViewMapping.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.treeViewMapping_KeyPress);
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
			this.textBoxInputFile.Location = new System.Drawing.Point(20, 48);
			this.textBoxInputFile.Margin = new System.Windows.Forms.Padding(4);
			this.textBoxInputFile.Name = "textBoxInputFile";
			this.textBoxInputFile.Size = new System.Drawing.Size(568, 22);
			this.textBoxInputFile.TabIndex = 11;
			// 
			// buttonBrowse
			// 
			this.buttonBrowse.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.buttonBrowse.Location = new System.Drawing.Point(597, 48);
			this.buttonBrowse.Margin = new System.Windows.Forms.Padding(4);
			this.buttonBrowse.Name = "buttonBrowse";
			this.buttonBrowse.Size = new System.Drawing.Size(33, 28);
			this.buttonBrowse.TabIndex = 12;
			this.buttonBrowse.Text = "...";
			this.buttonBrowse.UseVisualStyleBackColor = true;
			this.buttonBrowse.Click += new System.EventHandler(this.buttonBrowse_Click);
			// 
			// buttonInsert
			// 
			this.buttonInsert.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.buttonInsert.Location = new System.Drawing.Point(506, 80);
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
			// menuStrip1
			// 
			this.menuStrip1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.menuStrip1.Dock = System.Windows.Forms.DockStyle.None;
			this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
			this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.toolsToolStripMenuItem,
            this.aboutToolStripMenuItem});
			this.menuStrip1.Location = new System.Drawing.Point(0, 0);
			this.menuStrip1.Name = "menuStrip1";
			this.menuStrip1.Size = new System.Drawing.Size(176, 30);
			this.menuStrip1.TabIndex = 16;
			this.menuStrip1.Text = "menuStrip1";
			// 
			// fileToolStripMenuItem
			// 
			this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openBRSARToolStripMenuItem});
			this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
			this.fileToolStripMenuItem.Size = new System.Drawing.Size(46, 26);
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
			this.toolsToolStripMenuItem.Name = "toolsToolStripMenuItem";
			this.toolsToolStripMenuItem.Size = new System.Drawing.Size(58, 26);
			this.toolsToolStripMenuItem.Text = "Tools";
			// 
			// aboutToolStripMenuItem
			// 
			this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
			this.aboutToolStripMenuItem.Size = new System.Drawing.Size(64, 26);
			this.aboutToolStripMenuItem.Text = "About";
			this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
			// 
			// buttonCreateSawnd
			// 
			this.buttonCreateSawnd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.buttonCreateSawnd.Enabled = false;
			this.buttonCreateSawnd.Location = new System.Drawing.Point(771, 112);
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
			this.buttonCreateWAV.Location = new System.Drawing.Point(771, 182);
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
			this.buttonMultiExportSawnd.Location = new System.Drawing.Point(771, 147);
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
			// audioPlaybackBRSARSound
			// 
			this.audioPlaybackBRSARSound.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.audioPlaybackBRSARSound.Location = new System.Drawing.Point(924, 705);
			this.audioPlaybackBRSARSound.Margin = new System.Windows.Forms.Padding(4);
			this.audioPlaybackBRSARSound.Name = "audioPlaybackBRSARSound";
			this.audioPlaybackBRSARSound.Size = new System.Drawing.Size(640, 133);
			this.audioPlaybackBRSARSound.TabIndex = 18;
			// 
			// audioPlaybackPanelWav
			// 
			this.audioPlaybackPanelWav.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.audioPlaybackPanelWav.Location = new System.Drawing.Point(20, 139);
			this.audioPlaybackPanelWav.Margin = new System.Windows.Forms.Padding(4);
			this.audioPlaybackPanelWav.Name = "audioPlaybackPanelWav";
			this.audioPlaybackPanelWav.Size = new System.Drawing.Size(611, 105);
			this.audioPlaybackPanelWav.TabIndex = 14;
			// 
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(1580, 846);
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
		private System.Windows.Forms.MenuStrip menuStrip1;
		private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem openBRSARToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
		private System.Windows.Forms.Button buttonCreateSawnd;
        private System.Windows.Forms.Button buttonCreateWAV;
		private BrawlLib.Internal.Windows.Controls.AudioPlaybackPanel audioPlaybackBRSARSound;
		private System.ComponentModel.BackgroundWorker backgroundWorkerCreateSawnd;
		private System.ComponentModel.BackgroundWorker backgroundWorkerCreateWAV;
		private System.Windows.Forms.ToolStripMenuItem toolsToolStripMenuItem;
		private System.Windows.Forms.Button buttonMultiExportSawnd;
		private System.Windows.Forms.Button buttonMultiInsertSawnd;
		private System.ComponentModel.BackgroundWorker backgroundWorkerMultiInsertSawnd;
	}
}

