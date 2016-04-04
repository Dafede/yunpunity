using UnityEngine;
using System.Collections;

public class InteractableObjectWatcher : MonoBehaviour {

	public float interactionDistance = 1.25f;
	public Camera camera;
	public GameObject doorIcon;

	private GameObject lastGameObjectInFocus = null;

	void Update () {
		doorIcon.SetActive (false);
		// Will look for somethign in sight
		RaycastHit hit = new RaycastHit ();
		if (Physics.Raycast(camera.ScreenPointToRay(Input.mousePosition), out hit)) {
			if (hit.distance <= interactionDistance) {  // it's in a hand distance
				// take cara if the objects ar overlapping in the player pov
				// if (lastGameObjectInFocus.GetInstanceID () != hit.transform.gameObject.GetInstanceID ()) {}


				// Change Cursor to indicate some kind of action

				// set the material outline of the objecto to be see by the user
				Renderer hittedObjectRenderer = hit.transform.GetComponent<Renderer> ();
				if(hittedObjectRenderer != null) hittedObjectRenderer.material.SetFloat ("_DrawOutline", 1);

				// save the object as the last object in focus
				lastGameObjectInFocus = hit.transform.gameObject;

				if (lastGameObjectInFocus.tag == "Door") {
					doorIcon.SetActive (true);
				} 

				// if the user clicks, do the action
				if (Input.GetMouseButtonDown (0)) {
					InteractableObject io = hit.transform.GetComponent<InteractableObject> ();
					switch (io.interactableType) {
					case InteractableObject.InteractableType.Grab:
						io.DoGrab ();
						break;
					case InteractableObject.InteractableType.Push:
						io.DoPush ();
						break;
					case InteractableObject.InteractableType.See:
						io.DoSee ();
						break;
					}
				}
			} else {
				// nothing hitted
				// eliminate outline of the last game object in focus
				if (lastGameObjectInFocus != null){
					Renderer lastGameObjectInFocusRenderer = lastGameObjectInFocus.GetComponent<Renderer>();
					if (lastGameObjectInFocusRenderer != null)
						lastGameObjectInFocusRenderer.material.SetFloat("_DrawOutline", 0);	
				}
			}
		}
	}
}
