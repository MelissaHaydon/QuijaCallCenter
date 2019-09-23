using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisasterManager : MonoBehaviour
{
    public Employee[] employees;
    Employee selectedEmployee;

    bool disasterActive;

    float timer;

    void Start()
    {
        timer = 0f;
        disasterActive = false;
    }

    void Update()
    {
        if(!disasterActive)
        timer += Time.deltaTime;
        if(timer >= 10)
        {
            disasterActive = true;
            ChooseEmployee();
            selectedEmployee.disasterOccuring = true;
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
}
