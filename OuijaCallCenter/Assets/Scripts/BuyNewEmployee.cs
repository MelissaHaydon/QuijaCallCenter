using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BuyNewEmployee : MonoBehaviour
{

    public GameObject ghostEmployee;
    public Dialogue dialogue;

    public MoneyManager moneyManager;
    public ParticleSystem cloud;
    public Image ghostPortrait;

    public Canvas buyCanvas;
    public Canvas mainCanvas;

    public Text moneyDisplay;
    public Text moneyDisplay2;
    public Text dialogueDisplay;
    public Text dialogueDisplay2;
    public Text comeBackSoon;

    public GameObject arrow01;
    public GameObject arrow02;



    void Start()
    {
        cloud.gameObject.SetActive(false);
        cloud.Stop();
        //ghostEmployee.SetActive(false);
        moneyDisplay.text = 10.ToString();
        mainCanvas.gameObject.SetActive(true);
        buyCanvas.gameObject.SetActive(false);
        dialogueDisplay2.gameObject.SetActive(false);
        comeBackSoon.gameObject.SetActive(false);
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

            moneyManager.addMoney(-employee.cost);

            employee.soldPortrait.gameObject.SetActive(true);
            employee.buyButton.enabled = false;

            //ghostPortrait.gameObject.SetActive(false);
            //comeBackSoon.gameObject.SetActive(true);

            employee.purchased = true;
            employee.isActive = true;

            //dialogue.textFinished = true;
            //dialogue.continueButton.SetActive(false);
            //dialogue.textDisplay.gameObject.SetActive(false);
            //dialogueDisplay2.gameObject.SetActive(true);
            //dialogueDisplay2.text = "Now sit back and watch the money roll in!";
            //purchased = true;
        }
        else
        {

        }
    }

    public void OpenBuyScreen()
    {
        mainCanvas.gameObject.SetActive(false);
        buyCanvas.gameObject.SetActive(true);
        arrow01.SetActive(false);
    }

    public void closeBuyMenu()
    {
        mainCanvas.gameObject.SetActive(true);
        buyCanvas.gameObject.SetActive(false);
    }
}
