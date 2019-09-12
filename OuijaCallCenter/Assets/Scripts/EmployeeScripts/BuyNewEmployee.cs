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
    public int maxIndex;

    AudioSource audioSc;
    public AudioClip buyEmployeeSound;

    public GameObject[] employeeScreens;

    int indexOfPosition;

    void Start()
    {
        mainCanvas.gameObject.SetActive(true);
        buyCanvas.gameObject.SetActive(false);
        employeeScreens[1].SetActive(false);
        indexOfPosition = 0;
        maxIndex = 1;
        audioSc = GetComponent<AudioSource>();
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

            audioSc.PlayOneShot(buyEmployeeSound);

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

    public void BuyScreenRightArrow()
    {
        if(indexOfPosition < maxIndex)
        {
            employeeScreens[indexOfPosition].SetActive(false);
            indexOfPosition++;
            employeeScreens[indexOfPosition].SetActive(true);
        }
    }

    public void BuyScreenLeftArrow()
    {
        if (indexOfPosition > 0)
        {
            employeeScreens[indexOfPosition].SetActive(false);
            indexOfPosition--;
            employeeScreens[indexOfPosition].SetActive(true);
        }
    }
}
