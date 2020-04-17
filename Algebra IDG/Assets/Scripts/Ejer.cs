using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MathDebbuger;
using CustomMath;



public class Ejer : MonoBehaviour
{
    // Start is called before the first frame update

    public Vector3 Blanco;
    public Vector3 Negro;
    public Vector3 Rojo;
    Vec3 White;
    Vec3 Black;
    void Start()
    {
        VectorDebugger.EnableCoordinates();

        Blanco = new Vector3(10.0f, 10.0f, 10.0f);
        Negro = new Vector3(25.0f, 20.0f, 20.0f);

        White = new Vec3(Blanco);
        Black = new Vec3 (Negro);

        /*
        //Ejercicio 1
        Rojo = Blanco + Negro;
        */

        
        //Ejercicio 2 
        //Rojo = Negro - Blanco;
        
        /*
        //Ejercicio3
        Rojo = Vector3.Scale(Blanco, Negro);
        */
        //Ejercicio4
        //Rojo = Blanco + Negro;

        VectorDebugger.AddVector(Blanco, Color.white, "Blanco");
        VectorDebugger.AddVector(Negro, Color.black, "Negro");
        VectorDebugger.AddVector(Rojo, Color.red, "Rojo");

        VectorDebugger.EnableEditorView();
    }

    // Update is called once per frame
    void Update()
    {
        White = new Vec3(Blanco);
        Black = new Vec3(Negro);
        /*
        //Ejercicio 1
        Rojo = Blanco + Negro;
        */

        //Ejercicio 2
        //Rojo = Negro - Blanco;

        /*
        //Ejercicio 3
        Rojo = Vector3.Scale(Blanco, Negro);
        */
        //Ejercicio 4
        //Rojo = Blanco + Negro; //ACA HACER PRODUCTO PUNTO

        //Ejercicio 7

        Rojo = Vec3.Project(Black,White);
        

        VectorDebugger.UpdatePosition("Blanco" ,Blanco);
        VectorDebugger.UpdatePosition("Negro", Negro);
        VectorDebugger.UpdatePosition("Rojo", Rojo);

    }
}
