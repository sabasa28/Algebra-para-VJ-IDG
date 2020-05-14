using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public Transform Target;
    // Start is called before the first frame update
    void Start()
    {
        Target = GameObject.FindGameObjectWithTag("Player").transform;
        transform.forward = transform.up;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3.MoveTowards(transform.position, Target.position, 10);
        transform.forward = Target.position;
    }


}
