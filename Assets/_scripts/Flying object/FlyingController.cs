using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FlyingController : MonoBehaviour
{

    public float thrust;
    public float topSpeed = 20f;
    public float defaulLift = 1f;
    float dynamicLift;
    float fallRate;
    float glideRate;
    public Slider thrustSlider;


    Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        thrustSlider.onValueChanged.AddListener(delegate {ValueChangeCheck();});
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        
        transform.Translate(0, 0, (thrust + (glideRate *25)) * Time.deltaTime);
        transform.Rotate(dynamicLift, 0, 0);

        rb.velocity = new Vector3(0,rb.velocity.y * fallRate ,0);

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

        if (Input.GetKey(KeyCode.Q))
        {
            transform.Rotate(0, -0.5f, 0);
        }
        if (Input.GetKey(KeyCode.E))
        {
            transform.Rotate(0, 0.5f, 0);
        }

    }

     public void ValueChangeCheck()
    {
        thrust = thrustSlider.value * topSpeed;
        dynamicLift = thrustSlider.value * defaulLift;
        fallRate = 1f - thrustSlider.value;
        glideRate = 1f - thrustSlider.value;
    }

    private void OnCollisionEnter(Collision collision)
    {
        glideRate = 0;
    }
}
