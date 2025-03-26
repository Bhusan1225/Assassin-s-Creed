using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyingController2 : MonoBehaviour
{

    public float thrust = 10f;
    public float topSpeed = 20f;
    public float defaulLift = 1f;

    Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
     
       
        rb.velocity = transform.forward * thrust;
        transform.Rotate(defaulLift, 0, 0);

        if (Input.GetKey(KeyCode.W))
        {
            transform.Rotate(-0.5f, 0, 0);
        }
        if (Input.GetKey(KeyCode.S))
        {
            transform.Rotate(0.5f, 0, 0);
        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.Rotate(0,0 , 0.5f);
            
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.Rotate(0, 0, -0.5f);
        }

    }
}
