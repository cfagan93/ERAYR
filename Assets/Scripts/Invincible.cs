using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Invincible : MonoBehaviour 
{
	public GameObject PowerUp;
	
	void OnTriggerEnter(Collider col)
	{
		if(col.gameObject.tag == "Player")
		{
			PowerUp.SetActive(true);
			Destroy(this.gameObject);
            col.gameObject.GetComponent<Health>().SetInvincible();
		}
	}
}
