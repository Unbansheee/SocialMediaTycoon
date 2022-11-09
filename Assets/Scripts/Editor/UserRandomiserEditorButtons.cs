using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(User))]
public class UserRandomiserEditorButtons : Editor
{
    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();

        User script = (User)target;
        if (GUILayout.Button("Randomize"))
        {
            
            script.GenerateUser();
        }
    }
}
