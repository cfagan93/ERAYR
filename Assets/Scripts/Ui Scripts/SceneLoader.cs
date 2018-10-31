using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class SceneLoader : MonoBehaviour
{

	public string sceneName;

	public void LoadScene ()
	{
		Time.timeScale = 1f;
		SceneManager.LoadScene (sceneName);
	}
}
