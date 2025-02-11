using System.Reflection;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(ActiveEntity))]
public class ActiveEntityDrawer : Editor
{
    public override void OnInspectorGUI()
    {
        serializedObject.Update();

        SerializedProperty rangedStates = serializedObject.FindProperty("_rangedStates");

        EditorGUILayout.LabelField("Behavior", EditorStyles.boldLabel);

        ActiveEntity entity = (ActiveEntity)target;
        for (int i = 0; i < rangedStates.arraySize; i++)
        {
            SerializedProperty element = rangedStates.GetArrayElementAtIndex(i);

            RangedState rangedState = entity.rangeStates[i];

            EditorGUILayout.PropertyField(element, new GUIContent(rangedState.GenerateName()), true);
        }

        if (GUILayout.Button("Add Behavior"))
        {
            rangedStates.arraySize++;
        }

        if (GUILayout.Button("Remove Behavior"))
        {
            rangedStates.arraySize--;
        }

        EditorGUILayout.Space(); 

        EditorGUILayout.LabelField("Info", EditorStyles.boldLabel);
        DrawPropertiesExcluding(serializedObject, "_rangedStates", "m_Script");

        serializedObject.ApplyModifiedProperties();
    }
}
