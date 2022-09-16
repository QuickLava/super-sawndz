
namespace BrawlSoundConverter
{
	partial class RearrangeTabsForm
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
			this.treeView1 = new System.Windows.Forms.TreeView();
			this.buttonMoveUp = new System.Windows.Forms.Button();
			this.buttonMoveDown = new System.Windows.Forms.Button();
			this.label1 = new System.Windows.Forms.Label();
			this.buttonSave = new System.Windows.Forms.Button();
			this.buttonCancel = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// treeView1
			// 
			this.treeView1.HideSelection = false;
			this.treeView1.Location = new System.Drawing.Point(12, 27);
			this.treeView1.Name = "treeView1";
			this.treeView1.ShowLines = false;
			this.treeView1.ShowPlusMinus = false;
			this.treeView1.ShowRootLines = false;
			this.treeView1.Size = new System.Drawing.Size(296, 244);
			this.treeView1.TabIndex = 0;
			// 
			// buttonMoveUp
			// 
			this.buttonMoveUp.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.buttonMoveUp.Location = new System.Drawing.Point(314, 27);
			this.buttonMoveUp.Name = "buttonMoveUp";
			this.buttonMoveUp.Size = new System.Drawing.Size(32, 32);
			this.buttonMoveUp.TabIndex = 1;
			this.buttonMoveUp.Text = "↑";
			this.buttonMoveUp.UseVisualStyleBackColor = true;
			this.buttonMoveUp.Click += new System.EventHandler(this.buttonMoveUp_Click);
			// 
			// buttonMoveDown
			// 
			this.buttonMoveDown.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.buttonMoveDown.Location = new System.Drawing.Point(314, 65);
			this.buttonMoveDown.Name = "buttonMoveDown";
			this.buttonMoveDown.Size = new System.Drawing.Size(32, 32);
			this.buttonMoveDown.TabIndex = 2;
			this.buttonMoveDown.Text = "↓";
			this.buttonMoveDown.UseVisualStyleBackColor = true;
			this.buttonMoveDown.Click += new System.EventHandler(this.buttonMoveDown_Click);
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(12, 7);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(74, 17);
			this.label1.TabIndex = 3;
			this.label1.Text = "Tab Order";
			// 
			// buttonSave
			// 
			this.buttonSave.Location = new System.Drawing.Point(191, 275);
			this.buttonSave.Name = "buttonSave";
			this.buttonSave.Size = new System.Drawing.Size(75, 28);
			this.buttonSave.TabIndex = 4;
			this.buttonSave.Text = "Save";
			this.buttonSave.UseVisualStyleBackColor = true;
			this.buttonSave.Click += new System.EventHandler(this.buttonSave_Click);
			// 
			// buttonCancel
			// 
			this.buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.buttonCancel.Location = new System.Drawing.Point(271, 275);
			this.buttonCancel.Name = "buttonCancel";
			this.buttonCancel.Size = new System.Drawing.Size(75, 28);
			this.buttonCancel.TabIndex = 5;
			this.buttonCancel.Text = "Cancel";
			this.buttonCancel.UseVisualStyleBackColor = true;
			this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
			// 
			// RearrangeTabsForm
			// 
			this.AcceptButton = this.buttonSave;
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.CancelButton = this.buttonCancel;
			this.ClientSize = new System.Drawing.Size(354, 307);
			this.Controls.Add(this.buttonCancel);
			this.Controls.Add(this.buttonSave);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.buttonMoveDown);
			this.Controls.Add(this.buttonMoveUp);
			this.Controls.Add(this.treeView1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "RearrangeTabsForm";
			this.Text = "Rearrange Tabs";
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.TreeView treeView1;
		private System.Windows.Forms.Button buttonMoveUp;
		private System.Windows.Forms.Button buttonMoveDown;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Button buttonSave;
		private System.Windows.Forms.Button buttonCancel;
	}
}