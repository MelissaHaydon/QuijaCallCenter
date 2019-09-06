using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Task : MonoBehaviour
{
    bool task01Complete;
    bool task02Complete;
    bool task03Complete;
    bool allTasksComplete;

    public BuyNewEmployee employeeManager;
    public MoneyManager moneyManager;
    public EmployeeEvents eventManager;


    void Start()
    {
        task01Complete = false;
        task02Complete = false;
        task03Complete = false;
        allTasksComplete = false;
    }

    void Update()
    {
        if(task01Complete && task02Complete && task03Complete)
        {
            allTasksComplete = true;
        }
    }

    void CheckTask01()
    {
        if(employeeManager.employeeCount >= 2)
        {
            task01Complete = true;
        }
    }

    void CheckTask02()
    {
        if(moneyManager.totalMoney >= 200)
        {
            task02Complete = true;
        }
    }

    void CheckTask03()
    {
        if(eventManager.completedEvents >= 3)
        {
            task03Complete = true;
        }
    }
    
}
