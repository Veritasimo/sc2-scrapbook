namespace SC2Scrapbook
{
    partial class frmIngameBuildSelection
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmIngameBuildSelection));
            this.lblStatus = new System.Windows.Forms.Label();
            this.pnlSelectRace = new System.Windows.Forms.Panel();
            this.pbMyProtoss = new System.Windows.Forms.PictureBox();
            this.pbMyZerg = new System.Windows.Forms.PictureBox();
            this.pbMyTerran = new System.Windows.Forms.PictureBox();
            this.pnlOpponentRace = new System.Windows.Forms.Panel();
            this.pbTheirRandom = new System.Windows.Forms.PictureBox();
            this.pbTheirProtoss = new System.Windows.Forms.PictureBox();
            this.pbTheirZerg = new System.Windows.Forms.PictureBox();
            this.pbTheirTerran = new System.Windows.Forms.PictureBox();
            this.pnlBuilds = new System.Windows.Forms.Panel();
            this.lvBuilds = new EXControls.EXListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.lvchBuild = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.lvchMatchup = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.btnClose = new System.Windows.Forms.Button();
            this.pnlSelectRace.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbMyProtoss)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbMyZerg)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbMyTerran)).BeginInit();
            this.pnlOpponentRace.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbTheirRandom)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbTheirProtoss)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbTheirZerg)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbTheirTerran)).BeginInit();
            this.pnlBuilds.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblStatus
            // 
            this.lblStatus.BackColor = System.Drawing.Color.Transparent;
            this.lblStatus.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblStatus.Font = new System.Drawing.Font("Arial", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStatus.ForeColor = System.Drawing.Color.Red;
            this.lblStatus.Location = new System.Drawing.Point(0, 0);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(460, 37);
            this.lblStatus.TabIndex = 0;
            this.lblStatus.Text = "SELECT YOUR RACE";
            this.lblStatus.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.lblStatus.Click += new System.EventHandler(this.lblStatus_Click);
            // 
            // pnlSelectRace
            // 
            this.pnlSelectRace.Controls.Add(this.pbMyProtoss);
            this.pnlSelectRace.Controls.Add(this.pbMyZerg);
            this.pnlSelectRace.Controls.Add(this.pbMyTerran);
            this.pnlSelectRace.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlSelectRace.Location = new System.Drawing.Point(0, 37);
            this.pnlSelectRace.Name = "pnlSelectRace";
            this.pnlSelectRace.Size = new System.Drawing.Size(460, 176);
            this.pnlSelectRace.TabIndex = 1;
            // 
            // pbMyProtoss
            // 
            this.pbMyProtoss.BackColor = System.Drawing.Color.White;
            this.pbMyProtoss.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pbMyProtoss.Image = global::SC2Scrapbook.Properties.Resources.ProtossIcon;
            this.pbMyProtoss.Location = new System.Drawing.Point(318, 17);
            this.pbMyProtoss.Name = "pbMyProtoss";
            this.pbMyProtoss.Size = new System.Drawing.Size(130, 130);
            this.pbMyProtoss.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbMyProtoss.TabIndex = 2;
            this.pbMyProtoss.TabStop = false;
            this.pbMyProtoss.Click += new System.EventHandler(this.pbMyProtoss_Click);
            this.pbMyProtoss.MouseEnter += new System.EventHandler(this.raceSelectMouseEnter);
            this.pbMyProtoss.MouseLeave += new System.EventHandler(this.raceSelectMouseLeave);
            // 
            // pbMyZerg
            // 
            this.pbMyZerg.BackColor = System.Drawing.Color.White;
            this.pbMyZerg.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pbMyZerg.Image = global::SC2Scrapbook.Properties.Resources.zergicon;
            this.pbMyZerg.Location = new System.Drawing.Point(165, 17);
            this.pbMyZerg.Name = "pbMyZerg";
            this.pbMyZerg.Size = new System.Drawing.Size(130, 130);
            this.pbMyZerg.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbMyZerg.TabIndex = 1;
            this.pbMyZerg.TabStop = false;
            this.pbMyZerg.Click += new System.EventHandler(this.pbMyZerg_Click);
            this.pbMyZerg.MouseEnter += new System.EventHandler(this.raceSelectMouseEnter);
            this.pbMyZerg.MouseLeave += new System.EventHandler(this.raceSelectMouseLeave);
            // 
            // pbMyTerran
            // 
            this.pbMyTerran.BackColor = System.Drawing.Color.White;
            this.pbMyTerran.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pbMyTerran.Image = global::SC2Scrapbook.Properties.Resources.TerranIcon;
            this.pbMyTerran.Location = new System.Drawing.Point(12, 17);
            this.pbMyTerran.Name = "pbMyTerran";
            this.pbMyTerran.Size = new System.Drawing.Size(130, 130);
            this.pbMyTerran.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbMyTerran.TabIndex = 0;
            this.pbMyTerran.TabStop = false;
            this.pbMyTerran.Click += new System.EventHandler(this.pbMyTerran_Click);
            this.pbMyTerran.MouseEnter += new System.EventHandler(this.raceSelectMouseEnter);
            this.pbMyTerran.MouseLeave += new System.EventHandler(this.raceSelectMouseLeave);
            // 
            // pnlOpponentRace
            // 
            this.pnlOpponentRace.Controls.Add(this.pbTheirRandom);
            this.pnlOpponentRace.Controls.Add(this.pbTheirProtoss);
            this.pnlOpponentRace.Controls.Add(this.pbTheirZerg);
            this.pnlOpponentRace.Controls.Add(this.pbTheirTerran);
            this.pnlOpponentRace.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlOpponentRace.Location = new System.Drawing.Point(0, 37);
            this.pnlOpponentRace.Name = "pnlOpponentRace";
            this.pnlOpponentRace.Size = new System.Drawing.Size(460, 176);
            this.pnlOpponentRace.TabIndex = 2;
            this.pnlOpponentRace.Visible = false;
            // 
            // pbTheirRandom
            // 
            this.pbTheirRandom.BackColor = System.Drawing.Color.White;
            this.pbTheirRandom.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pbTheirRandom.Image = global::SC2Scrapbook.Properties.Resources.RandomIcon;
            this.pbTheirRandom.Location = new System.Drawing.Point(340, 34);
            this.pbTheirRandom.Name = "pbTheirRandom";
            this.pbTheirRandom.Size = new System.Drawing.Size(100, 100);
            this.pbTheirRandom.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbTheirRandom.TabIndex = 3;
            this.pbTheirRandom.TabStop = false;
            this.pbTheirRandom.Click += new System.EventHandler(this.pbTheirRandom_Click);
            this.pbTheirRandom.MouseEnter += new System.EventHandler(this.raceSelectMouseEnter);
            this.pbTheirRandom.MouseLeave += new System.EventHandler(this.raceSelectMouseLeave);
            // 
            // pbTheirProtoss
            // 
            this.pbTheirProtoss.BackColor = System.Drawing.Color.White;
            this.pbTheirProtoss.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pbTheirProtoss.Image = global::SC2Scrapbook.Properties.Resources.ProtossIcon;
            this.pbTheirProtoss.Location = new System.Drawing.Point(231, 34);
            this.pbTheirProtoss.Name = "pbTheirProtoss";
            this.pbTheirProtoss.Size = new System.Drawing.Size(100, 100);
            this.pbTheirProtoss.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbTheirProtoss.TabIndex = 2;
            this.pbTheirProtoss.TabStop = false;
            this.pbTheirProtoss.Click += new System.EventHandler(this.pbTheirProtoss_Click);
            this.pbTheirProtoss.MouseEnter += new System.EventHandler(this.raceSelectMouseEnter);
            this.pbTheirProtoss.MouseLeave += new System.EventHandler(this.raceSelectMouseLeave);
            // 
            // pbTheirZerg
            // 
            this.pbTheirZerg.BackColor = System.Drawing.Color.White;
            this.pbTheirZerg.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pbTheirZerg.Image = global::SC2Scrapbook.Properties.Resources.zergicon;
            this.pbTheirZerg.Location = new System.Drawing.Point(123, 34);
            this.pbTheirZerg.Name = "pbTheirZerg";
            this.pbTheirZerg.Size = new System.Drawing.Size(100, 100);
            this.pbTheirZerg.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbTheirZerg.TabIndex = 1;
            this.pbTheirZerg.TabStop = false;
            this.pbTheirZerg.Click += new System.EventHandler(this.pbTheirZerg_Click);
            this.pbTheirZerg.MouseEnter += new System.EventHandler(this.raceSelectMouseEnter);
            this.pbTheirZerg.MouseLeave += new System.EventHandler(this.raceSelectMouseLeave);
            // 
            // pbTheirTerran
            // 
            this.pbTheirTerran.BackColor = System.Drawing.Color.White;
            this.pbTheirTerran.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pbTheirTerran.Image = global::SC2Scrapbook.Properties.Resources.TerranIcon;
            this.pbTheirTerran.Location = new System.Drawing.Point(14, 34);
            this.pbTheirTerran.Name = "pbTheirTerran";
            this.pbTheirTerran.Size = new System.Drawing.Size(100, 100);
            this.pbTheirTerran.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbTheirTerran.TabIndex = 0;
            this.pbTheirTerran.TabStop = false;
            this.pbTheirTerran.Click += new System.EventHandler(this.pbTheirTerran_Click);
            this.pbTheirTerran.MouseEnter += new System.EventHandler(this.raceSelectMouseEnter);
            this.pbTheirTerran.MouseLeave += new System.EventHandler(this.raceSelectMouseLeave);
            // 
            // pnlBuilds
            // 
            this.pnlBuilds.Controls.Add(this.lvBuilds);
            this.pnlBuilds.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlBuilds.Location = new System.Drawing.Point(0, 37);
            this.pnlBuilds.Name = "pnlBuilds";
            this.pnlBuilds.Size = new System.Drawing.Size(460, 176);
            this.pnlBuilds.TabIndex = 3;
            this.pnlBuilds.Visible = false;
            this.pnlBuilds.Paint += new System.Windows.Forms.PaintEventHandler(this.pnlBuilds_Paint);
            // 
            // lvBuilds
            // 
            this.lvBuilds.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2});
            this.lvBuilds.ControlPadding = 4;
            this.lvBuilds.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvBuilds.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lvBuilds.FullRowSelect = true;
            this.lvBuilds.Location = new System.Drawing.Point(0, 0);
            this.lvBuilds.MultiSelect = false;
            this.lvBuilds.Name = "lvBuilds";
            this.lvBuilds.OwnerDraw = true;
            this.lvBuilds.Size = new System.Drawing.Size(460, 176);
            this.lvBuilds.TabIndex = 4;
            this.lvBuilds.UseCompatibleStateImageBehavior = false;
            this.lvBuilds.View = System.Windows.Forms.View.Details;
            this.lvBuilds.DoubleClick += new System.EventHandler(this.lvBuilds_DoubleClick);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Build";
            this.columnHeader1.Width = 351;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Matchup";
            this.columnHeader2.Width = 87;
            // 
            // lvchBuild
            // 
            this.lvchBuild.Text = "Build";
            this.lvchBuild.Width = 351;
            // 
            // lvchMatchup
            // 
            this.lvchMatchup.Text = "Matchup";
            this.lvchMatchup.Width = 87;
            // 
            // btnClose
            // 
            this.btnClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.Location = new System.Drawing.Point(418, 8);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(30, 23);
            this.btnClose.TabIndex = 4;
            this.btnClose.Text = "X";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // frmIngameBuildSelection
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(460, 213);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.pnlBuilds);
            this.Controls.Add(this.pnlOpponentRace);
            this.Controls.Add(this.pnlSelectRace);
            this.Controls.Add(this.lblStatus);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmIngameBuildSelection";
            this.Opacity = 0.5D;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "In-game BO Selection";
            this.TopMost = true;
            this.TransparencyKey = System.Drawing.SystemColors.Control;
            this.pnlSelectRace.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbMyProtoss)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbMyZerg)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbMyTerran)).EndInit();
            this.pnlOpponentRace.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbTheirRandom)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbTheirProtoss)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbTheirZerg)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbTheirTerran)).EndInit();
            this.pnlBuilds.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.Panel pnlSelectRace;
        private System.Windows.Forms.PictureBox pbMyTerran;
        private System.Windows.Forms.PictureBox pbMyProtoss;
        private System.Windows.Forms.PictureBox pbMyZerg;
        private System.Windows.Forms.Panel pnlOpponentRace;
        private System.Windows.Forms.PictureBox pbTheirProtoss;
        private System.Windows.Forms.PictureBox pbTheirZerg;
        private System.Windows.Forms.PictureBox pbTheirTerran;
        private System.Windows.Forms.PictureBox pbTheirRandom;
        private System.Windows.Forms.Panel pnlBuilds;
        private System.Windows.Forms.ColumnHeader lvchBuild;
        private System.Windows.Forms.ColumnHeader lvchMatchup;
        private System.Windows.Forms.Button btnClose;
        private EXControls.EXListView lvBuilds;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
    }
}