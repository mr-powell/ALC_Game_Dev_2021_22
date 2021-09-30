using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Agent : MonoBehaviour
{

public float maxSpeed;
public float maxAccel;
public float orientation;
public Vector3 velocity;
protected Steering steering;

    // Start is called before the first frame update
    void Start()
    {
        velocity = Vector3.zero;
        sterring = new Steering();
    }

     public void SetSteering (Steering steering)
    {
        this.steering = steering;
    }

    public virtual void Update() 
    {
        Vector3 displacement = velocity * Time.deltaTime;
        orientation += rotation * Time.deltaTime;
        // we need to limit the orientation value
        // to be in the range (0 - 360)
        if(orientation < 0.0f)
            orientation += 360.0f;
        else if (orientation > 360.0f)
        orientation -= 360.0f;
    }
}
