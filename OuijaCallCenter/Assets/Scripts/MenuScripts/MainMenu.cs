using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {

    public Canvas mainMenuCanvas;
    public Canvas controlsCanvas;


    void Start () {
        mainMenuCanvas.gameObject.SetActive(true);
        controlsCanvas.gameObject.SetActive(false);
	}
	
    public void showControlMenu()
    {
        mainMenuCanvas.gameObject.SetActive(false);
        controlsCanvas.gameObject.SetActive(true);
    }

    public void showMainMenu()
    {
        mainMenuCanvas.gameObject.SetActive(true);
        controlsCanvas.gameObject.SetActive(false);
    }

    public void startGame()
    {
        SceneManager.LoadScene(1);
    }

    public void exitGame()
    {
        Application.Quit();
    }
}
