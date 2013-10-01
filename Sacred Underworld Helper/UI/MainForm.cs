using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace SacredUnderworldHelper.UI
{
    public partial class MainForm : Form
    {
        Configuration config;
        
        SacredLauncher launcher;
        
        public MainForm()
        {
            InitializeComponent();

            config = new Configuration("config.ini");

            LoadSettings();

            launcher = new SacredLauncher();
            launcher.SacredExited += launcher_SacredExited;
            
            if (launcher.IsSacredAvailable)
            {
                button_sacred.Enabled = true;
                tabControl.TabPages.Add(new SettingsTab("Sacred Settings", launcher.SacredSettings));
            }

            if (launcher.IsUnderworldAvailable)
            {
                button_underworld.Enabled = true;
                tabControl.TabPages.Add(new SettingsTab("Underworld Settings", launcher.UnderworldSettings));
            }

            CheckBoxes(null, EventArgs.Empty); //Intialize tweak flags
        }

        void launcher_SacredExited(object sender, EventArgs e)
        {
            Application.Exit();
        }

        protected override void OnFormClosed(FormClosedEventArgs e)
        {
            base.OnFormClosed(e);

            if (launcher.SacredSettings != null)
                launcher.SacredSettings.Save();
            if (launcher.UnderworldSettings != null)
                launcher.UnderworldSettings.Save();

            SaveSettings();
        }

        void LoadSettings()
        {
            checkBox_emulateFullscreen.Checked = config["EMULATE_FULLSCREEN"] == "TRUE";
            checkBox_showClock.Checked = config["SHOW_CLOCK"] == "TRUE";
            checkBox_showGamingTime.Checked = config["SHOW_GAMING_TIME"] == "TRUE";
        }

        void SaveSettings()
        {
            config["EMULATE_FULLSCREEN"] = checkBox_emulateFullscreen.Checked ? "TRUE" : "FALSE";
            config["SHOW_CLOCK"] = checkBox_showClock.Checked ? "TRUE" : "FALSE";
            config["SHOW_GAMING_TIME"] = checkBox_showGamingTime.Checked ? "TRUE" : "FALSE";

            config.Save();
        }

        private void CheckBoxes(object sender, EventArgs e)
        {
            if (launcher == null) return;

            if (!checkBox_emulateFullscreen.Checked)
            {
                checkBox_showClock.Checked = checkBox_showGamingTime.Checked = false;
            }

            launcher.EmulateFullScreen = checkBox_emulateFullscreen.Checked;
            launcher.ShowClock = checkBox_showClock.Checked;
            launcher.ShowGamingTime = checkBox_showGamingTime.Checked;
        }

        private void Launch(object sender, EventArgs e)
        {
            if (sender == button_sacred)
                launcher.LaunchSacred();
            else
                launcher.LaunchUnderworld();
        }
    }
}
