
namespace BrawlSoundConverter
{
	partial class SettingsForm
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
			this.groupBoxNamingScheme = new System.Windows.Forms.GroupBox();
			this.radioButtonNameManual = new System.Windows.Forms.RadioButton();
			this.radioButtonNameDefault = new System.Windows.Forms.RadioButton();
			this.radioButtonNamePP = new System.Windows.Forms.RadioButton();
			this.radioButtonNamePM = new System.Windows.Forms.RadioButton();
			this.buttonBrowse = new System.Windows.Forms.Button();
			this.textBoxDefaultBrsar = new System.Windows.Forms.TextBox();
			this.labelDefaultBrsar = new System.Windows.Forms.Label();
			this.buttonCancel = new System.Windows.Forms.Button();
			this.buttonSave = new System.Windows.Forms.Button();
			this.labelDefaultNameScheme = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.radioButtonGroupDirEnable = new System.Windows.Forms.RadioButton();
			this.radioButtonGroupDirDisable = new System.Windows.Forms.RadioButton();
			this.label2 = new System.Windows.Forms.Label();
			this.buttonBRSARPathUseCurrent = new System.Windows.Forms.Button();
			this.label3 = new System.Windows.Forms.Label();
			this.groupBox2 = new System.Windows.Forms.GroupBox();
			this.radioButtonFullNameEnable = new System.Windows.Forms.RadioButton();
			this.radioButtonFullNameDisable = new System.Windows.Forms.RadioButton();
			this.label4 = new System.Windows.Forms.Label();
			this.groupBox3 = new System.Windows.Forms.GroupBox();
			this.buttonResetMaxSampRate = new System.Windows.Forms.Button();
			this.label6 = new System.Windows.Forms.Label();
			this.label8 = new System.Windows.Forms.Label();
			this.numericUpDownMaxSampRate = new System.Windows.Forms.NumericUpDown();
			this.groupBox6 = new System.Windows.Forms.GroupBox();
			this.radioButtonMatchSRAlways = new System.Windows.Forms.RadioButton();
			this.radioButtonMatchSRSometimes = new System.Windows.Forms.RadioButton();
			this.radioButtonMatchSRNever = new System.Windows.Forms.RadioButton();
			this.groupBoxStereoConv = new System.Windows.Forms.GroupBox();
			this.radioButtonStereoConvAlways = new System.Windows.Forms.RadioButton();
			this.radioButtonStereoConvSometimes = new System.Windows.Forms.RadioButton();
			this.radioButtonStereoConvNever = new System.Windows.Forms.RadioButton();
			this.label9 = new System.Windows.Forms.Label();
			this.label5 = new System.Windows.Forms.Label();
			this.groupBox4 = new System.Windows.Forms.GroupBox();
			this.checkBoxSaveAsDefault = new System.Windows.Forms.CheckBox();
			this.buttonConfigLoad = new System.Windows.Forms.Button();
			this.treeView2 = new System.Windows.Forms.TreeView();
			this.label7 = new System.Windows.Forms.Label();
			this.buttonConfigSave = new System.Windows.Forms.Button();
			this.label10 = new System.Windows.Forms.Label();
			this.label11 = new System.Windows.Forms.Label();
			this.groupBox5 = new System.Windows.Forms.GroupBox();
			this.buttonResetGroupThresh = new System.Windows.Forms.Button();
			this.label12 = new System.Windows.Forms.Label();
			this.numericUpDownGroupSizeThresh = new System.Windows.Forms.NumericUpDown();
			this.label13 = new System.Windows.Forms.Label();
			this.groupBox7 = new System.Windows.Forms.GroupBox();
			this.radioButtonCollNameCustom = new System.Windows.Forms.RadioButton();
			this.radioButtonCollNameDefault = new System.Windows.Forms.RadioButton();
			this.radioButtonCollNameIDHex = new System.Windows.Forms.RadioButton();
			this.radioButtonCollNameID = new System.Windows.Forms.RadioButton();
			this.groupBoxNamingScheme.SuspendLayout();
			this.groupBox1.SuspendLayout();
			this.groupBox2.SuspendLayout();
			this.groupBox3.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDownMaxSampRate)).BeginInit();
			this.groupBox6.SuspendLayout();
			this.groupBoxStereoConv.SuspendLayout();
			this.groupBox4.SuspendLayout();
			this.groupBox5.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDownGroupSizeThresh)).BeginInit();
			this.groupBox7.SuspendLayout();
			this.SuspendLayout();
			// 
			// groupBoxNamingScheme
			// 
			this.groupBoxNamingScheme.Controls.Add(this.radioButtonNameManual);
			this.groupBoxNamingScheme.Controls.Add(this.radioButtonNameDefault);
			this.groupBoxNamingScheme.Controls.Add(this.radioButtonNamePP);
			this.groupBoxNamingScheme.Controls.Add(this.radioButtonNamePM);
			this.groupBoxNamingScheme.Location = new System.Drawing.Point(10, 161);
			this.groupBoxNamingScheme.Name = "groupBoxNamingScheme";
			this.groupBoxNamingScheme.Size = new System.Drawing.Size(445, 51);
			this.groupBoxNamingScheme.TabIndex = 4;
			this.groupBoxNamingScheme.TabStop = false;
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
			// buttonBrowse
			// 
			this.buttonBrowse.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.buttonBrowse.Location = new System.Drawing.Point(423, 29);
			this.buttonBrowse.Margin = new System.Windows.Forms.Padding(4);
			this.buttonBrowse.Name = "buttonBrowse";
			this.buttonBrowse.Size = new System.Drawing.Size(33, 24);
			this.buttonBrowse.TabIndex = 1;
			this.buttonBrowse.Text = "...";
			this.buttonBrowse.UseVisualStyleBackColor = true;
			this.buttonBrowse.Click += new System.EventHandler(this.buttonBrowse_Click);
			// 
			// textBoxDefaultBrsar
			// 
			this.textBoxDefaultBrsar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.textBoxDefaultBrsar.Location = new System.Drawing.Point(10, 30);
			this.textBoxDefaultBrsar.Margin = new System.Windows.Forms.Padding(4);
			this.textBoxDefaultBrsar.Name = "textBoxDefaultBrsar";
			this.textBoxDefaultBrsar.Size = new System.Drawing.Size(408, 22);
			this.textBoxDefaultBrsar.TabIndex = 0;
			this.textBoxDefaultBrsar.TextChanged += new System.EventHandler(this.textBoxDefaultBrsar_TextChanged);
			// 
			// labelDefaultBrsar
			// 
			this.labelDefaultBrsar.AutoSize = true;
			this.labelDefaultBrsar.Location = new System.Drawing.Point(10, 9);
			this.labelDefaultBrsar.Name = "labelDefaultBrsar";
			this.labelDefaultBrsar.Size = new System.Drawing.Size(130, 17);
			this.labelDefaultBrsar.TabIndex = 17;
			this.labelDefaultBrsar.Text = "Default BRSAR File";
			// 
			// buttonCancel
			// 
			this.buttonCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.buttonCancel.Location = new System.Drawing.Point(356, 870);
			this.buttonCancel.Margin = new System.Windows.Forms.Padding(4);
			this.buttonCancel.Name = "buttonCancel";
			this.buttonCancel.Size = new System.Drawing.Size(100, 28);
			this.buttonCancel.TabIndex = 11;
			this.buttonCancel.Text = "Cancel";
			this.buttonCancel.UseVisualStyleBackColor = true;
			// 
			// buttonSave
			// 
			this.buttonSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.buttonSave.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.buttonSave.Location = new System.Drawing.Point(248, 870);
			this.buttonSave.Margin = new System.Windows.Forms.Padding(4);
			this.buttonSave.Name = "buttonSave";
			this.buttonSave.Size = new System.Drawing.Size(100, 28);
			this.buttonSave.TabIndex = 10;
			this.buttonSave.Text = "Save";
			this.buttonSave.UseVisualStyleBackColor = true;
			this.buttonSave.Click += new System.EventHandler(this.buttonSave_Click);
			// 
			// labelDefaultNameScheme
			// 
			this.labelDefaultNameScheme.AutoSize = true;
			this.labelDefaultNameScheme.Location = new System.Drawing.Point(10, 151);
			this.labelDefaultNameScheme.Name = "labelDefaultNameScheme";
			this.labelDefaultNameScheme.Size = new System.Drawing.Size(206, 17);
			this.labelDefaultNameScheme.TabIndex = 14;
			this.labelDefaultNameScheme.Text = "Default Sawnd Naming Scheme";
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label1.ForeColor = System.Drawing.SystemColors.GrayText;
			this.label1.Location = new System.Drawing.Point(12, 56);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(241, 17);
			this.label1.TabIndex = 13;
			this.label1.Text = "Warning: Specified File Doesn\'t Exist!";
			this.label1.Visible = false;
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.radioButtonGroupDirEnable);
			this.groupBox1.Controls.Add(this.radioButtonGroupDirDisable);
			this.groupBox1.Location = new System.Drawing.Point(10, 293);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(445, 51);
			this.groupBox1.TabIndex = 6;
			// 
			// radioButtonGroupDirEnable
			// 
			this.radioButtonGroupDirEnable.AutoSize = true;
			this.radioButtonGroupDirEnable.Location = new System.Drawing.Point(6, 21);
			this.radioButtonGroupDirEnable.Name = "radioButtonGroupDirEnable";
			this.radioButtonGroupDirEnable.Size = new System.Drawing.Size(73, 21);
			this.radioButtonGroupDirEnable.TabIndex = 0;
			this.radioButtonGroupDirEnable.TabStop = true;
			this.radioButtonGroupDirEnable.Text = "Enable";
			this.radioButtonGroupDirEnable.UseVisualStyleBackColor = true;
			// 
			// radioButtonGroupDirDisable
			// 
			this.radioButtonGroupDirDisable.AutoSize = true;
			this.radioButtonGroupDirDisable.Location = new System.Drawing.Point(86, 21);
			this.radioButtonGroupDirDisable.Name = "radioButtonGroupDirDisable";
			this.radioButtonGroupDirDisable.Size = new System.Drawing.Size(76, 21);
			this.radioButtonGroupDirDisable.TabIndex = 1;
			this.radioButtonGroupDirDisable.TabStop = true;
			this.radioButtonGroupDirDisable.Text = "Disable";
			this.radioButtonGroupDirDisable.UseVisualStyleBackColor = true;
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(10, 283);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(352, 17);
			this.label2.TabIndex = 11;
			this.label2.Text = "Create Group Directory by Default in Multi Create WAV";
			// 
			// buttonBRSARPathUseCurrent
			// 
			this.buttonBRSARPathUseCurrent.Enabled = false;
			this.buttonBRSARPathUseCurrent.Location = new System.Drawing.Point(364, 56);
			this.buttonBRSARPathUseCurrent.Name = "buttonBRSARPathUseCurrent";
			this.buttonBRSARPathUseCurrent.Size = new System.Drawing.Size(92, 24);
			this.buttonBRSARPathUseCurrent.TabIndex = 2;
			this.buttonBRSARPathUseCurrent.Text = "Use Current";
			this.buttonBRSARPathUseCurrent.UseVisualStyleBackColor = true;
			this.buttonBRSARPathUseCurrent.Click += new System.EventHandler(this.buttonBRSARPathUseCurrent_Click);
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(10, 85);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(262, 17);
			this.label3.TabIndex = 8;
			this.label3.Text = "Enable Full-Length Group Name Display";
			// 
			// groupBox2
			// 
			this.groupBox2.Controls.Add(this.radioButtonFullNameEnable);
			this.groupBox2.Controls.Add(this.radioButtonFullNameDisable);
			this.groupBox2.Location = new System.Drawing.Point(10, 95);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new System.Drawing.Size(445, 51);
			this.groupBox2.TabIndex = 3;
			// 
			// radioButtonFullNameEnable
			// 
			this.radioButtonFullNameEnable.AutoSize = true;
			this.radioButtonFullNameEnable.Location = new System.Drawing.Point(6, 21);
			this.radioButtonFullNameEnable.Name = "radioButtonFullNameEnable";
			this.radioButtonFullNameEnable.Size = new System.Drawing.Size(73, 21);
			this.radioButtonFullNameEnable.TabIndex = 0;
			this.radioButtonFullNameEnable.TabStop = true;
			this.radioButtonFullNameEnable.Text = "Enable";
			this.radioButtonFullNameEnable.UseVisualStyleBackColor = true;
			// 
			// radioButtonFullNameDisable
			// 
			this.radioButtonFullNameDisable.AutoSize = true;
			this.radioButtonFullNameDisable.Location = new System.Drawing.Point(86, 21);
			this.radioButtonFullNameDisable.Name = "radioButtonFullNameDisable";
			this.radioButtonFullNameDisable.Size = new System.Drawing.Size(76, 21);
			this.radioButtonFullNameDisable.TabIndex = 1;
			this.radioButtonFullNameDisable.TabStop = true;
			this.radioButtonFullNameDisable.Text = "Disable";
			this.radioButtonFullNameDisable.UseVisualStyleBackColor = true;
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(9, 18);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(215, 17);
			this.label4.TabIndex = 7;
			this.label4.Text = "Convert Audio to Mono on Import";
			// 
			// groupBox3
			// 
			this.groupBox3.Controls.Add(this.buttonResetMaxSampRate);
			this.groupBox3.Controls.Add(this.label6);
			this.groupBox3.Controls.Add(this.label8);
			this.groupBox3.Controls.Add(this.numericUpDownMaxSampRate);
			this.groupBox3.Controls.Add(this.groupBox6);
			this.groupBox3.Controls.Add(this.groupBoxStereoConv);
			this.groupBox3.Controls.Add(this.label9);
			this.groupBox3.Controls.Add(this.label4);
			this.groupBox3.Location = new System.Drawing.Point(10, 425);
			this.groupBox3.Name = "groupBox3";
			this.groupBox3.Size = new System.Drawing.Size(445, 199);
			this.groupBox3.TabIndex = 8;
			// 
			// buttonResetMaxSampRate
			// 
			this.buttonResetMaxSampRate.Location = new System.Drawing.Point(132, 163);
			this.buttonResetMaxSampRate.Name = "buttonResetMaxSampRate";
			this.buttonResetMaxSampRate.Size = new System.Drawing.Size(23, 23);
			this.buttonResetMaxSampRate.TabIndex = 3;
			this.buttonResetMaxSampRate.Text = "*";
			this.buttonResetMaxSampRate.UseVisualStyleBackColor = true;
			this.buttonResetMaxSampRate.Click += new System.EventHandler(this.buttonResetMaxSampRate_Click);
			// 
			// label6
			// 
			this.label6.AutoSize = true;
			this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label6.Location = new System.Drawing.Point(161, 166);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(164, 17);
			this.label6.TabIndex = 1;
			this.label6.Text = "Note: Set to 0 to disable.";
			// 
			// label8
			// 
			this.label8.AutoSize = true;
			this.label8.Location = new System.Drawing.Point(9, 144);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(180, 17);
			this.label8.TabIndex = 2;
			this.label8.Text = "Maximum Sample Rate (hz)";
			// 
			// numericUpDownMaxSampRate
			// 
			this.numericUpDownMaxSampRate.Increment = new decimal(new int[] {
            100,
            0,
            0,
            0});
			this.numericUpDownMaxSampRate.Location = new System.Drawing.Point(12, 164);
			this.numericUpDownMaxSampRate.Maximum = new decimal(new int[] {
            44100,
            0,
            0,
            0});
			this.numericUpDownMaxSampRate.Name = "numericUpDownMaxSampRate";
			this.numericUpDownMaxSampRate.Size = new System.Drawing.Size(120, 22);
			this.numericUpDownMaxSampRate.TabIndex = 2;
			// 
			// groupBox6
			// 
			this.groupBox6.Controls.Add(this.radioButtonMatchSRAlways);
			this.groupBox6.Controls.Add(this.radioButtonMatchSRSometimes);
			this.groupBox6.Controls.Add(this.radioButtonMatchSRNever);
			this.groupBox6.Location = new System.Drawing.Point(6, 101);
			this.groupBox6.Name = "groupBox6";
			this.groupBox6.Size = new System.Drawing.Size(430, 40);
			this.groupBox6.TabIndex = 1;
			// 
			// radioButtonMatchSRAlways
			// 
			this.radioButtonMatchSRAlways.AutoSize = true;
			this.radioButtonMatchSRAlways.Location = new System.Drawing.Point(6, 10);
			this.radioButtonMatchSRAlways.Name = "radioButtonMatchSRAlways";
			this.radioButtonMatchSRAlways.Size = new System.Drawing.Size(72, 21);
			this.radioButtonMatchSRAlways.TabIndex = 0;
			this.radioButtonMatchSRAlways.TabStop = true;
			this.radioButtonMatchSRAlways.Text = "Always";
			this.radioButtonMatchSRAlways.UseVisualStyleBackColor = true;
			// 
			// radioButtonMatchSRSometimes
			// 
			this.radioButtonMatchSRSometimes.AutoSize = true;
			this.radioButtonMatchSRSometimes.Location = new System.Drawing.Point(86, 10);
			this.radioButtonMatchSRSometimes.Name = "radioButtonMatchSRSometimes";
			this.radioButtonMatchSRSometimes.Size = new System.Drawing.Size(131, 21);
			this.radioButtonMatchSRSometimes.TabIndex = 1;
			this.radioButtonMatchSRSometimes.TabStop = true;
			this.radioButtonMatchSRSometimes.Text = "If Downsampling";
			this.radioButtonMatchSRSometimes.UseVisualStyleBackColor = true;
			// 
			// radioButtonMatchSRNever
			// 
			this.radioButtonMatchSRNever.AutoSize = true;
			this.radioButtonMatchSRNever.Location = new System.Drawing.Point(223, 10);
			this.radioButtonMatchSRNever.Name = "radioButtonMatchSRNever";
			this.radioButtonMatchSRNever.Size = new System.Drawing.Size(67, 21);
			this.radioButtonMatchSRNever.TabIndex = 2;
			this.radioButtonMatchSRNever.TabStop = true;
			this.radioButtonMatchSRNever.Text = "Never";
			this.radioButtonMatchSRNever.UseVisualStyleBackColor = true;
			// 
			// groupBoxStereoConv
			// 
			this.groupBoxStereoConv.Controls.Add(this.radioButtonStereoConvAlways);
			this.groupBoxStereoConv.Controls.Add(this.radioButtonStereoConvSometimes);
			this.groupBoxStereoConv.Controls.Add(this.radioButtonStereoConvNever);
			this.groupBoxStereoConv.Location = new System.Drawing.Point(6, 38);
			this.groupBoxStereoConv.Name = "groupBoxStereoConv";
			this.groupBoxStereoConv.Size = new System.Drawing.Size(430, 40);
			this.groupBoxStereoConv.TabIndex = 0;
			this.groupBoxStereoConv.TabStop = false;
			// 
			// radioButtonStereoConvAlways
			// 
			this.radioButtonStereoConvAlways.AutoSize = true;
			this.radioButtonStereoConvAlways.Location = new System.Drawing.Point(6, 10);
			this.radioButtonStereoConvAlways.Name = "radioButtonStereoConvAlways";
			this.radioButtonStereoConvAlways.Size = new System.Drawing.Size(72, 21);
			this.radioButtonStereoConvAlways.TabIndex = 0;
			this.radioButtonStereoConvAlways.TabStop = true;
			this.radioButtonStereoConvAlways.Text = "Always";
			this.radioButtonStereoConvAlways.UseVisualStyleBackColor = true;
			// 
			// radioButtonStereoConvSometimes
			// 
			this.radioButtonStereoConvSometimes.AutoSize = true;
			this.radioButtonStereoConvSometimes.Location = new System.Drawing.Point(86, 10);
			this.radioButtonStereoConvSometimes.Name = "radioButtonStereoConvSometimes";
			this.radioButtonStereoConvSometimes.Size = new System.Drawing.Size(195, 21);
			this.radioButtonStereoConvSometimes.TabIndex = 1;
			this.radioButtonStereoConvSometimes.TabStop = true;
			this.radioButtonStereoConvSometimes.Text = "If Overwriting Mono Sound";
			this.radioButtonStereoConvSometimes.UseVisualStyleBackColor = true;
			// 
			// radioButtonStereoConvNever
			// 
			this.radioButtonStereoConvNever.AutoSize = true;
			this.radioButtonStereoConvNever.Location = new System.Drawing.Point(289, 10);
			this.radioButtonStereoConvNever.Name = "radioButtonStereoConvNever";
			this.radioButtonStereoConvNever.Size = new System.Drawing.Size(67, 21);
			this.radioButtonStereoConvNever.TabIndex = 2;
			this.radioButtonStereoConvNever.TabStop = true;
			this.radioButtonStereoConvNever.Text = "Never";
			this.radioButtonStereoConvNever.UseVisualStyleBackColor = true;
			// 
			// label9
			// 
			this.label9.AutoSize = true;
			this.label9.Location = new System.Drawing.Point(9, 81);
			this.label9.Name = "label9";
			this.label9.Size = new System.Drawing.Size(278, 17);
			this.label9.TabIndex = 6;
			this.label9.Text = "Match Audio Sample Rate to Target Sound";
			// 
			// label5
			// 
			this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.label5.AutoSize = true;
			this.label5.Location = new System.Drawing.Point(10, 629);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(88, 17);
			this.label5.TabIndex = 5;
			this.label5.Text = "Tab Settings";
			// 
			// groupBox4
			// 
			this.groupBox4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.groupBox4.Controls.Add(this.checkBoxSaveAsDefault);
			this.groupBox4.Controls.Add(this.buttonConfigLoad);
			this.groupBox4.Controls.Add(this.treeView2);
			this.groupBox4.Controls.Add(this.label7);
			this.groupBox4.Controls.Add(this.buttonConfigSave);
			this.groupBox4.Location = new System.Drawing.Point(10, 639);
			this.groupBox4.Name = "groupBox4";
			this.groupBox4.Size = new System.Drawing.Size(445, 223);
			this.groupBox4.TabIndex = 9;
			// 
			// checkBoxSaveAsDefault
			// 
			this.checkBoxSaveAsDefault.AutoSize = true;
			this.checkBoxSaveAsDefault.Checked = true;
			this.checkBoxSaveAsDefault.CheckState = System.Windows.Forms.CheckState.Checked;
			this.checkBoxSaveAsDefault.Location = new System.Drawing.Point(272, 17);
			this.checkBoxSaveAsDefault.Name = "checkBoxSaveAsDefault";
			this.checkBoxSaveAsDefault.Size = new System.Drawing.Size(174, 21);
			this.checkBoxSaveAsDefault.TabIndex = 0;
			this.checkBoxSaveAsDefault.Text = "Save Config as Default";
			this.checkBoxSaveAsDefault.UseVisualStyleBackColor = true;
			// 
			// buttonConfigLoad
			// 
			this.buttonConfigLoad.Location = new System.Drawing.Point(226, 187);
			this.buttonConfigLoad.Name = "buttonConfigLoad";
			this.buttonConfigLoad.Size = new System.Drawing.Size(105, 28);
			this.buttonConfigLoad.TabIndex = 2;
			this.buttonConfigLoad.Text = "Load Config";
			this.buttonConfigLoad.UseVisualStyleBackColor = true;
			this.buttonConfigLoad.Click += new System.EventHandler(this.buttonConfigLoad_Click);
			// 
			// treeView2
			// 
			this.treeView2.Location = new System.Drawing.Point(6, 38);
			this.treeView2.Name = "treeView2";
			this.treeView2.Size = new System.Drawing.Size(431, 143);
			this.treeView2.TabIndex = 1;
			// 
			// label7
			// 
			this.label7.AutoSize = true;
			this.label7.Location = new System.Drawing.Point(6, 18);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(139, 17);
			this.label7.TabIndex = 3;
			this.label7.Text = "Configuration Layout";
			// 
			// buttonConfigSave
			// 
			this.buttonConfigSave.Location = new System.Drawing.Point(337, 187);
			this.buttonConfigSave.Name = "buttonConfigSave";
			this.buttonConfigSave.Size = new System.Drawing.Size(105, 28);
			this.buttonConfigSave.TabIndex = 3;
			this.buttonConfigSave.Text = "Save Config";
			this.buttonConfigSave.UseVisualStyleBackColor = true;
			this.buttonConfigSave.Click += new System.EventHandler(this.buttonSaveConfig_Click);
			// 
			// label10
			// 
			this.label10.AutoSize = true;
			this.label10.Location = new System.Drawing.Point(10, 415);
			this.label10.Name = "label10";
			this.label10.Size = new System.Drawing.Size(142, 17);
			this.label10.TabIndex = 4;
			this.label10.Text = "Audio Import Settings";
			// 
			// label11
			// 
			this.label11.AutoSize = true;
			this.label11.Location = new System.Drawing.Point(10, 349);
			this.label11.Name = "label11";
			this.label11.Size = new System.Drawing.Size(272, 17);
			this.label11.TabIndex = 2;
			this.label11.Text = "Group Size Warning Threshold (In Bytes):";
			// 
			// groupBox5
			// 
			this.groupBox5.Controls.Add(this.buttonResetGroupThresh);
			this.groupBox5.Controls.Add(this.label12);
			this.groupBox5.Controls.Add(this.numericUpDownGroupSizeThresh);
			this.groupBox5.Location = new System.Drawing.Point(10, 359);
			this.groupBox5.Name = "groupBox5";
			this.groupBox5.Size = new System.Drawing.Size(445, 51);
			this.groupBox5.TabIndex = 7;
			// 
			// buttonResetGroupThresh
			// 
			this.buttonResetGroupThresh.Location = new System.Drawing.Point(132, 20);
			this.buttonResetGroupThresh.Name = "buttonResetGroupThresh";
			this.buttonResetGroupThresh.Size = new System.Drawing.Size(23, 23);
			this.buttonResetGroupThresh.TabIndex = 1;
			this.buttonResetGroupThresh.Text = "*";
			this.buttonResetGroupThresh.UseVisualStyleBackColor = true;
			this.buttonResetGroupThresh.Click += new System.EventHandler(this.buttonResetGroupThresh_Click);
			// 
			// label12
			// 
			this.label12.AutoSize = true;
			this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label12.Location = new System.Drawing.Point(161, 23);
			this.label12.Name = "label12";
			this.label12.Size = new System.Drawing.Size(164, 17);
			this.label12.TabIndex = 1;
			this.label12.Text = "Note: Set to 0 to disable.";
			// 
			// numericUpDownGroupSizeThresh
			// 
			this.numericUpDownGroupSizeThresh.Increment = new decimal(new int[] {
            10000,
            0,
            0,
            0});
			this.numericUpDownGroupSizeThresh.Location = new System.Drawing.Point(12, 21);
			this.numericUpDownGroupSizeThresh.Maximum = new decimal(new int[] {
            100000000,
            0,
            0,
            0});
			this.numericUpDownGroupSizeThresh.Name = "numericUpDownGroupSizeThresh";
			this.numericUpDownGroupSizeThresh.Size = new System.Drawing.Size(120, 22);
			this.numericUpDownGroupSizeThresh.TabIndex = 0;
			// 
			// label13
			// 
			this.label13.AutoSize = true;
			this.label13.Location = new System.Drawing.Point(12, 217);
			this.label13.Name = "label13";
			this.label13.Size = new System.Drawing.Size(225, 17);
			this.label13.TabIndex = 0;
			this.label13.Text = "Default Collection Naming Scheme";
			// 
			// groupBox7
			// 
			this.groupBox7.Controls.Add(this.radioButtonCollNameCustom);
			this.groupBox7.Controls.Add(this.radioButtonCollNameDefault);
			this.groupBox7.Controls.Add(this.radioButtonCollNameIDHex);
			this.groupBox7.Controls.Add(this.radioButtonCollNameID);
			this.groupBox7.Location = new System.Drawing.Point(12, 227);
			this.groupBox7.Name = "groupBox7";
			this.groupBox7.Size = new System.Drawing.Size(445, 51);
			this.groupBox7.TabIndex = 5;
			// 
			// radioButtonCollNameCustom
			// 
			this.radioButtonCollNameCustom.AutoSize = true;
			this.radioButtonCollNameCustom.Location = new System.Drawing.Point(350, 21);
			this.radioButtonCollNameCustom.Name = "radioButtonCollNameCustom";
			this.radioButtonCollNameCustom.Size = new System.Drawing.Size(76, 21);
			this.radioButtonCollNameCustom.TabIndex = 3;
			this.radioButtonCollNameCustom.TabStop = true;
			this.radioButtonCollNameCustom.Text = "Custom";
			this.radioButtonCollNameCustom.UseVisualStyleBackColor = true;
			// 
			// radioButtonCollNameDefault
			// 
			this.radioButtonCollNameDefault.AutoSize = true;
			this.radioButtonCollNameDefault.Location = new System.Drawing.Point(6, 21);
			this.radioButtonCollNameDefault.Name = "radioButtonCollNameDefault";
			this.radioButtonCollNameDefault.Size = new System.Drawing.Size(74, 21);
			this.radioButtonCollNameDefault.TabIndex = 0;
			this.radioButtonCollNameDefault.TabStop = true;
			this.radioButtonCollNameDefault.Text = "Default";
			this.radioButtonCollNameDefault.UseVisualStyleBackColor = true;
			// 
			// radioButtonCollNameIDHex
			// 
			this.radioButtonCollNameIDHex.AutoSize = true;
			this.radioButtonCollNameIDHex.Location = new System.Drawing.Point(199, 21);
			this.radioButtonCollNameIDHex.Name = "radioButtonCollNameIDHex";
			this.radioButtonCollNameIDHex.Size = new System.Drawing.Size(145, 21);
			this.radioButtonCollNameIDHex.TabIndex = 2;
			this.radioButtonCollNameIDHex.TabStop = true;
			this.radioButtonCollNameIDHex.Text = "Collection ID (Hex)";
			this.radioButtonCollNameIDHex.UseVisualStyleBackColor = true;
			// 
			// radioButtonCollNameID
			// 
			this.radioButtonCollNameID.AutoSize = true;
			this.radioButtonCollNameID.Location = new System.Drawing.Point(86, 21);
			this.radioButtonCollNameID.Name = "radioButtonCollNameID";
			this.radioButtonCollNameID.Size = new System.Drawing.Size(107, 21);
			this.radioButtonCollNameID.TabIndex = 1;
			this.radioButtonCollNameID.TabStop = true;
			this.radioButtonCollNameID.Text = "Collection ID";
			this.radioButtonCollNameID.UseVisualStyleBackColor = true;
			// 
			// SettingsForm
			// 
			this.AcceptButton = this.buttonSave;
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.CancelButton = this.buttonCancel;
			this.ClientSize = new System.Drawing.Size(469, 911);
			this.Controls.Add(this.label13);
			this.Controls.Add(this.groupBox7);
			this.Controls.Add(this.label11);
			this.Controls.Add(this.groupBox5);
			this.Controls.Add(this.label10);
			this.Controls.Add(this.label5);
			this.Controls.Add(this.groupBox4);
			this.Controls.Add(this.groupBox3);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.groupBox2);
			this.Controls.Add(this.buttonBRSARPathUseCurrent);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.groupBox1);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.labelDefaultNameScheme);
			this.Controls.Add(this.buttonCancel);
			this.Controls.Add(this.buttonSave);
			this.Controls.Add(this.labelDefaultBrsar);
			this.Controls.Add(this.buttonBrowse);
			this.Controls.Add(this.textBoxDefaultBrsar);
			this.Controls.Add(this.groupBoxNamingScheme);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "SettingsForm";
			this.Text = "Settings";
			this.groupBoxNamingScheme.ResumeLayout(false);
			this.groupBoxNamingScheme.PerformLayout();
			this.groupBox1.ResumeLayout(false);
			this.groupBox1.PerformLayout();
			this.groupBox2.ResumeLayout(false);
			this.groupBox2.PerformLayout();
			this.groupBox3.ResumeLayout(false);
			this.groupBox3.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDownMaxSampRate)).EndInit();
			this.groupBox6.ResumeLayout(false);
			this.groupBox6.PerformLayout();
			this.groupBoxStereoConv.ResumeLayout(false);
			this.groupBoxStereoConv.PerformLayout();
			this.groupBox4.ResumeLayout(false);
			this.groupBox4.PerformLayout();
			this.groupBox5.ResumeLayout(false);
			this.groupBox5.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDownGroupSizeThresh)).EndInit();
			this.groupBox7.ResumeLayout(false);
			this.groupBox7.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.GroupBox groupBoxNamingScheme;
		private System.Windows.Forms.RadioButton radioButtonNameManual;
		private System.Windows.Forms.RadioButton radioButtonNameDefault;
		private System.Windows.Forms.RadioButton radioButtonNamePP;
		private System.Windows.Forms.RadioButton radioButtonNamePM;
		private System.Windows.Forms.Button buttonBrowse;
		private System.Windows.Forms.TextBox textBoxDefaultBrsar;
		private System.Windows.Forms.Label labelDefaultBrsar;
		private System.Windows.Forms.Button buttonCancel;
		private System.Windows.Forms.Button buttonSave;
		private System.Windows.Forms.Label labelDefaultNameScheme;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.RadioButton radioButtonGroupDirEnable;
		private System.Windows.Forms.RadioButton radioButtonGroupDirDisable;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Button buttonBRSARPathUseCurrent;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.GroupBox groupBox2;
		private System.Windows.Forms.RadioButton radioButtonFullNameEnable;
		private System.Windows.Forms.RadioButton radioButtonFullNameDisable;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.GroupBox groupBox3;
		private System.Windows.Forms.RadioButton radioButtonStereoConvNever;
		private System.Windows.Forms.RadioButton radioButtonStereoConvAlways;
		private System.Windows.Forms.RadioButton radioButtonStereoConvSometimes;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.GroupBox groupBox4;
		private System.Windows.Forms.Button buttonConfigSave;
		private System.Windows.Forms.TreeView treeView2;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.Button buttonConfigLoad;
		private System.Windows.Forms.GroupBox groupBox6;
		private System.Windows.Forms.RadioButton radioButtonMatchSRAlways;
		private System.Windows.Forms.RadioButton radioButtonMatchSRSometimes;
		private System.Windows.Forms.RadioButton radioButtonMatchSRNever;
		private System.Windows.Forms.GroupBox groupBoxStereoConv;
		private System.Windows.Forms.Label label9;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.NumericUpDown numericUpDownMaxSampRate;
		private System.Windows.Forms.Label label10;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.Label label11;
		private System.Windows.Forms.GroupBox groupBox5;
		private System.Windows.Forms.Label label12;
		private System.Windows.Forms.NumericUpDown numericUpDownGroupSizeThresh;
		public System.Windows.Forms.CheckBox checkBoxSaveAsDefault;
		private System.Windows.Forms.Button buttonResetMaxSampRate;
		private System.Windows.Forms.Button buttonResetGroupThresh;
		private System.Windows.Forms.Label label13;
		private System.Windows.Forms.GroupBox groupBox7;
		private System.Windows.Forms.RadioButton radioButtonCollNameCustom;
		private System.Windows.Forms.RadioButton radioButtonCollNameDefault;
		private System.Windows.Forms.RadioButton radioButtonCollNameIDHex;
		private System.Windows.Forms.RadioButton radioButtonCollNameID;
	}
}