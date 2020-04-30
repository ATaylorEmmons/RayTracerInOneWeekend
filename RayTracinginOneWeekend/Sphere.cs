using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RayTracinginOneWeekend
{
    public class Sphere : ICollidable
    {
        public Vector3 Center { get; set; }
        public float Radius {get; set; }

        public Sphere(Vector3 inCenter, float inRadius)
        {
            Center = inCenter;
            Radius = inRadius;
        }

        public Collision Collides(Ray r)
        {
            Collision ret = new Collision();
            Vector3 oc = r.Origin - this.Center;
            float a = r.Direction.LengthSquared();
            float b = 2.0f * oc.Dot(r.Direction);
            float c = oc.LengthSquared() - this.Radius*this.Radius;

            float disc = b * b - 4.0f * a * c;

            if(disc < 0)
            {
                ret.Collided = false;
            }
            else
            {
                float where = (-b - (float)Math.Sqrt(disc)) / (2.0f * a);

                ret.Collided = true;
                ret.Position = r.at(where);
                ret.Normal = (ret.Position - this.Center) / this.Radius;

                ret.FrontFace = ret.Normal.Dot(r.Direction) < 0;

                ret.Normal = ret.FrontFace ? ret.Normal : -ret.Normal;
            }

            return ret;
        }
    }
}
