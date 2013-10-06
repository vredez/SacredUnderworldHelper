using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SacredUnderworldHelper.WinAPI
{
    class WinTweak
    {
        public static void SendKeyStroke(IntPtr windowHandle, Keys key)
        {
            uint scancode = Win32.MapVirtualKey((uint)key, 0);

            Int32 lParam = 1 << 31;
            lParam |= (int)scancode << 16;
            lParam |= 1;

            Win32.PostMessage(windowHandle, Win32.WM_KEYDOWN, (IntPtr)key, (IntPtr)lParam);
            Win32.PostMessage(windowHandle, Win32.WM_CHAR, (IntPtr)key, (IntPtr)lParam);
            Win32.PostMessage(windowHandle, Win32.WM_KEYUP, (IntPtr)key, (IntPtr)lParam);
        }

        public static void ReadMemory(IntPtr processHandle, int address, byte[] output)
        {
            IntPtr bytes_read = IntPtr.Zero;
            Win32.ReadProcessMemory(processHandle, (IntPtr)address, output, output.Length, out bytes_read);
        }

        public static int ReadPointer(IntPtr processHandle, int[] offsets)
        {
            if (offsets == null || offsets.Length == 0)
                return 0;
            else if (offsets.Length == 1)
            {
                byte[] result = new byte[4];
                ReadMemory(processHandle, offsets[0], result);
                return BitConverter.ToInt32(result, 0);
            }

            IntPtr bytes_read = IntPtr.Zero;
            byte[] dump = new byte[4];
            int address = offsets[0];

            for (int i = 1; i < offsets.Length; i++)
            {
                ReadMemory(processHandle, address, dump);
                address = BitConverter.ToInt32(dump, 0) + offsets[i];
            }

            return address;
        }

        public static void ReadPointerValue(IntPtr processHandle, int[] offsets, byte[] output)
        {
            ReadMemory(processHandle, ReadPointer(processHandle, offsets), output);
        }

        private WinTweak() { }
    }
}
