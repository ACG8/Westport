﻿using UnityEngine;
using System.Collections;

public static class InputManager {

	public static bool gameStarted = false;

	public static float HAxis(int i) {
		float val = 0f;
		val += Input.GetAxis ("JH" + i);
		if (i > 2) {
			val += Input.GetAxis ("KH" + i);
			val = Mathf.Clamp (val, -1f, 1f);
		}
		return val;
	}

	public static float VAxis(int i) {
		float val = 0f;
		val += Input.GetAxis ("JV" + i);
		if (i > 2) {
			val += Input.GetAxis ("KV" + i);
			val = Mathf.Clamp (val, -1f, 1f);
		}
		return val;
	}

	public static Vector2 Joystick(int i) {
		return new Vector2 (HAxis (i), VAxis (i));
	}

	public static bool AButton(int i) {
		return Input.GetButtonDown ("A" + i);
	}

	public static bool BButton(int i) {
		return Input.GetButtonDown ("B" + i);
	}

	public static bool StartButton(int i) {
		return Input.GetButtonDown ("Start" + i);
	}

}
