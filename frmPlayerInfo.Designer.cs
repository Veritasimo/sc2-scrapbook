﻿namespace SC2Scrapbook
{
    partial class frmPlayerInfo
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
            this.tmrClose = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // tmrClose
            // 
            this.tmrClose.Interval = 10000;
            this.tmrClose.Tick += new System.EventHandler(this.tmrClose_Tick);
            // 
            // frmPlayerInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(284, 262);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmPlayerInfo";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.TopMost = true;
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmPlayerInfo_FormClosed);
            this.Load += new System.EventHandler(this.frmPlayerInfo_Load);
            this.Shown += new System.EventHandler(this.frmPlayerInfo_Shown);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.frmPlayerInfo_Paint);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Timer tmrClose;
    }
}