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
    public partial class frmSplash : Form
    {
        public static frmSplash Instance { get; private set; }

        public frmSplash()
        {
            Instance = this;
            InitializeComponent();
        }

        public static void ShowSplash()
        {
            if (Instance != null)
                CloseSplash();

            System.Threading.Thread thread = new System.Threading.Thread(new System.Threading.ThreadStart(delegate() {
                Application.Run(new frmSplash());
            }));
            thread.Start();

        }

        public static void CloseSplash()
        {
            if (Instance == null)
                return;

            Instance.Invoke(new Action(delegate() { 
                Instance.Close();
                Instance.Dispose();
            }));
            Instance.Dispose();
            Instance = null;
        }

        private void frmSplash_Load(object sender, EventArgs e)
        {
            System.Version version = System.Reflection.Assembly.GetExecutingAssembly().GetName().Version;

            lblVersion.Text = string.Format(lblVersion.Text, version.Major, version.Minor);

            Image image = new Bitmap(420, 45);
            Graphics g = Graphics.FromImage(image);

            g.DrawImage(Properties.Resources.bronze, new Rectangle(0, 0, 45, 45), 100, 150, 45, 45, GraphicsUnit.Pixel);
            g.DrawImage(Properties.Resources.silver, new Rectangle(60, 0, 45, 45), 100, 150, 45, 45, GraphicsUnit.Pixel);
            g.DrawImage(Properties.Resources.gold, new Rectangle(120, 0, 45, 45), 100, 150, 45, 45, GraphicsUnit.Pixel);
            g.DrawImage(Properties.Resources.platinum, new Rectangle(180, 0, 45, 45), 100, 150, 45, 45, GraphicsUnit.Pixel);
            g.DrawImage(Properties.Resources.diamond, new Rectangle(240, 0, 45, 45), 100, 150, 45, 45, GraphicsUnit.Pixel);
            g.DrawImage(Properties.Resources.master, new Rectangle(300, 0, 45, 45), 100, 150, 45, 45, GraphicsUnit.Pixel);
            g.DrawImage(Properties.Resources.grandmaster, new Rectangle(360, 0, 45, 45), 100, 150, 45, 45, GraphicsUnit.Pixel);

            g.Dispose();

            pnlLeagues.BackgroundImage = image;
        }
    }
}
