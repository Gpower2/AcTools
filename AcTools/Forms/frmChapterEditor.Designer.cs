namespace AcTools.Forms
{
    partial class frmChapterEditor
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
            this.lstChapters = new System.Windows.Forms.ListBox();
            this.txtName = new System.Windows.Forms.TextBox();
            this.lblStartTime = new System.Windows.Forms.Label();
            this.lblEndTime = new System.Windows.Forms.Label();
            this.lblName = new System.Windows.Forms.Label();
            this.btnAddChapter = new System.Windows.Forms.Button();
            this.btnRemoveChapter = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.btnLoad = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.cmbLanguage = new System.Windows.Forms.ComboBox();
            this.lblLanguage = new System.Windows.Forms.Label();
            this.cmbCountry = new System.Windows.Forms.ComboBox();
            this.lblCountry = new System.Windows.Forms.Label();
            this.lblUID = new System.Windows.Forms.Label();
            this.btnUpdateChapter = new System.Windows.Forms.Button();
            this.grpChapterList = new System.Windows.Forms.GroupBox();
            this.tlpChapterListMain = new System.Windows.Forms.TableLayoutPanel();
            this.tlpChapterListFunctions = new System.Windows.Forms.TableLayoutPanel();
            this.btnFromSectionsFile = new System.Windows.Forms.Button();
            this.grpCommon = new System.Windows.Forms.GroupBox();
            this.tlpChapterDetailsCommon = new System.Windows.Forms.TableLayoutPanel();
            this.pnlChapterDetailsCommonFunctions = new System.Windows.Forms.Panel();
            this.btnUseVideo = new System.Windows.Forms.Button();
            this.pnlChapterDetailsCommonEnd = new System.Windows.Forms.Panel();
            this.btnFromVideoEnd = new System.Windows.Forms.Button();
            this.txtEndTime = new System.Windows.Forms.MaskedTextBox();
            this.pnlChapterDetailsCommonStart = new System.Windows.Forms.Panel();
            this.btnFromVideoStart = new System.Windows.Forms.Button();
            this.txtStartTime = new System.Windows.Forms.MaskedTextBox();
            this.pnlChapterDetailsCommonName = new System.Windows.Forms.Panel();
            this.grpXMLOnly = new System.Windows.Forms.GroupBox();
            this.tlpChapterDetailsXml = new System.Windows.Forms.TableLayoutPanel();
            this.pnlChapterDetailsXmlUid = new System.Windows.Forms.Panel();
            this.btnChapterUidAuto = new System.Windows.Forms.Button();
            this.chkHidden = new System.Windows.Forms.CheckBox();
            this.txtUID = new System.Windows.Forms.MaskedTextBox();
            this.chkEnabled = new System.Windows.Forms.CheckBox();
            this.grpLanguage = new System.Windows.Forms.GroupBox();
            this.tlpChapterDetailsNamesLanguagesMain = new System.Windows.Forms.TableLayoutPanel();
            this.pnlChapterDetailsXmlName = new System.Windows.Forms.Panel();
            this.txtNameLanguage = new System.Windows.Forms.TextBox();
            this.lblNameLanguage = new System.Windows.Forms.Label();
            this.pnlChapterDetailsXmlLanguage = new System.Windows.Forms.Panel();
            this.btnNoLanguage = new System.Windows.Forms.Button();
            this.pnlChapterDetailsXmlCountry = new System.Windows.Forms.Panel();
            this.btnNoCountry = new System.Windows.Forms.Button();
            this.tlpLanguageListMain = new System.Windows.Forms.TableLayoutPanel();
            this.lstLanguages = new System.Windows.Forms.ListBox();
            this.tlpLanguageListFunctions = new System.Windows.Forms.TableLayoutPanel();
            this.btnRemoveLanguage = new System.Windows.Forms.Button();
            this.btnUpdateLanguage = new System.Windows.Forms.Button();
            this.btnAddLanguage = new System.Windows.Forms.Button();
            this.grpChapterInfo = new System.Windows.Forms.GroupBox();
            this.tlpChapterDetailsMain = new System.Windows.Forms.TableLayoutPanel();
            this.tlpChapterDetailsFunctions = new System.Windows.Forms.TableLayoutPanel();
            this.btnHook = new System.Windows.Forms.Button();
            this.tlpMain = new System.Windows.Forms.TableLayoutPanel();
            this.grpHook = new System.Windows.Forms.GroupBox();
            this.grpChapterList.SuspendLayout();
            this.tlpChapterListMain.SuspendLayout();
            this.tlpChapterListFunctions.SuspendLayout();
            this.grpCommon.SuspendLayout();
            this.tlpChapterDetailsCommon.SuspendLayout();
            this.pnlChapterDetailsCommonFunctions.SuspendLayout();
            this.pnlChapterDetailsCommonEnd.SuspendLayout();
            this.pnlChapterDetailsCommonStart.SuspendLayout();
            this.pnlChapterDetailsCommonName.SuspendLayout();
            this.grpXMLOnly.SuspendLayout();
            this.tlpChapterDetailsXml.SuspendLayout();
            this.pnlChapterDetailsXmlUid.SuspendLayout();
            this.grpLanguage.SuspendLayout();
            this.tlpChapterDetailsNamesLanguagesMain.SuspendLayout();
            this.pnlChapterDetailsXmlName.SuspendLayout();
            this.pnlChapterDetailsXmlLanguage.SuspendLayout();
            this.pnlChapterDetailsXmlCountry.SuspendLayout();
            this.tlpLanguageListMain.SuspendLayout();
            this.tlpLanguageListFunctions.SuspendLayout();
            this.grpChapterInfo.SuspendLayout();
            this.tlpChapterDetailsMain.SuspendLayout();
            this.tlpChapterDetailsFunctions.SuspendLayout();
            this.tlpMain.SuspendLayout();
            this.grpHook.SuspendLayout();
            this.SuspendLayout();
            // 
            // lstChapters
            // 
            this.lstChapters.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lstChapters.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.lstChapters.FormattingEnabled = true;
            this.lstChapters.ItemHeight = 14;
            this.lstChapters.Location = new System.Drawing.Point(3, 3);
            this.lstChapters.Name = "lstChapters";
            this.lstChapters.Size = new System.Drawing.Size(649, 163);
            this.lstChapters.TabIndex = 0;
            this.lstChapters.SelectedIndexChanged += new System.EventHandler(this.listChapters_SelectedIndexChanged);
            // 
            // txtName
            // 
            this.txtName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtName.Location = new System.Drawing.Point(69, 13);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(195, 23);
            this.txtName.TabIndex = 3;
            // 
            // lblStartTime
            // 
            this.lblStartTime.AutoSize = true;
            this.lblStartTime.Location = new System.Drawing.Point(3, 16);
            this.lblStartTime.Name = "lblStartTime";
            this.lblStartTime.Size = new System.Drawing.Size(58, 15);
            this.lblStartTime.TabIndex = 4;
            this.lblStartTime.Text = "StartTime";
            // 
            // lblEndTime
            // 
            this.lblEndTime.AutoSize = true;
            this.lblEndTime.Location = new System.Drawing.Point(10, 16);
            this.lblEndTime.Name = "lblEndTime";
            this.lblEndTime.Size = new System.Drawing.Size(54, 15);
            this.lblEndTime.TabIndex = 5;
            this.lblEndTime.Text = "EndTime";
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Location = new System.Drawing.Point(26, 16);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(39, 15);
            this.lblName.TabIndex = 6;
            this.lblName.Text = "Name";
            // 
            // btnAddChapter
            // 
            this.btnAddChapter.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnAddChapter.Location = new System.Drawing.Point(3, 3);
            this.btnAddChapter.Name = "btnAddChapter";
            this.btnAddChapter.Size = new System.Drawing.Size(109, 46);
            this.btnAddChapter.TabIndex = 7;
            this.btnAddChapter.Text = "Add Chapter";
            this.btnAddChapter.UseVisualStyleBackColor = true;
            this.btnAddChapter.Click += new System.EventHandler(this.btnAddChapter_Click);
            // 
            // btnRemoveChapter
            // 
            this.btnRemoveChapter.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnRemoveChapter.Location = new System.Drawing.Point(3, 3);
            this.btnRemoveChapter.Name = "btnRemoveChapter";
            this.btnRemoveChapter.Size = new System.Drawing.Size(105, 26);
            this.btnRemoveChapter.TabIndex = 8;
            this.btnRemoveChapter.Text = "Remove Chapter";
            this.btnRemoveChapter.UseVisualStyleBackColor = true;
            this.btnRemoveChapter.Click += new System.EventHandler(this.btnRemoveChapter_Click);
            // 
            // btnClear
            // 
            this.btnClear.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnClear.Location = new System.Drawing.Point(3, 35);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(105, 26);
            this.btnClear.TabIndex = 9;
            this.btnClear.Text = "Clear";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // btnLoad
            // 
            this.btnLoad.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnLoad.Location = new System.Drawing.Point(3, 99);
            this.btnLoad.Name = "btnLoad";
            this.btnLoad.Size = new System.Drawing.Size(105, 26);
            this.btnLoad.TabIndex = 10;
            this.btnLoad.Text = "Load...";
            this.btnLoad.UseVisualStyleBackColor = true;
            this.btnLoad.Click += new System.EventHandler(this.btnLoad_Click);
            // 
            // btnSave
            // 
            this.btnSave.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnSave.Location = new System.Drawing.Point(3, 131);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(105, 29);
            this.btnSave.TabIndex = 11;
            this.btnSave.Text = "Save...";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // cmbLanguage
            // 
            this.cmbLanguage.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbLanguage.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbLanguage.FormattingEnabled = true;
            this.cmbLanguage.Location = new System.Drawing.Point(83, 5);
            this.cmbLanguage.Name = "cmbLanguage";
            this.cmbLanguage.Size = new System.Drawing.Size(166, 23);
            this.cmbLanguage.TabIndex = 12;
            this.cmbLanguage.SelectedIndexChanged += new System.EventHandler(this.comLanguage_SelectedIndexChanged);
            // 
            // lblLanguage
            // 
            this.lblLanguage.AutoSize = true;
            this.lblLanguage.Location = new System.Drawing.Point(15, 8);
            this.lblLanguage.Name = "lblLanguage";
            this.lblLanguage.Size = new System.Drawing.Size(59, 15);
            this.lblLanguage.TabIndex = 13;
            this.lblLanguage.Text = "Language";
            // 
            // cmbCountry
            // 
            this.cmbCountry.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbCountry.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCountry.FormattingEnabled = true;
            this.cmbCountry.Location = new System.Drawing.Point(83, 3);
            this.cmbCountry.Name = "cmbCountry";
            this.cmbCountry.Size = new System.Drawing.Size(166, 23);
            this.cmbCountry.TabIndex = 14;
            this.cmbCountry.SelectedIndexChanged += new System.EventHandler(this.comCountry_SelectedIndexChanged);
            // 
            // lblCountry
            // 
            this.lblCountry.AutoSize = true;
            this.lblCountry.Location = new System.Drawing.Point(24, 7);
            this.lblCountry.Name = "lblCountry";
            this.lblCountry.Size = new System.Drawing.Size(50, 15);
            this.lblCountry.TabIndex = 15;
            this.lblCountry.Text = "Country";
            // 
            // lblUID
            // 
            this.lblUID.AutoSize = true;
            this.lblUID.Location = new System.Drawing.Point(6, 12);
            this.lblUID.Name = "lblUID";
            this.lblUID.Size = new System.Drawing.Size(79, 15);
            this.lblUID.TabIndex = 17;
            this.lblUID.Text = "UniqeID (UID)";
            // 
            // btnUpdateChapter
            // 
            this.btnUpdateChapter.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnUpdateChapter.Location = new System.Drawing.Point(3, 55);
            this.btnUpdateChapter.Name = "btnUpdateChapter";
            this.btnUpdateChapter.Size = new System.Drawing.Size(109, 46);
            this.btnUpdateChapter.TabIndex = 18;
            this.btnUpdateChapter.Text = "Update Chapter";
            this.btnUpdateChapter.UseVisualStyleBackColor = true;
            this.btnUpdateChapter.Click += new System.EventHandler(this.btnUpdateChapter_Click);
            // 
            // grpChapterList
            // 
            this.grpChapterList.Controls.Add(this.tlpChapterListMain);
            this.grpChapterList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpChapterList.Location = new System.Drawing.Point(3, 395);
            this.grpChapterList.Name = "grpChapterList";
            this.grpChapterList.Size = new System.Drawing.Size(778, 191);
            this.grpChapterList.TabIndex = 19;
            this.grpChapterList.TabStop = false;
            this.grpChapterList.Text = "Chapter List";
            // 
            // tlpChapterListMain
            // 
            this.tlpChapterListMain.ColumnCount = 2;
            this.tlpChapterListMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpChapterListMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 117F));
            this.tlpChapterListMain.Controls.Add(this.tlpChapterListFunctions, 1, 0);
            this.tlpChapterListMain.Controls.Add(this.lstChapters, 0, 0);
            this.tlpChapterListMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpChapterListMain.Location = new System.Drawing.Point(3, 19);
            this.tlpChapterListMain.Name = "tlpChapterListMain";
            this.tlpChapterListMain.RowCount = 1;
            this.tlpChapterListMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpChapterListMain.Size = new System.Drawing.Size(772, 169);
            this.tlpChapterListMain.TabIndex = 0;
            // 
            // tlpChapterListFunctions
            // 
            this.tlpChapterListFunctions.ColumnCount = 1;
            this.tlpChapterListFunctions.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpChapterListFunctions.Controls.Add(this.btnFromSectionsFile, 0, 2);
            this.tlpChapterListFunctions.Controls.Add(this.btnRemoveChapter, 0, 0);
            this.tlpChapterListFunctions.Controls.Add(this.btnClear, 0, 1);
            this.tlpChapterListFunctions.Controls.Add(this.btnLoad, 0, 3);
            this.tlpChapterListFunctions.Controls.Add(this.btnSave, 0, 4);
            this.tlpChapterListFunctions.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpChapterListFunctions.Location = new System.Drawing.Point(658, 3);
            this.tlpChapterListFunctions.Name = "tlpChapterListFunctions";
            this.tlpChapterListFunctions.RowCount = 5;
            this.tlpChapterListFunctions.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tlpChapterListFunctions.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tlpChapterListFunctions.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tlpChapterListFunctions.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tlpChapterListFunctions.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tlpChapterListFunctions.Size = new System.Drawing.Size(111, 163);
            this.tlpChapterListFunctions.TabIndex = 0;
            // 
            // btnFromSectionsFile
            // 
            this.btnFromSectionsFile.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnFromSectionsFile.Location = new System.Drawing.Point(3, 67);
            this.btnFromSectionsFile.Name = "btnFromSectionsFile";
            this.btnFromSectionsFile.Size = new System.Drawing.Size(105, 26);
            this.btnFromSectionsFile.TabIndex = 12;
            this.btnFromSectionsFile.Text = "From Sections...";
            this.btnFromSectionsFile.UseVisualStyleBackColor = true;
            this.btnFromSectionsFile.Click += new System.EventHandler(this.btnFromSectionsFile_Click);
            // 
            // grpCommon
            // 
            this.grpCommon.Controls.Add(this.tlpChapterDetailsCommon);
            this.grpCommon.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpCommon.Location = new System.Drawing.Point(3, 3);
            this.grpCommon.Name = "grpCommon";
            this.grpCommon.Size = new System.Drawing.Size(287, 358);
            this.grpCommon.TabIndex = 20;
            this.grpCommon.TabStop = false;
            this.grpCommon.Text = "Common";
            // 
            // tlpChapterDetailsCommon
            // 
            this.tlpChapterDetailsCommon.ColumnCount = 1;
            this.tlpChapterDetailsCommon.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpChapterDetailsCommon.Controls.Add(this.pnlChapterDetailsCommonFunctions, 0, 3);
            this.tlpChapterDetailsCommon.Controls.Add(this.pnlChapterDetailsCommonEnd, 0, 2);
            this.tlpChapterDetailsCommon.Controls.Add(this.pnlChapterDetailsCommonStart, 0, 1);
            this.tlpChapterDetailsCommon.Controls.Add(this.pnlChapterDetailsCommonName, 0, 0);
            this.tlpChapterDetailsCommon.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpChapterDetailsCommon.Location = new System.Drawing.Point(3, 19);
            this.tlpChapterDetailsCommon.Name = "tlpChapterDetailsCommon";
            this.tlpChapterDetailsCommon.RowCount = 5;
            this.tlpChapterDetailsCommon.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 52F));
            this.tlpChapterDetailsCommon.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 52F));
            this.tlpChapterDetailsCommon.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 52F));
            this.tlpChapterDetailsCommon.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 52F));
            this.tlpChapterDetailsCommon.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpChapterDetailsCommon.Size = new System.Drawing.Size(281, 336);
            this.tlpChapterDetailsCommon.TabIndex = 25;
            // 
            // pnlChapterDetailsCommonFunctions
            // 
            this.pnlChapterDetailsCommonFunctions.Controls.Add(this.btnUseVideo);
            this.pnlChapterDetailsCommonFunctions.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlChapterDetailsCommonFunctions.Location = new System.Drawing.Point(3, 159);
            this.pnlChapterDetailsCommonFunctions.Name = "pnlChapterDetailsCommonFunctions";
            this.pnlChapterDetailsCommonFunctions.Size = new System.Drawing.Size(275, 46);
            this.pnlChapterDetailsCommonFunctions.TabIndex = 3;
            // 
            // btnUseVideo
            // 
            this.btnUseVideo.Location = new System.Drawing.Point(7, 3);
            this.btnUseVideo.Name = "btnUseVideo";
            this.btnUseVideo.Size = new System.Drawing.Size(104, 37);
            this.btnUseVideo.TabIndex = 22;
            this.btnUseVideo.Text = "Use Video";
            this.btnUseVideo.UseVisualStyleBackColor = true;
            this.btnUseVideo.Click += new System.EventHandler(this.btnUseVideo_Click);
            // 
            // pnlChapterDetailsCommonEnd
            // 
            this.pnlChapterDetailsCommonEnd.Controls.Add(this.btnFromVideoEnd);
            this.pnlChapterDetailsCommonEnd.Controls.Add(this.lblEndTime);
            this.pnlChapterDetailsCommonEnd.Controls.Add(this.txtEndTime);
            this.pnlChapterDetailsCommonEnd.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlChapterDetailsCommonEnd.Location = new System.Drawing.Point(3, 107);
            this.pnlChapterDetailsCommonEnd.Name = "pnlChapterDetailsCommonEnd";
            this.pnlChapterDetailsCommonEnd.Size = new System.Drawing.Size(275, 46);
            this.pnlChapterDetailsCommonEnd.TabIndex = 2;
            // 
            // btnFromVideoEnd
            // 
            this.btnFromVideoEnd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnFromVideoEnd.Location = new System.Drawing.Point(184, 5);
            this.btnFromVideoEnd.Name = "btnFromVideoEnd";
            this.btnFromVideoEnd.Size = new System.Drawing.Size(80, 37);
            this.btnFromVideoEnd.TabIndex = 10;
            this.btnFromVideoEnd.Text = "From Video";
            this.btnFromVideoEnd.UseVisualStyleBackColor = true;
            this.btnFromVideoEnd.Click += new System.EventHandler(this.btnFromVideoEnd_Click);
            // 
            // txtEndTime
            // 
            this.txtEndTime.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtEndTime.Culture = new System.Globalization.CultureInfo("en-US");
            this.txtEndTime.Location = new System.Drawing.Point(69, 12);
            this.txtEndTime.Mask = "99:99:99.999";
            this.txtEndTime.Name = "txtEndTime";
            this.txtEndTime.Size = new System.Drawing.Size(108, 23);
            this.txtEndTime.TabIndex = 8;
            // 
            // pnlChapterDetailsCommonStart
            // 
            this.pnlChapterDetailsCommonStart.Controls.Add(this.btnFromVideoStart);
            this.pnlChapterDetailsCommonStart.Controls.Add(this.lblStartTime);
            this.pnlChapterDetailsCommonStart.Controls.Add(this.txtStartTime);
            this.pnlChapterDetailsCommonStart.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlChapterDetailsCommonStart.Location = new System.Drawing.Point(3, 55);
            this.pnlChapterDetailsCommonStart.Name = "pnlChapterDetailsCommonStart";
            this.pnlChapterDetailsCommonStart.Size = new System.Drawing.Size(275, 46);
            this.pnlChapterDetailsCommonStart.TabIndex = 1;
            // 
            // btnFromVideoStart
            // 
            this.btnFromVideoStart.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnFromVideoStart.Location = new System.Drawing.Point(184, 5);
            this.btnFromVideoStart.Name = "btnFromVideoStart";
            this.btnFromVideoStart.Size = new System.Drawing.Size(80, 37);
            this.btnFromVideoStart.TabIndex = 9;
            this.btnFromVideoStart.Text = "From Video";
            this.btnFromVideoStart.UseVisualStyleBackColor = true;
            this.btnFromVideoStart.Click += new System.EventHandler(this.btnFromVideoStart_Click);
            // 
            // txtStartTime
            // 
            this.txtStartTime.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtStartTime.Culture = new System.Globalization.CultureInfo("en-US");
            this.txtStartTime.Location = new System.Drawing.Point(69, 12);
            this.txtStartTime.Mask = "99:99:99.999";
            this.txtStartTime.Name = "txtStartTime";
            this.txtStartTime.Size = new System.Drawing.Size(108, 23);
            this.txtStartTime.TabIndex = 7;
            // 
            // pnlChapterDetailsCommonName
            // 
            this.pnlChapterDetailsCommonName.Controls.Add(this.txtName);
            this.pnlChapterDetailsCommonName.Controls.Add(this.lblName);
            this.pnlChapterDetailsCommonName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlChapterDetailsCommonName.Location = new System.Drawing.Point(3, 3);
            this.pnlChapterDetailsCommonName.Name = "pnlChapterDetailsCommonName";
            this.pnlChapterDetailsCommonName.Size = new System.Drawing.Size(275, 46);
            this.pnlChapterDetailsCommonName.TabIndex = 0;
            // 
            // grpXMLOnly
            // 
            this.grpXMLOnly.Controls.Add(this.tlpChapterDetailsXml);
            this.grpXMLOnly.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpXMLOnly.Location = new System.Drawing.Point(296, 3);
            this.grpXMLOnly.Name = "grpXMLOnly";
            this.grpXMLOnly.Size = new System.Drawing.Size(352, 358);
            this.grpXMLOnly.TabIndex = 21;
            this.grpXMLOnly.TabStop = false;
            this.grpXMLOnly.Text = "XML Only";
            // 
            // tlpChapterDetailsXml
            // 
            this.tlpChapterDetailsXml.ColumnCount = 1;
            this.tlpChapterDetailsXml.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpChapterDetailsXml.Controls.Add(this.pnlChapterDetailsXmlUid, 0, 0);
            this.tlpChapterDetailsXml.Controls.Add(this.grpLanguage, 0, 1);
            this.tlpChapterDetailsXml.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpChapterDetailsXml.Location = new System.Drawing.Point(3, 19);
            this.tlpChapterDetailsXml.Name = "tlpChapterDetailsXml";
            this.tlpChapterDetailsXml.RowCount = 2;
            this.tlpChapterDetailsXml.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 69F));
            this.tlpChapterDetailsXml.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpChapterDetailsXml.Size = new System.Drawing.Size(346, 336);
            this.tlpChapterDetailsXml.TabIndex = 0;
            // 
            // pnlChapterDetailsXmlUid
            // 
            this.pnlChapterDetailsXmlUid.Controls.Add(this.btnChapterUidAuto);
            this.pnlChapterDetailsXmlUid.Controls.Add(this.chkHidden);
            this.pnlChapterDetailsXmlUid.Controls.Add(this.txtUID);
            this.pnlChapterDetailsXmlUid.Controls.Add(this.chkEnabled);
            this.pnlChapterDetailsXmlUid.Controls.Add(this.lblUID);
            this.pnlChapterDetailsXmlUid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlChapterDetailsXmlUid.Location = new System.Drawing.Point(3, 3);
            this.pnlChapterDetailsXmlUid.Name = "pnlChapterDetailsXmlUid";
            this.pnlChapterDetailsXmlUid.Size = new System.Drawing.Size(340, 63);
            this.pnlChapterDetailsXmlUid.TabIndex = 0;
            // 
            // btnChapterUidAuto
            // 
            this.btnChapterUidAuto.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnChapterUidAuto.Location = new System.Drawing.Point(261, 32);
            this.btnChapterUidAuto.Name = "btnChapterUidAuto";
            this.btnChapterUidAuto.Size = new System.Drawing.Size(64, 24);
            this.btnChapterUidAuto.TabIndex = 32;
            this.btnChapterUidAuto.Text = "Auto";
            this.btnChapterUidAuto.UseVisualStyleBackColor = true;
            this.btnChapterUidAuto.Click += new System.EventHandler(this.btnChapterUidAuto_Click);
            // 
            // chkHidden
            // 
            this.chkHidden.AutoSize = true;
            this.chkHidden.Location = new System.Drawing.Point(96, 37);
            this.chkHidden.Name = "chkHidden";
            this.chkHidden.Size = new System.Drawing.Size(65, 19);
            this.chkHidden.TabIndex = 22;
            this.chkHidden.Text = "Hidden";
            this.chkHidden.UseVisualStyleBackColor = true;
            // 
            // txtUID
            // 
            this.txtUID.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtUID.Location = new System.Drawing.Point(96, 7);
            this.txtUID.Mask = "0000000000";
            this.txtUID.Name = "txtUID";
            this.txtUID.Size = new System.Drawing.Size(229, 23);
            this.txtUID.TabIndex = 24;
            // 
            // chkEnabled
            // 
            this.chkEnabled.AutoSize = true;
            this.chkEnabled.Location = new System.Drawing.Point(168, 37);
            this.chkEnabled.Name = "chkEnabled";
            this.chkEnabled.Size = new System.Drawing.Size(68, 19);
            this.chkEnabled.TabIndex = 23;
            this.chkEnabled.Text = "Enabled";
            this.chkEnabled.UseVisualStyleBackColor = true;
            // 
            // grpLanguage
            // 
            this.grpLanguage.Controls.Add(this.tlpChapterDetailsNamesLanguagesMain);
            this.grpLanguage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpLanguage.Location = new System.Drawing.Point(3, 72);
            this.grpLanguage.Name = "grpLanguage";
            this.grpLanguage.Size = new System.Drawing.Size(340, 261);
            this.grpLanguage.TabIndex = 28;
            this.grpLanguage.TabStop = false;
            this.grpLanguage.Text = "Names - Languages";
            // 
            // tlpChapterDetailsNamesLanguagesMain
            // 
            this.tlpChapterDetailsNamesLanguagesMain.ColumnCount = 1;
            this.tlpChapterDetailsNamesLanguagesMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpChapterDetailsNamesLanguagesMain.Controls.Add(this.pnlChapterDetailsXmlName, 0, 0);
            this.tlpChapterDetailsNamesLanguagesMain.Controls.Add(this.pnlChapterDetailsXmlLanguage, 0, 1);
            this.tlpChapterDetailsNamesLanguagesMain.Controls.Add(this.pnlChapterDetailsXmlCountry, 0, 2);
            this.tlpChapterDetailsNamesLanguagesMain.Controls.Add(this.tlpLanguageListMain, 0, 3);
            this.tlpChapterDetailsNamesLanguagesMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpChapterDetailsNamesLanguagesMain.Location = new System.Drawing.Point(3, 19);
            this.tlpChapterDetailsNamesLanguagesMain.Name = "tlpChapterDetailsNamesLanguagesMain";
            this.tlpChapterDetailsNamesLanguagesMain.RowCount = 4;
            this.tlpChapterDetailsNamesLanguagesMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tlpChapterDetailsNamesLanguagesMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tlpChapterDetailsNamesLanguagesMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tlpChapterDetailsNamesLanguagesMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpChapterDetailsNamesLanguagesMain.Size = new System.Drawing.Size(334, 239);
            this.tlpChapterDetailsNamesLanguagesMain.TabIndex = 29;
            // 
            // pnlChapterDetailsXmlName
            // 
            this.pnlChapterDetailsXmlName.Controls.Add(this.txtNameLanguage);
            this.pnlChapterDetailsXmlName.Controls.Add(this.lblNameLanguage);
            this.pnlChapterDetailsXmlName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlChapterDetailsXmlName.Location = new System.Drawing.Point(3, 3);
            this.pnlChapterDetailsXmlName.Name = "pnlChapterDetailsXmlName";
            this.pnlChapterDetailsXmlName.Size = new System.Drawing.Size(328, 34);
            this.pnlChapterDetailsXmlName.TabIndex = 0;
            // 
            // txtNameLanguage
            // 
            this.txtNameLanguage.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtNameLanguage.Location = new System.Drawing.Point(82, 5);
            this.txtNameLanguage.Name = "txtNameLanguage";
            this.txtNameLanguage.Size = new System.Drawing.Size(239, 23);
            this.txtNameLanguage.TabIndex = 25;
            // 
            // lblNameLanguage
            // 
            this.lblNameLanguage.AutoSize = true;
            this.lblNameLanguage.Location = new System.Drawing.Point(41, 8);
            this.lblNameLanguage.Name = "lblNameLanguage";
            this.lblNameLanguage.Size = new System.Drawing.Size(39, 15);
            this.lblNameLanguage.TabIndex = 26;
            this.lblNameLanguage.Text = "Name";
            // 
            // pnlChapterDetailsXmlLanguage
            // 
            this.pnlChapterDetailsXmlLanguage.Controls.Add(this.btnNoLanguage);
            this.pnlChapterDetailsXmlLanguage.Controls.Add(this.lblLanguage);
            this.pnlChapterDetailsXmlLanguage.Controls.Add(this.cmbLanguage);
            this.pnlChapterDetailsXmlLanguage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlChapterDetailsXmlLanguage.Location = new System.Drawing.Point(3, 43);
            this.pnlChapterDetailsXmlLanguage.Name = "pnlChapterDetailsXmlLanguage";
            this.pnlChapterDetailsXmlLanguage.Size = new System.Drawing.Size(328, 34);
            this.pnlChapterDetailsXmlLanguage.TabIndex = 1;
            // 
            // btnNoLanguage
            // 
            this.btnNoLanguage.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnNoLanguage.Location = new System.Drawing.Point(256, 3);
            this.btnNoLanguage.Name = "btnNoLanguage";
            this.btnNoLanguage.Size = new System.Drawing.Size(65, 27);
            this.btnNoLanguage.TabIndex = 31;
            this.btnNoLanguage.Text = "None";
            this.btnNoLanguage.UseVisualStyleBackColor = true;
            this.btnNoLanguage.Click += new System.EventHandler(this.btnNoLanguage_Click);
            // 
            // pnlChapterDetailsXmlCountry
            // 
            this.pnlChapterDetailsXmlCountry.Controls.Add(this.btnNoCountry);
            this.pnlChapterDetailsXmlCountry.Controls.Add(this.cmbCountry);
            this.pnlChapterDetailsXmlCountry.Controls.Add(this.lblCountry);
            this.pnlChapterDetailsXmlCountry.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlChapterDetailsXmlCountry.Location = new System.Drawing.Point(3, 83);
            this.pnlChapterDetailsXmlCountry.Name = "pnlChapterDetailsXmlCountry";
            this.pnlChapterDetailsXmlCountry.Size = new System.Drawing.Size(328, 34);
            this.pnlChapterDetailsXmlCountry.TabIndex = 2;
            // 
            // btnNoCountry
            // 
            this.btnNoCountry.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnNoCountry.Location = new System.Drawing.Point(256, 2);
            this.btnNoCountry.Name = "btnNoCountry";
            this.btnNoCountry.Size = new System.Drawing.Size(65, 27);
            this.btnNoCountry.TabIndex = 32;
            this.btnNoCountry.Text = "None";
            this.btnNoCountry.UseVisualStyleBackColor = true;
            this.btnNoCountry.Click += new System.EventHandler(this.btnNoCountry_Click);
            // 
            // tlpLanguageListMain
            // 
            this.tlpLanguageListMain.ColumnCount = 2;
            this.tlpLanguageListMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpLanguageListMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 79F));
            this.tlpLanguageListMain.Controls.Add(this.lstLanguages, 0, 0);
            this.tlpLanguageListMain.Controls.Add(this.tlpLanguageListFunctions, 1, 0);
            this.tlpLanguageListMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpLanguageListMain.Location = new System.Drawing.Point(3, 123);
            this.tlpLanguageListMain.Name = "tlpLanguageListMain";
            this.tlpLanguageListMain.RowCount = 1;
            this.tlpLanguageListMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpLanguageListMain.Size = new System.Drawing.Size(328, 113);
            this.tlpLanguageListMain.TabIndex = 3;
            // 
            // lstLanguages
            // 
            this.lstLanguages.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lstLanguages.FormattingEnabled = true;
            this.lstLanguages.ItemHeight = 15;
            this.lstLanguages.Location = new System.Drawing.Point(3, 3);
            this.lstLanguages.Name = "lstLanguages";
            this.lstLanguages.Size = new System.Drawing.Size(243, 107);
            this.lstLanguages.TabIndex = 27;
            this.lstLanguages.SelectedIndexChanged += new System.EventHandler(this.listLanguages_SelectedIndexChanged);
            // 
            // tlpLanguageListFunctions
            // 
            this.tlpLanguageListFunctions.ColumnCount = 1;
            this.tlpLanguageListFunctions.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpLanguageListFunctions.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 23F));
            this.tlpLanguageListFunctions.Controls.Add(this.btnRemoveLanguage, 0, 2);
            this.tlpLanguageListFunctions.Controls.Add(this.btnUpdateLanguage, 0, 1);
            this.tlpLanguageListFunctions.Controls.Add(this.btnAddLanguage, 0, 0);
            this.tlpLanguageListFunctions.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpLanguageListFunctions.Location = new System.Drawing.Point(252, 3);
            this.tlpLanguageListFunctions.Name = "tlpLanguageListFunctions";
            this.tlpLanguageListFunctions.RowCount = 3;
            this.tlpLanguageListFunctions.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tlpLanguageListFunctions.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tlpLanguageListFunctions.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tlpLanguageListFunctions.Size = new System.Drawing.Size(73, 107);
            this.tlpLanguageListFunctions.TabIndex = 0;
            // 
            // btnRemoveLanguage
            // 
            this.btnRemoveLanguage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnRemoveLanguage.Location = new System.Drawing.Point(3, 73);
            this.btnRemoveLanguage.Name = "btnRemoveLanguage";
            this.btnRemoveLanguage.Size = new System.Drawing.Size(67, 31);
            this.btnRemoveLanguage.TabIndex = 29;
            this.btnRemoveLanguage.Text = "Remove";
            this.btnRemoveLanguage.UseVisualStyleBackColor = true;
            this.btnRemoveLanguage.Click += new System.EventHandler(this.btnRemoveLanguage_Click);
            // 
            // btnUpdateLanguage
            // 
            this.btnUpdateLanguage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnUpdateLanguage.Location = new System.Drawing.Point(3, 38);
            this.btnUpdateLanguage.Name = "btnUpdateLanguage";
            this.btnUpdateLanguage.Size = new System.Drawing.Size(67, 29);
            this.btnUpdateLanguage.TabIndex = 30;
            this.btnUpdateLanguage.Text = "Update";
            this.btnUpdateLanguage.UseVisualStyleBackColor = true;
            this.btnUpdateLanguage.Click += new System.EventHandler(this.btnUpdateLanguage_Click);
            // 
            // btnAddLanguage
            // 
            this.btnAddLanguage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnAddLanguage.Location = new System.Drawing.Point(3, 3);
            this.btnAddLanguage.Name = "btnAddLanguage";
            this.btnAddLanguage.Size = new System.Drawing.Size(67, 29);
            this.btnAddLanguage.TabIndex = 28;
            this.btnAddLanguage.Text = "Add";
            this.btnAddLanguage.UseVisualStyleBackColor = true;
            this.btnAddLanguage.Click += new System.EventHandler(this.btnAddLanguage_Click);
            // 
            // grpChapterInfo
            // 
            this.grpChapterInfo.Controls.Add(this.tlpChapterDetailsMain);
            this.grpChapterInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpChapterInfo.Location = new System.Drawing.Point(3, 3);
            this.grpChapterInfo.Name = "grpChapterInfo";
            this.grpChapterInfo.Size = new System.Drawing.Size(778, 386);
            this.grpChapterInfo.TabIndex = 22;
            this.grpChapterInfo.TabStop = false;
            this.grpChapterInfo.Text = "Chapter Details";
            // 
            // tlpChapterDetailsMain
            // 
            this.tlpChapterDetailsMain.ColumnCount = 3;
            this.tlpChapterDetailsMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 45F));
            this.tlpChapterDetailsMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 55F));
            this.tlpChapterDetailsMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 120F));
            this.tlpChapterDetailsMain.Controls.Add(this.tlpChapterDetailsFunctions, 2, 0);
            this.tlpChapterDetailsMain.Controls.Add(this.grpXMLOnly, 1, 0);
            this.tlpChapterDetailsMain.Controls.Add(this.grpCommon, 0, 0);
            this.tlpChapterDetailsMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpChapterDetailsMain.Location = new System.Drawing.Point(3, 19);
            this.tlpChapterDetailsMain.Name = "tlpChapterDetailsMain";
            this.tlpChapterDetailsMain.RowCount = 1;
            this.tlpChapterDetailsMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpChapterDetailsMain.Size = new System.Drawing.Size(772, 364);
            this.tlpChapterDetailsMain.TabIndex = 0;
            // 
            // tlpChapterDetailsFunctions
            // 
            this.tlpChapterDetailsFunctions.ColumnCount = 1;
            this.tlpChapterDetailsFunctions.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpChapterDetailsFunctions.Controls.Add(this.btnAddChapter, 0, 0);
            this.tlpChapterDetailsFunctions.Controls.Add(this.btnUpdateChapter, 0, 1);
            this.tlpChapterDetailsFunctions.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpChapterDetailsFunctions.Location = new System.Drawing.Point(654, 3);
            this.tlpChapterDetailsFunctions.Name = "tlpChapterDetailsFunctions";
            this.tlpChapterDetailsFunctions.RowCount = 3;
            this.tlpChapterDetailsFunctions.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 52F));
            this.tlpChapterDetailsFunctions.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 52F));
            this.tlpChapterDetailsFunctions.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpChapterDetailsFunctions.Size = new System.Drawing.Size(115, 358);
            this.tlpChapterDetailsFunctions.TabIndex = 0;
            // 
            // btnHook
            // 
            this.btnHook.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnHook.Location = new System.Drawing.Point(696, 10);
            this.btnHook.Name = "btnHook";
            this.btnHook.Size = new System.Drawing.Size(75, 32);
            this.btnHook.TabIndex = 23;
            this.btnHook.Text = "UnHook";
            this.btnHook.UseVisualStyleBackColor = true;
            this.btnHook.Click += new System.EventHandler(this.btnHook_Click);
            // 
            // tlpMain
            // 
            this.tlpMain.ColumnCount = 1;
            this.tlpMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpMain.Controls.Add(this.grpHook, 0, 2);
            this.tlpMain.Controls.Add(this.grpChapterList, 0, 1);
            this.tlpMain.Controls.Add(this.grpChapterInfo, 0, 0);
            this.tlpMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpMain.Location = new System.Drawing.Point(0, 0);
            this.tlpMain.Name = "tlpMain";
            this.tlpMain.RowCount = 3;
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 392F));
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 52F));
            this.tlpMain.Size = new System.Drawing.Size(784, 641);
            this.tlpMain.TabIndex = 24;
            // 
            // grpHook
            // 
            this.grpHook.Controls.Add(this.btnHook);
            this.grpHook.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpHook.Location = new System.Drawing.Point(3, 592);
            this.grpHook.Name = "grpHook";
            this.grpHook.Size = new System.Drawing.Size(778, 46);
            this.grpHook.TabIndex = 0;
            this.grpHook.TabStop = false;
            // 
            // ChapterEditorForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 641);
            this.Controls.Add(this.tlpMain);
            this.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.MinimumSize = new System.Drawing.Size(800, 680);
            this.Name = "ChapterEditorForm";
            this.Text = "ChapterEditorForm";
            this.grpChapterList.ResumeLayout(false);
            this.tlpChapterListMain.ResumeLayout(false);
            this.tlpChapterListFunctions.ResumeLayout(false);
            this.grpCommon.ResumeLayout(false);
            this.tlpChapterDetailsCommon.ResumeLayout(false);
            this.pnlChapterDetailsCommonFunctions.ResumeLayout(false);
            this.pnlChapterDetailsCommonEnd.ResumeLayout(false);
            this.pnlChapterDetailsCommonEnd.PerformLayout();
            this.pnlChapterDetailsCommonStart.ResumeLayout(false);
            this.pnlChapterDetailsCommonStart.PerformLayout();
            this.pnlChapterDetailsCommonName.ResumeLayout(false);
            this.pnlChapterDetailsCommonName.PerformLayout();
            this.grpXMLOnly.ResumeLayout(false);
            this.tlpChapterDetailsXml.ResumeLayout(false);
            this.pnlChapterDetailsXmlUid.ResumeLayout(false);
            this.pnlChapterDetailsXmlUid.PerformLayout();
            this.grpLanguage.ResumeLayout(false);
            this.tlpChapterDetailsNamesLanguagesMain.ResumeLayout(false);
            this.pnlChapterDetailsXmlName.ResumeLayout(false);
            this.pnlChapterDetailsXmlName.PerformLayout();
            this.pnlChapterDetailsXmlLanguage.ResumeLayout(false);
            this.pnlChapterDetailsXmlLanguage.PerformLayout();
            this.pnlChapterDetailsXmlCountry.ResumeLayout(false);
            this.pnlChapterDetailsXmlCountry.PerformLayout();
            this.tlpLanguageListMain.ResumeLayout(false);
            this.tlpLanguageListFunctions.ResumeLayout(false);
            this.grpChapterInfo.ResumeLayout(false);
            this.tlpChapterDetailsMain.ResumeLayout(false);
            this.tlpChapterDetailsFunctions.ResumeLayout(false);
            this.tlpMain.ResumeLayout(false);
            this.grpHook.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox lstChapters;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Label lblStartTime;
        private System.Windows.Forms.Label lblEndTime;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.Button btnAddChapter;
        private System.Windows.Forms.Button btnRemoveChapter;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Button btnLoad;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.ComboBox cmbLanguage;
        private System.Windows.Forms.Label lblLanguage;
        private System.Windows.Forms.ComboBox cmbCountry;
        private System.Windows.Forms.Label lblCountry;
        private System.Windows.Forms.Label lblUID;
        private System.Windows.Forms.Button btnUpdateChapter;
        private System.Windows.Forms.GroupBox grpChapterList;
        private System.Windows.Forms.Button btnFromSectionsFile;
        private System.Windows.Forms.GroupBox grpCommon;
        private System.Windows.Forms.GroupBox grpXMLOnly;
        private System.Windows.Forms.CheckBox chkHidden;
        private System.Windows.Forms.CheckBox chkEnabled;
        private System.Windows.Forms.GroupBox grpChapterInfo;
        private System.Windows.Forms.Button btnHook;
        private System.Windows.Forms.MaskedTextBox txtStartTime;
        private System.Windows.Forms.MaskedTextBox txtEndTime;
        private System.Windows.Forms.MaskedTextBox txtUID;
        private System.Windows.Forms.GroupBox grpLanguage;
        private System.Windows.Forms.Button btnUpdateLanguage;
        private System.Windows.Forms.Button btnRemoveLanguage;
        private System.Windows.Forms.Button btnAddLanguage;
        private System.Windows.Forms.ListBox lstLanguages;
        private System.Windows.Forms.TextBox txtNameLanguage;
        private System.Windows.Forms.Label lblNameLanguage;
        private System.Windows.Forms.Button btnFromVideoEnd;
        private System.Windows.Forms.Button btnFromVideoStart;
        private System.Windows.Forms.Button btnNoCountry;
        private System.Windows.Forms.Button btnNoLanguage;
        private System.Windows.Forms.Button btnUseVideo;
        private System.Windows.Forms.Button btnChapterUidAuto;
        private System.Windows.Forms.TableLayoutPanel tlpChapterListMain;
        private System.Windows.Forms.TableLayoutPanel tlpChapterListFunctions;
        private System.Windows.Forms.TableLayoutPanel tlpChapterDetailsCommon;
        private System.Windows.Forms.Panel pnlChapterDetailsCommonFunctions;
        private System.Windows.Forms.Panel pnlChapterDetailsCommonEnd;
        private System.Windows.Forms.Panel pnlChapterDetailsCommonStart;
        private System.Windows.Forms.Panel pnlChapterDetailsCommonName;
        private System.Windows.Forms.TableLayoutPanel tlpChapterDetailsXml;
        private System.Windows.Forms.Panel pnlChapterDetailsXmlUid;
        private System.Windows.Forms.TableLayoutPanel tlpChapterDetailsNamesLanguagesMain;
        private System.Windows.Forms.Panel pnlChapterDetailsXmlName;
        private System.Windows.Forms.Panel pnlChapterDetailsXmlLanguage;
        private System.Windows.Forms.Panel pnlChapterDetailsXmlCountry;
        private System.Windows.Forms.TableLayoutPanel tlpLanguageListMain;
        private System.Windows.Forms.TableLayoutPanel tlpLanguageListFunctions;
        private System.Windows.Forms.TableLayoutPanel tlpChapterDetailsMain;
        private System.Windows.Forms.TableLayoutPanel tlpChapterDetailsFunctions;
        private System.Windows.Forms.TableLayoutPanel tlpMain;
        private System.Windows.Forms.GroupBox grpHook;
    }
}