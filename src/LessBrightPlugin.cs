using BepInEx;
using HarmonyLib;
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

        if (Compat.LethalConfig) LethalConfigIntegration.Initialize();

        _harmony.PatchAll(typeof(PlayerControllerBPatches));
    }
}
