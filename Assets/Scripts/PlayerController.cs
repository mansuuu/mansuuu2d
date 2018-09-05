using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public float speed = 5f;
    public float jumpSpeed = 8f;
    private float movement = 0f;
    private Rigidbody2D rigidBody;
    public Transform groundCheckPoint;
    public float groundCheckRadius;
    public LayerMask groundLayer;
    private bool isTouchingGround;

	// Use this for initialization
	void Start () {
        rigidBody = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {
        isTouchingGround = Physics2D.OverlapCircle(groundCheckPoint.position, groundCheckRadius, groundLayer);
        //get horizontal movement from input
        //get input of horizontal which is without input, movement always zero
        movement = Input.GetAxis("Horizontal");
        if (movement > 0f)
        {
            //move right
            rigidBody.velocity = new Vector2(movement * speed, rigidBody.velocity.y);
        }
        else if(movement < 0f)
        {
            //move left
            rigidBody.velocity = new Vector2(movement * speed, rigidBody.velocity.y);
        }
        else
        {
            //no movemont on horizontal
            rigidBody.velocity = new Vector2(0, rigidBody.velocity.y);
        }

        if(Input.GetButtonDown("Jump") && isTouchingGround)
        {
            rigidBody.velocity = new Vector2(rigidBody.velocity.x, jumpSpeed);
        }
	}   
}
