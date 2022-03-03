using UnityEngine;
using UnityEditor;
using VRC.SDK3.Components;
using VRC.Udon;
using UdonSharp;
using UdonSharpEditor;

public class TanukiUdonWindow : EditorWindow
{
    public static TanukiUdonWindow window;
    //Make the TanukiUdon window selection appear in Window toolbar tab
    [MenuItem("Window/TanukiUdon")]

    //Makes the UI actually work
    public static void ShowWindow()
    {
        window = (TanukiUdonWindow)EditorWindow.GetWindow<TanukiUdonWindow>("TanukiUdon");
        window.InitializeStyles();
    }
    
    public static GUIStyle titleGUIStyle;
    public static GUIStyle boxGUIStyle;
    static Texture _TanukiLogo;

    // Display settings for Pickup Tools dropdown
    bool showPickupTools = true;
    bool pickupUsePhysics = true;
    string pickupString = "Action Text";
    string interactionString = "Hover Text";

    // Display settings for Teleporter Tools dropdown
    bool showTeleporterTools = true;
    GameObject sourceGO, targetGO;

    void InitializeStyles()
    {
        titleGUIStyle = new GUIStyle();
        titleGUIStyle.fontSize = 32;
        titleGUIStyle.fontStyle = FontStyle.BoldAndItalic;
        titleGUIStyle.alignment = TextAnchor.MiddleCenter;
        titleGUIStyle.wordWrap = true;
        if (EditorGUIUtility.isProSkin)
            titleGUIStyle.normal.textColor = Color.white;
        else
            titleGUIStyle.normal.textColor = Color.black;
        
        boxGUIStyle = new GUIStyle();
        //boxGUIStyle = EditorStyles.foldout;
        if (EditorGUIUtility.isProSkin)
        {
            boxGUIStyle.normal.background = CreateBackgroundColorImage(new Color(0.3f, 0.3f, 0.3f));
            boxGUIStyle.normal.textColor = Color.white;
        }
        else
        {
            boxGUIStyle.normal.background = CreateBackgroundColorImage(new Color(0.85f, 0.85f, 0.85f));
            boxGUIStyle.normal.textColor = Color.black;
        }
        
    }

    void OnGUI()
    {
        if (window == null)
        {
            window = (TanukiUdonWindow)EditorWindow.GetWindow(typeof(TanukiUdonWindow));
            InitializeStyles();
        }
        // Load Logo
        if (_TanukiLogo == null)
            _TanukiLogo = Resources.Load<Texture2D>("TanukiLogo");

        // Display Logo and Header text
        GUILayout.BeginHorizontal();
        GUILayout.BeginVertical();
        GUI.DrawTexture(new Rect(10, 0, 80, 80), _TanukiLogo);

        EditorGUILayout.Space(30f);
        EditorGUILayout.LabelField("TanukiUdon", titleGUIStyle);

        GUILayout.EndVertical();
        GUILayout.EndHorizontal();

        EditorGUILayout.Space(20f);

        EditorGUILayout.BeginVertical(boxGUIStyle);
        // Create the Pickup Tools dropdown group
        showPickupTools = EditorGUILayout.Foldout(showPickupTools, "Pickup Tools");
        if (showPickupTools)
		{
            //Add VRC Pickup and ObjectSync
            GUILayout.Label("Convert selected GameObject(s) to synced VRCPickups", EditorStyles.label);
            //Make toggle and let it update
            if (pickupUsePhysics = GUILayout.Toggle(pickupUsePhysics, "Use physics", EditorStyles.toggle))
			{
               
                //If we need to do anything else here

			}
            //Make textfield and let it update
            pickupString = EditorGUILayout.TextField("Use Text", pickupString);
            interactionString = EditorGUILayout.TextField("Interaction Text", interactionString);
            if (GUILayout.Button("Convert selected to Pickup"))
            {
                Debug.Log("Converting to pickup...");
                //For all selected gameobjects
                foreach (GameObject obj in Selection.gameObjects)
                {
                    //Set components as necessary
                    VRCPickup pickup = obj.AddComponent<VRCPickup>() as VRCPickup;
                    VRCObjectSync objectSync = obj.AddComponent<VRCObjectSync>() as VRCObjectSync;
                    Rigidbody rigidbody = obj.GetComponent<Rigidbody>();
                    rigidbody.useGravity = pickupUsePhysics;
                    rigidbody.isKinematic = !pickupUsePhysics;
                    pickup.UseText = pickupString;
                    pickup.InteractionText = interactionString;

                }
            }    
        }
        EditorGUILayout.EndVertical();
        GUILayout.Space(15f);

        EditorGUILayout.BeginVertical(boxGUIStyle);

        // Create the Teleporter Tools dropdown group
        showTeleporterTools = EditorGUILayout.Foldout(showTeleporterTools, "Teleporter Tools");
        if (showTeleporterTools)
		{
            
            if (GUILayout.Button("Convert selected to Teleporter"))
			{
                foreach (GameObject obj in Selection.gameObjects)
				{
                    obj.AddUdonSharpComponent<Tanuki.TanukiTeleporter>();
				}
			}
            if (GUILayout.Button("Convert selected to Non-Teleporter"))
			{
                foreach (GameObject obj in Selection.gameObjects)
				{
                    UdonSharpEditorUtility.DestroyImmediate(obj.GetUdonSharpComponent<Tanuki.TanukiTeleporter>());
				}
			}
            sourceGO = EditorGUILayout.ObjectField("Source Teleporter", sourceGO, typeof(GameObject), true) as GameObject;
            targetGO = EditorGUILayout.ObjectField("Target Teleporter", targetGO, typeof(GameObject), true) as GameObject;
            if (GUILayout.Button("Make To-From Teleporter Loop"))
            {
                sourceGO.AddUdonSharpComponent<Tanuki.TanukiTeleporter>();
                Tanuki.TanukiTeleporter sourceTele = sourceGO.GetUdonSharpComponent<Tanuki.TanukiTeleporter>();
                //sourceTele.UpdateProxy();
                sourceTele.teleportTo = targetGO.transform;
                sourceTele.ApplyProxyModifications();
                
                targetGO.AddUdonSharpComponent<Tanuki.TanukiTeleporter>();
                Tanuki.TanukiTeleporter targetTele = targetGO.GetUdonSharpComponent<Tanuki.TanukiTeleporter>();
                targetTele.teleportTo = sourceGO.transform;
                targetTele.ApplyProxyModifications();
            }
        }
        EditorGUILayout.EndVertical();
        
        //Add a footer
        GUILayout.FlexibleSpace();
        GUILayout.Label("TanukiUdon v0.0.2", EditorStyles.boldLabel);
    }
    Texture2D CreateBackgroundColorImage(UnityEngine.Color color)
    {
        int w = 4, h = 4;
        Texture2D back = new Texture2D(w, h);
        UnityEngine.Color[] buffer = new UnityEngine.Color[w * h];
        for (int i = 0; i < w; ++i)
            for (int j = 0; j < h; ++j)
                buffer[i + w * j] = color;
        back.SetPixels(buffer);
        back.Apply(false);
        return back;
    }
}
