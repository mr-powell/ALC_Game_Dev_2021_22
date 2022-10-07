using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    
    public float moveSpeed;

    private Rigidbody rb;
    
    private Vector3 moveInput;

    private Vector2 mouseInput;

    public float mouseSensitivity = 1.0f;
    

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        // Hide and Lock the Cursor
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        // Move the player using Keyboard inputs
        moveInput = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        Vector3 moveH = transform.right * moveInput.x;
        Vector3 moveV = transform.forward * moveInput.z;
        rb.velocity = (moveH + moveV) * moveSpeed; 

        // Look around using Mouse input
        mouseInput = new Vector2(Input.GetAxisRaw("Mouse X"), Input.GetAxisRaw("Mouse Y")) * mouseSensitivity;
        // Rotate the Camera using Quaternion rotation
        transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles.x, transform.rotation.eulerAngles.y  - mouseInput.x, transform.eulerAngles.z);

        if(Input.GetMouseButton(0))
        {
            Ray ray = viewCam.ViewportPointToRay(new Vector3(0.5f,0.5f,0f))
            RaycastHit hit;
            if(Physics.Raycast(ray, out hit))
            {
                Debug.Log("I'm looking at "+ hit.transform.name);
            }
            else
            {
                Debug.Log("I'm not looking at anything");
            }
        }      

    }
}
