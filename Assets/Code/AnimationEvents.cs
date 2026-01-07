using FMOD.Studio;
using FMODUnity;
using UnityEngine;

public class AnimationEvents : MonoBehaviour
{
	private EventInstance footstepInstance;
	public EventReference footstepEvent;

	public LayerMask layerMask;


	// Start is called once before the first execution of Update after the MonoBehaviour is created
	void Start()
	{
		footstepInstance = RuntimeManager.CreateInstance(footstepEvent);
	}

	//wird vom Animation Event aufgerufen
	public void Footstep()
	{

		if (Physics.Raycast(transform.position + new Vector3(0,2,0), Vector3.down, out RaycastHit hit, 9999, layerMask))
		{
			string untergrund = hit.collider.tag;
			footstepInstance.setParameterByNameWithLabel("Untergründe", untergrund); //Untergründe ist der Name vom FMOD Parameter
		}
		else
		{
			footstepInstance.setParameterByNameWithLabel("Untergründe", "Leaves");
		}

		footstepInstance.set3DAttributes(RuntimeUtils.To3DAttributes(transform)); //unsere position aufs instance/event übertragen
		footstepInstance.start();
	}
}
