using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //Create a reference to the Rigidbody2D so we can manipulate it
    Rigidbody2D playerObject;

    // Start is called before the first frame update
    void Start()
    {
        //Find the Rigidbody2D component that is attached to the same object as this script
         playerObject = GetComponent<Rigidbody2D>();

    }

    // Update is called once per frame
    void Update()
    {
        //Create a 'float' that will be equal to the players horizontal input
        float movementValueX = Input.GetAxis("Horizontal");

        //Change the X velocity og the Rigidbody2D to be equal to the movement value
        playerObject.velocity = new Vector2 (movementValueX, playerObject.velocity.y);
        
    }
}
