using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyManger : MonoBehaviour
{
	public bool Key1;
	public bool Key2;

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

		if (col.gameObject.name == "Key1") {

			Key1 = true;
			Destroy (col.gameObject);

		}
		if (col.gameObject.name == "Key2") {

			Key2 = true;
			Destroy (col.gameObject);
	
		}
	}
}
