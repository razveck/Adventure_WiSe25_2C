using FMODUnity;
using Unity.Cinemachine;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Processors;
using UnityEngine.UI;

public class SettingsScreen : MonoBehaviour
{

	public Slider mainSlider;
	public Slider musicSlider;
	public Slider effectsSlider;
	public Slider ambientSlider;

	public Slider mouseSensSlider;
	public Toggle invertYToggle;
	public InputActionReference lookAction;

	public Button backBtn;

	public GameObject settingsPanel;
	public GameObject otherPanel;

	// Start is called once before the first execution of Update after the MonoBehaviour is created
	void Start()
	{
		backBtn.onClick.AddListener(() =>
		{
			settingsPanel.SetActive(false);
			otherPanel.SetActive(true);
		});

		mainSlider.onValueChanged.AddListener((newValue) =>
		{
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


		mouseSensSlider.onValueChanged.AddListener((value) =>
		{
			PlayerPrefs.SetFloat("mouseSensitivity", value);
			lookAction.action.ApplyParameterOverride((ScaleVector2Processor p) => p.x, value);
			lookAction.action.ApplyParameterOverride((ScaleVector2Processor p) => p.y, value);
		});
		mouseSensSlider.value = PlayerPrefs.GetFloat("mouseSensitivity", 1);
		lookAction.action.ApplyParameterOverride((ScaleVector2Processor p) => p.x, mouseSensSlider.value);
		lookAction.action.ApplyParameterOverride((ScaleVector2Processor p) => p.y, mouseSensSlider.value);

		invertYToggle.onValueChanged.AddListener((isOn) =>
		{
			PlayerPrefs.SetString("invertY", isOn.ToString()); //"true" oder "false" als TEXT
			lookAction.action.ApplyParameterOverride((InvertVector2Processor p) => p.invertY, isOn);
		});
		invertYToggle.isOn = bool.Parse(PlayerPrefs.GetString("invertY", "false")); //string in bool konvertieren
		lookAction.action.ApplyParameterOverride((InvertVector2Processor p) => p.invertY, invertYToggle.isOn);

	}

}