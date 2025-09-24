using UnityEngine;

public class Beispiel : MonoBehaviour
{

	//public Variables werden im Inspector angezeigt
	public GameObject objectToDestroy;



	// Start is called once before the first execution of Update after the MonoBehaviour is created
	void Start() {
		Debug.Log("Start");
	}

	// Update is called once per frame
	void Update() {
		Debug.Log("Update");
	}

	private void OnCollisionEnter(Collision collision) {
		//Destroy(gameObject); //this gameObject
		
		//Destroy(collision.gameObject); //das gameObject mit dem wir kollidieren

		Destroy(objectToDestroy); //ein beliebiges Objekt (in der Variabel verwiesen)
	}

}
