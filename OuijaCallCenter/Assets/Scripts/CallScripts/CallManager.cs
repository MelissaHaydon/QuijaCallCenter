﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CallManager : MonoBehaviour {

    float phoneTimer;
    float roundTimer;
    Phone phone;

    public Text winLoseTextBox;

    public static CallManager instance = null;

    enum CallState {Idle, Ringing, Assigning}
    CallState callState;

    void Awake()
    {

        if (instance == null)
        {

            instance = this;
        }

        else if (instance != this)
        {

            Destroy(gameObject);
        }

        DontDestroyOnLoad(gameObject);
    }

    void Start () {
        callState = CallState.Idle;
        phone = GetComponent<Phone>();
        phoneTimer = 0;
        roundTimer = 0;
	}
	
	void Update () {
        phoneTimer += Time.deltaTime;
        roundTimer += Time.deltaTime;
        if(phoneTimer >= 2f && callState == CallState.Idle)
        {
            callState = CallState.Ringing;
            phone.RingPhone();
        }
        if(roundTimer >= 60f)
        {
            if(MoneyManager.instance.totalMoney >= 20)
            {
                winGame();
            }
            else
            {
                loseGame();
            }
        }
	}

    public void ClickOnEmployee(Employee selectedEmployee)
    {
        if(callState == CallState.Assigning)
        {
            selectedEmployee.takeCall(phone.assignedCaller);
            callState = CallState.Idle;
            phone.callerTextBox.text = "";
            phoneTimer = 0f;
        }
    }

    void winGame()
    {
        winLoseTextBox.text = "You Win!";
    }

    void loseGame()
    {
        winLoseTextBox.text = "You Lose!";
    }

    private void OnMouseDown()
    {
        if(callState == CallState.Ringing)
        {
            phone.AnswerPhone();
            callState = CallState.Assigning;
        }
    }

}
