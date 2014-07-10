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
		gameObject.SetActive(true);
	}
	public virtual void Hide()
	{
		gameObject.SetActive(false);
	}
}
