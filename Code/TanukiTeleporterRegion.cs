
/* TanukiUdon Teleporter */
/* Based on JetDog Teleport_Event */

using UdonSharp;
using UnityEngine;
using VRC.SDKBase;
using VRC.Udon;

namespace Tanuki
{
    public class TanukiTeleporterRegion : UdonSharpBehaviour
    {
        public Transform teleportTo;
        public VRC_SceneDescriptor.SpawnOrientation teleportOrientation = VRC_SceneDescriptor.SpawnOrientation.AlignPlayerWithSpawnPoint;
        public bool lerpOnRemote = false;
        public virtual void OnPlayerTriggerEnter(VRC.SDKBase.VRCPlayerApi player)
		{
                Networking.LocalPlayer.TeleportTo(teleportTo.position, teleportTo.rotation, teleportOrientation, lerpOnRemote);
		}
    }
}