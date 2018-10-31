
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestructableObject : MonoBehaviour {

	public GameObject ObjectPiecePrefab;

	public void DestroyObject(){

		for (int i = 0 ; i < 4 ; i++){

			GameObject piece = GameObject.Instantiate(ObjectPiecePrefab,transform.position,transform.rotation);

			piece.GetComponent<Rigidbody>().AddForce(Random.Range(-100,100),Random.Range(-100,100),Random.Range(-100,100));

		}

		Destroy(gameObject);

	}

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
