using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows.Forms;
using System.ComponentModel;

namespace AcToolsLibrary.Common.Windows
{
    public class AcMouseHelper
    {
        public enum SystemMetric
        {
            SM_CXSCREEN = 0,
            SM_CYSCREEN = 1,
        }

        public enum INPUT_TYPE : uint
        {
            INPUT_MOUSE = 0,
            INPUT_KEYBOARD = 1,
            INPUT_HARDWARE = 2
        }

        public enum KEYEVENTF : uint
        {
            KEYEVENTF_EXTENDEDKEY = 0x0001,
            KEYEVENTF_KEYUP = 0x0002,
            KEYEVENTF_UNICODE = 0x0004,
            KEYEVENTF_SCANCODE = 0x0008
        }

        public enum XBUTTON : uint
        {
            XBUTTON1 = 0x0001,
            XBUTTON2 = 0x0002
        }

        public enum MOUSEEVENTF : uint
        {
            MOUSEEVENTF_MOVE = 0x0001,
            MOUSEEVENTF_LEFTDOWN = 0x0002,
            MOUSEEVENTF_LEFTUP = 0x0004,
            MOUSEEVENTF_RIGHTDOWN = 0x0008,
            MOUSEEVENTF_RIGHTUP = 0x0010,
            MOUSEEVENTF_MIDDLEDOWN = 0x0020,
            MOUSEEVENTF_MIDDLEUP = 0x0040,
            MOUSEEVENTF_XDOWN = 0x0080,
            MOUSEEVENTF_XUP = 0x0100,
            MOUSEEVENTF_WHEEL = 0x0800,
            MOUSEEVENTF_VIRTUALDESK = 0x4000,
            MOUSEEVENTF_ABSOLUTE = 0x8000
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct MOUSEINPUT
        {
            public long dx;
            public long dy;
            public uint mouseData;
            public MOUSEEVENTF dwFlags;
            public uint time;
            public UIntPtr dwExtraInfo;
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct KEYBDINPUT
        {
            public ushort wVk;
            public ushort wScan;
            public uint dwFlags;
            public uint time;
            public UIntPtr dwExtraInfo;
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct HARDWAREINPUT
        {
            uint uMsg;
            ushort wParamL;
            ushort wParamH;
        }

        [StructLayout(LayoutKind.Explicit)]
        public struct MOUSEKEYBDHARDWAREINPUT
        {
            [FieldOffset(0)]
            public HARDWAREINPUT hi;
            [FieldOffset(0)]
            public KEYBDINPUT ki;
            [FieldOffset(0)]
            public MOUSEINPUT mi;
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct INPUT
        {
            public INPUT_TYPE type;
            public MOUSEKEYBDHARDWAREINPUT data;
        }

        //[StructLayout(LayoutKind.Explicit)]
        //public struct INPUT
        //{
        //    [FieldOffset(0)]
        //    public INPUT_TYPE type;
        //    [FieldOffset(4)] //*
        //    public MOUSEINPUT mi;
        //    [FieldOffset(4)] //*
        //    public KEYBDINPUT ki;
        //    [FieldOffset(4)] //*
        //    public HARDWAREINPUT hi;
        //}


        const uint FORMAT_MESSAGE_ALLOCATE_BUFFER = 0x00000100;
        const uint FORMAT_MESSAGE_IGNORE_INSERTS = 0x00000200;
        const uint FORMAT_MESSAGE_FROM_SYSTEM = 0x00001000;
        const uint FORMAT_MESSAGE_ARGUMENT_ARRAY = 0x00002000;
        const uint FORMAT_MESSAGE_FROM_HMODULE = 0x00000800;
        const uint FORMAT_MESSAGE_FROM_STRING = 0x00000400;

        [DllImport("user32.dll")]
        public static extern void mouse_event(MOUSEEVENTF dwFlags, UInt32 dx, int UInt32, UInt32 dwData, UIntPtr dwExtraInfo);

        /// <summary>
        /// Synthesizes keystrokes, mouse motions, and button clicks.
        /// </summary>
        [DllImport("user32.dll")]
        public static extern uint SendInput(uint nInputs, [MarshalAs(UnmanagedType.LPArray), In] INPUT[] pInputs, int cbSize);

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern IntPtr SendMessage(IntPtr hWnd, AcWinAPI.WM Msg, IntPtr wParam, StringBuilder lParam);

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern IntPtr SendMessage(IntPtr hWnd, AcWinAPI.WM Msg, IntPtr wParam, [MarshalAs(UnmanagedType.LPWStr)] string lParam);

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern IntPtr SendMessage(IntPtr hWnd, AcWinAPI.WM Msg, int wParam, [MarshalAs(UnmanagedType.LPWStr)] string lParam);

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern IntPtr SendMessage(IntPtr hWnd, AcWinAPI.WM Msg, int wParam, ref IntPtr lParam);

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern IntPtr SendMessage(IntPtr hWnd, AcWinAPI.WM Msg, int wParam, IntPtr lParam);

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern IntPtr SendMessage(IntPtr hWnd, AcWinAPI.WM Msg, int wParam, int lParam);

        [DllImport("kernel32.dll", SetLastError = true)]
        public static extern uint GetLastError();

        [DllImport("user32.dll")]
        public static extern int GetSystemMetrics(SystemMetric smIndex);

        [DllImport("user32.dll")]
        public static extern IntPtr FindWindowEx(IntPtr hwndParent, IntPtr hwndChildAfter, string lpszClass, string lpszWindow);

        [DllImport("User32.Dll", EntryPoint = "PostMessageA")]
        public static extern bool PostMessage(IntPtr hWnd, uint msg, int wParam, int lParam);

        [DllImport("user32.dll")]
        public static extern IntPtr SetFocus(IntPtr hWnd);

        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool SetForegroundWindow(IntPtr hWnd);

        [DllImport("user32.dll")]
        public static extern IntPtr GetMessageExtraInfo();

        [DllImport("kernel32.dll", SetLastError = true)]
        static extern uint FormatMessage(uint dwFlags, IntPtr lpSource, uint dwMessageId, uint dwLanguageId, [Out] StringBuilder lpBuffer, uint nSize, string[] Arguments);


        public static int CalculateAbsoluteCoordinateX(int x)
        {
            return (x * 65536) / GetSystemMetrics(SystemMetric.SM_CXSCREEN);
        }

        public static int CalculateAbsoluteCoordinateY(int y)
        {
            return (y * 65536) / GetSystemMetrics(SystemMetric.SM_CYSCREEN);
        }

        public static void MouseLeftClick(int x, int y)
        {
            int lParam = (y << 16) + x;

            INPUT[] inputs = new INPUT[1];
            inputs[0].type = INPUT_TYPE.INPUT_MOUSE;
            //inputs[0].data.mi.dx = CalculateAbsoluteCoordinateX(x);
            //inputs[0].data.mi.dy = CalculateAbsoluteCoordinateY(y);
            inputs[0].data.mi.dx = x;
            inputs[0].data.mi.dy = y;
            inputs[0].data.mi.mouseData = 0;
            inputs[0].data.mi.dwFlags = MOUSEEVENTF.MOUSEEVENTF_LEFTDOWN | MOUSEEVENTF.MOUSEEVENTF_ABSOLUTE;
            inputs[0].data.mi.time = 0;

            /*
            uint intReturn = SendInput(1, inputs, Marshal.SizeOf(inputs[0]));
            if (intReturn != 1)
            {
                //string errorMessage = new Win32Exception(Marshal.GetLastWin32Error()).Message;
                string errorMessage = new Win32Exception((int)GetLastError()).Message;
                //uint t = GetLastError();
                // see the sample code
                throw new Exception("Could not send Left Down!");
            }
            */

            Thread.Sleep(10);

            inputs = new INPUT[1];
            inputs[0].type = INPUT_TYPE.INPUT_MOUSE;
            //inputs[0].data.mi.dx = CalculateAbsoluteCoordinateX(x);
            //inputs[0].data.mi.dy = CalculateAbsoluteCoordinateY(y);
            inputs[0].data.mi.dx = x;
            inputs[0].data.mi.dy = y;
            inputs[0].data.mi.mouseData = 0;
            inputs[0].data.mi.dwFlags = MOUSEEVENTF.MOUSEEVENTF_LEFTUP | MOUSEEVENTF.MOUSEEVENTF_ABSOLUTE;
            inputs[0].data.mi.time = 0;

            /*
            intReturn = SendInput(1, inputs, Marshal.SizeOf(inputs[0]));
            if (intReturn != 1)
            {
                //string errorMessage = new Win32Exception(Marshal.GetLastWin32Error()).Message;
                string errorMessage = new Win32Exception((int)GetLastError()).Message;
                //uint t = GetLastError();
                throw new Exception("Could not send Left Up!");
            }
            */
        }

        public static void MouseMove(Int32 x, Int32 y)
        {
            Cursor.Position = new System.Drawing.Point(x, y);
        }

        public static void MouseLeftClick()
        {
            mouse_event(MOUSEEVENTF.MOUSEEVENTF_LEFTDOWN, 0, 0, 0, UIntPtr.Zero);
            mouse_event(MOUSEEVENTF.MOUSEEVENTF_LEFTUP, 0, 0, 0, UIntPtr.Zero);
        }

    }
}
