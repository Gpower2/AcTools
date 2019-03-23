using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Reflection;

using AcTools.Forms;
using AcTools.Core;

namespace AcTools.CommonForms
{
    public partial class frmMain : AcForm
    {
        public frmMain()
        {
            InitializeComponent();
            InitIcon();
            this.Text = String.Format("AnimeClipse Fansub Tools - {0} - ({1})", 
                Assembly.GetExecutingAssembly().GetName().Version,
                new DateTime(2000, 1, 1).Add(new TimeSpan(
                    TimeSpan.TicksPerDay * Assembly.GetExecutingAssembly().GetName().Version.Build + // days since 1 January 2000
                    TimeSpan.TicksPerSecond * 2 * Assembly.GetExecutingAssembly().GetName().Version.Revision)) // seconds since midnight, (multiply by 2 to get original)
                    .ToString("dd/MM/yyyy HH:mm:ss")
            );
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Width = 1024;
            this.Height = 768; 
            this.WindowState = FormWindowState.Maximized;
        }

        /// <summary>
        /// Shows a form as an MDI child
        /// of this Main Form and locates it in 
        /// the center of the parent Form
        /// </summary>
        /// <param name="frm"></param>
        public void ShowChildForm(AcForm frm)
        {
            frm.MainForm = this;
            frm.StartPosition = FormStartPosition.CenterParent;
            frm.Show();
        }

        private void cascadeToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            this.LayoutMdi(System.Windows.Forms.MdiLayout.Cascade);
        }

        private void tileHorizontalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.LayoutMdi(System.Windows.Forms.MdiLayout.TileHorizontal);
        }

        private void tileVerticalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.LayoutMdi(System.Windows.Forms.MdiLayout.TileVertical);
        }

        private void timeCodesAnalyserToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowChildForm(new frmTimeCodeAnalyser());
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason != CloseReason.ApplicationExitCall)
            {
                if (ShowQuestion("Are you sure you want to exit AC Fansub Tools?", "Exit AC Fansub Tools?", false) == DialogResult.Yes)
                {
                    e.Cancel = false;
                    GC.Collect();
                    Application.Exit();
                }
                else
                {
                    e.Cancel = true;
                }
            }
        }

        private void loggerFormToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowChildForm(new frmLogger(frmLogger.LoggerFormType.LogForm));
        }

        private void loggerFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowChildForm(new frmLogger(frmLogger.LoggerFormType.LogFile));
        }

        private void debugFormToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowChildForm(new frmLogger(frmLogger.LoggerFormType.DebugForm));
        }

        private void debugFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowChildForm(new frmLogger(frmLogger.LoggerFormType.DebugFile));
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            (new frmAbout()).ShowDialog();
        }

        private void videoPlayerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowChildForm(new frmVideoPlayer());
        }

        private void kienzanToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowChildForm(new frmKienzan());
        }

        private void sectionEditorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowChildForm(new frmSectionEditor());
        }

        private void patcherxDeltaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowChildForm(new frmPatcher());
        }

        private void duplicatesAnalyserToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowChildForm(new frmDuplicateAnalyser());
        }

        private void resizeCalculatorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowChildForm(new frmResizeCalculator());
        }

        private void chapterEditorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowChildForm(new frmChapterEditor());
        }

        private void frameRestorationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowChildForm(new frmFrameRestoration());
        }

        private void hashCalculatorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowChildForm(new frmHashCalculator());
        }

        private void avisynthEditorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowChildForm(new frmAviSynthEditor());
        }

        private void aSSFormToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowChildForm(new frmAss());
        }

        private void bitrateCalculatorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowChildForm(new frmBitrateCalculator());
        }

        private void settingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowChildForm(new frmSettings());
        }

        private void meGUICutsCreatorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowChildForm(new frmMeGUICutsCreator());
        }

        private void timeCodesEditorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowChildForm(new frmTimeCodeEditor());
        }
    }
}
