using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movements : MonoBehaviour {

    public GameObject grenadePrefab;
    public int Wepeon = 1 ;
    public LaunchScript _Laun;
    private int if_played = 0;
    Animator anim;
    // Use this for initialization
    void Start () {
        //rb = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();
    }

    void movementControl(string state)
    {
        switch (state)
        {
            case "Throw":
                
                anim.SetBool("Throw", true);
                anim.SetBool("Gun", false);
                anim.SetBool("idel", false);
                break;
            case "idel":
                anim.SetBool("Throw", false);
                anim.SetBool("Gun", false);
                anim.SetBool("idel", true);
                break;
            case "Gun":
                anim.SetBool("Throw", false);
                anim.SetBool("Gun", true);
                anim.SetBool("idel", false);
                break;
        }
    }

    // Update is called once per frame
    void Update ()
    {
        if (Input.GetMouseButton(0)) { 
            if (Wepeon == 1)
            {
                if (if_played == 0)
                {

                    movementControl("Throw");
                    StartCoroutine(Example());
                    
                    if_played = 1;
                }
            }
            else if (Wepeon == 2)
            {
                movementControl("Gun");
            }
        }
        else
            {
                movementControl("idel");
            }
    }

    IEnumerator Example()
    {
        
        yield return new WaitForSeconds(1);
        RaycastHit hit;

        if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, 100))
        {

            Throw(hit);
        }
    }

    void Throw(RaycastHit hit)
    {
        GameObject grenade = Instantiate(grenadePrefab, transform.position + new Vector3(0f, .2f, .2f), transform.rotation);
        _Laun.GetComponent<LaunchScript>().Launch(hit, grenade);

    }
}
