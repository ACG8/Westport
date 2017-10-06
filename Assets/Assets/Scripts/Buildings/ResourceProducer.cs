using UnityEngine;
using System.Collections;
using UnityEngine.UI;

// A building that produces a single resource (like a fishery)
public class ResourceProducer : BuildingManager {

	// The building that supplies this one
	public ResourceProducer supplier;
	public Text offerText;

	// times per minute that resource is generated
	public int frequency;

	// costs of using the building. This stays fixed; the reward increases over time
	public string[] costTypes;
	public int[] costPrices;

	// reward for using the building. This increases over time
	public string rewardType;

//	// the type and bulk price of good sold by this building
//	public string goodType;
//	public int bulkPrice;

	// The current amount of the good offered
	private int offer = 0;
	// The amount of goods that this can supply to another building and the amount it gains when the player sells to it.
	private int supply = 0;
	public int supplyIncrement = 0;

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
			string[] goods = new string[costTypes.Length + 1];
			costTypes.CopyTo (goods, 0);
			goods [goods.Length - 1] = rewardType;
			int[] amounts = new int[costPrices.Length + 1];
			costPrices.CopyTo (amounts, 0);
			amounts [amounts.Length - 1] = offer;
			// If the trade is successful, reset the offer
			if (inventory.Trade (goods, amounts)) {
				offer = 0;
				supply += supplyIncrement;
				UpdateDisplay ();
			}
		}
				
	}
	
	// The building periodically increases the amount of goods that it has on offer
	void Update () {

		// handle timer
		timeRemaining -= Time.deltaTime;


		if (timeRemaining <= 0f) {
			if (supplier == null) { // buildings with null suppliers just increment their offer
				offer++;
				UpdateDisplay ();
				timeRemaining = timerMax;
			} else if (supplier.getSupply() > 0) { // buildings with non-null suppliers increment their offer only if they have supply remaining
				supplier.decrementSupply();
				offer++;
				UpdateDisplay ();
				timeRemaining = timerMax;
			}
		}


	}

	public int getSupply() {
		return supply;
	}

	public void decrementSupply() {
		supply--;
	}

	// Updates the graphical display indicating the current number of resources on offer
	void UpdateDisplay () {
		offerText.text = offer.ToString();
	}

}
