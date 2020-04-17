using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MathDebbuger;
using CustomMath;

public class Nave : MonoBehaviour
{
    float rotY = 0;
    public float rotSpeed;
    public GameObject bullet;
    public Vec3 bulletForce;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        //bulletForce 
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
            Instantiate(bullet);
            bullet.transform.rotation = transform.rotation;
            bullet.GetComponent<Rigidbody>().AddForce(transform.forward);//no
        }

    }
    
}
