using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPatrolHealth : MonoBehaviour
{
	public float health;
	public int damage;
	public bool hit;



	//void Death ()
	//{
		
	//	main.death = true;
	//}

	void Update ()
	{

		if (hit) {

			Invoke ("HitCooldown", 0.5f);

		}

	}

	public void TakeDamage ()
	{
		if (health > 0) {
			health -= damage;

			if (health <= 0) {
				Destroy (this.gameObject);
			}
		}
	}

	void OnTriggerStay (Collider col)
	{

		if (col.gameObject.name == "Player") {

			if (col.gameObject.GetComponent<Movement> ().attack && !hit) {

				hit = true;
				TakeDamage ();


			} else if (!col.gameObject.GetComponent<Movement> ().attack && !col.gameObject.GetComponent<Health> ().hit) {

				col.gameObject.GetComponent<Health> ().Damage (damage);

			}
				
		}

	}

	void HitCooldown ()
	{

		hit = false;

	}
}
