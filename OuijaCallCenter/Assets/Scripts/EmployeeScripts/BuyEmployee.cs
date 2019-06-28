using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BuyEmployee : MonoBehaviour {

    public int employeeID;
    public int employeeCost;

	void Start () {
		
	}


    public void Purchase()
    {
        if(MoneyManager.instance.totalMoney >= employeeCost)
        {
            EmployeeManager.instance.purchaseEmployee(employeeID, employeeCost);
        }
    }


}
