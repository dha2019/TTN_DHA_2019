using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOver : MonoBehaviour {

    public void quit()
    {
        Application.Quit();
    }
	
	// Update is called once per frame
	public void restart()
    {
        Application.LoadLevel(Application.loadedLevel);
    }
}
