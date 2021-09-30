using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour
{

    public string pickupName;

    public int amount;

    public GameManager gameManager;
    
    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player"))
        {
            print("You've picked up a "+ pickupName);
            gameManager.hasKey = true;
            Destroy(gameObject);
        }        
    }

}
