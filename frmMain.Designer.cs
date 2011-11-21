namespace SC2Scrapbook
{
    partial class frmMain
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            this.tmrNameChanged = new System.Windows.Forms.Timer(this.components);
            this.gbFilter = new System.Windows.Forms.GroupBox();
            this.cbVsRace = new EXControls.EXComboBox();
            this.lblVsRace = new System.Windows.Forms.Label();
            this.cbRace = new EXControls.EXComboBox();
            this.lblPlayerRace = new System.Windows.Forms.Label();
            this.txtBuildName = new System.Windows.Forms.TextBox();
            this.lblName = new System.Windows.Forms.Label();
            this.txtScript = new System.Windows.Forms.TextBox();
            this.lblScript = new System.Windows.Forms.Label();
            this.lblBuildName = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.TextBox();
            this.lblNotes = new System.Windows.Forms.Label();
            this.txtNotes = new System.Windows.Forms.TextBox();
            this.btnCreateBuild = new System.Windows.Forms.Button();
            this.btnUpdateBuild = new System.Windows.Forms.Button();
            this.cmdDelete = new System.Windows.Forms.Button();
            this.btnCloseOverlay = new System.Windows.Forms.Button();
            this.cmdResetBuilds = new System.Windows.Forms.Button();
            this.cmdLoadDefaults = new System.Windows.Forms.Button();
            this.cmdEditOverlay = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.cmenuBuilds = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.viewSharecodeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.copySharecodeURLToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.copySharecodeHTMLToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.copySharecodeBBCodeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.copySharecodeRedditToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cbPatch = new EXControls.EXComboBox();
            this.cbMatchup = new EXControls.EXComboBox();
            this.lvBuilds = new EXControls.EXListView();
            this.lvchBuild = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.lvchMatchup = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.lbUpdate = new System.Windows.Forms.LinkLabel();
            this.llChangelog = new System.Windows.Forms.LinkLabel();
            this.gbFilter.SuspendLayout();
            this.cmenuBuilds.SuspendLayout();
            this.SuspendLayout();
            // 
            // tmrNameChanged
            // 
            this.tmrNameChanged.Enabled = true;
            this.tmrNameChanged.Interval = 500;
            this.tmrNameChanged.Tick += new System.EventHandler(this.tmrNameChanged_Tick);
            // 
            // gbFilter
            // 
            this.gbFilter.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.gbFilter.Controls.Add(this.cbVsRace);
            this.gbFilter.Controls.Add(this.lblVsRace);
            this.gbFilter.Controls.Add(this.cbRace);
            this.gbFilter.Controls.Add(this.lblPlayerRace);
            this.gbFilter.Controls.Add(this.txtBuildName);
            this.gbFilter.Controls.Add(this.lblName);
            this.gbFilter.Location = new System.Drawing.Point(2, 329);
            this.gbFilter.Name = "gbFilter";
            this.gbFilter.Size = new System.Drawing.Size(426, 66);
            this.gbFilter.TabIndex = 1;
            this.gbFilter.TabStop = false;
            this.gbFilter.Text = "Filter";
            // 
            // cbVsRace
            // 
            this.cbVsRace.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cbVsRace.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbVsRace.FormattingEnabled = true;
            this.cbVsRace.Location = new System.Drawing.Point(285, 35);
            this.cbVsRace.Name = "cbVsRace";
            this.cbVsRace.Size = new System.Drawing.Size(131, 21);
            this.cbVsRace.TabIndex = 2;
            this.cbVsRace.SelectedIndexChanged += new System.EventHandler(this.comboFilterItemChanged);
            // 
            // lblVsRace
            // 
            this.lblVsRace.AutoSize = true;
            this.lblVsRace.Location = new System.Drawing.Point(282, 19);
            this.lblVsRace.Name = "lblVsRace";
            this.lblVsRace.Size = new System.Drawing.Size(18, 13);
            this.lblVsRace.TabIndex = 4;
            this.lblVsRace.Text = "vs";
            // 
            // cbRace
            // 
            this.cbRace.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cbRace.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbRace.FormattingEnabled = true;
            this.cbRace.Location = new System.Drawing.Point(148, 35);
            this.cbRace.Name = "cbRace";
            this.cbRace.Size = new System.Drawing.Size(131, 21);
            this.cbRace.TabIndex = 1;
            this.cbRace.SelectedIndexChanged += new System.EventHandler(this.comboFilterItemChanged);
            // 
            // lblPlayerRace
            // 
            this.lblPlayerRace.AutoSize = true;
            this.lblPlayerRace.Location = new System.Drawing.Point(145, 19);
            this.lblPlayerRace.Name = "lblPlayerRace";
            this.lblPlayerRace.Size = new System.Drawing.Size(33, 13);
            this.lblPlayerRace.TabIndex = 2;
            this.lblPlayerRace.Text = "Race";
            // 
            // txtBuildName
            // 
            this.txtBuildName.Location = new System.Drawing.Point(16, 35);
            this.txtBuildName.Name = "txtBuildName";
            this.txtBuildName.Size = new System.Drawing.Size(126, 20);
            this.txtBuildName.TabIndex = 0;
            this.txtBuildName.TextChanged += new System.EventHandler(this.txtBuildName_TextChanged);
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Location = new System.Drawing.Point(13, 19);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(61, 13);
            this.lblName.TabIndex = 0;
            this.lblName.Text = "Build Name";
            // 
            // txtScript
            // 
            this.txtScript.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtScript.Location = new System.Drawing.Point(434, 68);
            this.txtScript.Multiline = true;
            this.txtScript.Name = "txtScript";
            this.txtScript.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtScript.Size = new System.Drawing.Size(399, 98);
            this.txtScript.TabIndex = 7;
            // 
            // lblScript
            // 
            this.lblScript.AutoSize = true;
            this.lblScript.Location = new System.Drawing.Point(434, 52);
            this.lblScript.Name = "lblScript";
            this.lblScript.Size = new System.Drawing.Size(34, 13);
            this.lblScript.TabIndex = 4;
            this.lblScript.Text = "Script";
            // 
            // lblBuildName
            // 
            this.lblBuildName.AutoSize = true;
            this.lblBuildName.Location = new System.Drawing.Point(434, 3);
            this.lblBuildName.Name = "lblBuildName";
            this.lblBuildName.Size = new System.Drawing.Size(35, 13);
            this.lblBuildName.TabIndex = 6;
            this.lblBuildName.Text = "Name";
            // 
            // txtName
            // 
            this.txtName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtName.Location = new System.Drawing.Point(434, 19);
            this.txtName.Name = "txtName";
            this.txtName.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtName.Size = new System.Drawing.Size(319, 20);
            this.txtName.TabIndex = 5;
            // 
            // lblNotes
            // 
            this.lblNotes.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblNotes.AutoSize = true;
            this.lblNotes.Location = new System.Drawing.Point(434, 173);
            this.lblNotes.Name = "lblNotes";
            this.lblNotes.Size = new System.Drawing.Size(35, 13);
            this.lblNotes.TabIndex = 8;
            this.lblNotes.Text = "Notes";
            // 
            // txtNotes
            // 
            this.txtNotes.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtNotes.Location = new System.Drawing.Point(434, 189);
            this.txtNotes.Multiline = true;
            this.txtNotes.Name = "txtNotes";
            this.txtNotes.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtNotes.Size = new System.Drawing.Size(399, 116);
            this.txtNotes.TabIndex = 8;
            // 
            // btnCreateBuild
            // 
            this.btnCreateBuild.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCreateBuild.Location = new System.Drawing.Point(756, 311);
            this.btnCreateBuild.Name = "btnCreateBuild";
            this.btnCreateBuild.Size = new System.Drawing.Size(75, 23);
            this.btnCreateBuild.TabIndex = 10;
            this.btnCreateBuild.Text = "Create";
            this.btnCreateBuild.UseVisualStyleBackColor = true;
            this.btnCreateBuild.Click += new System.EventHandler(this.btnCreateBuild_Click);
            // 
            // btnUpdateBuild
            // 
            this.btnUpdateBuild.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnUpdateBuild.Location = new System.Drawing.Point(675, 311);
            this.btnUpdateBuild.Name = "btnUpdateBuild";
            this.btnUpdateBuild.Size = new System.Drawing.Size(75, 23);
            this.btnUpdateBuild.TabIndex = 9;
            this.btnUpdateBuild.Text = "Update";
            this.btnUpdateBuild.UseVisualStyleBackColor = true;
            this.btnUpdateBuild.Click += new System.EventHandler(this.btnUpdateBuild_Click);
            // 
            // cmdDelete
            // 
            this.cmdDelete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdDelete.Location = new System.Drawing.Point(594, 311);
            this.cmdDelete.Name = "cmdDelete";
            this.cmdDelete.Size = new System.Drawing.Size(75, 23);
            this.cmdDelete.TabIndex = 8;
            this.cmdDelete.Text = "Delete";
            this.cmdDelete.UseVisualStyleBackColor = true;
            this.cmdDelete.Click += new System.EventHandler(this.cmdDelete_Click);
            // 
            // btnCloseOverlay
            // 
            this.btnCloseOverlay.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCloseOverlay.Location = new System.Drawing.Point(439, 372);
            this.btnCloseOverlay.Name = "btnCloseOverlay";
            this.btnCloseOverlay.Size = new System.Drawing.Size(85, 23);
            this.btnCloseOverlay.TabIndex = 13;
            this.btnCloseOverlay.Text = "Close Overlays";
            this.btnCloseOverlay.UseVisualStyleBackColor = true;
            this.btnCloseOverlay.Click += new System.EventHandler(this.btnCloseOverlay_Click);
            // 
            // cmdResetBuilds
            // 
            this.cmdResetBuilds.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdResetBuilds.Location = new System.Drawing.Point(732, 372);
            this.cmdResetBuilds.Name = "cmdResetBuilds";
            this.cmdResetBuilds.Size = new System.Drawing.Size(99, 23);
            this.cmdResetBuilds.TabIndex = 16;
            this.cmdResetBuilds.Text = "Delete All Builds";
            this.cmdResetBuilds.UseVisualStyleBackColor = true;
            this.cmdResetBuilds.Click += new System.EventHandler(this.cmdResetBuilds_Click);
            // 
            // cmdLoadDefaults
            // 
            this.cmdLoadDefaults.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdLoadDefaults.Location = new System.Drawing.Point(617, 372);
            this.cmdLoadDefaults.Name = "cmdLoadDefaults";
            this.cmdLoadDefaults.Size = new System.Drawing.Size(109, 23);
            this.cmdLoadDefaults.TabIndex = 15;
            this.cmdLoadDefaults.Text = "Load Default Builds";
            this.cmdLoadDefaults.UseVisualStyleBackColor = true;
            this.cmdLoadDefaults.Click += new System.EventHandler(this.cmdLoadDefaults_Click);
            // 
            // cmdEditOverlay
            // 
            this.cmdEditOverlay.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdEditOverlay.Location = new System.Drawing.Point(530, 372);
            this.cmdEditOverlay.Name = "cmdEditOverlay";
            this.cmdEditOverlay.Size = new System.Drawing.Size(81, 23);
            this.cmdEditOverlay.TabIndex = 14;
            this.cmdEditOverlay.Text = "Edit Options";
            this.cmdEditOverlay.UseVisualStyleBackColor = true;
            this.cmdEditOverlay.Click += new System.EventHandler(this.cmdEditOverlay_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(763, 36);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(63, 29);
            this.button1.TabIndex = 17;
            this.button1.Text = "lol debug";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Visible = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // cmenuBuilds
            // 
            this.cmenuBuilds.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.viewSharecodeToolStripMenuItem,
            this.toolStripMenuItem1,
            this.copySharecodeURLToolStripMenuItem,
            this.copySharecodeHTMLToolStripMenuItem,
            this.copySharecodeBBCodeToolStripMenuItem,
            this.copySharecodeRedditToolStripMenuItem});
            this.cmenuBuilds.Name = "cmenuBuilds";
            this.cmenuBuilds.Size = new System.Drawing.Size(214, 120);
            this.cmenuBuilds.Opening += new System.ComponentModel.CancelEventHandler(this.cmenuBuilds_Opening);
            // 
            // viewSharecodeToolStripMenuItem
            // 
            this.viewSharecodeToolStripMenuItem.Name = "viewSharecodeToolStripMenuItem";
            this.viewSharecodeToolStripMenuItem.Size = new System.Drawing.Size(213, 22);
            this.viewSharecodeToolStripMenuItem.Text = "View Sharecode";
            this.viewSharecodeToolStripMenuItem.Click += new System.EventHandler(this.viewSharecodeToolStripMenuItem_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(210, 6);
            // 
            // copySharecodeURLToolStripMenuItem
            // 
            this.copySharecodeURLToolStripMenuItem.Name = "copySharecodeURLToolStripMenuItem";
            this.copySharecodeURLToolStripMenuItem.Size = new System.Drawing.Size(213, 22);
            this.copySharecodeURLToolStripMenuItem.Text = "Copy Sharecode (URL)";
            this.copySharecodeURLToolStripMenuItem.Click += new System.EventHandler(this.copySharecodeURLToolStripMenuItem_Click);
            // 
            // copySharecodeHTMLToolStripMenuItem
            // 
            this.copySharecodeHTMLToolStripMenuItem.Name = "copySharecodeHTMLToolStripMenuItem";
            this.copySharecodeHTMLToolStripMenuItem.Size = new System.Drawing.Size(213, 22);
            this.copySharecodeHTMLToolStripMenuItem.Text = "Copy Sharecode (HTML)";
            this.copySharecodeHTMLToolStripMenuItem.Click += new System.EventHandler(this.copySharecodeHTMLToolStripMenuItem_Click);
            // 
            // copySharecodeBBCodeToolStripMenuItem
            // 
            this.copySharecodeBBCodeToolStripMenuItem.Name = "copySharecodeBBCodeToolStripMenuItem";
            this.copySharecodeBBCodeToolStripMenuItem.Size = new System.Drawing.Size(213, 22);
            this.copySharecodeBBCodeToolStripMenuItem.Text = "Copy Sharecode (BBCode)";
            this.copySharecodeBBCodeToolStripMenuItem.Click += new System.EventHandler(this.copySharecodeBBCodeToolStripMenuItem_Click);
            // 
            // copySharecodeRedditToolStripMenuItem
            // 
            this.copySharecodeRedditToolStripMenuItem.Name = "copySharecodeRedditToolStripMenuItem";
            this.copySharecodeRedditToolStripMenuItem.Size = new System.Drawing.Size(213, 22);
            this.copySharecodeRedditToolStripMenuItem.Text = "Copy Sharecode (Reddit)";
            this.copySharecodeRedditToolStripMenuItem.Click += new System.EventHandler(this.copySharecodeRedditToolStripMenuItem_Click);
            // 
            // cbPatch
            // 
            this.cbPatch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cbPatch.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cbPatch.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbPatch.FormattingEnabled = true;
            this.cbPatch.Location = new System.Drawing.Point(732, 348);
            this.cbPatch.Name = "cbPatch";
            this.cbPatch.Size = new System.Drawing.Size(99, 21);
            this.cbPatch.TabIndex = 17;
            this.cbPatch.SelectedIndexChanged += new System.EventHandler(this.cbPatch_SelectedIndexChanged);
            // 
            // cbMatchup
            // 
            this.cbMatchup.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cbMatchup.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cbMatchup.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbMatchup.FormattingEnabled = true;
            this.cbMatchup.Location = new System.Drawing.Point(757, 19);
            this.cbMatchup.Name = "cbMatchup";
            this.cbMatchup.Size = new System.Drawing.Size(74, 21);
            this.cbMatchup.TabIndex = 6;
            // 
            // lvBuilds
            // 
            this.lvBuilds.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.lvBuilds.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.lvchBuild,
            this.lvchMatchup});
            this.lvBuilds.ContextMenuStrip = this.cmenuBuilds;
            this.lvBuilds.ControlPadding = 4;
            this.lvBuilds.FullRowSelect = true;
            this.lvBuilds.Location = new System.Drawing.Point(2, 3);
            this.lvBuilds.MultiSelect = false;
            this.lvBuilds.Name = "lvBuilds";
            this.lvBuilds.OwnerDraw = true;
            this.lvBuilds.Size = new System.Drawing.Size(426, 320);
            this.lvBuilds.TabIndex = 3;
            this.lvBuilds.UseCompatibleStateImageBehavior = false;
            this.lvBuilds.View = System.Windows.Forms.View.Details;
            this.lvBuilds.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.lvBuilds_ColumnClick);
            this.lvBuilds.SelectedIndexChanged += new System.EventHandler(this.lvBuilds_SelectedIndexChanged);
            this.lvBuilds.DoubleClick += new System.EventHandler(this.lvBuilds_DoubleClick);
            this.lvBuilds.MouseUp += new System.Windows.Forms.MouseEventHandler(this.lvBuilds_MouseUp);
            // 
            // lvchBuild
            // 
            this.lvchBuild.Text = "Build";
            this.lvchBuild.Width = 320;
            // 
            // lvchMatchup
            // 
            this.lvchMatchup.Text = "Matchup";
            this.lvchMatchup.Width = 87;
            // 
            // lbUpdate
            // 
            this.lbUpdate.AutoSize = true;
            this.lbUpdate.Location = new System.Drawing.Point(436, 351);
            this.lbUpdate.Name = "lbUpdate";
            this.lbUpdate.Size = new System.Drawing.Size(190, 13);
            this.lbUpdate.TabIndex = 18;
            this.lbUpdate.TabStop = true;
            this.lbUpdate.Text = "Update Available (SC2 Scrapbook 2.0)";
            this.lbUpdate.TextAlign = System.Drawing.ContentAlignment.TopRight;
            this.lbUpdate.Visible = false;
            this.lbUpdate.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.cmdUpdate_LinkClicked);
            // 
            // llChangelog
            // 
            this.llChangelog.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.llChangelog.AutoSize = true;
            this.llChangelog.Location = new System.Drawing.Point(642, 351);
            this.llChangelog.Name = "llChangelog";
            this.llChangelog.Size = new System.Drawing.Size(84, 13);
            this.llChangelog.TabIndex = 19;
            this.llChangelog.TabStop = true;
            this.llChangelog.Text = "View Changelog";
            this.llChangelog.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.llChangelog_LinkClicked);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(834, 407);
            this.Controls.Add(this.llChangelog);
            this.Controls.Add(this.lbUpdate);
            this.Controls.Add(this.cbPatch);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.cmdEditOverlay);
            this.Controls.Add(this.cmdLoadDefaults);
            this.Controls.Add(this.cmdResetBuilds);
            this.Controls.Add(this.btnCloseOverlay);
            this.Controls.Add(this.cmdDelete);
            this.Controls.Add(this.btnUpdateBuild);
            this.Controls.Add(this.btnCreateBuild);
            this.Controls.Add(this.cbMatchup);
            this.Controls.Add(this.lblNotes);
            this.Controls.Add(this.txtNotes);
            this.Controls.Add(this.lblBuildName);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.lblScript);
            this.Controls.Add(this.txtScript);
            this.Controls.Add(this.lvBuilds);
            this.Controls.Add(this.gbFilter);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "SC2 Scrapbook";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmMain_FormClosing);
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.Move += new System.EventHandler(this.frmMain_Move);
            this.gbFilter.ResumeLayout(false);
            this.gbFilter.PerformLayout();
            this.cmenuBuilds.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Timer tmrNameChanged;
        private System.Windows.Forms.GroupBox gbFilter;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.TextBox txtBuildName;
        private System.Windows.Forms.Label lblPlayerRace;
        private EXControls.EXComboBox cbRace;
        private EXControls.EXComboBox cbVsRace;
        private System.Windows.Forms.Label lblVsRace;
        private EXControls.EXListView lvBuilds;
        private System.Windows.Forms.ColumnHeader lvchBuild;
        private System.Windows.Forms.ColumnHeader lvchMatchup;
        private System.Windows.Forms.TextBox txtScript;
        private System.Windows.Forms.Label lblScript;
        private System.Windows.Forms.Label lblBuildName;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Label lblNotes;
        private System.Windows.Forms.TextBox txtNotes;
        private EXControls.EXComboBox cbMatchup;
        private System.Windows.Forms.Button btnCreateBuild;
        private System.Windows.Forms.Button btnUpdateBuild;
        private System.Windows.Forms.Button cmdDelete;
        private System.Windows.Forms.Button btnCloseOverlay;
        private System.Windows.Forms.Button cmdResetBuilds;
        private System.Windows.Forms.Button cmdLoadDefaults;
        private System.Windows.Forms.Button cmdEditOverlay;
        private System.Windows.Forms.Button button1;
        private EXControls.EXComboBox cbPatch;
        private System.Windows.Forms.ContextMenuStrip cmenuBuilds;
        private System.Windows.Forms.ToolStripMenuItem viewSharecodeToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem copySharecodeURLToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem copySharecodeHTMLToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem copySharecodeBBCodeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem copySharecodeRedditToolStripMenuItem;
        private System.Windows.Forms.LinkLabel lbUpdate;
        private System.Windows.Forms.LinkLabel llChangelog;
    }
}

