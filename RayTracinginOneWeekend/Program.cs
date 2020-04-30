using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Drawing;
using System.Windows.Forms;

namespace RayTracinginOneWeekend
{
    class Program
    {
        static void Main(string[] args)
        {
            int width = 1280;
            int height = 720;
            Form displayWindow = new Form();
            displayWindow.FormBorderStyle = FormBorderStyle.FixedSingle;
            displayWindow.Bounds = new System.Drawing.Rectangle(0, 0, width, height);


            FrameBuffer frameBuffer = new FrameBuffer(width, height);
            Renderer renderer = new Renderer(width, height, ref frameBuffer);
            Camera camera = new Camera();


            Sphere s = new Sphere(new Vector3(0.0f, 0.0f, -1.0f), .5f);

            renderer.Add(s);
            renderer.Render(camera);

            frameBuffer.Bitmap.Save("output.bmp");



            displayWindow.BackgroundImage = frameBuffer.Bitmap;
            Application.EnableVisualStyles();
            Application.Run(displayWindow);

        }
    }
}
