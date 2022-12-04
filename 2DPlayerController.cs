2DPlayerController script


using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController2D : MonoBehaviour
{
    //player stats
    public float speed;
    public float jumpForce;
    private float moveInput;

    // Player Rigidbody
    private Rigidbody2D rb;
    private bool isFacingRight = true;
    // Player Jump
   
    private bool isGrounded = true;
    public Transform groundCheck;
    public float checkRadius;
    public LayerMask whatIsGround;
    public bool doubleJump;


    // Start is called before the first frame update
    void Start()
    {
       rb = GetComponent<Rigidbody2D>(); 
    }   
    // Fixed update is called a fixed or set number of frames. This works best with physics based movement
    void FixedUpdate()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, checkRadius, whatIsGround); // Define what is Ground Parameters

        moveInput = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(moveInput * speed, rb.velocity.y);

        // If the player is moving right but facing left flip the player right
        if(!isFacingRight && moveInput > 0)
        {
            FlipPlayer();
        }
        //if the player is moving left but facing right flip the player left
        else if (isFacingRight && moveInput < 0)
        {
            FlipPlayer();
        }


    }
     
    // Update is called once per frame. We will use Update for the jump as we will need every frame. fixed Update skip frames.

    void Update()
    {
        if(isGrounded)
        {
            doubleJump = true;
        }

        if(Input.GetKeyDown(KeyCode.Space) && doubleJump)
        {
            rb.velocity = Vector2.up * jumpForce; // makes the player jump
            doubleJump = false;
        }
        
        else if (Input.GetKeyDown(KeyCode.Space) && !doubleJump && isGrounded)
        {
            rb.velocity = Vector2.up * jumpForce;
        }
        

    }
 

    void FlipPlayer()
    {
        isFacingRight = !isFacingRight;
        Vector3 scaler = transform.localScale; // local variable that stores localscale value
        scaler.x *= -1;
        transform.localScale = scaler;
    }
}
