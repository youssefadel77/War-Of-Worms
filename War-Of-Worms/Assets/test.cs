using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Cameras;
using UnityStandardAssets.Characters.ThirdPerson;

public class test : MonoBehaviour {

    public GameObject [] players;
    GameObject currentplayer;
    int playerindex;
    // Use this for initialization
    void Start () {
        playerindex = 0;
        currentplayer = players [0];
        currentplayer.GetComponent<changePOV>().enabled = true;
        currentplayer.GetComponent<PlayerMovement>().enabled = true;
        //Debug.Log(playerindex);
    }
    public void change()
    {
        playerindex++;

        if (playerindex == players.Length)
        {
            playerindex = 0;
        }
        //currentplayer.GetComponent<changePOV>().thirdCam.enabled = false;
        if (currentplayer.tag == "Player") { 
        currentplayer.GetComponent<changePOV>().enabled = false;
        currentplayer.GetComponent<PlayerMovement>().enabled = false;
        Debug.Log("PL");

        }
        else if (currentplayer.tag == "Ai")
        {
            currentplayer.GetComponent<changePOV>().enabled = false;
            currentplayer.GetComponent<AIscript>().enabled = false;
            Debug.Log("AI");
        }
        //currentplayer.GetComponent<changePOV>().thirdCam.enabled = false;
        //currentplayer.GetComponent<changePOV>().firstCam.enabled = false;
        //currentplayer.GetComponent<changePOV>().firstCam.enabled = false;
        //currentplayer.GetComponent<changePOV>().firstCam.enabled = false;
        currentplayer = players[playerindex];
        if (currentplayer.tag == "Player")
        {
            currentplayer.GetComponent<changePOV>().enabled = true;
            currentplayer.GetComponent<PlayerMovement>().enabled = true;
            Debug.Log("PL");
        }
        else if (currentplayer.tag == "Ai")
        {
            currentplayer.GetComponent<changePOV>().enabled = true;
            currentplayer.GetComponent<AIscript>().enabled = true;
            Debug.Log("AI");
        }
        //GameObject.Find ("Camera").GetComponent<AutoCam>().myTarget = players[playerindex].transform;
    }

    // Update is called once per frame
    void Update () {
        

        //yield WaitForSeconds(10);


        if (Input.GetKey(KeyCode.O))
        {
            change();
        }
    }
}
