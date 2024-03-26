using LessBright.Config;
using LethalConfig.ConfigItems;
using LethalConfig.ConfigItems.Options;
using static LethalConfig.LethalConfigManager;

namespace LessBright.Integrations;

internal static class LethalConfigIntegration
{
    public static void Initialize()
    {
        RegisterButtonEntry("Actions", "Toggle Light", "Manually toggle the light", () => { Compat.ThirdPartyToggleTriggered = true; });

        // Basic
        RegisterFloatEntry(Configs.Intensity, Ranges.Intensity);
        RegisterFloatEntry(Configs.Range, Ranges.Range);
        RegisterFloatEntry(Configs.SpotAngle, Ranges.SpotAngle);
        RegisterTextEntry(Configs.Color);

        // Positioning
        RegisterFloatEntry(Configs.PosOffsetX, Ranges.PosOffsetX);
        RegisterFloatEntry(Configs.PosOffsetY, Ranges.PosOffsetY);
        RegisterFloatEntry(Configs.PosOffsetZ, Ranges.PosOffsetZ);
        RegisterFloatEntry(Configs.RotOffsetX, Ranges.RotOffsetX);
        RegisterFloatEntry(Configs.RotOffsetY, Ranges.RotOffsetY);
        RegisterFloatEntry(Configs.RotOffsetZ, Ranges.RotOffsetZ);
    }

    private static void RegisterButtonEntry(string section, string name, string description,
        GenericButtonOptions.GenericButtonHandler handler)
    {
        AddConfigItem(new GenericButtonConfigItem(section, name, description, name, handler));
    }

    private static void RegisterTextEntry<TMapped>(WrappedConfigEntry<string, TMapped> entry)
    {
        AddConfigItem(entry.ToTextConfigItem());
    }

    private static void RegisterFloatEntry<TMapped>(WrappedConfigEntry<float, TMapped> entry, FloatRange range)
    {
        AddConfigItem(entry.ToFloatConfigItem(range.Min, range.Max, range.Step));
    }
}
