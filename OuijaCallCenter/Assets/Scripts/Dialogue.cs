using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Dialogue : MonoBehaviour
{

    public Text textDisplay;
    public string[] sentences;
    private int index;
    public float typingSpeed;

    public GameObject arrow01;
    public GameObject arrow02;

    public GameObject continueButton;
    bool arrowActivated;
    public bool textFinished;

    public GameObject textBoxPanel;
    public GameObject portraitPanel;

    public bool tutorialComplete;

    private void Start()
    {
        StartCoroutine(Type());
        arrow01.SetActive(false);
        arrow01.SetActive(false);
        continueButton.SetActive(false);
        index = 0;
        arrowActivated = false;
        textFinished = false;
        tutorialComplete = false;

    }

    private void Update()
    {
        if(textDisplay.text == sentences[index] && !textFinished)
        {
            continueButton.SetActive(true);
        }
    }

    IEnumerator Type()
    {
        foreach(char letter in sentences[index].ToCharArray())
        {
            textDisplay.text += letter;
            yield return new WaitForSeconds(typingSpeed);
        }

    }

    IEnumerator CloseWindow()
    {
        yield return new WaitForSeconds(2);
        continueButton.SetActive(false);
        textBoxPanel.SetActive(false);
        portraitPanel.SetActive(false);
        textDisplay.text = "";
    }

    public void NextSentence()
    {
        continueButton.SetActive(false);

        if (tutorialComplete)
        {
            textDisplay.text = "Looks like you know what you're doing, good luck!";
            index = sentences.Length -1;
            StartCoroutine(CloseWindow());
            
        }
        else if (index < sentences.Length - 1)
        {
            index++;
            textDisplay.text = "";
            StartCoroutine(Type());
        }
        else
        {
            textDisplay.text = "";
            continueButton.SetActive(false);
            textBoxPanel.SetActive(false);
            portraitPanel.SetActive(false);
            
        }
        if(index == sentences.Length - 1 && !arrowActivated && !tutorialComplete)
        {
            arrow01.SetActive(true);
            arrowActivated = true;
        }
    }

  
}
