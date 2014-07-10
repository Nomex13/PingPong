using System;
using UnityEngine;
using System.Collections;

public class Menu : MonoBehaviour
{
	private int field_screenWidth = 0;
	private int field_screenHeight = 0;
	private float field_screenDpi = 0;

	private float field_angle = 0f;

	void Start()
	{
		;
	}
	
	protected virtual void Update()
	{
		if (field_screenWidth != Screen.width || field_screenHeight != Screen.height)
		{
			Resize();
		}

		Vector2 acceleration = new Vector2(Input.acceleration.normalized.x, Input.acceleration.normalized.y);
		if (acceleration.magnitude > 0.5)
		{
			field_angle = -Vector2.Angle(new Vector2(0, 1), acceleration) * Mathf.PI / 180;
		}

		UIWidget widget = GetComponent<UIWidget>();
		// Rotate
		gameObject.transform.localRotation = Quaternion.Euler(0f, 0f, field_angle / Mathf.PI * 180);
		// Adjust size
		widget.leftAnchor.absolute = Convert.ToInt32(Mathf.Abs(Mathf.Sin(field_angle)) * (field_screenWidth - field_screenHeight) / 2);
		widget.rightAnchor.absolute = Convert.ToInt32(-Mathf.Abs(Mathf.Sin(field_angle)) * (field_screenWidth - field_screenHeight) / 2);
		widget.topAnchor.absolute = Convert.ToInt32(-Mathf.Abs(Mathf.Sin(field_angle)) * (field_screenHeight - field_screenWidth) / 2);
		widget.bottomAnchor.absolute = Convert.ToInt32(Mathf.Abs(Mathf.Sin(field_angle)) * (field_screenHeight - field_screenWidth) / 2);

		//field_angle += 0.01f;
	}

	void Resize()
	{
		field_screenWidth = Screen.width;
		field_screenHeight = Screen.height;
		field_screenDpi = Screen.dpi;
		if (field_screenDpi == 0)
		{
			field_screenDpi = 160; // Default DPI for desktops and any weird platform
		}
	}

	public void Show()
	{
		gameObject.SetActive(true);
	}
	public void Hide()
	{
		gameObject.SetActive(false);
	}
}
