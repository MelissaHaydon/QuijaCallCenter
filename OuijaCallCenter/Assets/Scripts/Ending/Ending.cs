using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ending : MonoBehaviour
{
    public string[] endText;
    string[] endText01;
    public string[] introductionText03;

    public Sprite talkingSprite;
    public Sprite charonSprite;
    public Sprite charonAnnoyedSprite;
    public SpriteRenderer spRend;
    public string chosenName;


    public DialogueManager dialogueManager;
    public HeldData heldData;


    void Start()
    {
        AddText();
        dialogueManager.EndingText(endText, this, talkingSprite);
        heldData = FindObjectOfType<HeldData>();
        chosenName = heldData.characterName;
    }

    void Update()
    {

    }


    void AddText()
    {
        endText01 = new string[4];
        endText01[0] = "Next!";
        endText01[1] = "Ah " + chosenName + " back again";
        endText01[2] = "Bye Betch";
    }
}
