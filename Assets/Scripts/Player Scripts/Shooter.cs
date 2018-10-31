using UnityEngine;
using System.Collections;

public class Shooter : MonoBehaviour {

	public float bulletSpeed = 10f;

	public GameObject bulletPrefab;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(KeyCode.Space)) {
			GameObject bullet = GameObject.Instantiate<GameObject>(bulletPrefab);
			Rigidbody2D bulletRb = bullet.GetComponent<Rigidbody2D>();

			bullet.transform.position = new Vector2(transform.position.x, transform.position.y);

			bulletRb.velocity = Vector2.right * bulletSpeed; 
		}
	}
}
