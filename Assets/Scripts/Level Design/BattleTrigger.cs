


using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleTrigger : MonoBehaviour 
{
	public List<GameObject> spawners;
	public List<GameObject> enemies;

	public bool triggered;
	public Vector3 target;
	private Vector3 original;

	public float speed;
	private float time;
	private bool active;
	private bool spawned;

	void Awake()
	{
		original = transform.position;
	}

	void CheckEnemies()
	{
		for (int i = 0; i < enemies.Count; i++) {
			if (enemies [i] != null) {
				break;
			} else if (enemies [enemies.Count - 1] == null) {
				enemies.Clear ();
			}
		}
	}

	void Update()
	{
		if (triggered) 
		{
			MoveBarriers ();
		}

		if (transform.position != original) {
			if (spawned) {

				if (enemies.Count == 0) {
					triggered = true;
					active = false;
				}
			}
		}
	}

	void MoveBarriers()
	{
		if (time < 1) 
		{
			time += speed * Time.deltaTime;
		}
			
		if (active) {
			float y = Mathf.Lerp (original.y, target.y, time);
			transform.position = new Vector3 (transform.position.x, y, transform.position.z);
		} else if (!active) {
			float y = Mathf.Lerp (target.y, original.y, time);
			transform.position = new Vector3 (transform.position.x, y, transform.position.z);
		}

		if (time >= 1) {
			triggered = false;
			time = 0;

			if (active) {
				Invoke ("SpawnEnemies", 0.5f);
			}
		}
	}

	void SpawnEnemies()
	{
		for (int i = 0; i < spawners.Count; i++) {
			spawners [i].GetComponent<EnemySpawn> ().Spawn ();
			enemies.Add(spawners[i].GetComponent<EnemySpawn>().spawnedEnemy);
		}

		spawned = true;
		InvokeRepeating ("CheckEnemies", 0, 0.5f);
	}

	void OnTriggerEnter(Collider other)
	{
		if (other.tag == "Player") 
		{
			triggered = true;
			active = true;
			GetComponent<BoxCollider> ().enabled = false;
		}
	}
}
