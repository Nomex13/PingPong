using UnityEngine;
using System.Collections;

public class MenuHighscores : Menu
{
	void Start()
	{
		;
	}

	void Update()
	{
		;
	}

	void OnClickPlayerVsPlayer()
	{
		Global.Gameplay.GameSet(2);
		Global.Gameplay.GameStart();
		Global.HudManager.ShowHudMain();
		Global.MenuManager.HideMenuAll();
	}

	void OnClickPlayerVsAi()
	{
		Global.Gameplay.GameSet(1);
		Global.Gameplay.GameStart();
		Global.HudManager.ShowHudMain();
		Global.MenuManager.HideMenuAll();
	}

	void OnClickAiVsAi()
	{
		Global.Gameplay.GameSet(0);
		Global.Gameplay.GameStart();
		Global.HudManager.ShowHudMain();
		Global.MenuManager.HideMenuAll();
	}

	void OnClickBack()
	{
		Global.MenuManager.ShowMenuMain();
	}
}
