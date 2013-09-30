using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Diagnostics;
using Microsoft.Win32;

namespace Sacred_Underworld_Helper
{
    class SacredLauncher
    {
        string sacredDirectory;
        string underworldDirectory;
        string sacredVersion;
        string underworldVersion;
        List<string> parameters;

        Process proc;

        public bool IsSacredAvailable
        {
            get { return !string.IsNullOrEmpty(sacredDirectory) && File.Exists(Path.Combine(sacredDirectory, "Sacred.exe")); }
        }

        public bool IsUnderworldAvailable
        {
            get { return !string.IsNullOrEmpty(underworldDirectory) && File.Exists(Path.Combine(underworldDirectory, "sacred.exe")); }
        }

        public string SacredDirectory
        {
            get { return sacredDirectory; }
            set { sacredDirectory = value; }
        }

        public string UnderworldDirectory
        {
            get { return underworldDirectory; }
            set { underworldDirectory = value; }
        }

        public string SacredVersion
        {
            get { return sacredVersion; }
        }

        public string UnderworldVersion
        {
            get { return underworldVersion; }
        }

        public List<String> Parameters
        {
            get { return parameters; }
            set { parameters = value; }
        }

        public event EventHandler SacredExited;

        protected virtual void OnSacredExited()
        {
            if (SacredExited != null)
                SacredExited(this, EventArgs.Empty);
        }

        public SacredLauncher()
        {
            parameters = new List<string>();

            RegistryKey sacred_reg = Registry.CurrentUser.OpenSubKey(@"Software\Ascaron Entertainment\Sacred");
            if (sacred_reg != null)
            {
                sacredDirectory = sacred_reg.GetValue("InstallLocation").ToString();
                sacredVersion = sacred_reg.GetValue("Version").ToString();
            }

            sacred_reg = Registry.CurrentUser.OpenSubKey(@"Software\Ascaron Entertainment\Sacred Underworld");
            if (sacred_reg != null)
            {
                underworldDirectory = sacred_reg.GetValue("InstallLocation").ToString();
                underworldVersion = sacred_reg.GetValue("Version").ToString();
            }
        }

        public void LaunchSacred()
        {
            Launch("sacred.exe", sacredDirectory);
        }

        public void LaunchUnderworld()
        {
            Launch("sacred.exe", underworldDirectory);
        }

        void Launch(string executable, string workDir)
        {
            if (proc != null)
                throw new Exception(string.Format("{0} is already running.", proc.ProcessName));

            proc = new Process();
            
            proc.StartInfo.FileName = Path.Combine(workDir, executable);
            proc.StartInfo.WorkingDirectory = workDir;
            proc.EnableRaisingEvents = true;

            foreach (string param in parameters)
                proc.StartInfo.Arguments += param + ' ';

            proc.Exited += proc_Exited;
            proc.Start();
        }

        void proc_Exited(object sender, EventArgs e)
        {
            proc = null;
            OnSacredExited();
        }
    }
}
