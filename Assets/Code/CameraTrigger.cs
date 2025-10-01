using Unity.Cinemachine;
using UnityEngine;

public class CameraTrigger : MonoBehaviour {

	public CinemachineCamera camera;

	private void OnTriggerEnter(Collider other) {
		//camera.SetActive(true);
		camera.Prioritize();
	}

	private void OnTriggerExit(Collider other) {
		//camera.SetActive(false);
	}
}
