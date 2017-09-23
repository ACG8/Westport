using UnityEngine;
using System.Collections;

public class BuildingManager : MonoBehaviour {

	// the player inside the building
	private GameObject occupant;

	// the relative coordinates at which the player exits the building
	public float exitX;
	public float exitY;

	// called when a player enters the building
	public void Enter(GameObject p) {
		if (occupant == null) {
			occupant = p;
			occupant.GetComponent<AvatarController> ().setInsideBuilding (this);
			foreach (Collider c in p.GetComponents<Collider>())
				c.enabled = false;
			occupant.GetComponent<Renderer> ().enabled = false;
		} else {
		}
	}

	// called when a player leaves the building
	public void Exit(GameObject p) {
		p.GetComponent<AvatarController> ().setInsideBuilding (null);
		occupant = null;
		p.GetComponent<Renderer> ().enabled = true;
		foreach (Collider c in p.GetComponents<Collider>())
			c.enabled = true;
		p.GetComponent<Transform>().localPosition.Set (exitX, exitY, 0);
	}

	public void Action(GameObject p) {
		GetComponent<BuildingAction> ().OnAction (p.GetComponent<PlayerInventory>());
	}
}
