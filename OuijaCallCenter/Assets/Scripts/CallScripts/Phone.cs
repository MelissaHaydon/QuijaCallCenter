using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Phone : MonoBehaviour {

    SpriteRenderer sp;
    public Caller assignedCaller;

    Animator anim;

    public Text callerTextBox;

	void Start () {
        sp = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
        assignedCaller = null;
        callerTextBox.text = "";
	}
	
	public void RingPhone()
    {
        sp.color = Color.red;
        anim.SetBool("PhoneRinging", true);
    }

    public void AnswerPhone()
    {
        sp.color = Color.white;
        anim.SetBool("PhoneRinging", false);
        assignedCaller = GetComponent<NewCall>().GetNewCaller();
        callerTextBox.text = assignedCaller.callText.text;
    }

    public void AssignCall(GameObject assignedEmployee)
    {
        callerTextBox.text = "";
    }

}
