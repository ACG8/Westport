using UnityEngine;
using System.Collections;
using UnityEngine.UI;


// manages everything for a single player
public class PlayerManager : MonoBehaviour {

	private bool playing = false;

	// Player's number
	public int playerNumber;

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
		
	// Update is called once per frame
	void Update () {

	}
}
