using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Diagnostics;

namespace Sacred_Underworld_Helper
{
    class SacredLauncher
    {
        string sacredDirectory;
        string underworldDirectory;
        List<string> parameters;

        Process proc;

        public bool IsSacredAvailable
        {
            get { return !string.IsNullOrEmpty(sacredDirectory) && Directory.Exists(sacredDirectory); }
        }

        public bool IsUnderworldAvailable
        {
            get { return !string.IsNullOrEmpty(underworldDirectory) && Directory.Exists(underworldDirectory); }
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
