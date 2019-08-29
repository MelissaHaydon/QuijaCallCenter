using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Tutorial : MonoBehaviour
{

    public DialogueManager dialogueManager;
    public string[] sentences01;
    public string[] sentences02;

    public Sprite skeletonSprite;
    public Sprite skeletonSprite02;

    public GameObject arrow;

    void Start()
    {
        PlayIntroDialogue();
    }

    void Update()
    {
    }

    void PlayIntroDialogue()
    {
        dialogueManager.NewText(sentences01, true, skeletonSprite02);
    }

    void PlaySecondDialogue()
    {
        dialogueManager.NewText(sentences01, true, skeletonSprite02);
    }

    public void RemoveArrow()
    {
        arrow.gameObject.SetActive(false);
    }
}
