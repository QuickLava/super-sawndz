
namespace BrawlSoundConverter
{
	partial class ManageTabsForm
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
			this.buttonMergeUp = new System.Windows.Forms.Button();
			this.buttonMergeDown = new System.Windows.Forms.Button();
			this.buttonDeleteTab = new System.Windows.Forms.Button();
			this.buttonRenameTab = new System.Windows.Forms.Button();
			this.buttonDeleteAll = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// treeView1
			// 
			this.treeView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.treeView1.HideSelection = false;
			this.treeView1.Location = new System.Drawing.Point(12, 25);
			this.treeView1.Name = "treeView1";
			this.treeView1.Size = new System.Drawing.Size(318, 388);
			this.treeView1.TabIndex = 0;
			this.treeView1.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeView1_AfterSelect);
			// 
			// buttonMoveUp
			// 
			this.buttonMoveUp.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.buttonMoveUp.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.buttonMoveUp.Location = new System.Drawing.Point(338, 25);
			this.buttonMoveUp.Name = "buttonMoveUp";
			this.buttonMoveUp.Size = new System.Drawing.Size(100, 28);
			this.buttonMoveUp.TabIndex = 1;
			this.buttonMoveUp.Text = "Move Up";
			this.buttonMoveUp.UseVisualStyleBackColor = true;
			this.buttonMoveUp.Click += new System.EventHandler(this.buttonMoveUp_Click);
			// 
			// buttonMoveDown
			// 
			this.buttonMoveDown.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.buttonMoveDown.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.buttonMoveDown.Location = new System.Drawing.Point(338, 63);
			this.buttonMoveDown.Name = "buttonMoveDown";
			this.buttonMoveDown.Size = new System.Drawing.Size(100, 28);
			this.buttonMoveDown.TabIndex = 2;
			this.buttonMoveDown.Text = "Move Down";
			this.buttonMoveDown.UseVisualStyleBackColor = true;
			this.buttonMoveDown.Click += new System.EventHandler(this.buttonMoveDown_Click);
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(12, 7);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(139, 17);
			this.label1.TabIndex = 3;
			this.label1.Text = "Configuration Layout";
			// 
			// buttonSave
			// 
			this.buttonSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.buttonSave.Location = new System.Drawing.Point(230, 419);
			this.buttonSave.Name = "buttonSave";
			this.buttonSave.Size = new System.Drawing.Size(100, 28);
			this.buttonSave.TabIndex = 4;
			this.buttonSave.Text = "Save";
			this.buttonSave.UseVisualStyleBackColor = true;
			this.buttonSave.Click += new System.EventHandler(this.buttonSave_Click);
			// 
			// buttonCancel
			// 
			this.buttonCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.buttonCancel.Location = new System.Drawing.Point(338, 419);
			this.buttonCancel.Name = "buttonCancel";
			this.buttonCancel.Size = new System.Drawing.Size(100, 28);
			this.buttonCancel.TabIndex = 5;
			this.buttonCancel.Text = "Cancel";
			this.buttonCancel.UseVisualStyleBackColor = true;
			this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
			// 
			// buttonMergeUp
			// 
			this.buttonMergeUp.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.buttonMergeUp.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.buttonMergeUp.Location = new System.Drawing.Point(338, 97);
			this.buttonMergeUp.Name = "buttonMergeUp";
			this.buttonMergeUp.Size = new System.Drawing.Size(100, 28);
			this.buttonMergeUp.TabIndex = 6;
			this.buttonMergeUp.Text = "Merge Up";
			this.buttonMergeUp.UseVisualStyleBackColor = true;
			this.buttonMergeUp.Click += new System.EventHandler(this.buttonMergeUp_Click);
			// 
			// buttonMergeDown
			// 
			this.buttonMergeDown.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.buttonMergeDown.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.buttonMergeDown.Location = new System.Drawing.Point(338, 131);
			this.buttonMergeDown.Name = "buttonMergeDown";
			this.buttonMergeDown.Size = new System.Drawing.Size(100, 28);
			this.buttonMergeDown.TabIndex = 7;
			this.buttonMergeDown.Text = "Merge Down";
			this.buttonMergeDown.UseVisualStyleBackColor = true;
			this.buttonMergeDown.Click += new System.EventHandler(this.buttonMergeDown_Click);
			// 
			// buttonDeleteTab
			// 
			this.buttonDeleteTab.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.buttonDeleteTab.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.buttonDeleteTab.Location = new System.Drawing.Point(338, 165);
			this.buttonDeleteTab.Name = "buttonDeleteTab";
			this.buttonDeleteTab.Size = new System.Drawing.Size(100, 28);
			this.buttonDeleteTab.TabIndex = 8;
			this.buttonDeleteTab.Text = "Close Tab";
			this.buttonDeleteTab.UseVisualStyleBackColor = true;
			this.buttonDeleteTab.Click += new System.EventHandler(this.buttonDeleteTab_Click);
			// 
			// buttonRenameTab
			// 
			this.buttonRenameTab.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.buttonRenameTab.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.buttonRenameTab.Location = new System.Drawing.Point(338, 233);
			this.buttonRenameTab.Name = "buttonRenameTab";
			this.buttonRenameTab.Size = new System.Drawing.Size(100, 28);
			this.buttonRenameTab.TabIndex = 9;
			this.buttonRenameTab.Text = "Rename Tab";
			this.buttonRenameTab.UseVisualStyleBackColor = true;
			this.buttonRenameTab.Click += new System.EventHandler(this.buttonRenameTab_Click);
			// 
			// buttonDeleteAll
			// 
			this.buttonDeleteAll.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.buttonDeleteAll.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F);
			this.buttonDeleteAll.Location = new System.Drawing.Point(338, 199);
			this.buttonDeleteAll.Name = "buttonDeleteAll";
			this.buttonDeleteAll.Size = new System.Drawing.Size(100, 28);
			this.buttonDeleteAll.TabIndex = 10;
			this.buttonDeleteAll.Text = "Close All";
			this.buttonDeleteAll.UseVisualStyleBackColor = true;
			this.buttonDeleteAll.Click += new System.EventHandler(this.buttonDeleteAll_Click);
			// 
			// ManageTabsForm
			// 
			this.AcceptButton = this.buttonSave;
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.CancelButton = this.buttonCancel;
			this.ClientSize = new System.Drawing.Size(446, 453);
			this.Controls.Add(this.buttonDeleteAll);
			this.Controls.Add(this.buttonRenameTab);
			this.Controls.Add(this.buttonDeleteTab);
			this.Controls.Add(this.buttonMergeDown);
			this.Controls.Add(this.buttonMergeUp);
			this.Controls.Add(this.buttonCancel);
			this.Controls.Add(this.buttonSave);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.buttonMoveDown);
			this.Controls.Add(this.buttonMoveUp);
			this.Controls.Add(this.treeView1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "ManageTabsForm";
			this.Text = "Manage Tabs";
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
		private System.Windows.Forms.Button buttonMergeUp;
		private System.Windows.Forms.Button buttonMergeDown;
		private System.Windows.Forms.Button buttonDeleteTab;
		private System.Windows.Forms.Button buttonRenameTab;
		private System.Windows.Forms.Button buttonDeleteAll;
	}
}