namespace AcTools.Forms
{
    partial class frmFrameRestoration
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
            this.grpVideoFrames = new System.Windows.Forms.GroupBox();
            this.tblMainContainer = new System.Windows.Forms.TableLayoutPanel();
            this.tblShowFrameOptions = new System.Windows.Forms.TableLayoutPanel();
            this.checkShowVideoFramePrevious = new System.Windows.Forms.CheckBox();
            this.checkShowVideoFrameNext = new System.Windows.Forms.CheckBox();
            this.checkShowVideoFrameCurrent = new System.Windows.Forms.CheckBox();
            this.tblVideoFrames = new System.Windows.Forms.TableLayoutPanel();
            this.txtVideoFramePrevious = new System.Windows.Forms.TextBox();
            this.picVideoFramePrevious = new AcControls.AcVideoFramePictureBox.AcVideoFramePictureBox();
            this.picVideoFrameNext = new AcControls.AcVideoFramePictureBox.AcVideoFramePictureBox();
            this.picVideoFrameCurrent = new AcControls.AcVideoFramePictureBox.AcVideoFramePictureBox();
            this.txtVideoFrameCurrent = new System.Windows.Forms.TextBox();
            this.txtVideoFrameNext = new System.Windows.Forms.TextBox();
            this.txtStatusPrevious = new System.Windows.Forms.TextBox();
            this.txtStatusCurrent = new System.Windows.Forms.TextBox();
            this.txtStatusNext = new System.Windows.Forms.TextBox();
            this.grpFunctions = new System.Windows.Forms.GroupBox();
            this.checkUsePreview = new System.Windows.Forms.CheckBox();
            this.btnUpdateProjectProperties = new System.Windows.Forms.Button();
            this.btnHook = new System.Windows.Forms.Button();
            this.checkKeepAspectRatio = new System.Windows.Forms.CheckBox();
            this.btnStart = new System.Windows.Forms.Button();
            this.btnSaveFiles = new System.Windows.Forms.Button();
            this.checkAutoCommit = new System.Windows.Forms.CheckBox();
            this.checkZoom = new System.Windows.Forms.CheckBox();
            this.btnPreview = new System.Windows.Forms.Button();
            this.btnDuplicateFrame = new System.Windows.Forms.Button();
            this.btnDeleteFrame = new System.Windows.Forms.Button();
            this.trackVideo = new AcControls.AcVideoSlider.AcVideoSlider();
            this.lblVideoFile = new System.Windows.Forms.Label();
            this.txtVideoFile = new System.Windows.Forms.TextBox();
            this.btnBrowseVideoFile = new System.Windows.Forms.Button();
            this.btnBrowseAvisynthOutputFile = new System.Windows.Forms.Button();
            this.txtAvisynthOutputFile = new System.Windows.Forms.TextBox();
            this.lblAvisynthOutputFile = new System.Windows.Forms.Label();
            this.btnGoToStart = new System.Windows.Forms.Button();
            this.btnGoToEnd = new System.Windows.Forms.Button();
            this.btnPlayVideo = new System.Windows.Forms.Button();
            this.btnSmallForward = new System.Windows.Forms.Button();
            this.btnSmallBack = new System.Windows.Forms.Button();
            this.btnForward = new System.Windows.Forms.Button();
            this.btnBack = new System.Windows.Forms.Button();
            this.btnGoToFrame = new System.Windows.Forms.Button();
            this.txtFrame = new System.Windows.Forms.TextBox();
            this.grpVideoControls = new System.Windows.Forms.GroupBox();
            this.txtCurrentTime = new System.Windows.Forms.TextBox();
            this.btnBrowseProjectFile = new System.Windows.Forms.Button();
            this.txtProjectFile = new System.Windows.Forms.TextBox();
            this.lblProjectFile = new System.Windows.Forms.Label();
            this.grpFiles = new System.Windows.Forms.GroupBox();
            this.tabCtrlFiles = new System.Windows.Forms.TabControl();
            this.tabPageProject = new System.Windows.Forms.TabPage();
            this.tabPageFiles = new System.Windows.Forms.TabPage();
            this.lblTimecodesFile = new System.Windows.Forms.Label();
            this.txtTimecodesFile = new System.Windows.Forms.TextBox();
            this.btnBrowseTimecodesFile = new System.Windows.Forms.Button();
            this.grpChangeList = new System.Windows.Forms.GroupBox();
            this.tblChanges = new System.Windows.Forms.TableLayoutPanel();
            this.btnDeleteChange = new System.Windows.Forms.Button();
            this.listChanges = new System.Windows.Forms.ListBox();
            this.grpVideoFrames.SuspendLayout();
            this.tblMainContainer.SuspendLayout();
            this.tblShowFrameOptions.SuspendLayout();
            this.tblVideoFrames.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picVideoFramePrevious)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picVideoFrameNext)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picVideoFrameCurrent)).BeginInit();
            this.grpFunctions.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackVideo)).BeginInit();
            this.grpVideoControls.SuspendLayout();
            this.grpFiles.SuspendLayout();
            this.tabCtrlFiles.SuspendLayout();
            this.tabPageProject.SuspendLayout();
            this.tabPageFiles.SuspendLayout();
            this.grpChangeList.SuspendLayout();
            this.tblChanges.SuspendLayout();
            this.SuspendLayout();
            // 
            // grpVideoFrames
            // 
            this.grpVideoFrames.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.grpVideoFrames.Controls.Add(this.tblMainContainer);
            this.grpVideoFrames.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.grpVideoFrames.Location = new System.Drawing.Point(10, 3);
            this.grpVideoFrames.Name = "grpVideoFrames";
            this.grpVideoFrames.Size = new System.Drawing.Size(606, 351);
            this.grpVideoFrames.TabIndex = 0;
            this.grpVideoFrames.TabStop = false;
            this.grpVideoFrames.Text = "Video Frames";
            // 
            // tblMainContainer
            // 
            this.tblMainContainer.ColumnCount = 1;
            this.tblMainContainer.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tblMainContainer.Controls.Add(this.tblShowFrameOptions, 0, 1);
            this.tblMainContainer.Controls.Add(this.tblVideoFrames, 0, 0);
            this.tblMainContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tblMainContainer.Location = new System.Drawing.Point(3, 18);
            this.tblMainContainer.Name = "tblMainContainer";
            this.tblMainContainer.RowCount = 2;
            this.tblMainContainer.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tblMainContainer.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 32F));
            this.tblMainContainer.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 22F));
            this.tblMainContainer.Size = new System.Drawing.Size(600, 330);
            this.tblMainContainer.TabIndex = 4;
            // 
            // tblShowFrameOptions
            // 
            this.tblShowFrameOptions.ColumnCount = 3;
            this.tblShowFrameOptions.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tblShowFrameOptions.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tblShowFrameOptions.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tblShowFrameOptions.Controls.Add(this.checkShowVideoFramePrevious, 0, 0);
            this.tblShowFrameOptions.Controls.Add(this.checkShowVideoFrameNext, 2, 0);
            this.tblShowFrameOptions.Controls.Add(this.checkShowVideoFrameCurrent, 1, 0);
            this.tblShowFrameOptions.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tblShowFrameOptions.Location = new System.Drawing.Point(3, 301);
            this.tblShowFrameOptions.Name = "tblShowFrameOptions";
            this.tblShowFrameOptions.RowCount = 1;
            this.tblShowFrameOptions.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tblShowFrameOptions.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 26F));
            this.tblShowFrameOptions.Size = new System.Drawing.Size(594, 26);
            this.tblShowFrameOptions.TabIndex = 3;
            // 
            // checkShowVideoFramePrevious
            // 
            this.checkShowVideoFramePrevious.AutoSize = true;
            this.checkShowVideoFramePrevious.Dock = System.Windows.Forms.DockStyle.Fill;
            this.checkShowVideoFramePrevious.Location = new System.Drawing.Point(3, 3);
            this.checkShowVideoFramePrevious.Name = "checkShowVideoFramePrevious";
            this.checkShowVideoFramePrevious.Size = new System.Drawing.Size(192, 20);
            this.checkShowVideoFramePrevious.TabIndex = 0;
            this.checkShowVideoFramePrevious.Text = "ShowPrevious";
            this.checkShowVideoFramePrevious.UseVisualStyleBackColor = true;
            this.checkShowVideoFramePrevious.CheckedChanged += new System.EventHandler(this.checkShowVideoFrameCurrent_CheckedChanged);
            // 
            // checkShowVideoFrameNext
            // 
            this.checkShowVideoFrameNext.AutoSize = true;
            this.checkShowVideoFrameNext.Dock = System.Windows.Forms.DockStyle.Fill;
            this.checkShowVideoFrameNext.Location = new System.Drawing.Point(399, 3);
            this.checkShowVideoFrameNext.Name = "checkShowVideoFrameNext";
            this.checkShowVideoFrameNext.Size = new System.Drawing.Size(192, 20);
            this.checkShowVideoFrameNext.TabIndex = 2;
            this.checkShowVideoFrameNext.Text = "Show Next";
            this.checkShowVideoFrameNext.UseVisualStyleBackColor = true;
            this.checkShowVideoFrameNext.CheckedChanged += new System.EventHandler(this.checkShowVideoFrameCurrent_CheckedChanged);
            // 
            // checkShowVideoFrameCurrent
            // 
            this.checkShowVideoFrameCurrent.AutoSize = true;
            this.checkShowVideoFrameCurrent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.checkShowVideoFrameCurrent.Location = new System.Drawing.Point(201, 3);
            this.checkShowVideoFrameCurrent.Name = "checkShowVideoFrameCurrent";
            this.checkShowVideoFrameCurrent.Size = new System.Drawing.Size(192, 20);
            this.checkShowVideoFrameCurrent.TabIndex = 1;
            this.checkShowVideoFrameCurrent.Text = "Show Current";
            this.checkShowVideoFrameCurrent.UseVisualStyleBackColor = true;
            this.checkShowVideoFrameCurrent.CheckedChanged += new System.EventHandler(this.checkShowVideoFrameCurrent_CheckedChanged);
            // 
            // tblVideoFrames
            // 
            this.tblVideoFrames.ColumnCount = 3;
            this.tblVideoFrames.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tblVideoFrames.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33334F));
            this.tblVideoFrames.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33334F));
            this.tblVideoFrames.Controls.Add(this.txtVideoFramePrevious, 0, 1);
            this.tblVideoFrames.Controls.Add(this.picVideoFramePrevious, 0, 0);
            this.tblVideoFrames.Controls.Add(this.picVideoFrameNext, 2, 0);
            this.tblVideoFrames.Controls.Add(this.picVideoFrameCurrent, 1, 0);
            this.tblVideoFrames.Controls.Add(this.txtVideoFrameCurrent, 1, 1);
            this.tblVideoFrames.Controls.Add(this.txtVideoFrameNext, 2, 1);
            this.tblVideoFrames.Controls.Add(this.txtStatusPrevious, 0, 2);
            this.tblVideoFrames.Controls.Add(this.txtStatusCurrent, 1, 2);
            this.tblVideoFrames.Controls.Add(this.txtStatusNext, 2, 2);
            this.tblVideoFrames.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tblVideoFrames.Location = new System.Drawing.Point(3, 3);
            this.tblVideoFrames.Name = "tblVideoFrames";
            this.tblVideoFrames.RowCount = 3;
            this.tblVideoFrames.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tblVideoFrames.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 32F));
            this.tblVideoFrames.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 32F));
            this.tblVideoFrames.Size = new System.Drawing.Size(594, 292);
            this.tblVideoFrames.TabIndex = 3;
            // 
            // txtVideoFramePrevious
            // 
            this.txtVideoFramePrevious.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtVideoFramePrevious.Location = new System.Drawing.Point(3, 231);
            this.txtVideoFramePrevious.Name = "txtVideoFramePrevious";
            this.txtVideoFramePrevious.ReadOnly = true;
            this.txtVideoFramePrevious.Size = new System.Drawing.Size(191, 22);
            this.txtVideoFramePrevious.TabIndex = 4;
            this.txtVideoFramePrevious.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // picVideoFramePrevious
            // 
            this.picVideoFramePrevious.Dock = System.Windows.Forms.DockStyle.Fill;
            this.picVideoFramePrevious.Location = new System.Drawing.Point(3, 3);
            this.picVideoFramePrevious.Name = "picVideoFramePrevious";
            this.picVideoFramePrevious.Size = new System.Drawing.Size(191, 222);
            this.picVideoFramePrevious.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picVideoFramePrevious.TabIndex = 0;
            this.picVideoFramePrevious.TabStop = false;
            this.picVideoFramePrevious.Click += new System.EventHandler(this.picVideoFrameCurrent_Click);
            // 
            // picVideoFrameNext
            // 
            this.picVideoFrameNext.Dock = System.Windows.Forms.DockStyle.Fill;
            this.picVideoFrameNext.Location = new System.Drawing.Point(398, 3);
            this.picVideoFrameNext.Name = "picVideoFrameNext";
            this.picVideoFrameNext.Size = new System.Drawing.Size(193, 222);
            this.picVideoFrameNext.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picVideoFrameNext.TabIndex = 2;
            this.picVideoFrameNext.TabStop = false;
            this.picVideoFrameNext.Click += new System.EventHandler(this.picVideoFrameCurrent_Click);
            // 
            // picVideoFrameCurrent
            // 
            this.picVideoFrameCurrent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.picVideoFrameCurrent.Location = new System.Drawing.Point(200, 3);
            this.picVideoFrameCurrent.Name = "picVideoFrameCurrent";
            this.picVideoFrameCurrent.Size = new System.Drawing.Size(192, 222);
            this.picVideoFrameCurrent.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picVideoFrameCurrent.TabIndex = 1;
            this.picVideoFrameCurrent.TabStop = false;
            this.picVideoFrameCurrent.Click += new System.EventHandler(this.picVideoFrameCurrent_Click);
            // 
            // txtVideoFrameCurrent
            // 
            this.txtVideoFrameCurrent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtVideoFrameCurrent.Location = new System.Drawing.Point(200, 231);
            this.txtVideoFrameCurrent.Name = "txtVideoFrameCurrent";
            this.txtVideoFrameCurrent.ReadOnly = true;
            this.txtVideoFrameCurrent.Size = new System.Drawing.Size(192, 22);
            this.txtVideoFrameCurrent.TabIndex = 3;
            this.txtVideoFrameCurrent.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtVideoFrameNext
            // 
            this.txtVideoFrameNext.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtVideoFrameNext.Location = new System.Drawing.Point(398, 231);
            this.txtVideoFrameNext.Name = "txtVideoFrameNext";
            this.txtVideoFrameNext.ReadOnly = true;
            this.txtVideoFrameNext.Size = new System.Drawing.Size(193, 22);
            this.txtVideoFrameNext.TabIndex = 5;
            this.txtVideoFrameNext.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtStatusPrevious
            // 
            this.txtStatusPrevious.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtStatusPrevious.Location = new System.Drawing.Point(3, 263);
            this.txtStatusPrevious.Name = "txtStatusPrevious";
            this.txtStatusPrevious.ReadOnly = true;
            this.txtStatusPrevious.Size = new System.Drawing.Size(191, 22);
            this.txtStatusPrevious.TabIndex = 6;
            this.txtStatusPrevious.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtStatusCurrent
            // 
            this.txtStatusCurrent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtStatusCurrent.Location = new System.Drawing.Point(200, 263);
            this.txtStatusCurrent.Name = "txtStatusCurrent";
            this.txtStatusCurrent.ReadOnly = true;
            this.txtStatusCurrent.Size = new System.Drawing.Size(192, 22);
            this.txtStatusCurrent.TabIndex = 7;
            this.txtStatusCurrent.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtStatusNext
            // 
            this.txtStatusNext.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtStatusNext.Location = new System.Drawing.Point(398, 263);
            this.txtStatusNext.Name = "txtStatusNext";
            this.txtStatusNext.ReadOnly = true;
            this.txtStatusNext.Size = new System.Drawing.Size(193, 22);
            this.txtStatusNext.TabIndex = 8;
            this.txtStatusNext.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // grpFunctions
            // 
            this.grpFunctions.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.grpFunctions.Controls.Add(this.checkUsePreview);
            this.grpFunctions.Controls.Add(this.btnUpdateProjectProperties);
            this.grpFunctions.Controls.Add(this.btnHook);
            this.grpFunctions.Controls.Add(this.checkKeepAspectRatio);
            this.grpFunctions.Controls.Add(this.btnStart);
            this.grpFunctions.Controls.Add(this.btnSaveFiles);
            this.grpFunctions.Controls.Add(this.checkAutoCommit);
            this.grpFunctions.Controls.Add(this.checkZoom);
            this.grpFunctions.Controls.Add(this.btnPreview);
            this.grpFunctions.Controls.Add(this.btnDuplicateFrame);
            this.grpFunctions.Controls.Add(this.btnDeleteFrame);
            this.grpFunctions.Location = new System.Drawing.Point(622, 3);
            this.grpFunctions.Name = "grpFunctions";
            this.grpFunctions.Size = new System.Drawing.Size(133, 351);
            this.grpFunctions.TabIndex = 1;
            this.grpFunctions.TabStop = false;
            this.grpFunctions.Text = "Functions";
            // 
            // checkUsePreview
            // 
            this.checkUsePreview.AutoSize = true;
            this.checkUsePreview.Location = new System.Drawing.Point(5, 326);
            this.checkUsePreview.Name = "checkUsePreview";
            this.checkUsePreview.Size = new System.Drawing.Size(86, 17);
            this.checkUsePreview.TabIndex = 11;
            this.checkUsePreview.Text = "Use Preview";
            this.checkUsePreview.UseVisualStyleBackColor = true;
            this.checkUsePreview.CheckedChanged += new System.EventHandler(this.checkUsePreview_CheckedChanged);
            // 
            // btnUpdateProjectProperties
            // 
            this.btnUpdateProjectProperties.Enabled = false;
            this.btnUpdateProjectProperties.Location = new System.Drawing.Point(10, 193);
            this.btnUpdateProjectProperties.Name = "btnUpdateProjectProperties";
            this.btnUpdateProjectProperties.Size = new System.Drawing.Size(113, 33);
            this.btnUpdateProjectProperties.TabIndex = 10;
            this.btnUpdateProjectProperties.Text = "Save Properties";
            this.btnUpdateProjectProperties.UseVisualStyleBackColor = true;
            this.btnUpdateProjectProperties.Click += new System.EventHandler(this.btnUpdateProjectProperties_Click);
            // 
            // btnHook
            // 
            this.btnHook.Location = new System.Drawing.Point(10, 232);
            this.btnHook.Name = "btnHook";
            this.btnHook.Size = new System.Drawing.Size(113, 33);
            this.btnHook.TabIndex = 9;
            this.btnHook.Text = "UnHook";
            this.btnHook.UseVisualStyleBackColor = true;
            this.btnHook.Click += new System.EventHandler(this.btnHook_Click);
            // 
            // checkKeepAspectRatio
            // 
            this.checkKeepAspectRatio.Location = new System.Drawing.Point(5, 270);
            this.checkKeepAspectRatio.Name = "checkKeepAspectRatio";
            this.checkKeepAspectRatio.Size = new System.Drawing.Size(131, 17);
            this.checkKeepAspectRatio.TabIndex = 7;
            this.checkKeepAspectRatio.Text = "Keep Aspect Ratio";
            this.checkKeepAspectRatio.UseVisualStyleBackColor = true;
            this.checkKeepAspectRatio.CheckedChanged += new System.EventHandler(this.checkKeepAspectRatio_CheckedChanged);
            // 
            // btnStart
            // 
            this.btnStart.Location = new System.Drawing.Point(10, 18);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(113, 33);
            this.btnStart.TabIndex = 6;
            this.btnStart.Text = "Start";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // btnSaveFiles
            // 
            this.btnSaveFiles.Enabled = false;
            this.btnSaveFiles.Location = new System.Drawing.Point(10, 160);
            this.btnSaveFiles.Name = "btnSaveFiles";
            this.btnSaveFiles.Size = new System.Drawing.Size(113, 33);
            this.btnSaveFiles.TabIndex = 5;
            this.btnSaveFiles.Text = "Save Files";
            this.btnSaveFiles.UseVisualStyleBackColor = true;
            this.btnSaveFiles.Click += new System.EventHandler(this.btnSaveFiles_Click);
            // 
            // checkAutoCommit
            // 
            this.checkAutoCommit.Enabled = false;
            this.checkAutoCommit.Location = new System.Drawing.Point(5, 307);
            this.checkAutoCommit.Name = "checkAutoCommit";
            this.checkAutoCommit.Size = new System.Drawing.Size(118, 17);
            this.checkAutoCommit.TabIndex = 4;
            this.checkAutoCommit.Text = "Auto Commit";
            this.checkAutoCommit.UseVisualStyleBackColor = true;
            // 
            // checkZoom
            // 
            this.checkZoom.Enabled = false;
            this.checkZoom.Location = new System.Drawing.Point(5, 290);
            this.checkZoom.Name = "checkZoom";
            this.checkZoom.Size = new System.Drawing.Size(116, 17);
            this.checkZoom.TabIndex = 3;
            this.checkZoom.Text = "Zoom Mode";
            this.checkZoom.UseVisualStyleBackColor = true;
            // 
            // btnPreview
            // 
            this.btnPreview.Enabled = false;
            this.btnPreview.Location = new System.Drawing.Point(10, 127);
            this.btnPreview.Name = "btnPreview";
            this.btnPreview.Size = new System.Drawing.Size(113, 33);
            this.btnPreview.TabIndex = 2;
            this.btnPreview.Text = "Preview";
            this.btnPreview.UseVisualStyleBackColor = true;
            this.btnPreview.Click += new System.EventHandler(this.btnPreview_Click);
            // 
            // btnDuplicateFrame
            // 
            this.btnDuplicateFrame.Enabled = false;
            this.btnDuplicateFrame.Location = new System.Drawing.Point(10, 89);
            this.btnDuplicateFrame.Name = "btnDuplicateFrame";
            this.btnDuplicateFrame.Size = new System.Drawing.Size(113, 33);
            this.btnDuplicateFrame.TabIndex = 1;
            this.btnDuplicateFrame.Text = "Duplicate";
            this.btnDuplicateFrame.UseVisualStyleBackColor = true;
            this.btnDuplicateFrame.Click += new System.EventHandler(this.btnDuplicate_Click);
            this.btnDuplicateFrame.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FrameRestorationForm_KeyDown);
            // 
            // btnDeleteFrame
            // 
            this.btnDeleteFrame.Enabled = false;
            this.btnDeleteFrame.Location = new System.Drawing.Point(10, 56);
            this.btnDeleteFrame.Name = "btnDeleteFrame";
            this.btnDeleteFrame.Size = new System.Drawing.Size(113, 33);
            this.btnDeleteFrame.TabIndex = 0;
            this.btnDeleteFrame.Text = "Delete";
            this.btnDeleteFrame.UseVisualStyleBackColor = true;
            this.btnDeleteFrame.Click += new System.EventHandler(this.btnDeleteFrame_Click);
            this.btnDeleteFrame.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FrameRestorationForm_KeyDown);
            // 
            // trackVideo
            // 
            this.trackVideo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.trackVideo.Location = new System.Drawing.Point(5, 17);
            this.trackVideo.Name = "trackVideo";
            this.trackVideo.Size = new System.Drawing.Size(734, 45);
            this.trackVideo.TabIndex = 2;
            this.trackVideo.ValueChanged += new System.EventHandler(this.trackVideo_ValueChanged);
            this.trackVideo.MouseDown += new System.Windows.Forms.MouseEventHandler(this.trackVideo_MouseDown);
            // 
            // lblVideoFile
            // 
            this.lblVideoFile.AutoSize = true;
            this.lblVideoFile.Location = new System.Drawing.Point(69, 8);
            this.lblVideoFile.Name = "lblVideoFile";
            this.lblVideoFile.Size = new System.Drawing.Size(59, 14);
            this.lblVideoFile.TabIndex = 3;
            this.lblVideoFile.Text = "Video File";
            // 
            // txtVideoFile
            // 
            this.txtVideoFile.AllowDrop = true;
            this.txtVideoFile.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtVideoFile.Location = new System.Drawing.Point(131, 4);
            this.txtVideoFile.Name = "txtVideoFile";
            this.txtVideoFile.Size = new System.Drawing.Size(501, 22);
            this.txtVideoFile.TabIndex = 4;
            this.txtVideoFile.DragDrop += new System.Windows.Forms.DragEventHandler(this.txtProjectFile_DragDrop);
            this.txtVideoFile.DragEnter += new System.Windows.Forms.DragEventHandler(this.txtProjectFile_DragEnter);
            // 
            // btnBrowseVideoFile
            // 
            this.btnBrowseVideoFile.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnBrowseVideoFile.Location = new System.Drawing.Point(638, 3);
            this.btnBrowseVideoFile.Name = "btnBrowseVideoFile";
            this.btnBrowseVideoFile.Size = new System.Drawing.Size(87, 25);
            this.btnBrowseVideoFile.TabIndex = 5;
            this.btnBrowseVideoFile.Text = "Browse...";
            this.btnBrowseVideoFile.UseVisualStyleBackColor = true;
            this.btnBrowseVideoFile.Click += new System.EventHandler(this.btnBrowseVideoFile_Click);
            // 
            // btnBrowseAvisynthOutputFile
            // 
            this.btnBrowseAvisynthOutputFile.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnBrowseAvisynthOutputFile.Location = new System.Drawing.Point(638, 56);
            this.btnBrowseAvisynthOutputFile.Name = "btnBrowseAvisynthOutputFile";
            this.btnBrowseAvisynthOutputFile.Size = new System.Drawing.Size(87, 25);
            this.btnBrowseAvisynthOutputFile.TabIndex = 8;
            this.btnBrowseAvisynthOutputFile.Text = "Browse...";
            this.btnBrowseAvisynthOutputFile.UseVisualStyleBackColor = true;
            this.btnBrowseAvisynthOutputFile.Click += new System.EventHandler(this.btnBrowseAvisynthOutputFile_Click);
            // 
            // txtAvisynthOutputFile
            // 
            this.txtAvisynthOutputFile.AllowDrop = true;
            this.txtAvisynthOutputFile.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtAvisynthOutputFile.Location = new System.Drawing.Point(131, 57);
            this.txtAvisynthOutputFile.Name = "txtAvisynthOutputFile";
            this.txtAvisynthOutputFile.Size = new System.Drawing.Size(501, 22);
            this.txtAvisynthOutputFile.TabIndex = 7;
            this.txtAvisynthOutputFile.DragDrop += new System.Windows.Forms.DragEventHandler(this.txtProjectFile_DragDrop);
            this.txtAvisynthOutputFile.DragEnter += new System.Windows.Forms.DragEventHandler(this.txtProjectFile_DragEnter);
            // 
            // lblAvisynthOutputFile
            // 
            this.lblAvisynthOutputFile.AutoSize = true;
            this.lblAvisynthOutputFile.Location = new System.Drawing.Point(8, 61);
            this.lblAvisynthOutputFile.Name = "lblAvisynthOutputFile";
            this.lblAvisynthOutputFile.Size = new System.Drawing.Size(120, 14);
            this.lblAvisynthOutputFile.TabIndex = 6;
            this.lblAvisynthOutputFile.Text = "AviSynth Output File";
            // 
            // btnGoToStart
            // 
            this.btnGoToStart.Location = new System.Drawing.Point(155, 65);
            this.btnGoToStart.Name = "btnGoToStart";
            this.btnGoToStart.Size = new System.Drawing.Size(36, 25);
            this.btnGoToStart.TabIndex = 32;
            this.btnGoToStart.Text = "|<";
            this.btnGoToStart.UseVisualStyleBackColor = true;
            this.btnGoToStart.Click += new System.EventHandler(this.btnGoToStart_Click);
            // 
            // btnGoToEnd
            // 
            this.btnGoToEnd.Location = new System.Drawing.Point(372, 65);
            this.btnGoToEnd.Name = "btnGoToEnd";
            this.btnGoToEnd.Size = new System.Drawing.Size(36, 25);
            this.btnGoToEnd.TabIndex = 31;
            this.btnGoToEnd.Text = ">|";
            this.btnGoToEnd.UseVisualStyleBackColor = true;
            this.btnGoToEnd.Click += new System.EventHandler(this.btnGoToEnd_Click);
            // 
            // btnPlayVideo
            // 
            this.btnPlayVideo.Location = new System.Drawing.Point(257, 65);
            this.btnPlayVideo.Name = "btnPlayVideo";
            this.btnPlayVideo.Size = new System.Drawing.Size(50, 25);
            this.btnPlayVideo.TabIndex = 30;
            this.btnPlayVideo.Text = "Play";
            this.btnPlayVideo.UseVisualStyleBackColor = true;
            this.btnPlayVideo.Click += new System.EventHandler(this.btnPlayVideo_Click);
            // 
            // btnSmallForward
            // 
            this.btnSmallForward.Location = new System.Drawing.Point(308, 65);
            this.btnSmallForward.Name = "btnSmallForward";
            this.btnSmallForward.Size = new System.Drawing.Size(24, 25);
            this.btnSmallForward.TabIndex = 29;
            this.btnSmallForward.Text = ">";
            this.btnSmallForward.UseVisualStyleBackColor = true;
            this.btnSmallForward.Click += new System.EventHandler(this.btnSmallForward_Click);
            // 
            // btnSmallBack
            // 
            this.btnSmallBack.Location = new System.Drawing.Point(231, 65);
            this.btnSmallBack.Name = "btnSmallBack";
            this.btnSmallBack.Size = new System.Drawing.Size(24, 25);
            this.btnSmallBack.TabIndex = 28;
            this.btnSmallBack.Text = "<";
            this.btnSmallBack.UseVisualStyleBackColor = true;
            this.btnSmallBack.Click += new System.EventHandler(this.btnSmallBack_Click);
            // 
            // btnForward
            // 
            this.btnForward.Location = new System.Drawing.Point(334, 65);
            this.btnForward.Name = "btnForward";
            this.btnForward.Size = new System.Drawing.Size(37, 25);
            this.btnForward.TabIndex = 27;
            this.btnForward.Text = ">>";
            this.btnForward.UseVisualStyleBackColor = true;
            this.btnForward.Click += new System.EventHandler(this.btnForward_Click);
            // 
            // btnBack
            // 
            this.btnBack.Location = new System.Drawing.Point(191, 65);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(40, 25);
            this.btnBack.TabIndex = 26;
            this.btnBack.Text = "<<";
            this.btnBack.UseVisualStyleBackColor = true;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // btnGoToFrame
            // 
            this.btnGoToFrame.Location = new System.Drawing.Point(105, 65);
            this.btnGoToFrame.Name = "btnGoToFrame";
            this.btnGoToFrame.Size = new System.Drawing.Size(50, 25);
            this.btnGoToFrame.TabIndex = 25;
            this.btnGoToFrame.Text = "Go To";
            this.btnGoToFrame.UseVisualStyleBackColor = true;
            this.btnGoToFrame.Click += new System.EventHandler(this.btnGoToFrame_Click);
            // 
            // txtFrame
            // 
            this.txtFrame.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.txtFrame.Location = new System.Drawing.Point(41, 66);
            this.txtFrame.Name = "txtFrame";
            this.txtFrame.Size = new System.Drawing.Size(62, 21);
            this.txtFrame.TabIndex = 24;
            // 
            // grpVideoControls
            // 
            this.grpVideoControls.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.grpVideoControls.Controls.Add(this.txtCurrentTime);
            this.grpVideoControls.Controls.Add(this.trackVideo);
            this.grpVideoControls.Controls.Add(this.btnGoToStart);
            this.grpVideoControls.Controls.Add(this.btnGoToFrame);
            this.grpVideoControls.Controls.Add(this.btnGoToEnd);
            this.grpVideoControls.Controls.Add(this.txtFrame);
            this.grpVideoControls.Controls.Add(this.btnPlayVideo);
            this.grpVideoControls.Controls.Add(this.btnBack);
            this.grpVideoControls.Controls.Add(this.btnSmallForward);
            this.grpVideoControls.Controls.Add(this.btnForward);
            this.grpVideoControls.Controls.Add(this.btnSmallBack);
            this.grpVideoControls.Location = new System.Drawing.Point(10, 360);
            this.grpVideoControls.Name = "grpVideoControls";
            this.grpVideoControls.Size = new System.Drawing.Size(745, 93);
            this.grpVideoControls.TabIndex = 33;
            this.grpVideoControls.TabStop = false;
            this.grpVideoControls.Text = "Video Controls";
            // 
            // txtCurrentTime
            // 
            this.txtCurrentTime.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtCurrentTime.Location = new System.Drawing.Point(425, 66);
            this.txtCurrentTime.Name = "txtCurrentTime";
            this.txtCurrentTime.ReadOnly = true;
            this.txtCurrentTime.Size = new System.Drawing.Size(310, 22);
            this.txtCurrentTime.TabIndex = 33;
            // 
            // btnBrowseProjectFile
            // 
            this.btnBrowseProjectFile.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnBrowseProjectFile.Location = new System.Drawing.Point(634, 32);
            this.btnBrowseProjectFile.Name = "btnBrowseProjectFile";
            this.btnBrowseProjectFile.Size = new System.Drawing.Size(87, 25);
            this.btnBrowseProjectFile.TabIndex = 36;
            this.btnBrowseProjectFile.Text = "Browse...";
            this.btnBrowseProjectFile.UseVisualStyleBackColor = true;
            this.btnBrowseProjectFile.Click += new System.EventHandler(this.btnBrowseProjectFile_Click);
            // 
            // txtProjectFile
            // 
            this.txtProjectFile.AllowDrop = true;
            this.txtProjectFile.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtProjectFile.Location = new System.Drawing.Point(131, 33);
            this.txtProjectFile.Name = "txtProjectFile";
            this.txtProjectFile.Size = new System.Drawing.Size(497, 22);
            this.txtProjectFile.TabIndex = 35;
            this.txtProjectFile.DragDrop += new System.Windows.Forms.DragEventHandler(this.txtProjectFile_DragDrop);
            this.txtProjectFile.DragEnter += new System.Windows.Forms.DragEventHandler(this.txtProjectFile_DragEnter);
            // 
            // lblProjectFile
            // 
            this.lblProjectFile.AutoSize = true;
            this.lblProjectFile.Location = new System.Drawing.Point(55, 37);
            this.lblProjectFile.Name = "lblProjectFile";
            this.lblProjectFile.Size = new System.Drawing.Size(67, 14);
            this.lblProjectFile.TabIndex = 34;
            this.lblProjectFile.Text = "Project File";
            // 
            // grpFiles
            // 
            this.grpFiles.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.grpFiles.Controls.Add(this.tabCtrlFiles);
            this.grpFiles.Location = new System.Drawing.Point(9, 459);
            this.grpFiles.Name = "grpFiles";
            this.grpFiles.Size = new System.Drawing.Size(746, 136);
            this.grpFiles.TabIndex = 37;
            this.grpFiles.TabStop = false;
            this.grpFiles.Text = "Files";
            // 
            // tabCtrlFiles
            // 
            this.tabCtrlFiles.Controls.Add(this.tabPageProject);
            this.tabCtrlFiles.Controls.Add(this.tabPageFiles);
            this.tabCtrlFiles.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabCtrlFiles.Location = new System.Drawing.Point(3, 18);
            this.tabCtrlFiles.Name = "tabCtrlFiles";
            this.tabCtrlFiles.SelectedIndex = 0;
            this.tabCtrlFiles.Size = new System.Drawing.Size(740, 115);
            this.tabCtrlFiles.TabIndex = 40;
            // 
            // tabPageProject
            // 
            this.tabPageProject.Controls.Add(this.btnBrowseProjectFile);
            this.tabPageProject.Controls.Add(this.lblProjectFile);
            this.tabPageProject.Controls.Add(this.txtProjectFile);
            this.tabPageProject.Location = new System.Drawing.Point(4, 23);
            this.tabPageProject.Name = "tabPageProject";
            this.tabPageProject.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageProject.Size = new System.Drawing.Size(732, 88);
            this.tabPageProject.TabIndex = 0;
            this.tabPageProject.Text = "Project";
            this.tabPageProject.UseVisualStyleBackColor = true;
            // 
            // tabPageFiles
            // 
            this.tabPageFiles.Controls.Add(this.btnBrowseVideoFile);
            this.tabPageFiles.Controls.Add(this.lblTimecodesFile);
            this.tabPageFiles.Controls.Add(this.btnBrowseAvisynthOutputFile);
            this.tabPageFiles.Controls.Add(this.txtTimecodesFile);
            this.tabPageFiles.Controls.Add(this.txtAvisynthOutputFile);
            this.tabPageFiles.Controls.Add(this.btnBrowseTimecodesFile);
            this.tabPageFiles.Controls.Add(this.lblAvisynthOutputFile);
            this.tabPageFiles.Controls.Add(this.txtVideoFile);
            this.tabPageFiles.Controls.Add(this.lblVideoFile);
            this.tabPageFiles.Location = new System.Drawing.Point(4, 23);
            this.tabPageFiles.Name = "tabPageFiles";
            this.tabPageFiles.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageFiles.Size = new System.Drawing.Size(732, 88);
            this.tabPageFiles.TabIndex = 1;
            this.tabPageFiles.Text = "Project Files";
            this.tabPageFiles.UseVisualStyleBackColor = true;
            // 
            // lblTimecodesFile
            // 
            this.lblTimecodesFile.AutoSize = true;
            this.lblTimecodesFile.Location = new System.Drawing.Point(41, 34);
            this.lblTimecodesFile.Name = "lblTimecodesFile";
            this.lblTimecodesFile.Size = new System.Drawing.Size(87, 14);
            this.lblTimecodesFile.TabIndex = 37;
            this.lblTimecodesFile.Text = "Timecodes File";
            // 
            // txtTimecodesFile
            // 
            this.txtTimecodesFile.AllowDrop = true;
            this.txtTimecodesFile.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtTimecodesFile.Location = new System.Drawing.Point(131, 30);
            this.txtTimecodesFile.Name = "txtTimecodesFile";
            this.txtTimecodesFile.Size = new System.Drawing.Size(501, 22);
            this.txtTimecodesFile.TabIndex = 38;
            this.txtTimecodesFile.DragDrop += new System.Windows.Forms.DragEventHandler(this.txtProjectFile_DragDrop);
            this.txtTimecodesFile.DragEnter += new System.Windows.Forms.DragEventHandler(this.txtProjectFile_DragDrop);
            // 
            // btnBrowseTimecodesFile
            // 
            this.btnBrowseTimecodesFile.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnBrowseTimecodesFile.Location = new System.Drawing.Point(638, 29);
            this.btnBrowseTimecodesFile.Name = "btnBrowseTimecodesFile";
            this.btnBrowseTimecodesFile.Size = new System.Drawing.Size(87, 25);
            this.btnBrowseTimecodesFile.TabIndex = 39;
            this.btnBrowseTimecodesFile.Text = "Browse...";
            this.btnBrowseTimecodesFile.UseVisualStyleBackColor = true;
            this.btnBrowseTimecodesFile.Click += new System.EventHandler(this.btnBrowseTimecodesFile_Click);
            // 
            // grpChangeList
            // 
            this.grpChangeList.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.grpChangeList.Controls.Add(this.tblChanges);
            this.grpChangeList.Location = new System.Drawing.Point(761, 3);
            this.grpChangeList.Name = "grpChangeList";
            this.grpChangeList.Size = new System.Drawing.Size(156, 592);
            this.grpChangeList.TabIndex = 38;
            this.grpChangeList.TabStop = false;
            this.grpChangeList.Text = "Change List";
            // 
            // tblChanges
            // 
            this.tblChanges.ColumnCount = 1;
            this.tblChanges.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tblChanges.Controls.Add(this.btnDeleteChange, 0, 1);
            this.tblChanges.Controls.Add(this.listChanges, 0, 0);
            this.tblChanges.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tblChanges.Location = new System.Drawing.Point(3, 18);
            this.tblChanges.Name = "tblChanges";
            this.tblChanges.RowCount = 2;
            this.tblChanges.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tblChanges.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 43F));
            this.tblChanges.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 22F));
            this.tblChanges.Size = new System.Drawing.Size(150, 571);
            this.tblChanges.TabIndex = 1;
            // 
            // btnDeleteChange
            // 
            this.btnDeleteChange.Enabled = false;
            this.btnDeleteChange.Location = new System.Drawing.Point(3, 531);
            this.btnDeleteChange.Name = "btnDeleteChange";
            this.btnDeleteChange.Size = new System.Drawing.Size(108, 37);
            this.btnDeleteChange.TabIndex = 0;
            this.btnDeleteChange.Text = "Delete Change";
            this.btnDeleteChange.UseVisualStyleBackColor = true;
            this.btnDeleteChange.Click += new System.EventHandler(this.btnDeleteChange_Click);
            // 
            // listChanges
            // 
            this.listChanges.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listChanges.FormattingEnabled = true;
            this.listChanges.HorizontalScrollbar = true;
            this.listChanges.ItemHeight = 14;
            this.listChanges.Location = new System.Drawing.Point(3, 3);
            this.listChanges.Name = "listChanges";
            this.listChanges.Size = new System.Drawing.Size(144, 522);
            this.listChanges.TabIndex = 0;
            this.listChanges.SelectedIndexChanged += new System.EventHandler(this.listChanges_SelectedIndexChanged);
            // 
            // FrameRestorationForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(924, 602);
            this.Controls.Add(this.grpChangeList);
            this.Controls.Add(this.grpFiles);
            this.Controls.Add(this.grpVideoControls);
            this.Controls.Add(this.grpFunctions);
            this.Controls.Add(this.grpVideoFrames);
            this.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.KeyPreview = true;
            this.MinimumSize = new System.Drawing.Size(940, 640);
            this.Name = "FrameRestorationForm";
            this.Text = "FrameRestorationForm";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrameRestorationForm_FormClosing);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FrameRestorationForm_KeyDown);
            this.grpVideoFrames.ResumeLayout(false);
            this.tblMainContainer.ResumeLayout(false);
            this.tblShowFrameOptions.ResumeLayout(false);
            this.tblShowFrameOptions.PerformLayout();
            this.tblVideoFrames.ResumeLayout(false);
            this.tblVideoFrames.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picVideoFramePrevious)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picVideoFrameNext)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picVideoFrameCurrent)).EndInit();
            this.grpFunctions.ResumeLayout(false);
            this.grpFunctions.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackVideo)).EndInit();
            this.grpVideoControls.ResumeLayout(false);
            this.grpVideoControls.PerformLayout();
            this.grpFiles.ResumeLayout(false);
            this.tabCtrlFiles.ResumeLayout(false);
            this.tabPageProject.ResumeLayout(false);
            this.tabPageProject.PerformLayout();
            this.tabPageFiles.ResumeLayout(false);
            this.tabPageFiles.PerformLayout();
            this.grpChangeList.ResumeLayout(false);
            this.tblChanges.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grpVideoFrames;
        private System.Windows.Forms.TableLayoutPanel tblMainContainer;
        private System.Windows.Forms.TableLayoutPanel tblShowFrameOptions;
        private System.Windows.Forms.CheckBox checkShowVideoFramePrevious;
        private System.Windows.Forms.CheckBox checkShowVideoFrameNext;
        private System.Windows.Forms.CheckBox checkShowVideoFrameCurrent;
        private System.Windows.Forms.TableLayoutPanel tblVideoFrames;
        private System.Windows.Forms.TextBox txtVideoFramePrevious;
        private AcControls.AcVideoFramePictureBox.AcVideoFramePictureBox picVideoFramePrevious;
        private AcControls.AcVideoFramePictureBox.AcVideoFramePictureBox picVideoFrameNext;
        private AcControls.AcVideoFramePictureBox.AcVideoFramePictureBox picVideoFrameCurrent;
        private System.Windows.Forms.TextBox txtVideoFrameCurrent;
        private System.Windows.Forms.TextBox txtVideoFrameNext;
        private System.Windows.Forms.TextBox txtStatusPrevious;
        private System.Windows.Forms.TextBox txtStatusCurrent;
        private System.Windows.Forms.TextBox txtStatusNext;
        private System.Windows.Forms.GroupBox grpFunctions;
        private System.Windows.Forms.Button btnSaveFiles;
        private System.Windows.Forms.CheckBox checkAutoCommit;
        private System.Windows.Forms.CheckBox checkZoom;
        private System.Windows.Forms.Button btnPreview;
        private System.Windows.Forms.Button btnDuplicateFrame;
        private System.Windows.Forms.Button btnDeleteFrame;
        private AcControls.AcVideoSlider.AcVideoSlider trackVideo;
        private System.Windows.Forms.Label lblVideoFile;
        private System.Windows.Forms.TextBox txtVideoFile;
        private System.Windows.Forms.Button btnBrowseVideoFile;
        private System.Windows.Forms.Button btnBrowseAvisynthOutputFile;
        private System.Windows.Forms.TextBox txtAvisynthOutputFile;
        private System.Windows.Forms.Label lblAvisynthOutputFile;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.Button btnGoToStart;
        private System.Windows.Forms.Button btnGoToEnd;
        private System.Windows.Forms.Button btnPlayVideo;
        private System.Windows.Forms.Button btnSmallForward;
        private System.Windows.Forms.Button btnSmallBack;
        private System.Windows.Forms.Button btnForward;
        private System.Windows.Forms.Button btnBack;
        private System.Windows.Forms.Button btnGoToFrame;
        private System.Windows.Forms.TextBox txtFrame;
        private System.Windows.Forms.GroupBox grpVideoControls;
        private System.Windows.Forms.Button btnBrowseProjectFile;
        private System.Windows.Forms.TextBox txtProjectFile;
        private System.Windows.Forms.Label lblProjectFile;
        private System.Windows.Forms.GroupBox grpFiles;
        private System.Windows.Forms.GroupBox grpChangeList;
        private System.Windows.Forms.ListBox listChanges;
        private System.Windows.Forms.CheckBox checkKeepAspectRatio;
        private System.Windows.Forms.TableLayoutPanel tblChanges;
        private System.Windows.Forms.Button btnDeleteChange;
        private System.Windows.Forms.TextBox txtCurrentTime;
        private System.Windows.Forms.Button btnHook;
        private System.Windows.Forms.Label lblTimecodesFile;
        private System.Windows.Forms.TextBox txtTimecodesFile;
        private System.Windows.Forms.Button btnBrowseTimecodesFile;
        private System.Windows.Forms.TabControl tabCtrlFiles;
        private System.Windows.Forms.TabPage tabPageProject;
        private System.Windows.Forms.TabPage tabPageFiles;
        private System.Windows.Forms.Button btnUpdateProjectProperties;
        private System.Windows.Forms.CheckBox checkUsePreview;
    }
}