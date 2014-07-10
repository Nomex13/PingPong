using UnityEngine;
using System.Collections;

public class Global : MonoBehaviour
{
	private bool field_inited = false;

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
	void Start()
	{
		field_gameplay = FindObjectOfType<Gameplay>();
		field_hudManager = FindObjectOfType<HudManager>();
		field_menuManager = FindObjectOfType<MenuManager>();
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
		Global.Gameplay.GameStop();
		Global.HudManager.HideHudAll();
		Global.MenuManager.ShowMenuMain();

		field_inited = true;
	}
}
