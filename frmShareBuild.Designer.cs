namespace SC2Scrapbook
{
    partial class frmShareBuild
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmShareBuild));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtShareCode = new System.Windows.Forms.TextBox();
            this.txtHTML = new System.Windows.Forms.TextBox();
            this.txtBBCode = new System.Windows.Forms.TextBox();
            this.txtReddit = new System.Windows.Forms.TextBox();
            this.btnCopySharecode = new System.Windows.Forms.Button();
            this.btnShareHTML = new System.Windows.Forms.Button();
            this.btnShareBBCode = new System.Windows.Forms.Button();
            this.btnShareReddit = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(62, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Sharecode:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 35);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(40, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "HTML:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(11, 61);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(49, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "BBCode:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(11, 87);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(41, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "Reddit:";
            // 
            // txtShareCode
            // 
            this.txtShareCode.Location = new System.Drawing.Point(80, 6);
            this.txtShareCode.Name = "txtShareCode";
            this.txtShareCode.ReadOnly = true;
            this.txtShareCode.Size = new System.Drawing.Size(285, 20);
            this.txtShareCode.TabIndex = 4;
            // 
            // txtHTML
            // 
            this.txtHTML.Location = new System.Drawing.Point(80, 32);
            this.txtHTML.Name = "txtHTML";
            this.txtHTML.ReadOnly = true;
            this.txtHTML.Size = new System.Drawing.Size(285, 20);
            this.txtHTML.TabIndex = 5;
            // 
            // txtBBCode
            // 
            this.txtBBCode.Location = new System.Drawing.Point(80, 58);
            this.txtBBCode.Name = "txtBBCode";
            this.txtBBCode.ReadOnly = true;
            this.txtBBCode.Size = new System.Drawing.Size(285, 20);
            this.txtBBCode.TabIndex = 6;
            // 
            // txtReddit
            // 
            this.txtReddit.Location = new System.Drawing.Point(80, 84);
            this.txtReddit.Name = "txtReddit";
            this.txtReddit.ReadOnly = true;
            this.txtReddit.Size = new System.Drawing.Size(285, 20);
            this.txtReddit.TabIndex = 7;
            // 
            // btnCopySharecode
            // 
            this.btnCopySharecode.Location = new System.Drawing.Point(371, 6);
            this.btnCopySharecode.Name = "btnCopySharecode";
            this.btnCopySharecode.Size = new System.Drawing.Size(43, 20);
            this.btnCopySharecode.TabIndex = 8;
            this.btnCopySharecode.Text = "Copy";
            this.btnCopySharecode.UseVisualStyleBackColor = true;
            this.btnCopySharecode.Click += new System.EventHandler(this.btnCopySharecode_Click);
            // 
            // btnShareHTML
            // 
            this.btnShareHTML.Location = new System.Drawing.Point(371, 31);
            this.btnShareHTML.Name = "btnShareHTML";
            this.btnShareHTML.Size = new System.Drawing.Size(43, 20);
            this.btnShareHTML.TabIndex = 9;
            this.btnShareHTML.Text = "Copy";
            this.btnShareHTML.UseVisualStyleBackColor = true;
            this.btnShareHTML.Click += new System.EventHandler(this.btnShareHTML_Click);
            // 
            // btnShareBBCode
            // 
            this.btnShareBBCode.Location = new System.Drawing.Point(371, 58);
            this.btnShareBBCode.Name = "btnShareBBCode";
            this.btnShareBBCode.Size = new System.Drawing.Size(43, 20);
            this.btnShareBBCode.TabIndex = 10;
            this.btnShareBBCode.Text = "Copy";
            this.btnShareBBCode.UseVisualStyleBackColor = true;
            this.btnShareBBCode.Click += new System.EventHandler(this.btnShareBBCode_Click);
            // 
            // btnShareReddit
            // 
            this.btnShareReddit.Location = new System.Drawing.Point(371, 83);
            this.btnShareReddit.Name = "btnShareReddit";
            this.btnShareReddit.Size = new System.Drawing.Size(43, 20);
            this.btnShareReddit.TabIndex = 11;
            this.btnShareReddit.Text = "Copy";
            this.btnShareReddit.UseVisualStyleBackColor = true;
            this.btnShareReddit.Click += new System.EventHandler(this.btnShareReddit_Click);
            // 
            // frmShareBuild
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(418, 111);
            this.Controls.Add(this.btnShareReddit);
            this.Controls.Add(this.btnShareBBCode);
            this.Controls.Add(this.btnShareHTML);
            this.Controls.Add(this.btnCopySharecode);
            this.Controls.Add(this.txtReddit);
            this.Controls.Add(this.txtBBCode);
            this.Controls.Add(this.txtHTML);
            this.Controls.Add(this.txtShareCode);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmShareBuild";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Share Build - {0}";
            this.Load += new System.EventHandler(this.frmShareBuild_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtShareCode;
        private System.Windows.Forms.TextBox txtHTML;
        private System.Windows.Forms.TextBox txtBBCode;
        private System.Windows.Forms.TextBox txtReddit;
        private System.Windows.Forms.Button btnCopySharecode;
        private System.Windows.Forms.Button btnShareHTML;
        private System.Windows.Forms.Button btnShareBBCode;
        private System.Windows.Forms.Button btnShareReddit;
    }
}