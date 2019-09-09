using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TaskManager : MonoBehaviour
{
    public Task tasks01;
    public Button taskMenuButton;
    public Animator taskButtonAnim;

    public Text task01Text;
    public Text task02Text;
    public Text task03Text;

    public GameObject tick01;
    public GameObject tick02;
    public GameObject tick03;
    public GameObject smallTick01;
    public GameObject smallTick02;
    public GameObject smallTick03;

    public GameObject taskCanvas;

    public Button rewardButton;
    public GameObject rewardHider;
    int currentReward;

    public MoneyManager moneyManager;

    void Start()
    {
        tick01.SetActive(false);
        tick02.SetActive(false);
        tick03.SetActive(false);
        smallTick01.SetActive(false);
        smallTick02.SetActive(false);
        smallTick03.SetActive(false);
        rewardButton.enabled = false;
        rewardHider.SetActive(true);
        taskMenuButton.enabled = true;
        taskCanvas.SetActive(false);
    }

    
    void Update()
    {

    }

    public void Task01Complete()
    {
        tick01.SetActive(true);
        smallTick01.SetActive(true);
    }

    public void Task02Complete()
    {
        tick02.SetActive(true);
        smallTick02.SetActive(true);
    }

    public void Task03Complete()
    {
        tick03.SetActive(true);
        smallTick03.SetActive(true);
    }

    public void AllTasksComplete(int reward)
    {
        currentReward = reward;
        rewardButton.enabled = true;
        rewardHider.SetActive(false);
        taskButtonAnim.SetBool("Shake", true);
    }

    public void EnableTaskMenu()
    {
        taskMenuButton.enabled = true;
    }

    public void CollectReward()
    {
        moneyManager.AddMoney(currentReward);
        taskButtonAnim.SetBool("Shake", false);
        tick01.SetActive(false);
        tick02.SetActive(false);
        tick03.SetActive(false);
        smallTick01.SetActive(false);
        smallTick02.SetActive(false);
        smallTick03.SetActive(false);
    }

    public void OpenTaskMenu()
    {
        taskCanvas.SetActive(true);
    }

    public void CloseTaskMenu()
    {
        taskCanvas.SetActive(false);
    }
}
