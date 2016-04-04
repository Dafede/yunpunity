using UnityEngine;
using System.Collections;

public class InteractableDoor : InteractableObject  {

//	public GameObject doorIcon;
	GameObject player;

	void Start(){
		player=GameObject.FindGameObjectWithTag ("Player");
	}

	void Update(){
//		doorIcon.transform.LookAt (player.transform.position);
	}

	public override void DoPush() {
		Animator animator = GetComponent<Animator> ();
			
		if (animator.GetBool ("open")) {
			animator.SetBool("open",false);
		} else {
			animator.SetBool("open",true);
		}
	}

}
