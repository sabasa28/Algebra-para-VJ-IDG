using UnityEngine;
using System;
namespace CustomMath
{
    public struct Vec3 : IEquatable<Vec3>
    {
        #region Variables
        public float x;
        public float y;
        public float z;

        public float sqrMagnitude { get { return (x * x + y * y + z * z); } }
        public Vec3 normalized {
            get
            {
                Vec3 aux= new Vec3(x,y,z);
                return (aux/aux.magnitude);
            }
        }
        public float magnitude { get { return (float)Math.Sqrt(sqrMagnitude); } }
        #endregion

        #region Default Values
        public static Vec3 Zero { get { return new Vec3(0.0f, 0.0f, 0.0f); } }
        public static Vec3 One { get { return new Vec3(1.0f, 1.0f, 1.0f); } }
        public static Vec3 Forward { get { return new Vec3(0.0f, 0.0f, 1.0f); } }
        public static Vec3 Back { get { return new Vec3(0.0f, 0.0f, -1.0f); } }
        public static Vec3 Right { get { return new Vec3(1.0f, 0.0f, 0.0f); } }
        public static Vec3 Left { get { return new Vec3(-1.0f, 0.0f, 0.0f); } }
        public static Vec3 Up { get { return new Vec3(0.0f, 1.0f, 0.0f); } }
        public static Vec3 Down { get { return new Vec3(0.0f, -1.0f, 0.0f); } }
        public static Vec3 PositiveInfinity { get { return new Vec3(float.PositiveInfinity, float.PositiveInfinity, float.PositiveInfinity); } }
        public static Vec3 NegativeInfinity { get { return new Vec3(float.NegativeInfinity, float.NegativeInfinity, float.NegativeInfinity); } }
        #endregion                                                                                                                                                                               

        #region Constructors
        public Vec3(float x, float y)
        {
            this.x = x;
            this.y = y;
            this.z = 0.0f;
        }

        public Vec3(float x, float y, float z)
        {
            this.x = x;
            this.y = y;
            this.z = z;
        }

        public Vec3(Vec3 v3)
        {
            this.x = v3.x;
            this.y = v3.y;
            this.z = v3.z;
        }

        public Vec3(Vector3 v3)
        {
            this.x = v3.x;
            this.y = v3.y;
            this.z = v3.z;
        }

        public Vec3(Vector2 v2)
        {
            this.x = v2.x;
            this.y = v2.y;
            this.z = 0.0f;
        }
        #endregion

        #region Operators
        public static bool operator ==(Vec3 left, Vec3 right)
        {
            bool equalsX = left.x == right.x;
            bool equalsY = left.y == right.y;
            bool equalsZ = left.z == right.z;
            return (equalsX && equalsY && equalsZ);
        }
        public static bool operator !=(Vec3 left, Vec3 right)
        {
            return !(left == right);
        }

        public static Vec3 operator +(Vec3 leftV3, Vec3 rightV3)
        {
            return new Vec3(leftV3.x + rightV3.x, leftV3.y + rightV3.y, leftV3.z + rightV3.z);
        }

        public static Vec3 operator -(Vec3 leftV3, Vec3 rightV3)
        {
            return new Vec3(leftV3.x - rightV3.x, leftV3.y - rightV3.y, leftV3.z - rightV3.z);
        }
            
        public static Vec3 operator -(Vec3 v3)
        {
            return new Vec3(Zero - v3);
        }

        public static Vec3 operator *(Vec3 v3, float scalar)
        {
            return new Vec3(v3.x*scalar, v3.y*scalar, v3.z*scalar);
        }
        public static Vec3 operator *(float scalar, Vec3 v3)
        {
            return (v3 * scalar);
        }
        public static Vec3 operator /(Vec3 v3, float scalar)
        {
            return new Vec3(v3.x/scalar, v3.y/scalar, v3.z/scalar);
        }

        public static implicit operator Vector3(Vec3 v3)
        {
            return new Vector3(v3.x, v3.y, v3.z);
        }

        public static implicit operator Vector2(Vec3 v2)
        {
            return new Vector2(v2.x, v2.y);
        }
        #endregion

        #region Functions
        public override string ToString()
        {
            return "X = " + x.ToString() + "   Y = " + y.ToString() + "   Z = " + z.ToString();
        }
        public static float Angle(Vec3 from, Vec3 to)
        {
            return Mathf.Rad2Deg * (float)Math.Acos(Dot(from, to)/(Math.Sqrt(Math.Pow(from.x,2)+Math.Pow(from.y,2)+ Math.Pow(from.z,2))*Math.Sqrt(Math.Pow(to.x,2)+ Math.Pow(to.y,2)+ Math.Pow(to.z,2))));
        }
        public static Vec3 ClampMagnitude(Vec3 vector, float maxLength)
        {
            if (Magnitude(vector) > maxLength)
                return vector.normalized * maxLength;
            else
                return vector;
        }
        public static float Magnitude(Vec3 vector)
        {
            return (float)Math.Sqrt(Math.Pow(vector.x, 2) + Math.Pow(vector.y, 2) + Math.Pow(vector.z, 2));
        }
        public static Vec3 Cross(Vec3 a, Vec3 b)
        {
            return new Vec3(((a.y * b.z)-(a.z * b.y)),((a.z*b.x)-(a.x*b.z)),((a.x*b.y)-(a.y*b.x)));
        }
        public static float Distance(Vec3 a, Vec3 b)
        {
            a -= b;

            return Magnitude(a);
        }
        public static float Dot(Vec3 a, Vec3 b)
        {
            return ((a.x*b.x)+(a.y*b.y)+(a.z*b.z));
        }
        public static Vec3 Lerp(Vec3 a, Vec3 b, float t)
        {
            float aux = Mathf.Clamp(t,0,1);

            return a + new Vec3((b-a)* aux);
        }
        public static Vec3 LerpUnclamped(Vec3 a, Vec3 b, float t)
        {
            return a + new Vec3((b - a) * t);
        }
        public static Vec3 Max(Vec3 a, Vec3 b) 
        {
            float newX = a.x;
            float newY = a.y;
            float newZ = a.z;
            if (newX < b.x) newX = b.x;
            if (newY < b.y) newY = b.y;
            if (newZ < b.z) newZ = b.z;

            return new Vec3(newX,newY,newZ);
        }
        public static Vec3 Min(Vec3 a, Vec3 b)
        {
            float newX = a.x;
            float newY = a.y;
            float newZ = a.z;
            if (newX > b.x) newX = b.x;
            if (newY > b.y) newY = b.y;
            if (newZ > b.z) newZ = b.z;

            return new Vec3(newX, newY, newZ);
        }
        public static float SqrMagnitude(Vec3 vector)
        {
            return vector.sqrMagnitude;
        }
        public static Vec3 Project(Vec3 vector, Vec3 onNormal)
        {
            return (Dot(onNormal, vector) / Dot(onNormal, onNormal)) * onNormal; 
        }
        public static Vec3 Reflect(Vec3 inDirection, Vec3 inNormal) 
        {
            return inDirection - 2 * (Dot(inDirection, inNormal)) * inNormal;
        }
        public void Set(float newX, float newY, float newZ)
        {
            x = newX;
            y = newY;
            z = newZ;
        }
        public void Scale(Vec3 scale)
        {
            Set(x*scale.x,y*scale.y,z*scale.z);
        }

        public static Vec3 Scale(Vec3 a, Vec3 b)
        {
            return new Vec3(a.x * b.x, a.y * b.y, a.z * b.z);
        }
        public void Normalize()
        {
            Set(normalized.x,normalized.y,normalized.z);
        }
        public static Vec3 Normalize(Vec3 vector)
        {
            return new Vec3(vector.normalized.x, vector.normalized.y, vector.normalized.z);
        }
        
        #endregion

        #region Internals
        public override bool Equals(object other)
        {
            if (!(other is Vec3)) return false;
            return Equals((Vec3)other);
        }

        public bool Equals(Vec3 other)
        {
            return x == other.x && y == other.y && z == other.z;
        }

        public override int GetHashCode()
        {
            return x.GetHashCode() ^ (y.GetHashCode() << 2) ^ (z.GetHashCode() >> 2);
        }
        #endregion
    }
}