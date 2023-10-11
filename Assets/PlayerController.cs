using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public GameObject groundChecker;
    public LayerMask whatIsGround;

    //Create a reference to the Rigidbody2D so we can manipulate it
    Rigidbody2D playerObject;

    //Speed of the object
    public float maxSpeed = 5.0f;
    bool isOnGround = false;
    public float jumpForce = 1.0f;

    Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        //Find the Rigidbody2D component that is attached to the same object as this script
         playerObject = GetComponent<Rigidbody2D>();

        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
        //float movementValueX to 1.0f, so that we always run forward and no longer care about player input
        float movementValueX = 1.0f;
        
        //Change the X velocity og the Rigidbody2D to be equal to the movement value
        playerObject.velocity = new Vector2(movementValueX * maxSpeed, playerObject.velocity.y);

        isOnGround = Physics2D.OverlapCircle(groundChecker.transform.position, 1.0f, whatIsGround);

        if ((isOnGround == true) && (Input.GetAxis("Jump") > 0.0f))
        {
            playerObject.AddForce(Vector2.up * jumpForce);
        }

        anim.SetFloat("Speed", Mathf.Abs(movementValueX));
        anim.SetBool("IsOnGround", isOnGround);

    }
}
