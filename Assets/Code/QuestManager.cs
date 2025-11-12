using System.Collections;
using TMPro;
using UnityEngine;

public class QuestManager : MonoBehaviour {

	public DialogScreen dialogScreen;

	public TMP_Text questDisplay;

	public NPC npc1;
	public Item bottle;
	public DialogLine npc1_dialog2;

	void Start() {
		StartCoroutine(Quest1());
	}

	IEnumerator Quest1(){

		yield return WaitForDialogChoice("quest1Start");

		questDisplay.transform.parent.gameObject.SetActive(true);
		questDisplay.text = "Finde eine Flasche";

		bottle.gameObject.SetActive(true);
		yield return WaitForItem(bottle);

		questDisplay.text = "Bringe die Flasche zurück";

		npc1.dialog = npc1_dialog2;

		yield return WaitForNPC(npc1);
		questDisplay.transform.parent.gameObject.SetActive(false);
	}

	IEnumerator WaitForNPC(NPC npc){
		bool talked = false;

		System.Action action = () => {
			talked = true;
		};

		npc.onInteracted += action;

		yield return new WaitUntil(() => talked);

		npc.onInteracted -= action;
	}

	IEnumerator WaitForItem(Item item){
		bool talked = false;

		System.Action action = () => {
			talked = true;
		};

		item.onInteracted += action;

		yield return new WaitUntil(() => talked);

		item.onInteracted -= action;
	}

	IEnumerator WaitForDialogChoice(string id) {
		bool talked = false;

		//wir warten auf eine BESTIMMTE id (wir müssen die ids filtern)
		System.Action<string> action = (inputId) => {
			if(inputId == id)
				talked = true;
		};

		dialogScreen.onDialogChoice += action;

		yield return new WaitUntil(() => talked);

		dialogScreen.onDialogChoice -= action;
	}
	

	/* COROTUINE BEISPIEL
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
	*/

}
