using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBoost : MonoBehaviour
{
	public int healthBoost;
	// Use this for initialization
	void Start ()
	{
		
	}
	
	// Update is called once per frame
	void Update ()
	{
		
	}

	void OnCollisionEnter (Collision col)
	{

		if (col.gameObject.tag == "Player") {

			col.transform.GetComponent<Health> ().playerHealth += healthBoost;


		}
		Destroy (this.gameObject);
	}
}
