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
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    //
    public void PlayerDead()
    {
        playedDied = true;
    }
    //
    public void EnterGame (string sceneName)
    {
        mainMenu.SetActive(false);
        gameStarted = true;
        newscene(sceneName);
    }

    private static void newscene(string sceneName)
    {
        Application.LoadLevel(sceneName);
    }
}
