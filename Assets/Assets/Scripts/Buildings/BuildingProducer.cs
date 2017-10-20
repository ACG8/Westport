using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BuildingProducer : BuildingManager {

	public Text text;
	private int index;
	public GameObject[] buildings;

	// Use this for initialization
	void Start () {
		
	}

	// Action selects and purchases a building
	public override void Action (PlayerManager p) {
		p.SetBlueprint (buildings [index]);
	}

	// Right and left scroll between the building options
	public override void Right(PlayerManager p) {
		index += index < buildings.Length - 1 ? 1 : 0;
		text.text = buildings [index].GetComponent<BuildingManager> ().displayText;
	}
	public override void Left(PlayerManager p) {
		index -= index > 0 ? 1 : 0;
		text.text = buildings [index].GetComponent<BuildingManager> ().displayText;
	}
	// Update is called once per frame
	void Update () {
		
	}
}
