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
    public partial class frmSimpleWallpaperDesigner : Form
    {

        private Point m_mouseStartPoint;
        private Control m_currentSelection;

        public frmSimpleWallpaperDesigner()
        {
            InitializeComponent();
        }

        private void lblInfo_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Copy;
        }

        private void lblBaseRequired_DragDrop(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent("FileDrop"))
            {
                string[] data = (string[])e.Data.GetData(DataFormats.FileDrop);

                if (data.Length > 0)
                {
                    if (System.IO.File.Exists(data[0]))
                    {
                        try
                        {
                            Image image = Image.FromFile(data[0]);
                            lblInfo.Text = string.Format("Size: {0}x{1}", image.Width, image.Height);

                            lblBaseRequired.Visible = false;
                            pnlReceptical.Width = image.Width;
                            pnlReceptical.Height = image.Height;
                            pnlReceptical.BackgroundImage = image;
                            pnlReceptical.Visible = true;


                            this.MaximumSize = new Size(pnlReceptical.Width + 100, pnlReceptical.Height + pnlControls.Height + 100);

                        }
                        catch { }
                    }
                }
            }
        }

        public void ClearSelection()
        {
            foreach (Control control in pnlReceptical.Controls)
            {
                if (control is Label)
                {
                    var label = control as Label;
                    label.BorderStyle = BorderStyle.None;
                }

                if (control is PictureBox)
                {
                    var pb = control as PictureBox;
                    pb.BorderStyle = BorderStyle.None;
                }
            }


            m_currentSelection = null;
        }

        private void CreatedControl_MouseDown(object sender, MouseEventArgs e)
        {

            if (e.Button == System.Windows.Forms.MouseButtons.Left)
            {
                if (sender is PictureBox)
                {
                    m_mouseStartPoint = new Point(e.X, e.Y);
                    int iIndex = this.pnlReceptical.Controls.GetChildIndex((Control)sender) + 1;
                    this.ClearSelection();
                    ((PictureBox)sender).BorderStyle = BorderStyle.FixedSingle;
                    ((PictureBox)sender).BackColor = Color.Gray;
                }
            }
        }


        private void CreatedControl_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Left)
            {
                if (sender is PictureBox)
                {
                    lblInfo.Text = string.Format("Size: {0}x{1}", pnlReceptical.BackgroundImage.Width, pnlReceptical.BackgroundImage.Height);
                    ((PictureBox)sender).BackColor = Color.Transparent;
                }
            }
            else if (e.Button == System.Windows.Forms.MouseButtons.Right)
            {
                if (sender is PictureBox)
                {
                    var pb = sender as PictureBox;
                    pnlReceptical.Controls.Remove(pb);
                    if (pb.Image != null)
                    {
                        pb.Image.Dispose();
                        pb.Image = null;
                    }
                    pb.Hide();
                    pb.Dispose();
                }
            }

        }

        private void CreatedControl_MouseEnter(object sender, EventArgs e)
        {

                if (sender is PictureBox)
                {
                    ((PictureBox)sender).BorderStyle = BorderStyle.FixedSingle;
                }
            
        }

        private void CreatedControl_MouseLeave(object sender, EventArgs e)
        {

                if (sender is PictureBox)
                {
                    ((PictureBox)sender).BorderStyle = BorderStyle.None;
                }
            
        }


        private void CreatedControl_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                if (sender is PictureBox)
                {
                    PictureBox pb = (PictureBox)sender;
                    pb.Top += e.Y - this.m_mouseStartPoint.Y;
                    pb.Left += e.X - this.m_mouseStartPoint.X;

                    if (pb.Top > pnlReceptical.BackgroundImage.Height)
                        pb.Top = pnlReceptical.BackgroundImage.Height;

                    if (pb.Left > pnlReceptical.BackgroundImage.Width)
                        pb.Left = pnlReceptical.BackgroundImage.Width;
                    pb.Cursor = Cursors.Arrow;
                    lblInfo.Text = string.Format("Size: {0}x{1}, Loc: {2},{3} ", pnlReceptical.BackgroundImage.Width, pnlReceptical.BackgroundImage.Height, pb.Top, pb.Left);
                }
            }
        }

        public void Save(string location)
        {
            try
            {
                Image image = new Bitmap(pnlReceptical.BackgroundImage);
                Graphics g = Graphics.FromImage(image);
                g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
                g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
                g.TextRenderingHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;

                foreach (Control control in pnlReceptical.Controls)
                {
                    if (control is PictureBox)
                    {
                        var pb = control as PictureBox;

                        g.DrawImage(pb.Image, pb.Left, pb.Top);
                    }
                }

                g.Dispose();

                System.Drawing.Imaging.ImageFormat format = System.Drawing.Imaging.ImageFormat.Png;
                string extension = System.IO.Path.GetExtension(location).ToLower();

                switch (extension)
                {
                    case ".jpg":
                    case ".jpeg":
                        format = System.Drawing.Imaging.ImageFormat.Jpeg;
                        break;
                    case ".bmp":
                        format = System.Drawing.Imaging.ImageFormat.Bmp;
                        break;
                    case ".tiff":
                        format = System.Drawing.Imaging.ImageFormat.Tiff;
                        break;
                    case ".gif":
                        format = System.Drawing.Imaging.ImageFormat.Gif;
                        break;
                }
                
                image.Save(location, format);
            }
            catch (Exception ex)
            {
                MessageBox.Show(string.Format("Failed to save file:\r\n\r\n{0}", ex.ToString()), "Uh oh", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        public PictureBox AddImage(Image image, int x, int y)
        {
            PictureBox pb = new PictureBox();
            pb.MouseMove += new MouseEventHandler(this.CreatedControl_MouseMove);
            pb.MouseEnter += new EventHandler(this.CreatedControl_MouseEnter);
            pb.MouseLeave += new EventHandler(this.CreatedControl_MouseLeave);
            pb.MouseDown += new MouseEventHandler(this.CreatedControl_MouseDown);
            pb.MouseUp += new MouseEventHandler(this.CreatedControl_MouseUp);
            pb.Parent = this.pnlReceptical;
            pb.Top = y;
            pb.Left = x;
            pb.Image = image;
            pb.SizeMode = PictureBoxSizeMode.Normal;
            pb.Height = pb.Image.Height;
            pb.Width = pb.Image.Width;
            pb.Cursor = Cursors.SizeAll;
            pb.BackColor = Color.Transparent;
            pb.BringToFront();
            pb.Show();
            pb.BackColor = Color.Transparent;

            return pb;
        }

        private void pnlReceptical_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Copy;
        }

        private void pnlReceptical_DragOver(object sender, DragEventArgs e)
        {

            if (e.Effect == DragDropEffects.Copy)
            {
                Point loc = this.pnlReceptical.PointToClient(new Point(e.X, e.Y));
                int iX = (int)Math.Round((double)(loc.X - (((double)this.pbBlankBox.Width) / 2.0)));
                int iY = (int)Math.Round((double)(loc.Y - (((double)this.pbBlankBox.Height) / 2.0)));
                int iBoxX = (int)Math.Round((double)(e.X - (((double)this.pbBlankBox.Width) / 2.0)));
                int iBoxY = (int)Math.Round((double)(e.Y - (((double)this.pbBlankBox.Height) / 2.0)));
                this.tooltip.ShowAlways = true;

                
                this.tooltip.Show(iX.ToString() + "," + iY.ToString(), this.pnlReceptical, new Point(0, 0));
                tooltip.ShowAlways = true;
                this.Refresh();
                ControlPaint.DrawReversibleFrame(new Rectangle(iBoxX, iBoxY, this.pbBlankBox.Width, this.pbBlankBox.Height), this.pbBlankBox.BackColor, FrameStyle.Dashed);
            }
        }

        private void pnlReceptical_DragDrop(object sender, DragEventArgs e)
        {
            if (e.Effect == DragDropEffects.Copy)
            {
                Point loc = this.pnlReceptical.PointToClient(new Point(e.X, e.Y));
                int iX = (int)Math.Round((double)(loc.X - (((double)this.pbBlankBox.Width) / 2.0)));
                int iY = (int)Math.Round((double)(loc.Y - (((double)this.pbBlankBox.Height) / 2.0)));
                this.tooltip.Hide(this.pnlReceptical);
                this.pbBlankBox.Visible = false;
                this.Refresh();

                if (e.Data.GetDataPresent(typeof(Models.Build)))
                {
                    var build = e.Data.GetData(typeof(Models.Build)) as Models.Build;

                    AddImage(build.GenerateImage(), iX, iY).Tag = build;
                }
                else if (e.Data.GetDataPresent(typeof(Bitmap)))
                {
                    var image = e.Data.GetData(typeof(Bitmap)) as Image;

                    // The resource window disposes the image.
                    Bitmap copy = new Bitmap(image);
                    AddImage(copy, iX, iY);
                }
            }

        }

        private void cmdSave_Click(object sender, EventArgs e)
        {
            if (pnlReceptical.BackgroundImage != null)
            {
                if (sfd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    Save(sfd.FileName);
                }
            }
        }

        private void cmdUpdate_Click(object sender, EventArgs e)
        {
            foreach (Control control in pnlReceptical.Controls)
            {
                if (control is PictureBox)
                {
                    var pb = control as PictureBox;

                    if (control.Tag != null)
                    {
                        var build = control.Tag as Models.Build;
                        {
                            if (pb.Image != null)
                                pb.Image.Dispose();
                            pb.Image = null;
                        }
                        pb.Image = build.GenerateImage();
                        pb.Width = pb.Image.Width;
                        pb.Height = pb.Image.Height;
                    }
                }
            }
        }

        private void cmdResource_Click(object sender, EventArgs e)
        {
            frmResources res = new frmResources();
            res.Show();
        }

    }
}
