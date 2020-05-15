using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//Jag har inte kopplat något så att man kan ta skada. Men för att ta skada skapar man ett floatvärde för damage (1) och därefter kan man skriva playerCurrentHealth.initialValue -= damage; och dessutom koppla signalen och skriva playerHealthSignal.rais();
/* exempel: 
 public void riddle(float damage){
 playerCurrentHealth.initialValue -= damage;
 if (playerCurrentHealth.initialValue >0)
 {
 playerHealtSignal.Raise();
 }
    
    }
     
     */
public class HeartManager : MonoBehaviour
{
    public Image[] hearts;
    public Sprite fullHeart;
    public Sprite emptyHeart;
    public FloatValue heartContainers;
    public FloatValue playerCurrentHealth;
    public Signal playerHealthSignal;
    void Start()
    {
        InitHearts();
    }

    
    // Detta används för att sätta initiala hjärtorna och att de visas i spelet.
    public void InitHearts()
    {
        for(int i =0; i< heartContainers.initialValue; i++) //heartcontainers är kopplad till ett float värde som i detta fall är initialvalue.
        {
            hearts[i].gameObject.SetActive(true);
            hearts[i].sprite = fullHeart;
        }
    }

    //Används för att uppdatera UI:t i spelet så att ifall man förlorar ett hjärta kommer UI:t byta bild till en tom hjärta.
    public void UpdateHearts()
    {
        float tempHealth = playerCurrentHealth.initialValue;
        for (int i = 0; i< heartContainers.initialValue; i++)
        {
            if (i <= tempHealth)
            {
                hearts[i].sprite = fullHeart;
            } else if (i > tempHealth) {
                hearts[i].sprite = emptyHeart;
            }
        }
    }
}
