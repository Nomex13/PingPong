using UnityEngine;
using System.Collections;

public class HudMain : Hud
{
	public HudSlider SliderLeft;
	public HudSlider SliderRight;
	public HudSlider SliderTop;
	public HudSlider SliderBottom;
	public HudButton ButtonPause;

	private int field_screenWidth = 0;
	private int field_screenHeight = 0;
	private float field_screenDpi = 0;
	private DirectionEnum field_direction;
	//private ScreenOrientation field_screenOrientaion;

	void Start()
	{
		;
	}
	
	void Update()
	{
		//if (field_screenOrientaion != Screen.orientation)
		//{
		//    Rerotate();
		//}
		if (field_screenWidth != Screen.width || field_screenHeight != Screen.height)
		{
			Resize();
		}
	}
	void Resize()
	{
		field_screenWidth = Screen.width;
		field_screenHeight = Screen.height;
		field_screenDpi = Screen.dpi;
		if (field_screenDpi == 0)
		{
			field_screenDpi = 160; // Default DPI for desktops and any weird platform
		}
		if (field_screenWidth > field_screenHeight)
		{
			SetDirection(DirectionEnum.HORIZONTAL);
		}
		else
		{
			SetDirection(DirectionEnum.VERTICAL);
		}
	}
	//void Rerotate()
	//{
	//    field_screenOrientaion = Screen.orientation;
	//}


	public void SetDirection(DirectionEnum param_direction)
	{
		field_direction = param_direction;
		if (field_direction == DirectionEnum.HORIZONTAL)
		{
			SetHorizontal();
		}
		else
		{
			SetVertical();
		}
	}

	public void SetHorizontal()
	{
		SliderLeft.Enable();
		SliderRight.Enable();
		SliderTop.Disable();
		SliderBottom.Disable();
	}

	public void SetVertical()
	{
		SliderLeft.Disable();
		SliderRight.Disable();
		SliderTop.Enable();
		SliderBottom.Enable();
	}
	public override void Show()
	{
		base.Show();
		if (field_direction == DirectionEnum.HORIZONTAL)
		{
			SetHorizontal();
		}
		else
		{
			SetVertical();
		}
		ButtonPause.Enable();
	}
	public override void Hide()
	{
		base.Hide();
		SliderLeft.Disable();
		SliderRight.Disable();
		SliderTop.Disable();
		SliderBottom.Disable();
		ButtonPause.Disable();
	}
	void OnClickCenter()
	{
		//Global.Gameplay.GamePause();
		//Global.HudManager.HideHudAll();
		//Global.MenuManager.ShowMenuPause();

		Global.StateManager.GamePause();
	}
	void OnSlideLeft(float param_position)
	{
		Global.Gameplay.SetPadOnePosition(param_position);
	}
	void OnSlideRight(float param_position)
	{
		Global.Gameplay.SetPadTwoPosition(param_position);
	}
	void OnSlideTop(float param_position)
	{
		Global.Gameplay.SetPadOnePosition(param_position);
	}
	void OnSlideBottom(float param_position)
	{
		Global.Gameplay.SetPadTwoPosition(param_position);
	}
}
