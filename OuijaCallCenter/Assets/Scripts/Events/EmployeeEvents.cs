using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EmployeeEvents : MonoBehaviour
{
    public Employee[] employees;
    public Employee selectedEmployee;
    public DialogueManager dialogueManager;

    Event chosenEvent;
    string[] sentences;
    string positiveResponse;
    string negativeResponse;

    bool eventActive;
    public Button buyButton;

    float eventTimer;
    public float timeBetweenEvents;

    public int completedEvents;

    void Start()
    {
        eventActive = false;
        completedEvents = 0;
    }


    private void Update()
    {
        if(!eventActive)
        eventTimer += Time.deltaTime;
        if(eventTimer >= timeBetweenEvents && !eventActive)
        {
            ChooseEmployee();
            ChooseEvent();
            dialogueManager.NewTextWithResponse(sentences, positiveResponse, negativeResponse);
            eventActive = true;
            buyButton.enabled = false;
        }
    }

    public void ChooseEmployee()
    {
        selectedEmployee = employees[Random.Range(0, employees.Length)];
        if (!selectedEmployee.purchased || selectedEmployee.onBreak)
        {
            ChooseEmployee();
        }
    }

    public void ChooseEvent()
    {
        chosenEvent = selectedEmployee.events[Random.Range(0, selectedEmployee.events.Length)];
        sentences = chosenEvent.sentences;
        negativeResponse = chosenEvent.negativeResponse;
        positiveResponse = chosenEvent.positiveResponse;
    }

    public void EventResult(bool succeeded)
    {
        if (succeeded)
        {
            selectedEmployee.ChangeHappiness(-0.25f);
            completedEvents++;
            if (chosenEvent.moneyEvent)
            {
                selectedEmployee.SpendMoney(chosenEvent.eventCost);
            }
            else if (chosenEvent.breakEvent)
            {
                selectedEmployee.TakeBreak(chosenEvent.breakTime);
            }
        }
        else
        {
            selectedEmployee.ChangeHappiness(0.25f);
        }
    }

    public void EventFinished()
    {
        eventActive = false;
        buyButton.enabled = true;
        eventTimer = 0;
    }
 
}
