using System.Collections;
using UnityEngine;

public class QuestManager : MonoBehaviour {

	public bool didTheThing;

	// Start is called once before the first execution of Update after the MonoBehaviour is created
	IEnumerator Start() {

		//3 Sekunden warten
		yield return new WaitForSeconds(3);

		Debug.Log("A");

		//auf eine Bedingung warten
		yield return new WaitUntil(() => didTheThing);

		//while(!didTheThing)
		//{
		//	//yield return
		//	//ein frame pausieren
		//	yield return null;
		//}



		Debug.Log("B");

	}

	// Update is called once per frame
	void Update() {
	}
}
