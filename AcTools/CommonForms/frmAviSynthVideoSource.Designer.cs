namespace AcTools.CommonForms
{
    partial class frmAviSynthVideoSource
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
            this.grpSourceProviders = new System.Windows.Forms.GroupBox();
            this.radioDirectShowSource2 = new System.Windows.Forms.RadioButton();
            this.radioFFMpegSource2 = new System.Windows.Forms.RadioButton();
            this.radioDGAVCDec = new System.Windows.Forms.RadioButton();
            this.radioDGMPGDec = new System.Windows.Forms.RadioButton();
            this.radioDirectShowSource = new System.Windows.Forms.RadioButton();
            this.radioAviSource = new System.Windows.Forms.RadioButton();
            this.btnOK = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.cmbFramerate = new System.Windows.Forms.ComboBox();
            this.checkFramerate = new System.Windows.Forms.CheckBox();
            this.grpSourceProviders.SuspendLayout();
            this.SuspendLayout();
            // 
            // grpSourceProviders
            // 
            this.grpSourceProviders.Controls.Add(this.radioDirectShowSource2);
            this.grpSourceProviders.Controls.Add(this.radioFFMpegSource2);
            this.grpSourceProviders.Controls.Add(this.radioDGAVCDec);
            this.grpSourceProviders.Controls.Add(this.radioDGMPGDec);
            this.grpSourceProviders.Controls.Add(this.radioDirectShowSource);
            this.grpSourceProviders.Controls.Add(this.radioAviSource);
            this.grpSourceProviders.Location = new System.Drawing.Point(12, 13);
            this.grpSourceProviders.Name = "grpSourceProviders";
            this.grpSourceProviders.Size = new System.Drawing.Size(293, 269);
            this.grpSourceProviders.TabIndex = 0;
            this.grpSourceProviders.TabStop = false;
            this.grpSourceProviders.Text = "AviSynth Video Source Providers";
            // 
            // radioDirectShowSource2
            // 
            this.radioDirectShowSource2.AutoSize = true;
            this.radioDirectShowSource2.Location = new System.Drawing.Point(62, 230);
            this.radioDirectShowSource2.Name = "radioDirectShowSource2";
            this.radioDirectShowSource2.Size = new System.Drawing.Size(161, 19);
            this.radioDirectShowSource2.TabIndex = 5;
            this.radioDirectShowSource2.TabStop = true;
            this.radioDirectShowSource2.Text = "DirectShowSource2 (dss2)";
            this.radioDirectShowSource2.UseVisualStyleBackColor = true;
            // 
            // radioFFMpegSource2
            // 
            this.radioFFMpegSource2.AutoSize = true;
            this.radioFFMpegSource2.Location = new System.Drawing.Point(62, 191);
            this.radioFFMpegSource2.Name = "radioFFMpegSource2";
            this.radioFFMpegSource2.Size = new System.Drawing.Size(157, 19);
            this.radioFFMpegSource2.TabIndex = 4;
            this.radioFFMpegSource2.TabStop = true;
            this.radioFFMpegSource2.Text = "FFMpeg Source 2 (ffms2)";
            this.radioFFMpegSource2.UseVisualStyleBackColor = true;
            // 
            // radioDGAVCDec
            // 
            this.radioDGAVCDec.AutoSize = true;
            this.radioDGAVCDec.Location = new System.Drawing.Point(62, 151);
            this.radioDGAVCDec.Name = "radioDGAVCDec";
            this.radioDGAVCDec.Size = new System.Drawing.Size(114, 19);
            this.radioDGAVCDec.TabIndex = 3;
            this.radioDGAVCDec.TabStop = true;
            this.radioDGAVCDec.Text = "DG AVC Decoder";
            this.radioDGAVCDec.UseVisualStyleBackColor = true;
            // 
            // radioDGMPGDec
            // 
            this.radioDGMPGDec.AutoSize = true;
            this.radioDGMPGDec.Location = new System.Drawing.Point(62, 111);
            this.radioDGMPGDec.Name = "radioDGMPGDec";
            this.radioDGMPGDec.Size = new System.Drawing.Size(122, 19);
            this.radioDGMPGDec.TabIndex = 2;
            this.radioDGMPGDec.TabStop = true;
            this.radioDGMPGDec.Text = "DG Mpeg Decoder";
            this.radioDGMPGDec.UseVisualStyleBackColor = true;
            // 
            // radioDirectShowSource
            // 
            this.radioDirectShowSource.AutoSize = true;
            this.radioDirectShowSource.Location = new System.Drawing.Point(62, 72);
            this.radioDirectShowSource.Name = "radioDirectShowSource";
            this.radioDirectShowSource.Size = new System.Drawing.Size(171, 19);
            this.radioDirectShowSource.TabIndex = 1;
            this.radioDirectShowSource.TabStop = true;
            this.radioDirectShowSource.Text = "DirectShowSource (Built-in)";
            this.radioDirectShowSource.UseVisualStyleBackColor = true;
            // 
            // radioAviSource
            // 
            this.radioAviSource.AutoSize = true;
            this.radioAviSource.Location = new System.Drawing.Point(62, 32);
            this.radioAviSource.Name = "radioAviSource";
            this.radioAviSource.Size = new System.Drawing.Size(128, 19);
            this.radioAviSource.TabIndex = 0;
            this.radioAviSource.TabStop = true;
            this.radioAviSource.Text = "AviSource (Built-in)";
            this.radioAviSource.UseVisualStyleBackColor = true;
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(12, 329);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(118, 40);
            this.btnOK.TabIndex = 1;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(184, 329);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(121, 40);
            this.btnCancel.TabIndex = 2;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // cmbFramerate
            // 
            this.cmbFramerate.FormattingEnabled = true;
            this.cmbFramerate.Location = new System.Drawing.Point(162, 295);
            this.cmbFramerate.Name = "cmbFramerate";
            this.cmbFramerate.Size = new System.Drawing.Size(120, 23);
            this.cmbFramerate.TabIndex = 3;
            // 
            // checkFramerate
            // 
            this.checkFramerate.AutoSize = true;
            this.checkFramerate.Location = new System.Drawing.Point(31, 297);
            this.checkFramerate.Name = "checkFramerate";
            this.checkFramerate.Size = new System.Drawing.Size(125, 19);
            this.checkFramerate.TabIndex = 4;
            this.checkFramerate.Text = "Override framerate";
            this.checkFramerate.UseVisualStyleBackColor = true;
            // 
            // AviSynthVideoSourceForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(321, 377);
            this.Controls.Add(this.checkFramerate);
            this.Controls.Add(this.cmbFramerate);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.grpSourceProviders);
            this.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "AviSynthVideoSourceForm";
            this.Text = "AviSynth VideoSource Picker";
            this.grpSourceProviders.ResumeLayout(false);
            this.grpSourceProviders.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox grpSourceProviders;
        private System.Windows.Forms.RadioButton radioDirectShowSource2;
        private System.Windows.Forms.RadioButton radioFFMpegSource2;
        private System.Windows.Forms.RadioButton radioDGAVCDec;
        private System.Windows.Forms.RadioButton radioDGMPGDec;
        private System.Windows.Forms.RadioButton radioDirectShowSource;
        private System.Windows.Forms.RadioButton radioAviSource;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.ComboBox cmbFramerate;
        private System.Windows.Forms.CheckBox checkFramerate;

    }
}