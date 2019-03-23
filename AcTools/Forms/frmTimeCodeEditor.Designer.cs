namespace AcTools.Forms
{
    partial class frmTimeCodeEditor
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
            this.btnBrowseTimecodesFile = new System.Windows.Forms.Button();
            this.btnLoadTimecodesFile = new System.Windows.Forms.Button();
            this.numUpDownDecimalDigits = new System.Windows.Forms.NumericUpDown();
            this.lblNumberOfDecimalDigits = new System.Windows.Forms.Label();
            this.lstFrameTimecodes = new System.Windows.Forms.ListBox();
            this.grpFrameList = new System.Windows.Forms.GroupBox();
            this.txtFrameFrameRate = new System.Windows.Forms.TextBox();
            this.txtFrameDuration = new System.Windows.Forms.TextBox();
            this.lblFrameNumber = new System.Windows.Forms.Label();
            this.txtFrameNumber = new System.Windows.Forms.TextBox();
            this.btnAddFrameTimecode = new System.Windows.Forms.Button();
            this.btnDeleteFrameTimecode = new System.Windows.Forms.Button();
            this.btnUpdateFrameTimecode = new System.Windows.Forms.Button();
            this.grpHeader = new System.Windows.Forms.GroupBox();
            this.txtAssumedFrameRate = new System.Windows.Forms.TextBox();
            this.lblAssumedFrameRate = new System.Windows.Forms.Label();
            this.lblTimecodesVersion = new System.Windows.Forms.Label();
            this.cmbTimecodesVersion = new System.Windows.Forms.ComboBox();
            this.btnNewTimecodesFile = new System.Windows.Forms.Button();
            this.btnSaveTimecodesFile = new System.Windows.Forms.Button();
            this.grpFrameDetails = new System.Windows.Forms.GroupBox();
            this.lblFrameStart = new System.Windows.Forms.Label();
            this.txtFrameStart = new System.Windows.Forms.TextBox();
            this.btnAddFrameTimecodeRange = new System.Windows.Forms.Button();
            this.radioFrameRate = new System.Windows.Forms.RadioButton();
            this.radioFrameDuration = new System.Windows.Forms.RadioButton();
            this.grpTimecodesFile = new System.Windows.Forms.GroupBox();
            this.tlpMain = new System.Windows.Forms.TableLayoutPanel();
            this.grpTimecodesFileInfo = new System.Windows.Forms.GroupBox();
            this.tlpTimecodesFileInfo = new System.Windows.Forms.TableLayoutPanel();
            ((System.ComponentModel.ISupportInitialize)(this.numUpDownDecimalDigits)).BeginInit();
            this.grpFrameList.SuspendLayout();
            this.grpHeader.SuspendLayout();
            this.grpFrameDetails.SuspendLayout();
            this.grpTimecodesFile.SuspendLayout();
            this.tlpMain.SuspendLayout();
            this.grpTimecodesFileInfo.SuspendLayout();
            this.tlpTimecodesFileInfo.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtTimecodesFile
            // 
            this.txtTimecodesFile.AllowDrop = true;
            this.txtTimecodesFile.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtTimecodesFile.Location = new System.Drawing.Point(9, 27);
            this.txtTimecodesFile.Name = "txtTimecodesFile";
            this.txtTimecodesFile.Size = new System.Drawing.Size(334, 23);
            this.txtTimecodesFile.TabIndex = 0;
            this.txtTimecodesFile.DragDrop += new System.Windows.Forms.DragEventHandler(this.txtTimecodesFile_DragDrop);
            this.txtTimecodesFile.DragEnter += new System.Windows.Forms.DragEventHandler(this.txtTimecodesFile_DragEnter);
            // 
            // btnBrowseTimecodesFile
            // 
            this.btnBrowseTimecodesFile.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnBrowseTimecodesFile.Location = new System.Drawing.Point(351, 21);
            this.btnBrowseTimecodesFile.Name = "btnBrowseTimecodesFile";
            this.btnBrowseTimecodesFile.Size = new System.Drawing.Size(89, 32);
            this.btnBrowseTimecodesFile.TabIndex = 2;
            this.btnBrowseTimecodesFile.Text = "Browse...";
            this.btnBrowseTimecodesFile.UseVisualStyleBackColor = true;
            this.btnBrowseTimecodesFile.Click += new System.EventHandler(this.btnBrowseTimecodesFile_Click);
            // 
            // btnLoadTimecodesFile
            // 
            this.btnLoadTimecodesFile.Location = new System.Drawing.Point(9, 62);
            this.btnLoadTimecodesFile.Name = "btnLoadTimecodesFile";
            this.btnLoadTimecodesFile.Size = new System.Drawing.Size(89, 37);
            this.btnLoadTimecodesFile.TabIndex = 3;
            this.btnLoadTimecodesFile.Text = "Load";
            this.btnLoadTimecodesFile.UseVisualStyleBackColor = true;
            this.btnLoadTimecodesFile.Click += new System.EventHandler(this.btnLoadTimecodesFile_Click);
            // 
            // numUpDownDecimalDigits
            // 
            this.numUpDownDecimalDigits.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.numUpDownDecimalDigits.Location = new System.Drawing.Point(400, 69);
            this.numUpDownDecimalDigits.Name = "numUpDownDecimalDigits";
            this.numUpDownDecimalDigits.Size = new System.Drawing.Size(40, 23);
            this.numUpDownDecimalDigits.TabIndex = 4;
            // 
            // lblNumberOfDecimalDigits
            // 
            this.lblNumberOfDecimalDigits.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblNumberOfDecimalDigits.AutoSize = true;
            this.lblNumberOfDecimalDigits.Location = new System.Drawing.Point(312, 73);
            this.lblNumberOfDecimalDigits.Name = "lblNumberOfDecimalDigits";
            this.lblNumberOfDecimalDigits.Size = new System.Drawing.Size(82, 15);
            this.lblNumberOfDecimalDigits.TabIndex = 5;
            this.lblNumberOfDecimalDigits.Text = "Decimal digits";
            // 
            // lstFrameTimecodes
            // 
            this.lstFrameTimecodes.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lstFrameTimecodes.FormattingEnabled = true;
            this.lstFrameTimecodes.ItemHeight = 15;
            this.lstFrameTimecodes.Location = new System.Drawing.Point(3, 19);
            this.lstFrameTimecodes.Name = "lstFrameTimecodes";
            this.lstFrameTimecodes.Size = new System.Drawing.Size(430, 98);
            this.lstFrameTimecodes.TabIndex = 6;
            this.lstFrameTimecodes.SelectedIndexChanged += new System.EventHandler(this.lstFrameTimecodes_SelectedIndexChanged);
            // 
            // grpFrameList
            // 
            this.grpFrameList.Controls.Add(this.lstFrameTimecodes);
            this.grpFrameList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpFrameList.Location = new System.Drawing.Point(3, 107);
            this.grpFrameList.Name = "grpFrameList";
            this.grpFrameList.Size = new System.Drawing.Size(436, 120);
            this.grpFrameList.TabIndex = 7;
            this.grpFrameList.TabStop = false;
            this.grpFrameList.Text = "Frames List";
            // 
            // txtFrameFrameRate
            // 
            this.txtFrameFrameRate.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtFrameFrameRate.Location = new System.Drawing.Point(169, 128);
            this.txtFrameFrameRate.Name = "txtFrameFrameRate";
            this.txtFrameFrameRate.Size = new System.Drawing.Size(149, 23);
            this.txtFrameFrameRate.TabIndex = 10;
            this.txtFrameFrameRate.TextChanged += new System.EventHandler(this.txtFrameFrameRate_TextChanged);
            // 
            // txtFrameDuration
            // 
            this.txtFrameDuration.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtFrameDuration.Location = new System.Drawing.Point(169, 95);
            this.txtFrameDuration.Name = "txtFrameDuration";
            this.txtFrameDuration.Size = new System.Drawing.Size(149, 23);
            this.txtFrameDuration.TabIndex = 11;
            this.txtFrameDuration.TextChanged += new System.EventHandler(this.txtFrameDuration_TextChanged);
            // 
            // lblFrameNumber
            // 
            this.lblFrameNumber.AutoSize = true;
            this.lblFrameNumber.Location = new System.Drawing.Point(35, 37);
            this.lblFrameNumber.Name = "lblFrameNumber";
            this.lblFrameNumber.Size = new System.Drawing.Size(87, 15);
            this.lblFrameNumber.TabIndex = 14;
            this.lblFrameNumber.Text = "Frame Number";
            // 
            // txtFrameNumber
            // 
            this.txtFrameNumber.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtFrameNumber.Location = new System.Drawing.Point(169, 32);
            this.txtFrameNumber.Name = "txtFrameNumber";
            this.txtFrameNumber.Size = new System.Drawing.Size(148, 23);
            this.txtFrameNumber.TabIndex = 15;
            // 
            // btnAddFrameTimecode
            // 
            this.btnAddFrameTimecode.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAddFrameTimecode.Location = new System.Drawing.Point(327, 22);
            this.btnAddFrameTimecode.Name = "btnAddFrameTimecode";
            this.btnAddFrameTimecode.Size = new System.Drawing.Size(101, 32);
            this.btnAddFrameTimecode.TabIndex = 16;
            this.btnAddFrameTimecode.Text = "Add";
            this.btnAddFrameTimecode.UseVisualStyleBackColor = true;
            this.btnAddFrameTimecode.Click += new System.EventHandler(this.btnAddFrameTimecode_Click);
            // 
            // btnDeleteFrameTimecode
            // 
            this.btnDeleteFrameTimecode.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDeleteFrameTimecode.Location = new System.Drawing.Point(327, 130);
            this.btnDeleteFrameTimecode.Name = "btnDeleteFrameTimecode";
            this.btnDeleteFrameTimecode.Size = new System.Drawing.Size(101, 32);
            this.btnDeleteFrameTimecode.TabIndex = 17;
            this.btnDeleteFrameTimecode.Text = "Delete";
            this.btnDeleteFrameTimecode.UseVisualStyleBackColor = true;
            this.btnDeleteFrameTimecode.Click += new System.EventHandler(this.btnDeleteFrameTimecode_Click);
            // 
            // btnUpdateFrameTimecode
            // 
            this.btnUpdateFrameTimecode.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnUpdateFrameTimecode.Location = new System.Drawing.Point(327, 93);
            this.btnUpdateFrameTimecode.Name = "btnUpdateFrameTimecode";
            this.btnUpdateFrameTimecode.Size = new System.Drawing.Size(101, 32);
            this.btnUpdateFrameTimecode.TabIndex = 18;
            this.btnUpdateFrameTimecode.Text = "Update";
            this.btnUpdateFrameTimecode.UseVisualStyleBackColor = true;
            this.btnUpdateFrameTimecode.Click += new System.EventHandler(this.btnUpdateFrameTimecode_Click);
            // 
            // grpHeader
            // 
            this.grpHeader.Controls.Add(this.txtAssumedFrameRate);
            this.grpHeader.Controls.Add(this.lblAssumedFrameRate);
            this.grpHeader.Controls.Add(this.lblTimecodesVersion);
            this.grpHeader.Controls.Add(this.cmbTimecodesVersion);
            this.grpHeader.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpHeader.Location = new System.Drawing.Point(3, 3);
            this.grpHeader.Name = "grpHeader";
            this.grpHeader.Size = new System.Drawing.Size(436, 98);
            this.grpHeader.TabIndex = 19;
            this.grpHeader.TabStop = false;
            this.grpHeader.Text = "Header";
            // 
            // txtAssumedFrameRate
            // 
            this.txtAssumedFrameRate.Location = new System.Drawing.Point(147, 59);
            this.txtAssumedFrameRate.Name = "txtAssumedFrameRate";
            this.txtAssumedFrameRate.Size = new System.Drawing.Size(160, 23);
            this.txtAssumedFrameRate.TabIndex = 3;
            // 
            // lblAssumedFrameRate
            // 
            this.lblAssumedFrameRate.AutoSize = true;
            this.lblAssumedFrameRate.Location = new System.Drawing.Point(9, 63);
            this.lblAssumedFrameRate.Name = "lblAssumedFrameRate";
            this.lblAssumedFrameRate.Size = new System.Drawing.Size(118, 15);
            this.lblAssumedFrameRate.TabIndex = 2;
            this.lblAssumedFrameRate.Text = "Assumed Frame Rate";
            // 
            // lblTimecodesVersion
            // 
            this.lblTimecodesVersion.AutoSize = true;
            this.lblTimecodesVersion.Location = new System.Drawing.Point(86, 28);
            this.lblTimecodesVersion.Name = "lblTimecodesVersion";
            this.lblTimecodesVersion.Size = new System.Drawing.Size(46, 15);
            this.lblTimecodesVersion.TabIndex = 1;
            this.lblTimecodesVersion.Text = "Version";
            // 
            // cmbTimecodesVersion
            // 
            this.cmbTimecodesVersion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTimecodesVersion.FormattingEnabled = true;
            this.cmbTimecodesVersion.Location = new System.Drawing.Point(147, 23);
            this.cmbTimecodesVersion.Name = "cmbTimecodesVersion";
            this.cmbTimecodesVersion.Size = new System.Drawing.Size(160, 23);
            this.cmbTimecodesVersion.TabIndex = 0;
            // 
            // btnNewTimecodesFile
            // 
            this.btnNewTimecodesFile.Location = new System.Drawing.Point(103, 62);
            this.btnNewTimecodesFile.Name = "btnNewTimecodesFile";
            this.btnNewTimecodesFile.Size = new System.Drawing.Size(89, 37);
            this.btnNewTimecodesFile.TabIndex = 20;
            this.btnNewTimecodesFile.Text = "New";
            this.btnNewTimecodesFile.UseVisualStyleBackColor = true;
            this.btnNewTimecodesFile.Click += new System.EventHandler(this.btnNewTimecodesFile_Click);
            // 
            // btnSaveTimecodesFile
            // 
            this.btnSaveTimecodesFile.Location = new System.Drawing.Point(197, 62);
            this.btnSaveTimecodesFile.Name = "btnSaveTimecodesFile";
            this.btnSaveTimecodesFile.Size = new System.Drawing.Size(89, 37);
            this.btnSaveTimecodesFile.TabIndex = 21;
            this.btnSaveTimecodesFile.Text = "Save";
            this.btnSaveTimecodesFile.UseVisualStyleBackColor = true;
            this.btnSaveTimecodesFile.Click += new System.EventHandler(this.btnSaveTimecodesFile_Click);
            // 
            // grpFrameDetails
            // 
            this.grpFrameDetails.Controls.Add(this.lblFrameStart);
            this.grpFrameDetails.Controls.Add(this.txtFrameStart);
            this.grpFrameDetails.Controls.Add(this.btnAddFrameTimecodeRange);
            this.grpFrameDetails.Controls.Add(this.radioFrameRate);
            this.grpFrameDetails.Controls.Add(this.radioFrameDuration);
            this.grpFrameDetails.Controls.Add(this.btnUpdateFrameTimecode);
            this.grpFrameDetails.Controls.Add(this.txtFrameFrameRate);
            this.grpFrameDetails.Controls.Add(this.txtFrameDuration);
            this.grpFrameDetails.Controls.Add(this.btnDeleteFrameTimecode);
            this.grpFrameDetails.Controls.Add(this.lblFrameNumber);
            this.grpFrameDetails.Controls.Add(this.btnAddFrameTimecode);
            this.grpFrameDetails.Controls.Add(this.txtFrameNumber);
            this.grpFrameDetails.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpFrameDetails.Location = new System.Drawing.Point(3, 233);
            this.grpFrameDetails.Name = "grpFrameDetails";
            this.grpFrameDetails.Size = new System.Drawing.Size(436, 167);
            this.grpFrameDetails.TabIndex = 22;
            this.grpFrameDetails.TabStop = false;
            this.grpFrameDetails.Text = "Frame Details";
            // 
            // lblFrameStart
            // 
            this.lblFrameStart.AutoSize = true;
            this.lblFrameStart.Location = new System.Drawing.Point(35, 68);
            this.lblFrameStart.Name = "lblFrameStart";
            this.lblFrameStart.Size = new System.Drawing.Size(94, 15);
            this.lblFrameStart.TabIndex = 22;
            this.lblFrameStart.Text = "Frame Start (ms)";
            // 
            // txtFrameStart
            // 
            this.txtFrameStart.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtFrameStart.Location = new System.Drawing.Point(170, 63);
            this.txtFrameStart.Name = "txtFrameStart";
            this.txtFrameStart.Size = new System.Drawing.Size(148, 23);
            this.txtFrameStart.TabIndex = 23;
            // 
            // btnAddFrameTimecodeRange
            // 
            this.btnAddFrameTimecodeRange.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAddFrameTimecodeRange.Location = new System.Drawing.Point(327, 58);
            this.btnAddFrameTimecodeRange.Name = "btnAddFrameTimecodeRange";
            this.btnAddFrameTimecodeRange.Size = new System.Drawing.Size(101, 32);
            this.btnAddFrameTimecodeRange.TabIndex = 21;
            this.btnAddFrameTimecodeRange.Text = "Add range...";
            this.btnAddFrameTimecodeRange.UseVisualStyleBackColor = true;
            this.btnAddFrameTimecodeRange.Click += new System.EventHandler(this.btnAddFrameTimecodeRange_Click);
            // 
            // radioFrameRate
            // 
            this.radioFrameRate.AutoSize = true;
            this.radioFrameRate.Location = new System.Drawing.Point(16, 130);
            this.radioFrameRate.Name = "radioFrameRate";
            this.radioFrameRate.Size = new System.Drawing.Size(111, 19);
            this.radioFrameRate.TabIndex = 20;
            this.radioFrameRate.TabStop = true;
            this.radioFrameRate.Text = "Frame Rate (fps)";
            this.radioFrameRate.UseVisualStyleBackColor = true;
            this.radioFrameRate.CheckedChanged += new System.EventHandler(this.radio_CheckedChanged);
            // 
            // radioFrameDuration
            // 
            this.radioFrameDuration.AutoSize = true;
            this.radioFrameDuration.Location = new System.Drawing.Point(16, 97);
            this.radioFrameDuration.Name = "radioFrameDuration";
            this.radioFrameDuration.Size = new System.Drawing.Size(134, 19);
            this.radioFrameDuration.TabIndex = 19;
            this.radioFrameDuration.TabStop = true;
            this.radioFrameDuration.Text = "Frame Duration (ms)";
            this.radioFrameDuration.UseVisualStyleBackColor = true;
            this.radioFrameDuration.CheckedChanged += new System.EventHandler(this.radio_CheckedChanged);
            // 
            // grpTimecodesFile
            // 
            this.grpTimecodesFile.Controls.Add(this.btnLoadTimecodesFile);
            this.grpTimecodesFile.Controls.Add(this.txtTimecodesFile);
            this.grpTimecodesFile.Controls.Add(this.btnSaveTimecodesFile);
            this.grpTimecodesFile.Controls.Add(this.btnNewTimecodesFile);
            this.grpTimecodesFile.Controls.Add(this.btnBrowseTimecodesFile);
            this.grpTimecodesFile.Controls.Add(this.numUpDownDecimalDigits);
            this.grpTimecodesFile.Controls.Add(this.lblNumberOfDecimalDigits);
            this.grpTimecodesFile.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpTimecodesFile.Location = new System.Drawing.Point(3, 3);
            this.grpTimecodesFile.Name = "grpTimecodesFile";
            this.grpTimecodesFile.Size = new System.Drawing.Size(448, 109);
            this.grpTimecodesFile.TabIndex = 23;
            this.grpTimecodesFile.TabStop = false;
            this.grpTimecodesFile.Text = "TimeCodes File";
            // 
            // tlpMain
            // 
            this.tlpMain.ColumnCount = 1;
            this.tlpMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpMain.Controls.Add(this.grpTimecodesFile, 0, 0);
            this.tlpMain.Controls.Add(this.grpTimecodesFileInfo, 0, 1);
            this.tlpMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpMain.Location = new System.Drawing.Point(0, 0);
            this.tlpMain.Name = "tlpMain";
            this.tlpMain.RowCount = 2;
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 115F));
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 23F));
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 23F));
            this.tlpMain.Size = new System.Drawing.Size(454, 546);
            this.tlpMain.TabIndex = 24;
            // 
            // grpTimecodesFileInfo
            // 
            this.grpTimecodesFileInfo.Controls.Add(this.tlpTimecodesFileInfo);
            this.grpTimecodesFileInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpTimecodesFileInfo.Location = new System.Drawing.Point(3, 118);
            this.grpTimecodesFileInfo.Name = "grpTimecodesFileInfo";
            this.grpTimecodesFileInfo.Size = new System.Drawing.Size(448, 425);
            this.grpTimecodesFileInfo.TabIndex = 24;
            this.grpTimecodesFileInfo.TabStop = false;
            // 
            // tlpTimecodesFileInfo
            // 
            this.tlpTimecodesFileInfo.ColumnCount = 1;
            this.tlpTimecodesFileInfo.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpTimecodesFileInfo.Controls.Add(this.grpHeader, 0, 0);
            this.tlpTimecodesFileInfo.Controls.Add(this.grpFrameDetails, 0, 2);
            this.tlpTimecodesFileInfo.Controls.Add(this.grpFrameList, 0, 1);
            this.tlpTimecodesFileInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpTimecodesFileInfo.Location = new System.Drawing.Point(3, 19);
            this.tlpTimecodesFileInfo.Name = "tlpTimecodesFileInfo";
            this.tlpTimecodesFileInfo.RowCount = 3;
            this.tlpTimecodesFileInfo.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 104F));
            this.tlpTimecodesFileInfo.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpTimecodesFileInfo.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 173F));
            this.tlpTimecodesFileInfo.Size = new System.Drawing.Size(442, 403);
            this.tlpTimecodesFileInfo.TabIndex = 25;
            // 
            // TimeCodeEditorForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(454, 546);
            this.Controls.Add(this.tlpMain);
            this.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.MinimumSize = new System.Drawing.Size(470, 585);
            this.Name = "TimeCodeEditorForm";
            this.Text = "TimeCodeEditorForm";
            ((System.ComponentModel.ISupportInitialize)(this.numUpDownDecimalDigits)).EndInit();
            this.grpFrameList.ResumeLayout(false);
            this.grpHeader.ResumeLayout(false);
            this.grpHeader.PerformLayout();
            this.grpFrameDetails.ResumeLayout(false);
            this.grpFrameDetails.PerformLayout();
            this.grpTimecodesFile.ResumeLayout(false);
            this.grpTimecodesFile.PerformLayout();
            this.tlpMain.ResumeLayout(false);
            this.grpTimecodesFileInfo.ResumeLayout(false);
            this.tlpTimecodesFileInfo.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox txtTimecodesFile;
        private System.Windows.Forms.Button btnBrowseTimecodesFile;
        private System.Windows.Forms.Button btnLoadTimecodesFile;
        private System.Windows.Forms.NumericUpDown numUpDownDecimalDigits;
        private System.Windows.Forms.Label lblNumberOfDecimalDigits;
        private System.Windows.Forms.ListBox lstFrameTimecodes;
        private System.Windows.Forms.GroupBox grpFrameList;
        private System.Windows.Forms.TextBox txtFrameFrameRate;
        private System.Windows.Forms.TextBox txtFrameDuration;
        private System.Windows.Forms.Label lblFrameNumber;
        private System.Windows.Forms.TextBox txtFrameNumber;
        private System.Windows.Forms.Button btnAddFrameTimecode;
        private System.Windows.Forms.Button btnDeleteFrameTimecode;
        private System.Windows.Forms.Button btnUpdateFrameTimecode;
        private System.Windows.Forms.GroupBox grpHeader;
        private System.Windows.Forms.TextBox txtAssumedFrameRate;
        private System.Windows.Forms.Label lblAssumedFrameRate;
        private System.Windows.Forms.Label lblTimecodesVersion;
        private System.Windows.Forms.ComboBox cmbTimecodesVersion;
        private System.Windows.Forms.Button btnNewTimecodesFile;
        private System.Windows.Forms.Button btnSaveTimecodesFile;
        private System.Windows.Forms.GroupBox grpFrameDetails;
        private System.Windows.Forms.GroupBox grpTimecodesFile;
        private System.Windows.Forms.TableLayoutPanel tlpMain;
        private System.Windows.Forms.GroupBox grpTimecodesFileInfo;
        private System.Windows.Forms.TableLayoutPanel tlpTimecodesFileInfo;
        private System.Windows.Forms.RadioButton radioFrameRate;
        private System.Windows.Forms.RadioButton radioFrameDuration;
        private System.Windows.Forms.Label lblFrameStart;
        private System.Windows.Forms.TextBox txtFrameStart;
        private System.Windows.Forms.Button btnAddFrameTimecodeRange;
    }
}