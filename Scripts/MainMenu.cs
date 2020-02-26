﻿using System.Collections;
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
            Destroy(panel, 1);
        }
    }
    
    public IEnumerator FadeCo()
    {
        if (FadeOutPanel != null)
        {
            Instantiate(FadeOutPanel, Vector3.zero, Quaternion.identity);
        }
        yield return new WaitForSeconds(FadeWait);
        AsyncOperation asyncOperation = SceneManager.LoadSceneAsync("SampleScene");
        while (!asyncOperation.isDone)
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
        Application.Quit();
    }
}
