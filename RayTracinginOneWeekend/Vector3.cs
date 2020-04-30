using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RayTracinginOneWeekend
{
    public class Vector3
    {
        float[] values;
        
        public float X
        {
            get { return values[0]; }
            set { values[0] = value; }
        }

        public float Y
        {
            get { return values[1]; }
            set { values[1] = value; }
        }

        public float Z
        {
            get { return values[2]; }
            set { values[2] = value; }
        }

        public Vector3(float x, float y, float z)
        {
            values = new float[]{ x, y, z};
        }

        public Vector3(float a)
        {
            values = new float[] { a, a, a};
        }

        public float Dot(Vector3 V)
        {
            return this.X * V.X + this.Y * V.Y + this.Z * V.Z;
        }

        public Vector3 Cross(Vector3 V)
        {
            return new Vector3(
                  this.Y * V.Z - this.Z * V.Y,
                  this.Z * V.X - this.X * V.Z,
                  this.X * V.Y - this.Y * V.X
              );
        }

        public float LengthSquared()
        {
            return this.X * this.X + this.Y * this.Y + this.Z * this.Z;
        }

        public float Length()
        {
            return (float)Math.Sqrt(this.LengthSquared());
        }

        public static Vector3 operator +(Vector3 U, Vector3 V)
        {
            return new Vector3(U.X + V.X, U.Y + V.Y, U.Z + V.Z);
        }

        public static Vector3 operator -(Vector3 U)
        {
            return new Vector3(-U.X, -U.Y, -U.Z);
        }

        public static Vector3 operator -(Vector3 U, Vector3 V)
        {
            return new Vector3(U.X - V.X, U.Y - V.Y, U.Z - V.Z);
        }

        public static Vector3 operator *(float a, Vector3 U)
        {
            return new Vector3(a * U.X, a * U.Y, a * U.Z);
        }

        public static Vector3 operator *( Vector3 U, float a)
        {
            return new Vector3(a * U.X, a * U.Y, a * U.Z);
        }

        /// <summary>
        /// Hadmard Product
        /// </summary>
        /// <param name="U"></param>
        /// <param name="V"></param>
        /// <returns></returns>
        public static Vector3 operator *(Vector3 U, Vector3 V)
        {
            return new Vector3(U.X*V.X, U.Y*V.Y, U.Z*V.Z);
        }

        public static Vector3 operator /(float a, Vector3 U)
        {
            return new Vector3(1/a * U.X, 1/a * U.Y, 1/a * U.Z);
        }

        public static Vector3 operator /(Vector3 U, float a)
        {
            return new Vector3(1/a * U.X, 1/a * U.Y, 1/a * U.Z);
        }

        /// <summary>
        /// Hadmard Product
        /// </summary>
        /// <param name="U"></param>
        /// <param name="V"></param>
        /// <returns></returns>
        public static Vector3 operator /(Vector3 U, Vector3 V)
        {
            return new Vector3(U.X / V.X, U.Y / V.Y, U.Z / V.Z);
        }


        public Vector3 Normalized()
        {
            return this / this.Length();
        }
    }
}
