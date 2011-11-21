using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SC2Scrapbook
{
    public partial class frmImportBuild : Form
    {
        public frmImportBuild(Models.Build build)
        {
            InitializeComponent();

            txtName.Text = build.Name;
            txtScript.Text = build.Script;
            txtNotes.Text = build.Notes;
            pbRace1.Image = Models.Matchup.ImageFromRace(build.Matchup.PlayerRace);
            pbRace2.Image = Models.Matchup.ImageFromRace(build.Matchup.OpponentRace);

            var builds = from x in Program.BuildsDB
                         where x.Guid == build.Guid
                         select x;

            if (builds.Count() != 0)
            {
                if (MessageBox.Show("You already have a build with this ID in your database. Do you want to continue?", "Duplicate?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != System.Windows.Forms.DialogResult.Yes)
                {
                    DialogResult = System.Windows.Forms.DialogResult.Cancel;
                    Close();
                }
            }
        }

        private void frmImportBuild_Load(object sender, EventArgs e)
        {

        }

        private void cmdImport_Click(object sender, EventArgs e)
        {

        }
    }
}
