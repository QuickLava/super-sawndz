
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
			this.radioButtonStereoConvNever = new System.Windows.Forms.RadioButton();
			this.radioButtonStereoConvAlways = new System.Windows.Forms.RadioButton();
			this.radioButtonStereoConvSometimes = new System.Windows.Forms.RadioButton();
			this.label5 = new System.Windows.Forms.Label();
			this.groupBox4 = new System.Windows.Forms.GroupBox();
			this.buttonConfigLoad = new System.Windows.Forms.Button();
			this.treeView2 = new System.Windows.Forms.TreeView();
			this.label7 = new System.Windows.Forms.Label();
			this.buttonConfigSave = new System.Windows.Forms.Button();
			this.groupBoxNamingScheme.SuspendLayout();
			this.groupBox1.SuspendLayout();
			this.groupBox2.SuspendLayout();
			this.groupBox3.SuspendLayout();
			this.groupBox4.SuspendLayout();
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
			this.groupBoxNamingScheme.TabIndex = 27;
			this.groupBoxNamingScheme.TabStop = false;
			// 
			// radioButtonNameManual
			// 
			this.radioButtonNameManual.AutoSize = true;
			this.radioButtonNameManual.Location = new System.Drawing.Point(314, 22);
			this.radioButtonNameManual.Name = "radioButtonNameManual";
			this.radioButtonNameManual.Size = new System.Drawing.Size(75, 21);
			this.radioButtonNameManual.TabIndex = 26;
			this.radioButtonNameManual.TabStop = true;
			this.radioButtonNameManual.Text = "Manual";
			this.radioButtonNameManual.UseVisualStyleBackColor = true;
			// 
			// radioButtonNameDefault
			// 
			this.radioButtonNameDefault.AutoSize = true;
			this.radioButtonNameDefault.Location = new System.Drawing.Point(6, 21);
			this.radioButtonNameDefault.Name = "radioButtonNameDefault";
			this.radioButtonNameDefault.Size = new System.Drawing.Size(74, 21);
			this.radioButtonNameDefault.TabIndex = 22;
			this.radioButtonNameDefault.Text = "Default";
			this.radioButtonNameDefault.UseVisualStyleBackColor = true;
			// 
			// radioButtonNamePP
			// 
			this.radioButtonNamePP.AutoSize = true;
			this.radioButtonNamePP.Location = new System.Drawing.Point(226, 21);
			this.radioButtonNamePP.Name = "radioButtonNamePP";
			this.radioButtonNamePP.Size = new System.Drawing.Size(81, 21);
			this.radioButtonNamePP.TabIndex = 25;
			this.radioButtonNamePP.Text = "Project+";
			this.radioButtonNamePP.UseVisualStyleBackColor = true;
			// 
			// radioButtonNamePM
			// 
			this.radioButtonNamePM.AutoSize = true;
			this.radioButtonNamePM.Location = new System.Drawing.Point(86, 21);
			this.radioButtonNamePM.Name = "radioButtonNamePM";
			this.radioButtonNamePM.Size = new System.Drawing.Size(134, 21);
			this.radioButtonNamePM.TabIndex = 24;
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
			this.buttonBrowse.TabIndex = 32;
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
			this.textBoxDefaultBrsar.TabIndex = 31;
			this.textBoxDefaultBrsar.TextChanged += new System.EventHandler(this.textBoxDefaultBrsar_TextChanged);
			// 
			// labelDefaultBrsar
			// 
			this.labelDefaultBrsar.AutoSize = true;
			this.labelDefaultBrsar.Location = new System.Drawing.Point(12, 9);
			this.labelDefaultBrsar.Name = "labelDefaultBrsar";
			this.labelDefaultBrsar.Size = new System.Drawing.Size(130, 17);
			this.labelDefaultBrsar.TabIndex = 33;
			this.labelDefaultBrsar.Text = "Default BRSAR File";
			// 
			// buttonCancel
			// 
			this.buttonCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.buttonCancel.Location = new System.Drawing.Point(356, 603);
			this.buttonCancel.Margin = new System.Windows.Forms.Padding(4);
			this.buttonCancel.Name = "buttonCancel";
			this.buttonCancel.Size = new System.Drawing.Size(100, 28);
			this.buttonCancel.TabIndex = 35;
			this.buttonCancel.Text = "Cancel";
			this.buttonCancel.UseVisualStyleBackColor = true;
			// 
			// buttonSave
			// 
			this.buttonSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.buttonSave.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.buttonSave.Location = new System.Drawing.Point(248, 603);
			this.buttonSave.Margin = new System.Windows.Forms.Padding(4);
			this.buttonSave.Name = "buttonSave";
			this.buttonSave.Size = new System.Drawing.Size(100, 28);
			this.buttonSave.TabIndex = 34;
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
			this.labelDefaultNameScheme.TabIndex = 34;
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
			this.label1.TabIndex = 36;
			this.label1.Text = "Warning: Specified File Doesn\'t Exist!";
			this.label1.Visible = false;
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.radioButtonGroupDirEnable);
			this.groupBox1.Controls.Add(this.radioButtonGroupDirDisable);
			this.groupBox1.Location = new System.Drawing.Point(10, 227);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(445, 51);
			this.groupBox1.TabIndex = 28;
			this.groupBox1.TabStop = false;
			// 
			// radioButtonGroupDirEnable
			// 
			this.radioButtonGroupDirEnable.AutoSize = true;
			this.radioButtonGroupDirEnable.Location = new System.Drawing.Point(6, 21);
			this.radioButtonGroupDirEnable.Name = "radioButtonGroupDirEnable";
			this.radioButtonGroupDirEnable.Size = new System.Drawing.Size(73, 21);
			this.radioButtonGroupDirEnable.TabIndex = 22;
			this.radioButtonGroupDirEnable.Text = "Enable";
			this.radioButtonGroupDirEnable.UseVisualStyleBackColor = true;
			// 
			// radioButtonGroupDirDisable
			// 
			this.radioButtonGroupDirDisable.AutoSize = true;
			this.radioButtonGroupDirDisable.Location = new System.Drawing.Point(86, 21);
			this.radioButtonGroupDirDisable.Name = "radioButtonGroupDirDisable";
			this.radioButtonGroupDirDisable.Size = new System.Drawing.Size(76, 21);
			this.radioButtonGroupDirDisable.TabIndex = 24;
			this.radioButtonGroupDirDisable.Text = "Disable";
			this.radioButtonGroupDirDisable.UseVisualStyleBackColor = true;
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(10, 217);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(352, 17);
			this.label2.TabIndex = 37;
			this.label2.Text = "Create Group Directory by Default in Multi Create WAV";
			// 
			// buttonBRSARPathUseCurrent
			// 
			this.buttonBRSARPathUseCurrent.Enabled = false;
			this.buttonBRSARPathUseCurrent.Location = new System.Drawing.Point(364, 56);
			this.buttonBRSARPathUseCurrent.Name = "buttonBRSARPathUseCurrent";
			this.buttonBRSARPathUseCurrent.Size = new System.Drawing.Size(92, 24);
			this.buttonBRSARPathUseCurrent.TabIndex = 38;
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
			this.label3.TabIndex = 40;
			this.label3.Text = "Enable Full-Length Group Name Display";
			// 
			// groupBox2
			// 
			this.groupBox2.Controls.Add(this.radioButtonFullNameEnable);
			this.groupBox2.Controls.Add(this.radioButtonFullNameDisable);
			this.groupBox2.Location = new System.Drawing.Point(10, 95);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new System.Drawing.Size(445, 51);
			this.groupBox2.TabIndex = 39;
			this.groupBox2.TabStop = false;
			// 
			// radioButtonFullNameEnable
			// 
			this.radioButtonFullNameEnable.AutoSize = true;
			this.radioButtonFullNameEnable.Location = new System.Drawing.Point(6, 21);
			this.radioButtonFullNameEnable.Name = "radioButtonFullNameEnable";
			this.radioButtonFullNameEnable.Size = new System.Drawing.Size(73, 21);
			this.radioButtonFullNameEnable.TabIndex = 22;
			this.radioButtonFullNameEnable.Text = "Enable";
			this.radioButtonFullNameEnable.UseVisualStyleBackColor = true;
			// 
			// radioButtonFullNameDisable
			// 
			this.radioButtonFullNameDisable.AutoSize = true;
			this.radioButtonFullNameDisable.Location = new System.Drawing.Point(86, 21);
			this.radioButtonFullNameDisable.Name = "radioButtonFullNameDisable";
			this.radioButtonFullNameDisable.Size = new System.Drawing.Size(76, 21);
			this.radioButtonFullNameDisable.TabIndex = 24;
			this.radioButtonFullNameDisable.Text = "Disable";
			this.radioButtonFullNameDisable.UseVisualStyleBackColor = true;
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(10, 283);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(243, 17);
			this.label4.TabIndex = 42;
			this.label4.Text = "Convert WAV Files to Mono on Import";
			// 
			// groupBox3
			// 
			this.groupBox3.Controls.Add(this.radioButtonStereoConvNever);
			this.groupBox3.Controls.Add(this.radioButtonStereoConvAlways);
			this.groupBox3.Controls.Add(this.radioButtonStereoConvSometimes);
			this.groupBox3.Location = new System.Drawing.Point(10, 293);
			this.groupBox3.Name = "groupBox3";
			this.groupBox3.Size = new System.Drawing.Size(445, 51);
			this.groupBox3.TabIndex = 41;
			this.groupBox3.TabStop = false;
			// 
			// radioButtonStereoConvNever
			// 
			this.radioButtonStereoConvNever.AutoSize = true;
			this.radioButtonStereoConvNever.Location = new System.Drawing.Point(289, 21);
			this.radioButtonStereoConvNever.Name = "radioButtonStereoConvNever";
			this.radioButtonStereoConvNever.Size = new System.Drawing.Size(67, 21);
			this.radioButtonStereoConvNever.TabIndex = 25;
			this.radioButtonStereoConvNever.Text = "Never";
			this.radioButtonStereoConvNever.UseVisualStyleBackColor = true;
			// 
			// radioButtonStereoConvAlways
			// 
			this.radioButtonStereoConvAlways.AutoSize = true;
			this.radioButtonStereoConvAlways.Location = new System.Drawing.Point(6, 21);
			this.radioButtonStereoConvAlways.Name = "radioButtonStereoConvAlways";
			this.radioButtonStereoConvAlways.Size = new System.Drawing.Size(72, 21);
			this.radioButtonStereoConvAlways.TabIndex = 22;
			this.radioButtonStereoConvAlways.Text = "Always";
			this.radioButtonStereoConvAlways.UseVisualStyleBackColor = true;
			// 
			// radioButtonStereoConvSometimes
			// 
			this.radioButtonStereoConvSometimes.AutoSize = true;
			this.radioButtonStereoConvSometimes.Location = new System.Drawing.Point(86, 21);
			this.radioButtonStereoConvSometimes.Name = "radioButtonStereoConvSometimes";
			this.radioButtonStereoConvSometimes.Size = new System.Drawing.Size(195, 21);
			this.radioButtonStereoConvSometimes.TabIndex = 24;
			this.radioButtonStereoConvSometimes.Text = "If Overwriting Mono Sound";
			this.radioButtonStereoConvSometimes.UseVisualStyleBackColor = true;
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Location = new System.Drawing.Point(10, 349);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(88, 17);
			this.label5.TabIndex = 44;
			this.label5.Text = "Tab Settings";
			// 
			// groupBox4
			// 
			this.groupBox4.Controls.Add(this.buttonConfigLoad);
			this.groupBox4.Controls.Add(this.treeView2);
			this.groupBox4.Controls.Add(this.label7);
			this.groupBox4.Controls.Add(this.buttonConfigSave);
			this.groupBox4.Location = new System.Drawing.Point(10, 359);
			this.groupBox4.Name = "groupBox4";
			this.groupBox4.Size = new System.Drawing.Size(445, 223);
			this.groupBox4.TabIndex = 43;
			this.groupBox4.TabStop = false;
			// 
			// buttonConfigLoad
			// 
			this.buttonConfigLoad.Location = new System.Drawing.Point(226, 187);
			this.buttonConfigLoad.Name = "buttonConfigLoad";
			this.buttonConfigLoad.Size = new System.Drawing.Size(105, 28);
			this.buttonConfigLoad.TabIndex = 6;
			this.buttonConfigLoad.Text = "Load Config";
			this.buttonConfigLoad.UseVisualStyleBackColor = true;
			this.buttonConfigLoad.Click += new System.EventHandler(this.buttonConfigLoad_Click);
			// 
			// treeView2
			// 
			this.treeView2.Location = new System.Drawing.Point(6, 38);
			this.treeView2.Name = "treeView2";
			this.treeView2.Size = new System.Drawing.Size(431, 143);
			this.treeView2.TabIndex = 4;
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
			this.buttonConfigSave.TabIndex = 0;
			this.buttonConfigSave.Text = "Save Config";
			this.buttonConfigSave.UseVisualStyleBackColor = true;
			this.buttonConfigSave.Click += new System.EventHandler(this.buttonSaveConfig_Click);
			// 
			// SettingsForm
			// 
			this.AcceptButton = this.buttonSave;
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.CancelButton = this.buttonCancel;
			this.ClientSize = new System.Drawing.Size(469, 644);
			this.Controls.Add(this.label5);
			this.Controls.Add(this.groupBox4);
			this.Controls.Add(this.label4);
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
			this.groupBox4.ResumeLayout(false);
			this.groupBox4.PerformLayout();
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
	}
}