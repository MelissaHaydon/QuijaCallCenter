using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cubicles : MonoBehaviour {

    public int cubicleID;
    public Vector3 employeeSpawnPos;
    public GameObject heldEmployee;

	void Start () {
        EmployeeManager.instance.cubiclePositions.Add(cubicleID, employeeSpawnPos);
        heldEmployee = null;
	}

}
