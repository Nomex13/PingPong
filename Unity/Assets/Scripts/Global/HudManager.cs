using UnityEngine;
using System.Collections;

public class HudManager : MonoBehaviour
{
	private bool field_inited = false;

	public HudMain HudMain;
	public HudScore HudScore;

	void Start ()
	{
		;
	}
	
	void Update ()
	{
		;
	}

	public void Init()
	{
		if (field_inited)
			return;

		field_inited = true;
	}

	public void ShowHudMain()
	{
		HideHudAll();
		HudMain.Show();
		HudScore.Show();
	}
	public void HideHudAll()
	{
		HudMain.Hide();
		HudScore.Hide();
	}
}
