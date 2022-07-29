
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
			this.groupBoxNamingScheme.SuspendLayout();
			this.groupBox1.SuspendLayout();
			this.groupBox2.SuspendLayout();
			this.SuspendLayout();
			// 
			// groupBoxNamingScheme
			// 
			this.groupBoxNamingScheme.Controls.Add(this.radioButtonNameManual);
			this.groupBoxNamingScheme.Controls.Add(this.radioButtonNameDefault);
			this.groupBoxNamingScheme.Controls.Add(this.radioButtonNamePP);
			this.groupBoxNamingScheme.Controls.Add(this.radioButtonNamePM);
			this.groupBoxNamingScheme.Location = new System.Drawing.Point(10, 163);
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
			this.buttonBrowse.Location = new System.Drawing.Point(422, 29);
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
			this.textBoxDefaultBrsar.Location = new System.Drawing.Point(12, 30);
			this.textBoxDefaultBrsar.Margin = new System.Windows.Forms.Padding(4);
			this.textBoxDefaultBrsar.Name = "textBoxDefaultBrsar";
			this.textBoxDefaultBrsar.Size = new System.Drawing.Size(405, 22);
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
			this.buttonCancel.Location = new System.Drawing.Point(361, 297);
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
			this.buttonSave.Location = new System.Drawing.Point(253, 297);
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
			this.labelDefaultNameScheme.Location = new System.Drawing.Point(10, 153);
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
			this.groupBox1.Location = new System.Drawing.Point(10, 234);
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
			this.label2.Location = new System.Drawing.Point(10, 224);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(352, 17);
			this.label2.TabIndex = 37;
			this.label2.Text = "Create Group Directory by Default in Multi Create WAV";
			// 
			// buttonBRSARPathUseCurrent
			// 
			this.buttonBRSARPathUseCurrent.Enabled = false;
			this.buttonBRSARPathUseCurrent.Location = new System.Drawing.Point(365, 56);
			this.buttonBRSARPathUseCurrent.Name = "buttonBRSARPathUseCurrent";
			this.buttonBRSARPathUseCurrent.Size = new System.Drawing.Size(92, 24);
			this.buttonBRSARPathUseCurrent.TabIndex = 38;
			this.buttonBRSARPathUseCurrent.Text = "Use Current";
			this.buttonBRSARPathUseCurrent.UseVisualStyleBackColor = true;
			this.buttonBRSARPathUseCurrent.Click += new System.EventHandler(this.button1_Click);
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
			// SettingsForm
			// 
			this.AcceptButton = this.buttonSave;
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.CancelButton = this.buttonCancel;
			this.ClientSize = new System.Drawing.Size(474, 338);
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
			this.Name = "SettingsForm";
			this.Text = "Settings";
			this.groupBoxNamingScheme.ResumeLayout(false);
			this.groupBoxNamingScheme.PerformLayout();
			this.groupBox1.ResumeLayout(false);
			this.groupBox1.PerformLayout();
			this.groupBox2.ResumeLayout(false);
			this.groupBox2.PerformLayout();
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
	}
}