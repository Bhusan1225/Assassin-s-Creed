using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.TextCore.Text;

public class PlayerController : MonoBehaviour
{
    public float playerSpeed;
    CharacterController controller;

    //grounded
    bool isGrounded;
    public Transform groundCheck;
    public float groundDistance;
    public LayerMask groundMask;

    Vector3 jump;

    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();   
    }

    // Update is called once per frame
    void Update()
    {

        //ground check
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        //resetting the default jump
        if (isGrounded && jump.y < 0f)
        {
            jump.y = -2f;
        }
        Move();


    }

    void Move()
    {
        //Getting the inputs
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        //create the moving vector
        Vector3 move = transform.right * x + transform.forward * z;

        //Actually moving the player 
        controller.Move(move * playerSpeed * Time.deltaTime);/////////////////////////////////////////////////// walk

    }
}
