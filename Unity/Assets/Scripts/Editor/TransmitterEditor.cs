using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using System.Collections;

[CustomEditor(typeof(Transmitter))]
public class TransmitterEditor : Editor
{
	private SerializedProperty field_propertyRecievers;
	//private SerializedProperty field_propertyOmg;
	private Reciever field_recieverEmpty;

	// Use this for initialization
	void Start ()
	{
	
	}
	
	// Update is called once per frame
	void Update ()
	{
		
	}

	void OnEnable()
	{
		field_propertyRecievers = serializedObject.FindProperty("Recievers");
		field_recieverEmpty = new Reciever();
		//field_propertyOmg = serializedObject.FindProperty("Omg");
	}

	public override void OnInspectorGUI()
	{
		//serializedObject.Update();

		//EditorGUIUtility.LookLikeInspector();

		field_propertyRecievers = serializedObject.FindProperty("Recievers");

		bool needMoreRecivers = false;

		List<Reciever> recievers = ((Transmitter)target).Recievers;
		if (Event.current.type == EventType.Repaint)
		{
			if (recievers.Count == 0 || recievers[recievers.Count - 1].GameObject != null)
			{
				Debug.Log("omg " + recievers.Count + " " + (recievers.Count > 0 ? recievers[recievers.Count - 1].GameObject.ToString() : ""));
				recievers.Add(new Reciever());
				//serializedObject.ApplyModifiedProperties();
			}
			else
			{
				Debug.Log(recievers[recievers.Count - 1].GameObject.ToString());
			}
			//if (field_propertyRecievers.arraySize == 0 || field_propertyRecievers.GetArrayElementAtIndex(field_propertyRecievers.arraySize - 1).FindPropertyRelative("GameObject").objectReferenceValue == null)
			//{
			//    //((Transmitter)target).Recievers.Add(new Reciever());
			//    //((Transmitter)target).Recievers.Add(1);
			//    //serializedObject.Update();
			//    field_propertyRecievers.arraySize++;
			//    field_propertyRecievers.GetArrayElementAtIndex(field_propertyRecievers.arraySize - 1).objectReferenceValue = null;
			//    //field_propertyRecievers.InsertArrayElementAtIndex(field_propertyRecievers.arraySize - 1);
			//    //field_propertyRecievers.serializedObject.ApplyModifiedProperties();
			//    //field_propertyRecievers.GetArrayElementAtIndex(field_propertyRecievers.arraySize - 1).objectReferenceValue = (object)(new Reciever());
			//}
		}
		//base.OnInspectorGUI();

		//EditorGUILayout.PropertyField(field_propertyOmg);
		//while (field_propertyRecievers.Next(true))
		//{
		//    EditorGUILayout.PropertyField(field_propertyRecievers);
		//}
		//if (field_propertyRecievers == null)
		//{
		//    GUILayout.Label("FUCKING NULL");
		//    GUILayout.Label(((Transmitter)target).Recievers.Count + " - FUCKING?!");
		//}

		//List<Reciever> recievers = ((Transmitter)target).Recievers;
		//for (int i = 0; i < recievers.Count; i++)
		//{

		//}

		GUILayout.Label(field_propertyRecievers.arraySize + " recievers");
		GUILayout.Label(recievers.Count + " actual recievers");

		for (int i = 0; i < field_propertyRecievers.arraySize; i++)
		{
			SerializedProperty reciever = field_propertyRecievers.GetArrayElementAtIndex(i);
			SerializedProperty recieverGameObject = reciever.FindPropertyRelative("GameObject");
			SerializedProperty recieverMethod = reciever.FindPropertyRelative("Method");
			SerializedProperty recieverParameter = reciever.FindPropertyRelative("Parameter");

			if (recieverGameObject.objectReferenceValue == null && i != field_propertyRecievers.arraySize - 1)
			{
				int oldSize = field_propertyRecievers.arraySize;
				field_propertyRecievers.DeleteArrayElementAtIndex(i);
				if (oldSize == field_propertyRecievers.arraySize)
				{
					field_propertyRecievers.DeleteArrayElementAtIndex(i);
				}
				i--;
				continue;
			}
			//if (recieverGameObject.objectReferenceValue != null && i == field_propertyRecievers.arraySize - 1)
			//{
			//    needMoreRecivers = true;
			//}
			//if (recieverGameObject.objectReferenceValue != null && i == field_propertyRecievers.arraySize - 1)
			//{
			//    //((Transmitter)target).Recievers.Add(new Reciever());
			//    field_propertyRecievers.InsertArrayElementAtIndex(field_propertyRecievers.arraySize);
			//}

			//reciever;
			//if (recieverGameObject == null)
				//EditorGUILayout.PropertyField(reciever);
			//if (recieverGameObject != null)
			EditorGUILayout.PropertyField(recieverGameObject);
			if (recieverGameObject.objectReferenceValue != null)
				EditorGUILayout.PropertyField(recieverMethod, true);
			if (recieverMethod.stringValue != "")
				EditorGUILayout.PropertyField(recieverParameter, true);
			EditorGUILayout.Space();
		}
		//if (GUILayout.Button("+", EditorStyles.miniButton))
	}
}
