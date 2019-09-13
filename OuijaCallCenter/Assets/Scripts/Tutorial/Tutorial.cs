﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Tutorial : MonoBehaviour
{

    public DialogueManager dialogueManager;
    public EmployeeEvents employEvents;
    public TaskManager taskManager;
    public string[] sentences01;
    public string[] sentences02;
    public string[] buyDialogue;

    public Sprite skeletonSprite;
    public Sprite skeletonSprite02;
    public GameObject tempButton;

    public GameObject arrow;
    public GameObject arrow02;
    public GameObject blockout01;
    public GameObject buyTextBox;
    public Text buyText;
    int index;

    public bool tutorialComplete;

    void Start()
    {
        employEvents.enabled = false;
        blockout01.SetActive(false);
        buyTextBox.SetActive(false);
        arrow.SetActive(false);
        arrow02.SetActive(false);
        index = 0;
        tutorialComplete = false;
    }

    void Update()
    {

    }

    public void PlayIntroDialogue()
    {
        dialogueManager.NewText(sentences01, true, skeletonSprite);
    }

    public void DisplayArrow()
    {
        arrow.SetActive(true);
    }

    public void BuyEmployeeTutorial()
    {
        if (!tutorialComplete)
        {
            arrow.gameObject.SetActive(false);
            blockout01.SetActive(true);
            arrow02.SetActive(true);
            buyTextBox.SetActive(true);
            StartCoroutine(Type(buyDialogue));
            
        }
    }

    public void PlaySecondDialogue()
    {
        if (!tutorialComplete)
        {
            arrow02.SetActive(false);
            blockout01.SetActive(false);
            arrow02.SetActive(false);
            buyTextBox.SetActive(false);
            dialogueManager.NewText(sentences02, true, skeletonSprite02);
            employEvents.enabled = true;
            tutorialComplete = true;
            tempButton.SetActive(false);

        }
    }

    IEnumerator Type(string[] sentences)
    {
        foreach (char letter in sentences[index].ToCharArray())
        {
            buyText.text += letter;
            yield return new WaitForSeconds(0.01f);
        }

    }

}
