using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;

public class PlayerInventory : MonoBehaviour {

	public GameObject inventoryPanel;
	private Dictionary<string,int> inventory = new Dictionary<string,int>();

	// Players start with 10 coins
	void Start() {
		Adjust ("Coin", 10);
		UpdatePanel ();

	}

	// Updates the text in the inventory panel
	void UpdatePanel() {
		// search inventory panel for icons
		foreach (Transform child in inventoryPanel.transform) {
			// update each icon's text with the new value
			string name = child.name;
			Text textComponent = child.Find ("Text").GetComponent<Text> ();
			int currentVal = Get (name);
			textComponent.text = currentVal.ToString ();

			//todo: grey out/recolor icons that have value of 0
		}
	}

	int Get(string key) {
		int value = 0;
		if (!inventory.TryGetValue (key, out value))
			inventory.Add (key, 0);
		return value;
	}

	void Adjust(string key, int delta) {
		int currentValue = Get (key);
		// Assert that we are not trying to pay more resources than exist
		Debug.Assert(delta + currentValue >= 0, "Attempted to call Adjust without sufficient resources");
		inventory[key] = currentValue + delta;
	}

	// Only succeeds if sufficient resources exist
	// Order of keys and deltas must match
	public void Trade(string[] costs, int[] deltas) {
		// assert that the two inputs are the same length
		Debug.Assert (costs.Length == deltas.Length, "Attempted to call trade with inputs of unequal length");

		int n = costs.Length;

		// first check if the transaction is legal. If not, return (and possibly make some noise)
		for (int i = 0; i < n; i++)
			if (deltas [i] < 0) {
				int currentAmt =  Get (costs [i]);
				int delta = deltas [i];
				if (currentAmt + delta < 0)
					return;
			}

		// second, iterate through the transaction and update all fields
		for (int i = 0; i < n; i++)
			Adjust (costs [i], deltas [i]);

		// update the panel to reflect the new resources. Note: This should be the ONLY way to change resource amounts.
		UpdatePanel ();
	}
}
