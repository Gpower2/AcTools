using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Drawing;
using System.Diagnostics;
using System.Globalization;

using AcControls.AcRichTextBoxControl;
using AcControls.AcMessageBox;

using AcToolsLibrary.Common;

namespace AcTools.Core
{
    public enum FormHookState
    {
        Hooked,
        Unhooked
    }

    public partial class AcForm : Form
    {
        /// <summary>
        /// Gets the form's border width in pixels
        /// </summary>
        public Int32 BorderWidth
        {
            get { return Convert.ToInt32(Convert.ToDouble((this.Width - this.ClientSize.Width)) / 2.0); }
        }

        /// <summary>
        /// Gets the form's Title Bar Height in pixels
        /// </summary>
        public Int32 TitlebarHeight
        {
            get { return this.Height - this.ClientSize.Height - 2 * BorderWidth; }
        }

        public ToolTip Tooltip { get; } = new ToolTip();

        protected FormHookState HookState = FormHookState.Hooked;        
        
        protected CultureInfo InvariantCulture = CultureInfo.InvariantCulture;

        public AcForm()
            : base()
        {
            this.DoubleBuffered = true;
            SetStyle(ControlStyles.OptimizedDoubleBuffer, true);

            InitializeComponent();
        }

        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // AcForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(284, 262);
            this.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.Name = "AcForm";
            this.ResumeLayout(false);
        }

        public void HookUnHook(Button btnHook = null)
        {
            if (HookState == FormHookState.Hooked)
            {
                this.MdiParent = null;
                HookState = FormHookState.Unhooked;
            }
            else
            {
                this.MdiParent = Application.OpenForms[0];
                HookState = FormHookState.Hooked;
            }
            if (btnHook != null)
            {
                if (HookState == FormHookState.Unhooked)
                {
                    btnHook.Text = "Hook";
                }
                else
                {
                    btnHook.Text = "UnHook";
                }
            }
        }

        /// <summary>
        /// Sets BackColors for all the controls in the form
        /// </summary>
        public virtual void InitColors()
        {
            this.BackColor = Color.FromArgb(AcSettings.Instance.FormBackColor); // Color.LightSteelBlue;
            foreach (Control ctrl in this.Controls)
            {
                initColors(ctrl);
            }
        }

        private void initColors(Control ctrl)
        {
            if (ctrl.GetType() == typeof(TrackBar))
            {
                ctrl.BackColor = Color.FromArgb(AcSettings.Instance.FormBackColor); //Color.LightSteelBlue;
            }
            else if (ctrl.GetType() == typeof(AcControls.AcVideoSlider.AcVideoSlider))
            {
                ctrl.BackColor = Color.FromArgb(AcSettings.Instance.FormBackColor); //Color.LightSteelBlue;
            }
            else if (ctrl.GetType() == typeof(TextBox))
            {
                if (((TextBox)ctrl).ReadOnly)
                {
                    ctrl.BackColor = Color.FromArgb(AcSettings.Instance.ReadOnlyControlBackColor); //Color.LightSteelBlue;;
                }
                else
                {
                    ctrl.BackColor = Color.FromArgb(AcSettings.Instance.EnabledControlBackColor); //Color.AliceBlue;;
                }
            }
            else if (ctrl.GetType() == typeof(AcRichTextBox))
            {
                if (((AcRichTextBox)ctrl).ReadOnly)
                {
                    ctrl.BackColor = Color.FromArgb(AcSettings.Instance.ReadOnlyControlBackColor); //Color.LightSteelBlue;;
                }
                else
                {
                    ctrl.BackColor = Color.FromArgb(AcSettings.Instance.EnabledControlBackColor); //Color.AliceBlue;;
                }
            }
            else if (ctrl.GetType() == typeof(RadioButton))
            {
                ctrl.BackColor = Color.Transparent;
            }
            else if (ctrl.GetType() == typeof(CheckBox))
            {
                ctrl.BackColor = Color.Transparent;
            }
            else if (ctrl.GetType() == typeof(Label))
            {
                ctrl.BackColor = Color.Transparent;
            }
            else if (ctrl.GetType() == typeof(PictureBox))
            {
                ctrl.BackColor = Color.FromArgb(AcSettings.Instance.EnabledControlBackColor); //Color.AliceBlue;;
            }
            else if (ctrl.GetType() == typeof(AcControls.AcVideoFramePictureBox.AcVideoFramePictureBox))
            {
                ctrl.BackColor = Color.FromArgb(AcSettings.Instance.EnabledControlBackColor); //Color.AliceBlue;;
            }
            else if (ctrl.GetType() == typeof(TabPage))
            {
                ctrl.BackColor = Color.FromArgb(AcSettings.Instance.FormBackColor); //Color.LightSteelBlue;
                foreach (Control grpCtrl in ((TabPage)ctrl).Controls)
                {
                    initColors(grpCtrl);
                }
            }
            else if (ctrl.GetType() == typeof(Panel))
            {
                ctrl.BackColor = Color.Transparent;
                foreach (Control grpCtrl in ((Panel)ctrl).Controls)
                {
                    initColors(grpCtrl);
                }
            }
            else if (ctrl.GetType() == typeof(GroupBox))
            {
                ctrl.BackColor = Color.Transparent;
                foreach (Control grpCtrl in ((GroupBox)ctrl).Controls)
                {
                    initColors(grpCtrl);
                }
            }
            else if (ctrl.GetType() == typeof(TableLayoutPanel))
            {
                ctrl.BackColor = Color.Transparent;
                foreach (Control grpCtrl in ((TableLayoutPanel)ctrl).Controls)
                {
                    initColors(grpCtrl);
                }
            }
            else if (ctrl.GetType() == typeof(TabControl))
            {
                ctrl.BackColor = Color.FromArgb(AcSettings.Instance.FormBackColor); //Color.LightSteelBlue;
                foreach (Control grpCtrl in ((TabControl)ctrl).Controls)
                {
                    initColors(grpCtrl);
                }
            }
            else if (ctrl.GetType() == typeof(Button))
            {
                ((Button)ctrl).FlatStyle = AcSettings.Instance.ControlFlatStyle;//FlatStyle.System;
            }
            else
            {
                ctrl.BackColor = Color.FromArgb(AcSettings.Instance.EnabledControlBackColor); //Color.AliceBlue;;
            }
        }

        /// <summary>
        /// Sets the flat style for all the button controls in the form
        /// </summary>
        public virtual void InitControls()
        {
            foreach (Control ctrl in this.Controls)
            {
                initControl(ctrl);
            }
        }

        private void initControl(Control ctrl)
        {
            //Exclude Courier family fonts
            if (!(ctrl.Font.Name.ToLower().Contains("courier") || ctrl.Font.Name.ToLower().Contains("consolas")))
            {
                ctrl.Font = AcSettings.Instance.MyFont;
            }
            if (ctrl.GetType() == typeof(Button))
            {
                ((Button)ctrl).FlatStyle = AcSettings.Instance.ControlFlatStyle;//FlatStyle.System;
            }
            else if (ctrl.GetType() == typeof(RadioButton))
            {
                ((RadioButton)ctrl).FlatStyle = AcSettings.Instance.ControlFlatStyle;//FlatStyle.System;
            }
            else if (ctrl.GetType() == typeof(CheckBox))
            {
                ((CheckBox)ctrl).FlatStyle = AcSettings.Instance.ControlFlatStyle;//FlatStyle.System;
            }
            else if (ctrl.GetType() == typeof(ComboBox))
            {
                ((ComboBox)ctrl).FlatStyle = AcSettings.Instance.ControlFlatStyle;//FlatStyle.System;
            }
            else if (ctrl.GetType() == typeof(GroupBox))
            {
                foreach (Control grpCtrl in ((GroupBox)ctrl).Controls)
                {
                    initControl(grpCtrl);
                }
            }
            else if (ctrl.GetType() == typeof(TableLayoutPanel))
            {
                foreach (Control grpCtrl in ((TableLayoutPanel)ctrl).Controls)
                {
                    initControl(grpCtrl);
                }
            }
            else if (ctrl.GetType() == typeof(TabControl))
            {
                foreach (Control grpCtrl in ((TabControl)ctrl).Controls)
                {
                    initControl(grpCtrl);
                }
            }
        }

        /// <summary>
        /// Sets the icon to the actools
        /// </summary>
        public void InitIcon()
        {
            this.Icon = AcTools.Properties.Resources.actools;
        }

        /// <summary>
        /// Sets the icon to a predefined icon
        /// </summary>
        /// <param name="icn">the icon to set</param>
        public void InitIcon(Icon icn)
        {
            this.Icon = icn;
        }

        /// <summary>
        /// Shows an open file dialog and returns the selected files
        /// </summary>
        /// <param name="titleStr">the title of the open file dialog</param>
        /// <param name="initDirStr">the initial directory of the open file dialog</param>
        /// <param name="filterStr">the filter of the open file dialog</param>
        /// <param name="multiSelect">flag if the open file dialog supports selection of multiple files</param>
        /// <returns>the list of the selected files</returns>
        public String[] ShowOpenFileDialog(String titleStr, String initDirStr, String filterStr, Boolean multiSelect)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            if (filterStr.Length > 0)
            {
                ofd.Filter = filterStr;
            }
            if (titleStr.Length > 0)
            {
                ofd.Title = titleStr;
            }
            if (initDirStr.Length > 0)
            {
                ofd.InitialDirectory = initDirStr;
            }
            ofd.Multiselect = multiSelect;

            if (ofd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                return ofd.FileNames;
            }
            return null;
        }

        /// <summary>
        /// Shows an open file dialog and returns the selected files
        /// </summary>
        /// <param name="titleStr">the title of the save file dialog</param>
        /// <param name="initDirStr">the initial directory of the save file dialog</param>
        /// <param name="filterStr">the filter of the save file dialog</param>
        /// <returns>the selected filename for save</returns>
        public String ShowSaveFileDialog(String titleStr, String initDirStr, String filterStr)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            if (filterStr.Length > 0)
            {
                sfd.Filter = filterStr;
            }
            if (titleStr.Length > 0)
            {
                sfd.Title = titleStr;
            }
            if (initDirStr.Length > 0)
            {
                sfd.InitialDirectory = initDirStr;
            }
            if (sfd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                return sfd.FileName;
            }
            return null;
        }

        /// <summary>
        /// Shows another form with the same Mdi Parent
        /// </summary>
        /// <param name="frm">the form to show</param>
        public void ShowForm(AcForm frm)
        {
            frm.MdiParent = this.MdiParent;
            frm.HookState = this.HookState;
            frm.StartPosition = FormStartPosition.CenterParent;
            frm.Show();
            frm.Focus();
        }

        /// <summary>
        /// Used from Settings form to reinit the form with the new settings
        /// </summary>
        public void ReInit()
        {
            InitColors();
            InitControls();
        }

        /// <summary>
        /// Each form that wants to use this function must implement it on its own
        /// Mainly used to update controls from other threads (like video player)
        /// </summary>
        /// <param name="obj"></param>
        public virtual void UpdateGUI(Object obj)
        {
        }

        /// <summary>
        /// Show an error message to the user
        /// </summary>
        /// <param name="errorMessage">The error message</param>
        /// <param name="errorTitle">The title of the error message</param>
        public void ShowErrorMessage(String errorMessage, String errorTitle = "An error has occured!")
        {
            AcMessageBox.Show(String.Format("An error has occured!\r\n\r\n{0}", errorMessage), errorTitle, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        /// <summary>
        /// Shows an Exception message to the user, Debug writes the Exception and Logs to the file and logger
        /// </summary>
        /// <param name="errorException">The Exception to be shown</param>
        /// <param name="errorTitle">The title of the Exception message</param>
        public void ShowExceptionMessage(Exception errorException, String errorTitle = "An error has occured!")
        {
            Debug.WriteLine(errorException);
            AcLogger.Log(errorException, AcLogType.FileAndLogger);
            ShowErrorMessage(errorException.Message);
        }

        /// <summary>
        /// Shows a suceess message to the user
        /// </summary>
        /// <param name="successMessage">The success message</param>
        /// <param name="successTitle">The title of the success message</param>
        public void ShowSuccessMessage(String successMessage, String successTitle = "Success!")
        {
            AcMessageBox.Show(successMessage, successTitle, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        /// <summary>
        /// Shows an information message to the user
        /// </summary>
        /// <param name="infoMessage">The information message</param>
        /// <param name="infoTitle">The title of the information message</param>
        public void ShowInformationMessage(String infoMessage, String infoTitle = "Information")
        {
            AcMessageBox.Show(infoMessage, infoTitle, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        /// <summary>
        /// Shows a warning message
        /// </summary>
        /// <param name="warningMessage">The warning message</param>
        /// <param name="warningTitle">The title of the warning message</param>
        public void ShowWarningMessage(String warningMessage, String warningTitle = "Warning!")
        {
            AcMessageBox.Show(String.Format("Warning!\r\n\r\n{0}", warningMessage), warningTitle, MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        /// <summary>
        /// Shows a question to the user and returns the answer (Yes, No, Cancel)
        /// </summary>
        /// <param name="questionMessage">The question text</param>
        /// <param name="questionTitle">The title of the question</param>
        /// <param name="showCancel">Whether to show Cancel button or not</param>
        /// <returns>The answer of the user</returns>
        public DialogResult ShowQuestion(String questionMessage, String questionTitle = "Are you sure?", Boolean showCancel = true)
        {
            MessageBoxButtons btns = MessageBoxButtons.YesNoCancel;
            if (!showCancel)
            {
                btns = MessageBoxButtons.YesNo;
            }
            return AcMessageBox.Show(questionMessage, questionTitle, btns, MessageBoxIcon.Question);
        }

        /// <summary>
        /// Shows a question as a warning to the user and returns the answer (Yes, No, Cancel)
        /// </summary>
        /// <param name="questionMessage">The question text</param>
        /// <param name="questionTitle">The title of the question</param>
        /// <returns>The answer of the user</returns>
        public DialogResult ShowWarningQuestion(String questionMessage, String questionTitle = "Warning!")
        {
            return AcMessageBox.Show(questionMessage, questionTitle, MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning);
        }
    }
}
