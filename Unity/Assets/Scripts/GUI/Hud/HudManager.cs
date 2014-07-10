using UnityEngine;
using System.Collections;

public class HudManager : MonoBehaviour
{
	public HudMain HudMain;

	void Start ()
	{
		;
	}
	
	void Update ()
	{
		;
	}

	public void ShowHudMain()
	{
		HideHudAll();
		HudMain.Show();
	}
	public void HideHudAll()
	{
		HudMain.Hide();
	}
}
