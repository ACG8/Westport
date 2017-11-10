using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Governs the behavior of the invasion force
public class GoblinInvasionForceAI {

	private GoblinInvasionForce avatar;

	public void SetAvatar(GoblinInvasionForce f) {
		avatar = f;
	}

	public GameObject FindNearestBuilding() {
		DestructibleBuilding[] scripts = GameObject.FindObjectsOfType<DestructibleBuilding> ();
		GameObject[] buildings = new GameObject[scripts.Length];

		for (int i = 0; i < scripts.Length; i++) {
			buildings [i] = scripts [i].gameObject;
		}

		// Initialize distance and closest building
		float distance = Mathf.Infinity;
		GameObject nearest = null;

		// Iterate over all buildings to find the closest one
		foreach (GameObject b in buildings) {
			Vector3 diff = b.transform.position - avatar.transform.position;
			float currentDistance = diff.sqrMagnitude;
			if (currentDistance < distance) {
				nearest = b;
				distance = currentDistance;
			}
		}

		// May return null
		return nearest;
	}

	// Sets velocity
	public void MoveTowardsObject(GameObject g) {
		// Get the direction
		Vector2 diff = g.transform.position - avatar.transform.position;
		diff.Normalize();

		// Set the velocity
		avatar.GetComponent<Rigidbody2D> ().velocity = diff * avatar.speed;
	}

	// Update for moving towards nearest building
	public void UpdateVelocity() {
		GameObject target = FindNearestBuilding ();
		if (target != null) {
			MoveTowardsObject (target);
		} else {
			// Stop moving
			avatar.GetComponent<Rigidbody2D> ().velocity = Vector2.zero;
		}
	}
}
