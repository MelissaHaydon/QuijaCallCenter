using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EmployeeManager : MonoBehaviour {

    public static EmployeeManager instance = null;

    public GameObject[] employeeList;

    //int[][] cubicleID;

    public Cubicles[] cubicleList;

    public Dictionary<int, Vector3> cubiclePositions = new Dictionary<int, Vector3>();
   // public Dictionary<int, GameObject> cubicleUsers = new Dictionary<int, GameObject>();

    GameObject heldEmployee;

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
        heldEmployee = null;
	}
	
	
	void Update () {
		
	}

    public void purchaseEmployee(int employeeID, int employeeCost)
    {
        MenuManager.instance.ShowPlacementScreen();
        MoneyManager.instance.totalMoney -= employeeCost;
        MoneyManager.instance.UpdateMoney();
        heldEmployee = employeeList[employeeID];

    }

    public void placeEmployee(int cubicleID)
    {
        if(cubicleList[cubicleID].heldEmployee == null)
        {
            cubicleList[cubicleID].heldEmployee = heldEmployee;
            Instantiate(heldEmployee, (cubiclePositions[cubicleID]), Quaternion.identity);
            MenuManager.instance.ShowMainScreen();
        }
        
    }
}
