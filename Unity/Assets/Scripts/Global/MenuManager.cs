using UnityEngine;
using System.Collections;

public class MenuManager : MonoBehaviour
{
	private bool field_inited = false;

	public MenuMain MenuMain;
	public MenuPause MenuPause;
	public MenuPlay MenuPlay;
	public MenuOptions MenuOptions;
	public MenuOptionsVideo MenuOptionsVideo;
	public MenuOptionsAudio MenuOptionsAudio;
	public MenuOptionsOther MenuOptionsOther;
	public MenuOptionsLanguage MenuOptionsLanguage;
	public MenuHighscores MenuHighscores;

	void Start()
	{
		ShowMenuMain();
	}
	
	void Update()
	{
		;
	}

	public void Init()
	{
		field_inited = true;
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
	public void ShowMenuOptionsOther()
	{
		HideMenuAll();
		MenuOptionsOther.Show();
	}
	public void ShowMenuOptionsLanguage()
	{
		HideMenuAll();
		MenuOptionsLanguage.Show();
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
		MenuOptionsVideo.Hide();
		MenuOptionsAudio.Hide();
		MenuOptionsOther.Hide();
		MenuOptionsLanguage.Hide();
		MenuHighscores.Hide();
	}
}
