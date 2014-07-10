using UnityEngine;
using System.Collections;

public class MenuButton : MonoBehaviour
{
	public GameObject Text;
	public GameObject Background;

	public GameObject CallObject;
	public string CallMethod;

	private TweenColor field_textTweenColor;
	private TweenColor field_backgroundTweenColor;

	void Start ()
	{
		field_textTweenColor = Text.GetComponent<TweenColor>();
		field_backgroundTweenColor = Background.GetComponent<TweenColor>();

		field_textTweenColor.enabled = true;
		field_backgroundTweenColor.enabled = true;

		field_textTweenColor.PlayReverse();
		field_backgroundTweenColor.PlayReverse();
	}
	void OnDisable()
	{
		if (field_textTweenColor != null)
			field_textTweenColor.value = field_textTweenColor.from;
		if (field_backgroundTweenColor != null)
			field_backgroundTweenColor.value = field_backgroundTweenColor.from;
	}
	void OnEnable()
	{
		if (field_textTweenColor != null)
			field_textTweenColor.value = field_textTweenColor.from;
		if (field_backgroundTweenColor != null)
			field_backgroundTweenColor.value = field_backgroundTweenColor.from;
	}
	
	void Update ()
	{
		;
	}

	void OnClick()
	{
		field_textTweenColor.PlayForward();
		field_backgroundTweenColor.PlayForward();

		//Debug.Log("Button clicked");

		//StopCoroutine("DoClick");
		StartCoroutine(DoClick());
		if (CallObject != null)
		{
			CallObject.SendMessage(CallMethod);
		}
	}

	void OnHover(bool param_isHoverNotBlur)
	{
		//Debug.Log("Hover: " + param_isHoverNotBlur);
		if (param_isHoverNotBlur)
		{
			field_textTweenColor.PlayForward();
			field_backgroundTweenColor.PlayForward();
		}
		else
		{
			field_textTweenColor.PlayReverse();
			field_backgroundTweenColor.PlayReverse();
		}
	}

	IEnumerator DoClick()
	{
		yield return new WaitForSeconds(0.1f);

		//Debug.Log("Button clicked!!!");
		if (CallObject != null)
		{
			CallObject.SendMessage(CallMethod);
		}
		yield return null;
	}
}
