using System.Collections.Generic;
using UnityEngine;
using MathDebbuger;
using CustomMath;
using System;

public class Tester : MonoBehaviour
{
    public Quaternion rot;
    public Quaternion rot1;

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

        Quarentenion miQ = new Quarentenion(transform.rotation.x, transform.rotation.y, transform.rotation.z, transform.rotation.w);
        Quarentenion miQ2 = new Quarentenion(-0.2f, 0, -0.3f, -0.4f);
        Quaternion noMiQ = new Quaternion(transform.rotation.x, transform.rotation.y, transform.rotation.z, transform.rotation.w);
        Quaternion noMiQ2 = new Quaternion(-0.2f, 0, -0.3f, -0.4f);
        Quarentenion myA = new Quarentenion(-0.2f, 0.3f, 0.1f, 0.5f);
        Quarentenion myB = new Quarentenion(0.2f, 0.3f, 0.8f, 0.5f);

        Quaternion A = new Quaternion(-0.2f, 0.3f, 0.1f, 0.5f);
        Quaternion B = new Quaternion(0.2f, 0.3f, 0.8f, 0.5f);

        MatrixRecargada m = MatrixRecargada.identity;
        Matrix4x4 M = Matrix4x4.identity;

        //Debug.Log(Quaternion.AngleAxis(80, new Vector3(10, 20, 30)));
        //Debug.Log(Quarentenion.AngleAxis(80, new Vector3(10,20,30)));

        //rot = Quaternion.FromToRotation(Vector3.up,Vector3.right);
        //miQ.SetFromToRotation(Vec3.Up,Vec3.Right);
        //noMiQ.SetFromToRotation(Vector3.up,Vector3.right);
        //Debug.Log(miQ);
        //Debug.Log(noMiQ);


        //dot//((a.x * b.x) + (a.y * b.y) + (a.z * b.z));

        //Mathf.Rad2Deg * (float)Math.Acos(Dot(from, to) / (Math.Sqrt(Math.Pow(from.x, 2) + Math.Pow(from.y, 2) + Math.Pow(from.z, 2)) * Math.Sqrt(Math.Pow(to.x, 2) + Math.Pow(to.y, 2) + Math.Pow(to.z, 2))));






        //Vector3 fromRot = transform.forward;
        ////Debug.Log(fromRot);
        //Vector3 toRot = Vector3.up;
        ////Debug.Log(toRot);
        //Vector3 betweeeeen;// = toRot - fromRot;
        //float angle = Vector3.Angle(fromRot, toRot);
        //float suma = Math.Abs(toRot.x) + Math.Abs(toRot.y) + Math.Abs(toRot.z);
        //betweeeeen = toRot/suma;// * angle;
        ////Debug.Log(betweeeeen);
        //betweeeeen *=angle;
        //rot1 =  Quaternion.Euler(fromRot)* Quaternion.Euler(betweeeeen);
        //Debug.Log(toRot);
        //Debug.Log(fromRot);
        //Debug.Log(rotx);
        //Debug.Log(roty);
        //Debug.Log(rotz);
        //Debug.Log("Vec target" + toRot);
        //Debug.Log("Vec orig" + fromRot);
        //Debug.Log("Angle " + angle);
        //Debug.Log("Suma " + suma);
        //Vector3 aux = new Vector3(toRot.x / suma, toRot.y / suma, toRot.z / suma);
        //Debug.Log("Nornalizado" + aux);
        ////aux = fromRot / suma; mah fasil
        //Vector3 angleBetween = new Vector3(aux.x * angle, aux.y* angle, aux.z * angle);
        //Debug.Log("Multiplicado por su angulo" + angleBetween);
        ////angleBetween = aux * angle; mah fasil
        //
        ////angleBetween = new Vector3(fromRot.x + angleBetween.x, fromRot.y + angleBetween.y, fromRot.z + angleBetween.z);
        //Debug.Log("Vector original sumado a el final" + angleBetween);
        //rot1 = Quaternion.Euler (angleBetween);
        //rot1 = Quaternion.Euler(spaceBetween);

        //noMiQ2 = Vector3.Angle(Vector3.up, Vector3.right);

        //noMiQ2 = Quaternion.Euler(Vector3.right);
        //Debug.Log(noMiQ);
        //Debug.Log(Quaternion.Euler(Vector3.up - Vector3.right));
        //Debug.Log
        //Debug.Log(Quaternion.Euler(Vector3.up));
        //Debug.Log(Quaternion.Euler(Vector3.right));
        //Debug.Log(Vector3.up);
        //Debug.Log(Vector3.right);




        //Debug.Log(Quarentenion.identity * Vec3.Up);

        //m = MatrixRecargada.Translat}e(new Vec3(transform.position));
        //M = Matrix4x4.Translate((transform.position));

        //m = MatrixRecargada.Scale(new Vec3(transform.lossyScale));
        //M = Matrix4x4.Scale((transform.lossyScale));
        //
        //m = MatrixRecargada.Rotate(new Quarentenion(transform.rotation));
        //M = Matrix4x4.Rotate((transform.rotation));


        //m= MatrixRecargada.Scale(new Vec3(transform.lossyScale));
        //M= Matrix4x4.Scale(transform.lossyScale);
        //m *= MatrixRecargada.identity;
        //M *= Matrix4x4.identity;


        //Debug.Log(m == MatrixRecargada.identity);
        //Debug.Log(m != MatrixRecargada.identity);
        //Debug.Log(M == Matrix4x4.identity);
        //Debug.Log(M != Matrix4x4.identity);

        //Debug.Log(Quaternion.AngleAxis(30, Vector3.up));
        //Debug.Log(Quarentenion.AngleAxis(30, Vec3.Up));

        //Debug.Log("Quat1" + miQ);
        //Debug.Log("Quat2" + miQ2);

        //Debug.Log("angle miq" + Quarentenion.Angle(miQ, miQ2));

        //Debug.Log(Quaternion.identity);
        //Debug.Log("ANGLE MIO" + Quarentenion.Angle(miQ, miQ2));
        //Debug.Log("ANGLE UNITY" + Quaternion.Angle(noMiQ, noMiQ2));
        //Debug.Log("quaren"+Quarentenion.Euler(new Vec3(7, 12, 5)));
        //Debug.Log("quater"+Quaternion.Euler(new Vector3(7, 12, 5)));
        //Debug.Log(miQ.eulerAngles);
        //Debug.Log(noMiQ.eulerAngles);
        //miQ.Normalize();
        //noMiQ.Normalize();
        //Debug.Log(miQ);
        //Debug.Log(noMiQ);


        //Debug.Log(noMiQ.eulerAngles);
        //Debug.Log(noMiQ2.eulerAngles);
        //Debug.Log("angle nomiq" + Quaternion.Angle(noMiQ, noMiQ2));
        //Debug.Log(noMiQ + " " + noMiQ2);



        //Plein b = new Plein(new Vec3(2, 10, 10), new Vec3(20, 0, 10), new Vec3 (3,2,1));
        //Plane c = new Plane(new Vector3(2, 10, 10), new Vector3(20, 0, 10), new Vec3(3, 2, 1));
        //
        //Debug.Log(b);
        //Debug.Log(c);
        //
        //b.Translate(new Vec3(50, 1, 1));
        //c.Translate(new Vec3(50, 1, 1));
        //
        //Debug.Log(b);
        //Debug.Log(c);

        //b.Set3Points(new Vec3(2, 10, 10), new Vec3(20, 0, 10), new Vec3(3, 2, 1));
        //c.Set3Points(new Vec3(2, 10, 10), new Vec3(20, 0, 10), new Vec3(3, 2, 1));
        //
        //Debug.Log(b.ClosestPointOnPlane(new Vec3(-50, 100, 100)));
        //Debug.Log(c.ClosestPointOnPlane(new Vec3(-50, 100, 100)));


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
        //if (Input.GetKeyDown(KeyCode.W))
        //{
        //    transform.rotation = Quaternion.FromToRotation(transform.forward, Vector3.up);
        //    Debug.Log("arriba");
        //}
        //if (Input.GetKeyDown(KeyCode.S))
        //{
        //    transform.rotation = rot1;
        //    Debug.Log("abajo");
        //}
        //if (Input.GetKeyDown(KeyCode.A))
        //{
        //    transform.rotation = rot;
        //    Debug.Log("izquierda");
        //}
        //if (Input.GetKeyDown(KeyCode.D))
        //{
        //    transform.rotation = rot;
        //    Debug.Log("derecha");
        //}
        //if (Input.GetKeyDown(KeyCode.Space))
        //{
        //    transform.rotation = rot;
        //    Debug.Log("hizo la wea ya");
        //}

        
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
