using UnityEditor;
using UnityEngine;
using System.Collections;

//[CustomEditor(typeof(Reciever))]
//public class RecieverEditor : Editor
//{
//    private SerializedProperty field_propertyGameObject;
//    private SerializedProperty field_propertyMethod;
//    private SerializedProperty field_propertyParameter;

//    // Use this for initialization
//    void Start ()
//    {
	
//    }
	
//    // Update is called once per frame
//    void Update ()
//    {
	
//    }

//    void OnEnable()
//    {
//        field_propertyGameObject = serializedObject.FindProperty("GameObject");
//        field_propertyMethod = serializedObject.FindProperty("Method");
//        field_propertyParameter = serializedObject.FindProperty("Parameter");
//    }

//    public override void OnInspectorGUI()
//    {
//        //base.OnInspectorGUI();

//        EditorGUILayout.PropertyField(field_propertyGameObject);
//        if (field_propertyGameObject.objectReferenceValue != null)
//        {
//            EditorGUILayout.PropertyField(field_propertyMethod);
//        }
//        if (field_propertyMethod.stringValue != "")
//        {
//            EditorGUILayout.PropertyField(field_propertyParameter);
//        }
//    }
//}
