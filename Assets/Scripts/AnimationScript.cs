using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationScript : MonoBehaviour
{
	public EnemyMovement main;
	public Movement playerMain;
	public bool player;

	public void CallReset ()
	{
		if (player)
			Invoke ("Ready", 0.1f);
		else
			Invoke ("Ready", 0.5f);
	}

	public void ResetLevel ()
	{
		playerMain.Reload ();
	}

	public void HitCheck ()
	{
		if (player) {
			playerMain.TurnOnHitCollider ();
		} else {
			main.TurnOnHitCollider ();
		}
	}

	public void EndCheck ()
	{
		if (player) {
			playerMain.TurnOffHitCollider ();
		} else {
			main.TurnOffHitCollider ();
		}
	}

	public void EnemyDeath ()
	{
		main.Destroy ();
	}

	void Ready ()
	{
		if (player) {
//			playerMain.attack = false;
			playerMain.ready = true;

		} else if (!player) {
			main.ready = true;
		}
	}
}
