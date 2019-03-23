namespace AcTools.Forms
{
    partial class frmKienzan
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
            this.txtVideoFile = new System.Windows.Forms.TextBox();
            this.txtTimecodesFile = new System.Windows.Forms.TextBox();
            this.txtDuplicatesFile = new System.Windows.Forms.TextBox();
            this.txtSectionsFile = new System.Windows.Forms.TextBox();
            this.btnBrowseVideoFile = new System.Windows.Forms.Button();
            this.btnBrowseTimecodesFile = new System.Windows.Forms.Button();
            this.btnBrowseDuplicatesFile = new System.Windows.Forms.Button();
            this.btnBrowseSectionsFile = new System.Windows.Forms.Button();
            this.btnPreviewVideo = new System.Windows.Forms.Button();
            this.btnAnalyseTimecodes = new System.Windows.Forms.Button();
            this.btnAnalyseDuplicates = new System.Windows.Forms.Button();
            this.btnEditSections = new System.Windows.Forms.Button();
            this.lblTimecodesFile = new System.Windows.Forms.Label();
            this.lblDuplicatesFile = new System.Windows.Forms.Label();
            this.lblSectionsFile = new System.Windows.Forms.Label();
            this.lblVideoFile = new System.Windows.Forms.Label();
            this.btnHook = new System.Windows.Forms.Button();
            this.listLog = new System.Windows.Forms.ListBox();
            this.grpLog = new System.Windows.Forms.GroupBox();
            this.comTargetFramerate = new System.Windows.Forms.ComboBox();
            this.lblTargetFramerate = new System.Windows.Forms.Label();
            this.progressKienzan = new System.Windows.Forms.ProgressBar();
            this.btnLoadTimecodes = new System.Windows.Forms.Button();
            this.btnLoadDuplicates = new System.Windows.Forms.Button();
            this.btnLoadSections = new System.Windows.Forms.Button();
            this.btnGenerateDuplicates = new System.Windows.Forms.Button();
            this.btnGenerateTimecodes = new System.Windows.Forms.Button();
            this.btnRunKienzan = new System.Windows.Forms.Button();
            this.btnCreateMeGUI = new System.Windows.Forms.Button();
            this.btnCreateCoolEditScript = new System.Windows.Forms.Button();
            this.btnFullyAuto = new System.Windows.Forms.Button();
            this.btnSyncAss = new System.Windows.Forms.Button();
            this.btnResetAll = new System.Windows.Forms.Button();
            this.grpInput = new System.Windows.Forms.GroupBox();
            this.txtAssFile = new System.Windows.Forms.TextBox();
            this.btnBrowseAssFile = new System.Windows.Forms.Button();
            this.lblAssFile = new System.Windows.Forms.Label();
            this.grpFunctions = new System.Windows.Forms.GroupBox();
            this.btnRunKienzanOld = new System.Windows.Forms.Button();
            this.grpLog.SuspendLayout();
            this.grpInput.SuspendLayout();
            this.grpFunctions.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtVideoFile
            // 
            this.txtVideoFile.AllowDrop = true;
            this.txtVideoFile.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtVideoFile.Location = new System.Drawing.Point(12, 37);
            this.txtVideoFile.Name = "txtVideoFile";
            this.txtVideoFile.Size = new System.Drawing.Size(399, 23);
            this.txtVideoFile.TabIndex = 0;
            this.txtVideoFile.DragDrop += new System.Windows.Forms.DragEventHandler(this.txtBox_DragDrop);
            this.txtVideoFile.DragEnter += new System.Windows.Forms.DragEventHandler(this.txtBox_DragEnter);
            // 
            // txtTimecodesFile
            // 
            this.txtTimecodesFile.AllowDrop = true;
            this.txtTimecodesFile.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtTimecodesFile.Location = new System.Drawing.Point(12, 82);
            this.txtTimecodesFile.Name = "txtTimecodesFile";
            this.txtTimecodesFile.Size = new System.Drawing.Size(399, 23);
            this.txtTimecodesFile.TabIndex = 1;
            this.txtTimecodesFile.DragDrop += new System.Windows.Forms.DragEventHandler(this.txtBox_DragDrop);
            this.txtTimecodesFile.DragEnter += new System.Windows.Forms.DragEventHandler(this.txtBox_DragEnter);
            // 
            // txtDuplicatesFile
            // 
            this.txtDuplicatesFile.AllowDrop = true;
            this.txtDuplicatesFile.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDuplicatesFile.Location = new System.Drawing.Point(12, 126);
            this.txtDuplicatesFile.Name = "txtDuplicatesFile";
            this.txtDuplicatesFile.Size = new System.Drawing.Size(399, 23);
            this.txtDuplicatesFile.TabIndex = 2;
            this.txtDuplicatesFile.DragDrop += new System.Windows.Forms.DragEventHandler(this.txtBox_DragDrop);
            this.txtDuplicatesFile.DragEnter += new System.Windows.Forms.DragEventHandler(this.txtBox_DragEnter);
            // 
            // txtSectionsFile
            // 
            this.txtSectionsFile.AllowDrop = true;
            this.txtSectionsFile.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSectionsFile.Location = new System.Drawing.Point(12, 170);
            this.txtSectionsFile.Name = "txtSectionsFile";
            this.txtSectionsFile.Size = new System.Drawing.Size(399, 23);
            this.txtSectionsFile.TabIndex = 3;
            this.txtSectionsFile.DragDrop += new System.Windows.Forms.DragEventHandler(this.txtBox_DragDrop);
            this.txtSectionsFile.DragEnter += new System.Windows.Forms.DragEventHandler(this.txtBox_DragEnter);
            // 
            // btnBrowseVideoFile
            // 
            this.btnBrowseVideoFile.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnBrowseVideoFile.Location = new System.Drawing.Point(417, 33);
            this.btnBrowseVideoFile.Name = "btnBrowseVideoFile";
            this.btnBrowseVideoFile.Size = new System.Drawing.Size(72, 31);
            this.btnBrowseVideoFile.TabIndex = 5;
            this.btnBrowseVideoFile.Text = "Browse...";
            this.btnBrowseVideoFile.UseVisualStyleBackColor = true;
            this.btnBrowseVideoFile.Click += new System.EventHandler(this.btnBrowseVideoFile_Click);
            // 
            // btnBrowseTimecodesFile
            // 
            this.btnBrowseTimecodesFile.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnBrowseTimecodesFile.Location = new System.Drawing.Point(417, 77);
            this.btnBrowseTimecodesFile.Name = "btnBrowseTimecodesFile";
            this.btnBrowseTimecodesFile.Size = new System.Drawing.Size(72, 31);
            this.btnBrowseTimecodesFile.TabIndex = 6;
            this.btnBrowseTimecodesFile.Text = "Browse...";
            this.btnBrowseTimecodesFile.UseVisualStyleBackColor = true;
            this.btnBrowseTimecodesFile.Click += new System.EventHandler(this.btnBrowseTimecodesFile_Click);
            // 
            // btnBrowseDuplicatesFile
            // 
            this.btnBrowseDuplicatesFile.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnBrowseDuplicatesFile.Location = new System.Drawing.Point(417, 121);
            this.btnBrowseDuplicatesFile.Name = "btnBrowseDuplicatesFile";
            this.btnBrowseDuplicatesFile.Size = new System.Drawing.Size(72, 31);
            this.btnBrowseDuplicatesFile.TabIndex = 7;
            this.btnBrowseDuplicatesFile.Text = "Browse...";
            this.btnBrowseDuplicatesFile.UseVisualStyleBackColor = true;
            this.btnBrowseDuplicatesFile.Click += new System.EventHandler(this.btnBrowseDuplicatesFile_Click);
            // 
            // btnBrowseSectionsFile
            // 
            this.btnBrowseSectionsFile.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnBrowseSectionsFile.Location = new System.Drawing.Point(417, 165);
            this.btnBrowseSectionsFile.Name = "btnBrowseSectionsFile";
            this.btnBrowseSectionsFile.Size = new System.Drawing.Size(72, 31);
            this.btnBrowseSectionsFile.TabIndex = 8;
            this.btnBrowseSectionsFile.Text = "Browse...";
            this.btnBrowseSectionsFile.UseVisualStyleBackColor = true;
            this.btnBrowseSectionsFile.Click += new System.EventHandler(this.btnBrowseSectionsFile_Click);
            // 
            // btnPreviewVideo
            // 
            this.btnPreviewVideo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPreviewVideo.Location = new System.Drawing.Point(494, 33);
            this.btnPreviewVideo.Name = "btnPreviewVideo";
            this.btnPreviewVideo.Size = new System.Drawing.Size(64, 31);
            this.btnPreviewVideo.TabIndex = 9;
            this.btnPreviewVideo.Text = "Preview";
            this.btnPreviewVideo.UseVisualStyleBackColor = true;
            this.btnPreviewVideo.Click += new System.EventHandler(this.btnPreviewVideo_Click);
            // 
            // btnAnalyseTimecodes
            // 
            this.btnAnalyseTimecodes.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAnalyseTimecodes.Location = new System.Drawing.Point(642, 77);
            this.btnAnalyseTimecodes.Name = "btnAnalyseTimecodes";
            this.btnAnalyseTimecodes.Size = new System.Drawing.Size(73, 31);
            this.btnAnalyseTimecodes.TabIndex = 10;
            this.btnAnalyseTimecodes.Text = "Analyse";
            this.btnAnalyseTimecodes.UseVisualStyleBackColor = true;
            this.btnAnalyseTimecodes.Click += new System.EventHandler(this.btnAnalyseTimecodes_Click);
            // 
            // btnAnalyseDuplicates
            // 
            this.btnAnalyseDuplicates.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAnalyseDuplicates.Location = new System.Drawing.Point(642, 121);
            this.btnAnalyseDuplicates.Name = "btnAnalyseDuplicates";
            this.btnAnalyseDuplicates.Size = new System.Drawing.Size(73, 31);
            this.btnAnalyseDuplicates.TabIndex = 11;
            this.btnAnalyseDuplicates.Text = "Analyse";
            this.btnAnalyseDuplicates.UseVisualStyleBackColor = true;
            this.btnAnalyseDuplicates.Click += new System.EventHandler(this.btnPreviewDuplicates_Click);
            // 
            // btnEditSections
            // 
            this.btnEditSections.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnEditSections.Location = new System.Drawing.Point(564, 165);
            this.btnEditSections.Name = "btnEditSections";
            this.btnEditSections.Size = new System.Drawing.Size(73, 31);
            this.btnEditSections.TabIndex = 12;
            this.btnEditSections.Text = "Edit";
            this.btnEditSections.UseVisualStyleBackColor = true;
            this.btnEditSections.Click += new System.EventHandler(this.btnPreviewSections_Click);
            // 
            // lblTimecodesFile
            // 
            this.lblTimecodesFile.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTimecodesFile.AutoSize = true;
            this.lblTimecodesFile.Location = new System.Drawing.Point(9, 65);
            this.lblTimecodesFile.Name = "lblTimecodesFile";
            this.lblTimecodesFile.Size = new System.Drawing.Size(86, 15);
            this.lblTimecodesFile.TabIndex = 24;
            this.lblTimecodesFile.Text = "Timecodes File";
            // 
            // lblDuplicatesFile
            // 
            this.lblDuplicatesFile.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblDuplicatesFile.AutoSize = true;
            this.lblDuplicatesFile.Location = new System.Drawing.Point(9, 108);
            this.lblDuplicatesFile.Name = "lblDuplicatesFile";
            this.lblDuplicatesFile.Size = new System.Drawing.Size(83, 15);
            this.lblDuplicatesFile.TabIndex = 25;
            this.lblDuplicatesFile.Text = "Duplicates File";
            // 
            // lblSectionsFile
            // 
            this.lblSectionsFile.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblSectionsFile.AutoSize = true;
            this.lblSectionsFile.Location = new System.Drawing.Point(9, 152);
            this.lblSectionsFile.Name = "lblSectionsFile";
            this.lblSectionsFile.Size = new System.Drawing.Size(72, 15);
            this.lblSectionsFile.TabIndex = 26;
            this.lblSectionsFile.Text = "Sections File";
            // 
            // lblVideoFile
            // 
            this.lblVideoFile.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblVideoFile.AutoSize = true;
            this.lblVideoFile.Location = new System.Drawing.Point(9, 21);
            this.lblVideoFile.Name = "lblVideoFile";
            this.lblVideoFile.Size = new System.Drawing.Size(58, 15);
            this.lblVideoFile.TabIndex = 27;
            this.lblVideoFile.Text = "Video File";
            // 
            // btnHook
            // 
            this.btnHook.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnHook.Location = new System.Drawing.Point(661, 486);
            this.btnHook.Name = "btnHook";
            this.btnHook.Size = new System.Drawing.Size(73, 31);
            this.btnHook.TabIndex = 28;
            this.btnHook.Text = "UnHook";
            this.btnHook.UseVisualStyleBackColor = true;
            this.btnHook.Click += new System.EventHandler(this.btnHook_Click);
            // 
            // listLog
            // 
            this.listLog.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listLog.FormattingEnabled = true;
            this.listLog.ItemHeight = 15;
            this.listLog.Location = new System.Drawing.Point(3, 19);
            this.listLog.Name = "listLog";
            this.listLog.Size = new System.Drawing.Size(716, 65);
            this.listLog.TabIndex = 30;
            // 
            // grpLog
            // 
            this.grpLog.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grpLog.Controls.Add(this.listLog);
            this.grpLog.Location = new System.Drawing.Point(5, 392);
            this.grpLog.Name = "grpLog";
            this.grpLog.Size = new System.Drawing.Size(722, 87);
            this.grpLog.TabIndex = 31;
            this.grpLog.TabStop = false;
            this.grpLog.Text = "Mini Log";
            // 
            // comTargetFramerate
            // 
            this.comTargetFramerate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.comTargetFramerate.FormattingEnabled = true;
            this.comTargetFramerate.Location = new System.Drawing.Point(290, 250);
            this.comTargetFramerate.Name = "comTargetFramerate";
            this.comTargetFramerate.Size = new System.Drawing.Size(121, 23);
            this.comTargetFramerate.TabIndex = 32;
            // 
            // lblTargetFramerate
            // 
            this.lblTargetFramerate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTargetFramerate.AutoSize = true;
            this.lblTargetFramerate.Location = new System.Drawing.Point(130, 254);
            this.lblTargetFramerate.Name = "lblTargetFramerate";
            this.lblTargetFramerate.Size = new System.Drawing.Size(148, 15);
            this.lblTargetFramerate.TabIndex = 33;
            this.lblTargetFramerate.Text = "Target Constant Framerate";
            // 
            // progressKienzan
            // 
            this.progressKienzan.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.progressKienzan.Location = new System.Drawing.Point(8, 487);
            this.progressKienzan.Name = "progressKienzan";
            this.progressKienzan.Size = new System.Drawing.Size(650, 28);
            this.progressKienzan.TabIndex = 37;
            // 
            // btnLoadTimecodes
            // 
            this.btnLoadTimecodes.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnLoadTimecodes.Location = new System.Drawing.Point(494, 77);
            this.btnLoadTimecodes.Name = "btnLoadTimecodes";
            this.btnLoadTimecodes.Size = new System.Drawing.Size(64, 31);
            this.btnLoadTimecodes.TabIndex = 38;
            this.btnLoadTimecodes.Text = "Load";
            this.btnLoadTimecodes.UseVisualStyleBackColor = true;
            this.btnLoadTimecodes.Click += new System.EventHandler(this.btnLoadTimecodes_Click);
            // 
            // btnLoadDuplicates
            // 
            this.btnLoadDuplicates.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnLoadDuplicates.Location = new System.Drawing.Point(494, 121);
            this.btnLoadDuplicates.Name = "btnLoadDuplicates";
            this.btnLoadDuplicates.Size = new System.Drawing.Size(64, 31);
            this.btnLoadDuplicates.TabIndex = 39;
            this.btnLoadDuplicates.Text = "Load";
            this.btnLoadDuplicates.UseVisualStyleBackColor = true;
            this.btnLoadDuplicates.Click += new System.EventHandler(this.btnLoadDuplicates_Click);
            // 
            // btnLoadSections
            // 
            this.btnLoadSections.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnLoadSections.Location = new System.Drawing.Point(494, 165);
            this.btnLoadSections.Name = "btnLoadSections";
            this.btnLoadSections.Size = new System.Drawing.Size(64, 31);
            this.btnLoadSections.TabIndex = 40;
            this.btnLoadSections.Text = "Load";
            this.btnLoadSections.UseVisualStyleBackColor = true;
            this.btnLoadSections.Click += new System.EventHandler(this.btnLoadSections_Click);
            // 
            // btnGenerateDuplicates
            // 
            this.btnGenerateDuplicates.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnGenerateDuplicates.Location = new System.Drawing.Point(564, 121);
            this.btnGenerateDuplicates.Name = "btnGenerateDuplicates";
            this.btnGenerateDuplicates.Size = new System.Drawing.Size(73, 31);
            this.btnGenerateDuplicates.TabIndex = 42;
            this.btnGenerateDuplicates.Text = "Generate";
            this.btnGenerateDuplicates.UseVisualStyleBackColor = true;
            this.btnGenerateDuplicates.Click += new System.EventHandler(this.btnGenerateDuplicates_Click);
            // 
            // btnGenerateTimecodes
            // 
            this.btnGenerateTimecodes.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnGenerateTimecodes.Location = new System.Drawing.Point(564, 77);
            this.btnGenerateTimecodes.Name = "btnGenerateTimecodes";
            this.btnGenerateTimecodes.Size = new System.Drawing.Size(73, 31);
            this.btnGenerateTimecodes.TabIndex = 41;
            this.btnGenerateTimecodes.Text = "Generate";
            this.btnGenerateTimecodes.UseVisualStyleBackColor = true;
            this.btnGenerateTimecodes.Click += new System.EventHandler(this.btnGenerateTimecodes_Click);
            // 
            // btnRunKienzan
            // 
            this.btnRunKienzan.Location = new System.Drawing.Point(10, 28);
            this.btnRunKienzan.Name = "btnRunKienzan";
            this.btnRunKienzan.Size = new System.Drawing.Size(90, 40);
            this.btnRunKienzan.TabIndex = 43;
            this.btnRunKienzan.Text = "Run Kienzan!";
            this.btnRunKienzan.UseVisualStyleBackColor = true;
            this.btnRunKienzan.Click += new System.EventHandler(this.btnRunKienzan_Click);
            // 
            // btnCreateMeGUI
            // 
            this.btnCreateMeGUI.Location = new System.Drawing.Point(114, 28);
            this.btnCreateMeGUI.Name = "btnCreateMeGUI";
            this.btnCreateMeGUI.Size = new System.Drawing.Size(90, 40);
            this.btnCreateMeGUI.TabIndex = 44;
            this.btnCreateMeGUI.Text = "Create MeGUI Cut File";
            this.btnCreateMeGUI.UseVisualStyleBackColor = true;
            this.btnCreateMeGUI.Click += new System.EventHandler(this.btnCreateMeGUI_Click);
            // 
            // btnCreateCoolEditScript
            // 
            this.btnCreateCoolEditScript.Location = new System.Drawing.Point(217, 28);
            this.btnCreateCoolEditScript.Name = "btnCreateCoolEditScript";
            this.btnCreateCoolEditScript.Size = new System.Drawing.Size(90, 40);
            this.btnCreateCoolEditScript.TabIndex = 45;
            this.btnCreateCoolEditScript.Text = "Create Audio Cut Script";
            this.btnCreateCoolEditScript.UseVisualStyleBackColor = true;
            this.btnCreateCoolEditScript.Click += new System.EventHandler(this.btnCreateCoolEditScript_Click);
            // 
            // btnFullyAuto
            // 
            this.btnFullyAuto.Location = new System.Drawing.Point(423, 28);
            this.btnFullyAuto.Name = "btnFullyAuto";
            this.btnFullyAuto.Size = new System.Drawing.Size(90, 40);
            this.btnFullyAuto.TabIndex = 46;
            this.btnFullyAuto.Text = "Fully Auto!";
            this.btnFullyAuto.UseVisualStyleBackColor = true;
            this.btnFullyAuto.Click += new System.EventHandler(this.btnFullyAuto_Click);
            // 
            // btnSyncAss
            // 
            this.btnSyncAss.Location = new System.Drawing.Point(321, 28);
            this.btnSyncAss.Name = "btnSyncAss";
            this.btnSyncAss.Size = new System.Drawing.Size(90, 40);
            this.btnSyncAss.TabIndex = 47;
            this.btnSyncAss.Text = "Sync Subtitles (ASS)";
            this.btnSyncAss.UseVisualStyleBackColor = true;
            this.btnSyncAss.Click += new System.EventHandler(this.btnSyncAss_Click);
            // 
            // btnResetAll
            // 
            this.btnResetAll.Location = new System.Drawing.Point(523, 28);
            this.btnResetAll.Name = "btnResetAll";
            this.btnResetAll.Size = new System.Drawing.Size(90, 40);
            this.btnResetAll.TabIndex = 48;
            this.btnResetAll.Text = "Reset All";
            this.btnResetAll.UseVisualStyleBackColor = true;
            this.btnResetAll.Click += new System.EventHandler(this.btnResetAll_Click);
            // 
            // grpInput
            // 
            this.grpInput.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grpInput.Controls.Add(this.txtAssFile);
            this.grpInput.Controls.Add(this.btnBrowseAssFile);
            this.grpInput.Controls.Add(this.lblAssFile);
            this.grpInput.Controls.Add(this.lblVideoFile);
            this.grpInput.Controls.Add(this.txtVideoFile);
            this.grpInput.Controls.Add(this.txtTimecodesFile);
            this.grpInput.Controls.Add(this.txtDuplicatesFile);
            this.grpInput.Controls.Add(this.txtSectionsFile);
            this.grpInput.Controls.Add(this.btnBrowseVideoFile);
            this.grpInput.Controls.Add(this.btnBrowseTimecodesFile);
            this.grpInput.Controls.Add(this.btnGenerateDuplicates);
            this.grpInput.Controls.Add(this.btnBrowseDuplicatesFile);
            this.grpInput.Controls.Add(this.btnGenerateTimecodes);
            this.grpInput.Controls.Add(this.btnBrowseSectionsFile);
            this.grpInput.Controls.Add(this.btnLoadSections);
            this.grpInput.Controls.Add(this.btnPreviewVideo);
            this.grpInput.Controls.Add(this.btnLoadDuplicates);
            this.grpInput.Controls.Add(this.btnAnalyseTimecodes);
            this.grpInput.Controls.Add(this.btnLoadTimecodes);
            this.grpInput.Controls.Add(this.btnAnalyseDuplicates);
            this.grpInput.Controls.Add(this.btnEditSections);
            this.grpInput.Controls.Add(this.lblTargetFramerate);
            this.grpInput.Controls.Add(this.lblTimecodesFile);
            this.grpInput.Controls.Add(this.comTargetFramerate);
            this.grpInput.Controls.Add(this.lblDuplicatesFile);
            this.grpInput.Controls.Add(this.lblSectionsFile);
            this.grpInput.Location = new System.Drawing.Point(5, 13);
            this.grpInput.Name = "grpInput";
            this.grpInput.Size = new System.Drawing.Size(722, 286);
            this.grpInput.TabIndex = 49;
            this.grpInput.TabStop = false;
            this.grpInput.Text = "Input";
            // 
            // txtAssFile
            // 
            this.txtAssFile.AllowDrop = true;
            this.txtAssFile.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtAssFile.Location = new System.Drawing.Point(12, 213);
            this.txtAssFile.Name = "txtAssFile";
            this.txtAssFile.Size = new System.Drawing.Size(399, 23);
            this.txtAssFile.TabIndex = 43;
            this.txtAssFile.DragDrop += new System.Windows.Forms.DragEventHandler(this.txtBox_DragDrop);
            this.txtAssFile.DragEnter += new System.Windows.Forms.DragEventHandler(this.txtBox_DragEnter);
            // 
            // btnBrowseAssFile
            // 
            this.btnBrowseAssFile.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnBrowseAssFile.Location = new System.Drawing.Point(417, 209);
            this.btnBrowseAssFile.Name = "btnBrowseAssFile";
            this.btnBrowseAssFile.Size = new System.Drawing.Size(72, 31);
            this.btnBrowseAssFile.TabIndex = 44;
            this.btnBrowseAssFile.Text = "Browse...";
            this.btnBrowseAssFile.UseVisualStyleBackColor = true;
            this.btnBrowseAssFile.Click += new System.EventHandler(this.btnBrowseAssFile_Click);
            // 
            // lblAssFile
            // 
            this.lblAssFile.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblAssFile.AutoSize = true;
            this.lblAssFile.Location = new System.Drawing.Point(9, 196);
            this.lblAssFile.Name = "lblAssFile";
            this.lblAssFile.Size = new System.Drawing.Size(46, 15);
            this.lblAssFile.TabIndex = 45;
            this.lblAssFile.Text = "Ass File";
            // 
            // grpFunctions
            // 
            this.grpFunctions.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grpFunctions.Controls.Add(this.btnRunKienzanOld);
            this.grpFunctions.Controls.Add(this.btnRunKienzan);
            this.grpFunctions.Controls.Add(this.btnCreateMeGUI);
            this.grpFunctions.Controls.Add(this.btnResetAll);
            this.grpFunctions.Controls.Add(this.btnCreateCoolEditScript);
            this.grpFunctions.Controls.Add(this.btnSyncAss);
            this.grpFunctions.Controls.Add(this.btnFullyAuto);
            this.grpFunctions.Location = new System.Drawing.Point(6, 306);
            this.grpFunctions.Name = "grpFunctions";
            this.grpFunctions.Size = new System.Drawing.Size(721, 83);
            this.grpFunctions.TabIndex = 50;
            this.grpFunctions.TabStop = false;
            this.grpFunctions.Text = "Functions";
            // 
            // btnRunKienzanOld
            // 
            this.btnRunKienzanOld.Location = new System.Drawing.Point(623, 28);
            this.btnRunKienzanOld.Name = "btnRunKienzanOld";
            this.btnRunKienzanOld.Size = new System.Drawing.Size(90, 40);
            this.btnRunKienzanOld.TabIndex = 49;
            this.btnRunKienzanOld.Text = "Run Old Kienzan!";
            this.btnRunKienzanOld.UseVisualStyleBackColor = true;
            this.btnRunKienzanOld.Click += new System.EventHandler(this.btnRunKienzanOld_Click);
            // 
            // KienzanForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(734, 521);
            this.Controls.Add(this.grpFunctions);
            this.Controls.Add(this.grpInput);
            this.Controls.Add(this.progressKienzan);
            this.Controls.Add(this.grpLog);
            this.Controls.Add(this.btnHook);
            this.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.MinimumSize = new System.Drawing.Size(750, 560);
            this.Name = "KienzanForm";
            this.Text = "KienzanForm";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.KienzanForm_FormClosing);
            this.grpLog.ResumeLayout(false);
            this.grpInput.ResumeLayout(false);
            this.grpInput.PerformLayout();
            this.grpFunctions.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox txtVideoFile;
        private System.Windows.Forms.TextBox txtTimecodesFile;
        private System.Windows.Forms.TextBox txtDuplicatesFile;
        private System.Windows.Forms.TextBox txtSectionsFile;
        private System.Windows.Forms.Button btnBrowseVideoFile;
        private System.Windows.Forms.Button btnBrowseTimecodesFile;
        private System.Windows.Forms.Button btnBrowseDuplicatesFile;
        private System.Windows.Forms.Button btnBrowseSectionsFile;
        private System.Windows.Forms.Button btnPreviewVideo;
        private System.Windows.Forms.Button btnAnalyseTimecodes;
        private System.Windows.Forms.Button btnAnalyseDuplicates;
        private System.Windows.Forms.Button btnEditSections;
        private System.Windows.Forms.Label lblTimecodesFile;
        private System.Windows.Forms.Label lblDuplicatesFile;
        private System.Windows.Forms.Label lblSectionsFile;
        private System.Windows.Forms.Label lblVideoFile;
        private System.Windows.Forms.Button btnHook;
        private System.Windows.Forms.ListBox listLog;
        private System.Windows.Forms.GroupBox grpLog;
        private System.Windows.Forms.ComboBox comTargetFramerate;
        private System.Windows.Forms.Label lblTargetFramerate;
        private System.Windows.Forms.ProgressBar progressKienzan;
        private System.Windows.Forms.Button btnLoadTimecodes;
        private System.Windows.Forms.Button btnLoadDuplicates;
        private System.Windows.Forms.Button btnLoadSections;
        private System.Windows.Forms.Button btnGenerateDuplicates;
        private System.Windows.Forms.Button btnGenerateTimecodes;
        private System.Windows.Forms.Button btnRunKienzan;
        private System.Windows.Forms.Button btnCreateMeGUI;
        private System.Windows.Forms.Button btnCreateCoolEditScript;
        private System.Windows.Forms.Button btnFullyAuto;
        private System.Windows.Forms.Button btnSyncAss;
        private System.Windows.Forms.Button btnResetAll;
        private System.Windows.Forms.GroupBox grpInput;
        private System.Windows.Forms.GroupBox grpFunctions;
        private System.Windows.Forms.TextBox txtAssFile;
        private System.Windows.Forms.Button btnBrowseAssFile;
        private System.Windows.Forms.Label lblAssFile;
        private System.Windows.Forms.Button btnRunKienzanOld;
    }
}