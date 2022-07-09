
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
			this.checkedListBox1 = new System.Windows.Forms.CheckedListBox();
			this.label1 = new System.Windows.Forms.Label();
			this.buttonBrowse = new System.Windows.Forms.Button();
			this.textBoxExportDirectory = new System.Windows.Forms.TextBox();
			this.buttonExport = new System.Windows.Forms.Button();
			this.backgroundWorkerMultiCreateSawnd = new System.ComponentModel.BackgroundWorker();
			this.buttonInvertSelection = new System.Windows.Forms.Button();
			this.buttonSelectAll = new System.Windows.Forms.Button();
			this.buttonDeselectAll = new System.Windows.Forms.Button();
			this.label2 = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// checkedListBox1
			// 
			this.checkedListBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.checkedListBox1.FormattingEnabled = true;
			this.checkedListBox1.Location = new System.Drawing.Point(15, 117);
			this.checkedListBox1.Name = "checkedListBox1";
			this.checkedListBox1.Size = new System.Drawing.Size(450, 378);
			this.checkedListBox1.TabIndex = 0;
			this.checkedListBox1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.checkedListBox1_KeyPress);
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
			this.buttonBrowse.Location = new System.Drawing.Point(431, 27);
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
			this.textBoxExportDirectory.Size = new System.Drawing.Size(408, 22);
			this.textBoxExportDirectory.TabIndex = 13;
			// 
			// buttonExport
			// 
			this.buttonExport.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.buttonExport.Enabled = false;
			this.buttonExport.Location = new System.Drawing.Point(364, 60);
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
			this.buttonInvertSelection.Location = new System.Drawing.Point(354, 501);
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
			this.buttonSelectAll.Location = new System.Drawing.Point(122, 501);
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
			this.buttonDeselectAll.Location = new System.Drawing.Point(238, 501);
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
			this.label2.Location = new System.Drawing.Point(12, 93);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(55, 17);
			this.label2.TabIndex = 21;
			this.label2.Text = "Groups";
			// 
			// multiSawndExportForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(477, 563);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.buttonDeselectAll);
			this.Controls.Add(this.buttonSelectAll);
			this.Controls.Add(this.buttonInvertSelection);
			this.Controls.Add(this.buttonExport);
			this.Controls.Add(this.buttonBrowse);
			this.Controls.Add(this.textBoxExportDirectory);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.checkedListBox1);
			this.Name = "multiSawndExportForm";
			this.Text = "Multi Create Sawnd";
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.CheckedListBox checkedListBox1;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Button buttonBrowse;
		private System.Windows.Forms.TextBox textBoxExportDirectory;
		private System.Windows.Forms.Button buttonExport;
		private System.ComponentModel.BackgroundWorker backgroundWorkerMultiCreateSawnd;
		private System.Windows.Forms.Button buttonInvertSelection;
		private System.Windows.Forms.Button buttonSelectAll;
		private System.Windows.Forms.Button buttonDeselectAll;
		private System.Windows.Forms.Label label2;
	}
}