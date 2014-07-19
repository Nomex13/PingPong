using UnityEngine;
using System.Collections;

public class MenuOptions : Menu
{
	void OnClickOther()
	{
		Global.MenuManager.ShowMenuOptionsOther();
	}

	void OnClickVideo()
	{
		Global.MenuManager.ShowMenuOptionsVideo();
	}

	void OnClickAudio()
	{
		Global.MenuManager.ShowMenuOptionsAudio();
	}

	void OnClickBack()
	{
		if (Global.StateManager.GameState == GameState.PAUSED)
		{
			Global.MenuManager.ShowMenuPause();
		}
		else
		{
			Global.MenuManager.ShowMenuMain();
		}
	}
}
