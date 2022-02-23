using UnityEngine;
using UnityEditor;
using VRC.SDK3.Components;
using VRC.Udon;
using UdonSharp;
using UdonSharpEditor;

public class TanukiUdonWindow : EditorWindow
{
    //Display settings for Pickup Tools dropdown
    bool showPickupTools = true;
    string statusPickupTools = "Pickup Tools";
    bool pickupUsePhysics = true;
    string pickupString = "Pick Up";

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


        //Create the first dropdown group
        showPickupTools = EditorGUILayout.Foldout(showPickupTools, statusPickupTools);
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
            pickupString = EditorGUILayout.TextField(pickupString, EditorStyles.textField);
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

                }
            }

            GUILayout.Space(25f);

            if (GUILayout.Button("Convert selected to Teleporter"))
			{
                foreach (GameObject obj in Selection.gameObjects)
				{

                    obj.AddUdonSharpComponent<Tanuki.TanukiTeleporter>();
				}
			}
        }
    }
}
