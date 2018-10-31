using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeScript : MonoBehaviour
{
	public int damage = 10;

	// Use this for initialization
	void Start ()
	{ 
		
		
	}
	
	// Update is called once per frame
	void Update ()
	{


		
	}

	void OnCollisionEnter (Collision other)
	{

		//Do damage to other object here if needs be

		if (other.gameObject.tag == "Player") {

			if (!other.gameObject.GetComponent<Health> ().invincible) {
			
				other.gameObject.GetComponent<Health> ().playerHealth -= damage;
			
			}

		}

		Destroy(gameObject);

	}

}
