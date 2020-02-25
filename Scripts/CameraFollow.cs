using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [Header("Position Variables")]
    public Transform player; //vilket gameobject som kameran ska följa.
    public float smoothing; //för att kunna skriva hur stor "delayen" på kameraförföljningen ska vara. Man använder sig av public för att det ska synas i unity för att kunna ändra i unity. Annars skulle man kunna skriva: private float =3f;
    public Vector2 maxPosition; //för att kunnna fixa boundries i koordinatsystemet. 
    public Vector2 minPosition;

    [Header("Position Reset")]
    public VectorValue camMin; //När man byter scen vill man komma till samma värden på camera boundries. Dock har Unity som standard att gå tillbaka till startvärdena man hade när man byter scen. Med dessa variabler via VectorValue kan man spara värderna som de var för att kunna återkomma till samma plats man lämnade av när man gjorde en scen transition.
    public VectorValue camMax;

    private void Start()
    {
        maxPosition = camMax.initialValue; //initialvalue finns i VectorValue skriptet.
        minPosition = camMin.initialValue;
    }
    void LateUpdate(){
     if(transform.position != player.position)
        {
            Vector3 targetPosition = new Vector3(player.position.x, player.position.y, transform.position.z); //targetPosition vill koppla till ett gameobject och i detta fall är det variabeln player. Detta gör att kameran följer gameobjectet.

            targetPosition.x = Mathf.Clamp(targetPosition.x, minPosition.x, maxPosition.x); 

            targetPosition.y = Mathf.Clamp(targetPosition.y, minPosition.y, maxPosition.y); 

            transform.position = Vector3.Lerp(transform.position, targetPosition, smoothing); //för smoothing
        }
   }
}
