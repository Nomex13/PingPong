using UnityEngine;
using System.Collections;

public class MenuSlider : MonoBehaviour
{
	public GameObject Foreground;
	public GameObject Background;
	public GameObject ForegroundText;
	public GameObject BackgroundText;
	public GameObject ForegroundSprite;
	public GameObject BackgroundSprite;

	public GameObject CallObject;
	public string CallMethod;

	private UIPanel field_foregroundPanel;
	private UIWidget field_backgroundWidget;
	private bool field_dragging;

	private float field_value;

	void Start ()
	{
		field_foregroundPanel = Foreground.GetComponent<UIPanel>();
		field_backgroundWidget = Background.GetComponent<UIWidget>();
		field_value = 0;
	}
	
	void Update ()
	{
		;
	}

	public void SetValue(float param_value)
	{
		if (param_value < 0)
			param_value = 0;
		if (param_value > 1)
			param_value = 1;

		field_value = param_value;
		if (field_foregroundPanel != null)
		{
			field_foregroundPanel.rightAnchor.relative = field_value;
		}
		if (CallObject != null)
		{
			CallObject.SendMessage(CallMethod, field_value);
		}
	}

	public float GetValue()
	{
		return field_value;
	}

	void OnClick()
	{
	}

	void OnPress(bool param_isDown)
	{
		if (param_isDown)
		{
			field_dragging = true;
			OnDrag(Vector2.zero);
			field_dragging = false;
		}
	}

	void OnDrag(Vector2 param_delta)
	{
		if (!field_dragging)
			return;

		SetValue((UICamera.currentTouch.pos.x - UICamera.currentCamera.WorldToScreenPoint(field_backgroundWidget.worldCorners[0]).x) / field_backgroundWidget.width);

		//Debug.Log((UICamera.currentTouch.pos.x + field_backgroundWidget.GetSides(transform)[0].x));
		//Debug.Log("Cam=" + UICamera.currentTouch.pos.x + ", Corner=" + UICamera.currentCamera.WorldToScreenPoint(field_backgroundWidget.worldCorners[0]).x + ", Abs=" + field_backgroundWidget.leftAnchor.absolute + ", Rel=" + field_backgroundWidget.leftAnchor.relative + ", Width=" + field_backgroundWidget.width);
	}

	void OnDragStart()
	{
		field_dragging = true;
	}

	void OnDragEnd()
	{
		field_dragging = false;
	}

	void OnDragOut(object param_object)
	{
	}
}
