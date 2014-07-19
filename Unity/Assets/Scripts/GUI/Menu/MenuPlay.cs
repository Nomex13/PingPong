using UnityEngine;
using System.Collections;

public class MenuPlay : Menu
{
	void OnClickPlayerVsPlayer()
	{
		//Global.Gameplay.GameSet(2);
		//Global.Gameplay.GameStart();
		//Global.HudManager.ShowHudMain();
		//Global.MenuManager.HideMenuAll();

		Global.StateManager.GameStart();
	}

	void OnClickPlayerVsAi()
	{
		//Global.Gameplay.GameSet(1);
		//Global.Gameplay.GameStart();
		//Global.HudManager.ShowHudMain();
		//Global.MenuManager.HideMenuAll();
	}

	void OnClickAiVsAi()
	{
		//Global.Gameplay.GameSet(0);
		//Global.Gameplay.GameStart();
		//Global.HudManager.ShowHudMain();
		//Global.MenuManager.HideMenuAll();
	}

	void OnClickBack()
	{
		Global.MenuManager.ShowMenuMain();
	}
}
