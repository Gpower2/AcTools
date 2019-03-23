namespace AcTools.Forms
{
    partial class frmDuplicateAnalyser
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
            this.txtDuplicatesFile = new System.Windows.Forms.TextBox();
            this.btnBrowseDuplicatesFile = new System.Windows.Forms.Button();
            this.btnAnalyseDuplicates = new System.Windows.Forms.Button();
            this.listDuplicates = new System.Windows.Forms.ListBox();
            this.btnHook = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.lblMap = new System.Windows.Forms.Label();
            this.trackMap = new AcControls.AcVideoSlider.AcVideoSlider();
            this.picMap = new System.Windows.Forms.PictureBox();
            this.comMapThreshold = new System.Windows.Forms.ComboBox();
            this.lblMapThreshold = new System.Windows.Forms.Label();
            this.lblMapFrames = new System.Windows.Forms.Label();
            this.btnRefreshMap = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.trackMap)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picMap)).BeginInit();
            this.SuspendLayout();
            // 
            // txtDuplicatesFile
            // 
            this.txtDuplicatesFile.AllowDrop = true;
            this.txtDuplicatesFile.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDuplicatesFile.Location = new System.Drawing.Point(12, 28);
            this.txtDuplicatesFile.Name = "txtDuplicatesFile";
            this.txtDuplicatesFile.Size = new System.Drawing.Size(378, 23);
            this.txtDuplicatesFile.TabIndex = 0;
            this.txtDuplicatesFile.DragDrop += new System.Windows.Forms.DragEventHandler(this.txtDuplicatesFile_DragDrop);
            this.txtDuplicatesFile.DragEnter += new System.Windows.Forms.DragEventHandler(this.txtDuplicatesFile_DragEnter);
            // 
            // btnBrowseDuplicatesFile
            // 
            this.btnBrowseDuplicatesFile.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnBrowseDuplicatesFile.Location = new System.Drawing.Point(398, 24);
            this.btnBrowseDuplicatesFile.Name = "btnBrowseDuplicatesFile";
            this.btnBrowseDuplicatesFile.Size = new System.Drawing.Size(73, 29);
            this.btnBrowseDuplicatesFile.TabIndex = 1;
            this.btnBrowseDuplicatesFile.Text = "Browse...";
            this.btnBrowseDuplicatesFile.UseVisualStyleBackColor = true;
            this.btnBrowseDuplicatesFile.Click += new System.EventHandler(this.btnBrowseDuplicatesFile_Click);
            // 
            // btnAnalyseDuplicates
            // 
            this.btnAnalyseDuplicates.Location = new System.Drawing.Point(12, 66);
            this.btnAnalyseDuplicates.Name = "btnAnalyseDuplicates";
            this.btnAnalyseDuplicates.Size = new System.Drawing.Size(126, 42);
            this.btnAnalyseDuplicates.TabIndex = 2;
            this.btnAnalyseDuplicates.Text = "Analyse Duplicates";
            this.btnAnalyseDuplicates.UseVisualStyleBackColor = true;
            this.btnAnalyseDuplicates.Click += new System.EventHandler(this.btnAnalyseDuplicates_Click);
            // 
            // listDuplicates
            // 
            this.listDuplicates.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listDuplicates.FormattingEnabled = true;
            this.listDuplicates.ItemHeight = 15;
            this.listDuplicates.Location = new System.Drawing.Point(13, 123);
            this.listDuplicates.Name = "listDuplicates";
            this.listDuplicates.Size = new System.Drawing.Size(458, 214);
            this.listDuplicates.TabIndex = 3;
            // 
            // btnHook
            // 
            this.btnHook.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnHook.Location = new System.Drawing.Point(395, 469);
            this.btnHook.Name = "btnHook";
            this.btnHook.Size = new System.Drawing.Size(85, 29);
            this.btnHook.TabIndex = 4;
            this.btnHook.Text = "UnHook";
            this.btnHook.UseVisualStyleBackColor = true;
            this.btnHook.Click += new System.EventHandler(this.btnHook_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(83, 15);
            this.label1.TabIndex = 5;
            this.label1.Text = "Duplicates File";
            // 
            // lblMap
            // 
            this.lblMap.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblMap.AutoSize = true;
            this.lblMap.Location = new System.Drawing.Point(12, 352);
            this.lblMap.Name = "lblMap";
            this.lblMap.Size = new System.Drawing.Size(89, 15);
            this.lblMap.TabIndex = 6;
            this.lblMap.Text = "Duplicates Map";
            // 
            // trackMap
            // 
            this.trackMap.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.trackMap.Location = new System.Drawing.Point(12, 374);
            this.trackMap.Name = "trackMap";
            this.trackMap.Size = new System.Drawing.Size(458, 45);
            this.trackMap.TabIndex = 7;
            this.trackMap.ValueChanged += new System.EventHandler(this.trackMap_ValueChanged);
            // 
            // picMap
            // 
            this.picMap.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.picMap.Location = new System.Drawing.Point(12, 426);
            this.picMap.Name = "picMap";
            this.picMap.Size = new System.Drawing.Size(460, 37);
            this.picMap.TabIndex = 8;
            this.picMap.TabStop = false;
            // 
            // comMapThreshold
            // 
            this.comMapThreshold.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.comMapThreshold.FormattingEnabled = true;
            this.comMapThreshold.Location = new System.Drawing.Point(350, 75);
            this.comMapThreshold.Name = "comMapThreshold";
            this.comMapThreshold.Size = new System.Drawing.Size(121, 23);
            this.comMapThreshold.TabIndex = 9;
            // 
            // lblMapThreshold
            // 
            this.lblMapThreshold.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblMapThreshold.AutoSize = true;
            this.lblMapThreshold.Location = new System.Drawing.Point(257, 78);
            this.lblMapThreshold.Name = "lblMapThreshold";
            this.lblMapThreshold.Size = new System.Drawing.Size(87, 15);
            this.lblMapThreshold.TabIndex = 10;
            this.lblMapThreshold.Text = "Map Threshold";
            // 
            // lblMapFrames
            // 
            this.lblMapFrames.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblMapFrames.AutoSize = true;
            this.lblMapFrames.Location = new System.Drawing.Point(150, 352);
            this.lblMapFrames.Name = "lblMapFrames";
            this.lblMapFrames.Size = new System.Drawing.Size(0, 15);
            this.lblMapFrames.TabIndex = 11;
            // 
            // btnRefreshMap
            // 
            this.btnRefreshMap.Location = new System.Drawing.Point(154, 66);
            this.btnRefreshMap.Name = "btnRefreshMap";
            this.btnRefreshMap.Size = new System.Drawing.Size(98, 42);
            this.btnRefreshMap.TabIndex = 12;
            this.btnRefreshMap.Text = "Refresh Map";
            this.btnRefreshMap.UseVisualStyleBackColor = true;
            this.btnRefreshMap.Click += new System.EventHandler(this.btnRefreshMap_Click);
            // 
            // DuplicateAnalyserForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(483, 501);
            this.Controls.Add(this.btnRefreshMap);
            this.Controls.Add(this.lblMapFrames);
            this.Controls.Add(this.lblMapThreshold);
            this.Controls.Add(this.comMapThreshold);
            this.Controls.Add(this.picMap);
            this.Controls.Add(this.trackMap);
            this.Controls.Add(this.lblMap);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnHook);
            this.Controls.Add(this.listDuplicates);
            this.Controls.Add(this.btnAnalyseDuplicates);
            this.Controls.Add(this.btnBrowseDuplicatesFile);
            this.Controls.Add(this.txtDuplicatesFile);
            this.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.MinimumSize = new System.Drawing.Size(499, 540);
            this.Name = "DuplicateAnalyserForm";
            this.Text = "DuplicateAnalyserForm";
            this.Resize += new System.EventHandler(this.DuplicateAnalyserForm_Resize);
            ((System.ComponentModel.ISupportInitialize)(this.trackMap)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picMap)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtDuplicatesFile;
        private System.Windows.Forms.Button btnBrowseDuplicatesFile;
        private System.Windows.Forms.Button btnAnalyseDuplicates;
        private System.Windows.Forms.ListBox listDuplicates;
        private System.Windows.Forms.Button btnHook;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblMap;
        private AcControls.AcVideoSlider.AcVideoSlider trackMap;
        private System.Windows.Forms.PictureBox picMap;
        private System.Windows.Forms.ComboBox comMapThreshold;
        private System.Windows.Forms.Label lblMapThreshold;
        private System.Windows.Forms.Label lblMapFrames;
        private System.Windows.Forms.Button btnRefreshMap;
    }
}