﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class destroy : MonoBehaviour {

	// Use this for initialization
	void Start(){
		
	}

	void OnCollisionEnter(Collision col){ 

		Destroy (gameObject);

}

}