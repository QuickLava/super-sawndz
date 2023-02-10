
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
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.groupBoxProcSettings = new System.Windows.Forms.GroupBox();
			this.buttonResetSampleRate = new System.Windows.Forms.Button();
			this.numericUpDownSampleRate = new System.Windows.Forms.NumericUpDown();
			this.buttonResetChannelCount = new System.Windows.Forms.Button();
			this.numericUpDownChannelCount = new System.Windows.Forms.NumericUpDown();
			this.label13 = new System.Windows.Forms.Label();
			this.buttonResetPadFinal = new System.Windows.Forms.Button();
			this.numericUpDownPadFinal = new System.Windows.Forms.NumericUpDown();
			this.label11 = new System.Windows.Forms.Label();
			this.buttonResetPadInit = new System.Windows.Forms.Button();
			this.numericUpDownPadInit = new System.Windows.Forms.NumericUpDown();
			this.label12 = new System.Windows.Forms.Label();
			this.checkBoxAllowClipping = new System.Windows.Forms.CheckBox();
			this.label8 = new System.Windows.Forms.Label();
			this.buttonReset = new System.Windows.Forms.Button();
			this.buttonApply = new System.Windows.Forms.Button();
			this.buttonResetPitch = new System.Windows.Forms.Button();
			this.numericUpDownPitch = new System.Windows.Forms.NumericUpDown();
			this.label7 = new System.Windows.Forms.Label();
			this.buttonResetTempo = new System.Windows.Forms.Button();
			this.numericUpDownTempo = new System.Windows.Forms.NumericUpDown();
			this.label6 = new System.Windows.Forms.Label();
			this.buttonResetVolume = new System.Windows.Forms.Button();
			this.numericUpDownVolume = new System.Windows.Forms.NumericUpDown();
			this.label5 = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.buttonCancel = new System.Windows.Forms.Button();
			this.buttonSave = new System.Windows.Forms.Button();
			this.audioPlaybackPanelProcessed = new BrawlLib.Internal.Windows.Controls.AudioPlaybackPanel();
			this.audioPlaybackBRSARSound = new BrawlLib.Internal.Windows.Controls.AudioPlaybackPanel();
			this.groupBoxProcSettings.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDownSampleRate)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDownChannelCount)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDownPadFinal)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDownPadInit)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDownPitch)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDownTempo)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDownVolume)).BeginInit();
			this.SuspendLayout();
			// 
			// treeViewMapping
			// 
			this.treeViewMapping.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.treeViewMapping.FullRowSelect = true;
			this.treeViewMapping.HideSelection = false;
			this.treeViewMapping.Location = new System.Drawing.Point(334, 36);
			this.treeViewMapping.Margin = new System.Windows.Forms.Padding(4);
			this.treeViewMapping.Name = "treeViewMapping";
			this.treeViewMapping.Size = new System.Drawing.Size(407, 229);
			this.treeViewMapping.TabIndex = 29;
			this.treeViewMapping.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeViewMapping_AfterSelect);
			// 
			// label1
			// 
			this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(331, 9);
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
			// groupBoxProcSettings
			// 
			this.groupBoxProcSettings.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.groupBoxProcSettings.Controls.Add(this.audioPlaybackPanelProcessed);
			this.groupBoxProcSettings.Controls.Add(this.buttonResetSampleRate);
			this.groupBoxProcSettings.Controls.Add(this.numericUpDownSampleRate);
			this.groupBoxProcSettings.Controls.Add(this.buttonResetChannelCount);
			this.groupBoxProcSettings.Controls.Add(this.numericUpDownChannelCount);
			this.groupBoxProcSettings.Controls.Add(this.label13);
			this.groupBoxProcSettings.Controls.Add(this.buttonResetPadFinal);
			this.groupBoxProcSettings.Controls.Add(this.numericUpDownPadFinal);
			this.groupBoxProcSettings.Controls.Add(this.label11);
			this.groupBoxProcSettings.Controls.Add(this.buttonResetPadInit);
			this.groupBoxProcSettings.Controls.Add(this.numericUpDownPadInit);
			this.groupBoxProcSettings.Controls.Add(this.label12);
			this.groupBoxProcSettings.Controls.Add(this.checkBoxAllowClipping);
			this.groupBoxProcSettings.Controls.Add(this.label8);
			this.groupBoxProcSettings.Controls.Add(this.buttonReset);
			this.groupBoxProcSettings.Controls.Add(this.buttonApply);
			this.groupBoxProcSettings.Controls.Add(this.buttonResetPitch);
			this.groupBoxProcSettings.Controls.Add(this.numericUpDownPitch);
			this.groupBoxProcSettings.Controls.Add(this.label7);
			this.groupBoxProcSettings.Controls.Add(this.buttonResetTempo);
			this.groupBoxProcSettings.Controls.Add(this.numericUpDownTempo);
			this.groupBoxProcSettings.Controls.Add(this.label6);
			this.groupBoxProcSettings.Controls.Add(this.buttonResetVolume);
			this.groupBoxProcSettings.Controls.Add(this.numericUpDownVolume);
			this.groupBoxProcSettings.Controls.Add(this.label5);
			this.groupBoxProcSettings.Controls.Add(this.label4);
			this.groupBoxProcSettings.Location = new System.Drawing.Point(16, 30);
			this.groupBoxProcSettings.Name = "groupBoxProcSettings";
			this.groupBoxProcSettings.Size = new System.Drawing.Size(304, 393);
			this.groupBoxProcSettings.TabIndex = 35;
			this.groupBoxProcSettings.TabStop = false;
			// 
			// buttonResetSampleRate
			// 
			this.buttonResetSampleRate.Location = new System.Drawing.Point(117, 84);
			this.buttonResetSampleRate.Name = "buttonResetSampleRate";
			this.buttonResetSampleRate.Size = new System.Drawing.Size(23, 23);
			this.buttonResetSampleRate.TabIndex = 70;
			this.buttonResetSampleRate.Text = "*";
			this.buttonResetSampleRate.UseVisualStyleBackColor = true;
			this.buttonResetSampleRate.Click += new System.EventHandler(this.buttonResetSampleRate_Click);
			// 
			// numericUpDownSampleRate
			// 
			this.numericUpDownSampleRate.Increment = new decimal(new int[] {
            100,
            0,
            0,
            0});
			this.numericUpDownSampleRate.Location = new System.Drawing.Point(10, 85);
			this.numericUpDownSampleRate.Maximum = new decimal(new int[] {
            44101,
            0,
            0,
            0});
			this.numericUpDownSampleRate.Minimum = new decimal(new int[] {
            100,
            0,
            0,
            0});
			this.numericUpDownSampleRate.Name = "numericUpDownSampleRate";
			this.numericUpDownSampleRate.Size = new System.Drawing.Size(108, 22);
			this.numericUpDownSampleRate.TabIndex = 69;
			this.numericUpDownSampleRate.Value = new decimal(new int[] {
            2000,
            0,
            0,
            0});
			// 
			// buttonResetChannelCount
			// 
			this.buttonResetChannelCount.Location = new System.Drawing.Point(256, 85);
			this.buttonResetChannelCount.Name = "buttonResetChannelCount";
			this.buttonResetChannelCount.Size = new System.Drawing.Size(23, 23);
			this.buttonResetChannelCount.TabIndex = 68;
			this.buttonResetChannelCount.Text = "*";
			this.buttonResetChannelCount.UseVisualStyleBackColor = true;
			this.buttonResetChannelCount.Click += new System.EventHandler(this.buttonResetChannelCount_Click);
			// 
			// numericUpDownChannelCount
			// 
			this.numericUpDownChannelCount.Location = new System.Drawing.Point(149, 85);
			this.numericUpDownChannelCount.Maximum = new decimal(new int[] {
            2,
            0,
            0,
            0});
			this.numericUpDownChannelCount.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
			this.numericUpDownChannelCount.Name = "numericUpDownChannelCount";
			this.numericUpDownChannelCount.Size = new System.Drawing.Size(108, 22);
			this.numericUpDownChannelCount.TabIndex = 67;
			this.numericUpDownChannelCount.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
			// 
			// label13
			// 
			this.label13.AutoSize = true;
			this.label13.Location = new System.Drawing.Point(146, 65);
			this.label13.Name = "label13";
			this.label13.Size = new System.Drawing.Size(105, 17);
			this.label13.TabIndex = 66;
			this.label13.Text = "Channel Count:";
			// 
			// buttonResetPadFinal
			// 
			this.buttonResetPadFinal.Location = new System.Drawing.Point(258, 179);
			this.buttonResetPadFinal.Name = "buttonResetPadFinal";
			this.buttonResetPadFinal.Size = new System.Drawing.Size(23, 23);
			this.buttonResetPadFinal.TabIndex = 65;
			this.buttonResetPadFinal.Text = "*";
			this.buttonResetPadFinal.UseVisualStyleBackColor = true;
			this.buttonResetPadFinal.Click += new System.EventHandler(this.buttonResetPadFinal_Click);
			// 
			// numericUpDownPadFinal
			// 
			this.numericUpDownPadFinal.Increment = new decimal(new int[] {
            50,
            0,
            0,
            0});
			this.numericUpDownPadFinal.Location = new System.Drawing.Point(151, 180);
			this.numericUpDownPadFinal.Maximum = new decimal(new int[] {
            5000,
            0,
            0,
            0});
			this.numericUpDownPadFinal.Minimum = new decimal(new int[] {
            5000,
            0,
            0,
            -2147483648});
			this.numericUpDownPadFinal.Name = "numericUpDownPadFinal";
			this.numericUpDownPadFinal.Size = new System.Drawing.Size(108, 22);
			this.numericUpDownPadFinal.TabIndex = 64;
			// 
			// label11
			// 
			this.label11.AutoSize = true;
			this.label11.Location = new System.Drawing.Point(148, 160);
			this.label11.Name = "label11";
			this.label11.Size = new System.Drawing.Size(130, 17);
			this.label11.TabIndex = 63;
			this.label11.Text = "Final Padding (ms):";
			// 
			// buttonResetPadInit
			// 
			this.buttonResetPadInit.Location = new System.Drawing.Point(119, 179);
			this.buttonResetPadInit.Name = "buttonResetPadInit";
			this.buttonResetPadInit.Size = new System.Drawing.Size(23, 23);
			this.buttonResetPadInit.TabIndex = 62;
			this.buttonResetPadInit.Text = "*";
			this.buttonResetPadInit.UseVisualStyleBackColor = true;
			this.buttonResetPadInit.Click += new System.EventHandler(this.buttonResetPadInit_Click);
			// 
			// numericUpDownPadInit
			// 
			this.numericUpDownPadInit.Increment = new decimal(new int[] {
            50,
            0,
            0,
            0});
			this.numericUpDownPadInit.Location = new System.Drawing.Point(10, 180);
			this.numericUpDownPadInit.Maximum = new decimal(new int[] {
            5000,
            0,
            0,
            0});
			this.numericUpDownPadInit.Minimum = new decimal(new int[] {
            5000,
            0,
            0,
            -2147483648});
			this.numericUpDownPadInit.Name = "numericUpDownPadInit";
			this.numericUpDownPadInit.Size = new System.Drawing.Size(110, 22);
			this.numericUpDownPadInit.TabIndex = 61;
			// 
			// label12
			// 
			this.label12.AutoSize = true;
			this.label12.Location = new System.Drawing.Point(6, 160);
			this.label12.Name = "label12";
			this.label12.Size = new System.Drawing.Size(132, 17);
			this.label12.TabIndex = 60;
			this.label12.Text = "Initial Padding (ms):";
			// 
			// checkBoxAllowClipping
			// 
			this.checkBoxAllowClipping.AutoSize = true;
			this.checkBoxAllowClipping.Checked = true;
			this.checkBoxAllowClipping.CheckState = System.Windows.Forms.CheckState.Checked;
			this.checkBoxAllowClipping.Location = new System.Drawing.Point(151, 40);
			this.checkBoxAllowClipping.Name = "checkBoxAllowClipping";
			this.checkBoxAllowClipping.Size = new System.Drawing.Size(116, 21);
			this.checkBoxAllowClipping.TabIndex = 53;
			this.checkBoxAllowClipping.Text = "Allow Clipping";
			this.checkBoxAllowClipping.UseVisualStyleBackColor = true;
			// 
			// label8
			// 
			this.label8.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.label8.AutoSize = true;
			this.label8.Location = new System.Drawing.Point(7, 254);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(61, 17);
			this.label8.TabIndex = 51;
			this.label8.Text = "Preview:";
			// 
			// buttonReset
			// 
			this.buttonReset.Location = new System.Drawing.Point(73, 219);
			this.buttonReset.Margin = new System.Windows.Forms.Padding(4);
			this.buttonReset.Name = "buttonReset";
			this.buttonReset.Size = new System.Drawing.Size(100, 28);
			this.buttonReset.TabIndex = 50;
			this.buttonReset.Text = "Reset";
			this.buttonReset.UseVisualStyleBackColor = true;
			this.buttonReset.Click += new System.EventHandler(this.buttonReset_Click);
			// 
			// buttonApply
			// 
			this.buttonApply.Location = new System.Drawing.Point(181, 219);
			this.buttonApply.Margin = new System.Windows.Forms.Padding(4);
			this.buttonApply.Name = "buttonApply";
			this.buttonApply.Size = new System.Drawing.Size(100, 28);
			this.buttonApply.TabIndex = 49;
			this.buttonApply.Text = "Apply";
			this.buttonApply.UseVisualStyleBackColor = true;
			this.buttonApply.Click += new System.EventHandler(this.buttonApply_Click);
			// 
			// buttonResetPitch
			// 
			this.buttonResetPitch.Location = new System.Drawing.Point(258, 131);
			this.buttonResetPitch.Name = "buttonResetPitch";
			this.buttonResetPitch.Size = new System.Drawing.Size(23, 23);
			this.buttonResetPitch.TabIndex = 48;
			this.buttonResetPitch.Text = "*";
			this.buttonResetPitch.UseVisualStyleBackColor = true;
			this.buttonResetPitch.Click += new System.EventHandler(this.buttonResetPitch_Click);
			// 
			// numericUpDownPitch
			// 
			this.numericUpDownPitch.DecimalPlaces = 2;
			this.numericUpDownPitch.Increment = new decimal(new int[] {
            25,
            0,
            0,
            131072});
			this.numericUpDownPitch.Location = new System.Drawing.Point(151, 131);
			this.numericUpDownPitch.Minimum = new decimal(new int[] {
            10000,
            0,
            0,
            -2147352576});
			this.numericUpDownPitch.Name = "numericUpDownPitch";
			this.numericUpDownPitch.Size = new System.Drawing.Size(108, 22);
			this.numericUpDownPitch.TabIndex = 47;
			// 
			// label7
			// 
			this.label7.AutoSize = true;
			this.label7.Location = new System.Drawing.Point(148, 110);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(155, 17);
			this.label7.TabIndex = 46;
			this.label7.Text = "Pitch Shift (Semitones):";
			// 
			// buttonResetTempo
			// 
			this.buttonResetTempo.Location = new System.Drawing.Point(119, 131);
			this.buttonResetTempo.Name = "buttonResetTempo";
			this.buttonResetTempo.Size = new System.Drawing.Size(23, 23);
			this.buttonResetTempo.TabIndex = 45;
			this.buttonResetTempo.Text = "*";
			this.buttonResetTempo.UseVisualStyleBackColor = true;
			this.buttonResetTempo.Click += new System.EventHandler(this.buttonResetTempo_Click);
			// 
			// numericUpDownTempo
			// 
			this.numericUpDownTempo.DecimalPlaces = 2;
			this.numericUpDownTempo.Increment = new decimal(new int[] {
            10,
            0,
            0,
            131072});
			this.numericUpDownTempo.Location = new System.Drawing.Point(10, 131);
			this.numericUpDownTempo.Minimum = new decimal(new int[] {
            10,
            0,
            0,
            131072});
			this.numericUpDownTempo.Name = "numericUpDownTempo";
			this.numericUpDownTempo.Size = new System.Drawing.Size(110, 22);
			this.numericUpDownTempo.TabIndex = 44;
			this.numericUpDownTempo.Value = new decimal(new int[] {
            100,
            0,
            0,
            131072});
			// 
			// label6
			// 
			this.label6.AutoSize = true;
			this.label6.Location = new System.Drawing.Point(6, 110);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(116, 17);
			this.label6.TabIndex = 43;
			this.label6.Text = "Tempo Multiplier:";
			// 
			// buttonResetVolume
			// 
			this.buttonResetVolume.Location = new System.Drawing.Point(119, 39);
			this.buttonResetVolume.Name = "buttonResetVolume";
			this.buttonResetVolume.Size = new System.Drawing.Size(23, 23);
			this.buttonResetVolume.TabIndex = 42;
			this.buttonResetVolume.Text = "*";
			this.buttonResetVolume.UseVisualStyleBackColor = true;
			this.buttonResetVolume.Click += new System.EventHandler(this.buttonResetVolume_Click);
			// 
			// numericUpDownVolume
			// 
			this.numericUpDownVolume.DecimalPlaces = 2;
			this.numericUpDownVolume.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
			this.numericUpDownVolume.Location = new System.Drawing.Point(10, 39);
			this.numericUpDownVolume.Name = "numericUpDownVolume";
			this.numericUpDownVolume.Size = new System.Drawing.Size(110, 22);
			this.numericUpDownVolume.TabIndex = 39;
			this.numericUpDownVolume.Value = new decimal(new int[] {
            100,
            0,
            0,
            131072});
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Location = new System.Drawing.Point(7, 18);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(119, 17);
			this.label5.TabIndex = 38;
			this.label5.Text = "Volume Multiplier:";
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(4, 64);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(139, 17);
			this.label4.TabIndex = 37;
			this.label4.Text = "Target Sample Rate:";
			// 
			// buttonCancel
			// 
			this.buttonCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.buttonCancel.Location = new System.Drawing.Point(641, 395);
			this.buttonCancel.Margin = new System.Windows.Forms.Padding(4);
			this.buttonCancel.Name = "buttonCancel";
			this.buttonCancel.Size = new System.Drawing.Size(100, 28);
			this.buttonCancel.TabIndex = 37;
			this.buttonCancel.Text = "Cancel";
			this.buttonCancel.UseVisualStyleBackColor = true;
			this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
			// 
			// buttonSave
			// 
			this.buttonSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.buttonSave.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.buttonSave.Location = new System.Drawing.Point(534, 395);
			this.buttonSave.Margin = new System.Windows.Forms.Padding(4);
			this.buttonSave.Name = "buttonSave";
			this.buttonSave.Size = new System.Drawing.Size(100, 28);
			this.buttonSave.TabIndex = 36;
			this.buttonSave.Text = "Save";
			this.buttonSave.UseVisualStyleBackColor = true;
			this.buttonSave.Click += new System.EventHandler(this.buttonSave_Click);
			// 
			// audioPlaybackPanelProcessed
			// 
			this.audioPlaybackPanelProcessed.Location = new System.Drawing.Point(19, 278);
			this.audioPlaybackPanelProcessed.Margin = new System.Windows.Forms.Padding(4);
			this.audioPlaybackPanelProcessed.Name = "audioPlaybackPanelProcessed";
			this.audioPlaybackPanelProcessed.Size = new System.Drawing.Size(271, 100);
			this.audioPlaybackPanelProcessed.TabIndex = 38;
			this.audioPlaybackPanelProcessed.TabStop = false;
			this.audioPlaybackPanelProcessed.TargetStreams = null;
			// 
			// audioPlaybackBRSARSound
			// 
			this.audioPlaybackBRSARSound.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.audioPlaybackBRSARSound.Location = new System.Drawing.Point(334, 280);
			this.audioPlaybackBRSARSound.Margin = new System.Windows.Forms.Padding(4);
			this.audioPlaybackBRSARSound.Name = "audioPlaybackBRSARSound";
			this.audioPlaybackBRSARSound.Size = new System.Drawing.Size(407, 100);
			this.audioPlaybackBRSARSound.TabIndex = 30;
			this.audioPlaybackBRSARSound.TabStop = false;
			this.audioPlaybackBRSARSound.TargetStreams = null;
			// 
			// WAVPreprocessingForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(754, 435);
			this.Controls.Add(this.buttonCancel);
			this.Controls.Add(this.buttonSave);
			this.Controls.Add(this.groupBoxProcSettings);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.treeViewMapping);
			this.Controls.Add(this.audioPlaybackBRSARSound);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "WAVPreprocessingForm";
			this.Text = "WAVPreprocessingForm";
			this.groupBoxProcSettings.ResumeLayout(false);
			this.groupBoxProcSettings.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDownSampleRate)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDownChannelCount)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDownPadFinal)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDownPadInit)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDownPitch)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDownTempo)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDownVolume)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.TreeView treeViewMapping;
		private BrawlLib.Internal.Windows.Controls.AudioPlaybackPanel audioPlaybackBRSARSound;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.GroupBox groupBoxProcSettings;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.NumericUpDown numericUpDownVolume;
		private System.Windows.Forms.Button buttonResetPitch;
		private System.Windows.Forms.NumericUpDown numericUpDownPitch;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.Button buttonResetTempo;
		private System.Windows.Forms.NumericUpDown numericUpDownTempo;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.Button buttonResetVolume;
		private System.Windows.Forms.Button buttonApply;
		private System.Windows.Forms.Button buttonReset;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.Button buttonCancel;
		private System.Windows.Forms.Button buttonSave;
		private System.Windows.Forms.CheckBox checkBoxAllowClipping;
		private System.Windows.Forms.Button buttonResetPadFinal;
		private System.Windows.Forms.NumericUpDown numericUpDownPadFinal;
		private System.Windows.Forms.Label label11;
		private System.Windows.Forms.Button buttonResetPadInit;
		private System.Windows.Forms.NumericUpDown numericUpDownPadInit;
		private System.Windows.Forms.Label label12;
		private System.Windows.Forms.Button buttonResetChannelCount;
		private System.Windows.Forms.NumericUpDown numericUpDownChannelCount;
		private System.Windows.Forms.Label label13;
		private System.Windows.Forms.Button buttonResetSampleRate;
		private System.Windows.Forms.NumericUpDown numericUpDownSampleRate;
		private BrawlLib.Internal.Windows.Controls.AudioPlaybackPanel audioPlaybackPanelProcessed;
	}
}