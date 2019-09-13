using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Managers : MonoBehaviour
{
    public GameObject managers;
    public GameObject employees;
    public GameObject items;

    void Start()
    {
        
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
}
