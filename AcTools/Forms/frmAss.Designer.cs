namespace AcTools.Forms
{
    partial class frmAss
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
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.lblStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.progressBar = new System.Windows.Forms.ToolStripProgressBar();
            this.btnTranslate = new System.Windows.Forms.Button();
            this.txtFramerate = new System.Windows.Forms.TextBox();
            this.lblSectionsFile = new System.Windows.Forms.Label();
            this.lblAssFile = new System.Windows.Forms.Label();
            this.btnSplit = new System.Windows.Forms.Button();
            this.btnBrowseSections = new System.Windows.Forms.Button();
            this.txtSectionsFile = new System.Windows.Forms.TextBox();
            this.btnBrowseAss = new System.Windows.Forms.Button();
            this.txtAssFile = new System.Windows.Forms.TextBox();
            this.btnUrlDecode = new System.Windows.Forms.Button();
            this.btnTestCharset = new System.Windows.Forms.Button();
            this.lstAss = new System.Windows.Forms.ListBox();
            this.lstAss2 = new System.Windows.Forms.ListBox();
            this.btnFixAss = new System.Windows.Forms.Button();
            this.btnChangeAssTiming = new System.Windows.Forms.Button();
            this.btnFixAss2 = new System.Windows.Forms.Button();
            this.btnParseSrt = new System.Windows.Forms.Button();
            this.statusStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // statusStrip
            // 
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lblStatus,
            this.progressBar});
            this.statusStrip.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.Flow;
            this.statusStrip.Location = new System.Drawing.Point(0, 417);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Size = new System.Drawing.Size(739, 22);
            this.statusStrip.TabIndex = 10;
            this.statusStrip.Text = "statusStrip1";
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = false;
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(300, 17);
            this.lblStatus.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // progressBar
            // 
            this.progressBar.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(360, 16);
            this.progressBar.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            // 
            // btnTranslate
            // 
            this.btnTranslate.Location = new System.Drawing.Point(81, 124);
            this.btnTranslate.Name = "btnTranslate";
            this.btnTranslate.Size = new System.Drawing.Size(64, 47);
            this.btnTranslate.TabIndex = 8;
            this.btnTranslate.Text = "Translate";
            this.btnTranslate.UseVisualStyleBackColor = true;
            this.btnTranslate.Click += new System.EventHandler(this.btnTranslate_Click);
            // 
            // txtFramerate
            // 
            this.txtFramerate.Location = new System.Drawing.Point(164, 92);
            this.txtFramerate.Name = "txtFramerate";
            this.txtFramerate.Size = new System.Drawing.Size(178, 20);
            this.txtFramerate.TabIndex = 7;
            // 
            // lblSectionsFile
            // 
            this.lblSectionsFile.AutoSize = true;
            this.lblSectionsFile.Location = new System.Drawing.Point(8, 61);
            this.lblSectionsFile.Name = "lblSectionsFile";
            this.lblSectionsFile.Size = new System.Drawing.Size(67, 13);
            this.lblSectionsFile.TabIndex = 6;
            this.lblSectionsFile.Text = "Sections File";
            // 
            // lblAssFile
            // 
            this.lblAssFile.AutoSize = true;
            this.lblAssFile.Location = new System.Drawing.Point(18, 28);
            this.lblAssFile.Name = "lblAssFile";
            this.lblAssFile.Size = new System.Drawing.Size(43, 13);
            this.lblAssFile.TabIndex = 5;
            this.lblAssFile.Text = "Ass File";
            // 
            // btnSplit
            // 
            this.btnSplit.Location = new System.Drawing.Point(11, 123);
            this.btnSplit.Name = "btnSplit";
            this.btnSplit.Size = new System.Drawing.Size(64, 47);
            this.btnSplit.TabIndex = 4;
            this.btnSplit.Text = "Split";
            this.btnSplit.UseVisualStyleBackColor = true;
            this.btnSplit.Click += new System.EventHandler(this.btnSplit_Click);
            // 
            // btnBrowseSections
            // 
            this.btnBrowseSections.Location = new System.Drawing.Point(562, 53);
            this.btnBrowseSections.Name = "btnBrowseSections";
            this.btnBrowseSections.Size = new System.Drawing.Size(71, 27);
            this.btnBrowseSections.TabIndex = 3;
            this.btnBrowseSections.Text = "Browse...";
            this.btnBrowseSections.UseVisualStyleBackColor = true;
            // 
            // txtSectionsFile
            // 
            this.txtSectionsFile.AllowDrop = true;
            this.txtSectionsFile.Location = new System.Drawing.Point(93, 57);
            this.txtSectionsFile.Name = "txtSectionsFile";
            this.txtSectionsFile.Size = new System.Drawing.Size(463, 20);
            this.txtSectionsFile.TabIndex = 2;
            this.txtSectionsFile.DragDrop += new System.Windows.Forms.DragEventHandler(this.txtSectionsFile_DragDrop);
            this.txtSectionsFile.DragEnter += new System.Windows.Forms.DragEventHandler(this.txtSectionsFile_DragEnter);
            // 
            // btnBrowseAss
            // 
            this.btnBrowseAss.Location = new System.Drawing.Point(562, 20);
            this.btnBrowseAss.Name = "btnBrowseAss";
            this.btnBrowseAss.Size = new System.Drawing.Size(71, 27);
            this.btnBrowseAss.TabIndex = 1;
            this.btnBrowseAss.Text = "Browse...";
            this.btnBrowseAss.UseVisualStyleBackColor = true;
            // 
            // txtAssFile
            // 
            this.txtAssFile.AllowDrop = true;
            this.txtAssFile.Location = new System.Drawing.Point(93, 24);
            this.txtAssFile.Name = "txtAssFile";
            this.txtAssFile.Size = new System.Drawing.Size(462, 20);
            this.txtAssFile.TabIndex = 0;
            this.txtAssFile.DragDrop += new System.Windows.Forms.DragEventHandler(this.txtAssFile_DragDrop);
            this.txtAssFile.DragEnter += new System.Windows.Forms.DragEventHandler(this.txtAssFile_DragEnter);
            // 
            // btnUrlDecode
            // 
            this.btnUrlDecode.Location = new System.Drawing.Point(151, 125);
            this.btnUrlDecode.Name = "btnUrlDecode";
            this.btnUrlDecode.Size = new System.Drawing.Size(64, 47);
            this.btnUrlDecode.TabIndex = 11;
            this.btnUrlDecode.Text = "Url/HTML Decode";
            this.btnUrlDecode.UseVisualStyleBackColor = true;
            this.btnUrlDecode.Click += new System.EventHandler(this.btnUrlDecode_Click);
            // 
            // btnTestCharset
            // 
            this.btnTestCharset.Location = new System.Drawing.Point(221, 125);
            this.btnTestCharset.Name = "btnTestCharset";
            this.btnTestCharset.Size = new System.Drawing.Size(64, 47);
            this.btnTestCharset.TabIndex = 12;
            this.btnTestCharset.Text = "Test Charset";
            this.btnTestCharset.UseVisualStyleBackColor = true;
            this.btnTestCharset.Click += new System.EventHandler(this.btnTestCharset_Click);
            // 
            // lstAss
            // 
            this.lstAss.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lstAss.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.lstAss.FormattingEnabled = true;
            this.lstAss.ItemHeight = 14;
            this.lstAss.Location = new System.Drawing.Point(35, 194);
            this.lstAss.Name = "lstAss";
            this.lstAss.Size = new System.Drawing.Size(317, 200);
            this.lstAss.TabIndex = 13;
            // 
            // lstAss2
            // 
            this.lstAss2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lstAss2.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.lstAss2.FormattingEnabled = true;
            this.lstAss2.ItemHeight = 14;
            this.lstAss2.Location = new System.Drawing.Point(388, 194);
            this.lstAss2.Name = "lstAss2";
            this.lstAss2.Size = new System.Drawing.Size(317, 200);
            this.lstAss2.TabIndex = 14;
            // 
            // btnFixAss
            // 
            this.btnFixAss.Location = new System.Drawing.Point(291, 127);
            this.btnFixAss.Name = "btnFixAss";
            this.btnFixAss.Size = new System.Drawing.Size(67, 44);
            this.btnFixAss.TabIndex = 15;
            this.btnFixAss.Text = "Fix Ass";
            this.btnFixAss.UseVisualStyleBackColor = true;
            this.btnFixAss.Click += new System.EventHandler(this.btnFixAss_Click);
            // 
            // btnChangeAssTiming
            // 
            this.btnChangeAssTiming.Location = new System.Drawing.Point(621, 125);
            this.btnChangeAssTiming.Name = "btnChangeAssTiming";
            this.btnChangeAssTiming.Size = new System.Drawing.Size(106, 44);
            this.btnChangeAssTiming.TabIndex = 16;
            this.btnChangeAssTiming.Text = "Change Timings";
            this.btnChangeAssTiming.UseVisualStyleBackColor = true;
            this.btnChangeAssTiming.Click += new System.EventHandler(this.btnChangeAssTiming_Click);
            // 
            // btnFixAss2
            // 
            this.btnFixAss2.Location = new System.Drawing.Point(364, 128);
            this.btnFixAss2.Name = "btnFixAss2";
            this.btnFixAss2.Size = new System.Drawing.Size(67, 44);
            this.btnFixAss2.TabIndex = 17;
            this.btnFixAss2.Text = "Fix Ass 2";
            this.btnFixAss2.UseVisualStyleBackColor = true;
            this.btnFixAss2.Click += new System.EventHandler(this.btnFixAss2_Click);
            // 
            // btnParseSrt
            // 
            this.btnParseSrt.Location = new System.Drawing.Point(437, 128);
            this.btnParseSrt.Name = "btnParseSrt";
            this.btnParseSrt.Size = new System.Drawing.Size(67, 44);
            this.btnParseSrt.TabIndex = 18;
            this.btnParseSrt.Text = "Parse Srt";
            this.btnParseSrt.UseVisualStyleBackColor = true;
            this.btnParseSrt.Click += new System.EventHandler(this.btnParseSrt_Click);
            // 
            // AssForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(739, 439);
            this.Controls.Add(this.btnParseSrt);
            this.Controls.Add(this.btnFixAss2);
            this.Controls.Add(this.btnChangeAssTiming);
            this.Controls.Add(this.btnFixAss);
            this.Controls.Add(this.lstAss2);
            this.Controls.Add(this.lstAss);
            this.Controls.Add(this.btnTestCharset);
            this.Controls.Add(this.btnUrlDecode);
            this.Controls.Add(this.statusStrip);
            this.Controls.Add(this.btnTranslate);
            this.Controls.Add(this.txtFramerate);
            this.Controls.Add(this.lblSectionsFile);
            this.Controls.Add(this.lblAssFile);
            this.Controls.Add(this.btnSplit);
            this.Controls.Add(this.btnBrowseSections);
            this.Controls.Add(this.txtSectionsFile);
            this.Controls.Add(this.btnBrowseAss);
            this.Controls.Add(this.txtAssFile);
            this.Name = "AssForm";
            this.Text = "AssForm";
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtAssFile;
        private System.Windows.Forms.Button btnBrowseAss;
        private System.Windows.Forms.TextBox txtSectionsFile;
        private System.Windows.Forms.Button btnBrowseSections;
        private System.Windows.Forms.Button btnSplit;
        private System.Windows.Forms.Label lblAssFile;
        private System.Windows.Forms.Label lblSectionsFile;
        private System.Windows.Forms.TextBox txtFramerate;
        private System.Windows.Forms.Button btnTranslate;
        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.ToolStripStatusLabel lblStatus;
        private System.Windows.Forms.ToolStripProgressBar progressBar;
        private System.Windows.Forms.Button btnUrlDecode;
        private System.Windows.Forms.Button btnTestCharset;
        private System.Windows.Forms.ListBox lstAss;
        private System.Windows.Forms.ListBox lstAss2;
        private System.Windows.Forms.Button btnFixAss;
        private System.Windows.Forms.Button btnChangeAssTiming;
        private System.Windows.Forms.Button btnFixAss2;
        private System.Windows.Forms.Button btnParseSrt;
    }
}