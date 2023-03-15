using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(ActiveEntity))]
public class ActiveEntityEditor : Editor
{
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();

        ActiveEntity entity = (ActiveEntity)target;

        if (GUILayout.Button("Update List"))
            UpdateList(entity);
    }

    private void UpdateList(ActiveEntity entity)
    {
        entity.UpdateBehavioursList();
    }
}
