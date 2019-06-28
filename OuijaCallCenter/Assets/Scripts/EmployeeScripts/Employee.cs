using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Employee : MonoBehaviour {

    enum EmployeeState { Idle, OnCall };
    public enum EmployeeType { Demon, Grandma, Ghost };

    Caller assignedCaller;
    EmployeeState curState;
    public EmployeeType employeeType;
    float callTimer;

    SpriteRenderer sp;

	void Start () {
        sp = GetComponent<SpriteRenderer>();
        curState = EmployeeState.Idle;
        callTimer = 0;
	}

    void Update()
    {
        if(curState == EmployeeState.OnCall)
        {
            callTimer += Time.deltaTime;
        }
        if (curState == EmployeeState.OnCall && callTimer >= 4f)
        {
            if(employeeType.ToString() == assignedCaller.prefferedEmployeeType.ToString())
            {
                MoneyManager.instance.AddMoney(3);
            }
            else
            {
                MoneyManager.instance.AddMoney(1);
            }
            curState = EmployeeState.Idle;
            sp.color = Color.white;
            callTimer = 0f;
        }
    }

    public void takeCall(Caller caller)
    {
        assignedCaller = caller;
        sp.color = Color.green;
        curState = EmployeeState.OnCall;
    }

    public void OnMouseDown()
    {
        if (curState == EmployeeState.Idle)
        {
            CallManager.instance.ClickOnEmployee(this);
        }
    }

}
