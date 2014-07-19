using UnityEngine;
using System.Collections;

public class LocalizationManager : MonoBehaviour
{
	private bool field_inited = false;

	void Start ()
	{
		;
	}
	
	void Update ()
	{
		;
	}

	public void Init()
	{
		if (field_inited)
			return;

		field_inited = true;
	}

	public void SetLanguage(string param_language)
	{
		Global.Settings.Language = param_language;
	}
}
