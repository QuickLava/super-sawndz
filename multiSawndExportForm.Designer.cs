
namespace BrawlSoundConverter
{
	partial class multiSawndExportForm
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
			this.radioButtonNameDefault = new System.Windows.Forms.RadioButton();
			this.radioButtonNamePM = new System.Windows.Forms.RadioButton();
			this.radioButtonNamePP = new System.Windows.Forms.RadioButton();
			this.groupBoxNamingScheme = new System.Windows.Forms.GroupBox();
			this.radioButtonNameManual = new System.Windows.Forms.RadioButton();
			this.treeViewGroups = new System.Windows.Forms.TreeView();
			this.toolTipNameDefault = new System.Windows.Forms.ToolTip(this.components);
			this.toolTipNamePM = new System.Windows.Forms.ToolTip(this.components);
			this.toolTipNamePP = new System.Windows.Forms.ToolTip(this.components);
			this.toolTipNameManual = new System.Windows.Forms.ToolTip(this.components);
			this.buttonCancel = new System.Windows.Forms.Button();
			this.groupBoxNamingScheme.SuspendLayout();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(12, 9);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(109, 17);
			this.label1.TabIndex = 10;
			this.label1.Text = "Export Directory";
			// 
			// buttonBrowse
			// 
			this.buttonBrowse.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.buttonBrowse.Location = new System.Drawing.Point(431, 27);
			this.buttonBrowse.Margin = new System.Windows.Forms.Padding(4);
			this.buttonBrowse.Name = "buttonBrowse";
			this.buttonBrowse.Size = new System.Drawing.Size(33, 25);
			this.buttonBrowse.TabIndex = 0;
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
			this.textBoxExportDirectory.Size = new System.Drawing.Size(408, 22);
			this.textBoxExportDirectory.TabIndex = 9;
			this.textBoxExportDirectory.TabStop = false;
			this.textBoxExportDirectory.TextChanged += new System.EventHandler(this.textBoxExportDirectory_TextChanged);
			// 
			// buttonExport
			// 
			this.buttonExport.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.buttonExport.Enabled = false;
			this.buttonExport.Location = new System.Drawing.Point(256, 60);
			this.buttonExport.Margin = new System.Windows.Forms.Padding(4);
			this.buttonExport.Name = "buttonExport";
			this.buttonExport.Size = new System.Drawing.Size(100, 28);
			this.buttonExport.TabIndex = 1;
			this.buttonExport.Text = "Export";
			this.buttonExport.UseVisualStyleBackColor = true;
			this.buttonExport.Click += new System.EventHandler(this.buttonExport_Click);
			// 
			// buttonInvertSelection
			// 
			this.buttonInvertSelection.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.buttonInvertSelection.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.7F);
			this.buttonInvertSelection.Location = new System.Drawing.Point(354, 526);
			this.buttonInvertSelection.Name = "buttonInvertSelection";
			this.buttonInvertSelection.Size = new System.Drawing.Size(110, 40);
			this.buttonInvertSelection.TabIndex = 6;
			this.buttonInvertSelection.Text = "Invert Selection";
			this.buttonInvertSelection.UseVisualStyleBackColor = true;
			this.buttonInvertSelection.Click += new System.EventHandler(this.buttonInvertSelection_Click);
			// 
			// buttonSelectAll
			// 
			this.buttonSelectAll.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.buttonSelectAll.Location = new System.Drawing.Point(122, 526);
			this.buttonSelectAll.Name = "buttonSelectAll";
			this.buttonSelectAll.Size = new System.Drawing.Size(110, 40);
			this.buttonSelectAll.TabIndex = 4;
			this.buttonSelectAll.Text = "Select All";
			this.buttonSelectAll.UseVisualStyleBackColor = true;
			this.buttonSelectAll.Click += new System.EventHandler(this.buttonSelectAll_Click);
			// 
			// buttonDeselectAll
			// 
			this.buttonDeselectAll.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.buttonDeselectAll.Location = new System.Drawing.Point(238, 526);
			this.buttonDeselectAll.Name = "buttonDeselectAll";
			this.buttonDeselectAll.Size = new System.Drawing.Size(110, 40);
			this.buttonDeselectAll.TabIndex = 5;
			this.buttonDeselectAll.Text = "Deselect All";
			this.buttonDeselectAll.UseVisualStyleBackColor = true;
			this.buttonDeselectAll.Click += new System.EventHandler(this.buttonDeselectAll_Click);
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(12, 148);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(55, 17);
			this.label2.TabIndex = 3;
			this.label2.Text = "Groups";
			// 
			// radioButtonNameDefault
			// 
			this.radioButtonNameDefault.AutoSize = true;
			this.radioButtonNameDefault.Location = new System.Drawing.Point(6, 21);
			this.radioButtonNameDefault.Name = "radioButtonNameDefault";
			this.radioButtonNameDefault.Size = new System.Drawing.Size(74, 21);
			this.radioButtonNameDefault.TabIndex = 0;
			this.radioButtonNameDefault.TabStop = true;
			this.radioButtonNameDefault.Text = "Default";
			this.radioButtonNameDefault.UseVisualStyleBackColor = true;
			// 
			// radioButtonNamePM
			// 
			this.radioButtonNamePM.AutoSize = true;
			this.radioButtonNamePM.Location = new System.Drawing.Point(86, 21);
			this.radioButtonNamePM.Name = "radioButtonNamePM";
			this.radioButtonNamePM.Size = new System.Drawing.Size(134, 21);
			this.radioButtonNamePM.TabIndex = 1;
			this.radioButtonNamePM.TabStop = true;
			this.radioButtonNamePM.Text = "Brawl / Project M";
			this.radioButtonNamePM.UseVisualStyleBackColor = true;
			// 
			// radioButtonNamePP
			// 
			this.radioButtonNamePP.AutoSize = true;
			this.radioButtonNamePP.Location = new System.Drawing.Point(226, 21);
			this.radioButtonNamePP.Name = "radioButtonNamePP";
			this.radioButtonNamePP.Size = new System.Drawing.Size(81, 21);
			this.radioButtonNamePP.TabIndex = 2;
			this.radioButtonNamePP.TabStop = true;
			this.radioButtonNamePP.Text = "Project+";
			this.radioButtonNamePP.UseVisualStyleBackColor = true;
			// 
			// groupBoxNamingScheme
			// 
			this.groupBoxNamingScheme.Controls.Add(this.radioButtonNameManual);
			this.groupBoxNamingScheme.Controls.Add(this.radioButtonNameDefault);
			this.groupBoxNamingScheme.Controls.Add(this.radioButtonNamePP);
			this.groupBoxNamingScheme.Controls.Add(this.radioButtonNamePM);
			this.groupBoxNamingScheme.Location = new System.Drawing.Point(15, 94);
			this.groupBoxNamingScheme.Name = "groupBoxNamingScheme";
			this.groupBoxNamingScheme.Size = new System.Drawing.Size(446, 51);
			this.groupBoxNamingScheme.TabIndex = 2;
			this.groupBoxNamingScheme.TabStop = false;
			this.groupBoxNamingScheme.Text = "Naming Scheme";
			// 
			// radioButtonNameManual
			// 
			this.radioButtonNameManual.AutoSize = true;
			this.radioButtonNameManual.Location = new System.Drawing.Point(314, 22);
			this.radioButtonNameManual.Name = "radioButtonNameManual";
			this.radioButtonNameManual.Size = new System.Drawing.Size(76, 21);
			this.radioButtonNameManual.TabIndex = 3;
			this.radioButtonNameManual.TabStop = true;
			this.radioButtonNameManual.Text = "Custom";
			this.radioButtonNameManual.UseVisualStyleBackColor = true;
			// 
			// treeViewGroups
			// 
			this.treeViewGroups.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.treeViewGroups.Location = new System.Drawing.Point(15, 169);
			this.treeViewGroups.Name = "treeViewGroups";
			this.treeViewGroups.ShowLines = false;
			this.treeViewGroups.ShowPlusMinus = false;
			this.treeViewGroups.ShowRootLines = false;
			this.treeViewGroups.Size = new System.Drawing.Size(446, 351);
			this.treeViewGroups.TabIndex = 3;
			this.treeViewGroups.AfterCheck += new System.Windows.Forms.TreeViewEventHandler(this.treeViewGroups_AfterCheck);
			this.treeViewGroups.DoubleClick += new System.EventHandler(this.treeViewGroups_DoubleClick);
			this.treeViewGroups.KeyDown += new System.Windows.Forms.KeyEventHandler(this.treeViewGroups_KeyDown);
			// 
			// buttonCancel
			// 
			this.buttonCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.buttonCancel.Enabled = false;
			this.buttonCancel.Location = new System.Drawing.Point(364, 59);
			this.buttonCancel.Margin = new System.Windows.Forms.Padding(4);
			this.buttonCancel.Name = "buttonCancel";
			this.buttonCancel.Size = new System.Drawing.Size(100, 28);
			this.buttonCancel.TabIndex = 2;
			this.buttonCancel.Text = "Cancel";
			this.buttonCancel.UseVisualStyleBackColor = true;
			this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
			// 
			// multiSawndExportForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.CancelButton = this.buttonCancel;
			this.ClientSize = new System.Drawing.Size(477, 588);
			this.Controls.Add(this.buttonCancel);
			this.Controls.Add(this.treeViewGroups);
			this.Controls.Add(this.groupBoxNamingScheme);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.buttonDeselectAll);
			this.Controls.Add(this.buttonSelectAll);
			this.Controls.Add(this.buttonInvertSelection);
			this.Controls.Add(this.buttonExport);
			this.Controls.Add(this.buttonBrowse);
			this.Controls.Add(this.textBoxExportDirectory);
			this.Controls.Add(this.label1);
			this.Name = "multiSawndExportForm";
			this.Text = "Multi Create Sawnd";
			this.groupBoxNamingScheme.ResumeLayout(false);
			this.groupBoxNamingScheme.PerformLayout();
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
		private System.Windows.Forms.RadioButton radioButtonNameDefault;
		private System.Windows.Forms.RadioButton radioButtonNamePM;
		private System.Windows.Forms.RadioButton radioButtonNamePP;
		private System.Windows.Forms.GroupBox groupBoxNamingScheme;
		private System.Windows.Forms.RadioButton radioButtonNameManual;
		private System.Windows.Forms.TreeView treeViewGroups;
		private System.Windows.Forms.ToolTip toolTipNameDefault;
		private System.Windows.Forms.ToolTip toolTipNamePM;
		private System.Windows.Forms.ToolTip toolTipNamePP;
		private System.Windows.Forms.ToolTip toolTipNameManual;
		private System.Windows.Forms.Button buttonCancel;
	}
}