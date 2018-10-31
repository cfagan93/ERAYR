


using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour 
{
	public GameObject enemy;
	public GameObject spawnedEnemy;
	private Vector3 pos;

	public GameObject player;

	public float offset;

	void Start()
	{
		pos = new Vector3 (transform.position.x + offset, transform.position.y, transform.position.z);
	}

	public void Spawn()
	{
		if (enemy != null) {
			spawnedEnemy = Instantiate (enemy, pos, Quaternion.identity);
			spawnedEnemy.GetComponent<EnemyMovement>().target = player.transform;
			gameObject.SetActive (false);
		} else {
			Debug.Log ("You forgot to put in enemy in spawner");
		}
	}

	void OnTriggerEnter(Collider other)
	{
		if (other.tag == "Player")
		{
			pos = new Vector3 (transform.position.x + offset, transform.position.y, transform.position.z);
			Spawn ();
		}
	}
}
