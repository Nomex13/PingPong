using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using System.Collections;

[CustomEditor(typeof(Transmitter))]
public class TransmitterEditor : Editor
{
	private SerializedProperty field_propertyReceivers;
	//private SerializedProperty field_propertyOmg;
	private Receiver field_receiverEmpty;

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
		field_propertyReceivers = serializedObject.FindProperty("Recievers");
		field_receiverEmpty = new Receiver();
		//field_propertyOmg = serializedObject.FindProperty("Omg");
	}

	public override void OnInspectorGUI()
	{
		//serializedObject.Update();

		//EditorGUIUtility.LookLikeInspector();

		field_propertyReceivers = serializedObject.FindProperty("Recievers");

		bool needMoreReceivers = false;

		List<Receiver> recievers = ((Transmitter)target).Receivers;
		if (Event.current.type == EventType.Repaint)
		{
			if (recievers.Count == 0 || recievers[recievers.Count - 1].GameObject != null)
			{
				Debug.Log("omg " + recievers.Count + " " + (recievers.Count > 0 ? recievers[recievers.Count - 1].GameObject.ToString() : ""));
				recievers.Add(new Receiver());
				//serializedObject.ApplyModifiedProperties();
			}
			else
			{
				Debug.Log(recievers[recievers.Count - 1].GameObject.ToString());
			}
			//if (field_propertyReceivers.arraySize == 0 || field_propertyReceivers.GetArrayElementAtIndex(field_propertyReceivers.arraySize - 1).FindPropertyRelative("GameObject").objectReferenceValue == null)
			//{
			//    //((Transmitter)target).Recievers.Add(new Reciever());
			//    //((Transmitter)target).Recievers.Add(1);
			//    //serializedObject.Update();
			//    field_propertyReceivers.arraySize++;
			//    field_propertyReceivers.GetArrayElementAtIndex(field_propertyReceivers.arraySize - 1).objectReferenceValue = null;
			//    //field_propertyReceivers.InsertArrayElementAtIndex(field_propertyReceivers.arraySize - 1);
			//    //field_propertyReceivers.serializedObject.ApplyModifiedProperties();
			//    //field_propertyReceivers.GetArrayElementAtIndex(field_propertyReceivers.arraySize - 1).objectReferenceValue = (object)(new Reciever());
			//}
		}
		//base.OnInspectorGUI();

		//EditorGUILayout.PropertyField(field_propertyOmg);
		//while (field_propertyReceivers.Next(true))
		//{
		//    EditorGUILayout.PropertyField(field_propertyReceivers);
		//}
		//if (field_propertyReceivers == null)
		//{
		//    GUILayout.Label("FUCKING NULL");
		//    GUILayout.Label(((Transmitter)target).Recievers.Count + " - FUCKING?!");
		//}

		//List<Reciever> recievers = ((Transmitter)target).Recievers;
		//for (int i = 0; i < recievers.Count; i++)
		//{

		//}

		GUILayout.Label(field_propertyReceivers.arraySize + " recievers");
		GUILayout.Label(recievers.Count + " actual recievers");

		for (int i = 0; i < field_propertyReceivers.arraySize; i++)
		{
			SerializedProperty reciever = field_propertyReceivers.GetArrayElementAtIndex(i);
			SerializedProperty recieverGameObject = reciever.FindPropertyRelative("GameObject");
			SerializedProperty recieverMethod = reciever.FindPropertyRelative("Method");
			SerializedProperty recieverParameter = reciever.FindPropertyRelative("Parameter");

			if (recieverGameObject.objectReferenceValue == null && i != field_propertyReceivers.arraySize - 1)
			{
				int oldSize = field_propertyReceivers.arraySize;
				field_propertyReceivers.DeleteArrayElementAtIndex(i);
				if (oldSize == field_propertyReceivers.arraySize)
				{
					field_propertyReceivers.DeleteArrayElementAtIndex(i);
				}
				i--;
				continue;
			}
			//if (recieverGameObject.objectReferenceValue != null && i == field_propertyReceivers.arraySize - 1)
			//{
			//    needMoreRecivers = true;
			//}
			//if (recieverGameObject.objectReferenceValue != null && i == field_propertyReceivers.arraySize - 1)
			//{
			//    //((Transmitter)target).Recievers.Add(new Reciever());
			//    field_propertyReceivers.InsertArrayElementAtIndex(field_propertyReceivers.arraySize);
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
