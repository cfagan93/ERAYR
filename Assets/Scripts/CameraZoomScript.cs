using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraZoomScript : MonoBehaviour {

	public float zoomIn;
	public float zoomOut;
	public float targetZoom;

	public float zoomSpeed;

	public Camera camera;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void FixedUpdate () {

		camera.orthographicSize = Mathf.Lerp(camera.orthographicSize, targetZoom, zoomSpeed);

	}


	void OnTriggerEnter (Collider col)
	{
		if (col.gameObject.tag == "ZoomInTrigger") {

			targetZoom = zoomIn;

		} else if (col.gameObject.tag == "ZoomOutTrigger") {

			targetZoom = zoomOut;

		}

	}

}
