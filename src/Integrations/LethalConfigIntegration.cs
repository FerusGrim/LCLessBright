using BepInEx.Configuration;
using LessBright.Utils;
using LethalConfig.ConfigItems;
using LethalConfig.ConfigItems.Options;
using static LethalConfig.LethalConfigManager;

namespace LessBright.Integrations;

internal static class LethalConfigIntegration
{
    public static void Initialize()
    {
        RegistryButtonEntry("Actions", "Toggle Light", "Manually toggle the light", () => { Compat.ThirdPartyToggleTriggered = true; });

        RegisterFloatEntry(Configs.Intensity!.Entry, Configs.Min.Intensity, Configs.Max.Intensity,
            Configs.Step.Intensity);
        RegisterFloatEntry(Configs.SpotAngle!.Entry, Configs.Min.SpotAngle, Configs.Max.SpotAngle,
            Configs.Step.SpotAngle);
        RegisterFloatEntry(Configs.InnerSpotAngle!.Entry, Configs.Min.InnerSpotAngle, Configs.Max.InnerSpotAngle,
            Configs.Step.InnerSpotAngle);
        RegisterFloatEntry(Configs.BounceIntensity!.Entry, Configs.Min.BounceIntensity, Configs.Max.BounceIntensity,
            Configs.Step.BounceIntensity);
        RegisterEnumEntry(Configs.ShadowType!.Entry);
        RegisterFloatEntry(Configs.ShadowStrength!.Entry, Configs.Min.ShadowStrength, Configs.Max.ShadowStrength,
            Configs.Step.ShadowStrength);
        RegisterEnumEntry(Configs.Color!.Entry);
        RegisterFloatEntry(Configs.OffsetX!.Entry, Configs.Min.OffsetX, Configs.Max.OffsetX, Configs.Step.OffsetX);
        RegisterFloatEntry(Configs.OffsetY!.Entry, Configs.Min.OffsetY, Configs.Max.OffsetY, Configs.Step.OffsetY);
        RegisterFloatEntry(Configs.OffsetZ!.Entry, Configs.Min.OffsetZ, Configs.Max.OffsetZ, Configs.Step.OffsetZ);
    }

    private static void RegistryButtonEntry(string section, string name, string description,
        GenericButtonOptions.GenericButtonHandler handler)
    {
        AddConfigItem(new GenericButtonConfigItem(section, name, description, name, handler));
    }

    private static void RegisterFloatEntry(ConfigEntry<float> entry, float min, float max, float step)
    {
        AddConfigItem(new FloatStepSliderConfigItem(entry, new FloatStepSliderOptions
        {
            RequiresRestart = false,
            Min = min,
            Max = max,
            Step = step
        }));
    }

    private static void RegisterEnumEntry<T>(ConfigEntry<T> entry) where T : Enum
    {
        AddConfigItem(new EnumDropDownConfigItem<T>(entry, new EnumDropDownOptions
        {
            RequiresRestart = false
        }));
    }
}
