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
		if (field_collider != null)
			field_collider.enabled = true;
	}
	public void Disable()
	{
		if (field_collider != null)
			field_collider.enabled = false;
	}
}
