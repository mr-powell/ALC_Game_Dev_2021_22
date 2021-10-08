using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Movement
    public float moveSpeed;
    
    // Camera
    public float lookSensitivity;   // Mouse look sensitivity
    public float maxLookX; //lowest down position we can look
    public float minLookX;  //Highest up we can look
    private float rotX; //Current X rotation of the camera
    // GameObjects & Components
    private Camera cam;
    private Rigidbody rb;

    void Awake()
    {
        //Get the components
        cam = Camera.main;
        rb = GetComponent<Rigidbody>();
    }
    
    // Update is called once per frame
    void Update()
    {
       Move();
       CamLook(); 
    }

    void Move()
    {
        float x = Input.GetAxis("Horizontal") * moveSpeed;
        float z = Input.GetAxis("Vertical") * moveSpeed;

        rb.velocity = new Vector3(x, rb.velocity.y, z);
    }
    void CamLook()
    {
        float y = Input.GetAxis("Mouse X") * lookSensitivity;
        rotX = Input.GetAxis("Mouse Y") * lookSensitivity;
        //Clamps the camera up and down rotation
        rotX = Mathf.Clamp(rotX, minLookX, maxLookX);
        // Apply Rotation to Camera
        cam.transform.localRotation = Quaternion.Euler(-rotX,0,0);
        transform.eulerAngles += Vector3.up * y;
    }
}
