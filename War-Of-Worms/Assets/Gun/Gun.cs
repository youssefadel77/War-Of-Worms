using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour {
	
	[Header("Main Components")]
	public float damage = 10f;
	public int range = 100;
	public float impactForce = 30f;
	public Camera PlayerCam;

	[Header("Additional Components")]
	public ParticleSystem MuzzleFlash;
	public GameObject impactEffect;

	public void Shoot(){
		
		MuzzleFlash.Play ();
		RaycastHit hit;
		if(Physics.Raycast(PlayerCam.transform.position,PlayerCam.transform.forward,out hit, range)){

			Debug.Log(hit.transform.name);

			EnemyHealth Target = hit.transform.GetComponent<EnemyHealth>();

			if (Target != null)
			{
				Target.TakeDamage (damage);
			}

			if (hit.rigidbody != null)
			{
				hit.rigidbody.AddForce (-hit.normal * impactForce);
			}

			GameObject impactGo = Instantiate (impactEffect, hit.point, Quaternion.LookRotation(hit.normal));

		}

	}

}
