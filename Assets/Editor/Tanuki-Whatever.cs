using UnityEngine;
using UnityEditor;
using VRC.SDK3.Components;
using VRC.Udon;
using UdonSharp;
using UdonSharpEditor;

public partial class TanukiUdonWindow : EditorWindow
{
    // I honestly cannot remember what the third thing it what that you
    // wanted so whatever is what you get
    void ShowWhatever()
    {
        EditorGUILayout.BeginVertical();

        GUILayout.Label("Insert Whatever Here");

        EditorGUILayout.EndVertical();
    }

}