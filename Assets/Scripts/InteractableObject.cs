using UnityEngine;
using System.Collections;

public abstract class InteractableObject : MonoBehaviour {

	public enum InteractableType {
		Grab,
		See,
		Push
	}

	public InteractableType interactableType;

	public virtual void DoGrab() {}

	public virtual void DoSee() {}

	public virtual void DoPush() {}
}
	