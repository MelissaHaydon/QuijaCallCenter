using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MoneyManager : MonoBehaviour
{
    public int totalMoney;

    public Text moneyDisplay;
    public Text moneyDisplay2;


    void Start()
    {
        totalMoney = 10;
        moneyDisplay.text = totalMoney.ToString();
        moneyDisplay2.text = totalMoney.ToString();
    }

    public void addMoney(int totalToAdd)
    {
        totalMoney += totalToAdd;
        moneyDisplay.text = totalMoney.ToString();
        moneyDisplay2.text = totalMoney.ToString();
    }
}
