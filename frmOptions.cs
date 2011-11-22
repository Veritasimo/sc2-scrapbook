﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SC2Scrapbook
{
    public partial class frmOptions : Form
    {
        public frmOptions()
        {
            InitializeComponent();

            numOutlineSize.Value = Configuration.Instance.OverlayTextOutlineSize;
            pnlOutlineColour.BackColor = Configuration.Instance.OverlayTextOutlineColour;
            pnlTextColour.BackColor = Configuration.Instance.OverlayTextColour;
            chkAdvancedEnabled.Checked = Configuration.Instance.UseAdvancedOptions;
            chkIngameBOSelector.Checked = Configuration.Instance.BuildSelectionOverlay;
            chkOpponentInfoOverlay.Checked = Configuration.Instance.OpponentInfoOverlay;
            txtMySC2Name.Text = Configuration.Instance.MySC2Character;
            chkUseRandomBuild.Checked = Configuration.Instance.SelectRandomBuild;
            chkAllowVsX.Checked = Configuration.Instance.AllowVsXBuilds;
            grpAdvancedOpponentInfo.Enabled = chkAdvancedEnabled.Checked;
            numOverlayClose.Value = Configuration.Instance.OpponentInfoOverlayTimeout;
            numImageScale.Value = Configuration.Instance.OverlayImageScale;

        }

        private void cmdEditTitle_Click(object sender, EventArgs e)
        {
            FontFamily fontFamily = new FontFamily(Configuration.Instance.OverlayTitleFont);
            fontDialog.Font = new Font(fontFamily, Configuration.Instance.OverlayTitleSize);

            if (fontDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                Configuration.Instance.OverlayTitleFont = fontDialog.Font.Name;
                Configuration.Instance.OverlayTitleSize = fontDialog.Font.SizeInPoints;
            }
        }

        private void cmdEditContentFont_Click(object sender, EventArgs e)
        {
            FontFamily fontFamily = new FontFamily(Configuration.Instance.OverlayContentFont);
            fontDialog.Font = new Font(fontFamily, Configuration.Instance.OverlayContentSize);

            if (fontDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                Configuration.Instance.OverlayContentFont = fontDialog.Font.Name;
                Configuration.Instance.OverlayContentSize = fontDialog.Font.SizeInPoints;
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void cmdPreview_Click(object sender, EventArgs e)
        {
            Program.HideOverlay();

            Models.Build build = new Models.Build("Build Title", "TvP", "Normal Example Content\r\n#Italic Example Content\r\n*Bold Example Content\r\nContent with {minerals}{protoss}{zerg}icons\r\nContent with {protoss_unit_zealot} {terran_unit_marine} units", "");
            frmBuildOverlay overlay = new frmBuildOverlay(build);
            overlay.Show();
        }

        private void cmdExit_Click(object sender, EventArgs e)
        {
            Program.HideBuildSelection();
            
            if (chkAdvancedEnabled.Checked)
                if (string.IsNullOrWhiteSpace(txtMySC2Name.Text))
                    chkAdvancedEnabled.Checked = false;

            Program.SaveConfigurationXML();
            Close();
        }

        private void pnlTextColour_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pnlTextColour_Click(object sender, EventArgs e)
        {
            colorDialog.Color = Configuration.Instance.OverlayTextColour;
            if (colorDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                Configuration.Instance.OverlayTextColour = colorDialog.Color;
                pnlTextColour.BackColor = colorDialog.Color;
            }
        }

        private void pnlOutlineColour_Click(object sender, EventArgs e)
        {
            colorDialog.Color = Configuration.Instance.OverlayTextOutlineColour;
            if (colorDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                Configuration.Instance.OverlayTextOutlineColour = colorDialog.Color;
                pnlOutlineColour.BackColor = colorDialog.Color;
            }
        }

        private void numOutlineSize_ValueChanged(object sender, EventArgs e)
        {
            Configuration.Instance.OverlayTextOutlineSize = (int)numOutlineSize.Value;
        }

        private void txtOverlayHotkey_KeyUp(object sender, KeyEventArgs e)
        {
            if ((e.KeyCode & Keys.ControlKey) == Keys.ControlKey)
                return;

            if ((e.KeyCode & Keys.Alt) == Keys.Alt)
                return;

            if (e.KeyCode == Keys.ShiftKey)
                return;

            
            txtOverlayHotkey.Text = "";
            if (e.Control)
                txtOverlayHotkey.Text += "CTRL+";
            if (e.Alt)
                txtOverlayHotkey.Text += "ALT+";
            if (e.Shift)
                txtOverlayHotkey.Text += "SHIFT+";

            txtOverlayHotkey.Text += e.KeyCode.ToString();
            Configuration.Instance.ToggleOverlayKey = e.KeyCode;
            Configuration.Instance.ToggleOverlayModifier = e.Modifiers;

        }

        private void txtOverlayHotkey_TextChanged(object sender, EventArgs e)
        {

        }

        private void chkAdvancedEnabled_CheckedChanged(object sender, EventArgs e)
        {
            if (this.Visible)
            {
                if (chkAdvancedEnabled.Checked)
                {
                    if (MessageBox.Show(@"Warning!

These options directly interface with the StarCraft II process.

No data is gathered from the game client except for the IDs of the players currently in game. Overlay data is harvested from the Battle.net website. 

Other applications such as StarInfo for JTV and SC2 XSplit Screen Switcher (used by many pros) gather the same data. Although the many users of these applications do not face repercussions for doing so, it is still against the SC2 EULA and Blizzard can detect and ban their usage at any time if they deem it necessary.

Do you want to continue?", "Advanced Goodness.", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == System.Windows.Forms.DialogResult.No)
                    {
                        chkAdvancedEnabled.Checked = false;
                        return;
                    }
                }

                grpAdvancedOpponentInfo.Enabled = chkAdvancedEnabled.Checked;

                if (!chkAdvancedEnabled.Checked)
                {
                    chkIngameBOSelector.Checked = false;
                    chkOpponentInfoOverlay.Checked = false;
                    Program.KillSC2InteractionThread();
                }
                else
                {
                    Program.StartSC2InteractionThread();
                }

                Configuration.Instance.UseAdvancedOptions = chkAdvancedEnabled.Checked;
                Configuration.Instance.BuildSelectionOverlay = chkIngameBOSelector.Checked;
                Configuration.Instance.OpponentInfoOverlay = chkOpponentInfoOverlay.Checked;
                Configuration.Instance.SelectRandomBuild = chkUseRandomBuild.Checked;
                Configuration.Instance.AllowVsXBuilds = chkAllowVsX.Checked;
            }
        }

        private void chkOpponentInfoOverlay_CheckedChanged(object sender, EventArgs e)
        {
            Configuration.Instance.OpponentInfoOverlay = chkOpponentInfoOverlay.Checked;
        }

        private void chkIngameBOSelector_CheckedChanged(object sender, EventArgs e)
        {
            Configuration.Instance.BuildSelectionOverlay = chkIngameBOSelector.Checked;

            if (!chkIngameBOSelector.Checked)
            {
                chkUseRandomBuild.Checked = false;
                chkUseRandomBuild.Enabled = false;
                chkAllowVsX.Checked = false;
                chkAllowVsX.Enabled = false;
            }
            else
            {
                chkUseRandomBuild.Enabled = true;
                chkAllowVsX.Enabled = true;
            }
        }

        private void frmOverlayOptions_Load(object sender, EventArgs e)
        {

        }

        private void txtMySC2Name_TextChanged(object sender, EventArgs e)
        {
            Configuration.Instance.MySC2Character = txtMySC2Name.Text;
        }

        private void chkUseRandomBuild_CheckedChanged(object sender, EventArgs e)
        {
            Configuration.Instance.SelectRandomBuild = chkUseRandomBuild.Checked;
        }

        private void chkAllowVsX_CheckedChanged(object sender, EventArgs e)
        {
            Configuration.Instance.AllowVsXBuilds = chkAllowVsX.Checked;
        }

        private void llNameHelp_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            MessageBox.Show("Your SC2 account name is required to identify which player is the opponent.", "WHO ARE YA?", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void numOverlayClose_ValueChanged(object sender, EventArgs e)
        {
            Configuration.Instance.OpponentInfoOverlayTimeout = (int)numOverlayClose.Value;
        }

        private void numImageScale_ValueChanged(object sender, EventArgs e)
        {
            Configuration.Instance.OverlayImageScale = (int)numImageScale.Value;
        }

    }
}
