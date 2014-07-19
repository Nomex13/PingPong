using System.Collections.Generic;
using UnityEngine;
using System.Collections;

public class HudSlider : MonoBehaviour
{
	public DirectionEnum Direction;
	public GameObject GameObject;
	public string Method;

	private Collider field_collider;
	private List<int> field_currentTouchIds = new List<int>();

	void Start()
	{
		field_collider = GetComponent<BoxCollider>();
	}

	void Update()
	{
		if (field_currentTouchIds.Count == 0)
			return;

		UpdatePosition();
	}

	void UpdatePosition()
	{
		float position = 0f;
		if (Direction == DirectionEnum.VERTICAL)
		{
			position = UICamera.GetTouch(field_currentTouchIds[field_currentTouchIds.Count - 1]).pos.y / Screen.height;
		}
		if (Direction == DirectionEnum.HORIZONTAL)
		{
			position = UICamera.GetTouch(field_currentTouchIds[field_currentTouchIds.Count - 1]).pos.x / Screen.width;
		}

		if (GameObject != null)
		{
			GameObject.SendMessage(Method, position);
		}
	}

	void OnPress(bool param_isPressedNotReleased)
	{
		if (param_isPressedNotReleased)
		{
			bool isAlreadyTracked = false;
			for (int i = 0; i < field_currentTouchIds.Count; i++)
			{
				if (field_currentTouchIds[i] == UICamera.currentTouchID)
				{
					// Make it the last one in the list
					field_currentTouchIds.RemoveAt(i);
					field_currentTouchIds.Add(UICamera.currentTouchID);
					isAlreadyTracked = true;
					break;
				}
			}
			if (!isAlreadyTracked)
			{
				field_currentTouchIds.Add(UICamera.currentTouchID);
			}
			//field_currentTouchId = UICamera.currentTouchID;

			//UpdatePosition();
		}
		else
		{
			for (int i = 0; i < field_currentTouchIds.Count; i++)
			{
				if (field_currentTouchIds[i] == UICamera.currentTouchID)
				{
					field_currentTouchIds.RemoveAt(i);
					break;
				}
			}
		}
		//Debug.Log("Pressed");
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

	public virtual void Show()
	{
		NGUITools.SetActive(gameObject, true);
	}
	public virtual void Hide()
	{
		NGUITools.SetActive(gameObject, false);
	}
}
