using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unpause : MonoBehaviour
{
	public GameObject pauseMenuCanvas;


	// Use this for initialization
	public void onclick ()
	{
		pauseMenuCanvas.SetActive (false);
		Time.timeScale = 1f;

	}
	
	// Update is called once per frame
	void Update ()
	{
		
	}
}
