using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    public Text textDisplay;
    public string[] sentences;
    private int index;
    public float typingSpeed;

    public EmployeeEvents eventManager;

    public GameObject continueButton;
    public GameObject positiveResponseButton;
    public GameObject negativeResponseButton;
    public GameObject textBoxPanel;
    public Image portraitPanel;

    public Text positiveResponseText;
    public Text negativeResponseText;

    bool typingActive;
    bool hasResponse;
    bool answered;
    bool tutorial;

    int arrayLength;


    void Start()
    {
        ResetValues();
    }

    private void ResetValues()
    {
        index = 0;
        hasResponse = false;
        typingActive = false;
        answered = false;
        tutorial = false;
        textDisplay.text = "";
        continueButton.SetActive(false);
        textBoxPanel.SetActive(false);
        portraitPanel.gameObject.SetActive(false);
        positiveResponseButton.SetActive(false);
        negativeResponseButton.SetActive(false);
        arrayLength = 0;
    }


    void Update()
    {
        if (typingActive)
        {
            if (textDisplay.text == sentences[index])
            {
                continueButton.SetActive(true);
            }
        }
    }

    public void NewText(string[] newSentences, bool isTutorial, Sprite talkingSprite)
    {
        sentences = newSentences;
        if (isTutorial)
        {
            tutorial = true;
        }
        typingActive = true;
        portraitPanel.sprite = talkingSprite;
        arrayLength = sentences.Length - 1;
        textBoxPanel.SetActive(true);
        portraitPanel.gameObject.SetActive(true);
        StartCoroutine(Type());
    }

    public void NewTextWithResponse(string[] newSentences, string positiveResponse, string negativeResponse)
    {
        sentences = newSentences;
        arrayLength = sentences.Length - 1;
        positiveResponseText.text = positiveResponse;
        negativeResponseText.text = negativeResponse;
        portraitPanel.sprite = eventManager.selectedEmployee.talkingSprite;
        hasResponse = true;
        typingActive = true;
        textBoxPanel.SetActive(true);
        portraitPanel.gameObject.SetActive(true);
        StartCoroutine(Type());
    }

    IEnumerator Type()
    {
        foreach (char letter in sentences[index].ToCharArray())
        {
            textDisplay.text += letter;
            yield return new WaitForSeconds(typingSpeed);
        }

    }

    public void PositiveResponse()
    {
        positiveResponseButton.SetActive(false);
        negativeResponseButton.SetActive(false);
        answered = true;
        arrayLength--;
        NextSentence();
    }

    public void NegativeResponse()
    {
        index ++;
        positiveResponseButton.SetActive(false);
        negativeResponseButton.SetActive(false);
        answered = true;
        NextSentence();
    }

    public void SkipDialogue()
    {
        ResetValues();
    }

    public void NextSentence()
    {
        continueButton.SetActive(false);

        if (index == 1 && hasResponse && !answered)
        {
            textDisplay.text = "";
            positiveResponseButton.SetActive(true);
            negativeResponseButton.SetActive(true);
        }
        else if (index < arrayLength)
        {
            index++;
            textDisplay.text = "";
            StartCoroutine(Type());
        }
        else
        {
            if (hasResponse)
            {
                eventManager.EventFinished();
            }
            ResetValues();
        }
    }
}
