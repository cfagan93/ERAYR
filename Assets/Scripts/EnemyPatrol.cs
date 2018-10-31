using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyPatrol : MonoBehaviour
{
	public float speed;

	//public Animator anim;

	NavMeshAgent agent;

	public int currentNavPoint = 0;

	public List<GameObject> navPoints;

	// Use this for initialization
	void Awake ()
	{
		//anim = GetComponent<Animator> ();
		agent = GetComponent<NavMeshAgent> ();

//		agent.SetDestination (navPoints [currentNavPoint].transform.position);

	}
	
	// Update is called once per frame
	void Update ()
	{

		if (agent.remainingDistance < 0.5f) {

			if (currentNavPoint < navPoints.Count - 1) {

				currentNavPoint++;

			} else {

				currentNavPoint = 0;

			}

			agent.SetDestination (navPoints [currentNavPoint].transform.position);

		}

	}
}
