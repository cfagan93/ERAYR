using UnityEngine;
using System.Collections;
using UnityEngine;
using UnityEngine. UI;

public class hurt: MonoBehaviour
{
	public int EnemyHealth = 30;
	public int damage = 10;

	void update ()
	{

		if (EnemyHealth < -0)
			Destroy (gameObject);
	}


	void OnCollisionEnter (Collision col)
	{
		if (col.gameObject.tag == "Player")
			col.gameObject.GetComponent <hurt> (); 
		hurt hurt = col.gameObject.GetComponent<hurt> ();
	}
}




