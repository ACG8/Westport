using UnityEngine;
using System.Collections;
using UnityEngine.UI;


// manages everything for a single player
public class PlayerManager : MonoBehaviour {

	// tracking the building that the player is currently ready to place
	public GameObject buildingPlan;

	// required box size of safety for building to be built
	private float buildingCheckSize = 2f;

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

	void EnterBuilding(BuildingManager b) {
		avatar.SetActive (false);
		insideBuilding = b;
		insideBuilding.SetOccupied (true);
	}

	void ExitBuilding() {
		avatar.SetActive (true);
		avatar.transform.SetPositionAndRotation (insideBuilding.getExitPosition (), Quaternion.identity);
		insideBuilding.SetOccupied (false);
		insideBuilding = null;
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
					EnterBuilding (nearbyBuilding);
				} else if (buildingPlan != null) {
					// check if any buildings are nearby
					Collider2D[] nearbyBuildings = Physics2D.OverlapBoxAll(avatar.transform.position, new Vector2(buildingCheckSize,buildingCheckSize), 0f, LayerMask.NameToLayer("Buildings"));
					if (nearbyBuildings.Length == 0) {
						// If no building is nearby, place your planned building and get inside
						GameObject newBuilding = Instantiate (buildingPlan, avatar.transform.position, avatar.transform.rotation);
						EnterBuilding (newBuilding.GetComponent<BuildingManager> ());
					}

				}
			}

		// if inside a building, can use building action or exit
		} else {
			// Pressing A calls the action of the building the player occupies
			if (InputManager.AButton (p))
				insideBuilding.GetComponent<BuildingManager> ().Action (this);

			// Pressing B exits the building
			if (InputManager.BButton (p)) {
				ExitBuilding ();
			}
		}
	}
}
