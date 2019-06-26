using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour {

    public static MenuManager instance = null;

    public Canvas buyScreenCanvas;
    public Canvas inGameUICanvas;

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
        inGameUICanvas.gameObject.SetActive(true);
        buyScreenCanvas.gameObject.SetActive(false);
    }
	
	
	void Update () {
		
	}

    public void ShowBuyScreen()
    {
        buyScreenCanvas.gameObject.SetActive(true);
        inGameUICanvas.gameObject.SetActive(false);
    }

    public void CloseBuyScreen()
    {
        buyScreenCanvas.gameObject.SetActive(false);
        inGameUICanvas.gameObject.SetActive(true);
    }
}
