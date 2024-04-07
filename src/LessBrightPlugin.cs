using BepInEx;
using BepInEx.Bootstrap;
using HarmonyLib;
using LessBright.Behaviors;
using LessBright.Integrations;
using LessBright.Patches;
using LessBright.Utils;

namespace LessBright;

[BepInPlugin(Metadata.PluginGuid, Metadata.PluginName, Metadata.PluginVersion)]
[BepInDependency(Metadata.Dependencies.LethalConfig, BepInDependency.DependencyFlags.SoftDependency)]
[BepInDependency(Metadata.Dependencies.InputUtils, BepInDependency.DependencyFlags.SoftDependency)]
public class LessBrightPlugin : BaseUnityPlugin
{
    private readonly Harmony _harmony = new(Metadata.PluginGuid);

    private void Awake()
    {
        LessBright.Config = Config;
        LessBright.PlayerState = gameObject.AddComponent<PlayerState>();

        if (Chainloader.PluginInfos.ContainsKey(Metadata.Dependencies.LethalConfig))
            LethalConfigIntegration.Initialize();

        _harmony.PatchAll(typeof(PlayerControllerBPatches));
        _harmony.PatchAll(typeof(TimeOfDayPatches));
    }
}
