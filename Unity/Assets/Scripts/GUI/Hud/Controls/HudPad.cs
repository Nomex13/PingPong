using UnityEngine;
using System.Collections.Generic;

public class HudPad : MonoBehaviour
{
	public Gameplay Gameplay;
	public PadPlayerIs PadPlayer;
	public PadDirectionIs PadDirection;

	private Collider field_collider;
	private List<int> field_currentTouchIds = new List<int>();

	void Start ()
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
		if (PadDirection == PadDirectionIs.VERTICAL)
		{
			position = UICamera.GetTouch(field_currentTouchIds[field_currentTouchIds.Count - 1]).pos.y / Screen.height;
		}
		if (PadDirection == PadDirectionIs.HORIZONTAL)
		{
			position = UICamera.GetTouch(field_currentTouchIds[field_currentTouchIds.Count - 1]).pos.x / Screen.width;
		}
		//Debug.Log(position);

		if (PadPlayer == PadPlayerIs.PLAYER1)
		{
			Gameplay.SetPadOnePosition(position);
		}
		if (PadPlayer == PadPlayerIs.PLAYER2)
		{
			Gameplay.SetPadTwoPosition(position);
		}
	}

	void OnPress(bool param_isPressedNotReleased)
	{
		if (param_isPressedNotReleased)
		{
			bool found = false;
			for (int i = 0; i < field_currentTouchIds.Count; i++)
			{
				if (field_currentTouchIds[i] == UICamera.currentTouchID)
				{
					field_currentTouchIds.RemoveAt(i);
					field_currentTouchIds.Add(UICamera.currentTouchID);
					found = true;
					break;
				}
			}
			if (!found)
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
		field_collider.enabled = true;
	}
	public void Disable()
	{
		field_collider.enabled = false;
	}

	public enum PadPlayerIs
	{
		PLAYER1,
		PLAYER2
	}
	public enum PadDirectionIs
	{
		HORIZONTAL,
		VERTICAL
	}
}
