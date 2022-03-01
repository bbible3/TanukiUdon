using UnityEngine;
using UnityEditor;
using VRC.SDK3.Components;
using VRC.Udon;
using UdonSharp;
using UdonSharpEditor;

public class TanukiUdonWindow : EditorWindow
{
    // Display settings for Pickup Tools dropdown
    bool showPickupTools = true;
    bool pickupUsePhysics = true;
    string pickupString = "Action Text";
    string interactionString = "Hover Text";

    // Display settings for Teleporter Tools dropdown
    bool showTeleporterTools = true;
    GameObject sourceTeleporter;
    GameObject targetTeleporter;

    //Make the TanukiUdon window selection appear in Window toolbar tab
    [MenuItem("Window/TanukiUdon")]

    //Makes the UI actually work
    public static void ShowWindow()
    {
        GetWindow<TanukiUdonWindow>("TanukiUdon");
    }
    void OnGUI()
    {
        
        //Add a header
        GUILayout.Label("TanukiUdon v0.0.1", EditorStyles.boldLabel);

        GUILayout.Space(25f);
        GUIStyle style = EditorStyles.foldout;
        style.fontStyle = FontStyle.Bold;

        // Create the Pickup Tools dropdown group
        showPickupTools = EditorGUILayout.Foldout(showPickupTools, "Pickup Tools", style);
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

        // Create the Teleporter Tools dropdown group
        showTeleporterTools = EditorGUILayout.Foldout(showTeleporterTools, "Teleporter Tools", style);
        if (showTeleporterTools)
		{
            
            if (GUILayout.Button("Convert selected to Teleporter"))
			{
                foreach (GameObject obj in Selection.gameObjects)
				{
                    obj.AddUdonSharpComponent<Tanuki.TanukiTeleporter>();
				}
			}
        }
        sourceTeleporter = EditorGUILayout.ObjectField("Source Teleporter", sourceTeleporter, typeof(GameObject), true) as GameObject;
        targetTeleporter = EditorGUILayout.ObjectField("Target Teleporter", targetTeleporter, typeof(GameObject), true) as GameObject;
       
        if (GUILayout.Button("Make To-From Teleporter Loop"))
		{
            sourceTeleporter.AddUdonSharpComponent<Tanuki.TanukiTeleporter>();
            targetTeleporter.AddUdonSharpComponent<Tanuki.TanukiTeleporter>();

            sourceTeleporter.GetComponent<Tanuki.TanukiTeleporter>().lerpOnRemote = true;
            //st.lerpOnRemote = true;
            //st.teleportTo = targetTeleporter.transform;
            Debug.Log(sourceTeleporter);
            //sourceTeleporter<Tanuki.TanukiTeleporter>().teleportTo = targetTeleporter;
            //targetTeleporter.TanukiTeleporter.teleportTo = sourceTeleporter;
            Debug.Log("Should have made loop");
		}
    }
}
