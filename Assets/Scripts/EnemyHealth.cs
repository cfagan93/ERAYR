




using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour 
{
	public float health;
	public float damage;

	public Animator anim;
	public EnemyMovement main;

	void Death()
	{
		anim.SetTrigger ("Die");
		main.death = true;
	}

	public void TakeDamage()
	{
		if (health > 0) {
			health -= damage;

			if (health <= 0) {
				Death ();
			}
		}
	}
}
