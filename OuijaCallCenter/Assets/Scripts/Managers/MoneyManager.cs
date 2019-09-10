using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class MoneyManager : MonoBehaviour
{
    public double totalMoney;
    public double lifetimeMoney;

    public Text moneyDisplay;
    public Text moneyDisplay2;


    void Start()
    {
        totalMoney = 100;
        lifetimeMoney = 100;
        moneyDisplay.text = totalMoney.ToString();
        moneyDisplay2.text = totalMoney.ToString();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.M))
        {
            AddMoney(10000);
        }
    }

    public void AddMoney(int totalToAdd)
    {
        totalMoney += totalToAdd;
        lifetimeMoney += totalToAdd;
        //moneyDisplay.text = totalMoney.ToString();
        //moneyDisplay2.text = totalMoney.ToString();
        moneyDisplay.text = MoneyConverter(totalMoney);
        moneyDisplay2.text = MoneyConverter(totalMoney);
    }

    public void RemoveMoney(int totalToRemove)
    {
        totalMoney += totalToRemove;
        //moneyDisplay.text = totalMoney.ToString();
        //moneyDisplay2.text = totalMoney.ToString();
        moneyDisplay.text = MoneyConverter(totalMoney);
        moneyDisplay2.text = MoneyConverter(totalMoney);
    }


        public static string MoneyConverter(double num)
        {
            double numStr;
            string suffix;
            if (num < 1000d)
            {
                numStr = num;
                suffix = "";
            return numStr.ToString("f0") + suffix;
        }
            else if (num < 1000000d)
            {
                numStr = num / 1000d;
                suffix = "K";
            return numStr.ToString("f0") + suffix;
        }
            else if (num < 1000000000d)
            {
                numStr = num / 1000000d;
                suffix = "M";
            return numStr.ToString("f1") + suffix;
        }
            else
            {
                numStr = num / 1000000000d;
                suffix = "B";
            return numStr.ToString("f1") + suffix;
        }
            
        }
    }
