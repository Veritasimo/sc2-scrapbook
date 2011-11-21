using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace SC2Scrapbook
{
    public partial class frmBuildOverlay : Form
    {
        private static Dictionary<string, System.Drawing.Image> m_map;

        private bool m_locked;
        private Models.Build m_build;

        public static readonly string[] RaceVariantIcons = { "gas", "minerals", "supply", "time" };
        public static Dictionary<string, System.Drawing.Image> IconMap
        {
            get
            {
                if (m_map == null)
                    m_map = new Dictionary<string, Image> { 
                        { "random", Properties.Resources.random },
                        { "protoss", Properties.Resources.protoss },
                        { "protoss_minerals", Properties.Resources.protoss_minerals },
                        { "protoss_gas", Properties.Resources.protoss_gas },
                        { "protoss_supply", Properties.Resources.protoss_supply },
                        { "protoss_time", Properties.Resources.protoss_time }, 
                        { "terran", Properties.Resources.terran },
                        { "terran_minerals", Properties.Resources.terran_minerals },
                        { "terran_gas", Properties.Resources.terran_gas },
                        { "terran_supply", Properties.Resources.terran_supply },
                        { "terran_time", Properties.Resources.terran_time }, 
                        { "zerg", Properties.Resources.zerg },
                        { "zerg_minerals", Properties.Resources.zerg_minerals },
                        { "zerg_gas", Properties.Resources.zerg_gas },
                        { "zerg_supply", Properties.Resources.zerg_supply },
                        { "zerg_time", Properties.Resources.zerg_time }, 
                    };

                return m_map;
            }
        }

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
                    //BackColor = Color.Fuchsia;
                    TransparencyKey = BackColor;
                    Opacity = .7;
                    lblFakeTitle.Visible = false;
                }
                else
                {
                    //BackColor = Color.DimGray;
                    TransparencyKey = Color.Red;
                    Opacity = .5;
                    lblFakeTitle.Visible = true;
                }

                Invalidate(this.ClientRectangle);
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

            List<object[]> images = new List<object[]>();
            FontFamily fontFamily = new FontFamily(Configuration.Instance.OverlayContentFont);
            
            FontFamily titleFontFamily = new FontFamily(Configuration.Instance.OverlayTitleFont);
            StringFormat strformat = new StringFormat(StringFormatFlags.MeasureTrailingSpaces | StringFormatFlags.NoClip | StringFormatFlags.NoWrap);
            float pos = Configuration.Instance.OverlayTitleSize + Configuration.Instance.OverlayContentSize;
            lblFakeTitle.Height = (int)                Configuration.Instance.OverlayTitleSize;
            GraphicsPath path = new GraphicsPath();
            
            path.AddString(m_build.Name, fontFamily,
            (int)FontStyle.Regular, Configuration.Instance.OverlayTitleSize, new PointF(0, 0), strformat);
            

            string[] lines = m_build.Script.Split(new string[] { "\r\n" }, StringSplitOptions.None);
            Regex regex = new Regex(@"\{([a-zA-Z0-9_]+)\}");
            for (int i=0; i <lines.Length;i++)
            {
                float x = 0;
                string line = lines[i];
                FontStyle modifier = FontStyle.Regular;

                if (line.StartsWith("#"))
                {
                    line = line.Substring(1);
                    modifier = FontStyle.Italic;
                }
                else if (line.StartsWith("*"))
                {
                    line = line.Substring(1);
                    modifier = FontStyle.Bold;
                }


                GraphicsPath tempPath = new GraphicsPath();
                
                Match match = null;
                while ((match = regex.Match(line)).Success)
                {
                   
                    string iconCode = match.Groups[1].Value.ToLower().Trim();
                    if (RaceVariantIcons.Contains(iconCode))
                    {
                        string raceVariantIcon = string.Format("{0}_{1}", Models.Matchup.StringFromRace(m_build.Matchup.PlayerRace).ToLower(), iconCode);
                        if (IconMap.ContainsKey(raceVariantIcon))
                            iconCode = raceVariantIcon;
                    }
                    

                    
                    string prefix = line.Substring(0, match.Index);
                    line = line.Substring(match.Index + match.Length);


                    if (!IconMap.ContainsKey(iconCode))
                    {
                        string output = string.Format(@"{0}\{\{{1}\}\}", prefix, iconCode);
                        tempPath.AddString(output, fontFamily, (int)modifier, Configuration.Instance.OverlayContentSize, new PointF(0, 0), strformat);

                        path.AddString(output, fontFamily, (int)modifier, Configuration.Instance.OverlayContentSize, new PointF(x, pos), strformat);
                        RectangleF size = tempPath.GetBounds();

                        x += x += size.X + size.Width + size.Left;
                        tempPath.Reset();
                    }
                    else
                    {
                        // It refuses to measure whitespace.
                        tempPath.AddString(prefix.Replace(' ', '|'), fontFamily, (int)modifier, Configuration.Instance.OverlayContentSize, new PointF(0, pos), strformat);
                        
                        path.AddString(prefix, fontFamily, (int)modifier, Configuration.Instance.OverlayContentSize, new PointF(x, pos), strformat);
                        RectangleF size = tempPath.GetBounds();
                        x += size.X + size.Width + size.Left;
                        tempPath.Reset();
                        Image image = IconMap[iconCode];

                        if (x == 0)
                            x = 3;
                        float ar = (float)image.Width / (float)image.Height;
                        int newWidth = (int)(Configuration.Instance.OverlayContentSize * ar);
                        images.Add(new object[] { image, x, pos, (int)newWidth });
                        x += newWidth;
                    }

                }

                path.AddString(line, fontFamily, (int)modifier, Configuration.Instance.OverlayContentSize, new PointF(x, pos), strformat);

                pos += Configuration.Instance.OverlayContentSize + 2;
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

            foreach (object[] image in images)
            {
                try
                {
                    e.Graphics.DrawImage(image[0] as Image, (float)image[1], (float)image[2], (int)image[3], (float)(Configuration.Instance.OverlayContentSize));
                }
                catch (Exception ex)
                {
                    ex = ex;
                }
            }

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


        /*protected override CreateParams CreateParams
        {
            get
            {
                CreateParams p = base.CreateParams;


                p.ExStyle |= (0x08000000);

                return p;
            }
        }*/
    }
}
