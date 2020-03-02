using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContextClue : MonoBehaviour
{
    public GameObject contextClue;
    public bool contextActive = false;

   
    public void ChangeContext() // Man skapar en signal som ska roppa på den här funktionen. Signal är en script som signalerar till eventuella att något ska hända.
    {
        contextActive = !contextActive;

        if(contextActive)
        {
            contextClue.SetActive(true);
        }
        else { 
            contextClue.SetActive(false);
        }
    }
   
}
