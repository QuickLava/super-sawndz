﻿
namespace BrawlSoundConverter
{
	partial class SoundPropertiesForm
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
			this.label2 = new System.Windows.Forms.Label();
			this.numericUpDownVol = new System.Windows.Forms.NumericUpDown();
			this.textBox1 = new System.Windows.Forms.TextBox();
			this.numericUpDownPan = new System.Windows.Forms.NumericUpDown();
			this.numericUpDownPitch = new System.Windows.Forms.NumericUpDown();
			this.label4 = new System.Windows.Forms.Label();
			this.label5 = new System.Windows.Forms.Label();
			this.button1 = new System.Windows.Forms.Button();
			this.button2 = new System.Windows.Forms.Button();
			this.numericUpDownFX1 = new System.Windows.Forms.NumericUpDown();
			this.numericUpDownFX2 = new System.Windows.Forms.NumericUpDown();
			this.numericUpDownFX3 = new System.Windows.Forms.NumericUpDown();
			this.label3 = new System.Windows.Forms.Label();
			this.label6 = new System.Windows.Forms.Label();
			this.label7 = new System.Windows.Forms.Label();
			this.label8 = new System.Windows.Forms.Label();
			this.textBox2 = new System.Windows.Forms.TextBox();
			this.label9 = new System.Windows.Forms.Label();
			this.textBox3 = new System.Windows.Forms.TextBox();
			this.label10 = new System.Windows.Forms.Label();
			this.textBox4 = new System.Windows.Forms.TextBox();
			this.label11 = new System.Windows.Forms.Label();
			this.textBox5 = new System.Windows.Forms.TextBox();
			this.label12 = new System.Windows.Forms.Label();
			this.textBox6 = new System.Windows.Forms.TextBox();
			this.label13 = new System.Windows.Forms.Label();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDownVol)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDownPan)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDownPitch)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDownFX1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDownFX2)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDownFX3)).BeginInit();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(13, 13);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(90, 17);
			this.label1.TabIndex = 26;
			this.label1.Text = "Sound Name";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(13, 155);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(71, 17);
			this.label2.TabIndex = 24;
			this.label2.Text = "MainSend";
			// 
			// numericUpDownVol
			// 
			this.numericUpDownVol.Location = new System.Drawing.Point(16, 176);
			this.numericUpDownVol.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
			this.numericUpDownVol.Name = "numericUpDownVol";
			this.numericUpDownVol.Size = new System.Drawing.Size(70, 22);
			this.numericUpDownVol.TabIndex = 6;
			// 
			// textBox1
			// 
			this.textBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.textBox1.Enabled = false;
			this.textBox1.Location = new System.Drawing.Point(16, 34);
			this.textBox1.Name = "textBox1";
			this.textBox1.Size = new System.Drawing.Size(452, 22);
			this.textBox1.TabIndex = 0;
			// 
			// numericUpDownPan
			// 
			this.numericUpDownPan.Location = new System.Drawing.Point(92, 176);
			this.numericUpDownPan.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
			this.numericUpDownPan.Name = "numericUpDownPan";
			this.numericUpDownPan.Size = new System.Drawing.Size(70, 22);
			this.numericUpDownPan.TabIndex = 7;
			// 
			// numericUpDownPitch
			// 
			this.numericUpDownPitch.DecimalPlaces = 2;
			this.numericUpDownPitch.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
			this.numericUpDownPitch.Location = new System.Drawing.Point(168, 176);
			this.numericUpDownPitch.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
			this.numericUpDownPitch.Name = "numericUpDownPitch";
			this.numericUpDownPitch.Size = new System.Drawing.Size(70, 22);
			this.numericUpDownPitch.TabIndex = 8;
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(165, 156);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(39, 17);
			this.label4.TabIndex = 20;
			this.label4.Text = "Pitch";
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Location = new System.Drawing.Point(93, 155);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(33, 17);
			this.label5.TabIndex = 19;
			this.label5.Text = "Pan";
			// 
			// button1
			// 
			this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.button1.Location = new System.Drawing.Point(320, 222);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(70, 28);
			this.button1.TabIndex = 12;
			this.button1.Text = "Save";
			this.button1.UseVisualStyleBackColor = true;
			this.button1.Click += new System.EventHandler(this.button1_Click);
			// 
			// button2
			// 
			this.button2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.button2.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.button2.Location = new System.Drawing.Point(396, 222);
			this.button2.Name = "button2";
			this.button2.Size = new System.Drawing.Size(72, 28);
			this.button2.TabIndex = 13;
			this.button2.Text = "Cancel";
			this.button2.UseVisualStyleBackColor = true;
			this.button2.Click += new System.EventHandler(this.button2_Click);
			// 
			// numericUpDownFX1
			// 
			this.numericUpDownFX1.Location = new System.Drawing.Point(244, 176);
			this.numericUpDownFX1.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
			this.numericUpDownFX1.Name = "numericUpDownFX1";
			this.numericUpDownFX1.Size = new System.Drawing.Size(70, 22);
			this.numericUpDownFX1.TabIndex = 9;
			// 
			// numericUpDownFX2
			// 
			this.numericUpDownFX2.Location = new System.Drawing.Point(320, 176);
			this.numericUpDownFX2.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
			this.numericUpDownFX2.Name = "numericUpDownFX2";
			this.numericUpDownFX2.Size = new System.Drawing.Size(70, 22);
			this.numericUpDownFX2.TabIndex = 10;
			// 
			// numericUpDownFX3
			// 
			this.numericUpDownFX3.Location = new System.Drawing.Point(396, 176);
			this.numericUpDownFX3.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
			this.numericUpDownFX3.Name = "numericUpDownFX3";
			this.numericUpDownFX3.Size = new System.Drawing.Size(70, 22);
			this.numericUpDownFX3.TabIndex = 11;
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(241, 156);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(68, 17);
			this.label3.TabIndex = 13;
			this.label3.Text = "FxSend A";
			// 
			// label6
			// 
			this.label6.AutoSize = true;
			this.label6.Location = new System.Drawing.Point(317, 156);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(68, 17);
			this.label6.TabIndex = 12;
			this.label6.Text = "FxSend B";
			// 
			// label7
			// 
			this.label7.AutoSize = true;
			this.label7.Location = new System.Drawing.Point(393, 156);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(68, 17);
			this.label7.TabIndex = 11;
			this.label7.Text = "FxSend C";
			// 
			// label8
			// 
			this.label8.AutoSize = true;
			this.label8.Location = new System.Drawing.Point(13, 59);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(113, 17);
			this.label8.TabIndex = 10;
			this.label8.Text = "Sound Info Index";
			// 
			// textBox2
			// 
			this.textBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.textBox2.Enabled = false;
			this.textBox2.Location = new System.Drawing.Point(16, 79);
			this.textBox2.Name = "textBox2";
			this.textBox2.Size = new System.Drawing.Size(452, 22);
			this.textBox2.TabIndex = 1;
			// 
			// label9
			// 
			this.label9.AutoSize = true;
			this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label9.Location = new System.Drawing.Point(49, 201);
			this.label9.Name = "label9";
			this.label9.Size = new System.Drawing.Size(425, 17);
			this.label9.TabIndex = 8;
			this.label9.Text = "Note: \'MainSend\' controls sound volume, \'FxSend\' controls reverb.";
			// 
			// textBox3
			// 
			this.textBox3.Enabled = false;
			this.textBox3.Location = new System.Drawing.Point(15, 124);
			this.textBox3.Name = "textBox3";
			this.textBox3.Size = new System.Drawing.Size(106, 22);
			this.textBox3.TabIndex = 2;
			// 
			// label10
			// 
			this.label10.AutoSize = true;
			this.label10.Location = new System.Drawing.Point(12, 104);
			this.label10.Name = "label10";
			this.label10.Size = new System.Drawing.Size(96, 17);
			this.label10.TabIndex = 7;
			this.label10.Text = "Sample Count";
			// 
			// textBox4
			// 
			this.textBox4.Enabled = false;
			this.textBox4.Location = new System.Drawing.Point(129, 124);
			this.textBox4.Name = "textBox4";
			this.textBox4.Size = new System.Drawing.Size(106, 22);
			this.textBox4.TabIndex = 3;
			// 
			// label11
			// 
			this.label11.AutoSize = true;
			this.label11.Location = new System.Drawing.Point(126, 104);
			this.label11.Name = "label11";
			this.label11.Size = new System.Drawing.Size(89, 17);
			this.label11.TabIndex = 5;
			this.label11.Text = "Sample Rate";
			// 
			// textBox5
			// 
			this.textBox5.Enabled = false;
			this.textBox5.Location = new System.Drawing.Point(244, 124);
			this.textBox5.Name = "textBox5";
			this.textBox5.Size = new System.Drawing.Size(106, 22);
			this.textBox5.TabIndex = 4;
			// 
			// label12
			// 
			this.label12.AutoSize = true;
			this.label12.Location = new System.Drawing.Point(241, 104);
			this.label12.Name = "label12";
			this.label12.Size = new System.Drawing.Size(110, 17);
			this.label12.TabIndex = 3;
			this.label12.Text = "Loop Start Point";
			// 
			// textBox6
			// 
			this.textBox6.Enabled = false;
			this.textBox6.Location = new System.Drawing.Point(359, 124);
			this.textBox6.Name = "textBox6";
			this.textBox6.Size = new System.Drawing.Size(106, 22);
			this.textBox6.TabIndex = 5;
			// 
			// label13
			// 
			this.label13.AutoSize = true;
			this.label13.Location = new System.Drawing.Point(356, 104);
			this.label13.Name = "label13";
			this.label13.Size = new System.Drawing.Size(101, 17);
			this.label13.TabIndex = 1;
			this.label13.Text = "Channel Count";
			// 
			// SoundPropertiesForm
			// 
			this.AcceptButton = this.button1;
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.CancelButton = this.button2;
			this.ClientSize = new System.Drawing.Size(480, 257);
			this.Controls.Add(this.textBox6);
			this.Controls.Add(this.label13);
			this.Controls.Add(this.textBox5);
			this.Controls.Add(this.label12);
			this.Controls.Add(this.textBox4);
			this.Controls.Add(this.label11);
			this.Controls.Add(this.textBox3);
			this.Controls.Add(this.label10);
			this.Controls.Add(this.label9);
			this.Controls.Add(this.textBox2);
			this.Controls.Add(this.label8);
			this.Controls.Add(this.label7);
			this.Controls.Add(this.label6);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.numericUpDownFX3);
			this.Controls.Add(this.numericUpDownFX2);
			this.Controls.Add(this.numericUpDownFX1);
			this.Controls.Add(this.button2);
			this.Controls.Add(this.button1);
			this.Controls.Add(this.label5);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.numericUpDownPitch);
			this.Controls.Add(this.numericUpDownPan);
			this.Controls.Add(this.numericUpDownVol);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.textBox1);
			this.Controls.Add(this.label1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "SoundPropertiesForm";
			this.Text = "Edit Sound Properties";
			((System.ComponentModel.ISupportInitialize)(this.numericUpDownVol)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDownPan)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDownPitch)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDownFX1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDownFX2)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDownFX3)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.NumericUpDown numericUpDownVol;
		private System.Windows.Forms.TextBox textBox1;
		private System.Windows.Forms.NumericUpDown numericUpDownPan;
		private System.Windows.Forms.NumericUpDown numericUpDownPitch;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.Button button2;
		private System.Windows.Forms.NumericUpDown numericUpDownFX1;
		private System.Windows.Forms.NumericUpDown numericUpDownFX2;
		private System.Windows.Forms.NumericUpDown numericUpDownFX3;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.TextBox textBox2;
		private System.Windows.Forms.Label label9;
		private System.Windows.Forms.TextBox textBox3;
		private System.Windows.Forms.Label label10;
		private System.Windows.Forms.TextBox textBox4;
		private System.Windows.Forms.Label label11;
		private System.Windows.Forms.TextBox textBox5;
		private System.Windows.Forms.Label label12;
		private System.Windows.Forms.TextBox textBox6;
		private System.Windows.Forms.Label label13;
	}
}