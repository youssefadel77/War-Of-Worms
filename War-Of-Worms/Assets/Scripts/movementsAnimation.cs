using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movementsAnimation : MonoBehaviour
{

    public bool isGrounded;
    private float speed;
    public float rotSpeed;
    public float jumpHeight;
    //walk speed
    private float w_speed = 0.05f;
    private int if_played = 0;
    public LaunchScript _Laun;
    //rotation speed
    private float rot_speed = 1.0f;
    Rigidbody rb;
    Animator anim;
    public GameObject grenadePrefab;
    public float throwforce = 15f;
    // Use this for initialization
    void Start()
    {
        

        rb = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();
        isGrounded = true; //indicate that we are in the ground
    }

    void movementControl(string state)
    {
        switch (state)
        {
            case "Walking":
                anim.SetBool("isWalking", true);
                anim.SetBool("isWalkingBackward", false);
                anim.SetBool("isIdle", false);
                break;
            case "WalkingBackward":
                anim.SetBool("isWalking", false);
                anim.SetBool("isWalkingBackward", true);
                anim.SetBool("isIdle", false);
                break;
            case "idle":
                anim.SetBool("isWalking", false);
                anim.SetBool("isWalkingBackward", false);
                anim.SetBool("isIdle", true);
                break;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (isGrounded)
        {
            //moving forward and backward
            if (Input.GetKey(KeyCode.W))
            {
                speed = w_speed;
                movementControl("Walking");
            }
            else if (Input.GetKey(KeyCode.S))
            {
                speed = w_speed;
                movementControl("WalkingBackward");
            }
            else
            {
                movementControl("idle");
  
            }
            //moving right and left
            if (Input.GetAxis("Mouse X") < 0)
            {
                rotSpeed = rot_speed;
            }
            else if (Input.GetAxis("Mouse X") > 0)
            {
                rotSpeed = rot_speed;
            }
            else if (Input.GetAxis("Mouse Y") > 0)
            {
                Debug.Log("Up");
            }
            
            
            else if (Input.GetMouseButton(0))
                if(if_played == 0)
                {

                    RaycastHit hit;

                    if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, 100))
                    {
                        Throw(hit);
                    }
                    if_played = 1;
                }
                
            else
            {
                rotSpeed = 0;
            }
        }
        var z = Input.GetAxis("Vertical") * speed;
        var y = Input.GetAxis("Mouse X") * rotSpeed;
        transform.Translate(0, 0, z);
        transform.Rotate(0, y, 0);
        //jumping function
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded == true)
        {
            anim.SetTrigger("isJumping");
            rb.AddForce(0, jumpHeight * Time.deltaTime, 0);
            isGrounded = false;
        }
        isGrounded = true;
    }

    void Throw(RaycastHit hit)
    {
        GameObject grenade = Instantiate(grenadePrefab, transform.position + new Vector3(0f,2f,2f) , transform.rotation);
        _Laun.GetComponent<LaunchScript>().Launch(hit,grenade);

    }

   



}
