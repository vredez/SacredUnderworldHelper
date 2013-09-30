using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace Sacred_Underworld_Helper.UI
{
    public partial class MainForm : Form
    {
        Configuration config;
        
        SacredLauncher launcher;
        SacredSettings sacredSettings;
        SacredSettings underworldSettings;
        
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
                sacredSettings = new SacredSettings(Path.Combine(launcher.SacredDirectory, "settings.cfg"));
                tabControl.TabPages.Add(new SettingsTab("Sacred Settings", sacredSettings));
            }

            if (launcher.IsUnderworldAvailable)
            {
                button_underworld.Enabled = true;
                underworldSettings = new SacredSettings(Path.Combine(launcher.UnderworldDirectory, "settings.cfg"));
                tabControl.TabPages.Add(new SettingsTab("Underworld Settings", underworldSettings));
            }
        }

        protected override void OnFormClosed(FormClosedEventArgs e)
        {
            base.OnFormClosed(e);

            if (sacredSettings != null)
                sacredSettings.Save();
            if (underworldSettings != null)
                underworldSettings.Save();

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

        void launcher_SacredExited(object sender, EventArgs e)
        {
            
        }

        private void CheckBoxes(object sender, EventArgs e)
        {
            if (!checkBox_emulateFullscreen.Checked)
            {
                checkBox_showClock.Checked = checkBox_showGamingTime.Checked = false;
            }
        }
    }
}
