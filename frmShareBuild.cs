using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SC2Scrapbook
{
    public partial class frmShareBuild : Form
    {
        public frmShareBuild(Models.Build build)
        {
            InitializeComponent();

            string sharecode = build.SaveBase64();
            txtBBCode.Text = string.Format("[url=sc2bo://{0}]{1}[/url]", sharecode, build.Name);
            txtHTML.Text = string.Format("<a href=\"sc2bo://{0}\" title=\"SC2 Scrapbook - Build Order Sharecode\">{1}</a>", sharecode, build.Name);
            txtReddit.Text = string.Format("[{1}](sc2bo://{0} \"SC2 Scrapbook - Build Order Sharecode\")", sharecode, build.Name.Replace("[", "\\[").Replace("]", "\\]"));
            txtShareCode.Text = string.Format("sc2bo://{0}", sharecode);
        }

        private void btnCopySharecode_Click(object sender, EventArgs e)
        {
            try
            {
                Clipboard.SetDataObject(txtShareCode.Text, true, 50, 50);
            }
            catch {
                MessageBox.Show("Failed to access system clipboard.", "Fail :(", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnShareHTML_Click(object sender, EventArgs e)
        {
            try
            {
                Clipboard.SetDataObject(txtHTML.Text, true, 50, 50);
            }
            catch
            {
                MessageBox.Show("Failed to access system clipboard.", "Fail :(", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnShareBBCode_Click(object sender, EventArgs e)
        {
            try
            {
                Clipboard.SetDataObject(txtBBCode.Text, true, 50, 50);
            }
            catch
            {
                MessageBox.Show("Failed to access system clipboard.", "Fail :(", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnShareReddit_Click(object sender, EventArgs e)
        {
            try
            {
                Clipboard.SetDataObject(txtReddit.Text, true, 50, 50);
            }
            catch
            {
                MessageBox.Show("Failed to access system clipboard.", "Fail :(", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void frmShareBuild_Load(object sender, EventArgs e)
        {

        }


    }
}
