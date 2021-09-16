using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 2.0f;
    public float turnSpeed = 10.0f;
    private float hInput;
    private float vInput;

    // Update is called once per frame
    void Update()
    {
       // Gathring Keyboard input for movement
       hInput = Input.GetAxis("Horizontal");
       vInput = Input.GetAxis("Vertical");
       // Makes the PC rotate left and right 
       transform.Rotate(Vector3.forward, turnSpeed * Time.deltaTime * hInput);
       // Makes the PC move forward and back
       transform.Translate(Vector3.forward * speed * Time.deltaTime * vInput); 
    }
}
