using UnityEngine;
using System.Collections;

public class MenuManager : MonoBehaviour
{
	public MenuMain MenuMain;
	public MenuPause MenuPause;
	public MenuPlay MenuPlay;
	public MenuOptions MenuOptions;
	public MenuOptionsGameplay MenuOptionsGameplay;
	public MenuOptionsVideo MenuOptionsVideo;
	public MenuOptionsAudio MenuOptionsAudio;
	public MenuHighscores MenuHighscores;

	void Start()
	{
		ShowMenuMain();
	}
	
	void Update()
	{

	}

	public void ShowMenuMain()
	{
		HideMenuAll();
		MenuMain.Show();
	}
	public void ShowMenuPause()
	{
		HideMenuAll();
		MenuPause.Show();
	}
	public void ShowMenuPlay()
	{
		HideMenuAll();
		MenuPlay.Show();
	}
	public void ShowMenuOptions()
	{
		HideMenuAll();
		MenuOptions.Show();
	}
	public void ShowMenuOptionsGameplay()
	{
		HideMenuAll();
		MenuOptionsGameplay.Show();
	}
	public void ShowMenuOptionsVideo()
	{
		HideMenuAll();
		MenuOptionsVideo.Show();
	}
	public void ShowMenuOptionsAudio()
	{
		HideMenuAll();
		MenuOptionsAudio.Show();
	}
	public void ShowMenuHighscores()
	{
		HideMenuAll();
		MenuHighscores.Show();
	}
	public void HideMenuAll()
	{
		MenuMain.Hide();
		MenuPause.Hide();
		MenuPlay.Hide();
		MenuOptions.Hide();
		MenuOptionsGameplay.Hide();
		MenuOptionsVideo.Hide();
		MenuOptionsAudio.Hide();
		MenuHighscores.Hide();
	}
}
