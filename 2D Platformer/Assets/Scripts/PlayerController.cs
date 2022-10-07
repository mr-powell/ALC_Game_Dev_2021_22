using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
   public float speed;    
    public bool isGrounded;
    public float jumpForce;
    private float moveInput;
    private Rigidbody2D rb;
    private bool faceRight = true;
    public Transform groundCheck;
    public float checkRadius;
    public LayerMask ground;
    //public int doubleJump = 2, doubleJumpValue;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        isGrounded = true; //Start on ground
    }
    void FixedUpdate()
    {
        //Ground Sensor
       isGrounded = Physics2D.OverlapCircle(groundCheck.position, checkRadius, ground);
       //Move Left and Right
       moveInput = Input.GetAxisRaw("Horizontal");
       rb.velocity = new Vector2(moveInput * speed, rb.velocity.y);
       
        //Jump
        if(Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rb.velocity = Vector2.up * jumpForce;
        }
        /* Double Jump
        if(isGrounded)
            doubleJump = 2;

        if(Input.GetKeyDown(KeyCode.Space) && doubleJump > 0)
        {
            rb.velocity = Vector2.up * jumpForce;
            doubleJump--;
        }
        else if(Input.GetKeyDown(KeyCode.Space) && doubleJump == 0 && isGrounded)
        {
            rb.velocity = Vector2.up * jumpForce;           
        }
        */
        // Flip Facing Direction
        if(!faceRight && moveInput > 0) // faceRight == false
        {
            Flip();
        }
        else if(faceRight && moveInput < 0) // faceRight == true;
        {
            Flip();
        }
    }
    void Flip()
    {
        faceRight = !faceRight; // faceRight = false; (Face Left)
        Vector3 scaler = transform.localScale;
        scaler.x *= -1;
        transform.localScale = scaler;
    }
}
