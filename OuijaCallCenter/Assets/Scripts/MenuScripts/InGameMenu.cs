using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class InGameMenu : MonoBehaviour {

    public Canvas inGameMenuCanvas;
    bool inMenu = false;

    void Start () {
        inGameMenuCanvas.gameObject.SetActive(false);
	}
	
	void Update () {
        if (Input.GetKeyDown(KeyCode.Escape) && !inMenu)
        {
            Time.timeScale = 0;
            inMenu = true;
            inGameMenuCanvas.gameObject.SetActive(true);
        }
        else if (Input.GetKeyDown(KeyCode.Escape) && inMenu)
        {
            Time.timeScale = 1;
            inMenu = false;
            inGameMenuCanvas.gameObject.SetActive(false);
        }
    }

    public void openMenu()
    {
        inGameMenuCanvas.gameObject.SetActive(true);
        inMenu = true;
    }

    public void closeMenu()
    {
        inGameMenuCanvas.gameObject.SetActive(false);
        inMenu = false;
        Time.timeScale = 1;
    }

    public void exitGame()
    {
        Application.Quit();
    }

    public void restartGame()
    {
        SceneManager.LoadScene(0);
    }




}
