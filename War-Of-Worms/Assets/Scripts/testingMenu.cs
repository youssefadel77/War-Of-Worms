using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class testingMenu : MonoBehaviour {

	public GameObject chooseGunMenuUi;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update(){
		if (Input.GetKeyDown (KeyCode.V)) {
			SceneManager.LoadScene ("chooseGunMenuScene");
		} else {
			print("nothing to do whith ya ya 3m");
		
		}
	}
}
