using GameNetcodeStuff;
using Unity.Netcode;

namespace LessBright.Utils;

internal static class Checks
{
    internal static bool IsLocalPlayer(PlayerControllerB controller)
    {
        return NetworkManager.Singleton.LocalClientId == controller.playerClientId;
    }

    internal static bool IsNotLocalPlayer(PlayerControllerB controller)
    {
        return !IsLocalPlayer(controller);
    }
}
