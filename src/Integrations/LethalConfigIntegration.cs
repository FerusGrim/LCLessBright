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
        RegisterIntEntry(Configs.Intensity, Ranges.Intensity);
        RegisterIntEntry(Configs.Range, Ranges.Range);
        RegisterIntEntry(Configs.SpotAngle, Ranges.SpotAngle);
        RegisterTextEntry(Configs.Color);

        // Positioning
        RegisterFloatEntry(Configs.OffsetX, Ranges.OffsetX);
        RegisterFloatEntry(Configs.OffsetY, Ranges.OffsetY);
        RegisterFloatEntry(Configs.OffsetZ, Ranges.OffsetZ);
        RegisterIntEntry(Configs.Pitch, Ranges.Pitch);
        RegisterIntEntry(Configs.Yaw, Ranges.Yaw);
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

    private static void RegisterIntEntry<TMapped>(WrappedConfigEntry<int, TMapped> entry, IntRange range)
    {
        AddConfigItem(entry.ToIntConfigItem(range.Min, range.Max));
    }

    private static void RegisterFloatEntry<TMapped>(WrappedConfigEntry<float, TMapped> entry, FloatRange range)
    {
        AddConfigItem(entry.ToFloatConfigItem(range.Min, range.Max, range.Step));
    }
}
