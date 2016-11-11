using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            var bitmap = (Bitmap)Bitmap.FromFile("1.bmp");
            using (var bitmapEditor = new BitmapEditor(bitmap))
            {
                for (int i = 0; i < bitmap.Height; i++)
                    for (int j = 0; j < bitmap.Width; j++)
                    {
                        if (j % 3 == 0)
                            bitmapEditor.SetPixel(i, j, 255, 0, 0);
                        if (j % 3 == 1)
                            bitmapEditor.SetPixel(i, j, 0, 255, 0);
                        if (j % 3 == 2)
                            bitmapEditor.SetPixel(i, j, 0, 0, 255);
                    }
            }
            bitmap.Save("new.bmp");
        }
    }
}
