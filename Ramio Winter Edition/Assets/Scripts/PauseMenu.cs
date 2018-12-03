using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		//check to see if the p key is pressed
        if(Input.GetKeyDown(KeyCode.P))
        {
            //if it is pressed, stop stuff from moving
            if (Time.timeScale == 1)
            {
                Time.timeScale = 0;
                //and make the pause menu visible
                //tell canvas to be on
                GetComponent<Canvas>().enabled = true;
            }else if(Time.timeScale == 0)
            {
                //unpause
                Resume();
            }
        }
    }
    public void Resume()
    {
        Time.timeScale = 1;
        GetComponent<Canvas>().enabled = false;
    }
    public void QuitGame()
    {
        Application.Quit();
    }
}
