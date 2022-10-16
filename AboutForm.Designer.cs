
namespace BrawlSoundConverter
{
	partial class AboutForm
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
			this.components = new System.ComponentModel.Container();
			this.labelSuperSawndz = new System.Windows.Forms.Label();
			this.treeView1 = new System.Windows.Forms.TreeView();
			this.buttonClose = new System.Windows.Forms.Button();
			this.label1 = new System.Windows.Forms.Label();
			this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
			this.SuspendLayout();
			// 
			// labelSuperSawndz
			// 
			this.labelSuperSawndz.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.labelSuperSawndz.Location = new System.Drawing.Point(12, 9);
			this.labelSuperSawndz.Name = "labelSuperSawndz";
			this.labelSuperSawndz.Size = new System.Drawing.Size(603, 23);
			this.labelSuperSawndz.TabIndex = 0;
			this.labelSuperSawndz.Text = "Super Sawndz - Version ";
			this.labelSuperSawndz.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.labelSuperSawndz.Click += new System.EventHandler(this.labelSuperSawndz_Click);
			// 
			// treeView1
			// 
			this.treeView1.BackColor = System.Drawing.SystemColors.Control;
			this.treeView1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.treeView1.Location = new System.Drawing.Point(12, 41);
			this.treeView1.Name = "treeView1";
			this.treeView1.ShowLines = false;
			this.treeView1.ShowPlusMinus = false;
			this.treeView1.ShowRootLines = false;
			this.treeView1.Size = new System.Drawing.Size(603, 365);
			this.treeView1.TabIndex = 1;
			this.treeView1.TabStop = false;
			// 
			// buttonClose
			// 
			this.buttonClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.buttonClose.Location = new System.Drawing.Point(540, 410);
			this.buttonClose.Name = "buttonClose";
			this.buttonClose.Size = new System.Drawing.Size(75, 28);
			this.buttonClose.TabIndex = 2;
			this.buttonClose.Text = "Close";
			this.buttonClose.UseVisualStyleBackColor = true;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label1.Location = new System.Drawing.Point(14, 450);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(221, 17);
			this.label1.TabIndex = 3;
			this.label1.Text = "Hyper Sawndz is not dead. - Lava";
			// 
			// AboutForm
			// 
			this.AcceptButton = this.buttonClose;
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.CancelButton = this.buttonClose;
			this.ClientSize = new System.Drawing.Size(627, 443);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.buttonClose);
			this.Controls.Add(this.treeView1);
			this.Controls.Add(this.labelSuperSawndz);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "AboutForm";
			this.Text = "About";
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label labelSuperSawndz;
		private System.Windows.Forms.TreeView treeView1;
		private System.Windows.Forms.Button buttonClose;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.ToolTip toolTip1;
	}
}