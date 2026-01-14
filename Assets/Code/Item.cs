using FMODUnity;
using UnityEngine;

public class Item : Interactable {

	public StudioEventEmitter emitter;

	public ItemType type;

	// Start is called once before the first execution of Update after the MonoBehaviour is created
	void Start() {

	}

	// Update is called once per frame
	void Update() {

	}

	//override �berschreibt/erweitert die Basis Funktion (in der Base Class)
	public override void Interact() {
		base.Interact();
		Debug.Log("Item");
		emitter.Play();
	}
}

public enum ItemType {
	Bottle, Key, Apple
}
