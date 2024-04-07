using BepInEx.Configuration;
using GameNetcodeStuff;
using LessBright.Behaviors;

namespace LessBright;

internal static class LessBright
{
    public static ConfigFile Config { get; internal set; } = null!;
    public static PlayerState PlayerState { get; internal set; } = null!;
    public static PlayerControllerB PlayerController => GameNetworkManager.Instance.localPlayerController;
}
