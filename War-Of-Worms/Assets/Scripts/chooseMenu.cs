using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class chooseMenu : MonoBehaviour {

    public void ToggleEndMenu()
    {
        gameObject.SetActive(true);
    }

    // Use this for initialization
    void Start()
    {
        gameObject.SetActive(false); ;
    }

    // Update is called once per frame
    void Update()
    {

    }
}
