using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
// Trader buildings trade one resource for another.
public class Trader : AbstractBuilding {

	public string buildingName;
	public Text offerText;
	public Good[] offer;

	// times per minute that resource is generated
	public int frequency;
	// Timer to control how often food stocks are incremented.
	private float timerMax;
	private float timeRemaining;

	new void Start() {
		base.Start ();
		timerMax = 60f / frequency;
		timeRemaining = timerMax;
		UpdateOfferText ();
	}
	// The building periodically increases the amount of goods that it has on offer
	void Update () {

		// handle timer
		timeRemaining -= Time.deltaTime;

		if (timeRemaining <= 0f) {
			foreach (Good g in offer)
				g.quantity++;
			UpdateOfferText ();
			timeRemaining = timerMax;
		}


	}

	public void UpdateOfferText() {
		offerText.text = "";
		foreach (Good g in offer) {
			offerText.text += g.type + ": " + g.quantity + "\n";
		}
	}

	// Each time the building is used, the offer resets to 0
	private void ResetOffer() {
		foreach (Good g in offer) {
			g.quantity = 0;
		}
		UpdateOfferText ();
	}

	protected override void Effect(PlayerManager p) {
		p.GetInventory ().Receive (offer);
		ResetOffer ();
	}

	public override string GetName ()
	{
		return string.Format (buildingName);
	}

}
