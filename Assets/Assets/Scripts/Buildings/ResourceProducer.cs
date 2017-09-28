using UnityEngine;
using System.Collections;
using UnityEngine.UI;

// A building that produces a single resource (like a fishery)
public class ResourceProducer : BuildingManager {

	public Text offerText;

	// times per minute that resource is generated
	public int frequency;

	// the type and bulk price of good sold by this building
	public string goodType;
	public int bulkPrice;

	// The current amount of the good offered
	private int offer = 0;

	// Timer to control how often food stocks are incremented.
	private float timerMax;
	private float timeRemaining;

	void Start () {
		timerMax = 60f / frequency;
		timeRemaining = timerMax;
	}

	// Player's action retrieves the stored resource in exchange for coin
	public override void Action(PlayerManager p) {
		if (offer > 0) {
			PlayerInventory inventory = p.GetInventory ();
			string[] goods = { "Coin", goodType };
			int[] amounts = { -bulkPrice, offer };
			inventory.Trade (goods, amounts);
			offer = 0;
			UpdateDisplay ();
		}
				
	}
	
	// The building periodically increases the amount of goods that it has on offer
	void Update () {
		// handle timer
		timeRemaining -= Time.deltaTime;
		if (timeRemaining <= 0f) {
			offer++;
			UpdateDisplay ();
			timeRemaining += timerMax;
		}
	}

	// Updates the graphical display indicating the current number of resources on offer
	void UpdateDisplay () {
		offerText.text = offer.ToString();
	}

}
