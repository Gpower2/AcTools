namespace AcTools.Forms
{
    partial class frmTimeCodeAnalyser
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
            this.txtTimecodesFile = new System.Windows.Forms.TextBox();
            this.btnTimecodeAnalyse = new System.Windows.Forms.Button();
            this.listTimecodes = new System.Windows.Forms.ListBox();
            this.btnHook = new System.Windows.Forms.Button();
            this.btnBrowseTimecodesFile = new System.Windows.Forms.Button();
            this.numAccuracyDecimalDigits = new System.Windows.Forms.NumericUpDown();
            this.lblAccuracyDigits = new System.Windows.Forms.Label();
            this.lblTimecodesFiles = new System.Windows.Forms.Label();
            this.picMap = new System.Windows.Forms.PictureBox();
            this.lblMap = new System.Windows.Forms.Label();
            this.lblMapFrames = new System.Windows.Forms.Label();
            this.trackMap = new AcControls.AcVideoSlider.AcVideoSlider();
            this.picLegendMap = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.numAccuracyDecimalDigits)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picMap)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackMap)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picLegendMap)).BeginInit();
            this.SuspendLayout();
            // 
            // txtTimecodesFile
            // 
            this.txtTimecodesFile.AllowDrop = true;
            this.txtTimecodesFile.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtTimecodesFile.Location = new System.Drawing.Point(12, 33);
            this.txtTimecodesFile.Name = "txtTimecodesFile";
            this.txtTimecodesFile.Size = new System.Drawing.Size(317, 23);
            this.txtTimecodesFile.TabIndex = 0;
            this.txtTimecodesFile.DragDrop += new System.Windows.Forms.DragEventHandler(this.txtTimecodesFile_DragDrop);
            this.txtTimecodesFile.DragEnter += new System.Windows.Forms.DragEventHandler(this.txtTimecodesFile_DragEnter);
            // 
            // btnTimecodeAnalyse
            // 
            this.btnTimecodeAnalyse.Location = new System.Drawing.Point(12, 67);
            this.btnTimecodeAnalyse.Name = "btnTimecodeAnalyse";
            this.btnTimecodeAnalyse.Size = new System.Drawing.Size(138, 45);
            this.btnTimecodeAnalyse.TabIndex = 1;
            this.btnTimecodeAnalyse.Text = "Analyse Timecodes";
            this.btnTimecodeAnalyse.UseVisualStyleBackColor = true;
            this.btnTimecodeAnalyse.Click += new System.EventHandler(this.btnTimecodeAnalyse_Click);
            // 
            // listTimecodes
            // 
            this.listTimecodes.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listTimecodes.FormattingEnabled = true;
            this.listTimecodes.ItemHeight = 15;
            this.listTimecodes.Location = new System.Drawing.Point(12, 127);
            this.listTimecodes.Name = "listTimecodes";
            this.listTimecodes.Size = new System.Drawing.Size(406, 154);
            this.listTimecodes.TabIndex = 2;
            // 
            // btnHook
            // 
            this.btnHook.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnHook.Location = new System.Drawing.Point(355, 431);
            this.btnHook.Name = "btnHook";
            this.btnHook.Size = new System.Drawing.Size(76, 32);
            this.btnHook.TabIndex = 3;
            this.btnHook.Text = "UnHook";
            this.btnHook.UseVisualStyleBackColor = true;
            this.btnHook.Click += new System.EventHandler(this.btnHook_Click);
            // 
            // btnBrowseTimecodesFile
            // 
            this.btnBrowseTimecodesFile.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnBrowseTimecodesFile.Location = new System.Drawing.Point(336, 29);
            this.btnBrowseTimecodesFile.Name = "btnBrowseTimecodesFile";
            this.btnBrowseTimecodesFile.Size = new System.Drawing.Size(82, 30);
            this.btnBrowseTimecodesFile.TabIndex = 4;
            this.btnBrowseTimecodesFile.Text = "Browse...";
            this.btnBrowseTimecodesFile.UseVisualStyleBackColor = true;
            this.btnBrowseTimecodesFile.Click += new System.EventHandler(this.btnBrowseTimecodesFile_Click);
            // 
            // numAccuracyDecimalDigits
            // 
            this.numAccuracyDecimalDigits.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.numAccuracyDecimalDigits.Location = new System.Drawing.Point(375, 77);
            this.numAccuracyDecimalDigits.Maximum = new decimal(new int[] {
            9,
            0,
            0,
            0});
            this.numAccuracyDecimalDigits.Name = "numAccuracyDecimalDigits";
            this.numAccuracyDecimalDigits.Size = new System.Drawing.Size(43, 23);
            this.numAccuracyDecimalDigits.TabIndex = 5;
            // 
            // lblAccuracyDigits
            // 
            this.lblAccuracyDigits.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblAccuracyDigits.AutoSize = true;
            this.lblAccuracyDigits.Location = new System.Drawing.Point(287, 79);
            this.lblAccuracyDigits.Name = "lblAccuracyDigits";
            this.lblAccuracyDigits.Size = new System.Drawing.Size(82, 15);
            this.lblAccuracyDigits.TabIndex = 6;
            this.lblAccuracyDigits.Text = "Decimal digits";
            // 
            // lblTimecodesFiles
            // 
            this.lblTimecodesFiles.AutoSize = true;
            this.lblTimecodesFiles.Location = new System.Drawing.Point(12, 9);
            this.lblTimecodesFiles.Name = "lblTimecodesFiles";
            this.lblTimecodesFiles.Size = new System.Drawing.Size(86, 15);
            this.lblTimecodesFiles.TabIndex = 7;
            this.lblTimecodesFiles.Text = "Timecodes File";
            // 
            // picMap
            // 
            this.picMap.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.picMap.Location = new System.Drawing.Point(12, 362);
            this.picMap.Name = "picMap";
            this.picMap.Size = new System.Drawing.Size(406, 32);
            this.picMap.TabIndex = 9;
            this.picMap.TabStop = false;
            // 
            // lblMap
            // 
            this.lblMap.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblMap.AutoSize = true;
            this.lblMap.Location = new System.Drawing.Point(12, 284);
            this.lblMap.Name = "lblMap";
            this.lblMap.Size = new System.Drawing.Size(92, 15);
            this.lblMap.TabIndex = 10;
            this.lblMap.Text = "Timecodes Map";
            // 
            // lblMapFrames
            // 
            this.lblMapFrames.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblMapFrames.Location = new System.Drawing.Point(124, 283);
            this.lblMapFrames.Name = "lblMapFrames";
            this.lblMapFrames.Size = new System.Drawing.Size(163, 27);
            this.lblMapFrames.TabIndex = 11;
            // 
            // trackMap
            // 
            this.trackMap.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.trackMap.Location = new System.Drawing.Point(12, 314);
            this.trackMap.Name = "trackMap";
            this.trackMap.Size = new System.Drawing.Size(406, 45);
            this.trackMap.TabIndex = 12;
            this.trackMap.ValueChanged += new System.EventHandler(this.trackMap_ValueChanged);
            // 
            // picLegendMap
            // 
            this.picLegendMap.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.picLegendMap.Location = new System.Drawing.Point(12, 398);
            this.picLegendMap.Name = "picLegendMap";
            this.picLegendMap.Size = new System.Drawing.Size(406, 31);
            this.picLegendMap.TabIndex = 13;
            this.picLegendMap.TabStop = false;
            // 
            // TimeCodeAnalyserForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(432, 465);
            this.Controls.Add(this.picLegendMap);
            this.Controls.Add(this.trackMap);
            this.Controls.Add(this.lblMapFrames);
            this.Controls.Add(this.lblMap);
            this.Controls.Add(this.picMap);
            this.Controls.Add(this.lblTimecodesFiles);
            this.Controls.Add(this.lblAccuracyDigits);
            this.Controls.Add(this.numAccuracyDecimalDigits);
            this.Controls.Add(this.btnBrowseTimecodesFile);
            this.Controls.Add(this.btnHook);
            this.Controls.Add(this.listTimecodes);
            this.Controls.Add(this.btnTimecodeAnalyse);
            this.Controls.Add(this.txtTimecodesFile);
            this.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.MinimumSize = new System.Drawing.Size(448, 504);
            this.Name = "TimeCodeAnalyserForm";
            this.Text = "TimeCodeAnalyserForm";
            this.Resize += new System.EventHandler(this.TimeCodeAnalyserForm_Resize);
            ((System.ComponentModel.ISupportInitialize)(this.numAccuracyDecimalDigits)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picMap)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackMap)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picLegendMap)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtTimecodesFile;
        private System.Windows.Forms.Button btnTimecodeAnalyse;
        private System.Windows.Forms.ListBox listTimecodes;
        private System.Windows.Forms.Button btnHook;
        private System.Windows.Forms.Button btnBrowseTimecodesFile;
        private System.Windows.Forms.NumericUpDown numAccuracyDecimalDigits;
        private System.Windows.Forms.Label lblAccuracyDigits;
        private System.Windows.Forms.Label lblTimecodesFiles;
        private System.Windows.Forms.PictureBox picMap;
        private System.Windows.Forms.Label lblMap;
        private System.Windows.Forms.Label lblMapFrames;
        private AcControls.AcVideoSlider.AcVideoSlider trackMap;
        private System.Windows.Forms.PictureBox picLegendMap;
    }
}