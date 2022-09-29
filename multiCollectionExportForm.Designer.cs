
namespace BrawlSoundConverter
{
	partial class multiCollectionExportForm
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
			this.label1 = new System.Windows.Forms.Label();
			this.buttonBrowse = new System.Windows.Forms.Button();
			this.textBoxExportDirectory = new System.Windows.Forms.TextBox();
			this.buttonExport = new System.Windows.Forms.Button();
			this.buttonInvertSelection = new System.Windows.Forms.Button();
			this.buttonSelectAll = new System.Windows.Forms.Button();
			this.buttonDeselectAll = new System.Windows.Forms.Button();
			this.label2 = new System.Windows.Forms.Label();
			this.buttonCancel = new System.Windows.Forms.Button();
			this.labelPreview = new System.Windows.Forms.Label();
			this.treeViewSounds = new System.Windows.Forms.TreeView();
			this.label3 = new System.Windows.Forms.Label();
			this.treeViewCollections = new System.Windows.Forms.TreeView();
			this.audioPlaybackPanel1 = new BrawlLib.Internal.Windows.Controls.AudioPlaybackPanel();
			this.checkBox1 = new System.Windows.Forms.CheckBox();
			this.checkBox2 = new System.Windows.Forms.CheckBox();
			this.checkBox3 = new System.Windows.Forms.CheckBox();
			this.label5 = new System.Windows.Forms.Label();
			this.treeViewCollectionDetails = new System.Windows.Forms.TreeView();
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
			this.buttonBrowse.Location = new System.Drawing.Point(911, 27);
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
			this.textBoxExportDirectory.Size = new System.Drawing.Size(888, 22);
			this.textBoxExportDirectory.TabIndex = 13;
			this.textBoxExportDirectory.TextChanged += new System.EventHandler(this.textBoxExportDirectory_TextChanged);
			// 
			// buttonExport
			// 
			this.buttonExport.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.buttonExport.Enabled = false;
			this.buttonExport.Location = new System.Drawing.Point(736, 60);
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
			this.buttonInvertSelection.Location = new System.Drawing.Point(834, 662);
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
			this.buttonSelectAll.Location = new System.Drawing.Point(602, 662);
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
			this.buttonDeselectAll.Location = new System.Drawing.Point(718, 662);
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
			this.label2.Location = new System.Drawing.Point(12, 86);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(76, 17);
			this.label2.TabIndex = 21;
			this.label2.Text = "Collections";
			// 
			// buttonCancel
			// 
			this.buttonCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.buttonCancel.Enabled = false;
			this.buttonCancel.Location = new System.Drawing.Point(844, 59);
			this.buttonCancel.Margin = new System.Windows.Forms.Padding(4);
			this.buttonCancel.Name = "buttonCancel";
			this.buttonCancel.Size = new System.Drawing.Size(100, 28);
			this.buttonCancel.TabIndex = 28;
			this.buttonCancel.Text = "Cancel";
			this.buttonCancel.UseVisualStyleBackColor = true;
			this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
			// 
			// labelPreview
			// 
			this.labelPreview.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.labelPreview.AutoSize = true;
			this.labelPreview.Location = new System.Drawing.Point(17, 484);
			this.labelPreview.Name = "labelPreview";
			this.labelPreview.Size = new System.Drawing.Size(61, 17);
			this.labelPreview.TabIndex = 36;
			this.labelPreview.Text = "Preview:";
			// 
			// treeViewSounds
			// 
			this.treeViewSounds.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.treeViewSounds.Location = new System.Drawing.Point(524, 106);
			this.treeViewSounds.Name = "treeViewSounds";
			this.treeViewSounds.ShowLines = false;
			this.treeViewSounds.ShowPlusMinus = false;
			this.treeViewSounds.ShowRootLines = false;
			this.treeViewSounds.Size = new System.Drawing.Size(419, 153);
			this.treeViewSounds.TabIndex = 34;
			this.treeViewSounds.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeViewSounds_AfterSelect);
			// 
			// label3
			// 
			this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(525, 86);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(129, 17);
			this.label3.TabIndex = 37;
			this.label3.Text = "Collection Contents";
			// 
			// treeViewCollections
			// 
			this.treeViewCollections.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.treeViewCollections.CheckBoxes = true;
			this.treeViewCollections.HideSelection = false;
			this.treeViewCollections.Location = new System.Drawing.Point(15, 106);
			this.treeViewCollections.Name = "treeViewCollections";
			this.treeViewCollections.ShowLines = false;
			this.treeViewCollections.ShowPlusMinus = false;
			this.treeViewCollections.ShowRootLines = false;
			this.treeViewCollections.Size = new System.Drawing.Size(504, 330);
			this.treeViewCollections.TabIndex = 27;
			this.treeViewCollections.AfterCheck += new System.Windows.Forms.TreeViewEventHandler(this.treeViewGroups_AfterCheck);
			this.treeViewCollections.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeViewCollections_AfterSelect);
			this.treeViewCollections.DoubleClick += new System.EventHandler(this.treeViewGroups_DoubleClick);
			this.treeViewCollections.KeyDown += new System.Windows.Forms.KeyEventHandler(this.treeViewCollections_KeyDown);
			// 
			// audioPlaybackPanel1
			// 
			this.audioPlaybackPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.audioPlaybackPanel1.Location = new System.Drawing.Point(14, 516);
			this.audioPlaybackPanel1.Name = "audioPlaybackPanel1";
			this.audioPlaybackPanel1.Size = new System.Drawing.Size(929, 109);
			this.audioPlaybackPanel1.TabIndex = 35;
			this.audioPlaybackPanel1.TargetStreams = null;
			// 
			// checkBox1
			// 
			this.checkBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.checkBox1.AutoSize = true;
			this.checkBox1.Location = new System.Drawing.Point(14, 442);
			this.checkBox1.Name = "checkBox1";
			this.checkBox1.Size = new System.Drawing.Size(117, 21);
			this.checkBox1.TabIndex = 38;
			this.checkBox1.Text = "Show RWSDs";
			this.checkBox1.UseVisualStyleBackColor = true;
			this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
			// 
			// checkBox2
			// 
			this.checkBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.checkBox2.AutoSize = true;
			this.checkBox2.Location = new System.Drawing.Point(137, 442);
			this.checkBox2.Name = "checkBox2";
			this.checkBox2.Size = new System.Drawing.Size(113, 21);
			this.checkBox2.TabIndex = 39;
			this.checkBox2.Text = "Show RBNKs";
			this.checkBox2.UseVisualStyleBackColor = true;
			this.checkBox2.CheckedChanged += new System.EventHandler(this.checkBox2_CheckedChanged);
			// 
			// checkBox3
			// 
			this.checkBox3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.checkBox3.AutoSize = true;
			this.checkBox3.Location = new System.Drawing.Point(256, 442);
			this.checkBox3.Name = "checkBox3";
			this.checkBox3.Size = new System.Drawing.Size(114, 21);
			this.checkBox3.TabIndex = 40;
			this.checkBox3.Text = "Show RSEQs";
			this.checkBox3.UseVisualStyleBackColor = true;
			this.checkBox3.CheckedChanged += new System.EventHandler(this.checkBox3_CheckedChanged);
			// 
			// label5
			// 
			this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.label5.AutoSize = true;
			this.label5.Location = new System.Drawing.Point(525, 262);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(116, 17);
			this.label5.TabIndex = 44;
			this.label5.Text = "Collection Details";
			// 
			// treeViewCollectionDetails
			// 
			this.treeViewCollectionDetails.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.treeViewCollectionDetails.Location = new System.Drawing.Point(524, 282);
			this.treeViewCollectionDetails.Name = "treeViewCollectionDetails";
			this.treeViewCollectionDetails.Size = new System.Drawing.Size(420, 154);
			this.treeViewCollectionDetails.TabIndex = 43;
			// 
			// multiCollectionExportForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.CancelButton = this.buttonCancel;
			this.ClientSize = new System.Drawing.Size(957, 724);
			this.Controls.Add(this.label5);
			this.Controls.Add(this.treeViewCollectionDetails);
			this.Controls.Add(this.checkBox3);
			this.Controls.Add(this.checkBox2);
			this.Controls.Add(this.checkBox1);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.labelPreview);
			this.Controls.Add(this.audioPlaybackPanel1);
			this.Controls.Add(this.treeViewSounds);
			this.Controls.Add(this.buttonCancel);
			this.Controls.Add(this.treeViewCollections);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.buttonDeselectAll);
			this.Controls.Add(this.buttonSelectAll);
			this.Controls.Add(this.buttonInvertSelection);
			this.Controls.Add(this.buttonExport);
			this.Controls.Add(this.buttonBrowse);
			this.Controls.Add(this.textBoxExportDirectory);
			this.Controls.Add(this.label1);
			this.Name = "multiCollectionExportForm";
			this.Text = "Export Collections";
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Button buttonBrowse;
		private System.Windows.Forms.TextBox textBoxExportDirectory;
		private System.Windows.Forms.Button buttonExport;
		private System.Windows.Forms.Button buttonInvertSelection;
		private System.Windows.Forms.Button buttonSelectAll;
		private System.Windows.Forms.Button buttonDeselectAll;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Button buttonCancel;
		private System.Windows.Forms.Label labelPreview;
		private BrawlLib.Internal.Windows.Controls.AudioPlaybackPanel audioPlaybackPanel1;
		private System.Windows.Forms.TreeView treeViewSounds;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.TreeView treeViewCollections;
		private System.Windows.Forms.CheckBox checkBox1;
		private System.Windows.Forms.CheckBox checkBox2;
		private System.Windows.Forms.CheckBox checkBox3;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.TreeView treeViewCollectionDetails;
	}
}