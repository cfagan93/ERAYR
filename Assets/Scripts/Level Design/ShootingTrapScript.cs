using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingTrapScript : MonoBehaviour {

	public GameObject spikePrefab;
	public bool loaded = true; 
	private AudioSource audioSource;

	// Use this for initialization
	void Start () {
		audioSource = GetComponent <AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {
		// audioSource.Play ()
	}

	void Reload () { 
		loaded = true; 



	}


	public void Shoot(GameObject target) {
		if (loaded) {
			loaded = false; 

			Invoke ("Reload", 1.0f); 

			GameObject spike = GameObject.Instantiate (spikePrefab, transform.position, transform.rotation);

			Vector3 direction = target.transform.position - spike.transform.position;

			Quaternion toRotation = Quaternion.FromToRotation (spike.transform.up, direction);

			spike.transform.rotation = toRotation;

			spike.GetComponent<Rigidbody> ().velocity = direction * 5;
			audioSource.Play ();

		} 
	}

}
