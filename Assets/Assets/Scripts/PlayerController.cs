using UnityEngine;
using System.Collections;


// Script on the player that handles controls
public class PlayerController : MonoBehaviour {
	
	public int p = 1;

	private BuildingManager insideBuilding;
	private BuildingManager nearbyBuilding;

	private GameObject avatar;
	//private string HORIZONTAL = "Horizontal_P" + PlayerNumber;

	public float speed = 5f;
	// Use this for initialization
	void Start () {
		// set the avatar
		foreach (Transform child in transform)
			if (child.CompareTag ("Avatar")) {
				avatar = child;
				break;
			}
	}
	
	// Update is called once per frame
	void Update () {

		// if outside of building, use outside controls
		if (insideBuilding == null) {
			
			// change velocity based on joystick
			avatar.transform.GetComponent<Rigidbody2D> ().velocity = InputManager.Joystick (p) * speed;

			// if there is a building nearby, enter it when action button is pressed
			if (InputManager.AButton (p) && nearbyBuilding != null)
				nearbyBuilding.Enter (this.gameObject);
		} else {
			// if inside a building, (todo: add other behavior) can use building action or exit
			if (InputManager.AButton (p))
				insideBuilding.Action (this.gameObject);

			if (InputManager.BButton (p))
				insideBuilding.Exit (this.gameObject);
		}
	}

	public void setInsideBuilding(BuildingManager b) {
		insideBuilding = b;
	}

	// handle entering a building
	void OnTriggerEnter2D(Collider2D other) {
		print ("entered");
		if (other.GetComponent<BuildingManager> () != null)
			nearbyBuilding = other.GetComponent<BuildingManager>();
	}

	// handle exiting a building
	void OnTriggerExit2D(Collider2D other) {
		if (other.GetComponent<BuildingManager> () != null)
			nearbyBuilding = null;
	}
}
