using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using static PictureCapture.Form1;
namespace PictureCapture
{
    public static class MouseHook

    {
        public static Form1 form;
        public static event EventHandler MouseAction = delegate { };
        public static Point StartPoint { get; set; }
        public static Point EndPoint { get; set; }
        public static void Start()
        {
            _hookID = SetHook(_proc);

        }

        public static void stop()
        {
            UnhookWindowsHookEx(_hookID);
        }
        private static LowLevelMouseProc _proc = HookCallback;
        private static IntPtr _hookID = IntPtr.Zero;

        private static IntPtr SetHook(LowLevelMouseProc proc)
        {
            using (Process curProcess = Process.GetCurrentProcess())
            using (ProcessModule curModule = curProcess.MainModule)
            {
                return SetWindowsHookEx(WH_MOUSE_LL, proc,
                  GetModuleHandle(curModule.ModuleName), 0);
            }
        }

        private delegate IntPtr LowLevelMouseProc(int nCode, IntPtr wParam, IntPtr lParam);

         static bool IfKeyDown = false;
        static Point[] StartAndEndPoint = new Point[4];
        private static IntPtr HookCallback(
          int nCode, IntPtr wParam, IntPtr lParam)
        {
            //按下左鍵
            if (nCode >= 0 && MouseMessages.WM_LBUTTONDOWN == (MouseMessages)wParam)
            {
                
                MSLLHOOKSTRUCT hookStruct = (MSLLHOOKSTRUCT)Marshal.PtrToStructure(lParam, typeof(MSLLHOOKSTRUCT));
                MouseAction(null, new EventArgs());
                //x,y座標
                Console.WriteLine((MouseMessages)wParam + "," + hookStruct.pt.x.ToString() + "," + hookStruct.pt.y.ToString());

                StartPoint = new Point((int)(hookStruct.pt.x),(int)(hookStruct.pt.y));
                form.SetFakeConsole = "Start Point " + StartPoint.X + StartPoint.Y;
                form.SetFakeConsole = form.CaptureStart.ToString();
                if (form.CaptureStart==true)
                {
                    StartAndEndPoint[0] = new Point ( StartPoint.X, StartPoint.Y );
                    form.SetFakeConsole = "KeyDown Capture";
                    //截圖開始點
                    StartPoint = new Point(StartPoint.X, StartPoint.Y);
                    IfKeyDown = true;
                }
            }
            
            //放開左鍵
            if (nCode >= 0 && MouseMessages.WM_LBUTTONUP == (MouseMessages)wParam)
            {

                MSLLHOOKSTRUCT hookStruct = (MSLLHOOKSTRUCT)Marshal.PtrToStructure(lParam, typeof(MSLLHOOKSTRUCT));
                MouseAction(null, new EventArgs());
                //x,y座標
                Console.WriteLine((MouseMessages)wParam + "," + hookStruct.pt.x.ToString() + "," + hookStruct.pt.y.ToString());
                EndPoint = new Point(hookStruct.pt.x, hookStruct.pt.y);
                form.SetFakeConsole = "End Point " + EndPoint.X + EndPoint.Y;
                
                if (form.CaptureStart == true)
                {
                    StartAndEndPoint[1] = new Point(EndPoint.X, EndPoint.Y);
                    form.SetFakeConsole = "KeyUp Capture";
                    EndPoint = new Point(EndPoint.X, EndPoint.Y);
                    //截圖結束點
                    form.CaptureStart = false;
                    IfKeyDown = false;

                }
            }
            //滑鼠移動中
            if (nCode >= 0 && MouseMessages.WM_MOUSEMOVE == (MouseMessages)wParam)
            {
                MSLLHOOKSTRUCT hookStruct = (MSLLHOOKSTRUCT)Marshal.PtrToStructure(lParam, typeof(MSLLHOOKSTRUCT));
                MouseAction(null, new EventArgs());
                Console.WriteLine((MouseMessages)wParam + "," + hookStruct.pt.x.ToString() + "," + hookStruct.pt.y.ToString());
                form.PosX = hookStruct.pt.x;   
                form.PosY = hookStruct.pt.y;
                //如果KeyDown且開始捕捉畫面
                if (IfKeyDown&&form.CaptureStart)
                {
                    IntPtr desktopPtr = GetDC(IntPtr.Zero);
                    Graphics g = Graphics.FromHdc(desktopPtr);
                    Pen opaquePen = new Pen(Color.FromArgb(128, 0, 0, 100), 1);
                    StartAndEndPoint[0] = StartPoint;
                    StartAndEndPoint[1] = new Point(StartPoint.X-(StartPoint.X- hookStruct.pt.x), StartPoint.Y);
                    StartAndEndPoint[2] = new Point(hookStruct.pt.x, hookStruct.pt.y);
                    StartAndEndPoint[3] = new Point(StartPoint.X, hookStruct.pt.y);
                    g.DrawPolygon(opaquePen,StartAndEndPoint);
                    g.Dispose();
                    ReleaseDC(IntPtr.Zero, desktopPtr);
                }
            }

            return CallNextHookEx(_hookID, nCode, wParam, lParam);
        }

        private const int WH_MOUSE_LL = 14;

        private enum MouseMessages
        {
            WM_LBUTTONDOWN = 0x0201,
            WM_LBUTTONUP = 0x0202,
            WM_MOUSEMOVE = 0x0200,
            WM_MOUSEWHEEL = 0x020A,
            WM_RBUTTONDOWN = 0x0204,
            WM_RBUTTONUP = 0x0205
        }

        [StructLayout(LayoutKind.Sequential)]
        private struct POINT
        {
            public int x;
            public int y;
        }

        [StructLayout(LayoutKind.Sequential)]
        private struct MSLLHOOKSTRUCT
        {
            public POINT pt;
            public uint mouseData;
            public uint flags;
            public uint time;
            public IntPtr dwExtraInfo;
        }

        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern IntPtr SetWindowsHookEx(int idHook,
          LowLevelMouseProc lpfn, IntPtr hMod, uint dwThreadId);

        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool UnhookWindowsHookEx(IntPtr hhk);

        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern IntPtr CallNextHookEx(IntPtr hhk, int nCode,
          IntPtr wParam, IntPtr lParam);
        [DllImport("kernel32.dll", CharSet = CharSet.Auto)]
        public static extern IntPtr GetModuleHandle(string lpModuleName);
    }
}
