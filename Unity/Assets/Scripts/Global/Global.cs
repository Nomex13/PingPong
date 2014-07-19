using UnityEngine;
using System.Collections;

public class Global : MonoBehaviour
{
	private bool field_inited = false;

	private static Settings field_settings;
	public static Settings Settings
	{
		get
		{
			if (field_settings == null)
			{
				field_settings = FindObjectOfType<Settings>();
			}
			return field_settings;
		}
	}
	private static StateManager field_stateManager;
	public static StateManager StateManager
	{
		get
		{
			if (field_stateManager == null)
			{
				field_stateManager = FindObjectOfType<StateManager>();
			}
			return field_stateManager;
		}
	}
	private static LocalizationManager field_localizationManager;
	public static LocalizationManager LocalizationManager
	{
		get
		{
			if (field_localizationManager == null)
			{
				field_localizationManager = FindObjectOfType<LocalizationManager>();
			}
			return field_localizationManager;
		}
	}
	private static HudManager field_hudManager;
	public static HudManager HudManager
	{
		get
		{
			if (field_hudManager == null)
			{
				field_hudManager = FindObjectOfType<HudManager>();
			}
			return field_hudManager;
		}
	}
	private static MenuManager field_menuManager;
	public static MenuManager MenuManager
	{
		get
		{
			if (field_menuManager == null)
			{
				field_menuManager = FindObjectOfType<MenuManager>();
			}
			return field_menuManager;
		}
	}
	private static AudioManager field_audioManager;
	public static AudioManager AudioManager
	{
		get
		{
			if (field_audioManager == null)
			{
				field_audioManager = FindObjectOfType<AudioManager>();
			}
			return field_audioManager;
		}
	}
	private static HapticsManager field_hapticsManager;
	public static HapticsManager HapticsManager
	{
		get
		{
			if (field_hapticsManager == null)
			{
				field_hapticsManager = FindObjectOfType<HapticsManager>();
			}
			return field_hapticsManager;
		}
	}
	private static Gameplay field_gameplay;
	public static Gameplay Gameplay
	{
		get
		{
			if (field_gameplay == null)
			{
				field_gameplay = FindObjectOfType<Gameplay>();
			}
			return field_gameplay;
		}
	}
	private static ScoreManager field_scoreManager;
	public static ScoreManager ScoreManager
	{
		get
		{
			if (field_scoreManager == null)
			{
				field_scoreManager = FindObjectOfType<ScoreManager>();
			}
			return field_scoreManager;
		}
	}
	void Start()
	{
		field_settings = FindObjectOfType<Settings>();
		field_stateManager = FindObjectOfType<StateManager>();
		field_localizationManager = FindObjectOfType<LocalizationManager>();
		field_hudManager = FindObjectOfType<HudManager>();
		field_menuManager = FindObjectOfType<MenuManager>();
		field_audioManager = FindObjectOfType<AudioManager>();
		field_hapticsManager = FindObjectOfType<HapticsManager>();

		field_gameplay = FindObjectOfType<Gameplay>();
		field_scoreManager = FindObjectOfType<ScoreManager>();
	}

	void Update()
	{
		if (!field_inited)
		{
			Init();
		}
	}

	void Init()
	{
		field_settings.Init();
		field_stateManager.Init();
		field_localizationManager.Init();
		field_hudManager.Init();
		field_menuManager.Init();
		field_audioManager.Init();
		field_hapticsManager.Init();

		field_gameplay.Init();
		field_scoreManager.Init();

		field_stateManager.GameInit();

		//field_gameplay.GameStop();
		//field_menuManager.ShowMenuMain();
		//field_audioManager.PlayMusicMenu();
		//MenuManager.ShowMenuOptionsAudio();
		//MenuManager.ShowMenuOptionsLanguage();

		field_inited = true;
		//Localization.language = "RU";
	}
}
