using UnityEngine;
using System.Collections;
using System;

public class BuildingAction : MonoBehaviour {

	// dictionary indicating what resources are traded at this building
	public string[] tradeGoods;
	public int[] tradeValues;
	// int indicating cost of using building
	public int cost = 1;
	// float indicating cooldown time of building
	public float cooldown = 10f;

	public void OnAction (PlayerInventory p) {
		p.Trade (tradeGoods, tradeValues);
	}
}
