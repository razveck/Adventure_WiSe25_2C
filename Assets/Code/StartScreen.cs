using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StartScreen : MonoBehaviour {

	//UnityEngine.UI
	public Button startBtn;
	public Button settingsBtn;
	public Button creditsBtn;
	public Button quitBtn;

	public GameObject startPanel;
	public GameObject settingsPanel;

	// Start is called once before the first execution of Update after the MonoBehaviour is created
	void Start() {
		startBtn.onClick.AddListener(() => {
			SceneManager.LoadScene("SampleScene");
		});

		settingsBtn.onClick.AddListener(() => {
			startPanel.SetActive(false);
			settingsPanel.SetActive(true);
		});

		quitBtn.onClick.AddListener(() => {
			Application.Quit();
		});
	}
}
