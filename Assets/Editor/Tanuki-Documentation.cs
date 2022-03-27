using UnityEngine;
using UnityEditor;
using VRC.SDK3.Components;
using VRC.Udon;
using UdonSharp;
using UdonSharpEditor;

public partial class TanukiUdonWindow : EditorWindow
{
    void ShowDocumentation()
    {
        EditorGUILayout.BeginVertical();

        GUILayout.Label("Insert Documentation Here");

        EditorGUILayout.EndVertical();
    }

}