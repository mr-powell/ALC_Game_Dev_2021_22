using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5f; // Speed at which the player will move
    public Rigidbody2D rb; // Store the referenced 2D rigidbody
    Vector2 movement; // Store players x,y position for

    void Start()
    {
        // Reference the rigidbody2D component on the player
        rb = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        //Check for movement every frame
        movement.x = Input.GetAxisRaw("Horizontal"); //Left Right Movement
        movement.y = Input.GetAxisRaw("Vertical"); // Up Down Movement
    }
    void FixedUpdate()
    {  
        //Apply physics and move the character 
        rb.MovePosition(rb.position + movement * moveSpeed * Time.deltaTime); 
    }
}