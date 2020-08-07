using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MathDebbuger;
using CustomMath;

public class Ejercicios : MonoBehaviour
{
    public Vector3 Blanco;
    public Vector3 Negro;
    public Vector3 Rojo;
    public Vector3 Verde;
    public GameObject go1;
    public GameObject go2;
    public float speed;
    public float angle;
    Vector3 origRot = new Vector3(0,90,0);
    Vector3 origVec = new Vector3(10, 0, 0);
    public enum Ejercicio
    {
        uno,
        dos,
        tres
    }
    public Ejercicio ejercicios = Ejercicio.uno;
    Ejercicio lastEjercicios = Ejercicio.uno;
    void Start()
    {
        VectorDebugger.EnableCoordinates();

        Blanco = origVec;
        Negro = new Vector3(25.0f, 20.0f, 20.0f);

        VectorDebugger.AddVector(Blanco, Color.white, "Blanco");
        VectorDebugger.AddVector(Negro, Color.black, "Negro");
        VectorDebugger.AddVector(Rojo, Color.red, "Rojo");
        VectorDebugger.AddVector(Rojo, Color.green, "Verde");
        VectorDebugger.TurnOffVector("Blanco");
        VectorDebugger.TurnOffVector("Negro");
        VectorDebugger.TurnOffVector("Rojo");
        VectorDebugger.TurnOffVector("Verde");
        VectorDebugger.EnableEditorView();
    }

    void Update()
    {
        if (ejercicios != lastEjercicios)
        {
            go1.transform.rotation = Quaternion.Euler(origRot);
            go2.transform.rotation = Quaternion.Euler(origRot);
            lastEjercicios = ejercicios;
        }

        Vector3 a;
        Vector3 b;
        switch (ejercicios)
        {
            case Ejercicio.uno:

                go1.transform.rotation = go1.transform.rotation * Quaternion.Euler(new Vector3(0, angle * Time.deltaTime * speed, 0));
                a = go1.transform.forward;
                Blanco = a * 10.0f;
                Negro = Vector3.zero;
                Rojo = Vector3.zero;
                Verde = Vector3.zero;

                break;
            case Ejercicio.dos:
                go1.transform.rotation = go1.transform.rotation * Quaternion.Euler(new Vector3(0, angle * Time.deltaTime * speed, 0));
                a = go1.transform.forward;
                Blanco = a * 10;
                Negro = Blanco + Vector3.up * 10;
                Rojo = Negro + a * 10.0f;
                Verde = Rojo;
                break;
            case Ejercicio.tres:
                go1.transform.rotation = go1.transform.rotation * Quaternion.Euler( 0 , angle * Time.deltaTime * speed , angle * Time.deltaTime * speed);
                a = go1.transform.forward;
                go2.transform.rotation = go2.transform.rotation * Quaternion.Euler(0, -angle * Time.deltaTime * speed, -angle * Time.deltaTime * speed);
                b = go2.transform.forward;
                Blanco = a * 10.0f;
                Negro = Blanco + (go1.transform.up) *10;
                Rojo = Negro + b* 10.0f;
                Verde = Rojo + (go2.transform.up) * 10;

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


        //Blanco = new Vec3(White);
        //Negro = new Vec3(Black);
        //Rojo = new Vec3(Red);
        VectorDebugger.UpdatePosition("Blanco", Blanco);
        VectorDebugger.UpdatePosition("Negro", Blanco, Negro);
        VectorDebugger.UpdatePosition("Rojo", Negro, Rojo);
        VectorDebugger.UpdatePosition("Verde", Rojo, Verde);

    }
}
