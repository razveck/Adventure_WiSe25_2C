using UnityEngine;

public class Interactable : MonoBehaviour {

	// Start is called once before the first execution of Update after the MonoBehaviour is created
	void Start() {

	}

	// Update is called once per frame
	void Update() {
		
	}

	//virtual erlaubt Subclasses Variationen/Erweiterungen von der Funktion zu erstellen
	public virtual void Interact() {
		Debug.Log("Interacted with " + name);
	}
}
