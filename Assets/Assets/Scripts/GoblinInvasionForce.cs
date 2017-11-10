using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// A band of invading goblins that destroys the nearest building
public class GoblinInvasionForce : MonoBehaviour {

	public float speed = 4;
	private GoblinInvasionForceAI ai = new GoblinInvasionForceAI();

	// Use this for initialization
	void Start () {
		ai.SetAvatar (this);
	}
	
	// Update is called once per frame
	void Update () {
		ai.UpdateVelocity ();
	}

	// Destroy buildings on contact
	void OnCollisionEnter2D(Collision2D collision) {
		print ("Test");
		GameObject other = collision.collider.gameObject;

		if (other.tag == "Building") {
			// TODO: Give some amount of time before building is destroyed.
			Destroy(other);
		}
	}
}
