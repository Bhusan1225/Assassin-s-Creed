using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCamaraController : MonoBehaviour
{

    [Header("Camera Controller")]
    public Transform target;
    public float cameraGap = 3f;
    public float cameraHeight = -1f;

    float rotX;
    float rotY;

    public float minVerAngle = -45f;
    public float maxVerAngle = 45f;

    private void Start()
    {
        //Cursor.lockState = CursorLockMode.Locked;
        //Cursor.visible = false;
    }


    // Update is called once per frame
    void Update()
    {

        rotX += Input.GetAxis("Mouse Y");
        rotX = Mathf.Clamp(rotX, minVerAngle, maxVerAngle);
        rotY += Input.GetAxis("Mouse X");


        var targetRotation = Quaternion.Euler(rotX, rotY, 0);



        
        transform.position = target.position - targetRotation * new Vector3(0f, cameraHeight, cameraGap);
        transform.rotation = targetRotation;


    }
}
