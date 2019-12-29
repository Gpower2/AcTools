namespace AcTools.Forms
{
    partial class frmVideoPlayer
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
            this.chkDontDropFrames = new System.Windows.Forms.CheckBox();
            this.btnSections = new System.Windows.Forms.Button();
            this.btnInfo = new System.Windows.Forms.Button();
            this.btnCrop = new System.Windows.Forms.Button();
            this.btnSaveScreenshot = new System.Windows.Forms.Button();
            this.btnGoToStart = new System.Windows.Forms.Button();
            this.btnGoToEnd = new System.Windows.Forms.Button();
            this.btnPlayVideo = new System.Windows.Forms.Button();
            this.btnBrowseVideoFile = new System.Windows.Forms.Button();
            this.btnReload = new System.Windows.Forms.Button();
            this.btnSmallForward = new System.Windows.Forms.Button();
            this.btnSmallBack = new System.Windows.Forms.Button();
            this.btnCopyFrameNumber = new System.Windows.Forms.Button();
            this.btnCopyFrameTime = new System.Windows.Forms.Button();
            this.cmbSize = new System.Windows.Forms.ComboBox();
            this.txtVideoTime = new System.Windows.Forms.TextBox();
            this.txtVideoFrame = new System.Windows.Forms.TextBox();
            this.btnResetSize = new System.Windows.Forms.Button();
            this.btnHook = new System.Windows.Forms.Button();
            this.trackVideo = new AcControls.AcVideoSlider.AcVideoSlider();
            this.btnForward = new System.Windows.Forms.Button();
            this.btnBack = new System.Windows.Forms.Button();
            this.btnOpen = new System.Windows.Forms.Button();
            this.txtVideoFile = new System.Windows.Forms.TextBox();
            this.picVideo = new AcControls.AcVideoFramePictureBox.AcVideoFramePictureBox();
            this.chkAlwaysOnTop = new System.Windows.Forms.CheckBox();
            this.btnEditVideoFile = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.trackVideo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picVideo)).BeginInit();
            this.SuspendLayout();
            // 
            // chkDontDropFrames
            // 
            this.chkDontDropFrames.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.chkDontDropFrames.Location = new System.Drawing.Point(6, 425);
            this.chkDontDropFrames.Name = "chkDontDropFrames";
            this.chkDontDropFrames.Size = new System.Drawing.Size(100, 17);
            this.chkDontDropFrames.TabIndex = 28;
            this.chkDontDropFrames.Text = "No frame drops";
            this.chkDontDropFrames.UseVisualStyleBackColor = true;
            // 
            // btnSections
            // 
            this.btnSections.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSections.Location = new System.Drawing.Point(707, 402);
            this.btnSections.Name = "btnSections";
            this.btnSections.Size = new System.Drawing.Size(55, 23);
            this.btnSections.TabIndex = 27;
            this.btnSections.Text = "Sections";
            this.btnSections.UseVisualStyleBackColor = true;
            this.btnSections.Click += new System.EventHandler(this.btnSections_Click);
            // 
            // btnInfo
            // 
            this.btnInfo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnInfo.Location = new System.Drawing.Point(653, 402);
            this.btnInfo.Name = "btnInfo";
            this.btnInfo.Size = new System.Drawing.Size(50, 23);
            this.btnInfo.TabIndex = 26;
            this.btnInfo.Text = "Info";
            this.btnInfo.UseVisualStyleBackColor = true;
            this.btnInfo.Click += new System.EventHandler(this.btnInfo_Click);
            // 
            // btnCrop
            // 
            this.btnCrop.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnCrop.Location = new System.Drawing.Point(653, 434);
            this.btnCrop.Name = "btnCrop";
            this.btnCrop.Size = new System.Drawing.Size(50, 23);
            this.btnCrop.TabIndex = 25;
            this.btnCrop.Text = "Crop";
            this.btnCrop.UseVisualStyleBackColor = true;
            this.btnCrop.Click += new System.EventHandler(this.btnCrop_Click);
            // 
            // btnSaveScreenshot
            // 
            this.btnSaveScreenshot.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnSaveScreenshot.Location = new System.Drawing.Point(450, 434);
            this.btnSaveScreenshot.Name = "btnSaveScreenshot";
            this.btnSaveScreenshot.Size = new System.Drawing.Size(60, 23);
            this.btnSaveScreenshot.TabIndex = 24;
            this.btnSaveScreenshot.Text = "Scrnshot";
            this.btnSaveScreenshot.UseVisualStyleBackColor = true;
            this.btnSaveScreenshot.Click += new System.EventHandler(this.btnSaveScreenshot_Click);
            // 
            // btnGoToStart
            // 
            this.btnGoToStart.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnGoToStart.Location = new System.Drawing.Point(110, 434);
            this.btnGoToStart.Name = "btnGoToStart";
            this.btnGoToStart.Size = new System.Drawing.Size(31, 23);
            this.btnGoToStart.TabIndex = 23;
            this.btnGoToStart.Text = "|<";
            this.btnGoToStart.UseVisualStyleBackColor = true;
            this.btnGoToStart.Click += new System.EventHandler(this.btnGoToStart_Click);
            // 
            // btnGoToEnd
            // 
            this.btnGoToEnd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnGoToEnd.Location = new System.Drawing.Point(296, 434);
            this.btnGoToEnd.Name = "btnGoToEnd";
            this.btnGoToEnd.Size = new System.Drawing.Size(31, 23);
            this.btnGoToEnd.TabIndex = 22;
            this.btnGoToEnd.Text = ">|";
            this.btnGoToEnd.UseVisualStyleBackColor = true;
            this.btnGoToEnd.Click += new System.EventHandler(this.btnGoToEnd_Click);
            // 
            // btnPlayVideo
            // 
            this.btnPlayVideo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnPlayVideo.Location = new System.Drawing.Point(197, 434);
            this.btnPlayVideo.Name = "btnPlayVideo";
            this.btnPlayVideo.Size = new System.Drawing.Size(43, 23);
            this.btnPlayVideo.TabIndex = 21;
            this.btnPlayVideo.Text = "Play";
            this.btnPlayVideo.UseVisualStyleBackColor = true;
            this.btnPlayVideo.Click += new System.EventHandler(this.btnPlayVideo_Click);
            // 
            // btnBrowseVideoFile
            // 
            this.btnBrowseVideoFile.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnBrowseVideoFile.Location = new System.Drawing.Point(265, 402);
            this.btnBrowseVideoFile.Name = "btnBrowseVideoFile";
            this.btnBrowseVideoFile.Size = new System.Drawing.Size(62, 23);
            this.btnBrowseVideoFile.TabIndex = 20;
            this.btnBrowseVideoFile.Text = "Browse...";
            this.btnBrowseVideoFile.UseVisualStyleBackColor = true;
            this.btnBrowseVideoFile.Click += new System.EventHandler(this.btnBrowseVideoFile_Click);
            // 
            // btnReload
            // 
            this.btnReload.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnReload.Location = new System.Drawing.Point(450, 402);
            this.btnReload.Name = "btnReload";
            this.btnReload.Size = new System.Drawing.Size(60, 23);
            this.btnReload.TabIndex = 18;
            this.btnReload.Text = "Reload";
            this.btnReload.UseVisualStyleBackColor = true;
            this.btnReload.Click += new System.EventHandler(this.btnReload_Click);
            // 
            // btnSmallForward
            // 
            this.btnSmallForward.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnSmallForward.Location = new System.Drawing.Point(241, 434);
            this.btnSmallForward.Name = "btnSmallForward";
            this.btnSmallForward.Size = new System.Drawing.Size(21, 23);
            this.btnSmallForward.TabIndex = 17;
            this.btnSmallForward.Text = ">";
            this.btnSmallForward.UseVisualStyleBackColor = true;
            this.btnSmallForward.Click += new System.EventHandler(this.btnSmallForward_Click);
            // 
            // btnSmallBack
            // 
            this.btnSmallBack.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnSmallBack.Location = new System.Drawing.Point(175, 434);
            this.btnSmallBack.Name = "btnSmallBack";
            this.btnSmallBack.Size = new System.Drawing.Size(21, 23);
            this.btnSmallBack.TabIndex = 16;
            this.btnSmallBack.Text = "<";
            this.btnSmallBack.UseVisualStyleBackColor = true;
            this.btnSmallBack.Click += new System.EventHandler(this.btnSmallBack_Click);
            // 
            // btnCopyFrameNumber
            // 
            this.btnCopyFrameNumber.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnCopyFrameNumber.Location = new System.Drawing.Point(634, 402);
            this.btnCopyFrameNumber.Name = "btnCopyFrameNumber";
            this.btnCopyFrameNumber.Size = new System.Drawing.Size(15, 23);
            this.btnCopyFrameNumber.TabIndex = 15;
            this.btnCopyFrameNumber.Text = "C";
            this.btnCopyFrameNumber.UseVisualStyleBackColor = true;
            this.btnCopyFrameNumber.Click += new System.EventHandler(this.btnCopyFrameNumber_Click);
            // 
            // btnCopyFrameTime
            // 
            this.btnCopyFrameTime.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnCopyFrameTime.Location = new System.Drawing.Point(634, 434);
            this.btnCopyFrameTime.Name = "btnCopyFrameTime";
            this.btnCopyFrameTime.Size = new System.Drawing.Size(15, 23);
            this.btnCopyFrameTime.TabIndex = 14;
            this.btnCopyFrameTime.Text = "C";
            this.btnCopyFrameTime.UseVisualStyleBackColor = true;
            this.btnCopyFrameTime.Click += new System.EventHandler(this.btnCopyFrameTime_Click);
            // 
            // cmbSize
            // 
            this.cmbSize.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.cmbSize.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbSize.FormattingEnabled = true;
            this.cmbSize.Location = new System.Drawing.Point(332, 435);
            this.cmbSize.Name = "cmbSize";
            this.cmbSize.Size = new System.Drawing.Size(60, 21);
            this.cmbSize.TabIndex = 13;
            // 
            // txtVideoTime
            // 
            this.txtVideoTime.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.txtVideoTime.Location = new System.Drawing.Point(513, 435);
            this.txtVideoTime.Name = "txtVideoTime";
            this.txtVideoTime.ReadOnly = true;
            this.txtVideoTime.Size = new System.Drawing.Size(117, 21);
            this.txtVideoTime.TabIndex = 12;
            // 
            // txtVideoFrame
            // 
            this.txtVideoFrame.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.txtVideoFrame.Location = new System.Drawing.Point(513, 403);
            this.txtVideoFrame.Name = "txtVideoFrame";
            this.txtVideoFrame.ReadOnly = true;
            this.txtVideoFrame.Size = new System.Drawing.Size(117, 21);
            this.txtVideoFrame.TabIndex = 11;
            // 
            // btnResetSize
            // 
            this.btnResetSize.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnResetSize.Location = new System.Drawing.Point(396, 434);
            this.btnResetSize.Name = "btnResetSize";
            this.btnResetSize.Size = new System.Drawing.Size(53, 23);
            this.btnResetSize.TabIndex = 10;
            this.btnResetSize.Text = "Set Size";
            this.btnResetSize.UseVisualStyleBackColor = true;
            this.btnResetSize.Click += new System.EventHandler(this.btnResetSize_Click);
            // 
            // btnHook
            // 
            this.btnHook.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnHook.Location = new System.Drawing.Point(708, 434);
            this.btnHook.Name = "btnHook";
            this.btnHook.Size = new System.Drawing.Size(55, 23);
            this.btnHook.TabIndex = 9;
            this.btnHook.Text = "UnHook";
            this.btnHook.UseVisualStyleBackColor = true;
            this.btnHook.Click += new System.EventHandler(this.btnHook_Click);
            // 
            // trackVideo
            // 
            this.trackVideo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.trackVideo.Location = new System.Drawing.Point(2, 351);
            this.trackVideo.Margin = new System.Windows.Forms.Padding(0);
            this.trackVideo.Name = "trackVideo";
            this.trackVideo.Size = new System.Drawing.Size(758, 45);
            this.trackVideo.TabIndex = 7;
            this.trackVideo.TickStyle = System.Windows.Forms.TickStyle.TopLeft;
            this.trackVideo.ValueChanged += new System.EventHandler(this.trackVideo_ValueChanged);
            this.trackVideo.MouseDown += new System.Windows.Forms.MouseEventHandler(this.trackVideo_MouseDown);
            this.trackVideo.MouseMove += new System.Windows.Forms.MouseEventHandler(this.trackVideo_MouseMove);
            // 
            // btnForward
            // 
            this.btnForward.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnForward.Location = new System.Drawing.Point(263, 434);
            this.btnForward.Name = "btnForward";
            this.btnForward.Size = new System.Drawing.Size(32, 23);
            this.btnForward.TabIndex = 6;
            this.btnForward.Text = ">>";
            this.btnForward.UseVisualStyleBackColor = true;
            this.btnForward.Click += new System.EventHandler(this.btnForward_Click);
            // 
            // btnBack
            // 
            this.btnBack.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnBack.Location = new System.Drawing.Point(141, 434);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(34, 23);
            this.btnBack.TabIndex = 5;
            this.btnBack.Text = "<<";
            this.btnBack.UseVisualStyleBackColor = true;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // btnOpen
            // 
            this.btnOpen.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnOpen.Location = new System.Drawing.Point(396, 402);
            this.btnOpen.Name = "btnOpen";
            this.btnOpen.Size = new System.Drawing.Size(53, 23);
            this.btnOpen.TabIndex = 2;
            this.btnOpen.Text = "Open";
            this.btnOpen.UseVisualStyleBackColor = true;
            this.btnOpen.Click += new System.EventHandler(this.btnOpen_Click);
            // 
            // txtVideoFile
            // 
            this.txtVideoFile.AllowDrop = true;
            this.txtVideoFile.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.txtVideoFile.Location = new System.Drawing.Point(6, 403);
            this.txtVideoFile.Name = "txtVideoFile";
            this.txtVideoFile.Size = new System.Drawing.Size(256, 21);
            this.txtVideoFile.TabIndex = 1;
            this.txtVideoFile.DragDrop += new System.Windows.Forms.DragEventHandler(this.txtVideo_DragDrop);
            this.txtVideoFile.DragEnter += new System.Windows.Forms.DragEventHandler(this.txtVideo_DragEnter);
            // 
            // picVideo
            // 
            this.picVideo.Location = new System.Drawing.Point(2, 2);
            this.picVideo.Name = "picVideo";
            this.picVideo.Size = new System.Drawing.Size(760, 344);
            this.picVideo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picVideo.TabIndex = 0;
            this.picVideo.TabStop = false;
            this.picVideo.DragDrop += new System.Windows.Forms.DragEventHandler(this.picVideo_DragDrop);
            this.picVideo.DragEnter += new System.Windows.Forms.DragEventHandler(this.picVideo_DragEnter);
            this.picVideo.MouseClick += new System.Windows.Forms.MouseEventHandler(this.picVideo_MouseClick);
            this.picVideo.MouseDown += new System.Windows.Forms.MouseEventHandler(this.picVideo_MouseDown);
            this.picVideo.MouseMove += new System.Windows.Forms.MouseEventHandler(this.picVideo_MouseMove);
            this.picVideo.MouseUp += new System.Windows.Forms.MouseEventHandler(this.picVideo_MouseUp);
            // 
            // chkAlwaysOnTop
            // 
            this.chkAlwaysOnTop.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.chkAlwaysOnTop.Location = new System.Drawing.Point(6, 442);
            this.chkAlwaysOnTop.Name = "chkAlwaysOnTop";
            this.chkAlwaysOnTop.Size = new System.Drawing.Size(100, 17);
            this.chkAlwaysOnTop.TabIndex = 29;
            this.chkAlwaysOnTop.Text = "Always On Top";
            this.chkAlwaysOnTop.UseVisualStyleBackColor = true;
            this.chkAlwaysOnTop.CheckedChanged += new System.EventHandler(this.chkAlwaysOnTop_CheckedChanged);
            // 
            // btnEditVideoFile
            // 
            this.btnEditVideoFile.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnEditVideoFile.Location = new System.Drawing.Point(332, 402);
            this.btnEditVideoFile.Name = "btnEditVideoFile";
            this.btnEditVideoFile.Size = new System.Drawing.Size(62, 23);
            this.btnEditVideoFile.TabIndex = 30;
            this.btnEditVideoFile.Text = "Edit...";
            this.btnEditVideoFile.UseVisualStyleBackColor = true;
            this.btnEditVideoFile.Click += new System.EventHandler(this.btnEditVideoFile_Click);
            // 
            // frmVideoPlayer
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(764, 461);
            this.Controls.Add(this.btnEditVideoFile);
            this.Controls.Add(this.chkAlwaysOnTop);
            this.Controls.Add(this.chkDontDropFrames);
            this.Controls.Add(this.btnSections);
            this.Controls.Add(this.btnInfo);
            this.Controls.Add(this.btnCrop);
            this.Controls.Add(this.btnSaveScreenshot);
            this.Controls.Add(this.btnGoToStart);
            this.Controls.Add(this.btnGoToEnd);
            this.Controls.Add(this.btnPlayVideo);
            this.Controls.Add(this.btnBrowseVideoFile);
            this.Controls.Add(this.btnReload);
            this.Controls.Add(this.btnSmallForward);
            this.Controls.Add(this.btnSmallBack);
            this.Controls.Add(this.btnCopyFrameNumber);
            this.Controls.Add(this.btnCopyFrameTime);
            this.Controls.Add(this.cmbSize);
            this.Controls.Add(this.txtVideoTime);
            this.Controls.Add(this.txtVideoFrame);
            this.Controls.Add(this.btnResetSize);
            this.Controls.Add(this.btnHook);
            this.Controls.Add(this.trackVideo);
            this.Controls.Add(this.btnForward);
            this.Controls.Add(this.btnBack);
            this.Controls.Add(this.btnOpen);
            this.Controls.Add(this.txtVideoFile);
            this.Controls.Add(this.picVideo);
            this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.KeyPreview = true;
            this.MinimumSize = new System.Drawing.Size(780, 500);
            this.Name = "frmVideoPlayer";
            this.Text = "VideoPlayerForm";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.VideoPlayerForm_FormClosing);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.VideoPlayerForm_KeyDown);
            this.Resize += new System.EventHandler(this.VideoPlayerForm_Resize);
            ((System.ComponentModel.ISupportInitialize)(this.trackVideo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picVideo)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private AcControls.AcVideoFramePictureBox.AcVideoFramePictureBox picVideo;
        private System.Windows.Forms.TextBox txtVideoFile;
        private System.Windows.Forms.Button btnOpen;
        private System.Windows.Forms.Button btnBack;
        private System.Windows.Forms.Button btnForward;
        private AcControls.AcVideoSlider.AcVideoSlider trackVideo;
        private System.Windows.Forms.Button btnHook;
        private System.Windows.Forms.Button btnResetSize;
        private System.Windows.Forms.TextBox txtVideoFrame;
        private System.Windows.Forms.TextBox txtVideoTime;
        private System.Windows.Forms.ComboBox cmbSize;
        private System.Windows.Forms.Button btnCopyFrameTime;
        private System.Windows.Forms.Button btnCopyFrameNumber;
        private System.Windows.Forms.Button btnSmallBack;
        private System.Windows.Forms.Button btnSmallForward;
        private System.Windows.Forms.Button btnReload;
        private System.Windows.Forms.Button btnBrowseVideoFile;
        private System.Windows.Forms.Button btnPlayVideo;
        private System.Windows.Forms.Button btnGoToEnd;
        private System.Windows.Forms.Button btnGoToStart;
        private System.Windows.Forms.Button btnSaveScreenshot;
        private System.Windows.Forms.Button btnCrop;
        private System.Windows.Forms.Button btnInfo;
        private System.Windows.Forms.Button btnSections;
        private System.Windows.Forms.CheckBox chkDontDropFrames;
        private System.Windows.Forms.CheckBox chkAlwaysOnTop;
        private System.Windows.Forms.Button btnEditVideoFile;
    }
}