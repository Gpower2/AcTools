namespace AcTools.Forms
{
    partial class frmChapterFromSections
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
            this.txtSectionsFile = new System.Windows.Forms.TextBox();
            this.txtChaptersFile = new System.Windows.Forms.TextBox();
            this.btnBrowseSectionsFile = new System.Windows.Forms.Button();
            this.btnBrowseChaptersFile = new System.Windows.Forms.Button();
            this.checkUseChaptersFile = new System.Windows.Forms.CheckBox();
            this.checkIsTrimFile = new System.Windows.Forms.CheckBox();
            this.btnOK = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.lblSectionsFile = new System.Windows.Forms.Label();
            this.lblChaptersFile = new System.Windows.Forms.Label();
            this.comboFramerate = new System.Windows.Forms.ComboBox();
            this.lblFramerate = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // txtSectionsFile
            // 
            this.txtSectionsFile.AllowDrop = true;
            this.txtSectionsFile.Location = new System.Drawing.Point(12, 29);
            this.txtSectionsFile.Name = "txtSectionsFile";
            this.txtSectionsFile.Size = new System.Drawing.Size(403, 23);
            this.txtSectionsFile.TabIndex = 0;
            this.txtSectionsFile.DragDrop += new System.Windows.Forms.DragEventHandler(this.txtBox_DragDrop);
            this.txtSectionsFile.DragEnter += new System.Windows.Forms.DragEventHandler(this.txtBox_DragEnter);
            // 
            // txtChaptersFile
            // 
            this.txtChaptersFile.AllowDrop = true;
            this.txtChaptersFile.Location = new System.Drawing.Point(12, 115);
            this.txtChaptersFile.Name = "txtChaptersFile";
            this.txtChaptersFile.Size = new System.Drawing.Size(403, 23);
            this.txtChaptersFile.TabIndex = 1;
            this.txtChaptersFile.DragDrop += new System.Windows.Forms.DragEventHandler(this.txtBox_DragDrop);
            this.txtChaptersFile.DragEnter += new System.Windows.Forms.DragEventHandler(this.txtBox_DragEnter);
            // 
            // btnBrowseSectionsFile
            // 
            this.btnBrowseSectionsFile.Location = new System.Drawing.Point(422, 23);
            this.btnBrowseSectionsFile.Name = "btnBrowseSectionsFile";
            this.btnBrowseSectionsFile.Size = new System.Drawing.Size(76, 35);
            this.btnBrowseSectionsFile.TabIndex = 2;
            this.btnBrowseSectionsFile.Text = "Browse...";
            this.btnBrowseSectionsFile.UseVisualStyleBackColor = true;
            this.btnBrowseSectionsFile.Click += new System.EventHandler(this.btnBrowseSectionsFile_Click);
            // 
            // btnBrowseChaptersFile
            // 
            this.btnBrowseChaptersFile.Location = new System.Drawing.Point(422, 110);
            this.btnBrowseChaptersFile.Name = "btnBrowseChaptersFile";
            this.btnBrowseChaptersFile.Size = new System.Drawing.Size(76, 35);
            this.btnBrowseChaptersFile.TabIndex = 3;
            this.btnBrowseChaptersFile.Text = "Browse...";
            this.btnBrowseChaptersFile.UseVisualStyleBackColor = true;
            this.btnBrowseChaptersFile.Click += new System.EventHandler(this.btnBrowseChaptersFile_Click);
            // 
            // checkUseChaptersFile
            // 
            this.checkUseChaptersFile.AutoSize = true;
            this.checkUseChaptersFile.Location = new System.Drawing.Point(15, 67);
            this.checkUseChaptersFile.Name = "checkUseChaptersFile";
            this.checkUseChaptersFile.Size = new System.Drawing.Size(116, 19);
            this.checkUseChaptersFile.TabIndex = 4;
            this.checkUseChaptersFile.Text = "Use Chapters File";
            this.checkUseChaptersFile.UseVisualStyleBackColor = true;
            this.checkUseChaptersFile.CheckedChanged += new System.EventHandler(this.checkUseChaptersFile_CheckedChanged);
            // 
            // checkIsTrimFile
            // 
            this.checkIsTrimFile.AutoSize = true;
            this.checkIsTrimFile.Location = new System.Drawing.Point(15, 166);
            this.checkIsTrimFile.Name = "checkIsTrimFile";
            this.checkIsTrimFile.Size = new System.Drawing.Size(173, 19);
            this.checkIsTrimFile.TabIndex = 5;
            this.checkIsTrimFile.Text = "Sections File trims the video";
            this.checkIsTrimFile.UseVisualStyleBackColor = true;
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(120, 209);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(87, 36);
            this.btnOK.TabIndex = 6;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(294, 209);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(87, 36);
            this.btnCancel.TabIndex = 7;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // lblSectionsFile
            // 
            this.lblSectionsFile.AutoSize = true;
            this.lblSectionsFile.Location = new System.Drawing.Point(15, 10);
            this.lblSectionsFile.Name = "lblSectionsFile";
            this.lblSectionsFile.Size = new System.Drawing.Size(72, 15);
            this.lblSectionsFile.TabIndex = 8;
            this.lblSectionsFile.Text = "Sections File";
            // 
            // lblChaptersFile
            // 
            this.lblChaptersFile.AutoSize = true;
            this.lblChaptersFile.Location = new System.Drawing.Point(15, 97);
            this.lblChaptersFile.Name = "lblChaptersFile";
            this.lblChaptersFile.Size = new System.Drawing.Size(75, 15);
            this.lblChaptersFile.TabIndex = 9;
            this.lblChaptersFile.Text = "Chapters File";
            // 
            // comboFramerate
            // 
            this.comboFramerate.FormattingEnabled = true;
            this.comboFramerate.Location = new System.Drawing.Point(330, 163);
            this.comboFramerate.Name = "comboFramerate";
            this.comboFramerate.Size = new System.Drawing.Size(151, 23);
            this.comboFramerate.TabIndex = 10;
            // 
            // lblFramerate
            // 
            this.lblFramerate.AutoSize = true;
            this.lblFramerate.Location = new System.Drawing.Point(265, 166);
            this.lblFramerate.Name = "lblFramerate";
            this.lblFramerate.Size = new System.Drawing.Size(60, 15);
            this.lblFramerate.TabIndex = 11;
            this.lblFramerate.Text = "Framerate";
            // 
            // ChapterFromSectionsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(504, 251);
            this.Controls.Add(this.lblFramerate);
            this.Controls.Add(this.comboFramerate);
            this.Controls.Add(this.lblChaptersFile);
            this.Controls.Add(this.lblSectionsFile);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.checkIsTrimFile);
            this.Controls.Add(this.checkUseChaptersFile);
            this.Controls.Add(this.btnBrowseChaptersFile);
            this.Controls.Add(this.btnBrowseSectionsFile);
            this.Controls.Add(this.txtChaptersFile);
            this.Controls.Add(this.txtSectionsFile);
            this.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(520, 290);
            this.MinimumSize = new System.Drawing.Size(520, 290);
            this.Name = "ChapterFromSectionsForm";
            this.Text = "ChapterFromSectionsForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtSectionsFile;
        private System.Windows.Forms.TextBox txtChaptersFile;
        private System.Windows.Forms.Button btnBrowseSectionsFile;
        private System.Windows.Forms.Button btnBrowseChaptersFile;
        private System.Windows.Forms.CheckBox checkUseChaptersFile;
        private System.Windows.Forms.CheckBox checkIsTrimFile;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Label lblSectionsFile;
        private System.Windows.Forms.Label lblChaptersFile;
        private System.Windows.Forms.ComboBox comboFramerate;
        private System.Windows.Forms.Label lblFramerate;
    }
}