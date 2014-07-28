using System;
using UnityEngine;
using System.Collections;

public static class Util
{
	public static IEnumerator WaitForRealSeconds(float param_secondsToWait)
	{
		long ticksAtStart = DateTime.Now.Ticks;
		long ticksToWait = Convert.ToInt64(param_secondsToWait * 10000000);
		long ticksAtEnd = ticksAtStart + ticksToWait;
		while (ticksAtEnd > DateTime.Now.Ticks)
		{
			yield return null;
		}
	}
}

public enum DirectionEnum
{
	HORIZONTAL,
	VERTICAL
}

public enum NGUIMouseTouchId : int
{
	LEFT = -1,
	RIGHT = -2,
	MIDDLE = -3
}