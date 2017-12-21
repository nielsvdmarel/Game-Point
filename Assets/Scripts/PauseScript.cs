using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseScript : MonoBehaviour {
    public static bool GameIsPaused = false;
    public GameObject PauseScreen;
    public GameObject PauseButton;

	void Start ()
    {
		
	}
	
	void Update ()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (GameIsPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
	}

    public void Resume()
    {
        Time.timeScale = 1;
        PauseButton.SetActive(true);
        PauseScreen.SetActive(false);
        GameIsPaused = false;
    }

   public void Pause()
    {
        Time.timeScale = 0;
        PauseButton.SetActive(false);
        PauseScreen.SetActive(true);
        GameIsPaused = true;
    }

    public void quit()
    {
        Application.Quit();
    }

    public void MainMenu()
    {
        SceneManager.LoadScene(0);
    }

}
