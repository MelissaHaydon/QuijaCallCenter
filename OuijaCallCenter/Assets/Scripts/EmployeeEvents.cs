using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EmployeeEvents : MonoBehaviour
{
    public Employee[] employees;
    public Employee selectedEmployee;

    Event chosenEvent;
    public string[] sentences;
    private int index;

    public Text textDisplay;
    public float typingSpeed;




    void Start()
    {
        
    }

    
    void Update()
    {
        
    }

    public void ChooseEmployee()
    {
        selectedEmployee = employees[Random.Range(0, employees.Length-1)];
    }

    public void ChooseEvent()
    {
        chosenEvent = selectedEmployee.events[Random.Range(0, selectedEmployee.events.Length - 1)];
        sentences = chosenEvent.sentences;
    }

    IEnumerator Type()
    {
        foreach (char letter in sentences[index].ToCharArray())
        {
            textDisplay.text += letter;
            yield return new WaitForSeconds(typingSpeed);
        }

    }

}
