using FMODUnity;
using UnityEngine;

public class AnimationEvents : MonoBehaviour {

	public EventReference footstepEvent;


	// Start is called once before the first execution of Update after the MonoBehaviour is created
	void Start() {

	}

	//wird vom Animation Event aufgerufen
	public void Footstep() {
		RuntimeManager.PlayOneShotAttached(footstepEvent, gameObject);
	}
}
