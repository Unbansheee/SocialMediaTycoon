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
        if (GUILayout.Button("Generate From Seed"))
        {
            myScript.GenerateAvatar();
        }
        
        if (GUILayout.Button("Generate Random Avatar"))
        {
            myScript.Seed = Random.Range(0, 1000000);
            myScript.GenerateAvatar();
        }
    }
}
