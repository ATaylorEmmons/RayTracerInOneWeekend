using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace RayTracinginOneWeekend
{
    //From: https://stackoverflow.com/questions/24701703/c-sharp-faster-alternatives-to-setpixel-and-getpixel-for-bitmaps-for-windows-f
    public class FrameBuffer : IDisposable
    {
        public Bitmap Bitmap { get; private set; }
        public Int32[] Bits{ get; private set; }
        public bool Disposed { get; private set; }

        public int Height { get; private set; }
        public int Width { get; private set; }

        protected GCHandle BitsHandle { get; private set; }

        public FrameBuffer(int width, int height)
        {
            Width = width;
            Height = height;

            Bits = new int[width * height];
            BitsHandle = GCHandle.Alloc(Bits, GCHandleType.Pinned);
            Bitmap = new Bitmap(width, height, width * 4, PixelFormat.Format32bppPArgb, BitsHandle.AddrOfPinnedObject()); 
        }

        public void SetPixel(int x, int y, Color c)
        {
            int index = x + y * Width;
            int color = c.ToArgb();

            Bits[index] = color;
        }

        public void Dispose()
        {
            if (Disposed) return;

            Disposed = true;
            Bitmap.Dispose();
            BitsHandle.Free();
        }
    }
}
