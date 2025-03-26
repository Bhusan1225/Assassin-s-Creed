using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyingController : MonoBehaviour
{

    [SerializeField] private float flyingSpeed = 100f;
    [SerializeField] private float resetSpeed = 100f;
    [SerializeField] private float shiftSpeed = 150f;
    [SerializeField] private float controllSpeed = 50f;

    [SerializeField] private float horizontalSensitivity = 2f;
    [SerializeField] private float verticalSensityity = 2f;

    private float yaw = 0f;
    private float pitch = 0f;

    public Animator animator;


    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;   
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        yaw += horizontalSensitivity * Input.GetAxis("Mouse X");
        pitch -= verticalSensityity * Input.GetAxis("Mouse Y");


        transform.eulerAngles = new Vector3(pitch, yaw, 0f);

        //fast flying
        if(Input.GetKey(KeyCode.LeftShift) )
        {
            flyingSpeed = shiftSpeed;
        }
        else
        {
            flyingSpeed = resetSpeed;
        }

        
        //flying direction controll
        if(Input.GetKey(KeyCode.W))
        {
            transform.localPosition += transform.forward * Time.deltaTime * controllSpeed;
            animator.SetBool("UP", true);
        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.localPosition += -transform.right * Time.deltaTime * controllSpeed;
            animator.SetBool("LEFT", true);
        }
        if (Input.GetKey(KeyCode.S))
        {
            transform.localPosition += -transform.forward * Time.deltaTime * controllSpeed;
            animator.SetBool("DOWN", true);
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.localPosition += transform.right * Time.deltaTime * controllSpeed;
            animator.SetBool("RIGHT",true);
        }
        if (!Input.GetKey(KeyCode.W) && !Input.GetKey(KeyCode.A) && !Input.GetKey(KeyCode.S) && !Input.GetKey(KeyCode.D) )
        {
            animator.SetBool("FORWARD", true);
            animator.SetBool("DOWN", false);
            animator.SetBool("UP", false) ;
            animator.SetBool("LEFT", false);
            animator.SetBool("RIGHT", false);


        }
        else
        {
            animator.SetBool("FORWARD", false );

        }


    }
}
