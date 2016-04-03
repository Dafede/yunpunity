using UnityEngine;
using System.Collections;

public class InteractableSphere : InteractableObject {
	
	public override void DoGrab() {
		Debug.Log ("GRAB!");
	}

	public override void DoSee() {
		Debug.Log ("SEE!");
	}

	public override void DoPush() {
		Debug.Log ("PUSH!");
	}
}
