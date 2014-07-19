using UnityEngine;
using System.Collections;

public class MenuOptionsLanguage : Menu
{
	public UIScrollView ScrollView;

	public override void Show()
	{
		base.Show();
		ScrollView.transform.position = new Vector3(0, 0, 0);
	}

	void OnClickGerman()
	{
		Global.LocalizationManager.SetLanguage("DE");
		Global.MenuManager.ShowMenuOptionsOther();
	}

	void OnClickEnglish()
	{
		Global.LocalizationManager.SetLanguage("EN");
		Global.MenuManager.ShowMenuOptionsOther();
	}

	void OnClickSpanish()
	{
		Global.LocalizationManager.SetLanguage("ES");
		Global.MenuManager.ShowMenuOptionsOther();
	}

	void OnClickFrench()
	{
		Global.LocalizationManager.SetLanguage("FR");
		Global.MenuManager.ShowMenuOptionsOther();
	}

	void OnClickItalian()
	{
		Global.LocalizationManager.SetLanguage("IT");
		Global.MenuManager.ShowMenuOptionsOther();
	}

	void OnClickRussian()
	{
		Global.LocalizationManager.SetLanguage("RU");
		Global.MenuManager.ShowMenuOptionsOther();
	}

	void OnClickBack()
	{
		Global.MenuManager.ShowMenuOptionsOther();
	}
}
