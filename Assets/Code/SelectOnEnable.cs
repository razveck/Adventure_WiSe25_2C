using UnityEngine;
using UnityEngine.EventSystems;

public class SelectOnEnable : MonoBehaviour {
	public GameObject objectToSelect;

	private void OnEnable() {
		//wenn DIESES aktiviert wird, legen wir den Fokus auf "objectToSelect"
		EventSystem.current.SetSelectedGameObject(objectToSelect);
	}
}
