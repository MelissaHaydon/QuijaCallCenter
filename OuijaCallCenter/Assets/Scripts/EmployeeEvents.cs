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

    float eventTimer;
    public float timeBetweenEvents;

    void Start()
    {
        eventActive = false;
    }


    private void Update()
    {
        eventTimer += Time.deltaTime;
        if(eventTimer >= timeBetweenEvents && !eventActive)
        {
            ChooseEmployee();
            ChooseEvent();
            dialogueManager.NewTextWithResponse(sentences, positiveResponse, negativeResponse);
            eventActive = true;
        }
    }

    public void ChooseEmployee()
    {
        selectedEmployee = employees[Random.Range(0, employees.Length-1)];
    }

    public void ChooseEvent()
    {
        chosenEvent = selectedEmployee.events[Random.Range(0, selectedEmployee.events.Length - 1)];
        sentences = chosenEvent.sentences;
        negativeResponse = chosenEvent.negativeResponse;
        positiveResponse = chosenEvent.positiveResponse;
    }

    public void EventResult(bool succeeded)
    {
        if (succeeded)
        {
            selectedEmployee.ChangeHappiness(0.5f);
        }
        else
        {
            selectedEmployee.ChangeHappiness(-0.5f);
        }
    }

    public void EventFinished()
    {
        eventActive = false;
        eventTimer = 0;
    }
    
}
