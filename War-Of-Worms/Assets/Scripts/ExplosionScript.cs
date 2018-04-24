using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionScript : MonoBehaviour {

	public float delay = 10f;

	float countdown;
    public float radius = 5f;
    public float force = 700f;
	bool hasexploded = false;
	public GameObject explosionEffect;



    // Use this for initialization
    void Start () {
		countdown = delay;
	}
	
	// Update is called once per frame
	void Update () {
		countdown -= Time.deltaTime;
		if(countdown <= 0f && hasexploded == false){
			Explode();
			hasexploded = true;
        }
        
    }

	void Explode(){
        Debug.Log("Explode");
        Instantiate(explosionEffect,transform.position,transform.rotation);
        Collider[] colliderstodestroy = Physics.OverlapSphere(transform.position, radius);
        foreach(Collider nearbyObject in colliderstodestroy)
        {
            Destribute des = nearbyObject.GetComponent<Destribute>();
            if (des != null)
            {
                des.Destroy();
            }
        }
        Collider[] colliderstomove = Physics.OverlapSphere(transform.position, radius);
        foreach(Collider nearbyObject in colliderstomove)
        {
            Rigidbody rb = nearbyObject.GetComponent<Rigidbody>();
            if (rb != null)
            {
                rb.AddExplosionForce(force, transform.position, radius);

            }
        }

        Destroy(gameObject);
    }
}
