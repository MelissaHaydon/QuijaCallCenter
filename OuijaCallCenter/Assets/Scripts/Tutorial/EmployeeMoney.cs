using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EmployeeMoney : MonoBehaviour
{

    public int moneyEarning;
    public bool isActive;

    public MoneyManager moneyManager;

    public Animator coinAnim;
    public float timer;

    void Start()
    {   
        timer = 0;
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
}
