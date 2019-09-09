using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BuyNewEmployee : MonoBehaviour
{

    public MoneyManager moneyManager;

    public Canvas buyCanvas;
    public Canvas mainCanvas;

    public int employeeCount;

    void Start()
    {
        mainCanvas.gameObject.SetActive(true);
        buyCanvas.gameObject.SetActive(false);
    }

    void Update()
    {
        
    }

    public void PurchaseEmployee(Employee employee)
    {
        if (!employee.purchased && moneyManager.totalMoney >= employee.cost)
        {
            buyCanvas.gameObject.SetActive(false);
            mainCanvas.gameObject.SetActive(true);

            employee.gameObject.SetActive(true);
            employee.buyCloud.gameObject.SetActive(true);
            employee.buyCloud.Play();

            moneyManager.RemoveMoney(-employee.cost);

            employee.soldPortrait.gameObject.SetActive(true);
            employee.buyButton.enabled = false;

            employee.purchased = true;
            employee.isActive = true;

            employeeCount++;

        }
        else
        {

        }
    }

    public void OpenBuyScreen()
    {
        mainCanvas.gameObject.SetActive(false);
        buyCanvas.gameObject.SetActive(true);
    }

    public void closeBuyMenu()
    {
        mainCanvas.gameObject.SetActive(true);
        buyCanvas.gameObject.SetActive(false);
    }
}
