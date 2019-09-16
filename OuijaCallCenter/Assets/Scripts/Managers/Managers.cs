using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Managers : MonoBehaviour
{
    public GameObject managers;
    public GameObject employees;
    public GameObject items;
    public GameObject mainCanvas;

    int indexOfPosition;
    public int maxIndex;

    public GameObject[] managerScreens;

    void Start()
    {
        indexOfPosition = 0;
        maxIndex = 1;
        managerScreens[1].SetActive(false);
        managers.SetActive(false);
        employees.SetActive(false);
        items.SetActive(false);
    }

    
    void Update()
    {
        
    }

    public void ShowManagers()
    {
        managers.SetActive(true);
        employees.SetActive(false);
        items.SetActive(false);
    }

    public void ShowEmployees()
    {
        managers.SetActive(false);
        employees.SetActive(true);
        items.SetActive(false);
    }

    public void ShowItems()
    {
        managers.SetActive(false);
        employees.SetActive(false);
        items.SetActive(true);
    }

    public void BackButton()
    {
        managers.SetActive(false);
        employees.SetActive(false);
        items.SetActive(false);
        mainCanvas.SetActive(true);
    }

    public void RightArrow()
    {
        if (indexOfPosition < maxIndex)
        {
            managerScreens[indexOfPosition].SetActive(false);
            indexOfPosition++;
            managerScreens[indexOfPosition].SetActive(true);
        }
    }

    public void LeftArrow()
    {
        if (indexOfPosition > 0)
        {
            managerScreens[indexOfPosition].SetActive(false);
            indexOfPosition--;
            managerScreens[indexOfPosition].SetActive(true);
        }
    }
}
