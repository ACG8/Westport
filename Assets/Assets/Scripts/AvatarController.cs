using UnityEngine;
using System.Collections;


// Script on the avatar that handles movement and updates
public class AvatarController : MonoBehaviour {

	private int p;

	private BuildingManager nearbyBuilding;

	public float speed = 5f;

	public void SetPlayerNumber(int n) {
		p = n;
	}

	// moves the avatar
	public void moveAvatar() {
		transform.GetComponent<Rigidbody2D> ().velocity = InputManager.Joystick (p) * speed;
	}

	// returns the building nearby
	public BuildingManager GetNearbyBuilding() {
		return nearbyBuilding;
	}

	// detect nearby buildings
	void OnTriggerEnter2D(Collider2D other) {
		if (other.GetComponent<BuildingManager> () != null)
			nearbyBuilding = other.GetComponent<BuildingManager>();
	}

	// unassign nearby buildings
	void OnTriggerExit2D(Collider2D other) {
		if (other.GetComponent<BuildingManager> () != null)
			nearbyBuilding = null;
	}
		
}
