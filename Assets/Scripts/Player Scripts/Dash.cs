using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class Dash : MonoBehaviour { 

	Rigidbody body;

	public float speed = 1f;

	// Use this for initialization
	void Start () {
		
		body = GetComponent<Rigidbody> ();

	}

	// Update is called once per frame
	void Update () {

		if (Input.GetKey (KeyCode.Z)) {

			//transform.position += new Vector3 (speed * Time.deltaTime, 0.1f, 0.0f);
			body.velocity = new Vector3(speed , body.velocity.y, 0);

		} else {
			
			float velocityX = body.velocity.x;

			Vector3 targetVelocity = new Vector3 (0, body.velocity.y, 0);

			body.velocity = Vector3.Lerp (body.velocity, targetVelocity, 0.05f);

		}

	}

}