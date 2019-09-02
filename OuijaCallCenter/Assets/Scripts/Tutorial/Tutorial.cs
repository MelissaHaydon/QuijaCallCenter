using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Tutorial : MonoBehaviour
{

    public DialogueManager dialogueManager;
    public EmployeeEvents employEvents;
    public string[] sentences01;
    public string[] sentences02;

    public Sprite skeletonSprite;
    public Sprite skeletonSprite02;

    public GameObject arrow;

    void Start()
    {
        employEvents.enabled = false;
    }

    void Update()
    {
    }

    public void PlayIntroDialogue()
    {
        dialogueManager.NewText(sentences01, true, skeletonSprite);
    }

    public void PlaySecondDialogue()
    {
        dialogueManager.NewText(sentences02, true, skeletonSprite02);
        employEvents.enabled = true;
    }

    public void RemoveArrow()
    {
        arrow.gameObject.SetActive(false);
    }
}
