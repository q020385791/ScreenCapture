﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Drawing.Printing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Permissions;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using static PictureCapture.MouseHook;

namespace PictureCapture
{
    public partial class Form1 : Form
    {


        public Form1()
        {
            InitializeComponent();
        }

        public bool CaptureStart { get; set; } = false;
        Bitmap myImage = new Bitmap(Screen.PrimaryScreen.WorkingArea.Width, Screen.PrimaryScreen.WorkingArea.Height);
        //private void btnCapture_Click(object sender, EventArgs e)
        //{
            
        //}

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            MouseHook.stop();
        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            e.Graphics.DrawImage(myImage, 0, 0);
        }

        private void printPreviewDialog1_Load(object sender, EventArgs e)
        {
           
        }

        //螢幕截圖
        public void Printsrc() 
        {
            IntPtr hdc = GetDC(IntPtr.Zero);
            float ScaleX = (float)GetDeviceCaps(hdc, DESKTOPHORZRES) / (float)GetDeviceCaps(hdc, HORZRES);
            float ScaleY = (float)GetDeviceCaps(hdc, DESKTOPVERTRES) / (float)GetDeviceCaps(hdc, VERTRES);
            ReleaseDC(IntPtr.Zero, hdc);
            int ScreenWidth = (int)(SystemInformation.PrimaryMonitorSize.Width* ScaleX);
            int ScreenHeight = (int)(SystemInformation.PrimaryMonitorSize.Height * ScaleY);
            Bitmap TheImage = new Bitmap(ScreenWidth, ScreenHeight);
            Graphics memoryGraphics = Graphics.FromImage(TheImage);
            //memoryGraphics.CopyFromScreen(new Point(0, 0), new Point(0, 0), new Size(ScreenWidth, ScreenHeight));
            memoryGraphics.CopyFromScreen(new Point(0, 0), new Point(0, 0), new Size((int)ScreenWidth, (int)ScreenHeight));
            TheImage.Save(@"C:\Users\Wan\Desktop\test.jpg", ImageFormat.Jpeg);
        }

        [DllImport("gdi32")]
        static extern int GetDeviceCaps(IntPtr hdc, int nIndex);

        [DllImport("user32")]
        public static extern IntPtr GetDC(IntPtr hWnd);

        [DllImport("user32")]
        public static extern int ReleaseDC(IntPtr hWnd, IntPtr hDC);

        public const int HORZRES = 8;
        public const int VERTRES = 10;
        public const int DESKTOPVERTRES = 117;
        public const int DESKTOPHORZRES = 118;

        private int _PosX;
        private int _PosY;
        public int PosX 
        {
            get 
            {
                return _PosX;
            } set 
            {
                _PosX = value;
            } 
        
        }
        public int PosY
        {
            get
            {
                return _PosY;
            }
            set
            {
                _PosY = value;
            }

        }

        public string SetFakeConsole 
        {
            get { return FakeConsole.Text; }

            set 
            {
                FakeConsole.Text += value;
            
            } 
        }


        private void btnPaintOnScreen_Click(object sender, EventArgs e)
        {
            IntPtr desktopPtr = GetDC(IntPtr.Zero);
            Graphics g = Graphics.FromHdc(desktopPtr);
            Pen semiTransPen = new Pen(Color.FromArgb(128, 0, 0, 255), 15);
            //SolidBrush b = new SolidBrush(Color.White);
            //g.FillRectangle(b, new Rectangle(0, 0, 200, 200));
            Pen opaquePen = new Pen(Color.FromArgb(100, 50, 50, 100), 80);
            g.DrawLine(opaquePen, 0, 20, 100, 20);
            g.Dispose();
            ReleaseDC(IntPtr.Zero, desktopPtr);
            
        }

        private void btnFullScreenCapture_Click(object sender, EventArgs e)
        {

            Graphics myGraphics = this.CreateGraphics();
            Size s = Screen.PrimaryScreen.WorkingArea.Size;
            int ScreenWidth = (int)(Screen.PrimaryScreen.WorkingArea.Width * 1.5);
            int ScreenHeight = (int)(Screen.PrimaryScreen.WorkingArea.Height * 1.5);
            myImage = new Bitmap(ScreenWidth, ScreenHeight, myGraphics);
            Graphics memoryGraphics = Graphics.FromImage(myImage);
            memoryGraphics.CopyFromScreen(new Point(0, 0), new Point(0, 0), new Size(ScreenWidth, ScreenHeight));
            printDocument1.DefaultPageSettings.PaperSize = new PaperSize("First custom size", 100, 100);
            printPreviewDialog1.Document = printDocument1;
            //printPreviewDialog1.Show();
            Printsrc();

            //myImage.Save(@"C:\Users\Wan\Desktop\test.jpg", ImageFormat.Jpeg);
        }

        private void btnCapturePart_Click(object sender, EventArgs e)
        {
            //偵測一次ButtonDown and Up
            CaptureStart = true;
        }

        private void btnStartCpatureMouse_Click(object sender, EventArgs e)
        {
            MouseHook.Start();
            FakeConsole.Text = "Start Capture Moooouse";
            MouseHook.form = this;
        }

        private void btnStopCaptureMouse_Click(object sender, EventArgs e)
        {
            MouseHook.stop();
            FakeConsole.Text = "Stop Capture Moooouse";
            this.CaptureStart = false;
        }
    }
}
