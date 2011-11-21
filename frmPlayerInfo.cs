using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Drawing2D;

namespace SC2Scrapbook
{
    public partial class frmPlayerInfo : Form
    {
        public FormAnimator Animator{get;private set;}
        private Models.Player _player;

        public static frmPlayerInfo Instance { get; private set; }

        public frmPlayerInfo(Models.Player player)
        {
            if (Instance != null)
            {
                Instance.Close();
                Instance = null;
            }

            Instance = this;

            int baseWidth = 154;
            int baseHeight = 113;
            int baseX = 252;
            int baseY = 594;

            double xPercentage = (double)baseX / 1280 * 100;
            double yPercentage =  (double)baseY / 720 * 100;
            double widthPercentage = (double)baseWidth / 1280 * 100;
            double heightPercentage = (double)baseHeight / 720 * 100;

            double yScale = Program.SC2WindowRect.Height / 720;
            double xScale = Program.SC2WindowRect.Width / 1280;


            InitializeComponent();



            Animator = new FormAnimator(this, FormAnimator.AnimationMethod.Slide, FormAnimator.AnimationDirection.Right, 1000);

            this.Left = (int)(Program.SC2WindowRect.Left + ((double)Program.SC2WindowRect.Width / 100 * xPercentage));
            this.Top = (int)(Program.SC2WindowRect.Top + ((double)Program.SC2WindowRect.Height / 100 * yPercentage));
            this.Height = (int)((double)Program.SC2WindowRect.Height / 100 * heightPercentage);
            this.Width = (int)((double)Program.SC2WindowRect.Width / 100 * widthPercentage);

            _player = player;

            if (Configuration.Instance.OpponentInfoOverlayTimeout > 0)
            {
                tmrClose.Interval = Configuration.Instance.OpponentInfoOverlayTimeout * 1000;
                tmrClose.Start();
            }
        }

        private void frmPlayerInfo_Load(object sender, EventArgs e)
        {

        }

        public void ShowNoActivate()
        {
            if (InvokeRequired)
            {
                BeginInvoke(new Action(delegate()
                {
                    ShowNoActivate();
                }));
            }
            else
            {
                Animator.Direction = FormAnimator.AnimationDirection.Right;
                Win32.ShowWindow(this.Handle, Win32.ShowWindowCommands.ShowNoActivate);
            }
        }

        public void HideWindow()
        {
            if (InvokeRequired)
            {
                BeginInvoke(new Action(delegate()
                {
                    HideWindow();
                }));
            }
            else
            {
                Animator.Direction = FormAnimator.AnimationDirection.Left;
                Win32.ShowWindow(this.Handle, Win32.ShowWindowCommands.Hide);
            } 
        }

        internal static Rectangle DrawLeagueImage(System.Drawing.Graphics g, Models.Player.Leagues league, int place, int size, int x, int y, double xScale, double yScale)
        {
            
            int srcHeight = 0;
            int srcWidth = 0;
            int srcX = 0;
            int srcY = 0;
            int modifier = 1;

            if (size == 1)
            {
                srcHeight = 25;
                srcWidth = 25;
                srcX = 145;
            }
            else if (size == 2)
            {
                srcHeight = 45;
                srcWidth = 45;
                srcX = 100;
            }
            else
            {
                srcHeight = 100;
                srcWidth = 100;
                srcX = 0;
            }

            if (league == Models.Player.Leagues.Grandmaster)
                modifier = 2;

            if (place <= (8 * modifier))
            {
                srcY = (srcHeight + 5) * 3;
                srcHeight += 5;

            }
            else if (place <= (25 * modifier))
            {
                srcY = (srcHeight + 5) * 2;
            }
            else if (place <= (50 * modifier))
            {
                srcY = (srcHeight + 5) * 1;
            }
            else if (place <= (100 * modifier))
            {
                srcY = 0;
            }

            Bitmap image = null;

            switch (league)
            {
                case Models.Player.Leagues.Bronze:
                    image = Properties.Resources.bronze;
                    break;
                case Models.Player.Leagues.Silver:
                    image = Properties.Resources.silver;
                    break;
                case Models.Player.Leagues.Gold:
                    image = Properties.Resources.gold;
                    break;
                case Models.Player.Leagues.Platinum:
                    image = Properties.Resources.platinum;
                    break;
                case Models.Player.Leagues.Diamond:
                    image = Properties.Resources.diamond;
                    break;
                case Models.Player.Leagues.Master:
                    image = Properties.Resources.master;
                    break;
                case Models.Player.Leagues.Grandmaster:
                    image = Properties.Resources.grandmaster;
                    break;
                default:
                    image = Properties.Resources.none;
                    break;
            }

            Rectangle destination = new Rectangle(x, y, (int)((srcWidth * 0.6) * xScale), (int)((srcHeight * 0.6) * yScale));
            g.DrawImage(image, destination, srcX, srcY, srcWidth, srcHeight, GraphicsUnit.Pixel);

            return destination;

        }

        internal static Rectangle DrawPortrait(System.Drawing.Graphics g, Models.Player.PortraitData p, int x, int y, double xScale, double yScale)
        {
            // Creating a full scale image of the portrait in the frame is necessary to avoid a scaling clusterfuck.
            Image newPortrait = new Bitmap(105, 101);
            Graphics newGraphics = Graphics.FromImage(newPortrait);

            if (p == null || !System.IO.File.Exists(p.Filename))
                newGraphics.DrawImage(Properties.Resources.defaultportrait, 7, 5);
            else
            {
                try
                {
                    Image image = Bitmap.FromFile(p.Filename);
                    newGraphics.DrawImage(image, new Rectangle(7, 5, 90, 90), p.Position.X, p.Position.Y, p.Position.Width, p.Position.Height, GraphicsUnit.Pixel);
                    image.Dispose();
                }
                catch
                {
                    newGraphics.DrawImage(Properties.Resources.defaultportrait, 7, 5);
                }
            }

            newGraphics.DrawImage(Properties.Resources.portrait_summary, 0, 0);

            Rectangle destination = new Rectangle(x, y, (int)((newPortrait.Width * 0.6) * xScale), (int)((newPortrait.Height * 0.6) * yScale));
            g.DrawImage(newPortrait, destination, 0, 0, newPortrait.Width, newPortrait.Height, GraphicsUnit.Pixel);

            newGraphics.Dispose();
            newPortrait.Dispose();

            return destination;
        }

        private void frmPlayerInfo_Paint(object sender, PaintEventArgs e)
        {


            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
            e.Graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
            e.Graphics.TextRenderingHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;

            System.Drawing.Imaging.ColorMatrix attrMatrix = new System.Drawing.Imaging.ColorMatrix();
            attrMatrix.Matrix33 = 0.5f;
            System.Drawing.Imaging.ImageAttributes attr = new System.Drawing.Imaging.ImageAttributes();
            attr.SetColorMatrix(attrMatrix, System.Drawing.Imaging.ColorMatrixFlag.Default, System.Drawing.Imaging.ColorAdjustType.Bitmap);
            
            
            if (_player == null)
            {
                Image raceSnapshot = Models.Matchup.SnapshotImageFromRace(Models.Matchup.Races.Random);
                e.Graphics.DrawImage(raceSnapshot, new Rectangle(0, 0, Width, Height), 0, 0, raceSnapshot.Width, raceSnapshot.Height, GraphicsUnit.Pixel, attr);

                e.Graphics.DrawString(string.Format("Custom Game Hero"), new Font("Arial", (float)(12 * Program.yScale), FontStyle.Regular, GraphicsUnit.Pixel), new SolidBrush(ColorTranslator.FromHtml("#47c5ff")), 20, 20);
                
            }
            else
            {
                Image raceSnapshot = Models.Matchup.SnapshotImageFromRace(_player.Race);
                e.Graphics.DrawImage(raceSnapshot, new Rectangle(0, 0, Width, Height), 0, 0, raceSnapshot.Width, raceSnapshot.Height, GraphicsUnit.Pixel, attr);

                Rectangle portrait = DrawPortrait(e.Graphics, _player.Portrait, 0, 0, Program.xScale > 1 ? 1 : Program.xScale, Program.yScale > 1 ? 1 : Program.yScale);
                int fontSize = 24;
                int availablespace = Width - (portrait.Width + 4);
                Font font = new Font("Arial", (float)((fontSize * 0.6) * Program.yScale), FontStyle.Bold, GraphicsUnit.Pixel);
                SizeF size;
                while ((size = e.Graphics.MeasureString(_player.Name, font)).Width > availablespace)
                {
                    fontSize -= 1;
                    font = new Font("Arial", (float)((fontSize * 0.6) * Program.yScale), FontStyle.Bold, GraphicsUnit.Pixel);
                }

                e.Graphics.DrawString(_player.Name, font, new SolidBrush(ColorTranslator.FromHtml("#47c5ff")), portrait.Width + 4, 12);

                int verticalSpace = Height - portrait.Height;
                Rectangle icon = DrawLeagueImage(e.Graphics, _player.League, _player.Place, 2, portrait.Width + 4, (int)(size.Height + 16 * Program.yScale), Program.xScale, Program.yScale);
                if (_player.Place > 0)
                {
                    e.Graphics.DrawString(string.Format("#{0}", _player.Place), new Font("Arial", icon.Height / 2, FontStyle.Regular, GraphicsUnit.Pixel), new SolidBrush(ColorTranslator.FromHtml("#47c5ff")), icon.Left + icon.Width + (int)(4 * Program.xScale), icon.Top + icon.Height - (icon.Height / 2) - 6);
                    if (_player.Points > -1)
                    {
                        e.Graphics.DrawString("P", new Font("Arial", icon.Height / 2, FontStyle.Bold, GraphicsUnit.Pixel), new SolidBrush(ColorTranslator.FromHtml("#47c5ff")), icon.Left + (icon.Width / 2), icon.Top + icon.Height);
                        e.Graphics.DrawString(string.Format("{0}", _player.Points), new Font("Arial", icon.Height / 2, FontStyle.Regular, GraphicsUnit.Pixel), new SolidBrush(ColorTranslator.FromHtml("#47c5ff")), icon.Left + icon.Width + (int)(4 * Program.xScale), icon.Top + icon.Height);

                        e.Graphics.DrawString("W", new Font("Arial", icon.Height / 2, FontStyle.Bold, GraphicsUnit.Pixel), new SolidBrush(ColorTranslator.FromHtml("#47c5ff")), icon.Left + (icon.Width / 2), icon.Top + icon.Height + (icon.Height / 2));
                        e.Graphics.DrawString(string.Format("{0}", _player.Wins), new Font("Arial", icon.Height / 2, FontStyle.Regular, GraphicsUnit.Pixel), new SolidBrush(ColorTranslator.FromHtml("#47c5ff")), icon.Left + icon.Width + (int)(4 * Program.xScale), icon.Top + icon.Height + (icon.Height / 2));

                        if (_player.Losses > -1)
                        {
                            e.Graphics.DrawString("L", new Font("Arial", icon.Height / 2, FontStyle.Bold, GraphicsUnit.Pixel), new SolidBrush(ColorTranslator.FromHtml("#47c5ff")), icon.Left + (icon.Width / 2), icon.Top + icon.Height + ((icon.Height / 2) * 2));
                            e.Graphics.DrawString(string.Format("{0}", _player.Losses), new Font("Arial", icon.Height / 2, FontStyle.Regular, GraphicsUnit.Pixel), new SolidBrush(ColorTranslator.FromHtml("#47c5ff")), icon.Left + icon.Width + (int)(4 * Program.xScale), icon.Top + icon.Height + ((icon.Height / 2) * 2));

                        }
                    }
                }
                
            }
        }

        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams p = base.CreateParams;


                p.ExStyle |= (0x08000000 | 8 | Win32.WS_EX_LAYERED);

                return p;
            }
        }

        private void frmPlayerInfo_Shown(object sender, EventArgs e)
        {
            Win32.SetFormTransparency(this, true);
            this.TransparencyKey = this.BackColor;
        }

        private void frmPlayerInfo_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (Instance == this)
                Instance = null;
        }

        private void tmrClose_Tick(object sender, EventArgs e)
        {
            tmrClose.Stop();
            Close();
        }


    }
}
