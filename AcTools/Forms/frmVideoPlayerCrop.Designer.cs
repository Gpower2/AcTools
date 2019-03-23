namespace AcTools.Forms
{
    partial class frmVideoPlayerCrop
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
            this.numX1 = new System.Windows.Forms.NumericUpDown();
            this.numX2 = new System.Windows.Forms.NumericUpDown();
            this.numY1 = new System.Windows.Forms.NumericUpDown();
            this.numY2 = new System.Windows.Forms.NumericUpDown();
            this.lblX1 = new System.Windows.Forms.Label();
            this.lblX2 = new System.Windows.Forms.Label();
            this.lblY2 = new System.Windows.Forms.Label();
            this.lblY1 = new System.Windows.Forms.Label();
            this.txtAvisynthCrop = new System.Windows.Forms.TextBox();
            this.btnHook = new System.Windows.Forms.Button();
            this.btnReset = new System.Windows.Forms.Button();
            this.checkOnTop = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.numX1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numX2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numY1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numY2)).BeginInit();
            this.SuspendLayout();
            // 
            // numX1
            // 
            this.numX1.Location = new System.Drawing.Point(41, 45);
            this.numX1.Name = "numX1";
            this.numX1.Size = new System.Drawing.Size(38, 21);
            this.numX1.TabIndex = 0;
            this.numX1.ValueChanged += new System.EventHandler(this.Crop_ValueChanged);
            // 
            // numX2
            // 
            this.numX2.Location = new System.Drawing.Point(120, 45);
            this.numX2.Name = "numX2";
            this.numX2.Size = new System.Drawing.Size(38, 21);
            this.numX2.TabIndex = 1;
            this.numX2.ValueChanged += new System.EventHandler(this.Crop_ValueChanged);
            // 
            // numY1
            // 
            this.numY1.Location = new System.Drawing.Point(79, 4);
            this.numY1.Name = "numY1";
            this.numY1.Size = new System.Drawing.Size(38, 21);
            this.numY1.TabIndex = 2;
            this.numY1.ValueChanged += new System.EventHandler(this.Crop_ValueChanged);
            // 
            // numY2
            // 
            this.numY2.Location = new System.Drawing.Point(79, 87);
            this.numY2.Name = "numY2";
            this.numY2.Size = new System.Drawing.Size(38, 21);
            this.numY2.TabIndex = 3;
            this.numY2.ValueChanged += new System.EventHandler(this.Crop_ValueChanged);
            // 
            // lblX1
            // 
            this.lblX1.AutoSize = true;
            this.lblX1.Location = new System.Drawing.Point(15, 49);
            this.lblX1.Name = "lblX1";
            this.lblX1.Size = new System.Drawing.Size(19, 13);
            this.lblX1.TabIndex = 4;
            this.lblX1.Text = "X1";
            // 
            // lblX2
            // 
            this.lblX2.AutoSize = true;
            this.lblX2.Location = new System.Drawing.Point(170, 49);
            this.lblX2.Name = "lblX2";
            this.lblX2.Size = new System.Drawing.Size(19, 13);
            this.lblX2.TabIndex = 5;
            this.lblX2.Text = "X2";
            // 
            // lblY2
            // 
            this.lblY2.AutoSize = true;
            this.lblY2.Location = new System.Drawing.Point(53, 90);
            this.lblY2.Name = "lblY2";
            this.lblY2.Size = new System.Drawing.Size(19, 13);
            this.lblY2.TabIndex = 6;
            this.lblY2.Text = "Y2";
            // 
            // lblY1
            // 
            this.lblY1.AutoSize = true;
            this.lblY1.Location = new System.Drawing.Point(53, 6);
            this.lblY1.Name = "lblY1";
            this.lblY1.Size = new System.Drawing.Size(19, 13);
            this.lblY1.TabIndex = 7;
            this.lblY1.Text = "Y1";
            // 
            // txtAvisynthCrop
            // 
            this.txtAvisynthCrop.Font = new System.Drawing.Font("Courier New", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.txtAvisynthCrop.Location = new System.Drawing.Point(1, 113);
            this.txtAvisynthCrop.Multiline = true;
            this.txtAvisynthCrop.Name = "txtAvisynthCrop";
            this.txtAvisynthCrop.ReadOnly = true;
            this.txtAvisynthCrop.Size = new System.Drawing.Size(196, 45);
            this.txtAvisynthCrop.TabIndex = 8;
            // 
            // btnHook
            // 
            this.btnHook.Location = new System.Drawing.Point(144, 163);
            this.btnHook.Name = "btnHook";
            this.btnHook.Size = new System.Drawing.Size(52, 28);
            this.btnHook.TabIndex = 9;
            this.btnHook.Text = "UnHook";
            this.btnHook.UseVisualStyleBackColor = true;
            this.btnHook.Click += new System.EventHandler(this.btnHook_Click);
            // 
            // btnReset
            // 
            this.btnReset.Location = new System.Drawing.Point(1, 163);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(52, 28);
            this.btnReset.TabIndex = 10;
            this.btnReset.Text = "Reset";
            this.btnReset.UseVisualStyleBackColor = true;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // checkOnTop
            // 
            this.checkOnTop.AutoSize = true;
            this.checkOnTop.Location = new System.Drawing.Point(69, 170);
            this.checkOnTop.Name = "checkOnTop";
            this.checkOnTop.Size = new System.Drawing.Size(61, 17);
            this.checkOnTop.TabIndex = 11;
            this.checkOnTop.Text = "On Top";
            this.checkOnTop.UseVisualStyleBackColor = true;
            this.checkOnTop.CheckedChanged += new System.EventHandler(this.checkOnTop_CheckedChanged);
            // 
            // VideoPlayerCropForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(201, 196);
            this.Controls.Add(this.checkOnTop);
            this.Controls.Add(this.btnReset);
            this.Controls.Add(this.btnHook);
            this.Controls.Add(this.txtAvisynthCrop);
            this.Controls.Add(this.lblY1);
            this.Controls.Add(this.lblY2);
            this.Controls.Add(this.lblX2);
            this.Controls.Add(this.lblX1);
            this.Controls.Add(this.numY2);
            this.Controls.Add(this.numY1);
            this.Controls.Add(this.numX2);
            this.Controls.Add(this.numX1);
            this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "VideoPlayerCropForm";
            this.Text = "VideoPlayerCropForm";
            ((System.ComponentModel.ISupportInitialize)(this.numX1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numX2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numY1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numY2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.NumericUpDown numX1;
        private System.Windows.Forms.NumericUpDown numX2;
        private System.Windows.Forms.NumericUpDown numY1;
        private System.Windows.Forms.NumericUpDown numY2;
        private System.Windows.Forms.Label lblX1;
        private System.Windows.Forms.Label lblX2;
        private System.Windows.Forms.Label lblY2;
        private System.Windows.Forms.Label lblY1;
        private System.Windows.Forms.TextBox txtAvisynthCrop;
        private System.Windows.Forms.Button btnHook;
        private System.Windows.Forms.Button btnReset;
        private System.Windows.Forms.CheckBox checkOnTop;
    }
}