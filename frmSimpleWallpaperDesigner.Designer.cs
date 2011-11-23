namespace SC2Scrapbook
{
    partial class frmSimpleWallpaperDesigner
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSimpleWallpaperDesigner));
            this.pnlControls = new System.Windows.Forms.Panel();
            this.cmdResource = new System.Windows.Forms.Button();
            this.cmdUpdate = new System.Windows.Forms.Button();
            this.lblInfo = new System.Windows.Forms.Label();
            this.cmdSave = new System.Windows.Forms.Button();
            this.pnlContent = new System.Windows.Forms.Panel();
            this.pbBlankBox = new System.Windows.Forms.PictureBox();
            this.pnlReceptical = new System.Windows.Forms.Panel();
            this.lblBaseRequired = new System.Windows.Forms.Label();
            this.tooltip = new System.Windows.Forms.ToolTip(this.components);
            this.sfd = new System.Windows.Forms.SaveFileDialog();
            this.pnlControls.SuspendLayout();
            this.pnlContent.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbBlankBox)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlControls
            // 
            this.pnlControls.Controls.Add(this.cmdResource);
            this.pnlControls.Controls.Add(this.cmdUpdate);
            this.pnlControls.Controls.Add(this.lblInfo);
            this.pnlControls.Controls.Add(this.cmdSave);
            this.pnlControls.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlControls.Location = new System.Drawing.Point(0, 332);
            this.pnlControls.Name = "pnlControls";
            this.pnlControls.Size = new System.Drawing.Size(584, 30);
            this.pnlControls.TabIndex = 0;
            // 
            // cmdResource
            // 
            this.cmdResource.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdResource.Location = new System.Drawing.Point(283, 3);
            this.cmdResource.Name = "cmdResource";
            this.cmdResource.Size = new System.Drawing.Size(94, 23);
            this.cmdResource.TabIndex = 3;
            this.cmdResource.Text = "View Resources";
            this.cmdResource.UseVisualStyleBackColor = true;
            this.cmdResource.Click += new System.EventHandler(this.cmdResource_Click);
            // 
            // cmdUpdate
            // 
            this.cmdUpdate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdUpdate.Location = new System.Drawing.Point(383, 3);
            this.cmdUpdate.Name = "cmdUpdate";
            this.cmdUpdate.Size = new System.Drawing.Size(117, 23);
            this.cmdUpdate.TabIndex = 2;
            this.cmdUpdate.Text = "Refresh Build Images";
            this.cmdUpdate.UseVisualStyleBackColor = true;
            this.cmdUpdate.Click += new System.EventHandler(this.cmdUpdate_Click);
            // 
            // lblInfo
            // 
            this.lblInfo.Dock = System.Windows.Forms.DockStyle.Left;
            this.lblInfo.Location = new System.Drawing.Point(0, 0);
            this.lblInfo.Name = "lblInfo";
            this.lblInfo.Size = new System.Drawing.Size(193, 30);
            this.lblInfo.TabIndex = 1;
            this.lblInfo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cmdSave
            // 
            this.cmdSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdSave.Location = new System.Drawing.Point(506, 3);
            this.cmdSave.Name = "cmdSave";
            this.cmdSave.Size = new System.Drawing.Size(75, 23);
            this.cmdSave.TabIndex = 0;
            this.cmdSave.Text = "Save";
            this.cmdSave.UseVisualStyleBackColor = true;
            this.cmdSave.Click += new System.EventHandler(this.cmdSave_Click);
            // 
            // pnlContent
            // 
            this.pnlContent.AutoScroll = true;
            this.pnlContent.AutoSize = true;
            this.pnlContent.Controls.Add(this.pbBlankBox);
            this.pnlContent.Controls.Add(this.pnlReceptical);
            this.pnlContent.Controls.Add(this.lblBaseRequired);
            this.pnlContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlContent.Location = new System.Drawing.Point(0, 0);
            this.pnlContent.Name = "pnlContent";
            this.pnlContent.Size = new System.Drawing.Size(584, 332);
            this.pnlContent.TabIndex = 1;
            // 
            // pbBlankBox
            // 
            this.pbBlankBox.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.pbBlankBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pbBlankBox.Location = new System.Drawing.Point(419, 108);
            this.pbBlankBox.Name = "pbBlankBox";
            this.pbBlankBox.Size = new System.Drawing.Size(14, 14);
            this.pbBlankBox.TabIndex = 6;
            this.pbBlankBox.TabStop = false;
            this.pbBlankBox.Visible = false;
            // 
            // pnlReceptical
            // 
            this.pnlReceptical.AllowDrop = true;
            this.pnlReceptical.Location = new System.Drawing.Point(0, 0);
            this.pnlReceptical.Name = "pnlReceptical";
            this.pnlReceptical.Size = new System.Drawing.Size(121, 85);
            this.pnlReceptical.TabIndex = 1;
            this.pnlReceptical.Visible = false;
            this.pnlReceptical.DragDrop += new System.Windows.Forms.DragEventHandler(this.pnlReceptical_DragDrop);
            this.pnlReceptical.DragEnter += new System.Windows.Forms.DragEventHandler(this.pnlReceptical_DragEnter);
            this.pnlReceptical.DragOver += new System.Windows.Forms.DragEventHandler(this.pnlReceptical_DragOver);
            // 
            // lblBaseRequired
            // 
            this.lblBaseRequired.AllowDrop = true;
            this.lblBaseRequired.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblBaseRequired.Location = new System.Drawing.Point(0, 0);
            this.lblBaseRequired.Name = "lblBaseRequired";
            this.lblBaseRequired.Size = new System.Drawing.Size(584, 332);
            this.lblBaseRequired.TabIndex = 0;
            this.lblBaseRequired.Text = "[ Drag an image to use as the wallpaper base, then drag builds or resources ]";
            this.lblBaseRequired.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblBaseRequired.DragDrop += new System.Windows.Forms.DragEventHandler(this.lblBaseRequired_DragDrop);
            this.lblBaseRequired.DragEnter += new System.Windows.Forms.DragEventHandler(this.lblInfo_DragEnter);
            // 
            // sfd
            // 
            this.sfd.Filter = "PNG Files (*.png)|*.png|JPEG Files (*.jpg;*.jpeg)|*.jpg;*.jpeg|Birmap Files (*.bm" +
    "p)|*.bmp";
            // 
            // frmSimpleWallpaperDesigner
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(584, 362);
            this.Controls.Add(this.pnlContent);
            this.Controls.Add(this.pnlControls);
            this.DoubleBuffered = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximumSize = new System.Drawing.Size(600, 400);
            this.MinimumSize = new System.Drawing.Size(513, 308);
            this.Name = "frmSimpleWallpaperDesigner";
            this.Text = "SC2 Scrapbook - Wallpaper Designer";
            this.pnlControls.ResumeLayout(false);
            this.pnlContent.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbBlankBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel pnlControls;
        private System.Windows.Forms.Button cmdSave;
        private System.Windows.Forms.Panel pnlContent;
        private System.Windows.Forms.Label lblBaseRequired;
        private System.Windows.Forms.Label lblInfo;
        private System.Windows.Forms.Panel pnlReceptical;
        private System.Windows.Forms.ToolTip tooltip;
        internal System.Windows.Forms.PictureBox pbBlankBox;
        private System.Windows.Forms.Button cmdUpdate;
        private System.Windows.Forms.Button cmdResource;
        private System.Windows.Forms.SaveFileDialog sfd;
    }
}