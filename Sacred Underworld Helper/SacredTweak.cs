using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;

namespace Sacred_Underworld_Helper
{
    class SacredTweak
    {
        bool showClock;
        bool showGamingTime;
        Font uiFont;
        Color uiColor;

        public bool ShowClock
        {
            get { return showClock; }
            set { showClock = value; }
        }

        public bool ShowGamingTime
        {
            get { return showGamingTime; }
            set { showGamingTime = value; }
        }

        public Font UIFont
        {
            get { return uiFont; }
            set { uiFont = value; }
        }

        public Color UIColor
        {
            get { return uiColor; }
            set { uiColor = value; }
        }

        public SacredTweak()
        {
        }
    }
}
