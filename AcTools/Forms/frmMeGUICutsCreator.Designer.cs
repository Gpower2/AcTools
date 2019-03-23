namespace AcTools.Forms
{
    partial class frmMeGUICutsCreator
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
            this.lblVideoFile = new System.Windows.Forms.Label();
            this.lblTimecodesFile = new System.Windows.Forms.Label();
            this.btnBrowseVideoFile = new System.Windows.Forms.Button();
            this.btnBrowseTimecodesFile = new System.Windows.Forms.Button();
            this.btnGenerateTimecodesFile = new System.Windows.Forms.Button();
            this.btnBrowseSectionsFile = new System.Windows.Forms.Button();
            this.lblSectionsFile = new System.Windows.Forms.Label();
            this.txtSectionsFile = new System.Windows.Forms.TextBox();
            this.btnPreviewSectionsFile = new System.Windows.Forms.Button();
            this.btnPreviewVideoFile = new System.Windows.Forms.Button();
            this.btnGenerateMeguiCutsFile = new System.Windows.Forms.Button();
            this.grpInput = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.lblFrameRate = new System.Windows.Forms.Label();
            this.cmbFrameRate = new System.Windows.Forms.ComboBox();
            this.grpFunctions = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.panel6 = new System.Windows.Forms.Panel();
            this.grpOutput = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.panel5 = new System.Windows.Forms.Panel();
            this.btnBrowseMeguiCutsFile = new System.Windows.Forms.Button();
            this.txtMeguiCutsFile = new System.Windows.Forms.TextBox();
            this.lblMeguiCutFile = new System.Windows.Forms.Label();
            this.tlpMain = new System.Windows.Forms.TableLayoutPanel();
            this.grpInput.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel4.SuspendLayout();
            this.grpFunctions.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            this.panel6.SuspendLayout();
            this.grpOutput.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.panel5.SuspendLayout();
            this.tlpMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtVideoFile
            // 
            this.txtVideoFile.AllowDrop = true;
            this.txtVideoFile.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtVideoFile.Location = new System.Drawing.Point(91, 7);
            this.txtVideoFile.Name = "txtVideoFile";
            this.txtVideoFile.Size = new System.Drawing.Size(347, 22);
            this.txtVideoFile.TabIndex = 0;
            this.txtVideoFile.DragDrop += new System.Windows.Forms.DragEventHandler(this.txt_DragDrop);
            this.txtVideoFile.DragEnter += new System.Windows.Forms.DragEventHandler(this.txt_DragEnter);
            // 
            // txtTimecodesFile
            // 
            this.txtTimecodesFile.AllowDrop = true;
            this.txtTimecodesFile.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtTimecodesFile.Location = new System.Drawing.Point(91, 6);
            this.txtTimecodesFile.Name = "txtTimecodesFile";
            this.txtTimecodesFile.Size = new System.Drawing.Size(347, 22);
            this.txtTimecodesFile.TabIndex = 1;
            this.txtTimecodesFile.DragDrop += new System.Windows.Forms.DragEventHandler(this.txt_DragDrop);
            this.txtTimecodesFile.DragEnter += new System.Windows.Forms.DragEventHandler(this.txt_DragEnter);
            // 
            // lblVideoFile
            // 
            this.lblVideoFile.AutoSize = true;
            this.lblVideoFile.Location = new System.Drawing.Point(29, 11);
            this.lblVideoFile.Name = "lblVideoFile";
            this.lblVideoFile.Size = new System.Drawing.Size(58, 13);
            this.lblVideoFile.TabIndex = 2;
            this.lblVideoFile.Text = "Video File";
            // 
            // lblTimecodesFile
            // 
            this.lblTimecodesFile.AutoSize = true;
            this.lblTimecodesFile.Location = new System.Drawing.Point(6, 10);
            this.lblTimecodesFile.Name = "lblTimecodesFile";
            this.lblTimecodesFile.Size = new System.Drawing.Size(81, 13);
            this.lblTimecodesFile.TabIndex = 3;
            this.lblTimecodesFile.Text = "Timecodes File";
            // 
            // btnBrowseVideoFile
            // 
            this.btnBrowseVideoFile.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnBrowseVideoFile.Location = new System.Drawing.Point(441, 2);
            this.btnBrowseVideoFile.Name = "btnBrowseVideoFile";
            this.btnBrowseVideoFile.Size = new System.Drawing.Size(70, 30);
            this.btnBrowseVideoFile.TabIndex = 4;
            this.btnBrowseVideoFile.Text = "Browse...";
            this.btnBrowseVideoFile.UseVisualStyleBackColor = true;
            this.btnBrowseVideoFile.Click += new System.EventHandler(this.btnBrowseVideoFile_Click);
            // 
            // btnBrowseTimecodesFile
            // 
            this.btnBrowseTimecodesFile.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnBrowseTimecodesFile.Location = new System.Drawing.Point(441, 1);
            this.btnBrowseTimecodesFile.Name = "btnBrowseTimecodesFile";
            this.btnBrowseTimecodesFile.Size = new System.Drawing.Size(70, 30);
            this.btnBrowseTimecodesFile.TabIndex = 5;
            this.btnBrowseTimecodesFile.Text = "Browse...";
            this.btnBrowseTimecodesFile.UseVisualStyleBackColor = true;
            this.btnBrowseTimecodesFile.Click += new System.EventHandler(this.btnBrowseTimecodesFile_Click);
            // 
            // btnGenerateTimecodesFile
            // 
            this.btnGenerateTimecodesFile.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnGenerateTimecodesFile.Location = new System.Drawing.Point(516, 1);
            this.btnGenerateTimecodesFile.Name = "btnGenerateTimecodesFile";
            this.btnGenerateTimecodesFile.Size = new System.Drawing.Size(70, 30);
            this.btnGenerateTimecodesFile.TabIndex = 6;
            this.btnGenerateTimecodesFile.Text = "Generate";
            this.btnGenerateTimecodesFile.UseVisualStyleBackColor = true;
            this.btnGenerateTimecodesFile.Click += new System.EventHandler(this.btnGenerateTimecodesFile_Click);
            // 
            // btnBrowseSectionsFile
            // 
            this.btnBrowseSectionsFile.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnBrowseSectionsFile.Location = new System.Drawing.Point(441, 2);
            this.btnBrowseSectionsFile.Name = "btnBrowseSectionsFile";
            this.btnBrowseSectionsFile.Size = new System.Drawing.Size(70, 30);
            this.btnBrowseSectionsFile.TabIndex = 9;
            this.btnBrowseSectionsFile.Text = "Browse...";
            this.btnBrowseSectionsFile.UseVisualStyleBackColor = true;
            this.btnBrowseSectionsFile.Click += new System.EventHandler(this.btnBrowseSectionsFile_Click);
            // 
            // lblSectionsFile
            // 
            this.lblSectionsFile.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblSectionsFile.AutoSize = true;
            this.lblSectionsFile.Location = new System.Drawing.Point(16, 11);
            this.lblSectionsFile.Name = "lblSectionsFile";
            this.lblSectionsFile.Size = new System.Drawing.Size(71, 13);
            this.lblSectionsFile.TabIndex = 8;
            this.lblSectionsFile.Text = "Sections File";
            // 
            // txtSectionsFile
            // 
            this.txtSectionsFile.AllowDrop = true;
            this.txtSectionsFile.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSectionsFile.Location = new System.Drawing.Point(91, 7);
            this.txtSectionsFile.Name = "txtSectionsFile";
            this.txtSectionsFile.Size = new System.Drawing.Size(347, 22);
            this.txtSectionsFile.TabIndex = 7;
            this.txtSectionsFile.DragDrop += new System.Windows.Forms.DragEventHandler(this.txt_DragDrop);
            this.txtSectionsFile.DragEnter += new System.Windows.Forms.DragEventHandler(this.txt_DragEnter);
            // 
            // btnPreviewSectionsFile
            // 
            this.btnPreviewSectionsFile.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPreviewSectionsFile.Location = new System.Drawing.Point(516, 2);
            this.btnPreviewSectionsFile.Name = "btnPreviewSectionsFile";
            this.btnPreviewSectionsFile.Size = new System.Drawing.Size(70, 30);
            this.btnPreviewSectionsFile.TabIndex = 10;
            this.btnPreviewSectionsFile.Text = "Preview";
            this.btnPreviewSectionsFile.UseVisualStyleBackColor = true;
            this.btnPreviewSectionsFile.Click += new System.EventHandler(this.btnPreviewSectionsFile_Click);
            // 
            // btnPreviewVideoFile
            // 
            this.btnPreviewVideoFile.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPreviewVideoFile.Location = new System.Drawing.Point(516, 2);
            this.btnPreviewVideoFile.Name = "btnPreviewVideoFile";
            this.btnPreviewVideoFile.Size = new System.Drawing.Size(70, 30);
            this.btnPreviewVideoFile.TabIndex = 11;
            this.btnPreviewVideoFile.Text = "Preview";
            this.btnPreviewVideoFile.UseVisualStyleBackColor = true;
            this.btnPreviewVideoFile.Click += new System.EventHandler(this.btnPreviewVideoFile_Click);
            // 
            // btnGenerateMeguiCutsFile
            // 
            this.btnGenerateMeguiCutsFile.Location = new System.Drawing.Point(3, 4);
            this.btnGenerateMeguiCutsFile.Name = "btnGenerateMeguiCutsFile";
            this.btnGenerateMeguiCutsFile.Size = new System.Drawing.Size(93, 35);
            this.btnGenerateMeguiCutsFile.TabIndex = 12;
            this.btnGenerateMeguiCutsFile.Text = "Generate MeGUI Cut File";
            this.btnGenerateMeguiCutsFile.UseVisualStyleBackColor = true;
            this.btnGenerateMeguiCutsFile.Click += new System.EventHandler(this.btnGenerateMeguiCutsFile_Click);
            // 
            // grpInput
            // 
            this.grpInput.Controls.Add(this.tableLayoutPanel1);
            this.grpInput.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpInput.Location = new System.Drawing.Point(3, 3);
            this.grpInput.Name = "grpInput";
            this.grpInput.Size = new System.Drawing.Size(603, 181);
            this.grpInput.TabIndex = 13;
            this.grpInput.TabStop = false;
            this.grpInput.Text = "Input";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.panel1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.panel2, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.panel3, 0, 4);
            this.tableLayoutPanel1.Controls.Add(this.panel4, 0, 6);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(3, 18);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 7;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(597, 160);
            this.tableLayoutPanel1.TabIndex = 17;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.txtVideoFile);
            this.panel1.Controls.Add(this.btnBrowseVideoFile);
            this.panel1.Controls.Add(this.btnPreviewVideoFile);
            this.panel1.Controls.Add(this.lblVideoFile);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(591, 34);
            this.panel1.TabIndex = 0;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.btnBrowseTimecodesFile);
            this.panel2.Controls.Add(this.txtTimecodesFile);
            this.panel2.Controls.Add(this.lblTimecodesFile);
            this.panel2.Controls.Add(this.btnGenerateTimecodesFile);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(3, 43);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(591, 34);
            this.panel2.TabIndex = 1;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.btnPreviewSectionsFile);
            this.panel3.Controls.Add(this.txtSectionsFile);
            this.panel3.Controls.Add(this.btnBrowseSectionsFile);
            this.panel3.Controls.Add(this.lblSectionsFile);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(3, 83);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(591, 34);
            this.panel3.TabIndex = 2;
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.lblFrameRate);
            this.panel4.Controls.Add(this.cmbFrameRate);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel4.Location = new System.Drawing.Point(3, 123);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(591, 34);
            this.panel4.TabIndex = 3;
            // 
            // lblFrameRate
            // 
            this.lblFrameRate.AutoSize = true;
            this.lblFrameRate.Location = new System.Drawing.Point(23, 10);
            this.lblFrameRate.Name = "lblFrameRate";
            this.lblFrameRate.Size = new System.Drawing.Size(64, 13);
            this.lblFrameRate.TabIndex = 1;
            this.lblFrameRate.Text = "Frame Rate";
            // 
            // cmbFrameRate
            // 
            this.cmbFrameRate.FormattingEnabled = true;
            this.cmbFrameRate.Location = new System.Drawing.Point(91, 6);
            this.cmbFrameRate.Name = "cmbFrameRate";
            this.cmbFrameRate.Size = new System.Drawing.Size(126, 21);
            this.cmbFrameRate.TabIndex = 0;
            // 
            // grpFunctions
            // 
            this.grpFunctions.Controls.Add(this.tableLayoutPanel3);
            this.grpFunctions.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpFunctions.Location = new System.Drawing.Point(3, 252);
            this.grpFunctions.Name = "grpFunctions";
            this.grpFunctions.Size = new System.Drawing.Size(603, 57);
            this.grpFunctions.TabIndex = 14;
            this.grpFunctions.TabStop = false;
            this.grpFunctions.Text = "Functions";
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.ColumnCount = 1;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel3.Controls.Add(this.panel6, 0, 1);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(3, 18);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 3;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(597, 36);
            this.tableLayoutPanel3.TabIndex = 17;
            // 
            // panel6
            // 
            this.panel6.Controls.Add(this.btnGenerateMeguiCutsFile);
            this.panel6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel6.Location = new System.Drawing.Point(3, -4);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(591, 44);
            this.panel6.TabIndex = 0;
            // 
            // grpOutput
            // 
            this.grpOutput.Controls.Add(this.tableLayoutPanel2);
            this.grpOutput.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpOutput.Location = new System.Drawing.Point(3, 190);
            this.grpOutput.Name = "grpOutput";
            this.grpOutput.Size = new System.Drawing.Size(603, 56);
            this.grpOutput.TabIndex = 15;
            this.grpOutput.TabStop = false;
            this.grpOutput.Text = "Output";
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 1;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel2.Controls.Add(this.panel5, 0, 1);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 18);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 3;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(597, 35);
            this.tableLayoutPanel2.TabIndex = 17;
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.btnBrowseMeguiCutsFile);
            this.panel5.Controls.Add(this.txtMeguiCutsFile);
            this.panel5.Controls.Add(this.lblMeguiCutFile);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel5.Location = new System.Drawing.Point(3, 1);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(591, 34);
            this.panel5.TabIndex = 0;
            // 
            // btnBrowseMeguiCutsFile
            // 
            this.btnBrowseMeguiCutsFile.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnBrowseMeguiCutsFile.Location = new System.Drawing.Point(441, 2);
            this.btnBrowseMeguiCutsFile.Name = "btnBrowseMeguiCutsFile";
            this.btnBrowseMeguiCutsFile.Size = new System.Drawing.Size(70, 30);
            this.btnBrowseMeguiCutsFile.TabIndex = 12;
            this.btnBrowseMeguiCutsFile.Text = "Browse...";
            this.btnBrowseMeguiCutsFile.UseVisualStyleBackColor = true;
            this.btnBrowseMeguiCutsFile.Click += new System.EventHandler(this.btnBrowseMeguiCutsFile_Click);
            // 
            // txtMeguiCutsFile
            // 
            this.txtMeguiCutsFile.AllowDrop = true;
            this.txtMeguiCutsFile.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtMeguiCutsFile.Location = new System.Drawing.Point(91, 7);
            this.txtMeguiCutsFile.Name = "txtMeguiCutsFile";
            this.txtMeguiCutsFile.Size = new System.Drawing.Size(347, 22);
            this.txtMeguiCutsFile.TabIndex = 10;
            this.txtMeguiCutsFile.DragDrop += new System.Windows.Forms.DragEventHandler(this.txt_DragDrop);
            this.txtMeguiCutsFile.DragEnter += new System.Windows.Forms.DragEventHandler(this.txt_DragEnter);
            // 
            // lblMeguiCutFile
            // 
            this.lblMeguiCutFile.AutoSize = true;
            this.lblMeguiCutFile.Location = new System.Drawing.Point(3, 11);
            this.lblMeguiCutFile.Name = "lblMeguiCutFile";
            this.lblMeguiCutFile.Size = new System.Drawing.Size(84, 13);
            this.lblMeguiCutFile.TabIndex = 11;
            this.lblMeguiCutFile.Text = "MeGUI Cut File";
            // 
            // tlpMain
            // 
            this.tlpMain.ColumnCount = 1;
            this.tlpMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpMain.Controls.Add(this.grpInput, 0, 0);
            this.tlpMain.Controls.Add(this.grpFunctions, 0, 2);
            this.tlpMain.Controls.Add(this.grpOutput, 0, 1);
            this.tlpMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpMain.Location = new System.Drawing.Point(0, 0);
            this.tlpMain.Name = "tlpMain";
            this.tlpMain.RowCount = 3;
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 60F));
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tlpMain.Size = new System.Drawing.Size(609, 312);
            this.tlpMain.TabIndex = 16;
            // 
            // MeGUICutsCreatorForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(609, 312);
            this.Controls.Add(this.tlpMain);
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MinimumSize = new System.Drawing.Size(625, 350);
            this.Name = "MeGUICutsCreatorForm";
            this.Text = "MeGUICutsCreatorForm";
            this.grpInput.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.grpFunctions.ResumeLayout(false);
            this.tableLayoutPanel3.ResumeLayout(false);
            this.panel6.ResumeLayout(false);
            this.grpOutput.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            this.tlpMain.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox txtVideoFile;
        private System.Windows.Forms.TextBox txtTimecodesFile;
        private System.Windows.Forms.Label lblVideoFile;
        private System.Windows.Forms.Label lblTimecodesFile;
        private System.Windows.Forms.Button btnBrowseVideoFile;
        private System.Windows.Forms.Button btnBrowseTimecodesFile;
        private System.Windows.Forms.Button btnGenerateTimecodesFile;
        private System.Windows.Forms.Button btnBrowseSectionsFile;
        private System.Windows.Forms.Label lblSectionsFile;
        private System.Windows.Forms.TextBox txtSectionsFile;
        private System.Windows.Forms.Button btnPreviewSectionsFile;
        private System.Windows.Forms.Button btnPreviewVideoFile;
        private System.Windows.Forms.Button btnGenerateMeguiCutsFile;
        private System.Windows.Forms.GroupBox grpInput;
        private System.Windows.Forms.GroupBox grpFunctions;
        private System.Windows.Forms.GroupBox grpOutput;
        private System.Windows.Forms.Button btnBrowseMeguiCutsFile;
        private System.Windows.Forms.Label lblMeguiCutFile;
        private System.Windows.Forms.TextBox txtMeguiCutsFile;
        private System.Windows.Forms.TableLayoutPanel tlpMain;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Label lblFrameRate;
        private System.Windows.Forms.ComboBox cmbFrameRate;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Panel panel5;
    }
}