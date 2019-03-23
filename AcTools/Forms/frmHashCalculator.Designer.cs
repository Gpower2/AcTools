namespace AcTools.Forms
{
    partial class frmHashCalculator
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
            this.grpHashes = new System.Windows.Forms.GroupBox();
            this.btnCalculateEd2k = new System.Windows.Forms.Button();
            this.txtHashEd2k = new System.Windows.Forms.TextBox();
            this.lblHashEd2k = new System.Windows.Forms.Label();
            this.btnCalculateMD4 = new System.Windows.Forms.Button();
            this.txtHashMd4 = new System.Windows.Forms.TextBox();
            this.lblHashMd4 = new System.Windows.Forms.Label();
            this.btnCalculateTTH = new System.Windows.Forms.Button();
            this.txtHashTTH = new System.Windows.Forms.TextBox();
            this.lblTTH = new System.Windows.Forms.Label();
            this.btnCalculateSHA512 = new System.Windows.Forms.Button();
            this.btnCalculateSHA384 = new System.Windows.Forms.Button();
            this.btnCalculateSHA256 = new System.Windows.Forms.Button();
            this.btnCalculateSHA1 = new System.Windows.Forms.Button();
            this.btnCalculateCRC32 = new System.Windows.Forms.Button();
            this.btnCalculateMD5 = new System.Windows.Forms.Button();
            this.txtHashSHA512 = new System.Windows.Forms.TextBox();
            this.lblHashSHA512 = new System.Windows.Forms.Label();
            this.txtHashSHA384 = new System.Windows.Forms.TextBox();
            this.lblHashSHA384 = new System.Windows.Forms.Label();
            this.txtHashSHA256 = new System.Windows.Forms.TextBox();
            this.lblHashSHA256 = new System.Windows.Forms.Label();
            this.txtHashSHA1 = new System.Windows.Forms.TextBox();
            this.lblHashSHA1 = new System.Windows.Forms.Label();
            this.txtHashCrc32 = new System.Windows.Forms.TextBox();
            this.lblHashCrc32 = new System.Windows.Forms.Label();
            this.txtHashMD5 = new System.Windows.Forms.TextBox();
            this.lblHashMD5 = new System.Windows.Forms.Label();
            this.btnChangeCase = new System.Windows.Forms.Button();
            this.lblStatus = new System.Windows.Forms.Label();
            this.btnCalculateAll = new System.Windows.Forms.Button();
            this.btnHook = new System.Windows.Forms.Button();
            this.grpInput = new System.Windows.Forms.GroupBox();
            this.tabCtrlInput = new System.Windows.Forms.TabControl();
            this.tabPageFile = new System.Windows.Forms.TabPage();
            this.btnBrowseInputFile = new System.Windows.Forms.Button();
            this.txtInputFile = new System.Windows.Forms.TextBox();
            this.tabPageText = new System.Windows.Forms.TabPage();
            this.txtText = new System.Windows.Forms.TextBox();
            this.grpFunctions = new System.Windows.Forms.GroupBox();
            this.grpHashes.SuspendLayout();
            this.grpInput.SuspendLayout();
            this.tabCtrlInput.SuspendLayout();
            this.tabPageFile.SuspendLayout();
            this.tabPageText.SuspendLayout();
            this.grpFunctions.SuspendLayout();
            this.SuspendLayout();
            // 
            // grpHashes
            // 
            this.grpHashes.Controls.Add(this.btnCalculateEd2k);
            this.grpHashes.Controls.Add(this.txtHashEd2k);
            this.grpHashes.Controls.Add(this.lblHashEd2k);
            this.grpHashes.Controls.Add(this.btnCalculateMD4);
            this.grpHashes.Controls.Add(this.txtHashMd4);
            this.grpHashes.Controls.Add(this.lblHashMd4);
            this.grpHashes.Controls.Add(this.btnCalculateTTH);
            this.grpHashes.Controls.Add(this.txtHashTTH);
            this.grpHashes.Controls.Add(this.lblTTH);
            this.grpHashes.Controls.Add(this.btnCalculateSHA512);
            this.grpHashes.Controls.Add(this.btnCalculateSHA384);
            this.grpHashes.Controls.Add(this.btnCalculateSHA256);
            this.grpHashes.Controls.Add(this.btnCalculateSHA1);
            this.grpHashes.Controls.Add(this.btnCalculateCRC32);
            this.grpHashes.Controls.Add(this.btnCalculateMD5);
            this.grpHashes.Controls.Add(this.txtHashSHA512);
            this.grpHashes.Controls.Add(this.lblHashSHA512);
            this.grpHashes.Controls.Add(this.txtHashSHA384);
            this.grpHashes.Controls.Add(this.lblHashSHA384);
            this.grpHashes.Controls.Add(this.txtHashSHA256);
            this.grpHashes.Controls.Add(this.lblHashSHA256);
            this.grpHashes.Controls.Add(this.txtHashSHA1);
            this.grpHashes.Controls.Add(this.lblHashSHA1);
            this.grpHashes.Controls.Add(this.txtHashCrc32);
            this.grpHashes.Controls.Add(this.lblHashCrc32);
            this.grpHashes.Controls.Add(this.txtHashMD5);
            this.grpHashes.Controls.Add(this.lblHashMD5);
            this.grpHashes.Location = new System.Drawing.Point(6, 148);
            this.grpHashes.Name = "grpHashes";
            this.grpHashes.Size = new System.Drawing.Size(722, 287);
            this.grpHashes.TabIndex = 4;
            this.grpHashes.TabStop = false;
            this.grpHashes.Text = "Hash Results";
            // 
            // btnCalculateEd2k
            // 
            this.btnCalculateEd2k.Location = new System.Drawing.Point(643, 76);
            this.btnCalculateEd2k.Name = "btnCalculateEd2k";
            this.btnCalculateEd2k.Size = new System.Drawing.Size(70, 26);
            this.btnCalculateEd2k.TabIndex = 29;
            this.btnCalculateEd2k.Text = "Calculate";
            this.btnCalculateEd2k.UseVisualStyleBackColor = true;
            this.btnCalculateEd2k.Click += new System.EventHandler(this.btnCalculateHash_Click);
            // 
            // txtHashEd2k
            // 
            this.txtHashEd2k.Location = new System.Drawing.Point(56, 79);
            this.txtHashEd2k.Name = "txtHashEd2k";
            this.txtHashEd2k.ReadOnly = true;
            this.txtHashEd2k.Size = new System.Drawing.Size(582, 21);
            this.txtHashEd2k.TabIndex = 28;
            // 
            // lblHashEd2k
            // 
            this.lblHashEd2k.AutoSize = true;
            this.lblHashEd2k.Location = new System.Drawing.Point(23, 83);
            this.lblHashEd2k.Name = "lblHashEd2k";
            this.lblHashEd2k.Size = new System.Drawing.Size(32, 13);
            this.lblHashEd2k.TabIndex = 27;
            this.lblHashEd2k.Text = "ED2K";
            // 
            // btnCalculateMD4
            // 
            this.btnCalculateMD4.Location = new System.Drawing.Point(643, 48);
            this.btnCalculateMD4.Name = "btnCalculateMD4";
            this.btnCalculateMD4.Size = new System.Drawing.Size(70, 26);
            this.btnCalculateMD4.TabIndex = 26;
            this.btnCalculateMD4.Text = "Calculate";
            this.btnCalculateMD4.UseVisualStyleBackColor = true;
            this.btnCalculateMD4.Click += new System.EventHandler(this.btnCalculateHash_Click);
            // 
            // txtHashMd4
            // 
            this.txtHashMd4.Location = new System.Drawing.Point(56, 51);
            this.txtHashMd4.Name = "txtHashMd4";
            this.txtHashMd4.ReadOnly = true;
            this.txtHashMd4.Size = new System.Drawing.Size(582, 21);
            this.txtHashMd4.TabIndex = 25;
            // 
            // lblHashMd4
            // 
            this.lblHashMd4.AutoSize = true;
            this.lblHashMd4.Location = new System.Drawing.Point(27, 55);
            this.lblHashMd4.Name = "lblHashMd4";
            this.lblHashMd4.Size = new System.Drawing.Size(28, 13);
            this.lblHashMd4.TabIndex = 24;
            this.lblHashMd4.Text = "MD4";
            // 
            // btnCalculateTTH
            // 
            this.btnCalculateTTH.Location = new System.Drawing.Point(643, 249);
            this.btnCalculateTTH.Name = "btnCalculateTTH";
            this.btnCalculateTTH.Size = new System.Drawing.Size(70, 26);
            this.btnCalculateTTH.TabIndex = 23;
            this.btnCalculateTTH.Text = "Calculate";
            this.btnCalculateTTH.UseVisualStyleBackColor = true;
            this.btnCalculateTTH.Click += new System.EventHandler(this.btnCalculateHash_Click);
            // 
            // txtHashTTH
            // 
            this.txtHashTTH.Location = new System.Drawing.Point(55, 252);
            this.txtHashTTH.Name = "txtHashTTH";
            this.txtHashTTH.ReadOnly = true;
            this.txtHashTTH.Size = new System.Drawing.Size(582, 21);
            this.txtHashTTH.TabIndex = 22;
            // 
            // lblTTH
            // 
            this.lblTTH.AutoSize = true;
            this.lblTTH.Location = new System.Drawing.Point(29, 256);
            this.lblTTH.Name = "lblTTH";
            this.lblTTH.Size = new System.Drawing.Size(26, 13);
            this.lblTTH.TabIndex = 21;
            this.lblTTH.Text = "TTH";
            // 
            // btnCalculateSHA512
            // 
            this.btnCalculateSHA512.Location = new System.Drawing.Point(643, 220);
            this.btnCalculateSHA512.Name = "btnCalculateSHA512";
            this.btnCalculateSHA512.Size = new System.Drawing.Size(70, 26);
            this.btnCalculateSHA512.TabIndex = 18;
            this.btnCalculateSHA512.Text = "Calculate";
            this.btnCalculateSHA512.UseVisualStyleBackColor = true;
            this.btnCalculateSHA512.Click += new System.EventHandler(this.btnCalculateHash_Click);
            // 
            // btnCalculateSHA384
            // 
            this.btnCalculateSHA384.Location = new System.Drawing.Point(643, 191);
            this.btnCalculateSHA384.Name = "btnCalculateSHA384";
            this.btnCalculateSHA384.Size = new System.Drawing.Size(70, 26);
            this.btnCalculateSHA384.TabIndex = 17;
            this.btnCalculateSHA384.Text = "Calculate";
            this.btnCalculateSHA384.UseVisualStyleBackColor = true;
            this.btnCalculateSHA384.Click += new System.EventHandler(this.btnCalculateHash_Click);
            // 
            // btnCalculateSHA256
            // 
            this.btnCalculateSHA256.Location = new System.Drawing.Point(643, 163);
            this.btnCalculateSHA256.Name = "btnCalculateSHA256";
            this.btnCalculateSHA256.Size = new System.Drawing.Size(70, 26);
            this.btnCalculateSHA256.TabIndex = 16;
            this.btnCalculateSHA256.Text = "Calculate";
            this.btnCalculateSHA256.UseVisualStyleBackColor = true;
            this.btnCalculateSHA256.Click += new System.EventHandler(this.btnCalculateHash_Click);
            // 
            // btnCalculateSHA1
            // 
            this.btnCalculateSHA1.Location = new System.Drawing.Point(643, 134);
            this.btnCalculateSHA1.Name = "btnCalculateSHA1";
            this.btnCalculateSHA1.Size = new System.Drawing.Size(70, 26);
            this.btnCalculateSHA1.TabIndex = 15;
            this.btnCalculateSHA1.Text = "Calculate";
            this.btnCalculateSHA1.UseVisualStyleBackColor = true;
            this.btnCalculateSHA1.Click += new System.EventHandler(this.btnCalculateHash_Click);
            // 
            // btnCalculateCRC32
            // 
            this.btnCalculateCRC32.Location = new System.Drawing.Point(643, 104);
            this.btnCalculateCRC32.Name = "btnCalculateCRC32";
            this.btnCalculateCRC32.Size = new System.Drawing.Size(70, 26);
            this.btnCalculateCRC32.TabIndex = 14;
            this.btnCalculateCRC32.Text = "Calculate";
            this.btnCalculateCRC32.UseVisualStyleBackColor = true;
            this.btnCalculateCRC32.Click += new System.EventHandler(this.btnCalculateHash_Click);
            // 
            // btnCalculateMD5
            // 
            this.btnCalculateMD5.Location = new System.Drawing.Point(643, 19);
            this.btnCalculateMD5.Name = "btnCalculateMD5";
            this.btnCalculateMD5.Size = new System.Drawing.Size(70, 26);
            this.btnCalculateMD5.TabIndex = 12;
            this.btnCalculateMD5.Text = "Calculate";
            this.btnCalculateMD5.UseVisualStyleBackColor = true;
            this.btnCalculateMD5.Click += new System.EventHandler(this.btnCalculateHash_Click);
            // 
            // txtHashSHA512
            // 
            this.txtHashSHA512.Location = new System.Drawing.Point(56, 223);
            this.txtHashSHA512.Name = "txtHashSHA512";
            this.txtHashSHA512.ReadOnly = true;
            this.txtHashSHA512.Size = new System.Drawing.Size(582, 21);
            this.txtHashSHA512.TabIndex = 11;
            // 
            // lblHashSHA512
            // 
            this.lblHashSHA512.AutoSize = true;
            this.lblHashSHA512.Location = new System.Drawing.Point(10, 227);
            this.lblHashSHA512.Name = "lblHashSHA512";
            this.lblHashSHA512.Size = new System.Drawing.Size(45, 13);
            this.lblHashSHA512.TabIndex = 10;
            this.lblHashSHA512.Text = "SHA512";
            // 
            // txtHashSHA384
            // 
            this.txtHashSHA384.Location = new System.Drawing.Point(56, 192);
            this.txtHashSHA384.Name = "txtHashSHA384";
            this.txtHashSHA384.ReadOnly = true;
            this.txtHashSHA384.Size = new System.Drawing.Size(582, 21);
            this.txtHashSHA384.TabIndex = 9;
            // 
            // lblHashSHA384
            // 
            this.lblHashSHA384.AutoSize = true;
            this.lblHashSHA384.Location = new System.Drawing.Point(10, 196);
            this.lblHashSHA384.Name = "lblHashSHA384";
            this.lblHashSHA384.Size = new System.Drawing.Size(45, 13);
            this.lblHashSHA384.TabIndex = 8;
            this.lblHashSHA384.Text = "SHA384";
            // 
            // txtHashSHA256
            // 
            this.txtHashSHA256.Location = new System.Drawing.Point(56, 166);
            this.txtHashSHA256.Name = "txtHashSHA256";
            this.txtHashSHA256.ReadOnly = true;
            this.txtHashSHA256.Size = new System.Drawing.Size(582, 21);
            this.txtHashSHA256.TabIndex = 7;
            // 
            // lblHashSHA256
            // 
            this.lblHashSHA256.AutoSize = true;
            this.lblHashSHA256.Location = new System.Drawing.Point(10, 170);
            this.lblHashSHA256.Name = "lblHashSHA256";
            this.lblHashSHA256.Size = new System.Drawing.Size(45, 13);
            this.lblHashSHA256.TabIndex = 6;
            this.lblHashSHA256.Text = "SHA256";
            // 
            // txtHashSHA1
            // 
            this.txtHashSHA1.Location = new System.Drawing.Point(56, 137);
            this.txtHashSHA1.Name = "txtHashSHA1";
            this.txtHashSHA1.ReadOnly = true;
            this.txtHashSHA1.Size = new System.Drawing.Size(582, 21);
            this.txtHashSHA1.TabIndex = 5;
            // 
            // lblHashSHA1
            // 
            this.lblHashSHA1.AutoSize = true;
            this.lblHashSHA1.Location = new System.Drawing.Point(22, 141);
            this.lblHashSHA1.Name = "lblHashSHA1";
            this.lblHashSHA1.Size = new System.Drawing.Size(33, 13);
            this.lblHashSHA1.TabIndex = 4;
            this.lblHashSHA1.Text = "SHA1";
            // 
            // txtHashCrc32
            // 
            this.txtHashCrc32.Location = new System.Drawing.Point(56, 107);
            this.txtHashCrc32.Name = "txtHashCrc32";
            this.txtHashCrc32.ReadOnly = true;
            this.txtHashCrc32.Size = new System.Drawing.Size(582, 21);
            this.txtHashCrc32.TabIndex = 3;
            // 
            // lblHashCrc32
            // 
            this.lblHashCrc32.AutoSize = true;
            this.lblHashCrc32.Location = new System.Drawing.Point(15, 111);
            this.lblHashCrc32.Name = "lblHashCrc32";
            this.lblHashCrc32.Size = new System.Drawing.Size(40, 13);
            this.lblHashCrc32.TabIndex = 2;
            this.lblHashCrc32.Text = "CRC32";
            // 
            // txtHashMD5
            // 
            this.txtHashMD5.Location = new System.Drawing.Point(56, 22);
            this.txtHashMD5.Name = "txtHashMD5";
            this.txtHashMD5.ReadOnly = true;
            this.txtHashMD5.Size = new System.Drawing.Size(582, 21);
            this.txtHashMD5.TabIndex = 1;
            // 
            // lblHashMD5
            // 
            this.lblHashMD5.AutoSize = true;
            this.lblHashMD5.Location = new System.Drawing.Point(27, 26);
            this.lblHashMD5.Name = "lblHashMD5";
            this.lblHashMD5.Size = new System.Drawing.Size(28, 13);
            this.lblHashMD5.TabIndex = 0;
            this.lblHashMD5.Text = "MD5";
            // 
            // btnChangeCase
            // 
            this.btnChangeCase.Location = new System.Drawing.Point(90, 19);
            this.btnChangeCase.Name = "btnChangeCase";
            this.btnChangeCase.Size = new System.Drawing.Size(70, 34);
            this.btnChangeCase.TabIndex = 24;
            this.btnChangeCase.Text = "To Upper";
            this.btnChangeCase.UseVisualStyleBackColor = true;
            this.btnChangeCase.Click += new System.EventHandler(this.btnChangeCase_Click);
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Location = new System.Drawing.Point(275, 30);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(0, 13);
            this.lblStatus.TabIndex = 20;
            this.lblStatus.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btnCalculateAll
            // 
            this.btnCalculateAll.Location = new System.Drawing.Point(8, 19);
            this.btnCalculateAll.Name = "btnCalculateAll";
            this.btnCalculateAll.Size = new System.Drawing.Size(76, 34);
            this.btnCalculateAll.TabIndex = 19;
            this.btnCalculateAll.Text = "Calculate All";
            this.btnCalculateAll.UseVisualStyleBackColor = true;
            this.btnCalculateAll.Click += new System.EventHandler(this.btnCalculateAll_Click);
            // 
            // btnHook
            // 
            this.btnHook.Location = new System.Drawing.Point(661, 24);
            this.btnHook.Name = "btnHook";
            this.btnHook.Size = new System.Drawing.Size(58, 28);
            this.btnHook.TabIndex = 13;
            this.btnHook.Text = "UnHook";
            this.btnHook.UseVisualStyleBackColor = true;
            this.btnHook.Click += new System.EventHandler(this.btnHook_Click);
            // 
            // grpInput
            // 
            this.grpInput.Controls.Add(this.tabCtrlInput);
            this.grpInput.Location = new System.Drawing.Point(6, 8);
            this.grpInput.Name = "grpInput";
            this.grpInput.Size = new System.Drawing.Size(722, 138);
            this.grpInput.TabIndex = 3;
            this.grpInput.TabStop = false;
            this.grpInput.Text = "Input";
            // 
            // tabCtrlInput
            // 
            this.tabCtrlInput.Controls.Add(this.tabPageFile);
            this.tabCtrlInput.Controls.Add(this.tabPageText);
            this.tabCtrlInput.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabCtrlInput.Location = new System.Drawing.Point(3, 17);
            this.tabCtrlInput.Name = "tabCtrlInput";
            this.tabCtrlInput.SelectedIndex = 0;
            this.tabCtrlInput.Size = new System.Drawing.Size(716, 118);
            this.tabCtrlInput.TabIndex = 0;
            // 
            // tabPageFile
            // 
            this.tabPageFile.Controls.Add(this.btnBrowseInputFile);
            this.tabPageFile.Controls.Add(this.txtInputFile);
            this.tabPageFile.Location = new System.Drawing.Point(4, 22);
            this.tabPageFile.Name = "tabPageFile";
            this.tabPageFile.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageFile.Size = new System.Drawing.Size(708, 92);
            this.tabPageFile.TabIndex = 0;
            this.tabPageFile.Text = "File";
            this.tabPageFile.UseVisualStyleBackColor = true;
            // 
            // btnBrowseInputFile
            // 
            this.btnBrowseInputFile.Location = new System.Drawing.Point(637, 33);
            this.btnBrowseInputFile.Name = "btnBrowseInputFile";
            this.btnBrowseInputFile.Size = new System.Drawing.Size(69, 29);
            this.btnBrowseInputFile.TabIndex = 1;
            this.btnBrowseInputFile.Text = "Browse...";
            this.btnBrowseInputFile.UseVisualStyleBackColor = true;
            this.btnBrowseInputFile.Click += new System.EventHandler(this.btnBrowseInputFile_Click);
            // 
            // txtInputFile
            // 
            this.txtInputFile.AllowDrop = true;
            this.txtInputFile.Location = new System.Drawing.Point(7, 38);
            this.txtInputFile.Name = "txtInputFile";
            this.txtInputFile.Size = new System.Drawing.Size(624, 21);
            this.txtInputFile.TabIndex = 0;
            this.txtInputFile.TextChanged += new System.EventHandler(this.txtInputFile_TextChanged);
            this.txtInputFile.DragDrop += new System.Windows.Forms.DragEventHandler(this.txtInputFile_DragDrop);
            this.txtInputFile.DragEnter += new System.Windows.Forms.DragEventHandler(this.txtInputFile_DragEnter);
            // 
            // tabPageText
            // 
            this.tabPageText.Controls.Add(this.txtText);
            this.tabPageText.Location = new System.Drawing.Point(4, 22);
            this.tabPageText.Name = "tabPageText";
            this.tabPageText.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageText.Size = new System.Drawing.Size(708, 93);
            this.tabPageText.TabIndex = 1;
            this.tabPageText.Text = "Text";
            this.tabPageText.UseVisualStyleBackColor = true;
            // 
            // txtText
            // 
            this.txtText.Location = new System.Drawing.Point(6, 6);
            this.txtText.Multiline = true;
            this.txtText.Name = "txtText";
            this.txtText.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtText.Size = new System.Drawing.Size(696, 81);
            this.txtText.TabIndex = 2;
            this.txtText.TextChanged += new System.EventHandler(this.txtInputFile_TextChanged);
            // 
            // grpFunctions
            // 
            this.grpFunctions.Controls.Add(this.btnChangeCase);
            this.grpFunctions.Controls.Add(this.btnCalculateAll);
            this.grpFunctions.Controls.Add(this.btnHook);
            this.grpFunctions.Controls.Add(this.lblStatus);
            this.grpFunctions.Location = new System.Drawing.Point(6, 441);
            this.grpFunctions.Name = "grpFunctions";
            this.grpFunctions.Size = new System.Drawing.Size(722, 62);
            this.grpFunctions.TabIndex = 5;
            this.grpFunctions.TabStop = false;
            this.grpFunctions.Text = "Functions";
            // 
            // HashCalculatorForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(734, 508);
            this.Controls.Add(this.grpFunctions);
            this.Controls.Add(this.grpHashes);
            this.Controls.Add(this.grpInput);
            this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.Name = "HashCalculatorForm";
            this.Text = "HashCalculatorForm";
            this.grpHashes.ResumeLayout(false);
            this.grpHashes.PerformLayout();
            this.grpInput.ResumeLayout(false);
            this.tabCtrlInput.ResumeLayout(false);
            this.tabPageFile.ResumeLayout(false);
            this.tabPageFile.PerformLayout();
            this.tabPageText.ResumeLayout(false);
            this.tabPageText.PerformLayout();
            this.grpFunctions.ResumeLayout(false);
            this.grpFunctions.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grpInput;
        private System.Windows.Forms.TabControl tabCtrlInput;
        private System.Windows.Forms.TabPage tabPageFile;
        private System.Windows.Forms.Button btnBrowseInputFile;
        private System.Windows.Forms.TextBox txtInputFile;
        private System.Windows.Forms.TabPage tabPageText;
        private System.Windows.Forms.TextBox txtText;
        private System.Windows.Forms.GroupBox grpHashes;
        private System.Windows.Forms.TextBox txtHashCrc32;
        private System.Windows.Forms.Label lblHashCrc32;
        private System.Windows.Forms.TextBox txtHashMD5;
        private System.Windows.Forms.Label lblHashMD5;
        private System.Windows.Forms.TextBox txtHashSHA512;
        private System.Windows.Forms.Label lblHashSHA512;
        private System.Windows.Forms.TextBox txtHashSHA384;
        private System.Windows.Forms.Label lblHashSHA384;
        private System.Windows.Forms.TextBox txtHashSHA256;
        private System.Windows.Forms.Label lblHashSHA256;
        private System.Windows.Forms.TextBox txtHashSHA1;
        private System.Windows.Forms.Label lblHashSHA1;
        private System.Windows.Forms.Button btnHook;
        private System.Windows.Forms.Button btnCalculateMD5;
        private System.Windows.Forms.Button btnCalculateAll;
        private System.Windows.Forms.Button btnCalculateSHA512;
        private System.Windows.Forms.Button btnCalculateSHA384;
        private System.Windows.Forms.Button btnCalculateSHA256;
        private System.Windows.Forms.Button btnCalculateSHA1;
        private System.Windows.Forms.Button btnCalculateCRC32;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.Button btnCalculateTTH;
        private System.Windows.Forms.TextBox txtHashTTH;
        private System.Windows.Forms.Label lblTTH;
        private System.Windows.Forms.Button btnChangeCase;
        private System.Windows.Forms.GroupBox grpFunctions;
        private System.Windows.Forms.Button btnCalculateEd2k;
        private System.Windows.Forms.TextBox txtHashEd2k;
        private System.Windows.Forms.Label lblHashEd2k;
        private System.Windows.Forms.Button btnCalculateMD4;
        private System.Windows.Forms.TextBox txtHashMd4;
        private System.Windows.Forms.Label lblHashMd4;

    }
}