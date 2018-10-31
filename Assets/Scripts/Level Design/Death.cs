using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Death : MonoBehaviour
{

	// public GameObject gameOver;

	void OnTriggerEnter (Collider col)
	{
		//if (col.gameObject.name == "Running") {
		
//			player = col.gameObject.GetComponent< Player > ();
			//Player.Damage(damageAmount);
			//damageTimeStart = Time.time;
			Destroy (col.gameObject);
			//gameOver.SetActive (true);
		}
	}
