using UnityEngine;
using System.Collections;
using System;

public class BuildingAction : MonoBehaviour {

	// dictionary indicating what resources are traded at this building
	public string[] tradeGoods;
	public int[] tradeValues;
	// boolean indicating whether the maximum possible trade should be used
	public bool maxtrade = false;
	// int indicating cost of using building
	public int cost = 1;
	// float indicating cooldown time of building
	public float cooldown = 10f;

	public void OnAction (PlayerInventory p) {
		if (maxtrade) p.MaxTrade (tradeGoods, (int[]) tradeValues.Clone());
		else p.Trade (tradeGoods, tradeValues);
	}
}
