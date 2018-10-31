using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyAfterTime : MonoBehaviour {

	public float LifeSpan;


	// Use this for initialization
	void Start () {
		Invoke ("SelfDestruct",LifeSpan);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void SelfDestruct(){

		Destroy(gameObject);

	}
}


