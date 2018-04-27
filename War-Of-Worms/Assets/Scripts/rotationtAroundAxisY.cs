using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotationtAroundAxisY : MonoBehaviour {

	public GameObject Lava;
	
	// Update is called once per frame
	void Update () {
		Lava.transform.Rotate (0, 1*Time.deltaTime, 0);
	}

	void OnCollisionEnter(Collision other)
	{
		if (other.gameObject.tag == "death") {
			Destroy (this.gameObject);
			Debug.Log ("destasdhasldhlashdlhalshdlahsdljharoyed");
		}
	}
}
