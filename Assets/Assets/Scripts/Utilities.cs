using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Utilities {
	private static float gridSize = 2f;

	// Returns the coordinates of the item, snapped to a grid 
	public static Vector2 ToGrid(Vector2 position) {
		float newX = Mathf.Round (position.x / gridSize) * gridSize;
		float newY = Mathf.Round (position.y / gridSize) * gridSize;
		return new Vector2 (newX, newY);
	}

}
