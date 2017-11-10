using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fortress : IndestructibleBuilding {

	public override string GetName() {
		return string.Format("Fortress");
	}

	protected override void Effect(PlayerManager p) {

	}
}
