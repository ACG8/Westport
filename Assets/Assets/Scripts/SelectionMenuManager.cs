using UnityEngine;
using System.Collections;
using UnityEngine.UI;

// handles menu for selecting players. Should be included only on the canvas element for player selection.
public class SelectionMenuManager : MonoBehaviour {

	// inventory panels for once the game begins
	public GameObject inventoryPanels;

	// The player managers and join boxes
	public GameObject[] players = new GameObject[4];
	public GameObject[] joinBoxes = new GameObject[4];
	
	// Update is called once per frame
	void Update () {
		// iterate over the players and check whether each has joined
		for (int i=0; i < 4; i++)
			if (PlayerSelectionCheck(i)) {
				StartGame ();
				break;
			}
	}

	// handles selection logic for each player
	private bool PlayerSelectionCheck(int i) {
		// player and player number and join box text
		GameObject p = players [i];
		int n = i + 1;
		Text jbMessage = joinBoxes [i].GetComponentInChildren<Text> ();

		// non-active players are activated
		if (!p.activeSelf && InputManager.AButton (n)) {
			jbMessage.text = "Press <Start> to begin";
			p.SetActive (true);
		}

		// active players are deactivated
		if (p.activeSelf && InputManager.BButton (n)) {
			jbMessage.text = "Press <A> to join";
			p.SetActive (false);
		}

		// indicate that we should start the game
		if (p.activeSelf && InputManager.StartButton (n))
			return true;

		// indicate that we should not start the game
		return false;
	}


	void StartGame() {
		inventoryPanels.GetComponent<Canvas> ().enabled = true;
		InputManager.gameStarted = true;
		GetComponent<Canvas> ().enabled = false;
		Destroy (GetComponent<GameObject> ());
	}
}
