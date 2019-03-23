namespace AcTools.Forms
{
    partial class frmSettings
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
            this.label1 = new System.Windows.Forms.Label();
            this.picFormBackColor = new System.Windows.Forms.PictureBox();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.txtFontSample = new System.Windows.Forms.TextBox();
            this.btnChangeFont = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.picReadOnlyControlBackColor = new System.Windows.Forms.PictureBox();
            this.label4 = new System.Windows.Forms.Label();
            this.picDisabledControlBackColor = new System.Windows.Forms.PictureBox();
            this.label3 = new System.Windows.Forms.Label();
            this.picEnabledControlBackColor = new System.Windows.Forms.PictureBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnDefaults = new System.Windows.Forms.Button();
            this.btnApply = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnOk = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.picFormBackColor)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picReadOnlyControlBackColor)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picDisabledControlBackColor)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picEnabledControlBackColor)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(40, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(84, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Form Back Color";
            // 
            // picFormBackColor
            // 
            this.picFormBackColor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picFormBackColor.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picFormBackColor.Location = new System.Drawing.Point(201, 17);
            this.picFormBackColor.Name = "picFormBackColor";
            this.picFormBackColor.Size = new System.Drawing.Size(66, 28);
            this.picFormBackColor.TabIndex = 1;
            this.picFormBackColor.TabStop = false;
            this.picFormBackColor.Click += new System.EventHandler(this.picFormBackColor_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(3, 3);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(363, 269);
            this.tabControl1.TabIndex = 2;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.txtFontSample);
            this.tabPage1.Controls.Add(this.btnChangeFont);
            this.tabPage1.Controls.Add(this.label5);
            this.tabPage1.Controls.Add(this.picReadOnlyControlBackColor);
            this.tabPage1.Controls.Add(this.label4);
            this.tabPage1.Controls.Add(this.picDisabledControlBackColor);
            this.tabPage1.Controls.Add(this.label3);
            this.tabPage1.Controls.Add(this.picEnabledControlBackColor);
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Controls.Add(this.picFormBackColor);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(355, 243);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "GUI";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // txtFontSample
            // 
            this.txtFontSample.Location = new System.Drawing.Point(80, 160);
            this.txtFontSample.Name = "txtFontSample";
            this.txtFontSample.Size = new System.Drawing.Size(107, 21);
            this.txtFontSample.TabIndex = 10;
            this.txtFontSample.Text = "Sample";
            // 
            // btnChangeFont
            // 
            this.btnChangeFont.Location = new System.Drawing.Point(201, 154);
            this.btnChangeFont.Name = "btnChangeFont";
            this.btnChangeFont.Size = new System.Drawing.Size(66, 33);
            this.btnChangeFont.TabIndex = 9;
            this.btnChangeFont.Text = "Change...";
            this.btnChangeFont.UseVisualStyleBackColor = true;
            this.btnChangeFont.Click += new System.EventHandler(this.btnChangeFont_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(40, 164);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(29, 13);
            this.label5.TabIndex = 8;
            this.label5.Text = "Font";
            // 
            // picReadOnlyControlBackColor
            // 
            this.picReadOnlyControlBackColor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picReadOnlyControlBackColor.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picReadOnlyControlBackColor.Location = new System.Drawing.Point(201, 119);
            this.picReadOnlyControlBackColor.Name = "picReadOnlyControlBackColor";
            this.picReadOnlyControlBackColor.Size = new System.Drawing.Size(66, 28);
            this.picReadOnlyControlBackColor.TabIndex = 7;
            this.picReadOnlyControlBackColor.TabStop = false;
            this.picReadOnlyControlBackColor.Click += new System.EventHandler(this.picReadOnlyControlBackColor_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(40, 127);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(148, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Read Only Control Back Color";
            // 
            // picDisabledControlBackColor
            // 
            this.picDisabledControlBackColor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picDisabledControlBackColor.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picDisabledControlBackColor.Location = new System.Drawing.Point(201, 85);
            this.picDisabledControlBackColor.Name = "picDisabledControlBackColor";
            this.picDisabledControlBackColor.Size = new System.Drawing.Size(66, 28);
            this.picDisabledControlBackColor.TabIndex = 5;
            this.picDisabledControlBackColor.TabStop = false;
            this.picDisabledControlBackColor.Click += new System.EventHandler(this.picDisabledControlBackColor_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(40, 93);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(138, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Disabled Control Back Color";
            // 
            // picEnabledControlBackColor
            // 
            this.picEnabledControlBackColor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picEnabledControlBackColor.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picEnabledControlBackColor.Location = new System.Drawing.Point(201, 51);
            this.picEnabledControlBackColor.Name = "picEnabledControlBackColor";
            this.picEnabledControlBackColor.Size = new System.Drawing.Size(66, 28);
            this.picEnabledControlBackColor.TabIndex = 3;
            this.picEnabledControlBackColor.TabStop = false;
            this.picEnabledControlBackColor.Click += new System.EventHandler(this.picEnabledControlBackColor_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(40, 59);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(136, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Enabled Control Back Color";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.tabControl1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.panel1, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(369, 325);
            this.tableLayoutPanel1.TabIndex = 3;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnDefaults);
            this.panel1.Controls.Add(this.btnApply);
            this.panel1.Controls.Add(this.btnCancel);
            this.panel1.Controls.Add(this.btnOk);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(3, 278);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(363, 44);
            this.panel1.TabIndex = 3;
            // 
            // btnDefaults
            // 
            this.btnDefaults.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnDefaults.Location = new System.Drawing.Point(3, 6);
            this.btnDefaults.Name = "btnDefaults";
            this.btnDefaults.Size = new System.Drawing.Size(81, 32);
            this.btnDefaults.TabIndex = 3;
            this.btnDefaults.Text = "Defaults";
            this.btnDefaults.UseVisualStyleBackColor = true;
            this.btnDefaults.Click += new System.EventHandler(this.btnDefaults_Click);
            // 
            // btnApply
            // 
            this.btnApply.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnApply.Location = new System.Drawing.Point(103, 6);
            this.btnApply.Name = "btnApply";
            this.btnApply.Size = new System.Drawing.Size(81, 32);
            this.btnApply.TabIndex = 2;
            this.btnApply.Text = "Apply";
            this.btnApply.UseVisualStyleBackColor = true;
            this.btnApply.Click += new System.EventHandler(this.btnApply_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.Location = new System.Drawing.Point(278, 6);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(81, 32);
            this.btnCancel.TabIndex = 1;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnOk
            // 
            this.btnOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOk.Location = new System.Drawing.Point(191, 6);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(81, 32);
            this.btnOk.TabIndex = 0;
            this.btnOk.Text = "OK";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // SettingsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(369, 325);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.Name = "SettingsForm";
            this.Text = "SettingsForm";
            ((System.ComponentModel.ISupportInitialize)(this.picFormBackColor)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picReadOnlyControlBackColor)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picDisabledControlBackColor)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picEnabledControlBackColor)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox picFormBackColor;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnApply;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.PictureBox picReadOnlyControlBackColor;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.PictureBox picDisabledControlBackColor;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.PictureBox picEnabledControlBackColor;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtFontSample;
        private System.Windows.Forms.Button btnChangeFont;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnDefaults;
    }
}