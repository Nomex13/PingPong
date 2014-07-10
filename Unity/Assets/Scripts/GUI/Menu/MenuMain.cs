using UnityEngine;
using System.Collections;

public class MenuMain : Menu
{
	void Start ()
	{
		;
	}
	
	protected override void Update ()
	{
		base.Update();
	}

	void OnClickPlay()
	{
		Global.MenuManager.ShowMenuPlay();
	}

	void OnClickOptions()
	{
		Global.MenuManager.ShowMenuOptions();
	}

	void OnClickHighscores()
	{
		Global.MenuManager.ShowMenuHighscores();
	}

	void OnClickExit()
	{
		Global.Gameplay.GameExit();
	}
}
