using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {
	[Header("State Components")]
	public bool isGrounded;
	private float speed;
	public float rotSpeed;
	//public float jumpHeight;
	//walk speed     
	public float w_speed = 0.001f;     
	//rotation speed     
	private float rot_speed = 1f;

	[Header("Fight Components")]
	Rigidbody rb;
	Animator anim;
	public GameObject grenadePrefab;
	public GameObject weaponPrefab;
	public int Wepeon = 1 ;
	public LaunchScript _Laun;
	private int if_played = 0;
	public Gun G;

    public Camera boomcam;

    public GameObject weaponSide;

    public int flag = 0;
    public GameObject world;
    public AudioSource source;
    public AudioClip hit;
    // Use this for initialization
    void Start()
	{
		rb = GetComponent<Rigidbody>();
		anim = GetComponent<Animator>();
		isGrounded = true; //indicate that we are in the ground
        source = GetComponent<AudioSource>();

    }

    // Update is called once per frame
    void Update() {


		///////////////		Walking State		///////////////
		if (isGrounded)
		{             
			//moving forward and backward
			if (Input.GetKey(KeyCode.W))
			{
				speed = w_speed;
				movementControl("Move");
			} else if (Input.GetKey(KeyCode.S))
			{
				speed = w_speed;
				movementControl("Move");
			}
			else if (Input.GetKey(KeyCode.Space))
			{
				movementControl("Jumping");
			}
			else
			{
				movementControl("Idle");
			}             
			//moving right and left   
			if (Input.GetKey(KeyCode.A))
			{
				rotSpeed = rot_speed;
			}
			else if (Input.GetKey(KeyCode.D))
			{
				rotSpeed = rot_speed;
			}
			else
			{
				rotSpeed = 0;
			}
		}

		var z = Input.GetAxis("Vertical") * speed * Time.deltaTime;
		var y = Input.GetAxis("Horizontal") * rotSpeed;
		transform.Translate(0, 0, z);
		transform.Rotate(0, y, 0);
		//jumping function  
		if (Input.GetKeyDown(KeyCode.Space) && isGrounded == true)
		{
			anim.SetTrigger("isJumping");
			rb.AddForce(0, 0, 0);
			isGrounded = false;
		}

		///////////////		Fight State		///////////////
		if (Input.GetMouseButton(0)) { 
			if (Wepeon == 1)
			{
				if (if_played == 0)
				{
					//movementControl("isThrow");
					
                    RaycastHit hit;

                    if (Physics.Raycast(boomcam.transform.position, boomcam.transform.forward, out hit, 500))
                    {
                        StartCoroutine(Example(hit));
                    }
                    
                    if_played = 1;
				}
                world.GetComponent<test>().change();
            }
			else if (Wepeon == 2)
			{
				
				float nextTimeToFire = 0f;
				float fireRate = 15f;
				if (flag == 0) {
					weaponSide = Instantiate (weaponPrefab, transform.position + new Vector3 (0f, .2f, .2f), transform.rotation);
					flag = 1;
				}
				//movementControl("Gun");
                
                source.PlayOneShot(hit);
				if (Time.time >=nextTimeToFire) {
					nextTimeToFire = Time.time + 1333 / fireRate;
					//if_played = 1;
					for(int i= 1; i<= 2; i++){
						G.GetComponent<Gun>().Shoot();
					}
				}
				Destroy(weaponSide);
			}

            world.GetComponent<test>().change();
        }
		else
		{
			movementControl("Idle");
		}
	}

   
    void movementControl(string state) {
		switch (state) {

			case "Idle":
				anim.SetBool("isMove", false);
				anim.SetBool("isIdle", true);
				anim.SetBool("isJumping", false);
				anim.SetBool("isThrow", false);
				anim.SetBool("isGun", false);
				break;
			case "Move":
				anim.SetBool("isMove", true);
				anim.SetBool("isIdle", false);
				anim.SetBool("isJumping", false);
				anim.SetBool("isThrow", false);
				anim.SetBool("isGun", false);
				break;

			case "Jumping":
				anim.SetBool("isMove", false);
				anim.SetBool("isIdle", false);
				anim.SetBool("isJumping", true);
				anim.SetBool("isThrow", false);
				anim.SetBool("isGun", false);
				break;
			case "Throw":
				anim.SetBool("isMove", false);
				anim.SetBool("isIdle", false);
				anim.SetBool("isJumping", false);
				anim.SetBool("isThrow", true);
				anim.SetBool("isGun", false);
				break;
			case "Gun":
				anim.SetBool("isMove", false);
				anim.SetBool("isIdle", false);
				anim.SetBool("isJumping", false);
				anim.SetBool("isThrow", false);
				anim.SetBool("isGun", true);
				break;

		}
	}

	void OnCollisionEnter()
	{
		isGrounded = true;
	}

	IEnumerator Example(RaycastHit hit)
	{

		yield return new WaitForSeconds(1);
        Throw(hit);

    }

	void Throw(RaycastHit hit)
	{
		GameObject grenade = Instantiate(grenadePrefab, transform.position + new Vector3(0f, .5f, .5f), transform.rotation);
		_Laun.GetComponent<LaunchScript>().Launch(hit, grenade);

	}
}
