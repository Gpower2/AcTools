using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using AcControls.Utilities;
using System.Diagnostics;

namespace AcControls.AcMessageBox
{
    public static class AcMessageBox 
    {
        public static DialogResult Show(String message)
        {
            using (AcMessageBoxForm msgForm = new AcMessageBoxForm(message))
            {
                return ShowForm(msgForm);
            }
        }

        public static DialogResult Show(String message, String title)
        {
            using (AcMessageBoxForm msgForm = new AcMessageBoxForm(message, title))
            {
                return ShowForm(msgForm);
            }
        }

        public static DialogResult Show(String message, String title, MessageBoxButtons mbuttons)
        {
            using (AcMessageBoxForm msgForm = new AcMessageBoxForm(message, title, mbuttons))
            {
                return ShowForm(msgForm);
            }
        }

        public static DialogResult Show(String message, String title, MessageBoxIcon micon)
        {
            using (AcMessageBoxForm msgForm = new AcMessageBoxForm(message, title, micon))
            {
                return ShowForm(msgForm);
            }
        }

        public static DialogResult Show(String message, String title, MessageBoxButtons mbuttons, MessageBoxIcon micon)
        {
            using (AcMessageBoxForm msgForm = new AcMessageBoxForm(message, title, mbuttons, micon))
            {
                return ShowForm(msgForm);
            }
        }

        public static DialogResult Show(String message, MessageBoxButtons mbuttons)
        {
            using (AcMessageBoxForm msgForm = new AcMessageBoxForm(message, mbuttons))
            {
                return ShowForm(msgForm);
            }
        }

        public static DialogResult Show(String message, MessageBoxIcon micon)
        {
            using (AcMessageBoxForm msgForm = new AcMessageBoxForm(message, micon))
            {
                return ShowForm(msgForm);
            }
        }

        public static DialogResult Show(String message, MessageBoxButtons mbuttons, MessageBoxIcon micon)
        {
            using (AcMessageBoxForm msgForm = new AcMessageBoxForm(message, mbuttons, micon))
            {
                return ShowForm(msgForm);
            }
        }

        private static DialogResult ShowForm(AcMessageBoxForm msgForm)
        {
            return msgForm.ShowDialog();

            //DialogResult res = DialogResult.None;
            //res = msgForm.ShowDialog();
            //try
            //{
            //    //try to set the focus to the main form of the application
            //    if (Application.OpenForms.Count > 0)
            //    {
            //        if (Application.OpenForms[0].IsHandleCreated)
            //        {
            //            Application.OpenForms[0].Invoke((MethodInvoker)delegate { Application.OpenForms[0].Select(); });
            //        }
            //        else
            //        {
            //            Application.OpenForms[0].Select();
            //        }
            //    }
            //}
            //catch (Exception ex)
            //{
            //    //If it's a cross thread operation, or fails otherwise, just debug write it
            //    Debug.WriteLine(ex);
            //}
            //return res;
        }

        private enum AcMessageBoxButtonTypes
        {
            OK,
            Cancel,
            Yes,
            No,
            Abort,
            Retry,
            Ignore,
            Copy
        }

        private class AcMessageBoxButton : Button
        {
            public AcMessageBoxButtonTypes buttonType = AcMessageBoxButtonTypes.OK;

            public AcMessageBoxButton(AcMessageBoxButtonTypes msgButton)
            {
                buttonType = msgButton;
                Text = Enum.GetName(typeof(AcMessageBoxButtonTypes), buttonType);
            }
        }

        private class AcMessageBoxForm : Form
        {
            //Controls
            private TableLayoutPanel tlpMain = null;
            private FlowLayoutPanel pnlButtons = null;
            private TableLayoutPanel tlpMessage = null;
            private TableLayoutPanel tlpText = null;
            private PictureBox picIcon = null;
            private TextBox txtMessage = null;
            private List<AcMessageBoxButton> acButtons = new List<AcMessageBoxButton>();

            //Properties
            private String _Message = String.Empty;
            private String _Title = String.Empty;
            private MessageBoxButtons _Buttons = MessageBoxButtons.OK;
            private MessageBoxIcon _Icon = MessageBoxIcon.Information;

            #region "Constructors"

            public AcMessageBoxForm(String message)
            {
                DialogResult = System.Windows.Forms.DialogResult.None;
                _Message = message;
                _Title = Application.ProductName;
                Init();
            }

            public AcMessageBoxForm(String message, String title)
            {
                DialogResult = System.Windows.Forms.DialogResult.None; 
                _Message = message;
                _Title = title;
                Init();
            }

            public AcMessageBoxForm(String message, String title, MessageBoxButtons mbuttons)
            {
                DialogResult = System.Windows.Forms.DialogResult.None;
                _Message = message;
                _Title = title;
                _Buttons = mbuttons;
                Init();
            }

            public AcMessageBoxForm(String message, String title, MessageBoxIcon micon)
            {
                DialogResult = System.Windows.Forms.DialogResult.None;
                _Message = message;
                _Title = title;
                _Icon = micon;
                Init();
            }

            public AcMessageBoxForm(String message, String title, MessageBoxButtons mbuttons, MessageBoxIcon micon)
            {
                DialogResult = System.Windows.Forms.DialogResult.None;
                _Message = message;
                _Title = title;
                _Buttons = mbuttons;
                _Icon = micon;
                Init();
            }

            public AcMessageBoxForm(String message, MessageBoxButtons mbuttons)
            {
                DialogResult = System.Windows.Forms.DialogResult.None;
                _Message = message;
                _Title = Application.ProductName;
                _Buttons = mbuttons;
                Init();
            }

            public AcMessageBoxForm(String message, MessageBoxIcon micon)
            {
                DialogResult = System.Windows.Forms.DialogResult.None;
                _Message = message;
                _Title = Application.ProductName;
                _Icon = micon;
                Init();
            }

            public AcMessageBoxForm(String message, MessageBoxButtons mbuttons, MessageBoxIcon micon)
            {
                DialogResult = System.Windows.Forms.DialogResult.None;
                _Message = message;
                _Title = Application.ProductName;
                _Buttons = mbuttons;
                _Icon = micon;
                Init();
            }

            #endregion

            private void Init()
            {
                //First, we must determine the minimum size of the form
                Int32 formWidth = 0, formHeight = 0;               
                Int32 charCount = 0, lines = 0;
                Int32 formMinimumWidth = 340;
                Int32 formMinimumHeight = 150;
                Int32 formMaximumWidth = (Screen.PrimaryScreen.WorkingArea.Width / 2);
                Int32 formMaximumHeight = Screen.PrimaryScreen.WorkingArea.Height / 2;
                this.Font = new System.Drawing.Font("Segoe UI", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
                System.Drawing.Graphics g = System.Drawing.Graphics.FromHwnd(this.Handle);
                System.Drawing.SizeF measureSize = g.MeasureString(_Message, this.Font,
                    new System.Drawing.SizeF(formMaximumWidth - 120, formMaximumHeight - 150),
                    new System.Drawing.StringFormat(), out charCount, out lines);
                if (lines > 1)
                {
                    formWidth = Convert.ToInt32(measureSize.Width) + 120;
                    formHeight = Convert.ToInt32(Convert.ToDouble(lines * this.Font.Height) / 0.7 + 150); 
                }
                else
                {
                    formWidth = Convert.ToInt32(measureSize.Width) + 120;
                    formHeight = Convert.ToInt32(measureSize.Height) + 150;
                }
                formWidth = formWidth < formMinimumWidth ? formMinimumWidth : formWidth;
                formHeight = formHeight < formMinimumHeight ? formMinimumHeight : formHeight;

                //Set the form properties
                this.Text = _Title;
                this.MinimizeBox = false;
                this.MaximizeBox = false;
                this.Icon = System.Drawing.Icon.ExtractAssociatedIcon(Application.ExecutablePath);
                this.Size = new System.Drawing.Size(formWidth, formHeight);
                this.MinimumSize = new System.Drawing.Size(formWidth, formHeight);
                this.MaximumSize = new System.Drawing.Size(formMaximumWidth, formMaximumHeight);
                this.StartPosition = FormStartPosition.CenterScreen;
                this.BackColor = System.Drawing.Color.White;
                this.Shown += new EventHandler(OnFormShown);

                //Create the main table layout panel
                tlpMain = new TableLayoutPanel();
                tlpMain.RowCount = 2;
                tlpMain.RowStyles.Add(new RowStyle(SizeType.Percent, 100));
                tlpMain.RowStyles.Add(new RowStyle(SizeType.Absolute, 40));
                tlpMain.ColumnCount = 1;
                tlpMain.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100));
                tlpMain.GrowStyle = TableLayoutPanelGrowStyle.AddColumns;
                tlpMain.Dock = DockStyle.Fill;

                //Create the panel for the buttons
                pnlButtons = new FlowLayoutPanel();
                pnlButtons.FlowDirection = FlowDirection.RightToLeft;
                pnlButtons.BackColor = System.Drawing.SystemColors.ControlLight;
                pnlButtons.Dock = DockStyle.Fill;

                //Create the buttons and place them in the panel
                AcMessageBoxButton tmpBtn = null;
                switch (_Buttons)
                {
                    case MessageBoxButtons.OK:
                        tmpBtn = new AcMessageBoxButton(AcMessageBoxButtonTypes.OK);
                        acButtons.Add(tmpBtn);
                        break;
                    case MessageBoxButtons.OKCancel:
                        tmpBtn = new AcMessageBoxButton(AcMessageBoxButtonTypes.Cancel);
                        acButtons.Add(tmpBtn);
                        tmpBtn = new AcMessageBoxButton(AcMessageBoxButtonTypes.OK);
                        acButtons.Add(tmpBtn);
                        break;
                    case MessageBoxButtons.YesNo:
                        tmpBtn = new AcMessageBoxButton(AcMessageBoxButtonTypes.No);
                        acButtons.Add(tmpBtn);
                        tmpBtn = new AcMessageBoxButton(AcMessageBoxButtonTypes.Yes);
                        acButtons.Add(tmpBtn);
                        break;
                    case MessageBoxButtons.YesNoCancel:
                        tmpBtn = new AcMessageBoxButton(AcMessageBoxButtonTypes.Cancel);
                        acButtons.Add(tmpBtn);
                        tmpBtn = new AcMessageBoxButton(AcMessageBoxButtonTypes.No);
                        acButtons.Add(tmpBtn);
                        tmpBtn = new AcMessageBoxButton(AcMessageBoxButtonTypes.Yes);
                        acButtons.Add(tmpBtn);
                        break;
                    case MessageBoxButtons.RetryCancel:
                        tmpBtn = new AcMessageBoxButton(AcMessageBoxButtonTypes.Cancel);
                        acButtons.Add(tmpBtn);
                        tmpBtn = new AcMessageBoxButton(AcMessageBoxButtonTypes.Retry);
                        acButtons.Add(tmpBtn);
                        break;
                    case MessageBoxButtons.AbortRetryIgnore:
                        tmpBtn = new AcMessageBoxButton(AcMessageBoxButtonTypes.Ignore);
                        acButtons.Add(tmpBtn);
                        tmpBtn = new AcMessageBoxButton(AcMessageBoxButtonTypes.Retry);
                        acButtons.Add(tmpBtn);
                        tmpBtn = new AcMessageBoxButton(AcMessageBoxButtonTypes.Abort);
                        acButtons.Add(tmpBtn);
                        break;
                }
                tmpBtn = new AcMessageBoxButton(AcMessageBoxButtonTypes.Copy);
                acButtons.Add(tmpBtn);
                foreach (AcMessageBoxButton acBtn in acButtons)
                {
                    pnlButtons.Controls.Add(acBtn);
                    acBtn.Size = new System.Drawing.Size(85, 25);
                    acBtn.BackColor = System.Drawing.SystemColors.Control;
                    acBtn.FlatStyle = FlatStyle.System;
                    acBtn.Click += new EventHandler(OnButtonClick);
                }
                
                //Create the message table layout panel
                tlpMessage = new TableLayoutPanel();
                tlpMessage.RowCount = 1;
                tlpMessage.RowStyles.Add(new RowStyle(SizeType.Percent, 100));
                tlpMessage.ColumnCount = 2;
                tlpMessage.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 60));
                tlpMessage.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100));
                tlpMessage.GrowStyle = TableLayoutPanelGrowStyle.AddColumns;
                tlpMessage.Dock = DockStyle.Fill;

                //Create the text message layout panel
                tlpText = new TableLayoutPanel();
                tlpText.RowCount = 3;
                if (lines > 2)
                {
                    tlpText.RowStyles.Add(new RowStyle(SizeType.Percent, 15));
                    tlpText.RowStyles.Add(new RowStyle(SizeType.Percent, 70));
                    tlpText.RowStyles.Add(new RowStyle(SizeType.Percent, 15));
                }
                else
                {
                    tlpText.RowStyles.Add(new RowStyle(SizeType.Percent, 33));
                    tlpText.RowStyles.Add(new RowStyle(SizeType.Percent, 33));
                    tlpText.RowStyles.Add(new RowStyle(SizeType.Percent, 33));
                }
                tlpText.ColumnCount = 1;
                tlpText.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100));
                tlpText.GrowStyle = TableLayoutPanelGrowStyle.AddColumns;
                tlpText.Dock = DockStyle.Fill;

                //Create the Picture Box with the System Icon
                picIcon = new PictureBox();
                System.Drawing.Icon iconToUse = null;
                switch (_Icon)
                {
                    case MessageBoxIcon.Error:
                        iconToUse = System.Drawing.SystemIcons.Error;
                        System.Media.SystemSounds.Hand.Play();
                        break;
                    case MessageBoxIcon.Exclamation:
                        iconToUse = System.Drawing.SystemIcons.Exclamation;
                        System.Media.SystemSounds.Exclamation.Play();
                        break;
                    case MessageBoxIcon.Information:
                        iconToUse = System.Drawing.SystemIcons.Information;
                        System.Media.SystemSounds.Asterisk.Play();
                        break;
                    case MessageBoxIcon.None:
                        iconToUse = null;
                        break;
                    case MessageBoxIcon.Question:
                        iconToUse = System.Drawing.SystemIcons.Question;
                        System.Media.SystemSounds.Asterisk.Play();
                        break;
                }
                picIcon.Image = iconToUse.ToBitmap();
                picIcon.SizeMode = PictureBoxSizeMode.CenterImage;
                picIcon.Dock = DockStyle.Fill;

                //Create the text box with the message
                txtMessage = new TextBox();
                txtMessage.Text = _Message;
                txtMessage.ReadOnly = true;
                txtMessage.Multiline = true;
                txtMessage.WordWrap = true;
                txtMessage.BackColor = System.Drawing.Color.White;
                txtMessage.BorderStyle = BorderStyle.None;
                txtMessage.Dock = DockStyle.Fill;
                txtMessage.ScrollBars = ScrollBars.Vertical;

                //Add the text to the text table layout panel
                tlpText.Controls.Add(txtMessage, 0, 1);

                //Add the Controls to the message table layout panel
                tlpMessage.Controls.Add(picIcon, 0, 0);
                tlpMessage.Controls.Add(tlpText, 1, 0);

                //Add the controls to the main table layout panel
                tlpMain.Controls.Add(tlpMessage, 0, 0);
                tlpMain.Controls.Add(pnlButtons, 0, 1);

                //Add the main table layout to the form
                this.Controls.Add(tlpMain);
            }

            /// <summary>
            /// 
            /// </summary>
            /// <param name="sender"></param>
            /// <param name="e"></param>
            private void OnButtonClick(object sender, EventArgs e)
            {
                try
                {
                    AcMessageBoxButton acBtn = (AcMessageBoxButton)sender;
                    switch (acBtn.buttonType)
                    {
                        case AcMessageBoxButtonTypes.Abort:
                            this.DialogResult = System.Windows.Forms.DialogResult.Abort;
                            this.Close();
                            break;
                        case AcMessageBoxButtonTypes.Cancel:
                            this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
                            this.Close();
                            break;
                        case AcMessageBoxButtonTypes.Ignore:
                            this.DialogResult = System.Windows.Forms.DialogResult.Ignore;
                            this.Close();
                            break;
                        case AcMessageBoxButtonTypes.No:
                            this.DialogResult = System.Windows.Forms.DialogResult.No;
                            this.Close();
                            break;
                        case AcMessageBoxButtonTypes.OK:
                            this.DialogResult = System.Windows.Forms.DialogResult.OK;
                            this.Close();
                            break;
                        case AcMessageBoxButtonTypes.Retry:
                            this.DialogResult = System.Windows.Forms.DialogResult.Retry;
                            this.Close();
                            break;
                        case AcMessageBoxButtonTypes.Yes:
                            this.DialogResult = System.Windows.Forms.DialogResult.Yes;
                            this.Close();
                            break;
                        case AcMessageBoxButtonTypes.Copy:
                            this.DialogResult = System.Windows.Forms.DialogResult.None;
                            Clipboard.SetText(txtMessage.Text);
                            AcMessageBox.Show("Message was copied to clipboard!", "Sucess!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            break;
                    }
                }
                catch (Exception ex)
                {
                    AcUtilities.DebugWrite(ex.ToString());
                    AcMessageBox.Show(ex.Message, "Exception!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            /// <summary>
            /// 
            /// </summary>
            /// <param name="sender"></param>
            /// <param name="e"></param>
            private void OnFormShown(object sender, EventArgs e)
            {
                try
                {
                    foreach (AcMessageBoxButton btn in acButtons)
                    {
                        if (btn.buttonType == AcMessageBoxButtonTypes.OK ||
                            btn.buttonType == AcMessageBoxButtonTypes.Yes)
                        {
                            btn.Focus();
                            return;
                        }
                    }
                }
                catch (Exception ex)
                {
                    AcUtilities.DebugWrite(ex.ToString());
                    AcMessageBox.Show(ex.Message, "Exception!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

        }
    }
}
