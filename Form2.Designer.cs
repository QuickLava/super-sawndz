
namespace BrawlSoundConverter
{
	partial class nameInputForm
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
			this.treeViewNames = new System.Windows.Forms.TreeView();
			this.label1 = new System.Windows.Forms.Label();
			this.button1 = new System.Windows.Forms.Button();
			this.button2 = new System.Windows.Forms.Button();
			this.treeView1 = new System.Windows.Forms.TreeView();
			this.labelBaseString = new System.Windows.Forms.Label();
			this.button3 = new System.Windows.Forms.Button();
			this.label2 = new System.Windows.Forms.Label();
			this.textBox1 = new System.Windows.Forms.TextBox();
			this.label3 = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// treeViewNames
			// 
			this.treeViewNames.Location = new System.Drawing.Point(12, 77);
			this.treeViewNames.Name = "treeViewNames";
			this.treeViewNames.ShowLines = false;
			this.treeViewNames.ShowPlusMinus = false;
			this.treeViewNames.ShowRootLines = false;
			this.treeViewNames.Size = new System.Drawing.Size(414, 302);
			this.treeViewNames.TabIndex = 1;
			this.treeViewNames.DoubleClick += new System.EventHandler(this.treeViewNames_DoubleClick);
			this.treeViewNames.KeyDown += new System.Windows.Forms.KeyEventHandler(this.treeViewNames_KeyDown);
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(9, 57);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(78, 17);
			this.label1.TabIndex = 2;
			this.label1.Text = "File Names";
			// 
			// button1
			// 
			this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.button1.Location = new System.Drawing.Point(595, 423);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(79, 28);
			this.button1.TabIndex = 3;
			this.button1.Text = "Finish";
			this.button1.UseVisualStyleBackColor = true;
			this.button1.Click += new System.EventHandler(this.button1_Click);
			// 
			// button2
			// 
			this.button2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.button2.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.button2.Location = new System.Drawing.Point(680, 422);
			this.button2.Name = "button2";
			this.button2.Size = new System.Drawing.Size(79, 28);
			this.button2.TabIndex = 4;
			this.button2.Text = "Cancel";
			this.button2.UseVisualStyleBackColor = true;
			this.button2.Click += new System.EventHandler(this.button2_Click);
			// 
			// treeView1
			// 
			this.treeView1.Location = new System.Drawing.Point(432, 77);
			this.treeView1.Name = "treeView1";
			this.treeView1.ShowLines = false;
			this.treeView1.ShowPlusMinus = false;
			this.treeView1.ShowRootLines = false;
			this.treeView1.Size = new System.Drawing.Size(326, 301);
			this.treeView1.TabIndex = 6;
			this.treeView1.NodeMouseDoubleClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.treeView1_NodeMouseDoubleClick);
			this.treeView1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.treeView1_KeyDown);
			// 
			// labelBaseString
			// 
			this.labelBaseString.AutoSize = true;
			this.labelBaseString.Location = new System.Drawing.Point(9, 9);
			this.labelBaseString.Name = "labelBaseString";
			this.labelBaseString.Size = new System.Drawing.Size(122, 17);
			this.labelBaseString.TabIndex = 8;
			this.labelBaseString.Text = "Base Name String";
			// 
			// button3
			// 
			this.button3.Location = new System.Drawing.Point(683, 25);
			this.button3.Name = "button3";
			this.button3.Size = new System.Drawing.Size(75, 28);
			this.button3.TabIndex = 9;
			this.button3.Text = "Apply";
			this.button3.UseVisualStyleBackColor = true;
			this.button3.Click += new System.EventHandler(this.button3_Click);
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(432, 56);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(147, 17);
			this.label2.TabIndex = 10;
			this.label2.Text = "Base Name Wildcards";
			// 
			// textBox1
			// 
			this.textBox1.Location = new System.Drawing.Point(13, 28);
			this.textBox1.Name = "textBox1";
			this.textBox1.Size = new System.Drawing.Size(661, 22);
			this.textBox1.TabIndex = 11;
			this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label3.Location = new System.Drawing.Point(211, 399);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(547, 17);
			this.label3.TabIndex = 12;
			this.label3.Text = "Note: Double-click or press Enter on a Wildcard to insert it into the Base Name S" +
    "tring.";
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label4.Location = new System.Drawing.Point(336, 382);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(423, 17);
			this.label4.TabIndex = 13;
			this.label4.Text = "Note: Double-click or press Enter on a File Name to directly edit it.";
			// 
			// nameInputForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.CancelButton = this.button2;
			this.ClientSize = new System.Drawing.Size(771, 462);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.textBox1);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.button3);
			this.Controls.Add(this.labelBaseString);
			this.Controls.Add(this.treeView1);
			this.Controls.Add(this.button2);
			this.Controls.Add(this.button1);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.treeViewNames);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "nameInputForm";
			this.Text = "Input Name";
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion
		public System.Windows.Forms.TreeView treeViewNames;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.Button button2;
		public System.Windows.Forms.TreeView treeView1;
		private System.Windows.Forms.Label labelBaseString;
		private System.Windows.Forms.Button button3;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.TextBox textBox1;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label4;
	}
}