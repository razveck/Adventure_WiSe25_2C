using System.Collections;
using TMPro;
using UnityEngine;


public class DialogScreen : MonoBehaviour {

	private DialogLine currentDialog;

	public GameObject panel;
	public TMP_Text nameTMP;
	public TMP_Text dialogTMP;
	public GameObject[] choiceButtons;
	public GameObject continueButton;

	//optional für portrait
	//public UnityEngine.UI.Image portrait;

	// Use this for initialization
	void Start() {

	}

	public void ShowDialog(DialogLine dialog) {
		currentDialog = dialog;

		panel.SetActive(true);
		nameTMP.text = dialog.characterName;
		dialogTMP.text = dialog.dialogText;

		for(int i = 0; i < choiceButtons.Length; i++) {
			if(i < dialog.choices.Length) {
				choiceButtons[i].SetActive(true);
				choiceButtons[i].GetComponentInChildren<TMP_Text>().text = dialog.choices[i].text;
			} else {
				choiceButtons[i].SetActive(false);
			}
		}

		if(dialog.choices.Length == 0) {
			continueButton.SetActive(true);
		} else {
			continueButton.SetActive(false);
		}

	}

	public void SelectChoice(int index) {
		ShowDialog(currentDialog.choices[index].nextLine);
	}

	public void Continue() {
		if(currentDialog.defaultNextLine != null)
			ShowDialog(currentDialog.defaultNextLine);
		else
			panel.SetActive(false);
	}

}
