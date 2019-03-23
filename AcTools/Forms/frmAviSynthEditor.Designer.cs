namespace AcTools.Forms
{
    partial class frmAviSynthEditor
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
            this.rtxtAviSynthCode = new AcControls.AcRichTextBoxControl.AcRichTextBox();
            this.SuspendLayout();
            // 
            // rtxtAviSynthCode
            // 
            this.rtxtAviSynthCode.CaseSensitive = false;
            this.rtxtAviSynthCode.FilterAutoComplete = false;
            this.rtxtAviSynthCode.Location = new System.Drawing.Point(12, 12);
            this.rtxtAviSynthCode.MaxUndoRedoSteps = 50;
            this.rtxtAviSynthCode.Name = "rtxtAviSynthCode";
            this.rtxtAviSynthCode.Size = new System.Drawing.Size(696, 398);
            this.rtxtAviSynthCode.TabIndex = 1;
            this.rtxtAviSynthCode.Text = "";
            // 
            // AviSynthEditorForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(720, 433);
            this.Controls.Add(this.rtxtAviSynthCode);
            this.Name = "AviSynthEditorForm";
            this.Text = "AviSynthEditorForm";
            this.ResumeLayout(false);

        }

        #endregion

        private AcControls.AcRichTextBoxControl.AcRichTextBox rtxtAviSynthCode;
    }
}