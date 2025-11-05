using System.Collections;
using TMPro;
using Unity.Cinemachine;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;


public class DialogScreen : MonoBehaviour {

	private DialogLine currentDialog;

	public GameObject panel;
	public TMP_Text nameTMP;
	public TMP_Text dialogTMP;
	public GameObject[] choiceButtons;
	public GameObject continueButton;

	public PlayerInput input;

	//nur wenn man eine FreeLookCamera hat
	public CinemachineInputAxisController cinemachineController;

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
			EventSystem.current.SetSelectedGameObject(continueButton);
		} else {
			continueButton.SetActive(false);
			EventSystem.current.SetSelectedGameObject(choiceButtons[0]);
		}

		input.SwitchCurrentActionMap("UI");
		cinemachineController.enabled = false;
	}

	public void Hide(){
		panel.SetActive(false);
		input.SwitchCurrentActionMap("Player");
		cinemachineController.enabled = true;
	}

	public void SelectChoice(int index) {
		ShowDialog(currentDialog.choices[index].nextLine);
	}

	public void Continue() {
		if(currentDialog.defaultNextLine != null)
			ShowDialog(currentDialog.defaultNextLine);
		else
			Hide();
	}

}
