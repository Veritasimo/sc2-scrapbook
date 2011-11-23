namespace SC2Scrapbook
{
    partial class frmResources
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
            this.pbPreview = new System.Windows.Forms.PictureBox();
            this.GroupBox1 = new System.Windows.Forms.GroupBox();
            this.chkAR = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.numWidth = new System.Windows.Forms.NumericUpDown();
            this.numHeight = new System.Windows.Forms.NumericUpDown();
            this.lbResources = new System.Windows.Forms.ListBox();
            this.tbRotation = new System.Windows.Forms.TrackBar();
            this.lblImageInfo = new System.Windows.Forms.Label();
            this.ofd = new System.Windows.Forms.OpenFileDialog();
            this.cmdExternal = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pbPreview)).BeginInit();
            this.GroupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numWidth)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numHeight)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbRotation)).BeginInit();
            this.SuspendLayout();
            // 
            // pbPreview
            // 
            this.pbPreview.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.pbPreview.Cursor = System.Windows.Forms.Cursors.SizeAll;
            this.pbPreview.Location = new System.Drawing.Point(218, 7);
            this.pbPreview.Name = "pbPreview";
            this.pbPreview.Size = new System.Drawing.Size(244, 232);
            this.pbPreview.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pbPreview.TabIndex = 5;
            this.pbPreview.TabStop = false;
            this.pbPreview.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pbPreview_MouseDown);
            // 
            // GroupBox1
            // 
            this.GroupBox1.Controls.Add(this.chkAR);
            this.GroupBox1.Controls.Add(this.label1);
            this.GroupBox1.Controls.Add(this.numWidth);
            this.GroupBox1.Controls.Add(this.numHeight);
            this.GroupBox1.Controls.Add(this.lbResources);
            this.GroupBox1.Location = new System.Drawing.Point(8, 8);
            this.GroupBox1.Name = "GroupBox1";
            this.GroupBox1.Size = new System.Drawing.Size(204, 265);
            this.GroupBox1.TabIndex = 4;
            this.GroupBox1.TabStop = false;
            this.GroupBox1.Text = "Resource Context";
            // 
            // chkAR
            // 
            this.chkAR.AutoSize = true;
            this.chkAR.Checked = true;
            this.chkAR.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkAR.Location = new System.Drawing.Point(146, 238);
            this.chkAR.Name = "chkAR";
            this.chkAR.Size = new System.Drawing.Size(41, 17);
            this.chkAR.TabIndex = 4;
            this.chkAR.Text = "AR";
            this.chkAR.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(68, 239);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(12, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "x";
            // 
            // numWidth
            // 
            this.numWidth.Location = new System.Drawing.Point(6, 237);
            this.numWidth.Name = "numWidth";
            this.numWidth.Size = new System.Drawing.Size(60, 20);
            this.numWidth.TabIndex = 2;
            this.numWidth.ValueChanged += new System.EventHandler(this.numWidth_ValueChanged);
            // 
            // numHeight
            // 
            this.numHeight.Location = new System.Drawing.Point(80, 237);
            this.numHeight.Name = "numHeight";
            this.numHeight.Size = new System.Drawing.Size(60, 20);
            this.numHeight.TabIndex = 1;
            this.numHeight.ValueChanged += new System.EventHandler(this.numHeight_ValueChanged);
            // 
            // lbResources
            // 
            this.lbResources.FormattingEnabled = true;
            this.lbResources.Location = new System.Drawing.Point(6, 19);
            this.lbResources.Name = "lbResources";
            this.lbResources.Size = new System.Drawing.Size(192, 212);
            this.lbResources.TabIndex = 0;
            this.lbResources.SelectedIndexChanged += new System.EventHandler(this.lbResources_SelectedIndexChanged);
            // 
            // tbRotation
            // 
            this.tbRotation.Location = new System.Drawing.Point(218, 245);
            this.tbRotation.Maximum = 180;
            this.tbRotation.Minimum = -180;
            this.tbRotation.Name = "tbRotation";
            this.tbRotation.Size = new System.Drawing.Size(244, 45);
            this.tbRotation.TabIndex = 6;
            this.tbRotation.Scroll += new System.EventHandler(this.tbRotation_Scroll);
            // 
            // lblImageInfo
            // 
            this.lblImageInfo.AutoSize = true;
            this.lblImageInfo.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.lblImageInfo.Location = new System.Drawing.Point(218, 8);
            this.lblImageInfo.Name = "lblImageInfo";
            this.lblImageInfo.Size = new System.Drawing.Size(0, 13);
            this.lblImageInfo.TabIndex = 7;
            // 
            // ofd
            // 
            this.ofd.Filter = "Image Files (*.png;*.jpg;*.jpeg;*.gif;*.bmp;*.tiff)|*.png;*.jpg;*.jpeg;*.gif;*.bm" +
    "p;*.tiff|All Files (*.*)|*.*";
            // 
            // cmdExternal
            // 
            this.cmdExternal.Location = new System.Drawing.Point(8, 273);
            this.cmdExternal.Name = "cmdExternal";
            this.cmdExternal.Size = new System.Drawing.Size(88, 23);
            this.cmdExternal.TabIndex = 8;
            this.cmdExternal.Text = "Load External";
            this.cmdExternal.UseVisualStyleBackColor = true;
            this.cmdExternal.Click += new System.EventHandler(this.cmdExternal_Click);
            // 
            // frmResources
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(472, 299);
            this.Controls.Add(this.cmdExternal);
            this.Controls.Add(this.lblImageInfo);
            this.Controls.Add(this.tbRotation);
            this.Controls.Add(this.pbPreview);
            this.Controls.Add(this.GroupBox1);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmResources";
            this.Text = "Resources";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmResources_FormClosed);
            this.Load += new System.EventHandler(this.frmResources_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pbPreview)).EndInit();
            this.GroupBox1.ResumeLayout(false);
            this.GroupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numWidth)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numHeight)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbRotation)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        internal System.Windows.Forms.PictureBox pbPreview;
        internal System.Windows.Forms.GroupBox GroupBox1;
        internal System.Windows.Forms.ListBox lbResources;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown numWidth;
        private System.Windows.Forms.NumericUpDown numHeight;
        private System.Windows.Forms.CheckBox chkAR;
        private System.Windows.Forms.TrackBar tbRotation;
        private System.Windows.Forms.Label lblImageInfo;
        private System.Windows.Forms.OpenFileDialog ofd;
        private System.Windows.Forms.Button cmdExternal;
    }
}