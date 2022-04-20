using UnityEngine;
using UnityEditor;
using VRC.SDK3.Components;
using VRC.Udon;
using UdonSharp;
using UdonSharpEditor;

public partial class TanukiUdonWindow : EditorWindow
{
    void ShowCodeSnippets()
    {
        EditorGUILayout.Space(10f);
        EditorGUILayout.BeginVertical();

        /***************/
        /*   CyanEmu   */
        /***************/
        EditorGUILayout.LabelField("CyanEmu", headingGUIStyle);

        EditorGUILayout.BeginHorizontal();
        EditorGUILayout.Space(10f);
        EditorGUILayout.LabelField("    CyanEmu is a VRChat client emulator in Unity. Test your SDK2 and Udon worlds locally in Unity without uploading! Read the Github wiki for extra features.", paragraphGUIStyle);

        GUILayout.FlexibleSpace();
        
        if (GUILayout.Button(downloadBtnContent, downloadBtnStyle, GUILayout.Width(40), GUILayout.Height(40)))
        {
            Application.OpenURL("https://github.com/CyanLaser/CyanEmu");
        }
        EditorGUILayout.Space(10f);
        EditorGUILayout.EndHorizontal();
        EditorGUILayout.Space(15f);
    
        /*****************/
        /*   UdonSharp   */
        /*****************/
        EditorGUILayout.LabelField("UdonSharp", headingGUIStyle);

        EditorGUILayout.BeginHorizontal();
        EditorGUILayout.Space(10f);
        EditorGUILayout.LabelField("    An experimental compiler for compiling C# to Udon assembly", paragraphGUIStyle);
        
        GUILayout.FlexibleSpace();
        
        if (GUILayout.Button(downloadBtnContent, downloadBtnStyle, GUILayout.Width(40), GUILayout.Height(40)))
        {
            Application.OpenURL("https://github.com/MerlinVR/UdonSharp");
        }
        EditorGUILayout.Space(10f);
        EditorGUILayout.EndHorizontal();
        EditorGUILayout.Space(15f);
 
        /***************************/
        /*   Avatar 3.0 Emulator   */
        /***************************/
        EditorGUILayout.LabelField("Avatar 3.0 Emulator", headingGUIStyle);

        EditorGUILayout.BeginHorizontal();
        EditorGUILayout.Space(10f);
        EditorGUILayout.LabelField("    An emulator for Avatars 3.0 reimplemented in the unity editor on top of the unity PlayableGraph API, using the AnimationControllerPlayable and AnimationLayerMixerPlayable APIs.", paragraphGUIStyle);
        
        GUILayout.FlexibleSpace();
        
        if (GUILayout.Button(downloadBtnContent, downloadBtnStyle, GUILayout.Width(40), GUILayout.Height(40)))
        {
            Application.OpenURL("https://github.com/lyuma/Av3Emulator");
        }
        EditorGUILayout.Space(10f);
        EditorGUILayout.EndHorizontal();
        EditorGUILayout.Space(15f);

        /**********************/
        /*   VRWorldToolkit   */
        /**********************/
        EditorGUILayout.LabelField("VRWorld Toolkit", headingGUIStyle);

        EditorGUILayout.BeginHorizontal();
        EditorGUILayout.Space(10f);
        EditorGUILayout.LabelField("    A Unity Editor extension made to make making worlds for VRChat easier and overall lower the entry-level to make a good performing world.", paragraphGUIStyle);
        
        GUILayout.FlexibleSpace();
        
        if (GUILayout.Button(downloadBtnContent, downloadBtnStyle, GUILayout.Width(40), GUILayout.Height(40)))
        {
            Application.OpenURL("https://github.com/oneVR/VRWorldToolkit/releases");
        }
        EditorGUILayout.Space(10f);
        EditorGUILayout.EndHorizontal();
        EditorGUILayout.Space(15f);

        /***********************/
        /*   EasyQuestSwitch   */
        /***********************/
        EditorGUILayout.LabelField("EasyQuestSwitch", headingGUIStyle);

        EditorGUILayout.BeginHorizontal();
        EditorGUILayout.Space(10f);
        EditorGUILayout.LabelField("    A Unity Editor tool that automate changes in a scene whenever you change the project's build target.", paragraphGUIStyle);
        
        GUILayout.FlexibleSpace();
        
        if (GUILayout.Button(downloadBtnContent, downloadBtnStyle, GUILayout.Width(40), GUILayout.Height(40)))
        {
            Application.OpenURL("https://github.com/JordoVR/EasyQuestSwitch/releases");
        }
        EditorGUILayout.Space(10f);
        EditorGUILayout.EndHorizontal();
        EditorGUILayout.Space(15f);

        /*******************************/
        /*   World Creator Assistant   */
        /*******************************/
        EditorGUILayout.LabelField("World Creator Assistant", headingGUIStyle);

        EditorGUILayout.BeginHorizontal();
        EditorGUILayout.Space(10f);
        EditorGUILayout.BeginVertical();
        EditorGUILayout.LabelField("    A Unity Editor extension for automating VRChat world project package management", paragraphGUIStyle);
        EditorGUILayout.LabelField("- Project Setup Wizard that allows automated batch import of VRCSDK, UPM packages, GitHub repositories, downloaded UAS assets and automatic setup of VRC layers", paragraphGUIStyle);
        EditorGUILayout.LabelField("- Importer for keeping VRCSDK and GitHub repositories up to date", paragraphGUIStyle);
        EditorGUILayout.LabelField("- Resources containing useful links and world creation related FAQ section", paragraphGUIStyle);
        EditorGUILayout.EndVertical();

        GUILayout.FlexibleSpace();
        
        if (GUILayout.Button(downloadBtnContent, downloadBtnStyle, GUILayout.Width(40), GUILayout.Height(40)))
        {
            Application.OpenURL("https://github.com/Varneon/WorldCreatorAssistant");
        }
        EditorGUILayout.Space(10f);
        EditorGUILayout.EndHorizontal();
        EditorGUILayout.Space(15f);

        /*******************/
        /*   CyanTrigger   */
        /*******************/
        EditorGUILayout.LabelField("CyanTrigger", headingGUIStyle);

        EditorGUILayout.BeginHorizontal();
        EditorGUILayout.Space(10f);
        EditorGUILayout.LabelField("    A new way to write logic for SDK3 worlds in VRChat, with an interface that resembles VRChat’s SDK2 VRC_Trigger. CyanTrigger has full access to all of Udon and can work with UdonGraph and UdonSharp.", paragraphGUIStyle);
        
        GUILayout.FlexibleSpace();
        
        if (GUILayout.Button(downloadBtnContent, downloadBtnStyle, GUILayout.Width(40), GUILayout.Height(40)))
        {
            Application.OpenURL("https://cyanlaser.booth.pm/items/3194594");
        }
        EditorGUILayout.Space(10f);
        EditorGUILayout.EndHorizontal();
        EditorGUILayout.EndVertical();
    }

}