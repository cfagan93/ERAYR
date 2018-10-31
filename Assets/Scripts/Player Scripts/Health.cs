using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Health : MonoBehaviour
{
	Rigidbody rb;
	public float horizontalSpeed;
	public int playerHealth = 100;
	public int lives = 3;
	public int damage = 10;
	public bool invincible;
	public bool SpeedBoost;
	private Animator anim;
	private Movement main;
	public string sceneName;
	public Transform spawnPoint;
	public AudioSource audioSource;

	public bool hit;

	// Use this for initialization
	void Start ()
	{
		//print ("PLAYER HEALTH");

		main = GetComponent<Movement> ();
		anim = GetComponent<Animator> ();
	}

	void Death ()
	{
		anim.SetTrigger ("PlayerDie");
		//audioSource.Play (); 
		main.dead = true;
	}

	public void Update ()
	{

		if (hit) {

			Invoke ("HitCooldown", 2f);

		}

		if (lives <= 0) {
			Debug.Log ("Im dead pickle rick");
			SceneManager.LoadScene (sceneName);
		}

	}

	public void Damage (int damage)
	{
		hit = true;

		if (playerHealth > 0) {
			playerHealth -= damage;

			if (playerHealth <= 0) {
				Death ();
			}
		} else if (playerHealth <= 0) {
			playerHealth = 0;
		}
	}

	void OnCollisionEnter (Collision col)
	{

		if (col.gameObject.tag == "crate") {
			//print ("Okay");
			if (!invincible && !GetComponent<Movement> ().attack) {
				Damage (damage);
			}
		}
		{
			if (col.gameObject.tag == "Enemy")
				col.gameObject.GetComponent <Health> (); 
			Health health = col.gameObject.GetComponent<Health> ();
		}

		if (playerHealth <= 0) {
			Death ();
		}


	}


	public void SetInvincible ()
	{

		invincible = true;
		Invoke ("SetNormal", 10);

	}

	public void SetNormal ()
	{

		invincible = false;

	}

	public void CheckForLives ()
	{

		if (lives > 0) {

			lives--;
			playerHealth = 100;
			SetInvincible ();
			Vector3 deathPosition = transform.position;
			deathPosition.y += 5;
			transform.position = spawnPoint.transform.position;
			GetComponent<Animator> ().SetTrigger ("Jump");
			GetComponent<Movement> ().dead = false;

		} else {

			//END GAME!

		}

	}

	void HitCooldown ()
	{

		hit = false;

	}

}
