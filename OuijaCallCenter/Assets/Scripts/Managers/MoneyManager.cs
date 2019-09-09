using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MoneyManager : MonoBehaviour
{
    public int totalMoney;
    public int lifetimeMoney;

    public Text moneyDisplay;
    public Text moneyDisplay2;


    void Start()
    {
        totalMoney = 100;
        lifetimeMoney = 100;
        moneyDisplay.text = totalMoney.ToString();
        moneyDisplay2.text = totalMoney.ToString();
    }

    public void AddMoney(int totalToAdd)
    {
        totalMoney += totalToAdd;
        lifetimeMoney += totalToAdd;
        moneyDisplay.text = totalMoney.ToString();
        moneyDisplay2.text = totalMoney.ToString();
    }

    public void RemoveMoney(int totalToRemove)
    {
        totalMoney += totalToRemove;
        moneyDisplay.text = totalMoney.ToString();
        moneyDisplay2.text = totalMoney.ToString();
    }
}
