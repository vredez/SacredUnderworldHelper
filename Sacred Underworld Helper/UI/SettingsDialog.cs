using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SacredUnderworldHelper.UI
{
	public partial class SettingsDialog : Form
	{
		string setting;

		public string Setting
		{
			get { return setting; }
			set
			{
				setting = value;
				Text = string.Format("Change value of \"{0}\"", setting);
			}
		}

		public string Value
		{
			get { return textBox.Text; }
			set { textBox.Text = value; }
		}

		public SettingsDialog()
		{
			InitializeComponent();
			Setting = string.Empty;
		}

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            Location = new Point
            {
                X = MousePosition.X + RectangleToClient(Bounds).X - textBox.Location.X - textBox.Font.Height / 2,
                Y = MousePosition.Y + RectangleToClient(Bounds).Y - textBox.Location.Y - textBox.Height / 2
            };

            textBox.SelectAll();
        }

		private void TextBoxKeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.End || e.KeyCode == Keys.Return)
			{
				DialogResult = DialogResult.OK;
			}
		}
	}
}
