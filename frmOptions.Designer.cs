namespace SC2Scrapbook
{
    partial class frmOptions
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmOptions));
            this.fontDialog = new System.Windows.Forms.FontDialog();
            this.cmdExit = new System.Windows.Forms.Button();
            this.colorDialog = new System.Windows.Forms.ColorDialog();
            this.grpOverlay = new System.Windows.Forms.GroupBox();
            this.numImageScale = new System.Windows.Forms.NumericUpDown();
            this.label5 = new System.Windows.Forms.Label();
            this.txtOverlayHotkey = new System.Windows.Forms.TextBox();
            this.lblOverlayKey = new System.Windows.Forms.Label();
            this.pnlTextColour = new System.Windows.Forms.Panel();
            this.lblTextColour = new System.Windows.Forms.Label();
            this.pnlOutlineColour = new System.Windows.Forms.Panel();
            this.lblOutlineColour = new System.Windows.Forms.Label();
            this.numOutlineSize = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.cmdEditContentFont = new System.Windows.Forms.Button();
            this.cmdEditTitle = new System.Windows.Forms.Button();
            this.cmdPreview = new System.Windows.Forms.Button();
            this.grpAdvancedOpponentInfo = new System.Windows.Forms.GroupBox();
            this.txtMySC2Name = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.numOverlayClose = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.llNameHelp = new System.Windows.Forms.LinkLabel();
            this.chkAllowVsX = new System.Windows.Forms.CheckBox();
            this.chkUseRandomBuild = new System.Windows.Forms.CheckBox();
            this.label2 = new System.Windows.Forms.Label();
            this.chkIngameBOSelector = new System.Windows.Forms.CheckBox();
            this.chkOpponentInfoOverlay = new System.Windows.Forms.CheckBox();
            this.chkAdvancedEnabled = new System.Windows.Forms.CheckBox();
            this.grpOverlay.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numImageScale)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numOutlineSize)).BeginInit();
            this.grpAdvancedOpponentInfo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numOverlayClose)).BeginInit();
            this.SuspendLayout();
            // 
            // cmdExit
            // 
            this.cmdExit.Location = new System.Drawing.Point(560, 219);
            this.cmdExit.Name = "cmdExit";
            this.cmdExit.Size = new System.Drawing.Size(75, 23);
            this.cmdExit.TabIndex = 0;
            this.cmdExit.Text = "Exit";
            this.cmdExit.UseVisualStyleBackColor = true;
            this.cmdExit.Click += new System.EventHandler(this.cmdExit_Click);
            // 
            // grpOverlay
            // 
            this.grpOverlay.Controls.Add(this.numImageScale);
            this.grpOverlay.Controls.Add(this.label5);
            this.grpOverlay.Controls.Add(this.txtOverlayHotkey);
            this.grpOverlay.Controls.Add(this.lblOverlayKey);
            this.grpOverlay.Controls.Add(this.pnlTextColour);
            this.grpOverlay.Controls.Add(this.lblTextColour);
            this.grpOverlay.Controls.Add(this.pnlOutlineColour);
            this.grpOverlay.Controls.Add(this.lblOutlineColour);
            this.grpOverlay.Controls.Add(this.numOutlineSize);
            this.grpOverlay.Controls.Add(this.label1);
            this.grpOverlay.Controls.Add(this.cmdEditContentFont);
            this.grpOverlay.Controls.Add(this.cmdEditTitle);
            this.grpOverlay.Location = new System.Drawing.Point(10, 12);
            this.grpOverlay.Name = "grpOverlay";
            this.grpOverlay.Size = new System.Drawing.Size(322, 202);
            this.grpOverlay.TabIndex = 12;
            this.grpOverlay.TabStop = false;
            this.grpOverlay.Text = "Build Order Overlay";
            // 
            // numImageScale
            // 
            this.numImageScale.Location = new System.Drawing.Point(180, 136);
            this.numImageScale.Maximum = new decimal(new int[] {
            8,
            0,
            0,
            0});
            this.numImageScale.Name = "numImageScale";
            this.numImageScale.Size = new System.Drawing.Size(136, 20);
            this.numImageScale.TabIndex = 24;
            this.numImageScale.Value = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.numImageScale.ValueChanged += new System.EventHandler(this.numImageScale_ValueChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(10, 138);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(66, 13);
            this.label5.TabIndex = 23;
            this.label5.Text = "Image Scale";
            // 
            // txtOverlayHotkey
            // 
            this.txtOverlayHotkey.Location = new System.Drawing.Point(180, 162);
            this.txtOverlayHotkey.Name = "txtOverlayHotkey";
            this.txtOverlayHotkey.ReadOnly = true;
            this.txtOverlayHotkey.Size = new System.Drawing.Size(136, 20);
            this.txtOverlayHotkey.TabIndex = 22;
            this.txtOverlayHotkey.TextChanged += new System.EventHandler(this.txtOverlayHotkey_TextChanged);
            this.txtOverlayHotkey.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtOverlayHotkey_KeyDown);
            this.txtOverlayHotkey.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtOverlayHotkey_KeyUp);
            // 
            // lblOverlayKey
            // 
            this.lblOverlayKey.AutoSize = true;
            this.lblOverlayKey.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblOverlayKey.Location = new System.Drawing.Point(10, 165);
            this.lblOverlayKey.Name = "lblOverlayKey";
            this.lblOverlayKey.Size = new System.Drawing.Size(116, 13);
            this.lblOverlayKey.TabIndex = 21;
            this.lblOverlayKey.Text = "Overlay Toggle Hotkey";
            // 
            // pnlTextColour
            // 
            this.pnlTextColour.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pnlTextColour.Location = new System.Drawing.Point(180, 61);
            this.pnlTextColour.Name = "pnlTextColour";
            this.pnlTextColour.Size = new System.Drawing.Size(136, 19);
            this.pnlTextColour.TabIndex = 19;
            this.pnlTextColour.Click += new System.EventHandler(this.pnlTextColour_Click);
            // 
            // lblTextColour
            // 
            this.lblTextColour.AutoSize = true;
            this.lblTextColour.Location = new System.Drawing.Point(10, 67);
            this.lblTextColour.Name = "lblTextColour";
            this.lblTextColour.Size = new System.Drawing.Size(61, 13);
            this.lblTextColour.TabIndex = 18;
            this.lblTextColour.Text = "Text Colour";
            // 
            // pnlOutlineColour
            // 
            this.pnlOutlineColour.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pnlOutlineColour.Location = new System.Drawing.Point(180, 85);
            this.pnlOutlineColour.Name = "pnlOutlineColour";
            this.pnlOutlineColour.Size = new System.Drawing.Size(136, 19);
            this.pnlOutlineColour.TabIndex = 17;
            this.pnlOutlineColour.Click += new System.EventHandler(this.pnlOutlineColour_Click);
            // 
            // lblOutlineColour
            // 
            this.lblOutlineColour.AutoSize = true;
            this.lblOutlineColour.Location = new System.Drawing.Point(10, 89);
            this.lblOutlineColour.Name = "lblOutlineColour";
            this.lblOutlineColour.Size = new System.Drawing.Size(97, 13);
            this.lblOutlineColour.TabIndex = 16;
            this.lblOutlineColour.Text = "Text Outline Colour";
            // 
            // numOutlineSize
            // 
            this.numOutlineSize.Location = new System.Drawing.Point(180, 110);
            this.numOutlineSize.Maximum = new decimal(new int[] {
            8,
            0,
            0,
            0});
            this.numOutlineSize.Name = "numOutlineSize";
            this.numOutlineSize.Size = new System.Drawing.Size(136, 20);
            this.numOutlineSize.TabIndex = 15;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 112);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(87, 13);
            this.label1.TabIndex = 14;
            this.label1.Text = "Text Outline Size";
            // 
            // cmdEditContentFont
            // 
            this.cmdEditContentFont.Location = new System.Drawing.Point(110, 19);
            this.cmdEditContentFont.Name = "cmdEditContentFont";
            this.cmdEditContentFont.Size = new System.Drawing.Size(101, 23);
            this.cmdEditContentFont.TabIndex = 13;
            this.cmdEditContentFont.Text = "Edit Content Font";
            this.cmdEditContentFont.UseVisualStyleBackColor = true;
            this.cmdEditContentFont.Click += new System.EventHandler(this.cmdEditContentFont_Click);
            // 
            // cmdEditTitle
            // 
            this.cmdEditTitle.Location = new System.Drawing.Point(14, 19);
            this.cmdEditTitle.Name = "cmdEditTitle";
            this.cmdEditTitle.Size = new System.Drawing.Size(90, 23);
            this.cmdEditTitle.TabIndex = 12;
            this.cmdEditTitle.Text = "Edit Title Font";
            this.cmdEditTitle.UseVisualStyleBackColor = true;
            this.cmdEditTitle.Click += new System.EventHandler(this.cmdEditTitle_Click);
            // 
            // cmdPreview
            // 
            this.cmdPreview.Location = new System.Drawing.Point(452, 219);
            this.cmdPreview.Name = "cmdPreview";
            this.cmdPreview.Size = new System.Drawing.Size(97, 23);
            this.cmdPreview.TabIndex = 20;
            this.cmdPreview.Text = "Preview Overlay";
            this.cmdPreview.UseVisualStyleBackColor = true;
            this.cmdPreview.Click += new System.EventHandler(this.cmdPreview_Click);
            // 
            // grpAdvancedOpponentInfo
            // 
            this.grpAdvancedOpponentInfo.Controls.Add(this.txtMySC2Name);
            this.grpAdvancedOpponentInfo.Controls.Add(this.label4);
            this.grpAdvancedOpponentInfo.Controls.Add(this.numOverlayClose);
            this.grpAdvancedOpponentInfo.Controls.Add(this.label3);
            this.grpAdvancedOpponentInfo.Controls.Add(this.llNameHelp);
            this.grpAdvancedOpponentInfo.Controls.Add(this.chkAllowVsX);
            this.grpAdvancedOpponentInfo.Controls.Add(this.chkUseRandomBuild);
            this.grpAdvancedOpponentInfo.Controls.Add(this.label2);
            this.grpAdvancedOpponentInfo.Controls.Add(this.chkIngameBOSelector);
            this.grpAdvancedOpponentInfo.Controls.Add(this.chkOpponentInfoOverlay);
            this.grpAdvancedOpponentInfo.Enabled = false;
            this.grpAdvancedOpponentInfo.Location = new System.Drawing.Point(338, 12);
            this.grpAdvancedOpponentInfo.Name = "grpAdvancedOpponentInfo";
            this.grpAdvancedOpponentInfo.Size = new System.Drawing.Size(288, 202);
            this.grpAdvancedOpponentInfo.TabIndex = 13;
            this.grpAdvancedOpponentInfo.TabStop = false;
            this.grpAdvancedOpponentInfo.Text = "                                             ";
            // 
            // txtMySC2Name
            // 
            this.txtMySC2Name.FormattingEnabled = true;
            this.txtMySC2Name.Location = new System.Drawing.Point(121, 21);
            this.txtMySC2Name.Name = "txtMySC2Name";
            this.txtMySC2Name.Size = new System.Drawing.Size(100, 21);
            this.txtMySC2Name.TabIndex = 31;
            this.txtMySC2Name.TextChanged += new System.EventHandler(this.txtMySC2Name_TextChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(184, 68);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(50, 13);
            this.label4.TabIndex = 30;
            this.label4.Text = "seconds.";
            // 
            // numOverlayClose
            // 
            this.numOverlayClose.Location = new System.Drawing.Point(142, 66);
            this.numOverlayClose.Name = "numOverlayClose";
            this.numOverlayClose.Size = new System.Drawing.Size(42, 20);
            this.numOverlayClose.TabIndex = 29;
            this.numOverlayClose.ValueChanged += new System.EventHandler(this.numOverlayClose_ValueChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(31, 68);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(112, 13);
            this.label3.TabIndex = 28;
            this.label3.Text = "Close the overlay after";
            // 
            // llNameHelp
            // 
            this.llNameHelp.AutoSize = true;
            this.llNameHelp.Location = new System.Drawing.Point(227, 24);
            this.llNameHelp.Name = "llNameHelp";
            this.llNameHelp.Size = new System.Drawing.Size(13, 13);
            this.llNameHelp.TabIndex = 27;
            this.llNameHelp.TabStop = true;
            this.llNameHelp.Text = "?";
            this.llNameHelp.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.llNameHelp_LinkClicked);
            // 
            // chkAllowVsX
            // 
            this.chkAllowVsX.AutoSize = true;
            this.chkAllowVsX.Enabled = false;
            this.chkAllowVsX.Location = new System.Drawing.Point(33, 121);
            this.chkAllowVsX.Name = "chkAllowVsX";
            this.chkAllowVsX.Size = new System.Drawing.Size(209, 17);
            this.chkAllowVsX.TabIndex = 25;
            this.chkAllowVsX.Text = "Include vsX builds (e.g., TvP and TvX)";
            this.chkAllowVsX.UseVisualStyleBackColor = true;
            this.chkAllowVsX.CheckedChanged += new System.EventHandler(this.chkAllowVsX_CheckedChanged);
            // 
            // chkUseRandomBuild
            // 
            this.chkUseRandomBuild.AutoSize = true;
            this.chkUseRandomBuild.Enabled = false;
            this.chkUseRandomBuild.Location = new System.Drawing.Point(33, 104);
            this.chkUseRandomBuild.Name = "chkUseRandomBuild";
            this.chkUseRandomBuild.Size = new System.Drawing.Size(191, 17);
            this.chkUseRandomBuild.TabIndex = 24;
            this.chkUseRandomBuild.Text = "Automatically select a random build";
            this.chkUseRandomBuild.UseVisualStyleBackColor = true;
            this.chkUseRandomBuild.CheckedChanged += new System.EventHandler(this.chkUseRandomBuild_CheckedChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 24);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(107, 13);
            this.label2.TabIndex = 18;
            this.label2.Text = "Your SC2 Character: ";
            // 
            // chkIngameBOSelector
            // 
            this.chkIngameBOSelector.AutoSize = true;
            this.chkIngameBOSelector.Location = new System.Drawing.Point(15, 85);
            this.chkIngameBOSelector.Name = "chkIngameBOSelector";
            this.chkIngameBOSelector.Size = new System.Drawing.Size(250, 17);
            this.chkIngameBOSelector.TabIndex = 23;
            this.chkIngameBOSelector.Text = "Show build order selection overlay on game join";
            this.chkIngameBOSelector.UseVisualStyleBackColor = true;
            this.chkIngameBOSelector.CheckedChanged += new System.EventHandler(this.chkIngameBOSelector_CheckedChanged);
            // 
            // chkOpponentInfoOverlay
            // 
            this.chkOpponentInfoOverlay.AutoSize = true;
            this.chkOpponentInfoOverlay.Location = new System.Drawing.Point(15, 48);
            this.chkOpponentInfoOverlay.Name = "chkOpponentInfoOverlay";
            this.chkOpponentInfoOverlay.Size = new System.Drawing.Size(221, 17);
            this.chkOpponentInfoOverlay.TabIndex = 22;
            this.chkOpponentInfoOverlay.Text = "Show opponent info overlay on game join";
            this.chkOpponentInfoOverlay.UseVisualStyleBackColor = true;
            this.chkOpponentInfoOverlay.CheckedChanged += new System.EventHandler(this.chkOpponentInfoOverlay_CheckedChanged);
            // 
            // chkAdvancedEnabled
            // 
            this.chkAdvancedEnabled.AutoSize = true;
            this.chkAdvancedEnabled.BackColor = System.Drawing.Color.Transparent;
            this.chkAdvancedEnabled.Location = new System.Drawing.Point(353, 11);
            this.chkAdvancedEnabled.Name = "chkAdvancedEnabled";
            this.chkAdvancedEnabled.Size = new System.Drawing.Size(139, 17);
            this.chkAdvancedEnabled.TabIndex = 21;
            this.chkAdvancedEnabled.Text = "Advanced SC2 Settings";
            this.chkAdvancedEnabled.UseVisualStyleBackColor = false;
            this.chkAdvancedEnabled.CheckedChanged += new System.EventHandler(this.chkAdvancedEnabled_CheckedChanged);
            // 
            // frmOptions
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(638, 247);
            this.Controls.Add(this.chkAdvancedEnabled);
            this.Controls.Add(this.grpAdvancedOpponentInfo);
            this.Controls.Add(this.grpOverlay);
            this.Controls.Add(this.cmdPreview);
            this.Controls.Add(this.cmdExit);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmOptions";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Options";
            this.Load += new System.EventHandler(this.frmOverlayOptions_Load);
            this.grpOverlay.ResumeLayout(false);
            this.grpOverlay.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numImageScale)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numOutlineSize)).EndInit();
            this.grpAdvancedOpponentInfo.ResumeLayout(false);
            this.grpAdvancedOpponentInfo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numOverlayClose)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.FontDialog fontDialog;
        private System.Windows.Forms.Button cmdExit;
        private System.Windows.Forms.ColorDialog colorDialog;
        private System.Windows.Forms.GroupBox grpOverlay;
        private System.Windows.Forms.TextBox txtOverlayHotkey;
        private System.Windows.Forms.Label lblOverlayKey;
        private System.Windows.Forms.Button cmdPreview;
        private System.Windows.Forms.Panel pnlTextColour;
        private System.Windows.Forms.Label lblTextColour;
        private System.Windows.Forms.Panel pnlOutlineColour;
        private System.Windows.Forms.Label lblOutlineColour;
        private System.Windows.Forms.NumericUpDown numOutlineSize;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button cmdEditContentFont;
        private System.Windows.Forms.Button cmdEditTitle;
        private System.Windows.Forms.GroupBox grpAdvancedOpponentInfo;
        private System.Windows.Forms.CheckBox chkAdvancedEnabled;
        private System.Windows.Forms.CheckBox chkIngameBOSelector;
        private System.Windows.Forms.CheckBox chkOpponentInfoOverlay;
        private System.Windows.Forms.CheckBox chkUseRandomBuild;
        private System.Windows.Forms.CheckBox chkAllowVsX;
        private System.Windows.Forms.LinkLabel llNameHelp;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown numOverlayClose;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown numImageScale;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox txtMySC2Name;
        private System.Windows.Forms.Label label2;
    }
}