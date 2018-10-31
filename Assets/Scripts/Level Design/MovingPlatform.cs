using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour 
{
	public float speed;
	public bool right;
    public bool left;
	void Update()
	{
		if(right == true)
		{
			transform.Translate(Vector2.right * speed * Time.deltaTime);
		}
		else if(right == false)
		{
			transform.Translate(Vector2.left * speed * Time.deltaTime);
		}
	}
	
	void OnTriggerEnter2D(Collider2D col)
	{
		if(col.gameObject.tag == "Trigger")
		{
			if(right == true)
			{
				right = false;
			}
			else if(left == true)
			{
				right = false;
			}
		}
	}
}
