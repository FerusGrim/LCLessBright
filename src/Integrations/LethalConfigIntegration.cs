using LessBright.Config;
using static LethalConfig.LethalConfigManager;

namespace LessBright.Integrations;

internal static class LethalConfigIntegration
{
    public static void Initialize()
    {
        AddConfigItem(Configs.Flashlight.Intensity.ToConfigItem(Ranges.Flashlight.Intensity));
        AddConfigItem(Configs.Flashlight.Range.ToConfigItem(Ranges.Flashlight.Range));
        AddConfigItem(Configs.Flashlight.Spread.ToConfigItem(Ranges.Flashlight.Spread));
        AddConfigItem(Configs.Flashlight.Color.ToConfigItem());
        AddConfigItem(Configs.Flashlight.OffsetX.ToConfigItem(Ranges.Flashlight.OffsetX));
        AddConfigItem(Configs.Flashlight.OffsetY.ToConfigItem(Ranges.Flashlight.OffsetY));
        AddConfigItem(Configs.Flashlight.OffsetZ.ToConfigItem(Ranges.Flashlight.OffsetZ));
        AddConfigItem(Configs.Flashlight.Pitch.ToConfigItem(Ranges.Flashlight.Pitch));
        AddConfigItem(Configs.Flashlight.Yaw.ToConfigItem(Ranges.Flashlight.Yaw));

        AddConfigItem(Configs.Sun.InsideIntensity.ToConfigItem(Ranges.Sun.InsideIntensity));
        AddConfigItem(Configs.Sun.EnablePositionOverride.ToConfigItem());
        AddConfigItem(Configs.Sun.PositionOverride.ToConfigItem(Ranges.Sun.PositionOverride));
    }
}
