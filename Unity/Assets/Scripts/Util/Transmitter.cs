using System.Collections.Generic;
using UnityEngine;
using System.Collections;

[ExecuteInEditMode]
//[System.Serializable]
public class Transmitter : MonoBehaviour
{
	//public Reciever[] Recievers = new Reciever[3];
	//public int Omg;

	[SerializeField]
	public List<Reciever> Recievers = new List<Reciever>();

	// Use this for initialization
	void Start ()
	{
		//Recievers.Add(new Reciever());
		//Recievers.Add(null);
		//Recievers[0] = (new Reciever());
		//Recievers[1] = (null);
	}
	
	// Update is called once per frame
	void Update ()
	{
		
	}

	void OnEnable()
	{
		//Recievers = new List<Reciever>();
		//Recievers.Add(new Reciever());
		//Recievers.Add(null);
	}
}