using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyingCompanion : MonoBehaviour
{
    public float x;
    public float y;
    public float gap = 1f;
    public Transform player;

 

    // Update is called once per frame
    void Update()
    {
        transform.rotation = player.rotation;
        transform.position = player.position - new Vector3(x, y, gap);   
    }
}
