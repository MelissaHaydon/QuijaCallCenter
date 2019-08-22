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

    private void Start()
    {
        StartCoroutine(Type());
        arrow01.SetActive(false);
        arrow01.SetActive(false);
        continueButton.SetActive(false);
        index = 0;
        arrowActivated = false;
        textFinished = false;

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

    public void NextSentence()
    {
        continueButton.SetActive(false);

        if(index < sentences.Length - 1)
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
        if(index == sentences.Length - 1 && !arrowActivated)
        {
            arrow01.SetActive(true);
            arrowActivated = true;
        }
    }

  
}
