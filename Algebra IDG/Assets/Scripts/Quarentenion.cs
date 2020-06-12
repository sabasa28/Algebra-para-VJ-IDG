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

    public float this[int index] {
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
    public static Quarentenion identity { get; }
    //
    // Resumen:
    //     Returns or sets the euler angle representation of the rotation.
    public Vec3 eulerAngles {
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
            return new Quarentenion (q.x, q.y, q.z, q.w);
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
        throw new NotImplementedException();
    }
    //
    // Resumen:
    //     Creates a rotation which rotates angle degrees around axis.
    //
    // Parámetros:
    //   angle:
    //
    //   axis:
    public static Quarentenion AngleAxis(float angle, Vector3 axis)
    {
        throw new NotImplementedException();
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
        throw new NotImplementedException();
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
        throw new NotImplementedException();
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
        throw new NotImplementedException();
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
        throw new NotImplementedException();
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
        return new Quarentenion(q.normalized.x, q.normalized.y, q.normalized.z, q.normalized.y) ;
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
    public static Quarentenion Slerp(Quarentenion a, Quarentenion b, float t)
    {
        throw new NotImplementedException();
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
        throw new NotImplementedException();
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
        throw new NotImplementedException();
    }
    public static Quarentenion operator *(Quarentenion lhs, Quarentenion rhs)
    {
        throw new NotImplementedException();
    }
    public static bool operator ==(Quarentenion lhs, Quarentenion rhs)
    {
        throw new NotImplementedException();
    }
    public static bool operator !=(Quarentenion lhs, Quarentenion rhs)
    {
        throw new NotImplementedException();
    }
}

