using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class crateSpawner : MonoBehaviour {
	
	public GameObject crate;

	// Use this for initialization
	void Start () {
		InvokeRepeating ("dropCrate", 2.0f, 0.80f);
	}
	
	// Update is called once per frame
	void dropCrate() {

		GameObject crateInstance = Instantiate (crate, transform.position, transform.rotation);
		
	}
}
