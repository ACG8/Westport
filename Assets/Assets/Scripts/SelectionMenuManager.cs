using UnityEngine;
using System.Collections;

public class SelectionMenuManager : MonoBehaviour {

	// menu for selecting players
	public GameObject selectionMenu;

	// inventory panels for once the game begins
	public GameObject inventoryPanels;

	// The player managers
	public PlayerManager[] playerManagers = new PlayerManager[4];

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		// iterate over the players and check whether each has joined
		foreach (PlayerManager p in playerManagers)
			if (p.SelectionCheck ())
				StartGame ();
	}


	void StartGame() {
		foreach (PlayerManager p in playerManagers)
			p.StartGame ();
		Destroy (selectionMenu);
		inventoryPanels.GetComponent<Canvas> ().enabled = true;
		InputManager.gameStarted = true;
		Destroy (this);
	}
}
