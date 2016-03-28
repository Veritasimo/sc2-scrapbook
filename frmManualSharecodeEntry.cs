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
    public partial class frmManualSharecodeEntry : Form
    {
        Models.Build activeBuild;

        public frmManualSharecodeEntry()
        {
            InitializeComponent();
            activeBuild = null;
        }

        private void txtShareCode_TextChanged(object sender, EventArgs e)
        {
            tmrUpdate.Stop();
            tmrUpdate.Start();
        }

        private void tmrUpdate_Tick(object sender, EventArgs e)
        {
            tmrUpdate.Stop();

            try
            {
                Models.Build build = null;

                string data = txtShareCode.Text;
                if (data.StartsWith("sc2bo://"))
                    data = data.Substring(8);

                try
                {
                    build = Models.Build.ParseSALT(new SALT(data));
                } catch (Exception)
                {

                }
                
                if (build == null) {

                    build = Models.Build.ParseBase64(data);
                }

                if (build != null)
                {
                    pbStatus.Image = Properties.Resources.tick;
                    Text = string.Format("Import Build - {0}", build.Name);
                }
                else
                {
                    pbStatus.Image = Properties.Resources.cross;
                    Text = string.Format("Import Build");
                }
                
            }
            catch (Exception)
            {
                pbStatus.Image = Properties.Resources.cross;
                Text = string.Format("Import Build");
            }

            
        }

        private void cmdImport_Click(object sender, EventArgs e)
        {
            try
            {
                Models.Build build = null;

                string data = txtShareCode.Text;
                if (data.StartsWith("sc2bo://"))
                    data = data.Substring(8);

                try
                {
                    build = Models.Build.ParseSALT(new SALT(data));
                }
                catch (Exception)
                {

                }
                if (build == null)
                {
                    build = Models.Build.ParseBase64(data);
                }

                frmImportBuild import = new frmImportBuild(build);
                if (import.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    Program.BuildsDB.Add(build);
                    Program.SaveBuildsXML();
                    this.DialogResult = System.Windows.Forms.DialogResult.OK;    
                }

                

                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(string.Format("Failed to import build:\r\n\r\n{0}", ex.ToString()), "Import Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
 