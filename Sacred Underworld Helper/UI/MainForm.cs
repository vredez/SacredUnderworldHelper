using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Sacred_Underworld_Helper.UI
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();

			SacredSettings settings = new SacredSettings(@"C:\Users\lid\Downloads\git\SacredUnderworldHelper\Examples\uw_settings.cfg");

			tabControl.TabPages.Add(new SettingsTab("Underworld Settings", settings));
        }
    }
}
