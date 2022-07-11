
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
			this.SuspendLayout();
			// 
			// treeViewNames
			// 
			this.treeViewNames.Location = new System.Drawing.Point(15, 29);
			this.treeViewNames.Name = "treeViewNames";
			this.treeViewNames.Size = new System.Drawing.Size(323, 352);
			this.treeViewNames.TabIndex = 1;
			this.treeViewNames.DoubleClick += new System.EventHandler(this.treeViewNames_DoubleClick);
			this.treeViewNames.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.treeViewNames_KeyPress);
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(12, 9);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(124, 17);
			this.label1.TabIndex = 2;
			this.label1.Text = "Sawnd File Names";
			// 
			// button1
			// 
			this.button1.Location = new System.Drawing.Point(174, 387);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(79, 28);
			this.button1.TabIndex = 3;
			this.button1.Text = "Finish";
			this.button1.UseVisualStyleBackColor = true;
			this.button1.Click += new System.EventHandler(this.button1_Click);
			// 
			// button2
			// 
			this.button2.Location = new System.Drawing.Point(259, 387);
			this.button2.Name = "button2";
			this.button2.Size = new System.Drawing.Size(79, 28);
			this.button2.TabIndex = 4;
			this.button2.Text = "Cancel";
			this.button2.UseVisualStyleBackColor = true;
			this.button2.Click += new System.EventHandler(this.button2_Click);
			// 
			// nameInputForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(351, 423);
			this.Controls.Add(this.button2);
			this.Controls.Add(this.button1);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.treeViewNames);
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
	}
}