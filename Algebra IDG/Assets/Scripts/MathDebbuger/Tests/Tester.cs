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
        VectorDebugger.EnableEditorView();
        List<Vec3> vectors = new List<Vec3>();
        vectors.Add(new Vec3(10.0f, 0.0f, 0.0f));
        vectors.Add(new Vec3(10.0f, 10.0f, 0.0f));
        vectors.Add(new Vec3(20.0f, 10.0f, 0.0f));
        vectors.Add(new Vec3(20.0f, 20.0f, 0.0f));
        
        Vec3 resta = vectors[0] - vectors[1];

        Vec3 multiplicacion = 2 * vectors[1];
        Vec3 division = vectors[1] / 2;
        Debug.Log(vectors[0]);
        Debug.Log(vectors[1]);
        Debug.Log(resta);
        Debug.Log(-vectors[0]);
        Debug.Log(multiplicacion);
        Debug.Log(division);
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
