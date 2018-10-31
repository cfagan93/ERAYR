using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Patrol : MonoBehaviour {
	public Vector3 position1;
	public Vector3 position2;
	Vector3 target;


	// Use this for initialization
	void Start () {
		target = position1;
	}
	
	// Update is called once per frame
	void Update () {

		if (Vector3.Distance (transform.position, position1) < 0.1f) {

			target = position2;
		}

		if (Vector3.Distance (transform.position, position2) < 0.25f) {
			target = position1;
		}
	}

	void Fixedupdate() {
		
		transform.position = Vector3.Lerp (transform.position, target,0.01f);
	}
}
