using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;

// An abstraction of what a building does
public abstract class AbstractBuilding : MonoBehaviour {

	public void Start() {
		UpdateCostText ();
	}

	// Textbox displaying the cost
	public Text costText;

	// boolean value indicating whether building is occupied
	private bool occupied = false;

	// The player that owns the building
	private PlayerManager owner = null;

	// Relative coordinates where the player exits the building
	public float exitX = 0f;
	public float exitY = -.4f;

	public Vector2 getExitPosition () {
		Vector2 exitPosition = new Vector2( exitX, exitY ) ;
		return transform.TransformPoint(exitPosition);
	}

	public void SetOwner(PlayerManager p) {
		owner = p;
	}

	// The cost of using the building
	public Good[] cost;

	// The goods given to the owner when the building is used
	public Good[] bonus;

	// attempts to pay the costs associated with this building. Returns true if it succeeds.
	public bool PayCost (PlayerInventory inventory) {
		return inventory.Pay (cost);
	}

	// Uses the action associated with the building
	public void Action (PlayerManager manager) {
		// If the player can pay the cost associated with the building, trigger the building's
		// effect. The owner then receives the bonus.
		if (PayCost (manager.GetInventory ())) {
			Effect (manager);
			if (owner != null)
				owner.GetInventory ().Receive (bonus);
			IncrementCost ();
		}
			
	}

	public abstract string GetName ();

	// Effect associated with pressing right or left while inside the building
	public virtual void Right(PlayerManager manager) {}
	public virtual void Left(PlayerManager manager) {}

	// What happens when you use the building's effect
	protected abstract void Effect(PlayerManager manager);

	public void SetOccupied(bool status) {
		occupied = status;
	}

	public bool IsOccupied() {
		return occupied;
	}

	private void UpdateCostText() {
		costText.text = "";
		foreach (Good g in cost)
			costText.text += g.type + ": " + g.quantity + "\n";
	}

	// Each time the building is used, the cost of using it increases slightly
	private void IncrementCost() {
		foreach (Good g in cost)
			g.quantity++;
		UpdateCostText ();
	}
}

// Subinterfaces so the goblins know what to attack
public abstract class DestructibleBuilding : AbstractBuilding {}
public abstract class IndestructibleBuilding : AbstractBuilding {}