using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    private Animator door;

    // Start is called before the first frame update
    void Start()
    {
       door = GetComponent<Animator>(); 
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other) 
    {
        if(other.gameObject.CompareTag("Player"))
        {
            door.SetTrigger("openDoor");
        }

    }

    void OnTriggerExit(Collider other)
    {
       if(other.gameObject.CompareTag("Player"))
        {
            door.SetTrigger("openDoor");
        } 
    }
}
