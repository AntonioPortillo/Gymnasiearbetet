using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Dialog2 : Interactable
{
    
    public GameObject dialogBox;
    public Text dialogText;
    public string dialog;
   
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F) && playerInRange) //För att aktivera dialogen (funktionen) trycker man på F
        { 
            if(dialogBox.activeInHierarchy)
            {
                dialogBox.SetActive(false);
            }
            else { 
                dialogBox.SetActive(true);
                dialogText.text = dialog;    
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && !other.isTrigger)
        {
            
            playerInRange = true;
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player") && !other.isTrigger)
        {
            
            playerInRange = false;
            dialogBox.SetActive(false);
        }
    }
}
