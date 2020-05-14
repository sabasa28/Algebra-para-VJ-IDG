using System.Collections.Generic;
using UnityEngine;
using MathDebbuger;
using CustomMath;

public class Tester : MonoBehaviour
{
    void Start()
    {
        VectorDebugger.EnableCoordinates();
        /*List<Vector3> vectors = new List<Vector3>();
        vectors.Add(new Vec3(10.0f, 0.0f, 0.0f));
        vectors.Add(new Vec3(10.0f, 10.0f, 0.0f));
        vectors.Add(new Vec3(20.0f, 10.0f, 0.0f));
        vectors.Add(new Vec3(20.0f, 20.0f, 0.0f));
        VectorDebugger.AddVectorsSecuence(vectors, true, Color.red, "secuencia"); //si es true el 0 es 0,0,0 sino es el primer elemento
        VectorDebugger.AddVector(new Vector3(10, 10, 0), Color.blue, "elAzul");
        VectorDebugger.AddVector(Vector3.down * 7, Color.green, "elVerde");
        */


        #region Fuego
        VectorDebugger.EnableEditorView();

        Plein b = new Plein(new Vec3(2, 10, 10), new Vec3(20, 0, 10), new Vec3 (3,2,1));
        Plane c = new Plane(new Vector3(2, 10, 10), new Vector3(20, 0, 10), new Vec3(3, 2, 1));

        Debug.Log(b);
        Debug.Log(c);

        b.Set3Points(new Vec3(2, 10, 10), new Vec3(20, 0, 10), new Vec3(3, 2, 1));
        c.Set3Points(new Vec3(2, 10, 10), new Vec3(20, 0, 10), new Vec3(3, 2, 1));

        Debug.Log(b.ClosestPointOnPlane(new Vec3(-50, 100, 100)));
        Debug.Log(c.ClosestPointOnPlane(new Vec3(-50, 100, 100)));


        //Debug.Log(b.GetDistanceToPoint(new Vec3(1, 1, 1)));
        //Debug.Log(c.GetDistanceToPoint(new Vec3(1, 1, 1)));
        //
        //Debug.Log(b.SameSide(new Vec3(-40, 11, 11),new Vec3 (-40,-10,11)));
        //Debug.Log(c.SameSide(new Vec3(-40, 11, 11), new Vec3 (-40,-10,11)));
        //
        //b.SetNormalAndPosition(new Vec3(2, 10, 10), new Vec3(20, 0, 10));
        //c.SetNormalAndPosition(new Vector3(2, 10, 10), new Vector3(20, 0, 10));
        //
        //Debug.Log("Plano =" + b.ToString());
        //Debug.Log("Plano unity =" + c.ToString());

        //Plein d = new Plein(new Vec3(4, 5, 1), new Vec3(10, 0, 12));
        //
        //Plane e = new Plane(new Vec3(4, 5, 1), new Vec3(10, 0, 12));
        //
        //Debug.Log("Plano =" + b.ToString());
        //Debug.Log("Plano =" + c);
        //
        //
        //Debug.Log("Flipped =" + b.flipped.ToString());
        //Debug.Log("Flipped =" + c.flipped);
        //
        //b.Flip();
        //c.Flip();
        //
        //Debug.Log("Plano flipped =" + b.ToString());
        //Debug.Log("Plano flipped =" + c);
        //
        //
        //Debug.Log("Translate =" + Plein.Translate(b, new Vec3(-10, 12, 1)).ToString());
        //Debug.Log("Translate =" + Plane.Translate(c, new Vector3(-10, 12, 1)));


        //Debug.Log(d.ToString());
        //Debug.Log(e);


        /*test ik
        Vector3 planeA;
        Vector3 planeB;
        Vector3 planeC;

        planeA = new Vector3(10, 20, 5);
        planeB = new Vector3(10, 0, 50);
        planeC = new Vector3(1, 20, 3);
        Vec3 planesA = new Vec3(planeA);
        Vec3 planesB = new Vec3(planeB);
        Vec3 planesC = new Vec3(planeC);


        Plane plane = new Plane(planeA, planeB, planeC);
        Plein planes = new Plein(planesA, planesB, planesC);

        Vec3 prueba = new Vec3(10, 3, 12);

        Debug.Log(plane.ToString());
        Debug.Log(planes.ToString());
        Debug.Log(plane.GetDistanceToPoint(prueba));
        Debug.Log(planes.GetDistanceToPoint(prueba));
        */

        //
        //Debug.Log(Vector3.Distance(c.ClosestPointOnPlane(Vec3.Zero),Vector3.zero));





        //List<Vec3> vectors = new List<Vec3>();
        //vectors.Add(new Vec3(10.0f, 0.0f, 0.0f));
        //vectors.Add(new Vec3(10.0f, 10.0f, 0.0f));
        //vectors.Add(new Vec3(20.0f, 10.0f, 0.0f));
        //vectors.Add(new Vec3(20.0f, 20.0f, 0.0f));
        //vectors.Add(new Vec3(20.0f, 10.0f, 5.0f));
        //vectors.Add(new Vec3(20.0f, 10.0f, 0.0f));
        //vectors.Add(new Vec3(8.9f, 4.5f, 0.0f));
        /*
        Vec3 resta = vectors[0] - vectors[1];

        Vec3 multiplicacion = 2 * vectors[1];
        Vec3 division = vectors[1] / 2;

        Debug.Log(vectors[0]);
        Debug.Log(vectors[1]);
        Debug.Log(resta);
        Debug.Log(-vectors[0]);
        Debug.Log(multiplicacion);
        Debug.Log(division);
        Debug.Log(Vec3.Dot(vectors[0], vectors[1]));//producto punto
        Debug.Log(Vec3.Angle(vectors[0], vectors[1]));
        Debug.Log(Vector3.ClampMagnitude(vectors[5], 20));
        Debug.Log(Vec3.ClampMagnitude(vectors[5], 20));
        Debug.Log(vectors[5].magnitude);
        Debug.Log((new Vector3(20.0f, 10.0f, 0.0f).normalized));
        Debug.Log((vectors[5].normalized));
        Vec3 vec = new Vec3(20.0f, 10.0f, 0.0f);
        Debug.Log(vec.normalized);
        //vec.Normalize();


        Debug.Log(Vec3.Normalize(ref vec) + "ESTE ES CON PARAMETRO");
        Vector3 vecto = new Vector3(20.0f, 10.0f, 0.0f);
        Debug.Log(vecto.normalized + "Vector3 normalized");
        //Vector3.Normalize(vecto);
        vecto.Normalize();
        Debug.Log(vecto + "Vector3 Normalize");
        Debug.Log(Vec3.Distance(vectors[0], vectors[1]));

        Vector3 vect = new Vector3(20.0f, 10.0f, 0.0f);
        Vector3 vectB = new Vector3(20.0f, 10.0f, 5.0f);
        Debug.Log(Vector3.SqrMagnitude(vect));
        Debug.Log(Vec3.SqrMagnitude(vectors[5]));
        Debug.Log(Vector3.Scale(vect, vectB));
        Debug.Log(Vec3.Scale(vectors[5], vectors[4]));
        vect.Scale(vectB);
        Debug.Log(vect);
        vectors[5].Scale(vectors[4]);
        Debug.Log(vectors[5]);
        vectors[5].Normalize();
        vectors[5].Set(100.0f, 100.0f, 100.0f);
        Debug.Log(vectors[5] + "SETTED");
*/


        //Vec3 test1 = new Vec3(35.0f, 4.0f, 5.0f);
        //Vec3 test2 = new Vec3(25.0f, 20.0f, 20.0f);
        //Vector3 test3 = new Vector3(35.0f, 4.0f, 5.0f);
        //Vector3 test4 = new Vector3(25.0f, 20.0f, 20.0f);
        //
        //
        //Debug.Log(Vec3.Reflect(test1,test2));
        //
        //Debug.Log(Vector3.Reflect(test3,test4));



        /*
        //test1.Scale(test2);
        //Debug.Log(Vec3.Scale(test1,test2));
        //test3.Scale(test4);
        //Debug.Log(Vector3.Scale(test3,test4));
        Debug.Log(Vec3.Lerp(test1,test2,10));
        Debug.Log(Vector3.Lerp(test3,test4,10));
        */
        #endregion
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.O))
        {
            VectorDebugger.TurnOffVector("elAzul");
        }
        if (Input.GetKeyDown(KeyCode.P))
        {
            VectorDebugger.TurnOnVector("elAzul");
        }
    }
}
