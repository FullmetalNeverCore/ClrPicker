using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace ClrPickerWPF.back
{
    public class ColorPicker
    {
        [StructLayout(LayoutKind.Sequential)]
        public struct POINT
        {
            public int X;
            public int Y;
        }

        [DllImport("user32.dll")]
        static extern bool GetCursorPos(out POINT lpoint);

        [DllImport("gdi32.dll")]
        static extern uint GetPixel(IntPtr hdc, int nXPos, int nYPos);

        [DllImport("user32.dll")]
        static extern IntPtr GetDC(IntPtr hwnd);

        [DllImport("user32.dll")]
        static extern int ReleaseDC(IntPtr hwnd, IntPtr hdc);

        public System.Windows.Media.Color getColor()
        {
            POINT p;
            IntPtr hdc = IntPtr.Zero;
            if (!GetCursorPos(out p))
            {
                throw new InvalidOperationException("Was not able to obtain cursor position!");
            }
            try
            {
                hdc = GetDC(IntPtr.Zero);
                uint pixel = GetPixel(hdc, p.X, p.Y);
                ReleaseDC(IntPtr.Zero, hdc);
                System.Windows.Media.Color color =
                    System.Windows.Media.Color.FromRgb((byte)(pixel & 0x0000FF),
                    (byte)((pixel & 0x00FF00) >> 8),
                    (byte)((pixel & 0xFF0000) >> 16));
                return color;
            }
            finally
            {
                if (hdc != IntPtr.Zero)
                {
                    ReleaseDC(IntPtr.Zero, hdc);
                }
            }
        }

    }

}
