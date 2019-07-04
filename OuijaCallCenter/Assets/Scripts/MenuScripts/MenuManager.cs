using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour {

    public static MenuManager instance = null;

    public Canvas buyScreenCanvas;
    public Canvas inGameUICanvas;
    public Canvas placeEmployeeCanvas;

    public Image arrowImage;

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
        inGameUICanvas.gameObject.SetActive(true);
        buyScreenCanvas.gameObject.SetActive(false);
        placeEmployeeCanvas.gameObject.SetActive(false);
    }
	
	
	void Update () {
		
	}

    public void ShowBuyScreen()
    {
        buyScreenCanvas.gameObject.SetActive(true);
        inGameUICanvas.gameObject.SetActive(false);
        placeEmployeeCanvas.gameObject.SetActive(false);
    }

    public void ShowMainScreen()
    {
        buyScreenCanvas.gameObject.SetActive(false);
        placeEmployeeCanvas.gameObject.SetActive(false);
        inGameUICanvas.gameObject.SetActive(true);
    }

    public void ShowPlacementScreen()
    {
        buyScreenCanvas.gameObject.SetActive(false);
        inGameUICanvas.gameObject.SetActive(false);
        placeEmployeeCanvas.gameObject.SetActive(true);
    }

    public void hideImage()
    {
        arrowImage.gameObject.SetActive(false);
    }
}
