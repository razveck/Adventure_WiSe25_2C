using System.Collections;
using FMODUnity;
using UnityEngine;

public class DialogLine : MonoBehaviour {

	public string characterName;
	public string dialogText;
	public DialogChoice[] choices; //array
	public DialogLine defaultNextLine;

	//optional
	//public Sprite portrait;
	//animation, audio, usw.
	public EventReference fmodEvent;

	/*ARRAY BEISPIEL
	void Func(){
		int[] zahlen = new int[10];
		//[x] -> index
		zahlen[0] = 3;
		zahlen[1] = -10;
		Debug.Log(zahlen[1]);
	}
	*/
}
