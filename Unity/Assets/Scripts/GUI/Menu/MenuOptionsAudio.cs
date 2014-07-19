using UnityEngine;
using System.Collections;

public class MenuOptionsAudio : Menu
{
	public MenuSlider MenuSliderMusic;
	public MenuSlider MenuSliderSound;
	public MenuSlider MenuSliderVibration;

	public override void Show()
	{
		base.Show();
	}

	void Update()
	{
		MenuSliderMusic.SetValue(Global.Settings.MusicVolume);
		MenuSliderSound.SetValue(Global.Settings.SoundVolume);
		MenuSliderVibration.SetValue(Global.Settings.Vibration);
	}

	void OnDragMusicVolume(float param_value)
	{
		Global.Settings.MusicVolume = param_value;
	}

	void OnDragSoundVolume(float param_value)
	{
		Global.Settings.SoundVolume = param_value;
	}

	void OnDragVibration(float param_value)
	{
		Global.Settings.Vibration = param_value;
	}

	void OnClickBack()
	{
		Global.MenuManager.ShowMenuOptions();
	}
}
