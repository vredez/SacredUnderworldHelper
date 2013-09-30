using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;

namespace Sacred_Underworld_Helper.Tweak
{
    class BlackScreen : Form
    {
        public BlackScreen()
        {
            FormBorderStyle = FormBorderStyle.None;
            ShowInTaskbar = false;
            BackColor = Color.Black;
            Text = "BLACKSCREEN";
            WindowState = FormWindowState.Maximized;
        }

        protected override void WndProc(ref Message m)
        {
            base.WndProc(ref m);
        }
    }
}
