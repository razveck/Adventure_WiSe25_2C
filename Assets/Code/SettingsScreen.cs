using FMODUnity;
using Unity.Collections.LowLevel.Unsafe;
using UnityEngine;
using UnityEngine.UI;

public class SettingsScreen : MonoBehaviour {

	public Slider mainSlider;
	public Slider musicSlider;
	public Slider effectsSlider;
	public Slider ambientSlider;

	public Slider mouseSensSlider;
	public Toggle invertYToggle;

	public Button backBtn;

	public GameObject settingsPanel;
	public GameObject otherPanel;

	// Start is called once before the first execution of Update after the MonoBehaviour is created
	void Start() {
		backBtn.onClick.AddListener(() => {
			settingsPanel.SetActive(false);
			otherPanel.SetActive(true);
		});

		mainSlider.onValueChanged.AddListener((newValue) => {
			//"bus:/" ist der default master bus
			//andere busses haben andere Pfade zB: "bus:/Game Pause/Music"
			RuntimeManager.GetBus("bus:/").setVolume(newValue);

			//variante mit VCA (entweder Bus ODER Vca benutzen)
			//RuntimeManager.GetVCA("vca:/Master").setVolume(newValue);

			PlayerPrefs.SetFloat("mainVolume", newValue);
		});



		//load audio settings
		mainSlider.value = PlayerPrefs.GetFloat("mainVolume", 0.5f);
		RuntimeManager.GetBus("bus:/").setVolume(mainSlider.value);
	}

}