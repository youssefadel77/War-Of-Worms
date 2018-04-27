using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pauseMenu : MonoBehaviour {


	public static bool GameIsPaused = false;
	public GameObject pauseMenuUi;
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.Escape)) {
			if (GameIsPaused) {
				Resume();
			} else {
				Pause();
			}


		}
		
	}
	public void Resume(){
		//is used to disable the pause menu 
		pauseMenuUi.SetActive (false);
		//is used to resume the game
		Time.timeScale = 1f;
		// change variable to false so i can use it later
		GameIsPaused = false;

	}
	void Pause(){
		//is used to enable the pause menu 
		pauseMenuUi.SetActive (true);
		//is used to pause the game
		Time.timeScale = 0f;
		// change variable to true so i can use it later
		GameIsPaused = true;

	}

	public void load (){
		//is used to resume the game
		Time.timeScale = 1f;
		Debug.Log ("loading menu");

	
	}

	public void Quit(){
		Debug.Log ("quitting game");
		Application.Quit();
	
	}
}
