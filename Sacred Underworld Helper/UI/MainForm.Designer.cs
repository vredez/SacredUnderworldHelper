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
			this.tabControl.SuspendLayout();
			this.SuspendLayout();
			// 
			// tabControl
			// 
			this.tabControl.Controls.Add(this.tab_launcher);
			this.tabControl.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tabControl.Location = new System.Drawing.Point(0, 0);
			this.tabControl.Name = "tabControl";
			this.tabControl.SelectedIndex = 0;
			this.tabControl.Size = new System.Drawing.Size(647, 388);
			this.tabControl.TabIndex = 0;
			// 
			// tab_launcher
			// 
			this.tab_launcher.Location = new System.Drawing.Point(4, 22);
			this.tab_launcher.Name = "tab_launcher";
			this.tab_launcher.Padding = new System.Windows.Forms.Padding(3);
			this.tab_launcher.Size = new System.Drawing.Size(639, 362);
			this.tab_launcher.TabIndex = 0;
			this.tab_launcher.Text = "Launcher";
			this.tab_launcher.UseVisualStyleBackColor = true;
			// 
			// MainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(647, 388);
			this.Controls.Add(this.tabControl);
			this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.Name = "MainForm";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Sacred Underworld Helper";
			this.tabControl.ResumeLayout(false);
			this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl;
		private System.Windows.Forms.TabPage tab_launcher;
    }
}