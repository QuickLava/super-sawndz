
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
			this.textBoxProcessedSize = new System.Windows.Forms.TextBox();
			this.label10 = new System.Windows.Forms.Label();
			this.buttonResetTrimFinal = new System.Windows.Forms.Button();
			this.numericUpDownTrimFinal = new System.Windows.Forms.NumericUpDown();
			this.label3 = new System.Windows.Forms.Label();
			this.buttonResetTrimInit = new System.Windows.Forms.Button();
			this.numericUpDownTrimInit = new System.Windows.Forms.NumericUpDown();
			this.label9 = new System.Windows.Forms.Label();
			this.audioPlaybackPanelProcessed = new BrawlLib.Internal.Windows.Controls.AudioPlaybackPanel();
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
			this.checkBoxNormalize = new System.Windows.Forms.CheckBox();
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
			this.audioPlaybackBRSARSound = new BrawlLib.Internal.Windows.Controls.AudioPlaybackPanel();
			this.groupBoxProcSettings.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDownTrimFinal)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDownTrimInit)).BeginInit();
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
			this.treeViewMapping.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.treeViewMapping.FullRowSelect = true;
			this.treeViewMapping.HideSelection = false;
			this.treeViewMapping.Location = new System.Drawing.Point(334, 36);
			this.treeViewMapping.Margin = new System.Windows.Forms.Padding(4);
			this.treeViewMapping.Name = "treeViewMapping";
			this.treeViewMapping.Size = new System.Drawing.Size(407, 302);
			this.treeViewMapping.TabIndex = 1;
			this.treeViewMapping.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeViewMapping_AfterSelect);
			// 
			// label1
			// 
			this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(331, 9);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(156, 17);
			this.label1.TabIndex = 4;
			this.label1.Text = "Existing Bank Contents:";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(13, 9);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(137, 17);
			this.label2.TabIndex = 3;
			this.label2.Text = "Processing Settings:";
			// 
			// groupBoxProcSettings
			// 
			this.groupBoxProcSettings.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.groupBoxProcSettings.Controls.Add(this.textBoxProcessedSize);
			this.groupBoxProcSettings.Controls.Add(this.label10);
			this.groupBoxProcSettings.Controls.Add(this.buttonResetTrimFinal);
			this.groupBoxProcSettings.Controls.Add(this.numericUpDownTrimFinal);
			this.groupBoxProcSettings.Controls.Add(this.label3);
			this.groupBoxProcSettings.Controls.Add(this.buttonResetTrimInit);
			this.groupBoxProcSettings.Controls.Add(this.numericUpDownTrimInit);
			this.groupBoxProcSettings.Controls.Add(this.label9);
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
			this.groupBoxProcSettings.Controls.Add(this.checkBoxNormalize);
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
			this.groupBoxProcSettings.Size = new System.Drawing.Size(304, 466);
			this.groupBoxProcSettings.TabIndex = 0;
			this.groupBoxProcSettings.TabStop = false;
			// 
			// textBoxProcessedSize
			// 
			this.textBoxProcessedSize.Enabled = false;
			this.textBoxProcessedSize.Location = new System.Drawing.Point(161, 260);
			this.textBoxProcessedSize.Name = "textBoxProcessedSize";
			this.textBoxProcessedSize.Size = new System.Drawing.Size(117, 22);
			this.textBoxProcessedSize.TabIndex = 0;
			this.textBoxProcessedSize.TabStop = false;
			// 
			// label10
			// 
			this.label10.AutoSize = true;
			this.label10.Location = new System.Drawing.Point(4, 263);
			this.label10.Name = "label10";
			this.label10.Size = new System.Drawing.Size(155, 17);
			this.label10.TabIndex = 1;
			this.label10.Text = "Processed Sound Size:";
			// 
			// buttonResetTrimFinal
			// 
			this.buttonResetTrimFinal.Location = new System.Drawing.Point(258, 179);
			this.buttonResetTrimFinal.Name = "buttonResetTrimFinal";
			this.buttonResetTrimFinal.Size = new System.Drawing.Size(23, 23);
			this.buttonResetTrimFinal.TabIndex = 14;
			this.buttonResetTrimFinal.Text = "*";
			this.buttonResetTrimFinal.UseVisualStyleBackColor = true;
			this.buttonResetTrimFinal.Click += new System.EventHandler(this.buttonResetTrimFinal_Click);
			// 
			// numericUpDownTrimFinal
			// 
			this.numericUpDownTrimFinal.Increment = new decimal(new int[] {
            25,
            0,
            0,
            0});
			this.numericUpDownTrimFinal.Location = new System.Drawing.Point(151, 180);
			this.numericUpDownTrimFinal.Maximum = new decimal(new int[] {
            5000,
            0,
            0,
            0});
			this.numericUpDownTrimFinal.Name = "numericUpDownTrimFinal";
			this.numericUpDownTrimFinal.Size = new System.Drawing.Size(108, 22);
			this.numericUpDownTrimFinal.TabIndex = 13;
			this.numericUpDownTrimFinal.KeyDown += new System.Windows.Forms.KeyEventHandler(this.numericUpDown_KeyDown);
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(148, 160);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(106, 17);
			this.label3.TabIndex = 4;
			this.label3.Text = "Final Trim (ms):";
			// 
			// buttonResetTrimInit
			// 
			this.buttonResetTrimInit.Location = new System.Drawing.Point(119, 179);
			this.buttonResetTrimInit.Name = "buttonResetTrimInit";
			this.buttonResetTrimInit.Size = new System.Drawing.Size(23, 23);
			this.buttonResetTrimInit.TabIndex = 12;
			this.buttonResetTrimInit.Text = "*";
			this.buttonResetTrimInit.UseVisualStyleBackColor = true;
			this.buttonResetTrimInit.Click += new System.EventHandler(this.buttonResetTrimInit_Click);
			// 
			// numericUpDownTrimInit
			// 
			this.numericUpDownTrimInit.Increment = new decimal(new int[] {
            25,
            0,
            0,
            0});
			this.numericUpDownTrimInit.Location = new System.Drawing.Point(10, 180);
			this.numericUpDownTrimInit.Maximum = new decimal(new int[] {
            5000,
            0,
            0,
            0});
			this.numericUpDownTrimInit.Name = "numericUpDownTrimInit";
			this.numericUpDownTrimInit.Size = new System.Drawing.Size(110, 22);
			this.numericUpDownTrimInit.TabIndex = 11;
			this.numericUpDownTrimInit.KeyDown += new System.Windows.Forms.KeyEventHandler(this.numericUpDown_KeyDown);
			// 
			// label9
			// 
			this.label9.AutoSize = true;
			this.label9.Location = new System.Drawing.Point(6, 160);
			this.label9.Name = "label9";
			this.label9.Size = new System.Drawing.Size(108, 17);
			this.label9.TabIndex = 7;
			this.label9.Text = "Initial Trim (ms):";
			// 
			// audioPlaybackPanelProcessed
			// 
			this.audioPlaybackPanelProcessed.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.audioPlaybackPanelProcessed.Location = new System.Drawing.Point(19, 351);
			this.audioPlaybackPanelProcessed.Margin = new System.Windows.Forms.Padding(4);
			this.audioPlaybackPanelProcessed.Name = "audioPlaybackPanelProcessed";
			this.audioPlaybackPanelProcessed.Size = new System.Drawing.Size(271, 100);
			this.audioPlaybackPanelProcessed.TabIndex = 21;
			this.audioPlaybackPanelProcessed.TargetStreams = null;
			// 
			// buttonResetSampleRate
			// 
			this.buttonResetSampleRate.Location = new System.Drawing.Point(117, 84);
			this.buttonResetSampleRate.Name = "buttonResetSampleRate";
			this.buttonResetSampleRate.Size = new System.Drawing.Size(23, 23);
			this.buttonResetSampleRate.TabIndex = 4;
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
            44100,
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
			this.numericUpDownSampleRate.TabIndex = 3;
			this.numericUpDownSampleRate.Value = new decimal(new int[] {
            2000,
            0,
            0,
            0});
			this.numericUpDownSampleRate.KeyDown += new System.Windows.Forms.KeyEventHandler(this.numericUpDown_KeyDown);
			// 
			// buttonResetChannelCount
			// 
			this.buttonResetChannelCount.Location = new System.Drawing.Point(256, 85);
			this.buttonResetChannelCount.Name = "buttonResetChannelCount";
			this.buttonResetChannelCount.Size = new System.Drawing.Size(23, 23);
			this.buttonResetChannelCount.TabIndex = 6;
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
			this.numericUpDownChannelCount.TabIndex = 5;
			this.numericUpDownChannelCount.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
			this.numericUpDownChannelCount.KeyDown += new System.Windows.Forms.KeyEventHandler(this.numericUpDown_KeyDown);
			// 
			// label13
			// 
			this.label13.AutoSize = true;
			this.label13.Location = new System.Drawing.Point(146, 65);
			this.label13.Name = "label13";
			this.label13.Size = new System.Drawing.Size(105, 17);
			this.label13.TabIndex = 13;
			this.label13.Text = "Channel Count:";
			// 
			// buttonResetPadFinal
			// 
			this.buttonResetPadFinal.Location = new System.Drawing.Point(258, 229);
			this.buttonResetPadFinal.Name = "buttonResetPadFinal";
			this.buttonResetPadFinal.Size = new System.Drawing.Size(23, 23);
			this.buttonResetPadFinal.TabIndex = 18;
			this.buttonResetPadFinal.Text = "*";
			this.buttonResetPadFinal.UseVisualStyleBackColor = true;
			this.buttonResetPadFinal.Click += new System.EventHandler(this.buttonResetPadFinal_Click);
			// 
			// numericUpDownPadFinal
			// 
			this.numericUpDownPadFinal.Increment = new decimal(new int[] {
            25,
            0,
            0,
            0});
			this.numericUpDownPadFinal.Location = new System.Drawing.Point(151, 230);
			this.numericUpDownPadFinal.Maximum = new decimal(new int[] {
            5000,
            0,
            0,
            0});
			this.numericUpDownPadFinal.Name = "numericUpDownPadFinal";
			this.numericUpDownPadFinal.Size = new System.Drawing.Size(108, 22);
			this.numericUpDownPadFinal.TabIndex = 17;
			this.numericUpDownPadFinal.KeyDown += new System.Windows.Forms.KeyEventHandler(this.numericUpDown_KeyDown);
			// 
			// label11
			// 
			this.label11.AutoSize = true;
			this.label11.Location = new System.Drawing.Point(148, 210);
			this.label11.Name = "label11";
			this.label11.Size = new System.Drawing.Size(130, 17);
			this.label11.TabIndex = 16;
			this.label11.Text = "Final Padding (ms):";
			// 
			// buttonResetPadInit
			// 
			this.buttonResetPadInit.Location = new System.Drawing.Point(119, 229);
			this.buttonResetPadInit.Name = "buttonResetPadInit";
			this.buttonResetPadInit.Size = new System.Drawing.Size(23, 23);
			this.buttonResetPadInit.TabIndex = 16;
			this.buttonResetPadInit.Text = "*";
			this.buttonResetPadInit.UseVisualStyleBackColor = true;
			this.buttonResetPadInit.Click += new System.EventHandler(this.buttonResetPadInit_Click);
			// 
			// numericUpDownPadInit
			// 
			this.numericUpDownPadInit.Increment = new decimal(new int[] {
            25,
            0,
            0,
            0});
			this.numericUpDownPadInit.Location = new System.Drawing.Point(10, 230);
			this.numericUpDownPadInit.Maximum = new decimal(new int[] {
            5000,
            0,
            0,
            0});
			this.numericUpDownPadInit.Name = "numericUpDownPadInit";
			this.numericUpDownPadInit.Size = new System.Drawing.Size(110, 22);
			this.numericUpDownPadInit.TabIndex = 15;
			this.numericUpDownPadInit.KeyDown += new System.Windows.Forms.KeyEventHandler(this.numericUpDown_KeyDown);
			// 
			// label12
			// 
			this.label12.AutoSize = true;
			this.label12.Location = new System.Drawing.Point(6, 210);
			this.label12.Name = "label12";
			this.label12.Size = new System.Drawing.Size(132, 17);
			this.label12.TabIndex = 19;
			this.label12.Text = "Initial Padding (ms):";
			// 
			// checkBoxNormalize
			// 
			this.checkBoxNormalize.AutoSize = true;
			this.checkBoxNormalize.Location = new System.Drawing.Point(151, 40);
			this.checkBoxNormalize.Name = "checkBoxNormalize";
			this.checkBoxNormalize.Size = new System.Drawing.Size(144, 21);
			this.checkBoxNormalize.TabIndex = 2;
			this.checkBoxNormalize.Text = "Normalize Volume";
			this.checkBoxNormalize.UseVisualStyleBackColor = true;
			this.checkBoxNormalize.CheckedChanged += new System.EventHandler(this.checkBoxNormalize_CheckedChanged);
			this.checkBoxNormalize.KeyDown += new System.Windows.Forms.KeyEventHandler(this.checkBoxNormalize_KeyDown);
			// 
			// label8
			// 
			this.label8.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
			this.label8.AutoSize = true;
			this.label8.Location = new System.Drawing.Point(7, 327);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(61, 17);
			this.label8.TabIndex = 21;
			this.label8.Text = "Preview:";
			// 
			// buttonReset
			// 
			this.buttonReset.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.buttonReset.Location = new System.Drawing.Point(73, 292);
			this.buttonReset.Margin = new System.Windows.Forms.Padding(4);
			this.buttonReset.Name = "buttonReset";
			this.buttonReset.Size = new System.Drawing.Size(100, 28);
			this.buttonReset.TabIndex = 19;
			this.buttonReset.Text = "Reset";
			this.buttonReset.UseVisualStyleBackColor = true;
			this.buttonReset.Click += new System.EventHandler(this.buttonReset_Click);
			// 
			// buttonApply
			// 
			this.buttonApply.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.buttonApply.Location = new System.Drawing.Point(181, 292);
			this.buttonApply.Margin = new System.Windows.Forms.Padding(4);
			this.buttonApply.Name = "buttonApply";
			this.buttonApply.Size = new System.Drawing.Size(100, 28);
			this.buttonApply.TabIndex = 20;
			this.buttonApply.Text = "Apply";
			this.buttonApply.UseVisualStyleBackColor = true;
			this.buttonApply.Click += new System.EventHandler(this.buttonApply_Click);
			// 
			// buttonResetPitch
			// 
			this.buttonResetPitch.Location = new System.Drawing.Point(258, 131);
			this.buttonResetPitch.Name = "buttonResetPitch";
			this.buttonResetPitch.Size = new System.Drawing.Size(23, 23);
			this.buttonResetPitch.TabIndex = 10;
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
			this.numericUpDownPitch.TabIndex = 9;
			this.numericUpDownPitch.KeyDown += new System.Windows.Forms.KeyEventHandler(this.numericUpDown_KeyDown);
			// 
			// label7
			// 
			this.label7.AutoSize = true;
			this.label7.Location = new System.Drawing.Point(148, 110);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(155, 17);
			this.label7.TabIndex = 26;
			this.label7.Text = "Pitch Shift (Semitones):";
			// 
			// buttonResetTempo
			// 
			this.buttonResetTempo.Location = new System.Drawing.Point(119, 131);
			this.buttonResetTempo.Name = "buttonResetTempo";
			this.buttonResetTempo.Size = new System.Drawing.Size(23, 23);
			this.buttonResetTempo.TabIndex = 8;
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
			this.numericUpDownTempo.TabIndex = 7;
			this.numericUpDownTempo.Value = new decimal(new int[] {
            100,
            0,
            0,
            131072});
			this.numericUpDownTempo.KeyDown += new System.Windows.Forms.KeyEventHandler(this.numericUpDown_KeyDown);
			// 
			// label6
			// 
			this.label6.AutoSize = true;
			this.label6.Location = new System.Drawing.Point(6, 110);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(116, 17);
			this.label6.TabIndex = 29;
			this.label6.Text = "Tempo Multiplier:";
			// 
			// buttonResetVolume
			// 
			this.buttonResetVolume.Location = new System.Drawing.Point(119, 39);
			this.buttonResetVolume.Name = "buttonResetVolume";
			this.buttonResetVolume.Size = new System.Drawing.Size(23, 23);
			this.buttonResetVolume.TabIndex = 1;
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
			this.numericUpDownVolume.TabIndex = 0;
			this.numericUpDownVolume.Value = new decimal(new int[] {
            100,
            0,
            0,
            131072});
			this.numericUpDownVolume.KeyDown += new System.Windows.Forms.KeyEventHandler(this.numericUpDown_KeyDown);
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Location = new System.Drawing.Point(7, 18);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(119, 17);
			this.label5.TabIndex = 32;
			this.label5.Text = "Volume Multiplier:";
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(4, 64);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(139, 17);
			this.label4.TabIndex = 33;
			this.label4.Text = "Target Sample Rate:";
			// 
			// buttonCancel
			// 
			this.buttonCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.buttonCancel.Location = new System.Drawing.Point(641, 468);
			this.buttonCancel.Margin = new System.Windows.Forms.Padding(4);
			this.buttonCancel.Name = "buttonCancel";
			this.buttonCancel.Size = new System.Drawing.Size(100, 28);
			this.buttonCancel.TabIndex = 4;
			this.buttonCancel.Text = "Cancel";
			this.buttonCancel.UseVisualStyleBackColor = true;
			this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
			// 
			// buttonSave
			// 
			this.buttonSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.buttonSave.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.buttonSave.Location = new System.Drawing.Point(534, 468);
			this.buttonSave.Margin = new System.Windows.Forms.Padding(4);
			this.buttonSave.Name = "buttonSave";
			this.buttonSave.Size = new System.Drawing.Size(100, 28);
			this.buttonSave.TabIndex = 3;
			this.buttonSave.Text = "Save";
			this.buttonSave.UseVisualStyleBackColor = true;
			this.buttonSave.Click += new System.EventHandler(this.buttonSave_Click);
			// 
			// audioPlaybackBRSARSound
			// 
			this.audioPlaybackBRSARSound.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.audioPlaybackBRSARSound.Location = new System.Drawing.Point(334, 353);
			this.audioPlaybackBRSARSound.Margin = new System.Windows.Forms.Padding(4);
			this.audioPlaybackBRSARSound.Name = "audioPlaybackBRSARSound";
			this.audioPlaybackBRSARSound.Size = new System.Drawing.Size(407, 100);
			this.audioPlaybackBRSARSound.TabIndex = 2;
			this.audioPlaybackBRSARSound.TargetStreams = null;
			// 
			// WAVPreprocessingForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(754, 508);
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
			this.Text = "Process Audio";
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.WAVPreprocessingForm_FormClosing);
			this.groupBoxProcSettings.ResumeLayout(false);
			this.groupBoxProcSettings.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDownTrimFinal)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDownTrimInit)).EndInit();
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
		private System.Windows.Forms.CheckBox checkBoxNormalize;
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
		private System.Windows.Forms.Button buttonResetTrimFinal;
		private System.Windows.Forms.NumericUpDown numericUpDownTrimFinal;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Button buttonResetTrimInit;
		private System.Windows.Forms.NumericUpDown numericUpDownTrimInit;
		private System.Windows.Forms.Label label9;
		private System.Windows.Forms.Label label10;
		private System.Windows.Forms.TextBox textBoxProcessedSize;
	}
}