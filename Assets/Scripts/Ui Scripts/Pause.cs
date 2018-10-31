using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause : MonoBehaviour
{


	public GameObject pauseMenuCanvas;



	public void PauseButton ()
	{
		  
		pauseMenuCanvas.SetActive (true);
		Time.timeScale = 0f;

		


	}

}
