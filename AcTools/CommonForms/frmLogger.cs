using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;

using AcTools.Core;
using AcControls.AcMessageBox;
using AcToolsLibrary.Common;

namespace AcTools.CommonForms
{
    public partial class frmLogger : AcForm
    {
        public enum LoggerFormType
        {
            LogForm,
            LogFile,
            DebugForm,
            DebugFile
        }

        private String _FormNameFormat = "Logger - {0}";
        private LoggerFormType _LogType;

        /// <summary>
        /// Default constructor
        /// </summary>
        public frmLogger(LoggerFormType lgtp)
        {
            InitializeComponent();
            InitColors();
            InitControls();
            InitIcon();
            _LogType = lgtp;
            ReLoad();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnCopy_Click(object sender, EventArgs e)
        {
            try
            {
                //Check if at least one line is selected
                if (lstLines.SelectedItems.Count > 0)
                {
                    StringBuilder clipboardBuilder = new StringBuilder();
                    foreach (String item in lstLines.SelectedItems)
                    {
                        clipboardBuilder.AppendLine(item);
                    }
                    Clipboard.SetText(clipboardBuilder.ToString());
                }
            }
            catch (Exception ex)
            {
                ShowExceptionMessage(ex);
            }
        }

        private void loadFile(String file)
        {
            try
            {
                this.Text = String.Format(_FormNameFormat, file);
                //Check if file exists
                if (!File.Exists(file))
                {
                    using (var sw = File.CreateText(file)) { sw.Write(String.Empty); }
                    //throw new Exception("File " + file + " does not exists!");
                }
                //Clean list
                lstLines.Items.Clear();

                //Read file
                using (StreamReader sr = new StreamReader(file, Encoding.UTF8))
                {
                    while (!sr.EndOfStream)
                    {
                        lstLines.Items.Add(sr.ReadLine());
                    }
                }
            }
            catch (Exception ex)
            {
                ShowExceptionMessage(ex);
            }
        }

        private void loadList(String lst)
        {
            //Clean list
            lstLines.Items.Clear();
            lstLines.Items.AddRange(lst.Split(new String[] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries));
        }

        private void btnReload_Click(object sender, EventArgs e)
        {
            try
            {
                ReLoad();
            }
            catch (Exception ex)
            {
                ShowExceptionMessage(ex);
            }
        }

        /// <summary>
        /// Reload the list
        /// </summary>
        public void ReLoad()
        {
            switch (_LogType)
            {
                case LoggerFormType.LogFile:
                    loadFile("log.txt");
                    break;
                case LoggerFormType.LogForm:
                    this.Text = String.Format(_FormNameFormat, "Log");
                    loadList(AcLogger.LogMessages);
                    break;
                case LoggerFormType.DebugFile:
                    loadFile("debug.txt");
                    break;
                case LoggerFormType.DebugForm:
                    this.Text = String.Format(_FormNameFormat, "Debug");
                    loadList(AcLogger.DebugMessages);
                    break;
            }
        }

    }
}
