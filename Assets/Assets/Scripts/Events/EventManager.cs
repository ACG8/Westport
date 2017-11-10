using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventManager : MonoBehaviour {

	public AbstractEvent[] events;

	// times per minute that event occurs
	public int frequency;

	// Timer to control how often event occurs
	private float timerMax;
	private float timeRemaining;

	void Start() {
		timerMax = 60f / frequency;
		timeRemaining = timerMax;
	}
	
	// Update is called once per frame
	void Update () {

		// handle timer
		timeRemaining -= Time.deltaTime;

		if (timeRemaining <= 0f) {
			timeRemaining = timerMax;

			AbstractEvent e = events [Random.Range (0, events.Length)];
			e.Initialize ();
		}
	}
}
