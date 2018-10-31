using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour {

	Rigidbody body;

	// Use this for initialization
	void Start () {

		body = GetComponent<Rigidbody> ();

	}
	
	// Update is called once per frame
	void Update () {

		Vector3 velocity = new Vector3 ();

		float yVelocity = body.velocity.y;

		if (Input.GetKey (KeyCode.LeftArrow)) {

			velocity.x = -5;

		}

		if (Input.GetKey (KeyCode.RightArrow)) {

			velocity.x = 5;

		}

		velocity.y = yVelocity;

		body.velocity = velocity;
	}

	void OnTriggerEnter(Collider other) {

		if (other.gameObject.tag == "ShootingTrap") {

			other.gameObject.GetComponent<ShootingTrapScript> ().Shoot (gameObject);

		}
	}
}
