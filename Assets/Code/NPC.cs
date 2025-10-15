using UnityEngine;

public class NPC : Interactable {
	// Start is called once before the first execution of Update after the MonoBehaviour is created
	void Start() {

	}

	// Update is called once per frame
	void Update() {

	}

	public override void Interact() {
		base.Interact();
		Debug.Log("NPC");
	}
}
