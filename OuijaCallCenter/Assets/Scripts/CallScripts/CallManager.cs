using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CallManager : MonoBehaviour {

    float phoneTimer;
    float roundTimer;
    Phone phone;

    public AudioClip ringSound;
    AudioSource audioSC;

    public Text winLoseTextBox;

    public static CallManager instance = null;

    enum CallState {Idle, Ringing, Assigning}
    CallState callState;

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

    }

    void Start () {
        callState = CallState.Idle;
        phone = GetComponent<Phone>();
        audioSC = GetComponent<AudioSource>();
        phoneTimer = 0;
        roundTimer = 0;
	}
	
	void Update () {
        phoneTimer += Time.deltaTime;
        roundTimer += Time.deltaTime;
        if(phoneTimer >= 2f && callState == CallState.Idle)
        {
            callState = CallState.Ringing;
            phone.RingPhone();
            audioSC.PlayOneShot(ringSound);
        }
        if(roundTimer >= 60f)
        {
            if(MoneyManager.instance.totalMoney >= 20)
            {
                winGame();
            }
            else
            {
                loseGame();
            }
        }
	}

    public void ClickOnEmployee(Employee selectedEmployee)
    {
        if(callState == CallState.Assigning)
        {
            selectedEmployee.takeCall(phone.assignedCaller);
            callState = CallState.Idle;
            phone.callerTextBox.text = "";
            phoneTimer = 0f;
        }
    }

    void winGame()
    {
        winLoseTextBox.text = "You Win!";
        StartCoroutine("Wait");
        SceneManager.LoadScene(0);
    }

    void loseGame()
    {
        winLoseTextBox.text = "You Lose!";
        StartCoroutine("Wait");
    }

    private void OnMouseDown()
    {
        if(callState == CallState.Ringing)
        {
            phone.AnswerPhone();
            callState = CallState.Assigning;
        }
    }

    IEnumerator Wait()
    {
        yield return new WaitForSeconds(3);
        SceneManager.LoadScene(0);
    }

}
