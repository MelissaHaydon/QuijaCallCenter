using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Phone : MonoBehaviour {

    SpriteRenderer sp;
    public Caller assignedCaller;

    public Text callerTextBox;

	void Start () {
        sp = GetComponent<SpriteRenderer>();
        assignedCaller = null;
        callerTextBox.text = "";
	}
	
	public void RingPhone()
    {
        sp.color = Color.red;
    }

    public void AnswerPhone()
    {
        sp.color = Color.white;
        assignedCaller = GetComponent<NewCall>().GetNewCaller();
        callerTextBox.text = assignedCaller.callText.text;
    }

    public void AssignCall(GameObject assignedEmployee)
    {
        callerTextBox.text = "";
    }

}
