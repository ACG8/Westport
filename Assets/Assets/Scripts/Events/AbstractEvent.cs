using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AbstractEvent : MonoBehaviour {

	// This is called when the event is initiated
	public abstract void Initialize ();

	// This is called when the event terminates
	public virtual void Terminate() {}

}
