using UnityEngine;
using System.Collections;

public class HudButton : MonoBehaviour
{
	private Collider field_collider;
	public GameObject GameObject;
	public string Method;

	void Start ()
	{
		field_collider = GetComponent<BoxCollider>();
	}
	
	void Update ()
	{
		;
	}

	void OnClick()
	{
		if (GameObject != null)
		{
			GameObject.SendMessage(Method);
		}
	}

	public void Enable()
	{
		field_collider.enabled = true;
	}
	public void Disable()
	{
		field_collider.enabled = false;
	}
}
