using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class changePOV : MonoBehaviour {
    public GameObject  thePlayer;
    public Camera firstCam;
    public Camera thirdCam;
    private bool check;

    // Use this for initialization
    void Start () {
        thirdCam.enabled = true ;
        firstCam.enabled = false;
        check = true;
    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKey(KeyCode.V))
        {
            if (check)
            { 
                thirdCam.enabled = false;
                firstCam.enabled = true;
            }
            else
            {
                thirdCam.enabled = true;
                firstCam.enabled = false;
            }
            check = !check;
        }
        
            
        
        



    }
}
