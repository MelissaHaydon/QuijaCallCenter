using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MoneyManager : MonoBehaviour {

    public Text moneyTextBox;

    public float totalMoney;

    public static MoneyManager instance = null;

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

    }

    void Start () {
        AddMoney(3);
	}

    public void CalculateMoney(EmployeeStat stat)
    {
        totalMoney += stat.Value;
    }

    public void AddMoney(int moneyAmount)
    {
        totalMoney += moneyAmount;
        moneyTextBox.text = totalMoney.ToString();
    }

    public void UpdateMoney()
    {
        moneyTextBox.text = totalMoney.ToString();
    }
}
