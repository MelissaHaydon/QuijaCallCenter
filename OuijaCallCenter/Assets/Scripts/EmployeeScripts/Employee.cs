using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Employee : MonoBehaviour
{

    public int moneyEarning;
    public bool isActive;

    public int cost;
    public bool purchased;
    public bool onBreak;

    public float happiness;
    public float earnRate;
    public float originalEarnRate;

    public GameObject buyPortrait;
    public GameObject soldPortrait;

    SpriteRenderer spRend;
    public Sprite talkingSprite;
    public Sprite atDeskSprite;
    public Sprite emptyDeskSprite;
    public Button buyButton;

    public ParticleSystem buyCloud;
    public MoneyManager moneyManager;

    public Animator coinAnim;
    public float timer;

    public Event[] events;

    void Start()
    {
        spRend = GetComponent<SpriteRenderer>();
        timer = 0;
        buyCloud.gameObject.SetActive(false);
        buyCloud.Stop();
        gameObject.SetActive(false);
        soldPortrait.gameObject.SetActive(false);
        buyButton.enabled = true;
        happiness = 1f;
        onBreak = false;
}
    
    void Update()
    {
        if(isActive)
        timer += Time.deltaTime;
        if (isActive && timer>=earnRate && !onBreak)
        {
            timer = 0;
            coinAnim.SetTrigger("AnimateCoin");
            moneyManager.addMoney(moneyEarning);
        }
    }

    public void ChangeHappiness(float happinessChange)
    {
        happiness += happinessChange;
        if(happiness > 1.5f)
        {
            happiness = 1.5f;
        }
        else if (happiness < 0.5f)
        {
            happiness = 0.5f;
        }
        earnRate = originalEarnRate * happiness;
    }

    public void SpendMoney(int moneyAmount)
    {
        moneyManager.addMoney(-moneyAmount);
    }

    public void TakeBreak(float breakTime)
    {
        StartCoroutine(Break(breakTime));
    }

    IEnumerator Break(float breakTime)
    {
        spRend.sprite = emptyDeskSprite;
        onBreak = true;
        yield return new WaitForSeconds(breakTime);
        spRend.sprite = atDeskSprite;
        onBreak = false;
    }
}
