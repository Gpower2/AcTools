using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using System.Collections.Specialized;

namespace AcControls.AcRichTextBoxControl
{
    /// <summary>
    /// Summary description for AutoCompleteForm.
    /// </summary>
    public class AutoCompleteForm : Form
    {
        private StringCollection mItems = new StringCollection();
        private ListView listCompleteItems;
        private ColumnHeader columnHdr;

        public StringCollection Items
        {
            get
            {
                return mItems;
            }
        }

        internal int ItemHeight
        {
            get
            {
                return 18;
            }
        }

        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.Container components = null;

        public AutoCompleteForm()
        {
            //
            // Required for Windows Form Designer support
            //
            InitializeComponent();
        }

        public String SelectedItem
        {
            get
            {
                if (listCompleteItems.SelectedItems.Count == 0)
                {
                    return null;
                }
                return listCompleteItems.SelectedItems[0].Text;
            }
        }

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (components != null)
                {
                    components.Dispose();
                }
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
            this.listCompleteItems = new System.Windows.Forms.ListView();
            this.columnHdr = new System.Windows.Forms.ColumnHeader();
            this.SuspendLayout();
            // 
            // lstCompleteItems
            // 
            this.listCompleteItems.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
																							   this.columnHdr});
            this.listCompleteItems.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listCompleteItems.FullRowSelect = true;
            this.listCompleteItems.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            this.listCompleteItems.HideSelection = false;
            this.listCompleteItems.LabelWrap = false;
            this.listCompleteItems.Location = new System.Drawing.Point(0, 0);
            this.listCompleteItems.MultiSelect = false;
            this.listCompleteItems.Name = "lstCompleteItems";
            this.listCompleteItems.Size = new System.Drawing.Size(152, 136);
            this.listCompleteItems.Sorting = System.Windows.Forms.SortOrder.Ascending;
            this.listCompleteItems.TabIndex = 1;
            this.listCompleteItems.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHdr.Width = 148;
            // 
            // AutoCompleteForm
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(152, 136);
            this.ControlBox = false;
            this.Controls.Add(this.listCompleteItems);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(128, 176);
            this.MinimizeBox = false;
            this.Name = "AutoCompleteForm";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "AutoCompleteForm";
            this.TopMost = true;
            this.Resize += new System.EventHandler(this.AutoCompleteForm_Resize);
            this.VisibleChanged += new System.EventHandler(this.AutoCompleteForm_VisibleChanged);
            this.ResumeLayout(false);

        }
        #endregion

        private void lstCompleteItems_SelectedIndexChanged(object sender, System.EventArgs e)
        {
        }

        internal int SelectedIndex
        {
            get
            {
                if (listCompleteItems.SelectedIndices.Count == 0)
                {
                    return -1;
                }
                return listCompleteItems.SelectedIndices[0];
            }
            set
            {
                listCompleteItems.Items[value].Selected = true;
            }
        }

        private void AutoCompleteForm_Resize(object sender, System.EventArgs e)
        {
            //System.Diagnostics.Debug.WriteLine(string.Format("Size x:{0} y:{1}\r\n {2}", Size.Width , Size.Height, Environment.StackTrace));
        }

        internal void UpdateView()
        {
            listCompleteItems.Items.Clear();
            foreach (String item in mItems)
            {
                listCompleteItems.Items.Add(item);
            }
        }

        private void AutoCompleteForm_VisibleChanged(object sender, System.EventArgs e)
        {
            ArrayList items = new ArrayList(mItems);
            items.Sort(new CaseInsensitiveComparer());
            mItems = new StringCollection();
            mItems.AddRange((String[])items.ToArray(typeof(string)));
            columnHdr.Width = listCompleteItems.Width - 20;
        }

        private void lstCompleteItems_Resize(object sender, System.EventArgs e)
        {
            if (this.Size != listCompleteItems.Size)
            {

            }
        }
    }
}
