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
    private bool isJumping;

    public AudioClip jump;
    public AudioClip backgroundMusic;

    public AudioClip sfxPlayer;
    public AudioClip musicPlayer;

    Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        //Find the Rigidbody2D component that is attached to the same object as this script
         playerObject = GetComponent<Rigidbody2D>();

        animator = GetComponent<Animator>();
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
            isJumping = true;
        }

        animator.SetFloat("Speed", Mathf.Abs(movementValueX));
        animator.SetBool("IsOnGround", isOnGround);

        if (Input.GetButtonUp("Jump"))
        {
            isJumping = false;
            animator.SetBool("isJumping", true);
        }

        if (isOnGround == true)
        {
            animator.SetBool("isJumping", false);
        }

        if (isOnGround == false)
        {
            animator.SetBool("isJumping", true);
            animator.SetBool("isTouchingGround", false);

        }

        if (isOnGround == true)
        {
            animator.SetBool("isTouchingGround", true);
        }

    
    }
}
