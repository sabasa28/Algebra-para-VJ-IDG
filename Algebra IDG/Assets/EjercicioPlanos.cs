using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CustomMath;
public class EjercicioPlanos : MonoBehaviour
{
    MeshRenderer meshRenderer;
    Color inCol;
    Color outCol;
    public List<GameObject> paredes = new List<GameObject>();
    List<Plein> planos = new List<Plein>();
    int paredesDelante=0;
    void Start()
    {
        meshRenderer = GetComponent<MeshRenderer>();
        inCol = meshRenderer.material.color;
        outCol = Color.red;

        for (int i = 0; i < paredes.Count; i++)
        {
            planos.Add(new Plein(new Vec3 (paredes[i].transform.up), new Vec3 (paredes[i].transform.position)));
        }

    }

    void Update()
    {
        paredesDelante = 0;
        for (int i = 0; i < paredes.Count; i++)
        {
            if (planos[i].GetSide(new Vec3(transform.position)))
                paredesDelante++;
        }
        if (paredesDelante == paredes.Count)
        {
            meshRenderer.material.color = inCol;
        }
        else
        {
            meshRenderer.material.color = outCol;
        }
    }
}
