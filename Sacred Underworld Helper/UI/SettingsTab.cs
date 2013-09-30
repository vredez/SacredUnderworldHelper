using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;

namespace Sacred_Underworld_Helper.UI
{
    partial class SettingsTab : TabPage
	{
		#region "Designer Code"

		ListView listView;
		ColumnHeader columnSettings;
		ColumnHeader columnValues;

		private void InitializeComponent()
		{
			listView = new ListView();
			columnSettings = new ColumnHeader();
			columnValues = new ColumnHeader();
			this.SuspendLayout();

			listView.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Top | AnchorStyles.Right;
			listView.Columns.Add(columnSettings);
			listView.Columns.Add(columnValues);
			listView.GridLines = true;
			listView.Margin = new Padding(5);
			listView.Name = "listView";
			listView.Location = new Point(5, 5);
			listView.Size = new Size(Width - 10, Height - 10);
			listView.View = View.Details;
			listView.FullRowSelect = true;
			listView.MouseMove += listView_MouseMove;
			listView.DoubleClick += listView_DoubleClick;

			columnSettings.Text = "Setting";
			columnSettings.Width = 200;

			columnValues.Text = "Value";
			columnValues.Width = 200;

			Controls.Add(listView);
			BackColor = Color.White;

			this.ResumeLayout(false);
		}

		void listView_MouseMove(object sender, MouseEventArgs e)
		{
			listView.Focus();
		}

		#endregion

		SacredSettings sacredSettings;
		SettingsDialog sd;

		public SacredSettings SacredSettings
		{
			get { return sacredSettings; }
			set
			{
				sacredSettings = value;
				UpdateContent();
			}
		}

		public SettingsTab(string title, SacredSettings sacredSettings)
		{
			InitializeComponent();
			Text = title;
			this.sacredSettings = sacredSettings;
			sd = new SettingsDialog();
			UpdateContent();
		}

		public void UpdateContent()
		{
			listView.SuspendLayout();
			listView.Items.Clear();

			foreach (string setting in sacredSettings.Settings)
			{
				ListViewItem lvi = new ListViewItem(new[] { setting, sacredSettings[setting] });
				listView.Items.Add(lvi);
			}

			listView.ResumeLayout();
		}

		void listView_DoubleClick(object sender, EventArgs e)
		{
			if (listView.SelectedItems.Count == 1)
			{
				string setting = listView.SelectedItems[0].Text;
				
				sd.Setting = setting;
				sd.Value = listView.SelectedItems[0].SubItems[1].Text;
				if (sd.ShowDialog() == DialogResult.OK)
				{
					listView.SelectedItems[0].SubItems[1].Text = sd.Value;
					sacredSettings[setting] = sd.Value;
				}
			}
		}
	}
}
