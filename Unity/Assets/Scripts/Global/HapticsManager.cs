using UnityEngine;
using System.Collections;

public class HapticsManager : MonoBehaviour
{
	private bool field_inited = false;

	public int VibrationDurationLong = 1000;
	public int VibrationDurationMedium = 250;
	public int VibrationDurationShort = 100;

	private bool field_canVibrate = false;

	void Start ()
	{
		if (Vibration.HasVibrator())
		{
			field_canVibrate = true;
		}
	}

	void Update()
	{
		;
	}

	public void Init()
	{
		if (field_inited)
			return;

		field_inited = true;
	}

	public void VibrateLong()
	{
		Vibrate(VibrationDurationLong);
	}
	public void VibrateMedium()
	{
		Vibrate(VibrationDurationMedium);
	}
	public void VibrateShort()
	{
		Vibrate(VibrationDurationShort);
	}
	
	public void Vibrate(int param_duration)
	{
		if (!field_canVibrate)
			return;
		if (param_duration <= 1)
			return;
		if (param_duration > 1000)
			param_duration = 1000;

		if (field_canVibrate)
		{
			Vibration.Vibrate(param_duration);
		}
		//else
		//{
		//	Handheld.Vibrate();
		//}
	}
}
