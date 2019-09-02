using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Introduction : MonoBehaviour
{
    public string[] introductionText;
    string[] introductionText02;

    public Sprite talkingSprite;
    public Sprite charonSprite;
    public Sprite charonAnnoyedSprite;
    public SpriteRenderer spRend;
    public GameObject textEntryBox;

    public DialogueManager dialogueManager;

    string chosenName;

    void Start()
    {
        dialogueManager.IntroductionText(introductionText, this, talkingSprite);
        textEntryBox.SetActive(false);
    }
    
    void Update()
    {
        
    }

    public void ChooseName(string name)
    {
        chosenName = name;
        textEntryBox.SetActive(false);
        AddText();
        spRend.sprite = charonAnnoyedSprite;
        dialogueManager.IntroductionText(introductionText02, null, talkingSprite);
    }

    public void DisplayNamePicker()
    {
        textEntryBox.SetActive(true);
    }

    void AddText()
    {
        introductionText02 = new string[4];
        introductionText02[0] = "...";
        introductionText02[1] = "I'm sure it is";
        introductionText02[2] = "Well then " + chosenName;
        introductionText02[3] = "I have some bad news";
    }
}
