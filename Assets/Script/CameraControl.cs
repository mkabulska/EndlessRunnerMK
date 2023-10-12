using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour
{
    // Create public reference to the player - we will assign this using the unity editor
    public GameObject player;
  
    void Update()
    {

        //Changes our position relative to the players position
        transform.position = new Vector3(player.transform.position.x, transform.position.y, transform.position.z);

    }
}
