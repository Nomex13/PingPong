using UnityEngine;
using System.Collections;

public class Hud : MonoBehaviour
{
	void Start()
	{
		;
	}
	
	void Update()
	{
		;
	}

	public virtual void Show()
	{
		NGUITools.SetActive(gameObject, true);
		//gameObject.SetActive(true);
	}
	public virtual void Hide()
	{
		NGUITools.SetActive(gameObject, false);
		//gameObject.SetActive(false);
	}
}
