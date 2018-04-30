using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class EnemyHealth : MonoBehaviour {
	
	[Header("Health Component")]
	public float startHealth = 100f;
	public float health;
	public Image healthBar;

    

    // Use this for initialization
    void Start () {
		health = startHealth;
        

    }

    // Update is called once per frame
    void Update () {
		
	}

	public void TakeDamage(float amount){

		health -= amount;

		healthBar.fillAmount = health/startHealth;
        Debug.Log(healthBar);
		if (health <= 0f)
		{
			Die ();
		}

	}

	void Die(){
        
		Destroy(gameObject);
	}

}
