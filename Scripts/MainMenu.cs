using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public GameObject FadeInPanel;
    public GameObject FadeOutPanel;
    public float FadeWait;

    private void Awake()
    {
        if (FadeInPanel != null)
        {
            GameObject panel = Instantiate(FadeInPanel, Vector3.zero, Quaternion.identity) as GameObject;
            Destroy(panel, 1); //man skapar en klon object som sedan förstörs när den har blivit använd. I detta fall är det en fade in panel som är animerad som förstörs när den har spelats.
        }
    }
    
    public IEnumerator FadeCo()
    {
        if (FadeOutPanel != null)
        {
            Instantiate(FadeOutPanel, Vector3.zero, Quaternion.identity);
        }
        yield return new WaitForSeconds(FadeWait); //hur långt tid man ska vänta med faden
        AsyncOperation asyncOperation = SceneManager.LoadSceneAsync("SampleScene"); //vilken scen som ska öppnas
        while (!asyncOperation.isDone) //när laddningen av scenen är klar ska fade börjas. 
        {
            yield return null;
        }
    }
    public void NewGame()
    {
        StartCoroutine(FadeCo());
    }

    public void QuitToDesktop()
    {
        Application.Quit(); // För att stänga av spelet. 
    }
}
