using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuyEmployee : MonoBehaviour {

    public int employeeID;
    public int employeeCost;

	void Start () {
		
	}


    private void OnMouseDown()
    {
        if(CallManager.instance.score >= employeeCost)
        {
            EmployeeManager.instance.purchaseEmployee(employeeID, employeeCost);
        }
    }
}
