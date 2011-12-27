namespace SC2Scrapbook
{
    partial class frmManualSharecodeEntry
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmManualSharecodeEntry));
            this.txtShareCode = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cmdImport = new System.Windows.Forms.Button();
            this.tmrUpdate = new System.Windows.Forms.Timer(this.components);
            this.pbStatus = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pbStatus)).BeginInit();
            this.SuspendLayout();
            // 
            // txtShareCode
            // 
            this.txtShareCode.Location = new System.Drawing.Point(72, 6);
            this.txtShareCode.Name = "txtShareCode";
            this.txtShareCode.Size = new System.Drawing.Size(310, 20);
            this.txtShareCode.TabIndex = 0;
            this.txtShareCode.TextChanged += new System.EventHandler(this.txtShareCode_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(4, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(62, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Sharecode:";
            // 
            // cmdImport
            // 
            this.cmdImport.Location = new System.Drawing.Point(307, 32);
            this.cmdImport.Name = "cmdImport";
            this.cmdImport.Size = new System.Drawing.Size(75, 23);
            this.cmdImport.TabIndex = 6;
            this.cmdImport.Text = "Import";
            this.cmdImport.UseVisualStyleBackColor = true;
            this.cmdImport.Click += new System.EventHandler(this.cmdImport_Click);
            // 
            // tmrUpdate
            // 
            this.tmrUpdate.Interval = 200;
            this.tmrUpdate.Tick += new System.EventHandler(this.tmrUpdate_Tick);
            // 
            // pbStatus
            // 
            this.pbStatus.Location = new System.Drawing.Point(388, 6);
            this.pbStatus.Name = "pbStatus";
            this.pbStatus.Size = new System.Drawing.Size(20, 20);
            this.pbStatus.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbStatus.TabIndex = 7;
            this.pbStatus.TabStop = false;
            // 
            // frmManualSharecodeEntry
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(414, 59);
            this.Controls.Add(this.pbStatus);
            this.Controls.Add(this.cmdImport);
            this.Controls.Add(this.txtShareCode);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmManualSharecodeEntry";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Import Build";
            ((System.ComponentModel.ISupportInitialize)(this.pbStatus)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtShareCode;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button cmdImport;
        private System.Windows.Forms.Timer tmrUpdate;
        private System.Windows.Forms.PictureBox pbStatus;
    }
}