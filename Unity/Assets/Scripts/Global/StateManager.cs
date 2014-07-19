using UnityEngine;
using System.Collections;

public class StateManager : MonoBehaviour
{
	private bool field_inited = false;

	private MenuState field_menuState;
	public MenuState MenuState
	{
		get
		{
			return field_menuState;
		}
	}
	private GameState field_gameState;
	public GameState GameState
	{
		get
		{
			return field_gameState;
		}
	}

	void Start()
	{
		;
	}

	void Update()
	{
		;
	}

	public void Init()
	{
		if (field_inited)
			return;

		field_gameState = GameState.IDLE;;
		field_menuState = MenuState.NORMAL;

		field_inited = true;
	}

	public void GameInit()
	{
		Global.HudManager.HideHudAll();
		Global.MenuManager.ShowMenuMain();
		Global.AudioManager.PlayMusicMenu();
		Global.ScoreManager.SetScore(0, 0);
		Global.Gameplay.GameStop();

		field_gameState = GameState.IDLE;
		field_menuState = MenuState.NORMAL;
	}

	public void GameStart()
	{
		Global.MenuManager.HideMenuAll();
		Global.HudManager.ShowHudMain();
		Global.AudioManager.PlayMusicGame();
		Global.ScoreManager.SetScore(0, 0);
		Global.Gameplay.GameStart();

		field_gameState = GameState.RUNNING;
		field_menuState = MenuState.HIDDEN;
	}
	public void GameResume()
	{
		Global.MenuManager.HideMenuAll();
		Global.HudManager.ShowHudMain();
		Global.AudioManager.PlayMusicGame();
		Global.Gameplay.GameResume();

		field_gameState = GameState.RUNNING;
		field_menuState = MenuState.HIDDEN;
	}
	public void GamePause()
	{
		Global.HudManager.HideHudAll();
		Global.MenuManager.ShowMenuPause();
		Global.AudioManager.PlayMusicMenu();
		Global.Gameplay.GamePause();

		field_gameState = GameState.PAUSED;
		field_menuState = MenuState.PAUSED;
	}
	public void GameStop()
	{
		Global.HudManager.HideHudAll();
		Global.MenuManager.ShowMenuMain();
		Global.AudioManager.PlayMusicMenu();
		Global.Gameplay.GameStop();

		field_gameState = GameState.IDLE;
		field_menuState = MenuState.NORMAL;
	}
}

public enum MenuState
{
	HIDDEN,
	PAUSED,
	NORMAL
}

public enum GameState
{
	IDLE,
	PAUSED,
	RUNNING
}