using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(NFTGenerator))]
public class NFTGeneratorEditorButtons : Editor
{
    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();
        NFTGenerator myScript = (NFTGenerator)target;
        if (GUILayout.Button("Generate Avatar"))
        {
            myScript.GenerateAvatar();
        }
    }
}
