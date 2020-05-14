using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MathDebbuger;
using CustomMath;

public class Nave : MonoBehaviour
{
    float rotY = 0;
    public float rotSpeed;
    public float shotForce;
    public GameObject bullet;
    public Vec3 bulletForce;
    public Vector3 White;
    public Vec3 Blanco;

    void Start()
    {
        VectorDebugger.EnableCoordinates();
        Blanco = new Vec3(transform.forward*50);
        White = Blanco;
        VectorDebugger.AddVector(transform.position,Blanco, Color.white, "Blanco");
        VectorDebugger.EnableEditorView();
    }

    void Update()
    {
        Blanco = new Vec3(transform.forward*50);

        VectorDebugger.UpdatePosition("Blanco", transform.position, Blanco);

        transform.rotation = Quaternion.Euler(new Vec3 (transform.rotation.x, rotY, transform.rotation.z));
        if(Input.GetKey(KeyCode.RightArrow))
        {
            rotY+=Time.deltaTime * rotSpeed;
        }
        if(Input.GetKey(KeyCode.LeftArrow))
        {
            rotY-=Time.deltaTime * rotSpeed;
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            GameObject b= Instantiate(bullet);
            b.transform.rotation = transform.rotation;
            b.GetComponent<Rigidbody>().AddForce(b.transform.forward * shotForce);//no
        }

    }
    
}
