using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using AcControls.Utilities;
using AcControls.AcMessageBox;
using System.Diagnostics;

namespace AcControls.AcInputBox
{
    public static class AcInputBox
    {


        /// <summary>
        /// Reserved for future versions
        /// </summary>
        /// <returns></returns>
        public static Object Show()
        {
            throw new Exception("Not implemented yet!");
        }

        /// <summary>
        /// Main method for invoking the input box
        /// The same as the Microsoft.VisualBasic.Interaction.InputBox Method
        /// WARNING! When users cancels, the result is null, not String.Empty!
        /// </summary>
        /// <returns></returns>
        public static String Show(String message, String title, String defaultResponse)
        {
            String result = String.Empty;
            using (AcInputBoxForm boxForm = new AcInputBoxForm(message, title, defaultResponse))
            {
                if (boxForm.ShowDialog(Application.OpenForms[0]) == DialogResult.OK)
                {
                    result = boxForm.InputResponse;
                }
                else
                {
                    result = null;
                }
                try
                {
                    Application.OpenForms[0].Select();
                    Application.OpenForms[0].Focus();
                }
                catch (Exception ex)
                {
                    Debug.WriteLine(ex);
                }
                
                return result;
            }
        }

        private enum AcInputBoxButtonTypes 
        {
            OK,
            Cancel
        }

        private class AcInputBoxButton : Button
        {
            public AcInputBoxButtonTypes buttonType = AcInputBoxButtonTypes.OK;

            public AcInputBoxButton(AcInputBoxButtonTypes msgButton)
            {
                buttonType = msgButton;
                Text = Enum.GetName(typeof(AcInputBoxButtonTypes), buttonType);
            }
        }

        private class AcInputBoxForm : Form
        {
            //Controls
            private TableLayoutPanel tlpMain = null;
            private TableLayoutPanel tlpMessage = null;
            private FlowLayoutPanel pnlButtons = null;
            private PictureBox picIcon = null;
            private TextBox txtUserResponse = null;
            private Label lblMessage = null;
            private List<AcInputBoxButton> acButtons = new List<AcInputBoxButton>();
            private AcInputBoxButton acBtnOK = null;

            //Properties
            private String _Message = String.Empty;
            private String _Title = String.Empty;
            private String _DefaultResponse = String.Empty;

            public String InputResponse = String.Empty;

            public AcInputBoxForm(String message, String title, String defaultResponse)
            {
                _Message = message;
                _Title = title;
                _DefaultResponse = defaultResponse;
                Init();
                this.Select();
                this.Focus();
            }

            private void Init()
            {
                //First, we must determine the minimum size of the form
                Int32 formWidth = 0, formHeight = 0;               
                Int32 charCount = 0, lines = 0;
                Int32 formMinimumWidth = 300;
                Int32 formMinimumHeight = 200;
                Int32 formMaximumWidth = (Screen.PrimaryScreen.WorkingArea.Width / 2);
                Int32 formMaximumHeight = Screen.PrimaryScreen.WorkingArea.Height / 2;
                System.Drawing.Graphics g = System.Drawing.Graphics.FromHwnd(this.Handle);
                System.Drawing.SizeF measureSize = g.MeasureString(_Message, this.Font,
                    new System.Drawing.SizeF(formMaximumWidth - 80, formMaximumHeight),
                    new System.Drawing.StringFormat(), out charCount, out lines);
                formWidth = Convert.ToInt32(measureSize.Width + 80);
                if (lines > 1)
                {                    
                    formHeight = Convert.ToInt32(((lines * this.Font.Height) / 0.33) * 2 + 110);
                }
                else
                {
                    formHeight = formMinimumHeight;
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
                this.KeyPreview = true;
                this.Shown += new EventHandler(OnFormShown);
                this.KeyDown += new KeyEventHandler(OnKeyDown);

                //Create the main table layout panel
                tlpMain = new TableLayoutPanel();
                tlpMain.RowCount = 3;
                tlpMain.RowStyles.Add(new RowStyle(SizeType.Percent, 50));
                tlpMain.RowStyles.Add(new RowStyle(SizeType.Percent, 50));
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
                AcInputBoxButton tmpBtn = null;
                tmpBtn = new AcInputBoxButton(AcInputBoxButtonTypes.Cancel);
                acButtons.Add(tmpBtn);
                tmpBtn = new AcInputBoxButton(AcInputBoxButtonTypes.OK);
                acButtons.Add(tmpBtn);
                acBtnOK = tmpBtn;
                foreach (AcInputBoxButton acBtn in acButtons)
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

                //Create the Picture Box with the System Icon
                picIcon = new PictureBox();
                picIcon.Image = System.Drawing.SystemIcons.Question.ToBitmap();
                picIcon.SizeMode = PictureBoxSizeMode.CenterImage;
                picIcon.Dock = DockStyle.Fill;

                //Create the text box for the user response
                txtUserResponse = new TextBox();
                //Add event to refresh the UserResponse according to textbox contents
                txtUserResponse.TextChanged += new EventHandler(OnTextChanged);
                txtUserResponse.Text = _DefaultResponse;
                txtUserResponse.Multiline = true;
                txtUserResponse.WordWrap = true;
                txtUserResponse.BackColor = System.Drawing.Color.White;
                txtUserResponse.BorderStyle = BorderStyle.FixedSingle;
                txtUserResponse.Dock = DockStyle.Fill;

                //Create the label for the prompt message
                lblMessage = new Label();
                lblMessage.Text = _Message;
                lblMessage.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
                lblMessage.Dock = DockStyle.Fill;

                //Add the Controls to the message table layout panel
                tlpMessage.Controls.Add(picIcon, 0, 0);
                tlpMessage.Controls.Add(lblMessage, 1, 0);

                //Add the controls to the main table layout panel
                tlpMain.Controls.Add(tlpMessage, 0, 0);
                tlpMain.Controls.Add(txtUserResponse, 0, 1);
                tlpMain.Controls.Add(pnlButtons, 0, 2);

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
                    AcInputBoxButton acBtn = (AcInputBoxButton)sender;
                    switch (acBtn.buttonType)
                    {
                        case AcInputBoxButtonTypes.OK:
                            this.DialogResult = System.Windows.Forms.DialogResult.OK;
                            this.Hide();
                            break;
                        case AcInputBoxButtonTypes.Cancel:
                            this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
                            this.Hide();
                            break;
                    }
                }
                catch (Exception ex)
                {
                    AcUtilities.DebugWrite(ex.ToString());
                    AcMessageBox.AcMessageBox.Show(ex.Message, "Exception!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            /// <summary>
            /// 
            /// </summary>
            /// <param name="sender"></param>
            /// <param name="e"></param>
            private void OnTextChanged(object sender, EventArgs e)
            {
                try
                {
                    InputResponse = txtUserResponse.Text;
                }
                catch (Exception ex)
                {
                    AcUtilities.DebugWrite(ex.ToString());
                    AcMessageBox.AcMessageBox.Show(ex.Message, "Exception!", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                    txtUserResponse.Select();
                }
                catch (Exception ex)
                {
                    AcUtilities.DebugWrite(ex.ToString());
                    AcMessageBox.AcMessageBox.Show(ex.Message, "Exception!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            /// <summary>
            /// 
            /// </summary>
            /// <param name="sender"></param>
            /// <param name="e"></param>
            private void OnKeyDown(object sender, KeyEventArgs e)
            {
                try
                {
                    if (e.KeyCode == Keys.Enter)
                    {
                        if (e.Modifiers == Keys.Control)
                        {
                            txtUserResponse.Text += "\r\n";
                            txtUserResponse.Select(txtUserResponse.Text.Length, 0);
                        }
                        else
                        {
                            acBtnOK.PerformClick();
                        }
                    }
                }
                catch (Exception ex)
                {
                    AcUtilities.DebugWrite(ex.ToString());
                    AcMessageBox.AcMessageBox.Show(ex.Message, "Exception!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
