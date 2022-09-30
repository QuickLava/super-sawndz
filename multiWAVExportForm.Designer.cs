
namespace BrawlSoundConverter
{
	partial class multiWAVExportForm
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			this.label1 = new System.Windows.Forms.Label();
			this.buttonBrowse = new System.Windows.Forms.Button();
			this.textBoxExportDirectory = new System.Windows.Forms.TextBox();
			this.buttonExport = new System.Windows.Forms.Button();
			this.backgroundWorkerMultiCreateSawnd = new System.ComponentModel.BackgroundWorker();
			this.buttonInvertSelection = new System.Windows.Forms.Button();
			this.buttonSelectAll = new System.Windows.Forms.Button();
			this.buttonDeselectAll = new System.Windows.Forms.Button();
			this.label2 = new System.Windows.Forms.Label();
			this.treeViewAudio = new System.Windows.Forms.TreeView();
			this.toolTipNameDefault = new System.Windows.Forms.ToolTip(this.components);
			this.toolTipNamePM = new System.Windows.Forms.ToolTip(this.components);
			this.toolTipNamePP = new System.Windows.Forms.ToolTip(this.components);
			this.toolTipNameManual = new System.Windows.Forms.ToolTip(this.components);
			this.buttonCancel = new System.Windows.Forms.Button();
			this.treeViewSoundInfo = new System.Windows.Forms.TreeView();
			this.label3 = new System.Windows.Forms.Label();
			this.labelFileLabel = new System.Windows.Forms.Label();
			this.audioPlaybackPanel1 = new BrawlLib.Internal.Windows.Controls.AudioPlaybackPanel();
			this.labelPreview = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.checkBox1 = new System.Windows.Forms.CheckBox();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(12, 9);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(109, 17);
			this.label1.TabIndex = 2;
			this.label1.Text = "Export Directory";
			// 
			// buttonBrowse
			// 
			this.buttonBrowse.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.buttonBrowse.Location = new System.Drawing.Point(687, 27);
			this.buttonBrowse.Margin = new System.Windows.Forms.Padding(4);
			this.buttonBrowse.Name = "buttonBrowse";
			this.buttonBrowse.Size = new System.Drawing.Size(33, 25);
			this.buttonBrowse.TabIndex = 14;
			this.buttonBrowse.Text = "...";
			this.buttonBrowse.UseVisualStyleBackColor = true;
			this.buttonBrowse.Click += new System.EventHandler(this.buttonBrowse_Click);
			// 
			// textBoxExportDirectory
			// 
			this.textBoxExportDirectory.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.textBoxExportDirectory.Enabled = false;
			this.textBoxExportDirectory.Location = new System.Drawing.Point(15, 30);
			this.textBoxExportDirectory.Margin = new System.Windows.Forms.Padding(4);
			this.textBoxExportDirectory.Name = "textBoxExportDirectory";
			this.textBoxExportDirectory.Size = new System.Drawing.Size(664, 22);
			this.textBoxExportDirectory.TabIndex = 13;
			this.textBoxExportDirectory.TextChanged += new System.EventHandler(this.textBoxExportDirectory_TextChanged);
			// 
			// buttonExport
			// 
			this.buttonExport.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.buttonExport.Enabled = false;
			this.buttonExport.Location = new System.Drawing.Point(513, 89);
			this.buttonExport.Margin = new System.Windows.Forms.Padding(4);
			this.buttonExport.Name = "buttonExport";
			this.buttonExport.Size = new System.Drawing.Size(100, 28);
			this.buttonExport.TabIndex = 15;
			this.buttonExport.Text = "Export";
			this.buttonExport.UseVisualStyleBackColor = true;
			this.buttonExport.Click += new System.EventHandler(this.buttonExport_Click);
			// 
			// buttonInvertSelection
			// 
			this.buttonInvertSelection.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.buttonInvertSelection.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.7F);
			this.buttonInvertSelection.Location = new System.Drawing.Point(611, 673);
			this.buttonInvertSelection.Name = "buttonInvertSelection";
			this.buttonInvertSelection.Size = new System.Drawing.Size(110, 40);
			this.buttonInvertSelection.TabIndex = 18;
			this.buttonInvertSelection.Text = "Invert Selection";
			this.buttonInvertSelection.UseVisualStyleBackColor = true;
			this.buttonInvertSelection.Click += new System.EventHandler(this.buttonInvertSelection_Click);
			// 
			// buttonSelectAll
			// 
			this.buttonSelectAll.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.buttonSelectAll.Location = new System.Drawing.Point(379, 673);
			this.buttonSelectAll.Name = "buttonSelectAll";
			this.buttonSelectAll.Size = new System.Drawing.Size(110, 40);
			this.buttonSelectAll.TabIndex = 19;
			this.buttonSelectAll.Text = "Select All";
			this.buttonSelectAll.UseVisualStyleBackColor = true;
			this.buttonSelectAll.Click += new System.EventHandler(this.buttonSelectAll_Click);
			// 
			// buttonDeselectAll
			// 
			this.buttonDeselectAll.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.buttonDeselectAll.Location = new System.Drawing.Point(495, 673);
			this.buttonDeselectAll.Name = "buttonDeselectAll";
			this.buttonDeselectAll.Size = new System.Drawing.Size(110, 40);
			this.buttonDeselectAll.TabIndex = 20;
			this.buttonDeselectAll.Text = "Deselect All";
			this.buttonDeselectAll.UseVisualStyleBackColor = true;
			this.buttonDeselectAll.Click += new System.EventHandler(this.buttonDeselectAll_Click);
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(11, 123);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(96, 17);
			this.label2.TabIndex = 21;
			this.label2.Text = "WAVE Entries";
			// 
			// treeViewAudio
			// 
			this.treeViewAudio.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
			this.treeViewAudio.Location = new System.Drawing.Point(14, 143);
			this.treeViewAudio.Name = "treeViewAudio";
			this.treeViewAudio.ShowLines = false;
			this.treeViewAudio.ShowPlusMinus = false;
			this.treeViewAudio.ShowRootLines = false;
			this.treeViewAudio.Size = new System.Drawing.Size(270, 337);
			this.treeViewAudio.TabIndex = 27;
			this.treeViewAudio.AfterCheck += new System.Windows.Forms.TreeViewEventHandler(this.treeViewAudio_AfterCheck);
			this.treeViewAudio.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeViewAudio_AfterSelect);
			this.treeViewAudio.DoubleClick += new System.EventHandler(this.treeViewAudio_DoubleClick);
			this.treeViewAudio.KeyDown += new System.Windows.Forms.KeyEventHandler(this.treeViewAudio_KeyDown);
			// 
			// buttonCancel
			// 
			this.buttonCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.buttonCancel.Enabled = false;
			this.buttonCancel.Location = new System.Drawing.Point(621, 89);
			this.buttonCancel.Margin = new System.Windows.Forms.Padding(4);
			this.buttonCancel.Name = "buttonCancel";
			this.buttonCancel.Size = new System.Drawing.Size(100, 28);
			this.buttonCancel.TabIndex = 28;
			this.buttonCancel.Text = "Cancel";
			this.buttonCancel.UseVisualStyleBackColor = true;
			this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
			// 
			// treeViewSoundInfo
			// 
			this.treeViewSoundInfo.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.treeViewSoundInfo.Location = new System.Drawing.Point(291, 143);
			this.treeViewSoundInfo.Name = "treeViewSoundInfo";
			this.treeViewSoundInfo.ShowLines = false;
			this.treeViewSoundInfo.ShowPlusMinus = false;
			this.treeViewSoundInfo.ShowRootLines = false;
			this.treeViewSoundInfo.Size = new System.Drawing.Size(428, 337);
			this.treeViewSoundInfo.TabIndex = 29;
			this.treeViewSoundInfo.NodeMouseDoubleClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.treeView1_NodeMouseDoubleClick);
			this.treeViewSoundInfo.KeyDown += new System.Windows.Forms.KeyEventHandler(this.treeViewSoundInfo_KeyDown);
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(288, 123);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(212, 17);
			this.label3.TabIndex = 30;
			this.label3.Text = "Sound - Associated WAVE Entry";
			// 
			// labelFileLabel
			// 
			this.labelFileLabel.AutoSize = true;
			this.labelFileLabel.Location = new System.Drawing.Point(12, 100);
			this.labelFileLabel.Name = "labelFileLabel";
			this.labelFileLabel.Size = new System.Drawing.Size(95, 17);
			this.labelFileLabel.TabIndex = 31;
			this.labelFileLabel.Text = "labelFileLabel";
			// 
			// audioPlaybackPanel1
			// 
			this.audioPlaybackPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.audioPlaybackPanel1.Location = new System.Drawing.Point(12, 539);
			this.audioPlaybackPanel1.Name = "audioPlaybackPanel1";
			this.audioPlaybackPanel1.Size = new System.Drawing.Size(706, 128);
			this.audioPlaybackPanel1.TabIndex = 32;
			this.audioPlaybackPanel1.TargetStreams = null;
			// 
			// labelPreview
			// 
			this.labelPreview.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.labelPreview.AutoSize = true;
			this.labelPreview.Location = new System.Drawing.Point(15, 507);
			this.labelPreview.Name = "labelPreview";
			this.labelPreview.Size = new System.Drawing.Size(61, 17);
			this.labelPreview.TabIndex = 33;
			this.labelPreview.Text = "Preview:";
			// 
			// label4
			// 
			this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.label4.AutoSize = true;
			this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label4.Location = new System.Drawing.Point(291, 487);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(435, 17);
			this.label4.TabIndex = 34;
			this.label4.Text = "Note: Double-click or press Enter to jump to a Sound\'s WAVE Entry.";
			// 
			// checkBox1
			// 
			this.checkBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.checkBox1.AutoSize = true;
			this.checkBox1.Enabled = false;
			this.checkBox1.Location = new System.Drawing.Point(549, 61);
			this.checkBox1.Name = "checkBox1";
			this.checkBox1.Size = new System.Drawing.Size(177, 21);
			this.checkBox1.TabIndex = 35;
			this.checkBox1.Text = "Create Group Directory";
			this.checkBox1.UseVisualStyleBackColor = true;
			this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
			// 
			// multiWAVExportForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.CancelButton = this.buttonCancel;
			this.ClientSize = new System.Drawing.Size(733, 725);
			this.Controls.Add(this.checkBox1);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.labelPreview);
			this.Controls.Add(this.audioPlaybackPanel1);
			this.Controls.Add(this.labelFileLabel);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.treeViewSoundInfo);
			this.Controls.Add(this.buttonCancel);
			this.Controls.Add(this.treeViewAudio);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.buttonDeselectAll);
			this.Controls.Add(this.buttonSelectAll);
			this.Controls.Add(this.buttonInvertSelection);
			this.Controls.Add(this.buttonExport);
			this.Controls.Add(this.buttonBrowse);
			this.Controls.Add(this.textBoxExportDirectory);
			this.Controls.Add(this.label1);
			this.Name = "multiWAVExportForm";
			this.Text = "Multi Export WAV";
			this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.multiWAVExportForm_FormClosed);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Button buttonBrowse;
		private System.Windows.Forms.TextBox textBoxExportDirectory;
		private System.Windows.Forms.Button buttonExport;
		private System.ComponentModel.BackgroundWorker backgroundWorkerMultiCreateSawnd;
		private System.Windows.Forms.Button buttonInvertSelection;
		private System.Windows.Forms.Button buttonSelectAll;
		private System.Windows.Forms.Button buttonDeselectAll;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.TreeView treeViewAudio;
		private System.Windows.Forms.ToolTip toolTipNameDefault;
		private System.Windows.Forms.ToolTip toolTipNamePM;
		private System.Windows.Forms.ToolTip toolTipNamePP;
		private System.Windows.Forms.ToolTip toolTipNameManual;
		private System.Windows.Forms.Button buttonCancel;
		private System.Windows.Forms.TreeView treeViewSoundInfo;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label labelFileLabel;
		private BrawlLib.Internal.Windows.Controls.AudioPlaybackPanel audioPlaybackPanel1;
		private System.Windows.Forms.Label labelPreview;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.CheckBox checkBox1;
	}
}