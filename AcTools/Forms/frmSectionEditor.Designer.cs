namespace AcTools.Forms
{
    partial class frmSectionEditor
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
            this.btnHook = new System.Windows.Forms.Button();
            this.listSections = new System.Windows.Forms.ListBox();
            this.txtSectionName = new System.Windows.Forms.TextBox();
            this.txtStartFrame = new System.Windows.Forms.TextBox();
            this.txtEndFrame = new System.Windows.Forms.TextBox();
            this.lblSectionName = new System.Windows.Forms.Label();
            this.lblStartFrame = new System.Windows.Forms.Label();
            this.lblEndFrame = new System.Windows.Forms.Label();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnRemove = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.btnSaveToFile = new System.Windows.Forms.Button();
            this.btnLoadFromFile = new System.Windows.Forms.Button();
            this.btnEndFromVideo = new System.Windows.Forms.Button();
            this.btnStartFromVideo = new System.Windows.Forms.Button();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.checkOnTop = new System.Windows.Forms.CheckBox();
            this.btnAutoName = new System.Windows.Forms.Button();
            this.btnUseVideo = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnHook
            // 
            this.btnHook.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnHook.Location = new System.Drawing.Point(265, 336);
            this.btnHook.Name = "btnHook";
            this.btnHook.Size = new System.Drawing.Size(72, 32);
            this.btnHook.TabIndex = 0;
            this.btnHook.Text = "UnHook";
            this.btnHook.UseVisualStyleBackColor = true;
            this.btnHook.Click += new System.EventHandler(this.btnHook_Click);
            // 
            // listSections
            // 
            this.listSections.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listSections.FormattingEnabled = true;
            this.listSections.ItemHeight = 15;
            this.listSections.Location = new System.Drawing.Point(9, 123);
            this.listSections.Name = "listSections";
            this.listSections.Size = new System.Drawing.Size(234, 199);
            this.listSections.TabIndex = 1;
            this.listSections.SelectedIndexChanged += new System.EventHandler(this.listSections_SelectedIndexChanged);
            // 
            // txtSectionName
            // 
            this.txtSectionName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSectionName.Location = new System.Drawing.Point(93, 7);
            this.txtSectionName.Name = "txtSectionName";
            this.txtSectionName.Size = new System.Drawing.Size(150, 23);
            this.txtSectionName.TabIndex = 2;
            // 
            // txtStartFrame
            // 
            this.txtStartFrame.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtStartFrame.Location = new System.Drawing.Point(93, 45);
            this.txtStartFrame.Name = "txtStartFrame";
            this.txtStartFrame.Size = new System.Drawing.Size(55, 23);
            this.txtStartFrame.TabIndex = 3;
            // 
            // txtEndFrame
            // 
            this.txtEndFrame.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtEndFrame.Location = new System.Drawing.Point(93, 81);
            this.txtEndFrame.Name = "txtEndFrame";
            this.txtEndFrame.Size = new System.Drawing.Size(55, 23);
            this.txtEndFrame.TabIndex = 4;
            // 
            // lblSectionName
            // 
            this.lblSectionName.AutoSize = true;
            this.lblSectionName.Location = new System.Drawing.Point(6, 12);
            this.lblSectionName.Name = "lblSectionName";
            this.lblSectionName.Size = new System.Drawing.Size(81, 15);
            this.lblSectionName.TabIndex = 5;
            this.lblSectionName.Text = "Section Name";
            // 
            // lblStartFrame
            // 
            this.lblStartFrame.AutoSize = true;
            this.lblStartFrame.Location = new System.Drawing.Point(6, 50);
            this.lblStartFrame.Name = "lblStartFrame";
            this.lblStartFrame.Size = new System.Drawing.Size(67, 15);
            this.lblStartFrame.TabIndex = 6;
            this.lblStartFrame.Text = "Start Frame";
            // 
            // lblEndFrame
            // 
            this.lblEndFrame.AutoSize = true;
            this.lblEndFrame.Location = new System.Drawing.Point(6, 84);
            this.lblEndFrame.Name = "lblEndFrame";
            this.lblEndFrame.Size = new System.Drawing.Size(63, 15);
            this.lblEndFrame.TabIndex = 7;
            this.lblEndFrame.Text = "End Frame";
            // 
            // btnAdd
            // 
            this.btnAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAdd.Location = new System.Drawing.Point(250, 75);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(89, 32);
            this.btnAdd.TabIndex = 8;
            this.btnAdd.Text = "Add";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnRemove
            // 
            this.btnRemove.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRemove.Location = new System.Drawing.Point(250, 122);
            this.btnRemove.Name = "btnRemove";
            this.btnRemove.Size = new System.Drawing.Size(89, 36);
            this.btnRemove.TabIndex = 9;
            this.btnRemove.Text = "Remove";
            this.btnRemove.UseVisualStyleBackColor = true;
            this.btnRemove.Click += new System.EventHandler(this.btnRemove_Click);
            // 
            // btnClear
            // 
            this.btnClear.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClear.Location = new System.Drawing.Point(250, 164);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(89, 36);
            this.btnClear.TabIndex = 10;
            this.btnClear.Text = "Clear";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // btnSaveToFile
            // 
            this.btnSaveToFile.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSaveToFile.Location = new System.Drawing.Point(250, 290);
            this.btnSaveToFile.Name = "btnSaveToFile";
            this.btnSaveToFile.Size = new System.Drawing.Size(89, 36);
            this.btnSaveToFile.TabIndex = 11;
            this.btnSaveToFile.Text = "Save...";
            this.btnSaveToFile.UseVisualStyleBackColor = true;
            this.btnSaveToFile.Click += new System.EventHandler(this.btnSaveToFile_Click);
            // 
            // btnLoadFromFile
            // 
            this.btnLoadFromFile.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnLoadFromFile.Location = new System.Drawing.Point(250, 249);
            this.btnLoadFromFile.Name = "btnLoadFromFile";
            this.btnLoadFromFile.Size = new System.Drawing.Size(89, 36);
            this.btnLoadFromFile.TabIndex = 12;
            this.btnLoadFromFile.Text = "Load...";
            this.btnLoadFromFile.UseVisualStyleBackColor = true;
            this.btnLoadFromFile.Click += new System.EventHandler(this.btnLoadFromFile_Click);
            // 
            // btnEndFromVideo
            // 
            this.btnEndFromVideo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnEndFromVideo.Location = new System.Drawing.Point(154, 75);
            this.btnEndFromVideo.Name = "btnEndFromVideo";
            this.btnEndFromVideo.Size = new System.Drawing.Size(89, 32);
            this.btnEndFromVideo.TabIndex = 13;
            this.btnEndFromVideo.Text = "From Video";
            this.btnEndFromVideo.UseVisualStyleBackColor = true;
            this.btnEndFromVideo.Click += new System.EventHandler(this.btnEndFromVideo_Click);
            // 
            // btnStartFromVideo
            // 
            this.btnStartFromVideo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnStartFromVideo.Location = new System.Drawing.Point(154, 39);
            this.btnStartFromVideo.Name = "btnStartFromVideo";
            this.btnStartFromVideo.Size = new System.Drawing.Size(89, 32);
            this.btnStartFromVideo.TabIndex = 13;
            this.btnStartFromVideo.Text = "From Video";
            this.btnStartFromVideo.UseVisualStyleBackColor = true;
            this.btnStartFromVideo.Click += new System.EventHandler(this.btnStartFromVideo_Click);
            // 
            // btnUpdate
            // 
            this.btnUpdate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnUpdate.Location = new System.Drawing.Point(250, 39);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(89, 32);
            this.btnUpdate.TabIndex = 14;
            this.btnUpdate.Text = "Update";
            this.btnUpdate.UseVisualStyleBackColor = true;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // checkOnTop
            // 
            this.checkOnTop.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.checkOnTop.AutoSize = true;
            this.checkOnTop.Location = new System.Drawing.Point(9, 344);
            this.checkOnTop.Name = "checkOnTop";
            this.checkOnTop.Size = new System.Drawing.Size(66, 19);
            this.checkOnTop.TabIndex = 15;
            this.checkOnTop.Text = "On Top";
            this.checkOnTop.UseVisualStyleBackColor = true;
            this.checkOnTop.CheckedChanged += new System.EventHandler(this.checkOnTop_CheckedChanged);
            // 
            // btnAutoName
            // 
            this.btnAutoName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAutoName.Location = new System.Drawing.Point(250, 3);
            this.btnAutoName.Name = "btnAutoName";
            this.btnAutoName.Size = new System.Drawing.Size(89, 32);
            this.btnAutoName.TabIndex = 16;
            this.btnAutoName.Text = "Auto Name";
            this.btnAutoName.UseVisualStyleBackColor = true;
            this.btnAutoName.Click += new System.EventHandler(this.btnAutoName_Click);
            // 
            // btnUseVideo
            // 
            this.btnUseVideo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnUseVideo.Location = new System.Drawing.Point(250, 206);
            this.btnUseVideo.Name = "btnUseVideo";
            this.btnUseVideo.Size = new System.Drawing.Size(89, 36);
            this.btnUseVideo.TabIndex = 17;
            this.btnUseVideo.Text = "Use Video...";
            this.btnUseVideo.UseVisualStyleBackColor = true;
            this.btnUseVideo.Click += new System.EventHandler(this.btnUseVideo_Click);
            // 
            // SectionEditorForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(344, 371);
            this.Controls.Add(this.btnUseVideo);
            this.Controls.Add(this.btnAutoName);
            this.Controls.Add(this.checkOnTop);
            this.Controls.Add(this.btnUpdate);
            this.Controls.Add(this.btnStartFromVideo);
            this.Controls.Add(this.btnEndFromVideo);
            this.Controls.Add(this.btnLoadFromFile);
            this.Controls.Add(this.btnSaveToFile);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.btnRemove);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.lblEndFrame);
            this.Controls.Add(this.lblStartFrame);
            this.Controls.Add(this.lblSectionName);
            this.Controls.Add(this.txtEndFrame);
            this.Controls.Add(this.txtStartFrame);
            this.Controls.Add(this.txtSectionName);
            this.Controls.Add(this.listSections);
            this.Controls.Add(this.btnHook);
            this.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.MinimumSize = new System.Drawing.Size(360, 410);
            this.Name = "SectionEditorForm";
            this.Text = "SectionEditorForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnHook;
        private System.Windows.Forms.ListBox listSections;
        private System.Windows.Forms.TextBox txtSectionName;
        private System.Windows.Forms.TextBox txtStartFrame;
        private System.Windows.Forms.TextBox txtEndFrame;
        private System.Windows.Forms.Label lblSectionName;
        private System.Windows.Forms.Label lblStartFrame;
        private System.Windows.Forms.Label lblEndFrame;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnRemove;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Button btnSaveToFile;
        private System.Windows.Forms.Button btnLoadFromFile;
        private System.Windows.Forms.Button btnEndFromVideo;
        private System.Windows.Forms.Button btnStartFromVideo;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.CheckBox checkOnTop;
        private System.Windows.Forms.Button btnAutoName;
        private System.Windows.Forms.Button btnUseVideo;
    }
}