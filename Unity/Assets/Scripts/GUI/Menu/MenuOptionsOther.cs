using UnityEngine;
using System.Collections;

public class MenuOptionsOther : Menu
{
	void OnClickLanguage()
	{
		Global.MenuManager.ShowMenuOptionsLanguage();
	}

	void OnClickBack()
	{
		Global.MenuManager.ShowMenuOptions();
	}
}
