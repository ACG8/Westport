using UnityEngine;
using System.Collections;

public abstract class BuildingManager : MonoBehaviour {

	public float exitX = 0f;
	public float exitY = -.4f;

	// the player (if any) that owns this building
	protected PlayerManager owner;

	private bool occupied;

	public Vector2 getExitPosition () {
		Vector2 exitPosition = new Vector2( exitX, exitY ) ;
		return transform.TransformPoint(exitPosition);
	}

	public void SetOccupied(bool status) {
		occupied = status;
	}

	public bool IsOccupied() {
		return occupied;
	}

	public abstract void Action (PlayerManager p);

}
