using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour {

    public GameObject PauseUI;           // ten bien khong anh huong lam. Chu yeu thao tac vs enginear

    private bool paused = false;

	// Use this for initialization
	void Start () {
        PauseUI.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetButtonDown("Pause"))
        {
            paused = !paused;
        }

        if(paused)
        {
            PauseUI.SetActive(true);
            Time.timeScale = 0;
        }

        if (!paused)
        {
            PauseUI.SetActive(false);
            Time.timeScale = 1;
        }

        
      
	}
    //su kien khi an resume,start,menu,exit
    public void Resume()
    {
        paused = false;
    }
    public void Restart()
    {
        Application.LoadLevel(Application.loadedLevel);
    }

    public void MainMenu()
    {
        Application.LoadLevel(1);           //level cua game dat la 1 trong build settings
    }
    public void Exit()
    {
        Application.Quit();
    }
}
