using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class PauseScreen : MonoBehaviour {

	public Button resumeBtn;
	public Button settingsBtn;
	public Button exitBtn;

	public GameObject pausePanel;
	public GameObject settingsPanel;

	public PlayerInput input;

	public GameObject dialogPanel;

	// Start is called once before the first execution of Update after the MonoBehaviour is created
	void Start() {
		input.actions.FindActionMap("Player").FindAction("Pause").performed += TogglePause;
		input.actions.FindActionMap("UI").FindAction("Pause").performed += TogglePause;
	}

	private void TogglePause(InputAction.CallbackContext obj) {
		if(Time.timeScale == 0)
			Unpause();
		else
			Pause();
	}

	private void Pause() {
		Time.timeScale = 0;
		input.SwitchCurrentActionMap("UI");
		pausePanel.SetActive(true);
	}

	private void Unpause() {
		Time.timeScale = 1;
		input.SwitchCurrentActionMap("Player");
		pausePanel.SetActive(false);
		settingsPanel.SetActive(false);
	}
}
