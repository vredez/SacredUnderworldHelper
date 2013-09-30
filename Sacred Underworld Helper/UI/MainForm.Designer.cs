namespace Sacred_Underworld_Helper.UI
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.tabControl = new System.Windows.Forms.TabControl();
            this.tab_launcher = new System.Windows.Forms.TabPage();
            this.button_sacred = new System.Windows.Forms.Button();
            this.button_underworld = new System.Windows.Forms.Button();
            this.groupBox_tweaks = new System.Windows.Forms.GroupBox();
            this.checkBox_emulateFullscreen = new System.Windows.Forms.CheckBox();
            this.checkBox_showClock = new System.Windows.Forms.CheckBox();
            this.checkBox_showGamingTime = new System.Windows.Forms.CheckBox();
            this.tabControl.SuspendLayout();
            this.tab_launcher.SuspendLayout();
            this.groupBox_tweaks.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl
            // 
            this.tabControl.Controls.Add(this.tab_launcher);
            this.tabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl.Location = new System.Drawing.Point(0, 0);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(300, 271);
            this.tabControl.TabIndex = 0;
            // 
            // tab_launcher
            // 
            this.tab_launcher.Controls.Add(this.groupBox_tweaks);
            this.tab_launcher.Controls.Add(this.button_underworld);
            this.tab_launcher.Controls.Add(this.button_sacred);
            this.tab_launcher.Location = new System.Drawing.Point(4, 22);
            this.tab_launcher.Name = "tab_launcher";
            this.tab_launcher.Padding = new System.Windows.Forms.Padding(3);
            this.tab_launcher.Size = new System.Drawing.Size(292, 245);
            this.tab_launcher.TabIndex = 0;
            this.tab_launcher.Text = "Launcher";
            this.tab_launcher.UseVisualStyleBackColor = true;
            // 
            // button_sacred
            // 
            this.button_sacred.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button_sacred.Enabled = false;
            this.button_sacred.Image = global::Sacred_Underworld_Helper.Properties.Resources.Sacred_new_4;
            this.button_sacred.Location = new System.Drawing.Point(8, 6);
            this.button_sacred.Name = "button_sacred";
            this.button_sacred.Size = new System.Drawing.Size(135, 135);
            this.button_sacred.TabIndex = 0;
            this.button_sacred.UseVisualStyleBackColor = true;
            // 
            // button_underworld
            // 
            this.button_underworld.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button_underworld.Enabled = false;
            this.button_underworld.Image = global::Sacred_Underworld_Helper.Properties.Resources.Sacred_Addon_new_4;
            this.button_underworld.Location = new System.Drawing.Point(149, 6);
            this.button_underworld.Name = "button_underworld";
            this.button_underworld.Size = new System.Drawing.Size(135, 135);
            this.button_underworld.TabIndex = 1;
            this.button_underworld.UseVisualStyleBackColor = true;
            // 
            // groupBox_tweaks
            // 
            this.groupBox_tweaks.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox_tweaks.Controls.Add(this.checkBox_showGamingTime);
            this.groupBox_tweaks.Controls.Add(this.checkBox_showClock);
            this.groupBox_tweaks.Controls.Add(this.checkBox_emulateFullscreen);
            this.groupBox_tweaks.Location = new System.Drawing.Point(8, 147);
            this.groupBox_tweaks.Name = "groupBox_tweaks";
            this.groupBox_tweaks.Size = new System.Drawing.Size(276, 92);
            this.groupBox_tweaks.TabIndex = 2;
            this.groupBox_tweaks.TabStop = false;
            this.groupBox_tweaks.Text = "Tweaks";
            // 
            // checkBox_emulateFullscreen
            // 
            this.checkBox_emulateFullscreen.AutoSize = true;
            this.checkBox_emulateFullscreen.Checked = true;
            this.checkBox_emulateFullscreen.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox_emulateFullscreen.Location = new System.Drawing.Point(13, 21);
            this.checkBox_emulateFullscreen.Name = "checkBox_emulateFullscreen";
            this.checkBox_emulateFullscreen.Size = new System.Drawing.Size(122, 17);
            this.checkBox_emulateFullscreen.TabIndex = 0;
            this.checkBox_emulateFullscreen.Text = "Emulate Fullscreen";
            this.checkBox_emulateFullscreen.UseVisualStyleBackColor = true;
            this.checkBox_emulateFullscreen.CheckedChanged += new System.EventHandler(this.CheckBoxes);
            // 
            // checkBox_showClock
            // 
            this.checkBox_showClock.AutoSize = true;
            this.checkBox_showClock.Checked = true;
            this.checkBox_showClock.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox_showClock.Location = new System.Drawing.Point(13, 44);
            this.checkBox_showClock.Name = "checkBox_showClock";
            this.checkBox_showClock.Size = new System.Drawing.Size(86, 17);
            this.checkBox_showClock.TabIndex = 1;
            this.checkBox_showClock.Text = "Show Clock";
            this.checkBox_showClock.UseVisualStyleBackColor = true;
            this.checkBox_showClock.CheckedChanged += new System.EventHandler(this.CheckBoxes);
            // 
            // checkBox_showGamingTime
            // 
            this.checkBox_showGamingTime.AutoSize = true;
            this.checkBox_showGamingTime.Checked = true;
            this.checkBox_showGamingTime.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox_showGamingTime.Location = new System.Drawing.Point(13, 67);
            this.checkBox_showGamingTime.Name = "checkBox_showGamingTime";
            this.checkBox_showGamingTime.Size = new System.Drawing.Size(124, 17);
            this.checkBox_showGamingTime.TabIndex = 2;
            this.checkBox_showGamingTime.Text = "Show Gaming Time";
            this.checkBox_showGamingTime.UseVisualStyleBackColor = true;
            this.checkBox_showGamingTime.CheckedChanged += new System.EventHandler(this.CheckBoxes);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(300, 271);
            this.Controls.Add(this.tabControl);
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Sacred Underworld Helper";
            this.tabControl.ResumeLayout(false);
            this.tab_launcher.ResumeLayout(false);
            this.groupBox_tweaks.ResumeLayout(false);
            this.groupBox_tweaks.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl;
		private System.Windows.Forms.TabPage tab_launcher;
        private System.Windows.Forms.Button button_sacred;
        private System.Windows.Forms.Button button_underworld;
        private System.Windows.Forms.GroupBox groupBox_tweaks;
        private System.Windows.Forms.CheckBox checkBox_showGamingTime;
        private System.Windows.Forms.CheckBox checkBox_showClock;
        private System.Windows.Forms.CheckBox checkBox_emulateFullscreen;
    }
}