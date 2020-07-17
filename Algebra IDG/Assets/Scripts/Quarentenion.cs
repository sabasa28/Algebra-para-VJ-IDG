using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CustomMath;
using System;
using System.Reflection;
using UnityEngine.Bindings;
using UnityEngine.Internal;
using UnityEngine.Scripting;
using System.Runtime.CompilerServices;

namespace CustomMath
{
    public struct Quarentenion : IEquatable<Quarentenion>
    {
        public const float kEpsilon = 1E-06F;
        //
        // Resumen:
        //     X component of the Quaternion. Don't modify this directly unless you know quaternions
        //     inside out.
        public float x;
        //
        // Resumen:
        //     Y component of the Quaternion. Don't modify this directly unless you know quaternions
        //     inside out.
        public float y;
        //
        // Resumen:
        //     Z component of the Quaternion. Don't modify this directly unless you know quaternions
        //     inside out.
        public float z;
        //
        // Resumen:
        //     W component of the Quaternion. Do not directly modify quaternions.
        public float w;

        //
        // Resumen:
        //     Constructs new Quaternion with given x,y,z,w components.
        //
        // Parámetros:
        //   x:
        //
        //   y:
        //
        //   z:
        //
        //   w:
        public Quarentenion(float x, float y, float z, float w)
        {
            this.x = x;
            this.y = y;
            this.z = z;
            this.w = w;
        }

        public Quarentenion(Quaternion q)
        {
            x = q.x;
            y = q.y;
            z = q.z;
            w = q.w;
        }

        public Quarentenion(Quarentenion q)
        {
            x = q.x;
            y = q.y;
            z = q.z;
            w = q.w;
        }

        public float this[int index]
        {
            get
            {
                switch (index)
                {
                    case 0:
                        return x;
                    case 1:
                        return y;
                    case 2:
                        return z;
                    case 3:
                        return w;
                    default:
                        throw new IndexOutOfRangeException("Fuera de rango de Quarentenions! (0-3)");
                }
            }
            set
            {
                switch (index)
                {
                    case 0:
                        x = value;
                        break;
                    case 1:
                        y = value;
                        break;
                    case 2:
                        z = value;
                        break;
                    case 3:
                        w = value;
                        break;
                    default:
                        throw new IndexOutOfRangeException("Fuera de rango de Quarentenions! (0-3)");
                }
            }
        }

        //
        // Resumen:
        //     The identity rotation (Read Only).
        public static Quarentenion identity
        {
            get
            {
                return new Quarentenion(0.0f, 0.0f, 0.0f, 1.0f);
            }
        }
        //
        // Resumen:
        //     Returns or sets the euler angle representation of the rotation.
        public Vec3 eulerAngles
        {
            get
            {
                Vec3 qAsVec3;

                qAsVec3.x = Mathf.Rad2Deg * Mathf.Asin(x * 2);
                qAsVec3.y = Mathf.Rad2Deg * Mathf.Asin(y * 2);
                qAsVec3.z = Mathf.Rad2Deg * Mathf.Asin(z * 2);


                return qAsVec3;
            }
            set
            {
                eulerAngles = value;
            }
        }
        //
        // Resumen:
        //     Returns this quaternion with a magnitude of 1 (Read Only).
        public Quarentenion normalized
        {
            get
            {
                float mag = Mathf.Sqrt(x * x + y * y + z * z + w * w);
                Quaternion q = new Quaternion(x / mag, y / mag, z / mag, w / mag);
                return new Quarentenion(q.x, q.y, q.z, q.w);
            }
        }

        //
        // Resumen:
        //     Returns the angle in degrees between two rotations a and b.
        //
        // Parámetros:
        //   a:
        //
        //   b:
        public static float Angle(Quarentenion a, Quarentenion b)
        {
            Quarentenion inv = Inverse(a);
            Quarentenion result = b * inv;

            float angle = Mathf.Acos(result.w) * 2.0f * Mathf.Rad2Deg;
            return angle;
        }
        //
        // Resumen:
        //     Creates a rotation which rotates angle degrees around axis.
        //
        // Parámetros:
        //   angle:
        //
        //   axis:
        public static Quarentenion AngleAxis(float angle, Vector3 axis) ///revisar///
        {
            angle *= Mathf.Deg2Rad;
            angle /= 2.0f;
            axis.Normalize();
            Quarentenion newQ;
            newQ.x = axis.x * Mathf.Sin(angle);
            newQ.y = axis.y * Mathf.Sin(angle);
            newQ.z = axis.z * Mathf.Sin(angle);
            newQ.w = Mathf.Cos(angle);
            newQ.Normalize();
            return newQ;
        }
        //
        // Resumen:
        //     The dot product between two rotations.
        //
        // Parámetros:
        //   a:
        //
        //   b:
        public static float Dot(Quarentenion a, Quarentenion b)
        {
            return ((a.x * b.x) + (a.y * b.y) + (a.z * b.z) + (a.w * b.w));
        }
        //
        // Resumen:
        //     Returns a rotation that rotates z degrees around the z axis, x degrees around
        //     the x axis, and y degrees around the y axis.
        //
        // Parámetros:
        //   euler:
        public static Quarentenion Euler(Vec3 euler)
        {
            Quarentenion qX = identity;
            Quarentenion qY = identity;
            Quarentenion qZ = identity;

            float sin = Mathf.Sin(Mathf.Deg2Rad * euler.x * 0.5f);
            float cos = Mathf.Cos(Mathf.Deg2Rad * euler.x * 0.5f);
            qX.Set(sin, 0.0f, 0.0f, cos);

            sin = Mathf.Sin(Mathf.Deg2Rad * euler.y * 0.5f);
            cos = Mathf.Cos(Mathf.Deg2Rad * euler.y * 0.5f);
            qY.Set(0.0f, sin, 0.0f, cos);

            sin = Mathf.Sin(Mathf.Deg2Rad * euler.z * 0.5f);
            cos = Mathf.Cos(Mathf.Deg2Rad * euler.z * 0.5f);
            qZ.Set(0.0f, 0.0f, sin, cos);

            return new Quarentenion(qX * qY * qZ);
        }

        //
        // Resumen:
        //     Returns a rotation that rotates z degrees around the z axis, x degrees around
        //     the x axis, and y degrees around the y axis.
        //
        // Parámetros:
        //   x:
        //
        //   y:
        //
        //   z:
        public static Quarentenion Euler(float x, float y, float z)
        {
            return Euler(new Vec3(x, y, z));
        }
        public static Quarentenion EulerAngles(float x, float y, float z)
        {
            throw new NotImplementedException();
        }
        public static Quarentenion EulerAngles(Vector3 euler)
        {
            throw new NotImplementedException();
        }
        public static Quarentenion EulerRotation(float x, float y, float z)
        {
            throw new NotImplementedException();
        }
        public static Quarentenion EulerRotation(Vec3 euler)
        {
            throw new NotImplementedException();
        }



        //
        // Resumen:
        //     Creates a rotation which rotates from fromDirection to toDirection.
        //
        // Parámetros:
        //   fromDirection:
        //
        //   toDirection:

        public static Quarentenion FromToRotation(Vec3 fromDirection, Vec3 toDirection)
        {
            throw new NotImplementedException();
        }
        //
        // Resumen:
        //     Returns the Inverse of rotation.
        //
        // Parámetros:
        //   rotation:
        public static Quarentenion Inverse(Quarentenion rotation)
        {
            return new Quarentenion(-rotation.x, -rotation.y, -rotation.z, rotation.w);
        }
        //
        // Resumen:
        //     Interpolates between a and b by t and normalizes the result afterwards. The parameter
        //     t is clamped to the range [0, 1].
        //
        // Parámetros:
        //   a:
        //
        //   b:
        //
        //   t:
        public static Quarentenion Lerp(Quarentenion a, Quarentenion b, float t)
        {
            t = Mathf.Clamp(t, 0, 1);
            return LerpUnclamped(a, b, t);
        }
        //
        // Resumen:
        //     Interpolates between a and b by t and normalizes the result afterwards. The parameter
        //     t is not clamped.
        //
        // Parámetros:
        //   a:
        //
        //   b:
        //
        //   t:
        public static Quarentenion LerpUnclamped(Quarentenion a, Quarentenion b, float t)
        {
            Quarentenion difference = new Quarentenion(b.x - a.x, b.y - a.y, b.z - a.z, b.w - b.w);
            Quarentenion differenceLerped = new Quarentenion(difference.x * t, difference.y * t, difference.z * t, difference.w * t);

            return new Quarentenion(a.x + differenceLerped.x, a.y + differenceLerped.y, a.z + differenceLerped.z, a.w + differenceLerped.w).normalized;
        }
        //
        // Resumen:
        //     Creates a rotation with the specified forward and upwards directions.
        //
        // Parámetros:
        //   forward:
        //     The direction to look in.
        //
        //   upwards:
        //     The vector that defines in which direction up is.
        public static Quarentenion LookRotation(Vec3 forward)
        {
            throw new NotImplementedException();
        }
        //
        // Resumen:
        //     Creates a rotation with the specified forward and upwards directions.
        //
        // Parámetros:
        //   forward:
        //     The direction to look in.
        //
        //   upwards:
        //     The vector that defines in which direction up is.
        public static Quarentenion LookRotation(Vector3 forward, [DefaultValue("Vector3.up")] Vec3 upwards)
        {
            throw new NotImplementedException();
        }
        //
        // Resumen:
        //     Converts this quaternion to one with the same orientation but with a magnitude
        //     of 1.
        //
        // Parámetros:
        //   q:
        public static Quarentenion Normalize(Quarentenion q)
        {
            return new Quarentenion(q.normalized);
        }
        //
        // Resumen:
        //     Rotates a rotation from towards to.
        //
        // Parámetros:
        //   from:
        //
        //   to:
        //
        //   maxDegreesDelta:
        public static Quarentenion RotateTowards(Quarentenion from, Quarentenion to, float maxDegreesDelta)
        {
            throw new NotImplementedException();
        }
        //
        // Resumen:
        //     Spherically interpolates between a and b by t. The parameter t is clamped to
        //     the range [0, 1].
        //
        // Parámetros:
        //   a:
        //
        //   b:
        //
        //   t:
        public static Quarentenion Slerp(Quarentenion a, Quarentenion b, float t) //revisar
        {
            float angle = Angle(a, b);
            float angleLerped = angle * t;

            if (angleLerped > angle) angleLerped = angle;

            angleLerped *= Mathf.Deg2Rad;

            float sin;
            float cos;

            Quarentenion rotX;
            Quarentenion rotY;
            Quarentenion rotZ;
            Quarentenion q;

            sin = Mathf.Sin(angleLerped * 0.5f);
            cos = Mathf.Cos(angleLerped * 0.5f);
            rotX = new Quarentenion(sin, 0f, 0f, cos);

            sin = Mathf.Sin(angleLerped * 0.5f);
            cos = Mathf.Cos(angleLerped * 0.5f);
            rotY = new Quarentenion(0f, sin, 0f, cos);

            sin = Mathf.Sin(angleLerped * 0.5f);
            cos = Mathf.Cos(angleLerped * 0.5f);
            rotZ = new Quarentenion(0f, 0f, sin, cos);

            q = rotX * rotY * rotZ;
            return q.normalized;
        }
        //
        // Resumen:
        //     Spherically interpolates between a and b by t. The parameter t is not clamped.
        //
        // Parámetros:
        //   a:
        //
        //   b:
        //
        //   t:
        public static Quarentenion SlerpUnclamped(Quarentenion a, Quarentenion b, float t)
        {
            throw new NotImplementedException();
        }
        public bool Equals(Quarentenion other)
        {
            throw new NotImplementedException();
        }
        public override bool Equals(object other)
        {
            throw new NotImplementedException();
        }
        public override int GetHashCode()
        {
            throw new NotImplementedException();
        }
        public void Normalize()
        {
            Quarentenion normalQ = new Quarentenion(normalized);
            x = normalQ.x;
            y = normalQ.y;
            z = normalQ.z;
            w = normalQ.w;
        }
        //
        // Resumen:
        //     Set x, y, z and w components of an existing Quaternion.
        //
        // Parámetros:
        //   newX:
        //
        //   newY:
        //
        //   newZ:
        //
        //   newW:
        public void Set(float newX, float newY, float newZ, float newW)
        {
            x = newX;
            y = newY;
            z = newZ;
            w = newW;
        }
        //
        // Resumen:
        //     Creates a rotation which rotates from fromDirection to toDirection.
        //
        // Parámetros:
        //   fromDirection:
        //
        //   toDirection:
        public void SetFromToRotation(Vec3 fromDirection, Vec3 toDirection)
        {
            throw new NotImplementedException();
        }
        //
        // Resumen:
        //     Creates a rotation with the specified forward and upwards directions.
        //
        // Parámetros:
        //   view:
        //     The direction to look in.
        //
        //   up:
        //     The vector that defines in which direction up is.
        public void SetLookRotation(Vec3 view, [DefaultValue("Vector3.up")] Vec3 up)
        {
            throw new NotImplementedException();
        }
        //
        // Resumen:
        //     Creates a rotation with the specified forward and upwards directions.
        //
        // Parámetros:
        //   view:
        //     The direction to look in.
        //
        //   up:
        //     The vector that defines in which direction up is.
        public void SetLookRotation(Vec3 view)
        {
            throw new NotImplementedException();
        }
        public void ToAngleAxis(out float angle, out Vec3 axis)
        {
            throw new NotImplementedException();
        }
        //
        // Resumen:
        //     Returns a nicely formatted string of the Quaternion.
        //
        // Parámetros:
        //   format:
        public string ToString(string format)
        {
            throw new NotImplementedException();
        }
        //
        // Resumen:
        //     Returns a nicely formatted string of the Quaternion.
        //
        // Parámetros:
        //   format:
        public override string ToString()
        {
            return ("X = " + x + ", Y = " + y + ", Z = " + z + ", W = " + w);
        }

        public static Vec3 operator *(Quarentenion rotation, Vec3 point)
        {
            Quarentenion q = Euler(point);
            q *= rotation;
            return q.eulerAngles;
        }
        public static Quarentenion operator *(Quarentenion a, Quarentenion b)
        {
            float x = (a.w * b.x) + (a.x * b.w) + (a.y * b.z) - (a.z * b.y);
            float y = (a.w * b.y) - (a.x * b.z) + (a.y * b.w) + (a.z * b.x);
            float z = (a.w * b.z) + (a.x * b.y) - (a.y * b.x) + (a.z * b.w);
            float w = (a.w * b.w) - (a.x * b.x) - (a.y * b.y) - (a.z * b.z);
            return new Quarentenion(x, y, z, w);
        }
        public static bool operator ==(Quarentenion lhs, Quarentenion rhs)
        {
            if (lhs.x == rhs.x && lhs.y == rhs.y && lhs.z == rhs.z && lhs.w == rhs.w)
                return true;
            else
                return false;
            //throw new NotImplementedException();
        }
        public static bool operator !=(Quarentenion lhs, Quarentenion rhs)
        {
            throw new NotImplementedException();
        }

        public static implicit operator Quaternion(Quarentenion q)
        {
            return new Quaternion(q.x, q.y, q.z, q.w);
        }

        //public static implicit operator Quarentenion(Quaternion q)
        //{
        //    return new Quarentenion(q.x, q.y, q.z, q.w);
        //}
    }
}