using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoblinInvasionEvent : AbstractEvent {

	public GameObject GoblinPrefab;

	public override void Initialize () {
		// 1. Create goblin invasion force on a random side of the map

		Vector2 position = new Vector2 (0f, 0f);

		GameObject goblinForce = (GameObject) Instantiate(GoblinPrefab);
	}
}
