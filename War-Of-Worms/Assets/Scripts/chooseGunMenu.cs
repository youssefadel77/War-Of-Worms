using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class chooseGunMenu : MonoBehaviour {
	//variable will be used to know which gun is selected
	public int weapon;
	//the UI that i will drag and drop the menu panel on it
	public GameObject chooseGunMenuUi;
	bool checkChooseMenu = false;
	public static bool GameIsPaused = false;

	void Update(){
		if (Input.GetKeyDown (KeyCode.V)) {
			//to switch between menus when i click "V"
			checkChooseMenu = !checkChooseMenu;
			chooseGunMenuUi.SetActive (checkChooseMenu);

		} 
	}




	// this is called when a granade is selected 
	public void granadeSelected(){
		weapon = 1;
		Debug.Log (weapon);
		checkChooseMenu = !checkChooseMenu;
		chooseGunMenuUi.SetActive (false);

	}
	
	// this is called when a shoot gun is selected 
	public void gunSelected(){
		weapon = 2;
		Debug.Log (weapon);
		checkChooseMenu = !checkChooseMenu;
		chooseGunMenuUi.SetActive (false);

	}
}
