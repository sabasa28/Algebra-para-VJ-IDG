using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CustomMath;
using System;
using System.Drawing;

namespace CustomMath
{
    //
    // Resumen:
    //     Representation of a plane in 3D space.
    [System.Serializable]
    public struct Plein 
    {
        
        //
        // Resumen:
        //     Creates a plane.
        //
        // Parámetros:
        //   inNormal:
        //
        //   inPoint:
        public Plein(Vec3 inNormal, Vec3 inPoint)
        {
            normal = inNormal;
            distance = inPoint.x; //WHAT QUE QUISE HACER ACA WTTTTTTTTTTTTTTTTTTF
        }

        //
        // Resumen:
        //     Creates a plane.
        //
        // Parámetros:
        //   a:
        //
        //   b:
        //
        //   c:
        public Plein(Vec3 a, Vec3 b, Vec3 c)
        {
            Vec3 side1 = b - a;
            Vec3 side2 = c - a;
            Debug.Log(side1);
            Debug.Log(side2);
            
            


            normal = Vec3.Cross(side1, side2).normalized;

            Debug.Log(Vec3.Distance(side2,Vec3.Zero));

            distance = (Vec3.Distance(a,Vec3.Zero)+ Vec3.Distance(b, Vec3.Zero)+ Vec3.Distance(c, Vec3.Zero))/3;
        }

        //
        // Resumen:
        //     Normal vector of the plane.
        public Vec3 normal { get; set; }

        //
        // Resumen:
        //     Distance from the origin to the plane.
        public float distance { get; set; }

        //
        // Resumen:
        //     Returns a copy of the plane that faces in the opposite direction.
        public Plein flipped 
        { 
            get {
                normal = -normal;

                return new Plein(normal, new Vec3(distance, 0, 0));
            } 
        }

        //
        // Resumen:
        //     Returns a copy of the given plane that is moved in space by the given translation.
        //
        // Parámetros:
        //   plane:
        //     The plane to move in space.
        //
        //   translation:
        //     The offset in space to move the plane with.
        //
        // Devuelve:
        //     The translated plane.
        public static Plein Translate(Plein plein, Vec3 translation)
        {
            throw new NotImplementedException();
        }
        //
        // Resumen:
        //     For a given point returns the closest point on the plane.
        //
        // Parámetros:
        //   point:
        //     The point to project onto the plane.
        //
        // Devuelve:
        //     A point on the plane that is closest to point.
        public Vec3 ClosestPointOnPlane(Vec3 point)
        {
            
            throw new NotImplementedException();
        }
        //
        // Resumen:
        //     Makes the plane face in the opposite direction.
        public void Flip()
        {
            throw new NotImplementedException();
        }
        //
        // Resumen:
        //     Returns a signed distance from plane to point.
        //
        // Parámetros:
        //   point:
        public float GetDistanceToPoint(Vec3 point)
        {
            throw new NotImplementedException();
        }
        //
        // Resumen:
        //     Is a point on the positive side of the plane?
        //
        // Parámetros:
        //   point:
        public bool GetSide(Vec3 point)
        {
            throw new NotImplementedException();
        }
        public bool Raycast(Ray ray, out float enter)
        {
            throw new NotImplementedException();
        }
        //
        // Resumen:
        //     Are two points on the same side of the plane?
        //
        // Parámetros:
        //   inPt0:
        //
        //   inPt1:
        public bool SameSide(Vector3 inPt0, Vector3 inPt1)
        {
            throw new NotImplementedException();
        }
        //
        // Resumen:
        //     Sets a plane using three points that lie within it. The points go around clockwise
        //     as you look down on the top surface of the plane.
        //
        // Parámetros:
        //   a:
        //     First point in clockwise order.
        //
        //   b:
        //     Second point in clockwise order.
        //
        //   c:
        //     Third point in clockwise order.
        public void Set3Points(Vec3 a, Vec3 b, Vec3 c)
        {
            throw new NotImplementedException();
        }
        //
        // Resumen:
        //     Sets a plane using a point that lies within it along with a normal to orient
        //     it.
        //
        // Parámetros:
        //   inNormal:
        //     The plane's normal vector.
        //
        //   inPoint:
        //     A point that lies on the plane.
        public void SetNormalAndPosition(Vec3 inNormal, Vec3 inPoint)
        {
            throw new NotImplementedException();
        }
        public override string ToString()
        {
            return "(normal:"+normal.ToString()+", distance:"+distance+")";
        }
        public string ToString(string format)
        {
            throw new NotImplementedException();
        }
        //
        // Resumen:
        //     Moves the plane in space by the translation vector.
        //
        // Parámetros:
        //   translation:
        //     The offset in space to move the plane with.
        public void Translate(Vector3 translation)
        {
            throw new NotImplementedException();
        }
    }
}

