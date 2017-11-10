using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ConstructionFirm : IndestructibleBuilding {

	public Text currentBlueprintText;
	public GameObject[] buildings;

	private int index = 0;

	void Start() {
		UpdateOfferText ();
	}

	// Action selects and purchases a building
	protected override void Effect (PlayerManager p) {
		p.SetBlueprint (buildings [index]);
	}

	// Right and left scroll between the building options
	public override void Right(PlayerManager p) {
		index += index < buildings.Length - 1 ? 1 : 0;
		UpdateOfferText ();
	}

	public override void Left(PlayerManager p) {
		index -= index > 0 ? 1 : 0;
		UpdateOfferText ();
	}

	private void UpdateOfferText() {
		currentBlueprintText.text = buildings [index].GetComponent<AbstractBuilding> ().GetName();
	}

	public override string GetName() {
		return string.Format("Construction Firm");
	}

}
