namespace AcTools.CommonForms
{
    partial class frmLogger
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
            this.lstLines = new System.Windows.Forms.ListBox();
            this.btnCopy = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnReload = new System.Windows.Forms.Button();
            this.tlpMain = new System.Windows.Forms.TableLayoutPanel();
            this.grpLines = new System.Windows.Forms.GroupBox();
            this.grpFunctions = new System.Windows.Forms.GroupBox();
            this.tlpMain.SuspendLayout();
            this.grpLines.SuspendLayout();
            this.grpFunctions.SuspendLayout();
            this.SuspendLayout();
            // 
            // lstLines
            // 
            this.lstLines.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lstLines.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.lstLines.FormattingEnabled = true;
            this.lstLines.HorizontalScrollbar = true;
            this.lstLines.ItemHeight = 15;
            this.lstLines.Location = new System.Drawing.Point(3, 19);
            this.lstLines.Name = "lstLines";
            this.lstLines.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.lstLines.Size = new System.Drawing.Size(716, 401);
            this.lstLines.TabIndex = 0;
            // 
            // btnCopy
            // 
            this.btnCopy.Location = new System.Drawing.Point(7, 23);
            this.btnCopy.Name = "btnCopy";
            this.btnCopy.Size = new System.Drawing.Size(98, 39);
            this.btnCopy.TabIndex = 1;
            this.btnCopy.Text = "Copy Selection";
            this.btnCopy.UseVisualStyleBackColor = true;
            this.btnCopy.Click += new System.EventHandler(this.btnCopy_Click);
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.Location = new System.Drawing.Point(617, 23);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(98, 39);
            this.btnClose.TabIndex = 2;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnReload
            // 
            this.btnReload.Location = new System.Drawing.Point(112, 23);
            this.btnReload.Name = "btnReload";
            this.btnReload.Size = new System.Drawing.Size(98, 39);
            this.btnReload.TabIndex = 3;
            this.btnReload.Text = "Reload";
            this.btnReload.UseVisualStyleBackColor = true;
            this.btnReload.Click += new System.EventHandler(this.btnReload_Click);
            // 
            // tlpMain
            // 
            this.tlpMain.ColumnCount = 1;
            this.tlpMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpMain.Controls.Add(this.grpLines, 0, 0);
            this.tlpMain.Controls.Add(this.grpFunctions, 0, 1);
            this.tlpMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpMain.Location = new System.Drawing.Point(0, 0);
            this.tlpMain.Name = "tlpMain";
            this.tlpMain.RowCount = 2;
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 81F));
            this.tlpMain.Size = new System.Drawing.Size(728, 510);
            this.tlpMain.TabIndex = 4;
            // 
            // grpLines
            // 
            this.grpLines.Controls.Add(this.lstLines);
            this.grpLines.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpLines.Location = new System.Drawing.Point(3, 3);
            this.grpLines.Name = "grpLines";
            this.grpLines.Size = new System.Drawing.Size(722, 423);
            this.grpLines.TabIndex = 0;
            this.grpLines.TabStop = false;
            // 
            // grpFunctions
            // 
            this.grpFunctions.Controls.Add(this.btnCopy);
            this.grpFunctions.Controls.Add(this.btnClose);
            this.grpFunctions.Controls.Add(this.btnReload);
            this.grpFunctions.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpFunctions.Location = new System.Drawing.Point(3, 432);
            this.grpFunctions.Name = "grpFunctions";
            this.grpFunctions.Size = new System.Drawing.Size(722, 75);
            this.grpFunctions.TabIndex = 1;
            this.grpFunctions.TabStop = false;
            this.grpFunctions.Text = "Functions";
            // 
            // LoggerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(728, 510);
            this.Controls.Add(this.tlpMain);
            this.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.MinimumSize = new System.Drawing.Size(744, 548);
            this.Name = "LoggerForm";
            this.Text = "LoggerForm";
            this.tlpMain.ResumeLayout(false);
            this.grpLines.ResumeLayout(false);
            this.grpFunctions.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox lstLines;
        private System.Windows.Forms.Button btnCopy;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnReload;
        private System.Windows.Forms.TableLayoutPanel tlpMain;
        private System.Windows.Forms.GroupBox grpLines;
        private System.Windows.Forms.GroupBox grpFunctions;
    }
}