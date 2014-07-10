using UnityEngine;
using System.Collections;

public class MenuPause : Menu
{
	void Start()
	{
		;
	}
	
	void Update()
	{
		;
	}

	void OnClickResume()
	{
		//Global.Gameplay.GameSet(2);
		//Global.Gameplay.GameStart();
		//Global.HudManager.ShowHudMain();
		//Global.MenuManager.HideMenuAll();
		Global.Gameplay.GameResume();
		Global.HudManager.ShowHudMain();
		Global.MenuManager.HideMenuAll();
	}

	void OnClickOptions()
	{
		Global.MenuManager.ShowMenuOptions();
	}

	void OnClickHighscores()
	{
		Global.MenuManager.ShowMenuHighscores();
	}

	void OnClickEnd()
	{
		Global.Gameplay.GameStop();
		Global.HudManager.HideHudAll();
		Global.MenuManager.ShowMenuMain();
	}
}
