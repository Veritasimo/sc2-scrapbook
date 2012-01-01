using System;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SC2Scrapbook.Models;
using EXControls;

namespace SC2Scrapbook
{
    public partial class frmMain : Form
    {
        private ListViewColumnSorter lvwColumnSorter;

        public static frmMain Instance { get; private set; }
        private string _initialImportCode = null;

        public frmMain(string importCode = null)
        {
            Instance = this;
            InitializeComponent();
            lvwColumnSorter = new ListViewColumnSorter();

            lvBuilds.ListViewItemSorter = lvwColumnSorter;
            lvwColumnSorter.SortColumn = 0;
            lvwColumnSorter.Order = SortOrder.Ascending;

            cbRace.ItemHeight = 16;
            cbRace.Items.Add(new EXControls.EXComboBox.EXItem("Any"));
            cbRace.Items.Add(new EXControls.EXComboBox.EXImageItem("Terran", SC2Scrapbook.Properties.Resources.terran));
            cbRace.Items.Add(new EXControls.EXComboBox.EXImageItem("Protoss", SC2Scrapbook.Properties.Resources.protoss));
            cbRace.Items.Add(new EXControls.EXComboBox.EXImageItem("Zerg", SC2Scrapbook.Properties.Resources.zerg));

            cbVsRace.Items.Add(new EXControls.EXComboBox.EXItem("Any"));
            cbVsRace.Items.Add(new EXControls.EXComboBox.EXImageItem("Terran", SC2Scrapbook.Properties.Resources.terran));
            cbVsRace.Items.Add(new EXControls.EXComboBox.EXImageItem("Protoss", SC2Scrapbook.Properties.Resources.protoss));
            cbVsRace.Items.Add(new EXControls.EXComboBox.EXImageItem("Zerg", SC2Scrapbook.Properties.Resources.zerg));
            cbVsRace.Items.Add(new EXControls.EXComboBox.EXImageItem("Random", SC2Scrapbook.Properties.Resources.random));

            cbMatchup.Items.Add(new EXControls.EXComboBox.EXImageItem("TvT", SC2Scrapbook.Properties.Resources.terran));
            cbMatchup.Items.Add(new EXControls.EXComboBox.EXImageItem("TvP", SC2Scrapbook.Properties.Resources.terran));
            cbMatchup.Items.Add(new EXControls.EXComboBox.EXImageItem("TvZ", SC2Scrapbook.Properties.Resources.terran));
            cbMatchup.Items.Add(new EXControls.EXComboBox.EXImageItem("TvX", SC2Scrapbook.Properties.Resources.terran));
            cbMatchup.Items.Add(new EXControls.EXComboBox.EXImageItem("PvT", SC2Scrapbook.Properties.Resources.protoss));
            cbMatchup.Items.Add(new EXControls.EXComboBox.EXImageItem("PvP", SC2Scrapbook.Properties.Resources.protoss));
            cbMatchup.Items.Add(new EXControls.EXComboBox.EXImageItem("PvZ", SC2Scrapbook.Properties.Resources.protoss));
            cbMatchup.Items.Add(new EXControls.EXComboBox.EXImageItem("PvX", SC2Scrapbook.Properties.Resources.protoss));
            cbMatchup.Items.Add(new EXControls.EXComboBox.EXImageItem("ZvT", SC2Scrapbook.Properties.Resources.zerg));
            cbMatchup.Items.Add(new EXControls.EXComboBox.EXImageItem("ZvP", SC2Scrapbook.Properties.Resources.zerg));
            cbMatchup.Items.Add(new EXControls.EXComboBox.EXImageItem("ZvZ", SC2Scrapbook.Properties.Resources.zerg));
            cbMatchup.Items.Add(new EXControls.EXComboBox.EXImageItem("ZvX", SC2Scrapbook.Properties.Resources.zerg));

            PopulateBuilds();

            if (!Configuration.Instance.FirstRun)
            {
                if ((Configuration.Instance.MainHeight != 0) && (Configuration.Instance.MainWidth != 0)) {
                    Height = Configuration.Instance.MainHeight;
                    Width = Configuration.Instance.MainWidth;
                }
            }

            foreach (Patch patch in Program.PatchList)
            {
                cbPatch.Items.Add(new EXControls.EXComboBox.EXItem(patch.ToString()));
            }

            if (cbPatch.Items.Count > 0)
                cbPatch.SelectedIndex = 0;

            if (importCode != null)
            {
                MessageBox.Show(importCode);
                var build = Build.ParseBase64(importCode);

                if (build != null)
                {
                    frmImportBuild import = new frmImportBuild(build);

                    if (import.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                    {
                        Program.BuildsDB.Add(build);
                        Program.SaveBuildsXML();
                        PopulateBuilds();
                    }
                }
            }

            try
            {
                System.Net.WebClient c = new System.Net.WebClient();
                string update = c.DownloadString("http://veritasimo.cjb.net/version.txt");
                if (!string.IsNullOrEmpty(update))
                {
                    string[] thisVersion = Properties.Resources.version.Split('|');
                    string[] newVersion = update.Split('|');

                    if (newVersion.Length == 3)
                    {
                        int newVersionNumber = 0;
                        int oldVersionNumber = int.Parse(thisVersion[0]);

                        if (int.TryParse(newVersion[0], out newVersionNumber))
                        {
                            if (newVersionNumber > oldVersionNumber)
                            {
                                lbUpdate.Text = string.Format("Update Available ({0})", newVersion[1]);
                                lbUpdate.Tag = newVersion[2];
                                lbUpdate.Visible = true;
                            }
                        }
                    }
                }
            }
            catch { }


            foreach (ToolStripMenuItem item in zergToolStripMenuItem3.DropDownItems)
            {
                item.Click += new EventHandler(insertIconMenuClick);
            }

            foreach (ToolStripMenuItem item in protossToolStripMenuItem3.DropDownItems)
            {
                item.Click += new EventHandler(insertIconMenuClick);
            }

            foreach (ToolStripMenuItem item in terranToolStripMenuItem3.DropDownItems)
            {
                item.Click += new EventHandler(insertIconMenuClick);
            }

            foreach (ToolStripMenuItem item in zergToolStripMenuItem4.DropDownItems)
            {
                item.Click += new EventHandler(insertIconMenuClick);
            }

            foreach (ToolStripMenuItem item in protossToolStripMenuItem4.DropDownItems)
            {
                item.Click += new EventHandler(insertIconMenuClick);
            }

            foreach (ToolStripMenuItem item in terranToolStripMenuItem4.DropDownItems)
            {
                item.Click += new EventHandler(insertIconMenuClick);
            }

            foreach (ToolStripMenuItem item in zergToolStripMenuItem5.DropDownItems)
            {
                if (!item.HasDropDownItems)
                {
                    item.Click += new EventHandler(insertIconMenuClick);
                }
                else
                {
                    foreach (ToolStripMenuItem subitem in item.DropDownItems)
                    {
                        subitem.Click += new EventHandler(insertIconMenuClick);
                    }
                }
            }

            foreach (ToolStripMenuItem item in protossToolStripMenuItem5.DropDownItems)
            {
                if (!item.HasDropDownItems)
                {
                    item.Click += new EventHandler(insertIconMenuClick);
                }
                else
                {
                    foreach (ToolStripMenuItem subitem in item.DropDownItems)
                    {
                        subitem.Click += new EventHandler(insertIconMenuClick);
                    }
                }
            }

            foreach (ToolStripMenuItem item in terranToolStripMenuItem5.DropDownItems)
            {
                if (!item.HasDropDownItems)
                {
                    item.Click += new EventHandler(insertIconMenuClick);
                }
                else
                {
                    foreach (ToolStripMenuItem subitem in item.DropDownItems)
                    {
                        subitem.Click += new EventHandler(insertIconMenuClick);
                    }
                }
            }

#if DEBUG
            button1.Visible = true;
            button1.Enabled = true;
#endif
            
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            frmSplash.CloseSplash();
            this.BringToFront();
            this.Activate();
        }

        public void PopulateBuilds()
        {

            lvBuilds.Items.Clear();
            var builds = from x in Program.BuildsDB
                         select x;

            string search = txtBuildName.Text.Trim().ToLower();
            if (search != "")
            {
                builds = builds.Where(build => build.LowercaseName.Contains(search));
            }

            if (cbRace.SelectedIndex > 0)
            {
                builds = builds.Where(build => build.Matchup.PlayerRace == Matchup.RaceFromString(cbRace.SelectedItem.ToString()));
            }

            if (cbVsRace.SelectedIndex > 0)
            {
                builds = builds.Where(build => build.Matchup.OpponentRace == Matchup.RaceFromString(cbVsRace.SelectedItem.ToString()));
            }


            foreach (var build in builds)
            {
                EXListViewItem item = new EXImageListViewItem(build.Name, Models.Matchup.ImageFromRace(build.Matchup.PlayerRace));
                item.Tag = build;

                item.SubItems.Add(
                    new EXControls.EXListViewSubItem(build.Matchup.ToString())
                );

                lvBuilds.Items.Add(item);
            }

            lvBuilds.Sort();

            lvBuilds.Invalidate();

        }

        private void comboFilterItemChanged(object sender, EventArgs e)
        {
            PopulateBuilds();
        }

        private void txtBuildName_TextChanged(object sender, EventArgs e)
        {
            tmrNameChanged.Enabled = false;
            tmrNameChanged.Enabled = true;
        }

        private void tmrNameChanged_Tick(object sender, EventArgs e)
        {
            PopulateBuilds();
            tmrNameChanged.Enabled = false;
        }

        private void lvBuilds_DoubleClick(object sender, EventArgs e)
        {
            foreach (EXListViewItem item in lvBuilds.Items)
            {
                if (item.Selected)
                {
                    Program.HideOverlay();

                    frmBuildOverlay overlay = new frmBuildOverlay((Models.Build)item.Tag);
                    overlay.Show();

                }
            }
        }

        private void lvBuilds_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            if (e.Column == lvwColumnSorter.SortColumn)
            {
                // Reverse the current sort direction for this column.
                if (lvwColumnSorter.Order == SortOrder.Ascending)
                {
                    lvwColumnSorter.Order = SortOrder.Descending;
                }
                else
                {
                    lvwColumnSorter.Order = SortOrder.Ascending;
                }
            }
            else
            {
                // Set the column number that is to be sorted; default to ascending.
                lvwColumnSorter.SortColumn = e.Column;
                lvwColumnSorter.Order = SortOrder.Ascending;
            }

            // Perform the sort with these new sort options.
            lvBuilds.Sort();
        }

        private void lvBuilds_MouseUp(object sender, MouseEventArgs e)
        {
            m_dodrag = false;
            foreach (EXListViewItem item in lvBuilds.Items)
            {
                item.BackColor = lvBuilds.BackColor;
                foreach (ListViewItem.ListViewSubItem subitem in item.SubItems)
                {
                    subitem.BackColor = lvBuilds.BackColor;
                }
            }

            if (lvBuilds.SelectedItems.Count == 1)
            {

                foreach (EXListViewItem item in lvBuilds.Items)
                {
                    if (item.Selected)
                    {
                        item.BackColor = SystemColors.Highlight;
                        foreach (ListViewItem.ListViewSubItem subitem in item.SubItems)
                        {
                            subitem.BackColor = SystemColors.Highlight;
                        }
                        Models.Build build = item.Tag as Models.Build;

                        txtName.Text = build.Name;
                        txtNotes.Text = build.Notes;
                        txtScript.Text = build.Script;

                        for (int i = 0; i < cbMatchup.Items.Count; i++)
                        {
                            if (((EXControls.EXComboBox.EXItem)cbMatchup.Items[i]).Text == build.Matchup.ToString())
                            {
                                cbMatchup.SelectedIndex = i;
                                break;
                            }
                        }
                        break;

                    }
                }
            }
            else
            {

            }
        }

        private void btnCreateBuild_Click(object sender, EventArgs e)
        {
            if ((txtName.Text != "") && (txtScript.Text != "") && (cbMatchup.SelectedItem != null))
            {
                Build build = new Build();
                build.Name = txtName.Text;
                build.Script = txtScript.Text;
                build.Notes = txtNotes.Text;
                build.Matchup = new Matchup(((EXComboBox.EXItem)cbMatchup.SelectedItem).Text);

                Program.BuildsDB.Add(build);
                Program.SaveBuildsXML();

                PopulateBuilds();
            }
        }

        private void lvBuilds_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnUpdateBuild_Click(object sender, EventArgs e)
        {
            foreach (EXListViewItem item in lvBuilds.Items)
            {
                if (item.Selected)
                {
                    Build build = item.Tag as Build;
                    System.IO.File.Delete(build.CacheFile);
                    build.Name = txtName.Text;
                    build.Script = txtScript.Text;
                    build.Notes = txtNotes.Text;
                    build.Matchup = new Matchup(((EXComboBox.EXItem)cbMatchup.SelectedItem).Text);
                    

                    Program.SaveBuildsXML();

                    PopulateBuilds();

                    foreach (EXListViewItem newItem in lvBuilds.Items)
                    {
                        if (newItem.Tag == build)
                        {
                            newItem.Selected = true;
                            newItem.BackColor = SystemColors.Highlight;
                            foreach (ListViewItem.ListViewSubItem subitem in newItem.SubItems)
                            {
                                subitem.BackColor = SystemColors.Highlight;
                            }
                            newItem.EnsureVisible();
                            break;
                        }
                    }
                    break;
                }
            }
        }

        private void cmdDelete_Click(object sender, EventArgs e)
        {
            foreach (EXListViewItem item in lvBuilds.Items)
            {
                if (item.Selected)
                {
                    Build build = item.Tag as Build;

                    System.IO.File.Delete(build.CacheFile);
                    Program.BuildsDB.Remove(build);
                    Program.SaveBuildsXML();

                    PopulateBuilds();

                    break;
                }
            }
        }

        private void btnCloseOverlay_Click(object sender, EventArgs e)
        {
            Program.HideBuildSelection();
            Program.HideOverlay();
            Program.HidePlayerInfo();
        }

        private void frmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            Program.HideBuildSelection();
            Program.HideOverlay();
            Program.HidePlayerInfo();
            Program.KillSC2InteractionThread();

            Program.SaveConfigurationXML();
            Environment.Exit(0);
        }

        private void cmdResetBuilds_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you super super serial?", "HOLY BADNESS!", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
            {
                Program.BuildsDB.Clear();
                PopulateBuilds();
                Program.SaveBuildsXML();
            }
        }

        private void cmdLoadDefaults_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure? This will delete ALL the things.", "This may get messy...", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
            {
                Program.LoadDefaultBuilds();
                Program.LoadBuildsXML();
                PopulateBuilds();
                Program.SaveBuildsXML();
            }
        }

        private void cmdEditOverlay_Click(object sender, EventArgs e)
        {
            frmOptions options = new frmOptions();
            options.ShowDialog();
            options.Dispose();
        }

        private void frmMain_Move(object sender, EventArgs e)
        {
            if (Visible)
            {
                Configuration.Instance.MainWidth = Width;
                Configuration.Instance.MainHeight = Height;
                Configuration.Instance.MainLeft = Left;
                Configuration.Instance.MainTop = Top;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Program.HideBuildSelection();
            Program.ShowBuildSelection();
            
        }

        private void lvBuilds_Move(object sender, EventArgs e)
        {

        }

        private void cbPatch_SelectedIndexChanged(object sender, EventArgs e)
        {
            Program.ActivePatch = Program.PatchList[cbPatch.SelectedIndex];
        }

        public void ShowWindow()
        {
            if (WindowState == FormWindowState.Minimized)
                WindowState = FormWindowState.Normal;
            Activate();
        }

        protected override void WndProc(ref Message m)
        {
            if (m.Msg == Win32.WM_SHOWBON)
            {
                ShowWindow();
            }
            else if (m.Msg == Win32.WM_BONIMPORT)
            {
                string[] files = System.IO.Directory.GetFiles(Program.DataDirectory, "*.import");

                foreach (string file in files)
                {
                    string data = System.IO.File.ReadAllText(file);
                    System.IO.File.Delete(file);

                    try
                    {
                        Build build = Build.ParseBase64(data);
                        if (build != null)
                        {
                            ShowWindow();
                            frmImportBuild import = new frmImportBuild(build);

                            if (import.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                            {
                                Program.BuildsDB.Add(build);
                                Program.SaveBuildsXML();
                                PopulateBuilds();
                            }
                        }
                    }
                    catch { }
                }
            }
            else
            {
                base.WndProc(ref m);
            }

        }

        private void cmdShareBuild_Click(object sender, EventArgs e)
        {

        }

        private void cmenuBuilds_Opening(object sender, CancelEventArgs e)
        {
 
            copySharecodeBBCodeToolStripMenuItem.Enabled = (lvBuilds.SelectedItems.Count > 0);
            copySharecodeHTMLToolStripMenuItem.Enabled = (lvBuilds.SelectedItems.Count > 0);
            copySharecodeRedditToolStripMenuItem.Enabled = (lvBuilds.SelectedItems.Count > 0);
            viewSharecodeToolStripMenuItem.Enabled = (lvBuilds.SelectedItems.Count> 0);
            copySharecodeURLToolStripMenuItem.Enabled = (lvBuilds.SelectedItems.Count > 0);
            
        }

        private void viewSharecodeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (EXListViewItem item in lvBuilds.SelectedItems)
            {
                frmShareBuild share = new frmShareBuild(item.Tag as Build);
                share.ShowDialog();
            }

        }

        private void copySharecodeURLToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                foreach (EXListViewItem item in lvBuilds.SelectedItems)
                {
                    var build = item.Tag as Build;
                    Clipboard.SetDataObject(string.Format("sc2bo://{0}", build.SaveBase64()), true, 50, 50);
                }
            }
            catch
            {
                MessageBox.Show("Failed to access system clipboard.", "Fail :(", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void copySharecodeHTMLToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                foreach (EXListViewItem item in lvBuilds.SelectedItems)
                {
                    var build = item.Tag as Build;
                    Clipboard.SetDataObject(string.Format("<a href=\"sc2bo://{0}\" title=\"SC2 Scrapbook - Build Order Sharecode\">{1}</a>", build.SaveBase64(), build.Name), true, 50, 50);
                }
            }
            catch
            {
                MessageBox.Show("Failed to access system clipboard.", "Fail :(", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void copySharecodeBBCodeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                foreach (EXListViewItem item in lvBuilds.SelectedItems)
                {
                    var build = item.Tag as Build;
                    Clipboard.SetDataObject(string.Format("[url=sc2bo://{0} \"SC2 Scrapbook - Build Order Sharecode\"]{1}[/url]", build.SaveBase64(), build.Name), true, 50, 50);
                }
            }
            catch
            {
                MessageBox.Show("Failed to access system clipboard.", "Fail :(", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void copySharecodeRedditToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                foreach (EXListViewItem item in lvBuilds.SelectedItems)
                {
                    var build = item.Tag as Build;
                    Clipboard.SetDataObject(string.Format("[{1}](sc2bo://{0})", build.SaveBase64(), build.Name.Replace("[", "\\[").Replace("]", "\\]")), true, 50, 50);
                }
            }
            catch
            {
                MessageBox.Show("Failed to access system clipboard.", "Fail :(", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cmdUpdate_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.ProcessStartInfo psi = new System.Diagnostics.ProcessStartInfo();
            psi.UseShellExecute = true;
            psi.FileName = lbUpdate.Tag as string;
            System.Diagnostics.Process.Start(psi);
        }

        private void llChangelog_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            string tempFile = string.Format("{0}{1}sc2sbcl.txt", System.IO.Path.GetTempPath(), System.IO.Path.DirectorySeparatorChar);
            System.IO.File.WriteAllText(tempFile, Properties.Resources.Changelog);
            System.Diagnostics.ProcessStartInfo psi = new System.Diagnostics.ProcessStartInfo();
            psi.UseShellExecute = true;
            psi.FileName = tempFile as string;
            System.Diagnostics.Process.Start(psi);

        }

        private void frmMain_Resize(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Minimized)
            {
                Hide();
                notifyIcon.Visible = true;
                if (!Configuration.Instance.SeenMinimizeNotification)
                {
                    notifyIcon.ShowBalloonTip(2500, "Down Here, Brohan!", "I'm still running! Double click my icon to show me :). Click this alert to not show this message again.", ToolTipIcon.Info);
                }
            }
            else if (WindowState == FormWindowState.Normal)
            {
                if (Visible)
                {
                    notifyIcon.Visible = false;    
                    Configuration.Instance.MainWidth = Width;
                    Configuration.Instance.MainHeight = Height;
                    Configuration.Instance.MainLeft = Left;
                    Configuration.Instance.MainTop = Top;
                }
            }
        }

        private void notifyIcon_BalloonTipClicked(object sender, EventArgs e)
        {
            Configuration.Instance.SeenMinimizeNotification = true;
        }

        private void notifyIcon_DoubleClick(object sender, EventArgs e)
        {
            Show();
            WindowState = FormWindowState.Normal;
        }

        private void pbIconSelect_Click(object sender, EventArgs e)
        {
            cmIconSelect.Show(Cursor.Position);
        }

        private void insertIconMenuClick(object sender, EventArgs e)
        {
            if (sender is ToolStripMenuItem)
            {
                var item = sender as ToolStripMenuItem;

                if (item.Tag != null)
                {
                    if (item.Tag is string)
                    {
                        int start = txtScript.SelectionStart;
                        if (txtScript.SelectionLength > 0)
                        {
                            txtScript.Text = txtScript.Text.Remove(txtScript.SelectionStart, txtScript.SelectionLength);
                        }

                        txtScript.Text = txtScript.Text.Insert(start, string.Format(@"{{{0}}}", item.Tag));


                        txtScript.SelectionStart = start + ((string)item.Tag).Length + 2;
                        
                    }
                }                
            }
        }

        private void vikingAssaultModEToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void lvBuilds_ItemDrag(object sender, ItemDragEventArgs e)
        {

        }

        private void btnCreateWallpaper_Click(object sender, EventArgs e)
        {
            frmSimpleWallpaperDesigner designer = new frmSimpleWallpaperDesigner();
            designer.Show();
        }

        bool m_dodrag = false;
        private void lvBuilds_MouseMove(object sender, MouseEventArgs e)
        {
            if (m_dodrag)
            {
                var build = lvBuilds.SelectedItems[0].Tag as Build;
                lvBuilds.DoDragDrop(build, DragDropEffects.Copy);
            }
        }


        private void lvBuilds_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Clicks == 1)
            {
                m_dodrag = true;
            }
            else
            {
                m_dodrag = false;
            }
        }

        private void pbImport_Click(object sender, EventArgs e)
        {
            frmManualSharecodeEntry import = new frmManualSharecodeEntry();
            if (import.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                PopulateBuilds();
            }
        }
        
    }
}
