using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthUI : MonoBehaviour
{
	public Text healthText;
	public Text lifeText;
	public GameObject player;

	// Use this for initialization
	void Start ()
	{
		healthText.text = "Health: " + player.GetComponent<Health> ().playerHealth;
		lifeText.text = "Lives" + player.GetComponent<Health> ().lives;
	}
	
	// Update is called once per frame
	void Update ()
	{
		healthText.text = "Health: " + player.GetComponent<Health> ().playerHealth;
		lifeText.text = "Lives " + player.GetComponent<Health> ().lives;
	}
}
