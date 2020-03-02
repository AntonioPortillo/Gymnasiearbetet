using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseManager : MonoBehaviour
{
    private bool isPaused;
    public GameObject pausePanel;
    public string mainMenu;
  
  void Start()
    {
        isPaused = false; // När spelet startas är boolean = false gällande om pauseskärmen är igång eller inte.
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("Pause")) // i unity har jag fixat en Axis som innehåller vad som ska ske när man trycker på respektive knapp. På Axis kan man fixa så att spelet dessutom är spelbart på Xbox eller Playstation
        {
            ChangePause(); 
        }
    }
    public void ChangePause() //kopplas till den ena knappen som stänger av pausemenyn för att komma tillbaks till spelet.
    {
        isPaused = !isPaused;
        if (isPaused)
        {
            pausePanel.SetActive(true);
            Time.timeScale = 0f;
        }
        else
        {
            pausePanel.SetActive(false);
            Time.timeScale = 1f;
        }
    }
   public void QuitToMain() //kopplas till en knapp som tar en till mainMenu scenen.
    {
        SceneManager.LoadScene(mainMenu);
        Time.timeScale = 1f;
    }
}
