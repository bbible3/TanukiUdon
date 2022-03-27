using UnityEngine;
using UnityEditor;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VRC.SDK3.Components;
using VRC.Udon;
using UdonSharp;
using UdonSharpEditor;

public partial class TanukiUdonWindow : EditorWindow
{
	void ShowPickupEditor()
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
}
