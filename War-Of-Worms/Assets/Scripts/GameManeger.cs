using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

public class GameManeger : MonoBehaviour {

    public static GameManeger instance = null;
    private bool playerActive = false;
    private bool gameOver = false;
    private bool playedDied = false;
    private bool gameStarted = false;
    [SerializeField] private GameObject mainMenu;
    //[SerializeField] private GameObject choose
    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);
        Assert.IsNotNull(mainMenu);
    }
    //
    public bool GameStarted
    {
        get
        {
            return gameStarted;
        }
    }
    // Use this for initialization
    public void EnterGame (string sceneName)
    {
        mainMenu.SetActive(false);
        gameStarted = true;
        newscene(sceneName);
    }


    //public void active()
    //{
    //    choose.SetActive(true);
    //}


    public void EndGame ()
    {
        Application.Quit();
    }

    private static void newscene(string sceneName)
    {
        Application.LoadLevel(sceneName);
    }
}
