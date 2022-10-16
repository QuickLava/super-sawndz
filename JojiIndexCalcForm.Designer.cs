
namespace BrawlSoundConverter
{
	partial class ExInfoIndexCalcForm
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
			this.labelPreview = new System.Windows.Forms.Label();
			this.audioPlaybackPanelBankContents = new BrawlLib.Internal.Windows.Controls.AudioPlaybackPanel();
			this.labelTreeViewLabel = new System.Windows.Forms.Label();
			this.treeViewBankContents = new System.Windows.Forms.TreeView();
			this.button2 = new System.Windows.Forms.Button();
			this.numericUpDownSoundbankID = new System.Windows.Forms.NumericUpDown();
			this.labelIDInput = new System.Windows.Forms.Label();
			this.labelNoteValidIDRange = new System.Windows.Forms.Label();
			this.checkBoxHexInput = new System.Windows.Forms.CheckBox();
			this.labelEInfoIndexOut = new System.Windows.Forms.Label();
			this.textBoxEInfoIndexOut = new System.Windows.Forms.TextBox();
			this.checkBoxPPEXMode = new System.Windows.Forms.CheckBox();
			this.labelNoteHexadecimal = new System.Windows.Forms.Label();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDownSoundbankID)).BeginInit();
			this.SuspendLayout();
			// 
			// labelPreview
			// 
			this.labelPreview.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.labelPreview.AutoSize = true;
			this.labelPreview.Location = new System.Drawing.Point(12, 398);
			this.labelPreview.Name = "labelPreview";
			this.labelPreview.Size = new System.Drawing.Size(61, 17);
			this.labelPreview.TabIndex = 14;
			this.labelPreview.Text = "Preview:";
			// 
			// audioPlaybackPanelBankContents
			// 
			this.audioPlaybackPanelBankContents.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.audioPlaybackPanelBankContents.Location = new System.Drawing.Point(12, 421);
			this.audioPlaybackPanelBankContents.Name = "audioPlaybackPanelBankContents";
			this.audioPlaybackPanelBankContents.Size = new System.Drawing.Size(491, 120);
			this.audioPlaybackPanelBankContents.TabIndex = 17;
			this.audioPlaybackPanelBankContents.TabStop = false;
			this.audioPlaybackPanelBankContents.TargetStreams = null;
			// 
			// labelTreeViewLabel
			// 
			this.labelTreeViewLabel.AutoSize = true;
			this.labelTreeViewLabel.Location = new System.Drawing.Point(9, 5);
			this.labelTreeViewLabel.Name = "labelTreeViewLabel";
			this.labelTreeViewLabel.Size = new System.Drawing.Size(188, 17);
			this.labelTreeViewLabel.TabIndex = 20;
			this.labelTreeViewLabel.Text = "Snake Soundbank Contents:";
			// 
			// treeViewBankContents
			// 
			this.treeViewBankContents.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.treeViewBankContents.FullRowSelect = true;
			this.treeViewBankContents.HideSelection = false;
			this.treeViewBankContents.Location = new System.Drawing.Point(12, 25);
			this.treeViewBankContents.Name = "treeViewBankContents";
			this.treeViewBankContents.Size = new System.Drawing.Size(495, 235);
			this.treeViewBankContents.TabIndex = 15;
			this.treeViewBankContents.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeView1_AfterSelect);
			// 
			// button2
			// 
			this.button2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.button2.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.button2.Location = new System.Drawing.Point(432, 549);
			this.button2.Name = "button2";
			this.button2.Size = new System.Drawing.Size(75, 28);
			this.button2.TabIndex = 19;
			this.button2.Text = "Close";
			this.button2.UseVisualStyleBackColor = true;
			// 
			// numericUpDownSoundbankID
			// 
			this.numericUpDownSoundbankID.Location = new System.Drawing.Point(15, 311);
			this.numericUpDownSoundbankID.Maximum = new decimal(new int[] {
            587,
            0,
            0,
            0});
			this.numericUpDownSoundbankID.Minimum = new decimal(new int[] {
            331,
            0,
            0,
            0});
			this.numericUpDownSoundbankID.Name = "numericUpDownSoundbankID";
			this.numericUpDownSoundbankID.Size = new System.Drawing.Size(96, 22);
			this.numericUpDownSoundbankID.TabIndex = 24;
			this.numericUpDownSoundbankID.Value = new decimal(new int[] {
            331,
            0,
            0,
            0});
			this.numericUpDownSoundbankID.ValueChanged += new System.EventHandler(this.numericUpDown1_ValueChanged);
			// 
			// labelIDInput
			// 
			this.labelIDInput.AutoSize = true;
			this.labelIDInput.Location = new System.Drawing.Point(9, 291);
			this.labelIDInput.Name = "labelIDInput";
			this.labelIDInput.Size = new System.Drawing.Size(181, 17);
			this.labelIDInput.TabIndex = 25;
			this.labelIDInput.Text = "Targeted EX Soundbank ID";
			// 
			// labelNoteValidIDRange
			// 
			this.labelNoteValidIDRange.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.labelNoteValidIDRange.AutoSize = true;
			this.labelNoteValidIDRange.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.labelNoteValidIDRange.Location = new System.Drawing.Point(16, 264);
			this.labelNoteValidIDRange.Name = "labelNoteValidIDRange";
			this.labelNoteValidIDRange.Size = new System.Drawing.Size(491, 17);
			this.labelNoteValidIDRange.TabIndex = 26;
			this.labelNoteValidIDRange.Text = "Note: Valid EX Soundbank ID Range: 331- 587 (Dec.) / 0x14B - 0x24B (Hex).";
			// 
			// checkBoxHexInput
			// 
			this.checkBoxHexInput.AutoSize = true;
			this.checkBoxHexInput.Location = new System.Drawing.Point(124, 312);
			this.checkBoxHexInput.Name = "checkBoxHexInput";
			this.checkBoxHexInput.Size = new System.Drawing.Size(145, 21);
			this.checkBoxHexInput.TabIndex = 27;
			this.checkBoxHexInput.Text = "Hexadecimal Input";
			this.checkBoxHexInput.UseVisualStyleBackColor = true;
			this.checkBoxHexInput.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
			// 
			// labelEInfoIndexOut
			// 
			this.labelEInfoIndexOut.AutoSize = true;
			this.labelEInfoIndexOut.Location = new System.Drawing.Point(9, 343);
			this.labelEInfoIndexOut.Name = "labelEInfoIndexOut";
			this.labelEInfoIndexOut.Size = new System.Drawing.Size(205, 17);
			this.labelEInfoIndexOut.TabIndex = 28;
			this.labelEInfoIndexOut.Text = "Calculated Expanded Info Index";
			// 
			// textBoxEInfoIndexOut
			// 
			this.textBoxEInfoIndexOut.Location = new System.Drawing.Point(12, 363);
			this.textBoxEInfoIndexOut.Name = "textBoxEInfoIndexOut";
			this.textBoxEInfoIndexOut.Size = new System.Drawing.Size(97, 22);
			this.textBoxEInfoIndexOut.TabIndex = 29;
			// 
			// checkBoxPPEXMode
			// 
			this.checkBoxPPEXMode.AutoSize = true;
			this.checkBoxPPEXMode.Location = new System.Drawing.Point(275, 312);
			this.checkBoxPPEXMode.Name = "checkBoxPPEXMode";
			this.checkBoxPPEXMode.Size = new System.Drawing.Size(152, 21);
			this.checkBoxPPEXMode.TabIndex = 30;
			this.checkBoxPPEXMode.Text = "Enable P+EX Mode";
			this.checkBoxPPEXMode.UseVisualStyleBackColor = true;
			this.checkBoxPPEXMode.CheckedChanged += new System.EventHandler(this.checkBox2_CheckedChanged);
			// 
			// labelNoteHexadecimal
			// 
			this.labelNoteHexadecimal.AutoSize = true;
			this.labelNoteHexadecimal.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.labelNoteHexadecimal.Location = new System.Drawing.Point(121, 366);
			this.labelNoteHexadecimal.Name = "labelNoteHexadecimal";
			this.labelNoteHexadecimal.Size = new System.Drawing.Size(308, 17);
			this.labelNoteHexadecimal.TabIndex = 31;
			this.labelNoteHexadecimal.Text = "Note: Calculated Info Indeces are always in hex.";
			// 
			// ExInfoIndexCalcForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(517, 589);
			this.Controls.Add(this.labelNoteHexadecimal);
			this.Controls.Add(this.checkBoxPPEXMode);
			this.Controls.Add(this.textBoxEInfoIndexOut);
			this.Controls.Add(this.labelEInfoIndexOut);
			this.Controls.Add(this.checkBoxHexInput);
			this.Controls.Add(this.labelNoteValidIDRange);
			this.Controls.Add(this.numericUpDownSoundbankID);
			this.Controls.Add(this.labelIDInput);
			this.Controls.Add(this.labelPreview);
			this.Controls.Add(this.audioPlaybackPanelBankContents);
			this.Controls.Add(this.labelTreeViewLabel);
			this.Controls.Add(this.treeViewBankContents);
			this.Controls.Add(this.button2);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "ExInfoIndexCalcForm";
			this.Text = "Expanded Info Index Calculator";
			((System.ComponentModel.ISupportInitialize)(this.numericUpDownSoundbankID)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion
		private System.Windows.Forms.Label labelPreview;
		private BrawlLib.Internal.Windows.Controls.AudioPlaybackPanel audioPlaybackPanelBankContents;
		private System.Windows.Forms.Label labelTreeViewLabel;
		private System.Windows.Forms.TreeView treeViewBankContents;
		private System.Windows.Forms.Button button2;
		private System.Windows.Forms.NumericUpDown numericUpDownSoundbankID;
		private System.Windows.Forms.Label labelIDInput;
		private System.Windows.Forms.Label labelNoteValidIDRange;
		private System.Windows.Forms.CheckBox checkBoxHexInput;
		private System.Windows.Forms.Label labelEInfoIndexOut;
		private System.Windows.Forms.TextBox textBoxEInfoIndexOut;
		private System.Windows.Forms.CheckBox checkBoxPPEXMode;
		private System.Windows.Forms.Label labelNoteHexadecimal;
	}
}