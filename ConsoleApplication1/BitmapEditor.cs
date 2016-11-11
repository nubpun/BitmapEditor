using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Drawing.Imaging;
using System.Runtime.InteropServices;

namespace ConsoleApplication1
{
    class BitmapEditor:IDisposable
    {
        private Bitmap bmp;
        private BitmapData bmpData;
        private byte[] rgbValues;
        public BitmapEditor(Bitmap bmp)
        {
            this.bmp = bmp;
            bmpData = bmp.LockBits(new Rectangle(0, 0, bmp.Width, bmp.Height), ImageLockMode.ReadWrite, bmp.PixelFormat);
            int numBytes = (bmp.Width * 3 + 1) * bmp.Height;
            rgbValues = new byte[numBytes];
            Marshal.Copy(bmpData.Scan0, rgbValues, 0, numBytes);
        }
        public void SetPixel(int x, int y, byte r, byte g, byte b)
        {
            int pos = x * (bmp.Width * 3 + 1) + y * 3;
            rgbValues[pos] = b;
            rgbValues[pos + 1] = g;
            rgbValues[pos + 2] = r;
        }

        public void Dispose()
        {
            Marshal.Copy(rgbValues, 0, bmpData.Scan0, rgbValues.Length);
            bmp.UnlockBits(bmpData);
        }
    }
}
