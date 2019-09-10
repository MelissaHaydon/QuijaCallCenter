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
    public Tutorial tutorialManager;
    public Introduction introduction;
    public Ending ending;

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
    public bool tutorial;
    int positionInText;
    bool tutorialActive;
    bool cancelled;

    int arrayLength;


    void Start()
    {
        ResetValues();
        if(tutorial)
        tutorialManager.PlayIntroDialogue();
        tutorialActive = true;
    }

    private void ResetValues()
    {
        index = 0;
        cancelled = true;
        hasResponse = false;
        typingActive = false;
        answered = false;
        introduction = null;
        ending = null;
        textDisplay.text = "";
        sentences = null;
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
        ResetValues();
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
        cancelled = false;
        StartCoroutine(Type());
    }

    public void NewTextWithResponse(string[] newSentences, string positiveResponse, string negativeResponse)
    {
        ResetValues();
        sentences = newSentences;
        arrayLength = sentences.Length - 1;
        positiveResponseText.text = positiveResponse;
        negativeResponseText.text = negativeResponse;
        portraitPanel.sprite = eventManager.selectedEmployee.talkingSprite;
        hasResponse = true;
        typingActive = true;
        cancelled = false;
        textBoxPanel.SetActive(true);
        portraitPanel.gameObject.SetActive(true);
        StartCoroutine(Type());
    }

    public void IntroductionText(string[] newSentences, Introduction intro, Sprite talkingSprite)
    {
        ResetValues();
        introduction = intro;
        sentences = newSentences;
        typingActive = true;
        portraitPanel.sprite = talkingSprite;
        arrayLength = sentences.Length - 1;
        textBoxPanel.SetActive(true);
        cancelled = false;
        portraitPanel.gameObject.SetActive(true);
        StartCoroutine(Type());
    }

    public void EndingText(string[] newSentences, Ending end, Sprite talkingSprite)
    {
        ResetValues();
        ending = end;
        sentences = newSentences;
        typingActive = true;
        portraitPanel.sprite = talkingSprite;
        arrayLength = sentences.Length - 1;
        textBoxPanel.SetActive(true);
        cancelled = false;
        portraitPanel.gameObject.SetActive(true);
        StartCoroutine(Type());
    }

    IEnumerator Type()
    {
        
        foreach (char letter in sentences[index].ToCharArray())
        {
            if (!cancelled)
            {
                textDisplay.text += letter;
                yield return new WaitForSeconds(typingSpeed);
            }
        }

    }

    public void PositiveResponse()
    {
        positiveResponseButton.SetActive(false);
        negativeResponseButton.SetActive(false);
        answered = true;
        eventManager.EventResult(true);
        arrayLength--;
        NextSentence();
    }

    public void NegativeResponse()
    {
        index ++;
        positiveResponseButton.SetActive(false);
        negativeResponseButton.SetActive(false);
        eventManager.EventResult(false);
        answered = true;
        NextSentence();
    }

    public void SkipDialogue()
    {
        ResetValues();
        tutorialActive = false;
    }

    public void NextSentence()
    {
        continueButton.SetActive(false);

        if (tutorialActive && index == 1)
        {
            tutorialManager.DisplayArrow();
        }
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
            else if (introduction != null)
            {
                if (positionInText == 0)
                {
                    introduction.DisplayNamePicker();
                    positionInText++;
                }
                else if (positionInText == 1)
                {
                    introduction.ShowContract();
                    positionInText++;
                }
                else if (positionInText == 2)
                {
                    introduction.LoadNextScene();
                }
                
            }
            else if (ending != null)
            {

            }
            ResetValues();
        }
    }
}
