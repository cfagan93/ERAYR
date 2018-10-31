


using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMovement : MonoBehaviour
{
	public float speed;
	public Transform target;
	NavMeshAgent agent;

	public bool SeesPlayer = false;

	public float offset;
	public int damage;
	private Vector3 pos;

	private float velocity;
	public Animator anim;

	public float length;
	public LayerMask layer;

	public bool ready = true;
	public Collider hitCol;

	private GameObject player;
	public bool death;

	public GameObject hitParticle;

	void Start ()
	{
		agent = GetComponent<NavMeshAgent> ();
		//target = player.transform;
	}

	void Update ()
	{
		//if (SeesPlayer == true) {
		//Debug.Log ("fuck this shit");
		if (!death) {
			velocity = Mathf.Abs (agent.velocity.x);
			Ray f = new Ray (transform.position, transform.forward);

			//if(target != null) {

			if (target.position.x > transform.position.x) {
				pos = new Vector3 (target.position.x - offset, target.position.y, target.position.z);
			} else if (target.position.x < transform.position.x) {
				pos = new Vector3 (target.position.x + offset, target.position.y, target.position.z);
			}

			if (anim.GetCurrentAnimatorStateInfo (0).IsName ("Idle Run Blend")) {
				agent.SetDestination (pos);
			}

			transform.LookAt (new Vector3 (target.position.x + offset, transform.position.y, target.position.z));
			
			//}

			anim.SetFloat ("Speed", velocity);
			Checking (f);
		}
	}


	void Checking (Ray f)
	{
		if (Physics.Raycast (f, length, layer)) {
			if (ready) {
				anim.SetTrigger ("Box");
				ready = false;
			}
		}
	}

	public void TurnOnHitCollider ()
	{
		hitCol.enabled = true;
	}

	public void TurnOffHitCollider ()
	{
		hitCol.enabled = false;
	}

	public void Destroy ()
	{
		Destroy (this.gameObject, 2);
		GetComponent<Rigidbody> ().isKinematic = true;
		GetComponent<BoxCollider> ().enabled = false;
	}

	void Damage ()
	{
		target.GetComponent<Health> ().Damage (damage);
	}

	void OnTriggerEnter (Collider other)
	{
		if (other.tag == "Player") {
			Damage ();
			Instantiate (hitParticle, hitCol.transform.position, Quaternion.identity);
		}
	}

}
