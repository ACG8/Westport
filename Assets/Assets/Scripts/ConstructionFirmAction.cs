using UnityEngine;
using System.Collections;

public class ConstructionFirmAction : BuildingAction {

	//public GameObject[] buildingList;
	//private int buildingIndex = 0;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	new void OnAction(PlayerInventory p) {
		base.OnAction (p);

	}

}
