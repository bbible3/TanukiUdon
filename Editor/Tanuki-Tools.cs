using UnityEngine;
using UnityEditor;
using VRC.SDK3.Components;
using VRC.Udon;
using UdonSharp;
using UdonSharpEditor;

public partial class TanukiUdonWindow : EditorWindow
{
    // Display settings for Pickup Tools dropdown
    bool showPickupTools = true;
    bool pickupUsePhysics = true;
    string pickupString = "Action Text";
    string interactionString = "Hover Text";

    string useTeleporterString = "Use";

    // Display settings for Teleporter Tools dropdown
    bool showTeleporterTools = true;
    GameObject sourceGO, targetGO;

    string teleporterMode = "Interact Teleporter";

    int _t_selected = 0;
    string[] _t_options = new string[2] { "Interact Teleporter", "Region Teleporter" };
    
    int _goal_selected = 0;
    string[] _goals = new string[2] {"Mass Convert", "Teleporter Loop"};

    void makeTeleporterLoop(GameObject sourceGO, GameObject targetGO, string teleporterMode) 
    {
        // This could be cleaner if the teleporter was in only one file and just
        // had an argument that could be passed to change between region and interact
        // but i figuure we could change that in a future issue
        if (teleporterMode == "Interact Teleporter")
        {
            // Add and apply teleporter
            sourceGO.AddUdonSharpComponent<Tanuki.TanukiTeleporter>();
            Tanuki.TanukiTeleporter sourceTele = sourceGO.GetUdonSharpComponent<Tanuki.TanukiTeleporter>();
            //sourceTele.UpdateProxy();
            sourceTele.teleportTo = targetGO.transform;
            sourceTele.ApplyProxyModifications();

            // Change InteractionText
            UdonBehaviour objBeh = sourceTele.GetComponent<UdonBehaviour>();
            objBeh.InteractionText = useTeleporterString;

            targetGO.AddUdonSharpComponent<Tanuki.TanukiTeleporter>();
            Tanuki.TanukiTeleporter targetTele = targetGO.GetUdonSharpComponent<Tanuki.TanukiTeleporter>();
            targetTele.teleportTo = sourceGO.transform;
            targetTele.ApplyProxyModifications();

            UdonBehaviour objBeh2 = targetTele.GetComponent<UdonBehaviour>();
            objBeh2.InteractionText = useTeleporterString;
            EditorUtility.DisplayDialog("Converted to teleporter pair", "Successfully converted to Interact Teleporter pair.", "Arigato!");
        }
        else if (teleporterMode == "Region Teleporter")
        {
            Debug.Log("Generating Region Teleporter");
            // Add and apply teleporter
            sourceGO.AddUdonSharpComponent<Tanuki.TanukiTeleporterRegion>();
            Tanuki.TanukiTeleporterRegion sourceTele = sourceGO.GetUdonSharpComponent<Tanuki.TanukiTeleporterRegion>();
            //sourceTele.UpdateProxy();
            sourceTele.teleportTo = targetGO.transform;
            sourceTele.ApplyProxyModifications();

            targetGO.AddUdonSharpComponent<Tanuki.TanukiTeleporterRegion>();
            Tanuki.TanukiTeleporterRegion targetTele = targetGO.GetUdonSharpComponent<Tanuki.TanukiTeleporterRegion>();
            targetTele.teleportTo = sourceGO.transform;
            targetTele.ApplyProxyModifications();
            EditorUtility.DisplayDialog("Converted to teleporter pair", "Successfully converted to Region Teleporter pair. Please note that this will likely lead to an infinite teleporter loop, this functionality should probably be avoided.", "Got it!");

            sourceGO.GetComponent<BoxCollider>().isTrigger = true;
            targetGO.GetComponent<BoxCollider>().isTrigger = true;

        }
    }
    
	void ShowTools()
	{
        EditorGUILayout.BeginVertical(boxGUIStyle);

        /***********************/
        /*    PICKUP TOOLS     */
        /***********************/
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
                int countMakePickup = 0;
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
                    countMakePickup++;
                }
                EditorUtility.DisplayDialog("Converted to pickup", "Successfully converted " + countMakePickup + " items to pickups.", "Arigato!");
            }
        }
        EditorGUILayout.EndVertical();
        GUILayout.Space(15f);

        EditorGUILayout.BeginVertical(boxGUIStyle);

        /***************************/
        /*    TELEPORTER TOOLS     */
        /***************************/
        showTeleporterTools = EditorGUILayout.Foldout(showTeleporterTools, "Teleporter Tools");
        if (showTeleporterTools)
		{
            // Goal is pretty vague, totally open to it being changed, but this dropdown's 
            // purpose enables us to show/hide elements based on what user wants i.e not showing
            // interaction text when using region teleporters. Plus we can add new modes later too
            _goal_selected = EditorGUILayout.Popup("What's Your Goal?", _goal_selected, _goals);
            
            // A dropdown to choose between area or interact-based teleporters
            EditorGUI.BeginChangeCheck();
            _t_selected = EditorGUILayout.Popup("Teleporter Mode", _t_selected, _t_options);
            if (EditorGUI.EndChangeCheck())
            {
                teleporterMode = _t_options[_t_selected];
            }
            if (teleporterMode == "Interact Teleporter") {
                useTeleporterString = EditorGUILayout.TextField("Interaction Text", useTeleporterString);
            }

            // Goal is Mass Conversion
            if (_goal_selected == 0)
            {
                EditorGUILayout.BeginHorizontal();
                if (GUILayout.Button("Convert selected to Teleporter"))
                {
                    int countMakeTeleporter = 0;
                    foreach (GameObject obj in Selection.gameObjects)
                    {
                        if (teleporterMode == "Interact Teleporter")
                        {
                            obj.AddUdonSharpComponent<Tanuki.TanukiTeleporter>();
                        }
                        else if (teleporterMode == "Region Teleporter")
                        {
                            obj.AddUdonSharpComponent<Tanuki.TanukiTeleporterRegion>();
                            obj.GetComponent<BoxCollider>().isTrigger = true;
                        }
                        //To change InteractionText, we must get the UdonBehaviour component
                        UdonBehaviour objBeh = obj.GetComponent<UdonBehaviour>();
                        objBeh.InteractionText = useTeleporterString;
                        countMakeTeleporter++;
                    }
                    EditorUtility.DisplayDialog("Converted to teleporter", "Successfully converted " + countMakeTeleporter + " items into " + teleporterMode + ". You must assign their destination manually.", "Arigato!");

                }
                if (GUILayout.Button("Convert selected to Non-Teleporter"))
                {
                    int countRemoveTeleporter = 0;
                    foreach (GameObject obj in Selection.gameObjects)
                    {
                        try
                        {
                            UdonSharpEditorUtility.DestroyImmediate(obj.GetUdonSharpComponent<Tanuki.TanukiTeleporter>());
                        }
                        catch
                        {
                            Debug.Log("Failed to find TanukiTeleporter");
                        }
                        try
                        {
                            UdonSharpEditorUtility.DestroyImmediate(obj.GetUdonSharpComponent<Tanuki.TanukiTeleporterRegion>());

                        }
                        catch
                        {
                            Debug.Log("Failed to find TanukiTeleporterRegion");
                        }

                        countRemoveTeleporter++;

                    }
                    EditorUtility.DisplayDialog("Removed teleporter", "Successfully removed " + countRemoveTeleporter + " teleporters.", "Arigato!");

                }
                EditorGUILayout.EndHorizontal();
            }
            // Goal is Teleporter Loop
            else if (_goal_selected == 1)
            {
                sourceGO = EditorGUILayout.ObjectField("Source Teleporter", sourceGO, typeof(GameObject), true) as GameObject;
                targetGO = EditorGUILayout.ObjectField("Target Teleporter", targetGO, typeof(GameObject), true) as GameObject;
                if (GUILayout.Button("Make To-From Teleporter Loop"))
                {
                    makeTeleporterLoop(sourceGO, targetGO, teleporterMode);
                }
            }
        }


        EditorGUILayout.EndVertical();
    }
}
