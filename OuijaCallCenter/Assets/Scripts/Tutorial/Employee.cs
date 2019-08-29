﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Employee : MonoBehaviour
{

    public int moneyEarning;
    public bool isActive;

    public int cost;
    public bool purchased;

    public float happiness;

    public GameObject buyPortrait;
    public GameObject soldPortrait;
    public Sprite talkingSprite;
    public Button buyButton;

    public ParticleSystem buyCloud;
    public MoneyManager moneyManager;

    public Animator coinAnim;
    public float timer;

    public Event[] events;

    void Start()
    {   
        timer = 0;
        buyCloud.gameObject.SetActive(false);
        buyCloud.Stop();
        gameObject.SetActive(false);
        soldPortrait.gameObject.SetActive(false);
        buyButton.enabled = true;
        happiness = 1f;
}
    
    void Update()
    {
        if(isActive)
        timer += Time.deltaTime;
        if (isActive && timer>=3f)
        {
            timer = 0;
            coinAnim.SetTrigger("AnimateCoin");
            moneyManager.addMoney(moneyEarning);
        }
    }

    public void ChangeHappiness(float happinessChange)
    {
        happiness += happinessChange;
    }
}
