
/* TanukiUdon Teleporter */
/* Based on JetDog Teleport_Event */

using UdonSharp;
using UnityEngine;
using VRC.SDKBase;
using VRC.Udon;

namespace Tanuki
{
    public class TanukiTeleporter : UdonSharpBehaviour
    {
        public Transform teleportTo;
        public VRC_SceneDescriptor.SpawnOrientation teleportOrientation = VRC_SceneDescriptor.SpawnOrientation.AlignPlayerWithSpawnPoint;
        public bool lerpOnRemote = false;
        public override void Interact()
		{
                Networking.LocalPlayer.TeleportTo(teleportTo.position, teleportTo.rotation, teleportOrientation, lerpOnRemote);
		}
    }
}