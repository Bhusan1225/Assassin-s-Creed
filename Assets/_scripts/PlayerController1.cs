using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController1 : MonoBehaviour
{
    [Header("Player Movement")]
    public float movementSpeed = 3f;
    public float rotSpeed = 450f;
    Quaternion requiedRotaion;

    [Header("Player Animator")]
    public Animator animator;

    public MainCamaraController mainCamera;

    void PlayerMovement()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        float movementAmout = Mathf.Clamp01(Mathf.Abs(horizontal) + Mathf.Abs(vertical));

        var movementInput  = (new Vector3(horizontal, 0 , vertical)).normalized; //direction

        var movementDerection  = mainCamera.flatRotaion * movementInput;

        if (movementAmout > 0 )
        {
            transform.position += movementDerection * movementSpeed * Time.deltaTime; // speed in certain direction
            requiedRotaion = Quaternion.LookRotation(movementDerection); //direction into rotation
        }

        transform.rotation = Quaternion.RotateTowards(transform.rotation, requiedRotaion, rotSpeed * Time.deltaTime);
        animator.SetFloat("movementValue", movementAmout);

    }
    
    
    
    
    
    
    
    
    
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        PlayerMovement();
    }
}
