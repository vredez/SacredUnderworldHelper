using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Diagnostics;
using System.Windows.Forms;
using Microsoft.Win32;
using System.Runtime.InteropServices;
using SacredUnderworldHelper.WinAPI;
using System.Drawing;
using System.Threading;

namespace SacredUnderworldHelper
{
    class SacredLauncher
    {
        string sacredDirectory;
        string underworldDirectory;
        string sacredVersion;
        string underworldVersion;
        List<string> parameters;
        bool emulateFullScreen;
        bool showClock;
        bool showGamingTime;
        bool potBot;

        Process proc;

        BlackScreen blackScreen;
        System.Windows.Forms.Timer timer;

        Size nativeResolution;
        Size emulationResolution;

        SacredSettings sacredSettings;
        SacredSettings underworldSettings;

        Font uiFont;

        delegate void VoidPtr();

        public event EventHandler SacredExited;

        protected virtual void OnSacredExited()
        {
            if (SacredExited != null)
                SacredExited(this, EventArgs.Empty);
        }

        #region "Properties"

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

        public bool EmulateFullScreen
        {
            get { return emulateFullScreen; }
            set { emulateFullScreen = value; }
        }

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

        public bool PotBot
        {
            get { return potBot; }
            set { potBot = value; }
        }

        public SacredSettings SacredSettings
        {
            get { return sacredSettings; }
        }

        public SacredSettings UnderworldSettings
        {
            get { return underworldSettings; }
        }

        #endregion

        #region "Nested Types"

        class BlackScreen : Form
        {
            public BlackScreen()
            {
                DoubleBuffered = true;
                ShowInTaskbar = false;
                FormBorderStyle = FormBorderStyle.None;
                BackColor = Color.Black;
                WindowState = FormWindowState.Maximized;
            }
        }

        #endregion

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

            if (IsSacredAvailable)
            {
                sacredSettings = new SacredSettings(Path.Combine(SacredDirectory, "settings.cfg"));
            }

            if (IsUnderworldAvailable)
            {
                underworldSettings = new SacredSettings(Path.Combine(UnderworldDirectory, "settings.cfg"));
            }

            timer = new System.Windows.Forms.Timer();
            timer.Interval = 100;
            timer.Tick += TimerTick;

            blackScreen = new BlackScreen();     
            blackScreen.Paint += BlackScreenPaint;
            blackScreen.Activated += BlackScreenActivated;

            nativeResolution = Screen.PrimaryScreen.Bounds.Size;
            emulationResolution = new Size
            {
                Width = (int)Math.Ceiling((768f * nativeResolution.Width) / nativeResolution.Height),
                Height = 768
            };

            uiFont = new Font("AntiquaSSK", 18f);
        }

        public void LaunchSacred()
        {
            if (emulateFullScreen && sacredSettings["FULLSCREEN"] == "1")
            {
                sacredSettings["FULLSCREEN"] = "0";
                sacredSettings.Save();
            }

            Launch("sacred.exe", sacredDirectory);
        }

        public void LaunchUnderworld()
        {
            if (emulateFullScreen && underworldSettings["FULLSCREEN"] == "1")
            {
                underworldSettings["FULLSCREEN"] = "0";
                underworldSettings.Save();
            }

            Launch("sacred.exe", underworldDirectory);
        }

        void Launch(string executable, string workDir)
        {
            if (proc != null)
                throw new Exception(string.Format("{0} is already running.", proc.ProcessName));

            if (emulateFullScreen)
                StartFullscreenEmulation();

            proc = new Process();

            proc.StartInfo.FileName = Path.Combine(workDir, executable);
            proc.StartInfo.WorkingDirectory = workDir;
            proc.EnableRaisingEvents = true;

            foreach (string param in parameters)
                proc.StartInfo.Arguments += param + ' ';

            proc.Exited += ProcExited;
            proc.Start();

            if (potBot)
                ThreadPool.QueueUserWorkItem(PotBotTask, 10);
        }

        void ProcExited(object sender, EventArgs e)
        {
            if(emulateFullScreen)
                StopFullscreenEmulation();
            proc = null;
            OnSacredExited();
        }

        void StartFullscreenEmulation()
        {
            SetTaskbarVisibility(false);
            ChangeScreenResoltion(emulationResolution.Width, emulationResolution.Height);
            blackScreen.Show();
            if (showClock || showGamingTime)
                timer.Start();
        }

        void StopFullscreenEmulation()
        {
            SetTaskbarVisibility(true);
            timer.Stop();
            blackScreen.Invoke(new VoidPtr(blackScreen.Close));
            ChangeScreenResoltion(nativeResolution.Width, nativeResolution.Height);
        }

        void TimerTick(object sender, EventArgs e)
        {
            blackScreen.Invalidate();
        }

        void BlackScreenPaint(object sender, PaintEventArgs e)
        {
            if (proc == null) return;
            
            Graphics g = e.Graphics;

            if (showClock)
            {
                string clock_text = DateTime.Now.ToShortTimeString();
                SizeF text_size = g.MeasureString(clock_text, uiFont);

                g.DrawString(clock_text, uiFont, Brushes.Red, blackScreen.ClientSize.Width - text_size.Width - 10, 10);
            }

            if (showGamingTime)
            {
                TimeSpan gamingTime = DateTime.Now - proc.StartTime;
                g.DrawString(string.Format("{0:00}:{1:00}", gamingTime.Hours, gamingTime.Minutes), uiFont, Brushes.Red, 10, 10);
            }
        }

        void BlackScreenActivated(object sender, EventArgs e)
        {
            if(proc != null && proc.MainWindowHandle != IntPtr.Zero)
                Win32.SetForegroundWindow(proc.MainWindowHandle);
        }

        void ChangeScreenResoltion(int width, int height)
        {
            DEVMODE1 dm = new DEVMODE1();
            dm.dmDeviceName = new String(new char[32]);
            dm.dmFormName = new String(new char[32]);
            dm.dmSize = (short)System.Runtime.InteropServices.Marshal.SizeOf(dm);

            if (Win32.EnumDisplaySettings(null, Win32.ENUM_CURRENT_SETTINGS, ref dm) != 0)
            {
                dm.dmPelsWidth = width;
                dm.dmPelsHeight = height;

                int result = Win32.ChangeDisplaySettings(ref dm, Win32.CDS_TEST);

                if (result != Win32.DISP_CHANGE_FAILED)
                {
                    Win32.ChangeDisplaySettings(ref dm, Win32.CDS_UPDATEREGISTRY);
                }
            }
        }

        void SetTaskbarVisibility(bool visibility)
        {
            int taskbar_handle = Win32.FindWindow("Shell_TrayWnd", "");
            int startbutton_handle = Win32.FindWindow("Button", "Start");

            if (taskbar_handle != 0)
                Win32.ShowWindow(taskbar_handle, visibility ? Win32.SW_SHOW : Win32.SW_HIDE);

            if (startbutton_handle != 0)
                Win32.ShowWindow(startbutton_handle, visibility ? Win32.SW_SHOW : Win32.SW_HIDE);
        }

        void PotBotTask(object data)
        {
            int interval = (int)data;
            IntPtr processHandle = Win32.OpenProcess(Win32.ProcessAccess.VmRead, false, proc.Id);

            int[] max_hp_offsets = { (int)proc.MainModule.BaseAddress + 0x6D3BC0, 0x4, 0x4, 0x4D4 };
            int[] cur_hp_offsets = { (int)proc.MainModule.BaseAddress + 0x6D3BC0, 0x4, 0x4, 0x4D8 };

            int max_hp_address;
            int cur_hp_address;

            byte[] dump = new byte[4];

            int max_hp = 0;
            int cur_hp = 0;
            int old_hp = 0;

            while (potBot && proc != null && !proc.HasExited)
            {
                max_hp_address = WinTweak.ReadPointer(processHandle, max_hp_offsets);
                cur_hp_address = WinTweak.ReadPointer(processHandle, cur_hp_offsets);

                if (max_hp_address >= proc.MainModule.BaseAddress.ToInt32() && cur_hp_address >= proc.MainModule.BaseAddress.ToInt32())
                {
                    Array.Clear(dump, 0, dump.Length);
                    WinTweak.ReadMemory(processHandle, max_hp_address, dump);
                    max_hp = BitConverter.ToInt32(dump, 0);

                    Array.Clear(dump, 0, dump.Length);
                    WinTweak.ReadMemory(processHandle, cur_hp_address, dump);
                    old_hp = cur_hp;
                    cur_hp = BitConverter.ToInt32(dump, 0);

                    if (ConsumePot(cur_hp, old_hp, max_hp))
                    {
                        WinTweak.SendKeyStroke(proc.MainWindowHandle, Keys.Space);
                        Thread.Sleep(100);
                    }
                }
                Thread.Sleep(interval);
            }

            Win32.CloseHandle(processHandle);
        }

        bool ConsumePot(float hp, float oldHp, float maxHp)
        {
            float damage = oldHp - hp;

            if (hp / maxHp <= 0.25f || (hp - damage) / maxHp <= 0.25f) return true;

            return false;
        }
        
    }
}
