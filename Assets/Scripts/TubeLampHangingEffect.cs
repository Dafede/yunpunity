using UnityEngine;
using System.Collections;

public class TubeLampHangingEffect : MonoBehaviour {

	public GameObject tubeLamp;
	Collider tubeCollider;

	// Use this for initialization
	void Start () {
		tubeCollider=tubeLamp.GetComponent<Collider>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter(Collider other) {
		if (other.tag=="Player")
			tubeCollider.attachedRigidbody.useGravity = true;

	}
}
