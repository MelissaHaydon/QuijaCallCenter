using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Tutorial : MonoBehaviour
{
    enum TutorialState {Intro, AnswerCalls, BuyCharacter}
    TutorialState tutState;

    string introText01;
    string introText02;

    void Start()
    {
        tutState = TutorialState.Intro;

    }


    void Update()
    {
        if(tutState == TutorialState.Intro)
        {

        }
    }
}
