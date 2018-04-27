using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyObjectWhenFallingScript : MonoBehaviour {




	void OnCollisionEnter(Collision other)
	{
		if (other.gameObject.tag == "death") {
			Destroy (this.gameObject);
			Debug.Log ("destasdhasldhlashdlhalshdlahsdljharoyed");
		}
	}



}
