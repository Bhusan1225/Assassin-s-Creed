using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameHandler : MonoBehaviour
{
    //flying object
    public GameObject flyingCompanionCamara;
    public FlyingController flyingcontroller;
    public FlyingCompanion flyingCompanion;

    //character object
    public PlayerController playerController;
    public GameObject playerCamera;

    //bool to check birdfollowing
    bool isBirdFollowing;


    // Start is called before the first frame update
    void Start()
    {
        flyingCompanionCamara.SetActive(false);
        flyingcontroller.enabled = false;
        isBirdFollowing = true;
        
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.F) && isBirdFollowing)
        {
            playerController.enabled = false; //player controller deacivated
            playerCamera.SetActive(false); //player camera deactivated

            flyingCompanionCamara.SetActive(true); //bird camera activated
            flyingcontroller.enabled = true; //bird controller acivated 
            flyingCompanion.enabled = false; //bird's flying companion will deacivated

            isBirdFollowing = false;
        }

        if (Input.GetKeyDown(KeyCode.R) && isBirdFollowing == false)
        {
            playerController.enabled = true; //player controller acivated
            playerCamera.SetActive(true); //player camera activated
            
            flyingCompanionCamara.SetActive(false); //bird camera deactivated
            flyingcontroller.enabled = false; //bird controller deacivated 
            flyingCompanion.enabled = true; //bird's flying companion will acivated

            isBirdFollowing = true;
        }
    }
}
