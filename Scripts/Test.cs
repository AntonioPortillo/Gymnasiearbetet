using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Test : MonoBehaviour
{

    public Text textDisplay;
    public string[] sentences;
    private int index;
    public float typingSpeed;

    public GameObject dialogBox;
    public bool playerInRange;
    public GameObject continueButton;



    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && playerInRange)
        {
            if (dialogBox.activeInHierarchy)
            {
                dialogBox.SetActive(false);
                continueButton.SetActive(false);
                ClearMessageBox();
            }
            else
            {
                dialogBox.SetActive(true);
                continueButton.SetActive(true);
                StartCoroutine(Type());
                HideChatBubble();

            }
        }

        if (Input.GetKeyDown(KeyCode.Return) && dialogBox.activeInHierarchy) {
            NextSentence();
        }

        if (playerInRange && dialogBox.activeInHierarchy) {
            if (textDisplay.text == sentences[index])
            {
                continueButton.SetActive(true);
            }
        }
    }

    IEnumerator Type()
    {
        foreach (char letter in sentences[index].ToCharArray())
        {
            textDisplay.text += letter;
            yield return new WaitForSeconds(typingSpeed);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = true;
            ClearMessageBox();
            ShowChatBubble();
        }
    }

    private void ShowChatBubble()
    {
        
    }
    private void HideChatBubble()
    {
        // If the object is visible hide it
    }

    private void ClearMessageBox() {
        index = 0;
        textDisplay.text = "";
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = false;
            dialogBox.SetActive(false);
            HideChatBubble();

        }
    }

    public void NextSentence()
    {
        continueButton.SetActive(false);

        if (index < sentences.Length - 1)
        {
            index++;
            textDisplay.text = "";
            StartCoroutine(Type());
        }
        else
        {
            textDisplay.text = "";
            continueButton.SetActive(false);
            dialogBox.SetActive(false);
        }
    }
}



