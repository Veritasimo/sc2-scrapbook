namespace SC2Scrapbook
{
    partial class frmBuildOverlay
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmBuildOverlay));
            this.lblFakeTitle = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblFakeTitle
            // 
            this.lblFakeTitle.BackColor = System.Drawing.Color.Transparent;
            this.lblFakeTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblFakeTitle.Location = new System.Drawing.Point(0, 0);
            this.lblFakeTitle.Name = "lblFakeTitle";
            this.lblFakeTitle.Size = new System.Drawing.Size(453, 31);
            this.lblFakeTitle.TabIndex = 0;
            this.lblFakeTitle.DoubleClick += new System.EventHandler(this.frmOverlay_DoubleClick);
            this.lblFakeTitle.MouseDown += new System.Windows.Forms.MouseEventHandler(this.lblFakeTitle_MouseDown);
            this.lblFakeTitle.MouseUp += new System.Windows.Forms.MouseEventHandler(this.frmOverlay_MouseUp);
            // 
            // frmOverlay
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DimGray;
            this.ClientSize = new System.Drawing.Size(453, 341);
            this.Controls.Add(this.lblFakeTitle);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmOverlay";
            this.Opacity = 0.5D;
            this.ShowInTaskbar = false;
            this.Text = "Build Order Overlay";
            this.TopMost = true;
            this.TransparencyKey = System.Drawing.Color.Red;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmOverlay_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmOverlay_FormClosed);
            this.Load += new System.EventHandler(this.frmOverlay_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.frmOverlay_Paint);
            this.DoubleClick += new System.EventHandler(this.frmOverlay_DoubleClick);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.frmOverlay_MouseMove);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.frmOverlay_MouseUp);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblFakeTitle;

    }
}