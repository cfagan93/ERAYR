using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class EnemyPatrol1 : MonoBehaviour {

	public Transform pos1;
	public Transform pos2;

	private NavMeshAgent agent;


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
				
		}

	void OnTriggerEnter(Collider other)
	{

		if (other.tag == "1")
			agent.SetDestination (pos2.position);
	}



}


