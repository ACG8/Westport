using UnityEngine;
using System.Collections;

public abstract class BuildingManager : MonoBehaviour {

	// the player (if any) that owns this building
	protected PlayerManager owner;

	private bool occupied;

	public void SetOccupied(bool status) {
		occupied = status;
	}

	public bool IsOccupied() {
		return occupied;
	}

	public abstract void Action (PlayerManager p);

}
