using BepInEx.Bootstrap;
using LessBright.Utils;
using UnityEngine.InputSystem;

namespace LessBright.Integrations;

internal static class Compat
{
    public static bool LethalConfig => Chainloader.PluginInfos.ContainsKey(Metadata.Dependencies.LethalConfig);
    private static bool InputUtils => Chainloader.PluginInfos.ContainsKey(Metadata.Dependencies.InputUtils);

    private static InputAction NightVisionToggleKey => InputUtilsIntegration.Instance.NightVisionToggleKey;

    public static bool ThirdPartyToggleTriggered { get; set; }

    public static bool IsToggleNightVisionTriggered()
    {
        if (!ThirdPartyToggleTriggered)
            return InputUtils ? NightVisionToggleKey.triggered : Keyboard.current[Key.F].wasPressedThisFrame;

        ThirdPartyToggleTriggered = false;
        return true;
    }
}
