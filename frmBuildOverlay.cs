using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SC2Scrapbook
{
    public partial class frmBuildOverlay : Form
    {

        private bool m_locked;
        private Models.Build m_build;

        public static frmBuildOverlay Instance { get; set; }

        public frmBuildOverlay(Models.Build build, bool locked = false)
        {
            if (Instance != null)
            {
                Instance.Close();
                Instance = null;
            }
            Instance = this;
            InitializeComponent();
            m_locked = !locked;
            m_build = build;
        }

        public bool Locked
        {
            get
            {
                return m_locked;
            }
            set
            {
                if (m_locked == value)
                    return;

                m_locked = value;

                Win32.SetFormTransparency(this, m_locked);

                if (m_locked)
                {
                    TransparencyKey = BackColor;
                    Opacity = .7;
                    lblFakeTitle.Visible = false;
                }
                else
                {
                    TransparencyKey = Color.Red;
                    Opacity = .5;
                    lblFakeTitle.Visible = true;
                }

                Invalidate();
            }
        }

        private void frmOverlay_Load(object sender, EventArgs e)
        {
            Locked = !m_locked;

            if (!Configuration.Instance.FirstRun)
            {
                Top = Configuration.Instance.OverlayTop;
                Left = Configuration.Instance.OverlayLeft;

                
            }

            Configuration.Instance.FirstRun = false;
        }


        /*
        protected override void WndProc(ref Message m)
        {

            if (m.Msg == (int)0x0084) // WM_NCHITTEST 
            {
                if (!m_locked)
                {
                    m.Result = (IntPtr)(0x2); // HTCAPTION]
                    this.Invalidate();
                }
                else
                {
                    base.WndProc(ref m);
                }
            }
            else
            {
                base.WndProc(ref m);
            }
        }*/


        private void frmOverlay_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
            e.Graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
            if (!m_locked)
            {
                // Left
                e.Graphics.DrawLine(Pens.Black, new Point(0, 0), new Point(0, this.ClientRectangle.Bottom - 2));
                e.Graphics.DrawLine(Pens.Gray, new Point(1, 1), new Point(1, this.ClientRectangle.Bottom - 2));

                // Top
                e.Graphics.DrawLine(Pens.Black, new Point(0, 0), new Point(this.ClientRectangle.Width, 0));
                e.Graphics.DrawLine(Pens.Gray, new Point(1, 1), new Point(this.ClientRectangle.Width - 2, 1));

                // Right
                e.Graphics.DrawLine(Pens.Black, new Point(this.ClientRectangle.Right - 1, 0), new Point(this.ClientRectangle.Right - 1, this.ClientRectangle.Bottom));
                e.Graphics.DrawLine(Pens.Gray, new Point(this.ClientRectangle.Right - 2, 1), new Point(this.ClientRectangle.Right - 2, this.ClientRectangle.Bottom - 2));

                // Bottom
                e.Graphics.DrawLine(Pens.Black, new Point(0, this.ClientRectangle.Bottom - 1), new Point(this.ClientRectangle.Width, this.ClientRectangle.Bottom - 1));
                e.Graphics.DrawLine(Pens.Gray, new Point(1, this.ClientRectangle.Bottom - 2), new Point(this.ClientRectangle.Width - 2, this.ClientRectangle.Bottom - 2));
            }

            FontFamily fontFamily = new FontFamily(Configuration.Instance.OverlayContentFont);
            FontFamily titleFontFamily = new FontFamily(Configuration.Instance.OverlayTitleFont);
            StringFormat strformat = new StringFormat();
            float pos = Configuration.Instance.OverlayTitleSize + Configuration.Instance.OverlayContentSize;
            lblFakeTitle.Height = (int)                Configuration.Instance.OverlayTitleSize;
            GraphicsPath path = new GraphicsPath();
            path.AddString(m_build.Name, fontFamily,
            (int)FontStyle.Regular, Configuration.Instance.OverlayTitleSize, new PointF(0, 0), strformat);
            

            string[] lines = m_build.Script.Split(new string[] { "\r\n" }, StringSplitOptions.None);

            foreach (string line in lines)
            {
                if (line.StartsWith("#"))
                {
                    path.AddString(line.Substring(1), fontFamily,
                (int)FontStyle.Italic, Configuration.Instance.OverlayContentSize, new PointF(0, pos), strformat);
                    pos += Configuration.Instance.OverlayContentSize + 2;
                }
                else if (line.StartsWith("*"))
                {
                    path.AddString(line.Substring(1), fontFamily,
                (int)FontStyle.Bold, Configuration.Instance.OverlayContentSize, new PointF(0, pos), strformat);
                    pos += Configuration.Instance.OverlayContentSize + 2;
                }
                else
                {
                    path.AddString(line, fontFamily,
                (int)FontStyle.Regular, Configuration.Instance.OverlayContentSize, new PointF(0, pos), strformat);
                    pos += Configuration.Instance.OverlayContentSize + 2;
                }
            }

            pos += Configuration.Instance.OverlayContentSize;

            for (int i = 0; i < Configuration.Instance.OverlayTextOutlineSize; ++i)
            {
                Pen pen = new Pen(Configuration.Instance.OverlayTextOutlineColour, i + 1);
                pen.LineJoin = LineJoin.Round;
                e.Graphics.DrawPath(pen, path);
                pen.Dispose();
            }

            SolidBrush brush = new SolidBrush(Configuration.Instance.OverlayTextColour);
            e.Graphics.FillPath(brush, path);


            RectangleF bounds = path.GetBounds();
            this.Height = (int)bounds.Height + (int)bounds.Y + (int)bounds.Top + 6;
            this.Width = (int)bounds.Width + (int)bounds.X + (int)bounds.Left + 6;

            path.Dispose();
            fontFamily.Dispose();
            brush.Dispose();
            e.Graphics.Dispose();

            
        }

        private void frmOverlay_MouseMove(object sender, MouseEventArgs e)
        {
            System.Diagnostics.Debug.WriteLine(e.ToString());
        }

        private void frmOverlay_DoubleClick(object sender, EventArgs e)
        {
            Locked = !Locked;
        }

        private void lblFakeTitle_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                Win32.ReleaseCapture();
                Win32.SendMessage(Handle, Win32.WM_NCLBUTTONDOWN,Win32.HT_CAPTION, 0);
            }
        }

        private void frmOverlay_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Right)
            {
                Close();
            }
        }

        private void frmOverlay_FormClosed(object sender, FormClosedEventArgs e)
        {
            frmBuildOverlay.Instance = null;
        }

        private void frmOverlay_FormClosing(object sender, FormClosingEventArgs e)
        {
            Configuration.Instance.OverlayLeft = Left;
            Configuration.Instance.OverlayTop = Top;

            Program.SaveConfigurationXML();
        }


        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams p = base.CreateParams;


                p.ExStyle |= (0x08000000);

                return p;
            }
        }
    }
}
