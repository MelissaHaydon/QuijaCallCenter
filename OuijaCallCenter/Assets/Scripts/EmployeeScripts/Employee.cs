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
    public GameObject moneyReadyCoin;
    public GameObject computerScreen;

    SpriteRenderer spRend;
    public Sprite talkingSprite;
    public Sprite atDeskSprite;
    public Sprite emptyDeskSprite;
    public Button buyButton;

    public ParticleSystem buyCloud;
    public MoneyManager moneyManager;

    public Animator coinAnim;
    public float timer;
    public bool moneyReady;
    AudioSource audioSc;
    public AudioClip moneyGainSound;

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
        moneyReady = false;
        moneyReadyCoin.SetActive(false);
        audioSc = GetComponent<AudioSource>();
        computerScreen.SetActive(true);

}
    
    void Update()
    {
        if(isActive && !onBreak)
        timer += Time.deltaTime;
        if (isActive && timer>=earnRate && !onBreak && !moneyReady)
        {
            moneyReady = true;
            moneyReadyCoin.SetActive(true);
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
        moneyManager.RemoveMoney(-moneyAmount);
    }

    public void TakeBreak(float breakTime)
    {
        StartCoroutine(Break(breakTime));
    }

    IEnumerator Break(float breakTime)
    {
        spRend.sprite = emptyDeskSprite;
        onBreak = true;
        computerScreen.SetActive(false);
        yield return new WaitForSeconds(breakTime);
        spRend.sprite = atDeskSprite;
        onBreak = false;
        computerScreen.SetActive(true);
    }

    private void OnMouseDown()
    {
        if (moneyReady)
        {
            moneyReady = false;
            timer = 0;
            coinAnim.SetTrigger("AnimateCoin");
            moneyManager.AddMoney(moneyEarning);
            moneyReadyCoin.SetActive(false);
            audioSc.PlayOneShot(moneyGainSound);
        }
    }
}
