using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour {

	public PlayerInput input;
	private InputAction moveAction;

	public CharacterController controller;
	public Animator animator;
	public float speed;
	public float turnSpeed;
	public Transform directionReference;

	public Interactable currentInteractable;

	// Start is called once before the first execution of Update after the MonoBehaviour is created
	void Start() {
		moveAction = input.actions.FindAction("Move");

		input.actions.FindAction("Interact").performed += Interact_performed;

	}

	private void Interact_performed(InputAction.CallbackContext obj) {
		//test
		if(currentInteractable != null)
			currentInteractable.Interact();
	}

	// Update is called once per frame
	void Update() {
		Vector2 inputDirection = moveAction.ReadValue<Vector2>();

		//nur für feste Kamera!!!
		//wenn wir die "Move" Taste drücken, übernimmt das Reference Object die Camera Rotation
		if(moveAction.WasPressedThisFrame())
			directionReference.rotation = Camera.main.transform.rotation;

		Vector3 forward = directionReference.forward; //die lokale Z-Achse (der Kamera)
		forward.y = 0f;
		forward.Normalize();
		Vector3 right = directionReference.right; //lokale X-Achse
		right.y = 0f;
		right.Normalize();
		//transform.up -> lokale Y-Achse

		//wie viel auf forward + wie viel auf right
		Vector3 moveDirection = forward * inputDirection.y + right * inputDirection.x;

		controller.Move(moveDirection * (Time.deltaTime * speed));

		if(!controller.isGrounded)
			controller.Move(new Vector3(0, -1, 0)); //Schwerkraft ist eine Beschleunigung

		if(inputDirection != Vector2.zero) {
			//transform (klein) verweist auf "this" transform
			transform.forward = Vector3.Slerp(transform.forward, moveDirection, Time.deltaTime * turnSpeed);
		}

		animator.SetFloat("speed", inputDirection.magnitude * speed);
	}

	private void OnTriggerEnter(Collider other) {
		Interactable interactable = other.GetComponent<Interactable>(); //sucht nach einem Interactable Component auf "other"

		if(interactable != null) //wenn es nicht null ist, haben wir auf jeden Fall ein Interactable berührt
			currentInteractable = interactable;
	}

	private void OnTriggerExit(Collider other) {
		Interactable interactable = other.GetComponent<Interactable>();

		if(interactable != null)
			currentInteractable = null;
	}

}
