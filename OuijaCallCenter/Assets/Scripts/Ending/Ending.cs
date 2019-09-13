using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ending : MonoBehaviour
{

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

        heldData = FindObjectOfType<HeldData>();
        chosenName = heldData.characterName;
        AddText();
        dialogueManager.EndingText(endText01, this, talkingSprite);
    }

    void Update()
    {

    }


    void AddText()
    {
        endText01 = new string[4];
        endText01[0] = "Next!";
        endText01[1] = "Ah " + chosenName + " back again";
        endText01[2] = "I see you're ready to cross now";
        endText01[3] = "Farewell";
    }
}
