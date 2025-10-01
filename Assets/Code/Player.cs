using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour {

	public PlayerInput input;
	private InputAction moveAction;

	public CharacterController controller;
	public float speed;
	public Transform cameraTransform;

	// Start is called once before the first execution of Update after the MonoBehaviour is created
	void Start() {
		moveAction = input.actions.FindAction("Move");
	}

	// Update is called once per frame
	void Update() {
		Vector2 inputDirection = moveAction.ReadValue<Vector2>();

		Vector3 forward = cameraTransform.forward; //die lokale Z-Achse (der Kamera)
		forward.y = 0;
		forward.Normalize();
		Vector3 right = cameraTransform.right; //lokale X-Achse
		//transform.up -> lokale Y-Achse

		//wie viel auf forward + wie viel auf right
		Vector3 moveDirection = forward * inputDirection.y + right * inputDirection.x;


		controller.Move(moveDirection * (Time.deltaTime * speed));
	}
}
