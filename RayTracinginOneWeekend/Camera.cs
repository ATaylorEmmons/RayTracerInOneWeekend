using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RayTracinginOneWeekend
{
    public class Camera
    {

        public Vector3 upperLeft;
        public Vector3 horizontal;
        public Vector3 vertical;
        public Vector3 origin;

        public Camera()
        {
            upperLeft = new Vector3(-2.0f, 1.0f, -1.0f);
            horizontal = new Vector3(4.0f, 0.0f, 0.0f);
            vertical = new Vector3(0.0f, -2.0f, 0.0f);
            origin = new Vector3(0.0f, 0.0f, 0.0f);
        }

        public Ray Cast(float u, float v)
        {
            return new Ray(origin, upperLeft + u * horizontal + v * vertical);
        }
    }
}
