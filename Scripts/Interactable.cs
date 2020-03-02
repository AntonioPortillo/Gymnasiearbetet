using System.Collections;
using UnityEngine;
using System.Collections.Generic;

public class Interactable : MonoBehaviour
{
     public Signal context; //kopplas till Signal scriptet
    public bool playerInRange;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && !other.isTrigger)
        {
            context.Raise(); //Raise() är en metod som kommer med att man skapar en signal 
            playerInRange = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player") && !other.isTrigger)
        {
            context.Raise();
            playerInRange = false;
        }
    }
}
