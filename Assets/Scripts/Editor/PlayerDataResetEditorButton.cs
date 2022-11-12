using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(PlayerData))]
public class PlayerDataResetEditorButton : Editor
{
    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();
        var  myScript = (PlayerData)target;
        if (GUILayout.Button("Reset"))
        {
            myScript.Reset();
        }
        if (GUILayout.Button("Buff Mode"))
        {
            myScript.Money = 1000000;
            myScript.SiteUsers = 1000000;
            myScript.DataMB = 1000000;
            myScript.Reputation = 1000000;
            myScript.SiteUsersPerSecond = 100;
            myScript.DataMBPerSecond = 100;
        }
        
    }
}