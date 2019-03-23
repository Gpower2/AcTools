namespace AcTools.Forms
{
    partial class frmPatcher
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
            this.btnHook = new System.Windows.Forms.Button();
            this.txtOldFile = new System.Windows.Forms.TextBox();
            this.txtNewFile = new System.Windows.Forms.TextBox();
            this.btnBrowseOldFile = new System.Windows.Forms.Button();
            this.btnBrowseNewFile = new System.Windows.Forms.Button();
            this.txtDiffFile = new System.Windows.Forms.TextBox();
            this.btnBrowsePatchFile = new System.Windows.Forms.Button();
            this.listPatches = new System.Windows.Forms.ListBox();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnRemove = new System.Windows.Forms.Button();
            this.btnMakePatches = new System.Windows.Forms.Button();
            this.lblOldFile = new System.Windows.Forms.Label();
            this.lblNewFile = new System.Windows.Forms.Label();
            this.lblDiffFile = new System.Windows.Forms.Label();
            this.lblListPatches = new System.Windows.Forms.Label();
            this.checkHideConsole = new System.Windows.Forms.CheckBox();
            this.chkCopyXdelta = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // btnHook
            // 
            this.btnHook.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnHook.Location = new System.Drawing.Point(581, 360);
            this.btnHook.Name = "btnHook";
            this.btnHook.Size = new System.Drawing.Size(82, 29);
            this.btnHook.TabIndex = 0;
            this.btnHook.Text = "UnHook";
            this.btnHook.UseVisualStyleBackColor = true;
            this.btnHook.Click += new System.EventHandler(this.btnHook_Click);
            // 
            // txtOldFile
            // 
            this.txtOldFile.AllowDrop = true;
            this.txtOldFile.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtOldFile.Location = new System.Drawing.Point(10, 25);
            this.txtOldFile.Name = "txtOldFile";
            this.txtOldFile.Size = new System.Drawing.Size(548, 23);
            this.txtOldFile.TabIndex = 1;
            this.txtOldFile.TextChanged += new System.EventHandler(this.txt_TextChanged);
            this.txtOldFile.DragDrop += new System.Windows.Forms.DragEventHandler(this.txtBox_DragDrop);
            this.txtOldFile.DragEnter += new System.Windows.Forms.DragEventHandler(this.txtBox_DragEnter);
            // 
            // txtNewFile
            // 
            this.txtNewFile.AllowDrop = true;
            this.txtNewFile.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtNewFile.Location = new System.Drawing.Point(10, 80);
            this.txtNewFile.Name = "txtNewFile";
            this.txtNewFile.Size = new System.Drawing.Size(548, 23);
            this.txtNewFile.TabIndex = 2;
            this.txtNewFile.TextChanged += new System.EventHandler(this.txt_TextChanged);
            this.txtNewFile.DragDrop += new System.Windows.Forms.DragEventHandler(this.txtBox_DragDrop);
            this.txtNewFile.DragEnter += new System.Windows.Forms.DragEventHandler(this.txtBox_DragEnter);
            // 
            // btnBrowseOldFile
            // 
            this.btnBrowseOldFile.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnBrowseOldFile.Location = new System.Drawing.Point(567, 22);
            this.btnBrowseOldFile.Name = "btnBrowseOldFile";
            this.btnBrowseOldFile.Size = new System.Drawing.Size(96, 32);
            this.btnBrowseOldFile.TabIndex = 3;
            this.btnBrowseOldFile.Text = "Browse...";
            this.btnBrowseOldFile.UseVisualStyleBackColor = true;
            this.btnBrowseOldFile.Click += new System.EventHandler(this.btnBrowseOldFile_Click);
            // 
            // btnBrowseNewFile
            // 
            this.btnBrowseNewFile.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnBrowseNewFile.Location = new System.Drawing.Point(567, 75);
            this.btnBrowseNewFile.Name = "btnBrowseNewFile";
            this.btnBrowseNewFile.Size = new System.Drawing.Size(96, 32);
            this.btnBrowseNewFile.TabIndex = 4;
            this.btnBrowseNewFile.Text = "Browse...";
            this.btnBrowseNewFile.UseVisualStyleBackColor = true;
            this.btnBrowseNewFile.Click += new System.EventHandler(this.btnBrowseNewFile_Click);
            // 
            // txtDiffFile
            // 
            this.txtDiffFile.AllowDrop = true;
            this.txtDiffFile.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDiffFile.Location = new System.Drawing.Point(10, 133);
            this.txtDiffFile.Name = "txtDiffFile";
            this.txtDiffFile.Size = new System.Drawing.Size(548, 23);
            this.txtDiffFile.TabIndex = 5;
            this.txtDiffFile.DragDrop += new System.Windows.Forms.DragEventHandler(this.txtBox_DragDrop);
            this.txtDiffFile.DragEnter += new System.Windows.Forms.DragEventHandler(this.txtBox_DragEnter);
            // 
            // btnBrowsePatchFile
            // 
            this.btnBrowsePatchFile.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnBrowsePatchFile.Location = new System.Drawing.Point(567, 127);
            this.btnBrowsePatchFile.Name = "btnBrowsePatchFile";
            this.btnBrowsePatchFile.Size = new System.Drawing.Size(96, 32);
            this.btnBrowsePatchFile.TabIndex = 6;
            this.btnBrowsePatchFile.Text = "Browse...";
            this.btnBrowsePatchFile.UseVisualStyleBackColor = true;
            this.btnBrowsePatchFile.Click += new System.EventHandler(this.btnBrowsePatchFile_Click);
            // 
            // listPatches
            // 
            this.listPatches.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listPatches.FormattingEnabled = true;
            this.listPatches.HorizontalScrollbar = true;
            this.listPatches.ItemHeight = 15;
            this.listPatches.Location = new System.Drawing.Point(10, 180);
            this.listPatches.Name = "listPatches";
            this.listPatches.Size = new System.Drawing.Size(548, 169);
            this.listPatches.TabIndex = 7;
            this.listPatches.SelectedIndexChanged += new System.EventHandler(this.listPatches_SelectedIndexChanged);
            // 
            // btnAdd
            // 
            this.btnAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAdd.Location = new System.Drawing.Point(567, 179);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(96, 35);
            this.btnAdd.TabIndex = 8;
            this.btnAdd.Text = "Add";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnRemove
            // 
            this.btnRemove.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRemove.Location = new System.Drawing.Point(567, 219);
            this.btnRemove.Name = "btnRemove";
            this.btnRemove.Size = new System.Drawing.Size(96, 36);
            this.btnRemove.TabIndex = 9;
            this.btnRemove.Text = "Remove";
            this.btnRemove.UseVisualStyleBackColor = true;
            this.btnRemove.Click += new System.EventHandler(this.btnRemove_Click);
            // 
            // btnMakePatches
            // 
            this.btnMakePatches.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnMakePatches.Location = new System.Drawing.Point(567, 316);
            this.btnMakePatches.Name = "btnMakePatches";
            this.btnMakePatches.Size = new System.Drawing.Size(96, 35);
            this.btnMakePatches.TabIndex = 10;
            this.btnMakePatches.Text = "Make Patches!";
            this.btnMakePatches.UseVisualStyleBackColor = true;
            this.btnMakePatches.Click += new System.EventHandler(this.btnMakePatches_Click);
            // 
            // lblOldFile
            // 
            this.lblOldFile.AutoSize = true;
            this.lblOldFile.Location = new System.Drawing.Point(13, 7);
            this.lblOldFile.Name = "lblOldFile";
            this.lblOldFile.Size = new System.Drawing.Size(47, 15);
            this.lblOldFile.TabIndex = 11;
            this.lblOldFile.Text = "Old File";
            // 
            // lblNewFile
            // 
            this.lblNewFile.AutoSize = true;
            this.lblNewFile.Location = new System.Drawing.Point(13, 62);
            this.lblNewFile.Name = "lblNewFile";
            this.lblNewFile.Size = new System.Drawing.Size(52, 15);
            this.lblNewFile.TabIndex = 12;
            this.lblNewFile.Text = "New File";
            // 
            // lblDiffFile
            // 
            this.lblDiffFile.AutoSize = true;
            this.lblDiffFile.Location = new System.Drawing.Point(13, 114);
            this.lblDiffFile.Name = "lblDiffFile";
            this.lblDiffFile.Size = new System.Drawing.Size(47, 15);
            this.lblDiffFile.TabIndex = 13;
            this.lblDiffFile.Text = "Diff File";
            // 
            // lblListPatches
            // 
            this.lblListPatches.AutoSize = true;
            this.lblListPatches.Location = new System.Drawing.Point(14, 164);
            this.lblListPatches.Name = "lblListPatches";
            this.lblListPatches.Size = new System.Drawing.Size(69, 15);
            this.lblListPatches.TabIndex = 14;
            this.lblListPatches.Text = "Patches List";
            // 
            // checkHideConsole
            // 
            this.checkHideConsole.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.checkHideConsole.Location = new System.Drawing.Point(567, 264);
            this.checkHideConsole.Name = "checkHideConsole";
            this.checkHideConsole.Size = new System.Drawing.Size(103, 20);
            this.checkHideConsole.TabIndex = 15;
            this.checkHideConsole.Text = "Hide Console";
            this.checkHideConsole.UseVisualStyleBackColor = true;
            // 
            // chkCopyXdelta
            // 
            this.chkCopyXdelta.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.chkCopyXdelta.Location = new System.Drawing.Point(567, 288);
            this.chkCopyXdelta.Name = "chkCopyXdelta";
            this.chkCopyXdelta.Size = new System.Drawing.Size(99, 20);
            this.chkCopyXdelta.TabIndex = 16;
            this.chkCopyXdelta.Text = "Copy xDelta";
            this.chkCopyXdelta.UseVisualStyleBackColor = true;
            // 
            // PatcherForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(672, 396);
            this.Controls.Add(this.chkCopyXdelta);
            this.Controls.Add(this.checkHideConsole);
            this.Controls.Add(this.lblListPatches);
            this.Controls.Add(this.lblDiffFile);
            this.Controls.Add(this.lblNewFile);
            this.Controls.Add(this.lblOldFile);
            this.Controls.Add(this.btnMakePatches);
            this.Controls.Add(this.btnRemove);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.listPatches);
            this.Controls.Add(this.btnBrowsePatchFile);
            this.Controls.Add(this.txtDiffFile);
            this.Controls.Add(this.btnBrowseNewFile);
            this.Controls.Add(this.btnBrowseOldFile);
            this.Controls.Add(this.txtNewFile);
            this.Controls.Add(this.txtOldFile);
            this.Controls.Add(this.btnHook);
            this.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.MinimumSize = new System.Drawing.Size(688, 435);
            this.Name = "PatcherForm";
            this.Text = "PatcherForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnHook;
        private System.Windows.Forms.TextBox txtOldFile;
        private System.Windows.Forms.TextBox txtNewFile;
        private System.Windows.Forms.Button btnBrowseOldFile;
        private System.Windows.Forms.Button btnBrowseNewFile;
        private System.Windows.Forms.TextBox txtDiffFile;
        private System.Windows.Forms.Button btnBrowsePatchFile;
        private System.Windows.Forms.ListBox listPatches;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnRemove;
        private System.Windows.Forms.Button btnMakePatches;
        private System.Windows.Forms.Label lblOldFile;
        private System.Windows.Forms.Label lblNewFile;
        private System.Windows.Forms.Label lblDiffFile;
        private System.Windows.Forms.Label lblListPatches;
        private System.Windows.Forms.CheckBox checkHideConsole;
        private System.Windows.Forms.CheckBox chkCopyXdelta;
    }
}