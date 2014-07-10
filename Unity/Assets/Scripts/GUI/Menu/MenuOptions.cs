using UnityEngine;
using System.Collections;

public class MenuOptions : Menu
{
	void Start()
	{
		;
	}

	void Update()
	{
		;
	}

	void OnClickGameplay()
	{
		Global.MenuManager.ShowMenuOptionsGameplay();
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
		Global.MenuManager.ShowMenuMain();
	}
}
