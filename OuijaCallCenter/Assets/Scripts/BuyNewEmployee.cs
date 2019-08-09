using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BuyNewEmployee : MonoBehaviour
{

    public GameObject ghostEmployee;
    public Dialogue dialogue;
    public EmployeeMoney employMoney;
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

    bool purchased;

    void Start()
    {
        cloud.gameObject.SetActive(false);
        cloud.Stop();
        ghostEmployee.SetActive(false);
        purchased = false;
        moneyDisplay.text = 10.ToString();
        mainCanvas.gameObject.SetActive(true);
        buyCanvas.gameObject.SetActive(false);
        dialogueDisplay2.gameObject.SetActive(false);
        comeBackSoon.gameObject.SetActive(false);
    }

    void Update()
    {
        
    }

    public void PurchaseEmployee()
    {
        if (!purchased)
        {
            buyCanvas.gameObject.SetActive(false);
            mainCanvas.gameObject.SetActive(true);
            ghostEmployee.SetActive(true);
            cloud.gameObject.SetActive(true);
            cloud.Play();
            arrow02.SetActive(false);
            moneyDisplay.text = 0.ToString();
            moneyDisplay2.text = 0.ToString();
            ghostPortrait.gameObject.SetActive(false);
            comeBackSoon.gameObject.SetActive(true);
            dialogue.textFinished = true;
            dialogue.continueButton.SetActive(false);
            dialogue.textDisplay.gameObject.SetActive(false);
            dialogueDisplay2.gameObject.SetActive(true);
            dialogueDisplay2.text = "Now sit back and watch the money roll in!";
            employMoney.isActive = true;
            purchased = true;
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
