using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;


public class QuestManager : MonoBehaviour
{

	public DialogScreen dialogScreen;

	public TMP_Text questDisplay;

	public NPC npc1;
	public Item bottle;
	public DialogLine npc1_dialog2;


	void Start()
	{
		StartCoroutine(Quest1());
		StartCoroutine(Quest2());
	}


	IEnumerator Quest1()
	{

		yield return WaitForDialogChoice("quest1Start");

		TMP_Text myDisplay = Instantiate(questDisplay, questDisplay.transform.parent);

		//myDisplay.transform.parent.gameObject.SetActive(true);
		myDisplay.text = "Finde eine Flasche";

		bottle.gameObject.SetActive(true);
		yield return WaitForItem(bottle);

		myDisplay.text = "Bringe die Flasche zur�ck";

		npc1.dialog = npc1_dialog2;

		yield return WaitForNPC(npc1);
		//myDisplay.transform.parent.gameObject.SetActive(false);


		Destroy(myDisplay.gameObject);
	}

	IEnumerator Quest2(){
		Debug.Log("Quest 2 start");
		TMP_Text myDisplay = Instantiate(questDisplay, questDisplay.transform.parent);
		myDisplay.text = "HUHIU";
		
		yield return new WaitForSeconds(5);

		Debug.Log("Quest 2 end");
		Destroy(myDisplay.gameObject);

	}

	IEnumerator WaitForNPC(NPC npc)
	{
		bool talked = false;

		System.Action action = () =>
		{
			talked = true;
		};

		npc.onInteracted += action;

		yield return new WaitUntil(() => talked);

		npc.onInteracted -= action;
	}

	IEnumerator WaitForItem(Item item)
	{
		bool talked = false;

		System.Action action = () =>
		{
			talked = true;
		};

		item.onInteracted += action;

		yield return new WaitUntil(() => talked);

		item.onInteracted -= action;
	}

	IEnumerator WaitForDialogChoice(string id)
	{
		bool talked = false;

		//wir warten auf eine BESTIMMTE id (wir m�ssen die ids filtern)
		System.Action<string> action = (inputId) =>
		{
			if (inputId == id)
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
