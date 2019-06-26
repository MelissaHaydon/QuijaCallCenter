using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EmployeeManager : MonoBehaviour {

    public static EmployeeManager instance = null;

    public Employee[] employeeList;

    void Awake()
    {

        if (instance == null)
        {

            instance = this;
        }

        else if (instance != this)
        {

            Destroy(gameObject);
        }

        DontDestroyOnLoad(gameObject);
    }

    void Start () {
		
	}
	
	
	void Update () {
		
	}

    public void purchaseEmployee(int emplyeeID, int employeeCost)
    {
        CallManager.instance.score -= employeeCost;
    }
}
