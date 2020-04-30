using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RayTracinginOneWeekend
{
    public class Ray
    {
        public Vector3 Origin { get; set; }
        public Vector3 Direction { get; set; }

        public Ray(Vector3 inOrigin, Vector3 inDirection)
        {
            this.Origin = inOrigin;
            this.Direction = inDirection;
        }

        public Vector3 at(float a)
        {
            return this.Origin + a * this.Direction;
        }
    }
}
