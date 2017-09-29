using UnityEngine;
using System.Collections;
using UnityEngine.UI;


// manages everything for a single player
public class PlayerManager : MonoBehaviour {

	// tracking the player's state with respect to buildings
	private BuildingManager insideBuilding;

	// various aspects of the player
	private AvatarController controller;
	private PlayerInventory inventory;
	private GameObject avatar;

	// Player's number
	public int p;

	// Use this for initialization
	void Start () {
		controller = GetComponentInChildren<AvatarController> ();
		inventory = GetComponent<PlayerInventory> ();
		avatar = gameObject.transform.GetChild (0).gameObject;

		// set player number of avatar controller
		controller.SetPlayerNumber(p);
	}

	public PlayerInventory GetInventory() {
		return inventory;
	}
		
	// Update is called once per frame
	void Update () {

		if (controller == null)
			return;

		// if outside of building, use outside controls
		if (insideBuilding == null) {
			controller.moveAvatar ();

			// Pressing A enters a nearby building, if one exists
			if (InputManager.AButton (p)) {
				BuildingManager nearbyBuilding = controller.GetNearbyBuilding ();
				// If there is a building and it is unoccupied, enter it
				if (!(nearbyBuilding == null || nearbyBuilding.IsOccupied())) {
					avatar.SetActive (false);
					insideBuilding = nearbyBuilding;
					insideBuilding.SetOccupied (true);
				}
			}

		// if inside a building, can use building action or exit
		} else {
			// Pressing A calls the action of the building the player occupies
			if (InputManager.AButton (p))
				insideBuilding.GetComponent<BuildingManager> ().Action (this);

			// Pressing B exits the building
			if (InputManager.BButton (p)) {
				avatar.SetActive (true);
				insideBuilding.SetOccupied (false);
				insideBuilding = null;
			}
		}
	}
}
