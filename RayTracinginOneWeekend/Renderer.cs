using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RayTracinginOneWeekend
{
    public class Renderer
    {
        List<ICollidable> renderList;

        public int Width { get; }
        public int Height { get; }

        FrameBuffer frameBuffer;

        static public Color Convert(Vector3 V)
        {
            int r = (int)(V.X * 255.9f);
            int g = (int)(V.Y * 255.9f);
            int b = (int)(V.Z * 255.9f);

            return Color.FromArgb(255, r, g, b);
        }

        public Renderer(int width, int height, ref FrameBuffer fBuffer)
        {
            renderList = new List<ICollidable>();
            frameBuffer = fBuffer;
            Width = width;
            Height = height;
        }

        public void Add(ICollidable collidable)
        {
            renderList.Add(collidable);
        }

        public void Render(Camera camera)
        {
            for (int j = 0; j < Height; j++)
            {
                for (int i = 0; i < Width; i++)
                {
                    float u = (float)i / Width;
                    float v = (float)j / Height;

                    Ray r = camera.Cast(u, v);
                    Vector3 vColor = RayColor(r);

                    Color c;

                    Collision collision = renderList[0].Collides(r);
                    if (collision.Collided)
                    {
                        Vector3 ranged = .5f * (collision.Normal + new Vector3(1.0f));
                        c = Renderer.Convert(ranged);
                    }
                    else
                    {
                        c = Renderer.Convert(vColor);
                    }

                    frameBuffer.SetPixel(i, j, c);
                }
            }
        }

        public Vector3 RayColor(Ray r)
        {
            Vector3 unitDirection = r.Direction.Normalized();
            float a = .5f * (unitDirection.Y + 1.0f);

            return (1.0f - a) * new Vector3(1.0f, 1.0f, 1.0f) + a * new Vector3(.5f, .7f, 1.0f);
        }

        
    }
}
