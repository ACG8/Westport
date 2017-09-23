using UnityEngine;
using System.Collections;
using UnityEngine.UI;


// manages everything for a single player
public class PlayerManager : MonoBehaviour {

	private bool playing = false;

	// Player's number
	public int playerNumber;

	// The box in which the player joins the game
	public GameObject joinBox;

	// The object representing the player in the game
	public GameObject avatar;

	// Use this for initialization
	void Start () {
//		// set the avatar
//		foreach (Transform child in transform)
//			if (child.CompareTag ("Avatar")) {
//				avatar = child.GetComponent<GameObject> ();
//				break;
//			}
	}


	// Updates selection box checks and returns boolean indicating whether game should start
	public bool SelectionCheck() {

		// On action
		if (!playing && InputManager.AButton (playerNumber)) {
			Text textComponent = joinBox.GetComponentInChildren<Text> ();
			textComponent.text = "Press <Start> to begin";
			playing = true;
		}

		if (playing) {
			// On cancel
			if (InputManager.BButton (playerNumber)) {
				Text textComponent = joinBox.GetComponentInChildren<Text> ();
				textComponent.text = "Press <A> to join";
				playing = false;
			}

			// On start
			if (InputManager.StartButton (playerNumber))
				return true;
		}

		return false;

	}

	// called to start the game
	public void StartGame() {
		if (playing) {
			
		} else {
			Destroy (this);
		}
	}

	// Update is called once per frame
	void Update () {

	}
}
