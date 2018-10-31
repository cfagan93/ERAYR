


using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Movement : MonoBehaviour
{

	Rigidbody rb;
	public float horizontalSpeed;
	public float animationHorizontalSpeed;
	public float VerticalSpeed;
	private bool secondJump = false;
	private bool firstJump = false;
	public float jumpPower;
	public float jumpPower2;
	public bool Ground;
	public Animator anim;
	public int Jump1;
	public float yRotation;
	public bool ready = true;
	public Collider hitCol;
	public Collider kickCol;
	public GameObject PauseMenu;
	public bool IsPaused;
	public bool dead;
	private Health health;
	private int levelNo;
	public GameObject hitParticle;
	public AudioSource audioSource;


	public bool attack;

	// Use this for initializationleve
	void Start ()
	{
		rb = GetComponent<Rigidbody> ();
		anim = GetComponent<Animator> ();

		health = GetComponent<Health> ();

		SceneManager.sceneLoaded += LoadedLevel;
		audioSource = GetComponent <AudioSource>();
	}

	void LoadedLevel (Scene scene, LoadSceneMode mode)
	{
		Scene level = SceneManager.GetActiveScene ();
		levelNo = level.buildIndex;
	}

	// Update is called once per frame
	void Update ()
	{

		if (Input.GetKey (KeyCode.Escape)) {

			if (IsPaused == false) {

				PauseMenu.SetActive (true);
				IsPaused = true;
				Time.timeScale = 0f;
			} else {

				PauseMenu.SetActive (false);
				IsPaused = false;
				Time.timeScale = 1f;
			}


		}


		if (ready) {
			if (Input.GetKeyDown (KeyCode.B)) {
				audioSource.Play (); 
				anim.SetTrigger ("Box");
				attack = true;
				ready = false;
			} else {

				attack = false;

			}

			if (Input.GetKeyDown (KeyCode.K)) {
				audioSource.Play (); 
				anim.SetTrigger ("Kicking");
				attack = true;
				ready = false;
			} else {

				attack = false;

			}
		}

		if (Input.GetKey (KeyCode.X)) {

			anim.SetTrigger ("Roll");
			// else {
			//	anim.SetBool ("Roll", false);
		}



		if (Input.GetKey (KeyCode.C)) {

			anim.SetBool ("Crouching", true);

		} else {

			anim.SetBool ("Crouching", false);
		
		}

		if (!anim.GetCurrentAnimatorStateInfo (0).IsName ("Box") && !anim.GetCurrentAnimatorStateInfo (0).IsName ("Kicking 2") && !dead && !attack) {
			if (Ground) {
				if (secondJump != true) {
					if (Input.GetKeyDown (KeyCode.Space) && !firstJump) {

						firstJump = true;
						rb.AddForce (0, jumpPower, 0);
						Jump1++;
						//animationHorizontalSpeed = 0;
						//anim.SetFloat ("VerticalSpeed", 1);


						anim.SetTrigger ("Jump");
					} else {

						if (Input.GetKeyDown (KeyCode.Space) && firstJump) {

							secondJump = true;

							if (secondJump) {
								rb.AddForce (0, jumpPower2, 0);
								anim.SetTrigger ("Double Jump");
							}

						}
					}

				}

			}

			if (secondJump) {

				Ground = false;

			}

			if (Input.GetKey (KeyCode.A)) {
				
				rb.velocity = new Vector3 (horizontalSpeed * -5, rb.velocity.y, 0);

				horizontalSpeed = Mathf.Lerp (horizontalSpeed, 2, 0.1f);
				animationHorizontalSpeed = Mathf.Lerp (animationHorizontalSpeed, 1, 0.1f);

				yRotation = -90;

			}
			if (Input.GetKey (KeyCode.D)) {
				
				rb.velocity = new Vector3 (horizontalSpeed * 5, rb.velocity.y, 0);

				horizontalSpeed = Mathf.Lerp (horizontalSpeed, 2, 0.1f);
				animationHorizontalSpeed = Mathf.Lerp (animationHorizontalSpeed, 1, 0.1f);

				yRotation = 90;
			}

			if (!Input.GetKey (KeyCode.A) && !Input.GetKey (KeyCode.D)) {

				horizontalSpeed = Mathf.Lerp (horizontalSpeed, 0, 0.1f);
				animationHorizontalSpeed = Mathf.Lerp (animationHorizontalSpeed, 0, 0.1f);

			}
		}

		anim.SetFloat ("Speed", animationHorizontalSpeed);

		Quaternion rot = transform.rotation;
		Vector3 eulerRot = rot.eulerAngles;
		eulerRot.y = yRotation;
		rot.eulerAngles = eulerRot;
		transform.rotation = rot;
	}


	void OnCollisionEnter (Collision col)
	{
		if (col.gameObject.tag == "Ground") {
			firstJump = false;
			Ground = true;
			secondJump = false;
			anim.SetFloat ("VerticalSpeed", 0);
		}	
	
	}

	public void TurnOnHitCollider ()
	{
		if (anim.GetCurrentAnimatorStateInfo (0).IsName ("Box")) {
			hitCol.enabled = true;
		} else if (anim.GetCurrentAnimatorStateInfo (0).IsName ("Kicking 2")) {
			kickCol.enabled = true;
		}
	}

	public void TurnOffHitCollider ()
	{
		hitCol.enabled = false;
		kickCol.enabled = false;
	}

	public void Reload ()
	{
		dead = false;
		SceneManager.LoadScene (levelNo);
	}

	public void JumpFinished ()
	{

		//if (Ground) {

		//Debug.Log ("Stopping jump!");

		//anim.SetFloat ("VerticalSpeed", 0);

	}

	void OnTriggerStay (Collider other)
	{

		if (other.gameObject.tag == "ShootingTrap") {

			other.gameObject.GetComponent<ShootingTrapScript> ().Shoot (gameObject);
			Debug.Log ("Trying to shoot: " + gameObject.name);

		}

	}


	void OnTriggerEnter (Collider other)
	{
		

		if (other.tag == "Enemy") {
			other.GetComponent<EnemyHealth> ().TakeDamage ();

			if (hitCol.enabled) {
				Instantiate (hitParticle, hitCol.transform.position, Quaternion.identity);
			} else if (kickCol.enabled) {
				Instantiate (hitParticle, kickCol.transform.position, Quaternion.identity);
			}
		}
		if (other.tag == "DestructableObject") {
			other.GetComponent<DestructableObject> ().DestroyObject ();

			if (hitCol.enabled) {
				Instantiate (hitParticle, hitCol.transform.position, Quaternion.identity);
			} else if (kickCol.enabled) {
				Instantiate (hitParticle, kickCol.transform.position, Quaternion.identity);
			}
		}
		
	}



}

