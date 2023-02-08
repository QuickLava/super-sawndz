
namespace BrawlSoundConverter
{
	partial class WAVPreprocessingForm
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
			this.treeViewMapping = new System.Windows.Forms.TreeView();
			this.audioPlaybackBRSARSound = new BrawlLib.Internal.Windows.Controls.AudioPlaybackPanel();
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.audioPlaybackPanelPreview = new BrawlLib.Internal.Windows.Controls.AudioPlaybackPanel();
			this.label3 = new System.Windows.Forms.Label();
			this.groupBoxProcSettings = new System.Windows.Forms.GroupBox();
			this.textBoxOrigSampleRate = new System.Windows.Forms.TextBox();
			this.textBoxTargetSampleRate = new System.Windows.Forms.TextBox();
			this.label4 = new System.Windows.Forms.Label();
			this.label5 = new System.Windows.Forms.Label();
			this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
			this.buttonResetVolume = new System.Windows.Forms.Button();
			this.buttonResetTempo = new System.Windows.Forms.Button();
			this.numericUpDown2 = new System.Windows.Forms.NumericUpDown();
			this.label6 = new System.Windows.Forms.Label();
			this.buttonResetPitch = new System.Windows.Forms.Button();
			this.numericUpDown3 = new System.Windows.Forms.NumericUpDown();
			this.label7 = new System.Windows.Forms.Label();
			this.buttonApply = new System.Windows.Forms.Button();
			this.buttonReset = new System.Windows.Forms.Button();
			this.label8 = new System.Windows.Forms.Label();
			this.buttonCancel = new System.Windows.Forms.Button();
			this.buttonSave = new System.Windows.Forms.Button();
			this.buttonResetSampleRate = new System.Windows.Forms.Button();
			this.checkBoxSearchGroups = new System.Windows.Forms.CheckBox();
			this.button1 = new System.Windows.Forms.Button();
			this.numericUpDown4 = new System.Windows.Forms.NumericUpDown();
			this.label9 = new System.Windows.Forms.Label();
			this.button2 = new System.Windows.Forms.Button();
			this.numericUpDown5 = new System.Windows.Forms.NumericUpDown();
			this.label10 = new System.Windows.Forms.Label();
			this.button3 = new System.Windows.Forms.Button();
			this.numericUpDown6 = new System.Windows.Forms.NumericUpDown();
			this.label11 = new System.Windows.Forms.Label();
			this.button4 = new System.Windows.Forms.Button();
			this.numericUpDown7 = new System.Windows.Forms.NumericUpDown();
			this.label12 = new System.Windows.Forms.Label();
			this.groupBoxProcSettings.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDown2)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDown3)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDown4)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDown5)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDown6)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDown7)).BeginInit();
			this.SuspendLayout();
			// 
			// treeViewMapping
			// 
			this.treeViewMapping.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.treeViewMapping.FullRowSelect = true;
			this.treeViewMapping.HideSelection = false;
			this.treeViewMapping.Location = new System.Drawing.Point(470, 30);
			this.treeViewMapping.Margin = new System.Windows.Forms.Padding(4);
			this.treeViewMapping.Name = "treeViewMapping";
			this.treeViewMapping.Size = new System.Drawing.Size(407, 166);
			this.treeViewMapping.TabIndex = 29;
			// 
			// audioPlaybackBRSARSound
			// 
			this.audioPlaybackBRSARSound.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.audioPlaybackBRSARSound.Location = new System.Drawing.Point(470, 204);
			this.audioPlaybackBRSARSound.Margin = new System.Windows.Forms.Padding(4);
			this.audioPlaybackBRSARSound.Name = "audioPlaybackBRSARSound";
			this.audioPlaybackBRSARSound.Size = new System.Drawing.Size(407, 100);
			this.audioPlaybackBRSARSound.TabIndex = 30;
			this.audioPlaybackBRSARSound.TabStop = false;
			this.audioPlaybackBRSARSound.TargetStreams = null;
			// 
			// label1
			// 
			this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(467, 9);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(156, 17);
			this.label1.TabIndex = 31;
			this.label1.Text = "Existing Bank Contents:";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(13, 9);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(137, 17);
			this.label2.TabIndex = 32;
			this.label2.Text = "Processing Settings:";
			// 
			// audioPlaybackPanelPreview
			// 
			this.audioPlaybackPanelPreview.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.audioPlaybackPanelPreview.Location = new System.Drawing.Point(12, 255);
			this.audioPlaybackPanelPreview.Name = "audioPlaybackPanelPreview";
			this.audioPlaybackPanelPreview.Size = new System.Drawing.Size(417, 120);
			this.audioPlaybackPanelPreview.TabIndex = 33;
			this.audioPlaybackPanelPreview.TargetStreams = null;
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(6, 18);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(146, 17);
			this.label3.TabIndex = 34;
			this.label3.Text = "Original Sample Rate:";
			// 
			// groupBoxProcSettings
			// 
			this.groupBoxProcSettings.Controls.Add(this.button3);
			this.groupBoxProcSettings.Controls.Add(this.numericUpDown6);
			this.groupBoxProcSettings.Controls.Add(this.label11);
			this.groupBoxProcSettings.Controls.Add(this.button4);
			this.groupBoxProcSettings.Controls.Add(this.numericUpDown7);
			this.groupBoxProcSettings.Controls.Add(this.label12);
			this.groupBoxProcSettings.Controls.Add(this.button2);
			this.groupBoxProcSettings.Controls.Add(this.numericUpDown5);
			this.groupBoxProcSettings.Controls.Add(this.label10);
			this.groupBoxProcSettings.Controls.Add(this.button1);
			this.groupBoxProcSettings.Controls.Add(this.numericUpDown4);
			this.groupBoxProcSettings.Controls.Add(this.label9);
			this.groupBoxProcSettings.Controls.Add(this.checkBoxSearchGroups);
			this.groupBoxProcSettings.Controls.Add(this.buttonResetSampleRate);
			this.groupBoxProcSettings.Controls.Add(this.label8);
			this.groupBoxProcSettings.Controls.Add(this.buttonReset);
			this.groupBoxProcSettings.Controls.Add(this.buttonApply);
			this.groupBoxProcSettings.Controls.Add(this.buttonResetPitch);
			this.groupBoxProcSettings.Controls.Add(this.audioPlaybackPanelPreview);
			this.groupBoxProcSettings.Controls.Add(this.numericUpDown3);
			this.groupBoxProcSettings.Controls.Add(this.label7);
			this.groupBoxProcSettings.Controls.Add(this.buttonResetTempo);
			this.groupBoxProcSettings.Controls.Add(this.numericUpDown2);
			this.groupBoxProcSettings.Controls.Add(this.label6);
			this.groupBoxProcSettings.Controls.Add(this.buttonResetVolume);
			this.groupBoxProcSettings.Controls.Add(this.numericUpDown1);
			this.groupBoxProcSettings.Controls.Add(this.label5);
			this.groupBoxProcSettings.Controls.Add(this.label4);
			this.groupBoxProcSettings.Controls.Add(this.textBoxTargetSampleRate);
			this.groupBoxProcSettings.Controls.Add(this.textBoxOrigSampleRate);
			this.groupBoxProcSettings.Controls.Add(this.label3);
			this.groupBoxProcSettings.Location = new System.Drawing.Point(16, 30);
			this.groupBoxProcSettings.Name = "groupBoxProcSettings";
			this.groupBoxProcSettings.Size = new System.Drawing.Size(440, 393);
			this.groupBoxProcSettings.TabIndex = 35;
			this.groupBoxProcSettings.TabStop = false;
			// 
			// textBoxOrigSampleRate
			// 
			this.textBoxOrigSampleRate.Enabled = false;
			this.textBoxOrigSampleRate.Location = new System.Drawing.Point(9, 39);
			this.textBoxOrigSampleRate.Name = "textBoxOrigSampleRate";
			this.textBoxOrigSampleRate.Size = new System.Drawing.Size(200, 22);
			this.textBoxOrigSampleRate.TabIndex = 35;
			// 
			// textBoxTargetSampleRate
			// 
			this.textBoxTargetSampleRate.Location = new System.Drawing.Point(215, 39);
			this.textBoxTargetSampleRate.Name = "textBoxTargetSampleRate";
			this.textBoxTargetSampleRate.Size = new System.Drawing.Size(200, 22);
			this.textBoxTargetSampleRate.TabIndex = 36;
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(212, 18);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(139, 17);
			this.label4.TabIndex = 37;
			this.label4.Text = "Target Sample Rate:";
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Location = new System.Drawing.Point(7, 68);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(113, 17);
			this.label5.TabIndex = 38;
			this.label5.Text = "Volume Modifier:";
			// 
			// numericUpDown1
			// 
			this.numericUpDown1.Location = new System.Drawing.Point(10, 89);
			this.numericUpDown1.Name = "numericUpDown1";
			this.numericUpDown1.Size = new System.Drawing.Size(75, 22);
			this.numericUpDown1.TabIndex = 39;
			// 
			// buttonResetVolume
			// 
			this.buttonResetVolume.Location = new System.Drawing.Point(84, 88);
			this.buttonResetVolume.Name = "buttonResetVolume";
			this.buttonResetVolume.Size = new System.Drawing.Size(23, 23);
			this.buttonResetVolume.TabIndex = 42;
			this.buttonResetVolume.Text = "*";
			this.buttonResetVolume.UseVisualStyleBackColor = true;
			// 
			// buttonResetTempo
			// 
			this.buttonResetTempo.Location = new System.Drawing.Point(84, 144);
			this.buttonResetTempo.Name = "buttonResetTempo";
			this.buttonResetTempo.Size = new System.Drawing.Size(23, 23);
			this.buttonResetTempo.TabIndex = 45;
			this.buttonResetTempo.Text = "*";
			this.buttonResetTempo.UseVisualStyleBackColor = true;
			// 
			// numericUpDown2
			// 
			this.numericUpDown2.Location = new System.Drawing.Point(10, 144);
			this.numericUpDown2.Name = "numericUpDown2";
			this.numericUpDown2.Size = new System.Drawing.Size(75, 22);
			this.numericUpDown2.TabIndex = 44;
			// 
			// label6
			// 
			this.label6.AutoSize = true;
			this.label6.Location = new System.Drawing.Point(6, 124);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(110, 17);
			this.label6.TabIndex = 43;
			this.label6.Text = "Tempo Modifier:";
			// 
			// buttonResetPitch
			// 
			this.buttonResetPitch.Location = new System.Drawing.Point(187, 143);
			this.buttonResetPitch.Name = "buttonResetPitch";
			this.buttonResetPitch.Size = new System.Drawing.Size(23, 23);
			this.buttonResetPitch.TabIndex = 48;
			this.buttonResetPitch.Text = "*";
			this.buttonResetPitch.UseVisualStyleBackColor = true;
			// 
			// numericUpDown3
			// 
			this.numericUpDown3.Location = new System.Drawing.Point(113, 144);
			this.numericUpDown3.Name = "numericUpDown3";
			this.numericUpDown3.Size = new System.Drawing.Size(75, 22);
			this.numericUpDown3.TabIndex = 47;
			// 
			// label7
			// 
			this.label7.AutoSize = true;
			this.label7.Location = new System.Drawing.Point(110, 124);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(97, 17);
			this.label7.TabIndex = 46;
			this.label7.Text = "Pitch Modifier:";
			// 
			// buttonApply
			// 
			this.buttonApply.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.buttonApply.Enabled = false;
			this.buttonApply.Location = new System.Drawing.Point(333, 230);
			this.buttonApply.Margin = new System.Windows.Forms.Padding(4);
			this.buttonApply.Name = "buttonApply";
			this.buttonApply.Size = new System.Drawing.Size(100, 28);
			this.buttonApply.TabIndex = 49;
			this.buttonApply.Text = "Apply";
			this.buttonApply.UseVisualStyleBackColor = true;
			// 
			// buttonReset
			// 
			this.buttonReset.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.buttonReset.Enabled = false;
			this.buttonReset.Location = new System.Drawing.Point(225, 231);
			this.buttonReset.Margin = new System.Windows.Forms.Padding(4);
			this.buttonReset.Name = "buttonReset";
			this.buttonReset.Size = new System.Drawing.Size(100, 28);
			this.buttonReset.TabIndex = 50;
			this.buttonReset.Text = "Reset";
			this.buttonReset.UseVisualStyleBackColor = true;
			// 
			// label8
			// 
			this.label8.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.label8.AutoSize = true;
			this.label8.Location = new System.Drawing.Point(12, 232);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(61, 17);
			this.label8.TabIndex = 51;
			this.label8.Text = "Preview:";
			// 
			// buttonCancel
			// 
			this.buttonCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.buttonCancel.Location = new System.Drawing.Point(777, 350);
			this.buttonCancel.Margin = new System.Windows.Forms.Padding(4);
			this.buttonCancel.Name = "buttonCancel";
			this.buttonCancel.Size = new System.Drawing.Size(100, 28);
			this.buttonCancel.TabIndex = 37;
			this.buttonCancel.Text = "Cancel";
			this.buttonCancel.UseVisualStyleBackColor = true;
			// 
			// buttonSave
			// 
			this.buttonSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.buttonSave.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.buttonSave.Location = new System.Drawing.Point(669, 350);
			this.buttonSave.Margin = new System.Windows.Forms.Padding(4);
			this.buttonSave.Name = "buttonSave";
			this.buttonSave.Size = new System.Drawing.Size(100, 28);
			this.buttonSave.TabIndex = 36;
			this.buttonSave.Text = "Save";
			this.buttonSave.UseVisualStyleBackColor = true;
			// 
			// buttonResetSampleRate
			// 
			this.buttonResetSampleRate.Location = new System.Drawing.Point(416, 38);
			this.buttonResetSampleRate.Name = "buttonResetSampleRate";
			this.buttonResetSampleRate.Size = new System.Drawing.Size(23, 23);
			this.buttonResetSampleRate.TabIndex = 52;
			this.buttonResetSampleRate.Text = "*";
			this.buttonResetSampleRate.UseVisualStyleBackColor = true;
			// 
			// checkBoxSearchGroups
			// 
			this.checkBoxSearchGroups.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.checkBoxSearchGroups.AutoSize = true;
			this.checkBoxSearchGroups.Checked = true;
			this.checkBoxSearchGroups.CheckState = System.Windows.Forms.CheckState.Checked;
			this.checkBoxSearchGroups.Location = new System.Drawing.Point(113, 88);
			this.checkBoxSearchGroups.Name = "checkBoxSearchGroups";
			this.checkBoxSearchGroups.Size = new System.Drawing.Size(116, 21);
			this.checkBoxSearchGroups.TabIndex = 53;
			this.checkBoxSearchGroups.Text = "Allow Clipping";
			this.checkBoxSearchGroups.UseVisualStyleBackColor = true;
			// 
			// button1
			// 
			this.button1.Location = new System.Drawing.Point(289, 143);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(23, 23);
			this.button1.TabIndex = 56;
			this.button1.Text = "*";
			this.button1.UseVisualStyleBackColor = true;
			// 
			// numericUpDown4
			// 
			this.numericUpDown4.Location = new System.Drawing.Point(215, 144);
			this.numericUpDown4.Name = "numericUpDown4";
			this.numericUpDown4.Size = new System.Drawing.Size(75, 22);
			this.numericUpDown4.TabIndex = 55;
			// 
			// label9
			// 
			this.label9.AutoSize = true;
			this.label9.Location = new System.Drawing.Point(212, 124);
			this.label9.Name = "label9";
			this.label9.Size = new System.Drawing.Size(97, 17);
			this.label9.TabIndex = 54;
			this.label9.Text = "Pitch Modifier:";
			// 
			// button2
			// 
			this.button2.Location = new System.Drawing.Point(392, 143);
			this.button2.Name = "button2";
			this.button2.Size = new System.Drawing.Size(23, 23);
			this.button2.TabIndex = 59;
			this.button2.Text = "*";
			this.button2.UseVisualStyleBackColor = true;
			// 
			// numericUpDown5
			// 
			this.numericUpDown5.Location = new System.Drawing.Point(318, 144);
			this.numericUpDown5.Name = "numericUpDown5";
			this.numericUpDown5.Size = new System.Drawing.Size(75, 22);
			this.numericUpDown5.TabIndex = 58;
			// 
			// label10
			// 
			this.label10.AutoSize = true;
			this.label10.Location = new System.Drawing.Point(315, 124);
			this.label10.Name = "label10";
			this.label10.Size = new System.Drawing.Size(97, 17);
			this.label10.TabIndex = 57;
			this.label10.Text = "Pitch Modifier:";
			// 
			// button3
			// 
			this.button3.Location = new System.Drawing.Point(187, 193);
			this.button3.Name = "button3";
			this.button3.Size = new System.Drawing.Size(23, 23);
			this.button3.TabIndex = 65;
			this.button3.Text = "*";
			this.button3.UseVisualStyleBackColor = true;
			// 
			// numericUpDown6
			// 
			this.numericUpDown6.Location = new System.Drawing.Point(113, 194);
			this.numericUpDown6.Name = "numericUpDown6";
			this.numericUpDown6.Size = new System.Drawing.Size(75, 22);
			this.numericUpDown6.TabIndex = 64;
			// 
			// label11
			// 
			this.label11.AutoSize = true;
			this.label11.Location = new System.Drawing.Point(110, 174);
			this.label11.Name = "label11";
			this.label11.Size = new System.Drawing.Size(94, 17);
			this.label11.TabIndex = 63;
			this.label11.Text = "Final Padding";
			// 
			// button4
			// 
			this.button4.Location = new System.Drawing.Point(84, 194);
			this.button4.Name = "button4";
			this.button4.Size = new System.Drawing.Size(23, 23);
			this.button4.TabIndex = 62;
			this.button4.Text = "*";
			this.button4.UseVisualStyleBackColor = true;
			// 
			// numericUpDown7
			// 
			this.numericUpDown7.Location = new System.Drawing.Point(10, 194);
			this.numericUpDown7.Name = "numericUpDown7";
			this.numericUpDown7.Size = new System.Drawing.Size(75, 22);
			this.numericUpDown7.TabIndex = 61;
			// 
			// label12
			// 
			this.label12.AutoSize = true;
			this.label12.Location = new System.Drawing.Point(6, 174);
			this.label12.Name = "label12";
			this.label12.Size = new System.Drawing.Size(100, 17);
			this.label12.TabIndex = 60;
			this.label12.Text = "Initial Padding:";
			// 
			// WAVPreprocessingForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(890, 483);
			this.Controls.Add(this.buttonCancel);
			this.Controls.Add(this.buttonSave);
			this.Controls.Add(this.groupBoxProcSettings);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.treeViewMapping);
			this.Controls.Add(this.audioPlaybackBRSARSound);
			this.Name = "WAVPreprocessingForm";
			this.Text = "WAVPreprocessingForm";
			this.groupBoxProcSettings.ResumeLayout(false);
			this.groupBoxProcSettings.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDown2)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDown3)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDown4)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDown5)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDown6)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDown7)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.TreeView treeViewMapping;
		private BrawlLib.Internal.Windows.Controls.AudioPlaybackPanel audioPlaybackBRSARSound;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private BrawlLib.Internal.Windows.Controls.AudioPlaybackPanel audioPlaybackPanelPreview;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.GroupBox groupBoxProcSettings;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.TextBox textBoxTargetSampleRate;
		private System.Windows.Forms.TextBox textBoxOrigSampleRate;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.NumericUpDown numericUpDown1;
		private System.Windows.Forms.Button buttonResetPitch;
		private System.Windows.Forms.NumericUpDown numericUpDown3;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.Button buttonResetTempo;
		private System.Windows.Forms.NumericUpDown numericUpDown2;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.Button buttonResetVolume;
		private System.Windows.Forms.Button buttonApply;
		private System.Windows.Forms.Button buttonReset;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.Button buttonCancel;
		private System.Windows.Forms.Button buttonSave;
		private System.Windows.Forms.Button buttonResetSampleRate;
		private System.Windows.Forms.CheckBox checkBoxSearchGroups;
		private System.Windows.Forms.Button button3;
		private System.Windows.Forms.NumericUpDown numericUpDown6;
		private System.Windows.Forms.Label label11;
		private System.Windows.Forms.Button button4;
		private System.Windows.Forms.NumericUpDown numericUpDown7;
		private System.Windows.Forms.Label label12;
		private System.Windows.Forms.Button button2;
		private System.Windows.Forms.NumericUpDown numericUpDown5;
		private System.Windows.Forms.Label label10;
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.NumericUpDown numericUpDown4;
		private System.Windows.Forms.Label label9;
	}
}