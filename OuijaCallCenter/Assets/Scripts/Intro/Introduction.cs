using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Introduction : MonoBehaviour
{
    public string[] introductionText;
    string[] introductionText02;
    public string[] introductionText03;

    public Sprite talkingSprite;
    public Sprite charonSprite;
    public Sprite charonAnnoyedSprite;
    public SpriteRenderer spRend;
    public GameObject textEntryBox;
    public GameObject contract;
    public GameObject signature;
    public GameObject signatureButton;

    public DialogueManager dialogueManager;
    public HeldData heldData;

    string chosenName;

    void Start()
    {
        dialogueManager.IntroductionText(introductionText, this, talkingSprite);
        textEntryBox.SetActive(false);
        contract.SetActive(false);
        signature.SetActive(false);
        signatureButton.SetActive(false);
    }
    
    void Update()
    {

    }

    public void ChooseName(string name)
    {
        chosenName = name;
        heldData.characterName = name;
        textEntryBox.SetActive(false);
        AddText();
        spRend.sprite = charonAnnoyedSprite;
        dialogueManager.IntroductionText(introductionText02, this, talkingSprite);
    }

    public void DisplayNamePicker()
    {
        textEntryBox.SetActive(true);
    }

    public void ShowContract()
    {
        spRend.sprite = charonSprite;
        contract.SetActive(true);
        signatureButton.SetActive(true);
    }

    public void SignContract()
    {
        signature.SetActive(true);
        signatureButton.SetActive(false);
        StartCoroutine(Wait());
    }

    public void LoadNextScene()
    {
        SceneManager.LoadScene(2);
    }

    IEnumerator Wait()
    {
        yield return new WaitForSeconds(1);
        contract.SetActive(false);
        signature.SetActive(false);
        dialogueManager.IntroductionText(introductionText03, this, talkingSprite);
    }

    void AddText()
    {
        introductionText02 = new string[8];
        introductionText02[0] = "...";
        introductionText02[1] = "I'm sure it is";
        introductionText02[2] = "Well then " + chosenName;
        introductionText02[3] = "I have some bad news";
        introductionText02[4] = "You're, how do I put it...";
        introductionText02[5] = "Flat broke";
        introductionText02[6] = "If you want to get out of here you're going to have to earn it";
        introductionText02[7] = "Now if you'd just sign this contract, we can get you started";
    }
}
