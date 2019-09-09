using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Task : MonoBehaviour
{
    bool task01Complete;
    bool task02Complete;
    bool task03Complete;
    public bool allTasksComplete;

    public Text task01Status;
    public Text task02Status;
    public Text task03Status;

    public BuyNewEmployee employeeManager;
    public MoneyManager moneyManager;
    public EmployeeEvents eventManager;
    public TaskManager taskManager;


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
            taskManager.AllTasksComplete(2000);
            this.enabled = false;
        }
        CheckTask01();
        CheckTask02();
        CheckTask03();
    }

    void CheckTask01()
    {
        if(employeeManager.employeeCount >= 2)
        {
            task01Complete = true;
            taskManager.Task01Complete();
        }
        task01Status.text = employeeManager.employeeCount.ToString() + "/2";
    }

    void CheckTask02()
    {
        if(moneyManager.lifetimeMoney >= 1000)
        {
            task02Complete = true;
            taskManager.Task02Complete();
        }
        task02Status.text = moneyManager.lifetimeMoney.ToString() + "/1000";
    }

    void CheckTask03()
    {
        if(eventManager.completedEvents >= 3)
        {
            task03Complete = true;
            taskManager.Task03Complete();
        }
        task03Status.text = eventManager.completedEvents.ToString() + "/2";
    }
    
}
