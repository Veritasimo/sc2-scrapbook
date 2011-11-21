using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using EXControls;

namespace SC2Scrapbook
{
    public partial class frmIngameBuildSelection : Form
    {

        public Models.Matchup.Races _myRace;
        public Models.Matchup.Races _opponentRace;

        public frmIngameBuildSelection()
        {
            InitializeComponent();
        }

        void SelectRace(Models.Matchup.Races race) {
            _myRace = race;
            pnlSelectRace.Visible = false;
            pnlOpponentRace.Visible = true;

            lblStatus.Text = "Select Opponent's Race";

        }

        void SelectOpponentRace(Models.Matchup.Races race)
        {
            _opponentRace = race;
            pnlSelectRace.Visible = false;
            pnlOpponentRace.Visible = false;
            pnlBuilds.Visible = !Configuration.Instance.SelectRandomBuild;
            lblStatus.Text = "Select Build Order";

            PopulateBuilds();
        }


        private void lblStatus_Click(object sender, EventArgs e)
        {

        }


        private void pbTheirTerran_Click(object sender, EventArgs e)
        {
            SelectOpponentRace(Models.Matchup.Races.Terran);
        }

        private void pbTheirZerg_Click(object sender, EventArgs e)
        {
            SelectOpponentRace(Models.Matchup.Races.Zerg);
        }

        private void pbTheirProtoss_Click(object sender, EventArgs e)
        {
            SelectOpponentRace(Models.Matchup.Races.Protoss);
        }

        private void pbTheirRandom_Click(object sender, EventArgs e)
        {
            SelectOpponentRace(Models.Matchup.Races.Random);
        }

        private void pbMyTerran_Click(object sender, EventArgs e)
        {
            SelectRace(Models.Matchup.Races.Terran);
        }

        private void pbMyProtoss_Click(object sender, EventArgs e)
        {
            SelectRace(Models.Matchup.Races.Protoss);
        }

        private void pbMyZerg_Click(object sender, EventArgs e)
        {
            SelectRace(Models.Matchup.Races.Zerg);
        }


        public void PopulateBuilds()
        {
            
            var builds = from x in Program.BuildsDB
                         where(x.Matchup.PlayerRace == _myRace)
                         select x;

            if (Configuration.Instance.AllowVsXBuilds)
                builds = builds.Where(build => build.Matchup.OpponentRace == _opponentRace || build.Matchup.OpponentRace == Models.Matchup.Races.Random);
            else
                builds = builds.Where(build => build.Matchup.OpponentRace == _opponentRace);

            if (Configuration.Instance.SelectRandomBuild)
            {
                Models.Build build = builds.Skip(new Random().Next(builds.Count())).FirstOrDefault();
                frmBuildOverlay overlay = new frmBuildOverlay(build, true);
                overlay.Show();

                Hide();
            }
            else
            {
                lvBuilds.Items.Clear();

                foreach (var build in builds)
                {
                    EXListViewItem item = new EXImageListViewItem(build.Name, Models.Matchup.ImageFromRace(build.Matchup.PlayerRace));
                    item.Tag = build;

                    item.SubItems.Add(
                        new EXControls.EXListViewSubItem(build.Matchup.ToString())
                    );

                    lvBuilds.Items.Add(item);
                }

                lvBuilds.Sort();
            }
        }

        private void lvBuilds_DoubleClick(object sender, EventArgs e)
        {
            foreach (EXListViewItem item in lvBuilds.Items)
            {
                if (item.Selected)
                {
                    if (frmBuildOverlay.Instance != null)
                        frmBuildOverlay.Instance.Close();

                    frmBuildOverlay overlay = new frmBuildOverlay((Models.Build)item.Tag, true);
                    overlay.Show();

                    Hide();
                }
            }

            
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void lvBuilds_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void pnlBuilds_Paint(object sender, PaintEventArgs e)
        {

        }

        private void raceSelectMouseEnter(object sender, EventArgs e)
        {
            ((PictureBox)sender).BackColor = SystemColors.Control;
        }

        private void raceSelectMouseLeave(object sender, EventArgs e)
        {
            ((PictureBox)sender).BackColor = Color.White;
        }

        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams p = base.CreateParams;


                p.ExStyle |= (0x08000000 | 8);

                return p;
            }
        }

    }
}
