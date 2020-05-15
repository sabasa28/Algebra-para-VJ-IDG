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
    Vec3 Red;
    float t = 0.0f;

    public enum Ejercicios
    { 
        uno,
        dos,
        tes,
        cuatro,
        cinco,
        seis,
        siete,
        ocho,
        nueve,
        diez
    }
    public Ejercicios ejercicios = Ejercicios.uno;
    void Start()
    {
        VectorDebugger.EnableCoordinates();

        Blanco = new Vector3(10.0f, 10.0f, 10.0f);
        Negro = new Vector3(25.0f, 20.0f, 20.0f);

        White = new Vec3(Blanco);
        Black = new Vec3 (Negro);

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

        switch (ejercicios)
        {
            case Ejercicios.uno:
                Red = White + Black;
                break;
            case Ejercicios.dos:
                Red = Black - White;
                break;
            case Ejercicios.tes:
                Red = Vec3.Scale(White, Black);
                break;
            case Ejercicios.cuatro:
                Red = Vec3.Cross(Black, White);
                break;
            case Ejercicios.cinco:
                Red = Vec3.Lerp(White, Black, t);
                t += Time.deltaTime;
                if (t >= 1) t = 0;
                break;
            case Ejercicios.seis:
                Red = Vec3.Max(White, Black);
                break;
            case Ejercicios.siete:
                Red = Vec3.Project(White, Black);
                break;
            case Ejercicios.ocho:
                break;
            case Ejercicios.nueve:
                Red = Vec3.Reflect(White, Black);
                break;
            case Ejercicios.diez:
                Red = Vec3.LerpUnclamped(Black, White, t);
                t += Time.deltaTime;
                if (t >= 10) t = 0;
                break;
            default:
                break;
        }


        //Ejercicio 1

        //Red = White + Black;

        //Ejercicio 2

        //Red = Black - White;

        //Ejercicio 3

        //Red = Vector3.Scale(White, Black);

        //Ejercicio 4

        //Red = Vec3.Cross(Black, White);

        //Ejercicio 5

        //Red = Vec3.Lerp(White,Black,t);
        //t += Time.deltaTime;
        //if (t >= 1) t = 0;

        //Ejercicio 6

        //Red = Vec3.Max(White, Black);

        //Ejercicio 7

        //Red = Vec3.Project(White,Black);

        //Ejercicio 8

        //Red = Vec3.Zero;

        //Ejercicio 9

        //Red = Vec3.Reflect(White,Black);

        //Ejercicio 10
        //Red = Vec3.LerpUnclamped(Black, White,t);
        //t += Time.deltaTime;
        //if (t >= 10) t = 0;


        Blanco = new Vec3(White);
        Negro = new Vec3(Black);
        Rojo = new Vec3(Red);

        VectorDebugger.UpdatePosition("Blanco" ,White);
        VectorDebugger.UpdatePosition("Negro", Black);
        VectorDebugger.UpdatePosition("Rojo", Rojo);

    }
}
