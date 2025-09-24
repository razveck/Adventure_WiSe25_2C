using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour {

	public PlayerInput input;
	private InputAction moveAction;

	public CharacterController controller;
	public float speed;

	// Start is called once before the first execution of Update after the MonoBehaviour is created
	void Start() {
		moveAction = input.actions.FindAction("Move");
	}

	// Update is called once per frame
	void Update() {
		Vector2 inputDirection = moveAction.ReadValue<Vector2>();

		Vector3 moveDirection = new(inputDirection.x, 0, inputDirection.y);

		controller.Move(moveDirection * Time.deltaTime * speed);
	}
}
