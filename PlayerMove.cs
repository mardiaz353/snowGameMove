using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlayerMove : MonoBehaviour {

    public float moveSpeed;//how fast our character moves
    public float jumpForce;//how much force he jumps with

    public KeyCode left;
    public KeyCode right;
    public KeyCode jump;
    public KeyCode throwBall;

    public Transform groundCheckPoint;//local space to world space//the Transform attached to this game object//transform is a variable


    private Rigidbody2D theRB;//reference the rigidbody
    //we're linking what we put in the game to what we're coding
    public Transform groundCheck;

    //Draws a circle, then checks if the ground is within that circle
    public bool isGrounded;
    public float groundCheckRadius;
    public LayerMask whatIsGround;

	// Use this for initialization
	void Start () {
        theRB = GetComponent<Rigidbody2D>();//we're calling it
        //Get component returns the component of Type type if the game object has one attached, null if it doesn't
    }
	
	// Update is called once per frame
	void Update () {

        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, whatIsGround);//checks if ground is within circle at the start of the program

        if (Input.GetKey(left))//is the left key getting pressed?
        {
            theRB.velocity = new Vector2(-moveSpeed, theRB.velocity.y);//vector has two number values, an x and a y value
        } else if(Input.GetKey(right))//if we want it to go left, it needs to move negative along the x axis
        {
            theRB.velocity = new Vector2(moveSpeed, theRB.velocity.y);
        }
        else
        {
            theRB.velocity = new Vector2(0, theRB.velocity.y);
        }
        if(Input.GetKeyDown(jump))
        {
            theRB.velocity = new Vector2(theRB.velocity.x, jumpForce);
        }
        }
	}

