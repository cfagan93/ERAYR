using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
	public Animator anim;
	// Use this for initialization
	void Start ()
	{
		
	}
	
	// Update is called once per frame
	void Update ()
	{
		
	}

	void OnTriggerEnter (Collider col)
	{

		if (col.gameObject.tag == "Player") {

			Debug.Log ("Player");

			if (col.gameObject.GetComponent<KeyManger> ().Key1 == true) {
				anim.SetBool ("OpenDoor", true);
				Debug.Log ("Open Door");
			}
		
		}

	}
}
