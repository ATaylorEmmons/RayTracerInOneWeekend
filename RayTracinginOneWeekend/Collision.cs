using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RayTracinginOneWeekend
{
    public struct Collision
    {
        public bool Collided;
        public Vector3 Position;
        public Vector3 Normal;

        public bool FrontFace;
        public float time;
    }
}
