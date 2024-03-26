using UnityEngine;

namespace LessBright.Config;

internal static class Configs
{
    // Basic
    public static readonly WrappedConfigEntry<int, int> Intensity =
        WrappedConfigEntry<float, float>.BasicInt("Basic", "Intensity", "The intensity of the light", Ranges.Intensity.Default);

    public static readonly WrappedConfigEntry<int, int> Range =
        WrappedConfigEntry<float, float>.BasicInt("Basic", "Range", "The range of the light", Ranges.Range.Default);

    public static readonly WrappedConfigEntry<int, int> SpotAngle =
        WrappedConfigEntry<float, float>.BasicInt("Basic", "Spot Angle", "The spot angle of the light", Ranges.SpotAngle.Default);

    public static readonly WrappedConfigEntry<string, Color> Color = WrappedConfigEntry<string, Color>.MappedString("Basic", "Color",
        "The color of the light", Ranges.DefaultColorHex,
        str => ColorUtility.TryParseHtmlString(str, out var color) ? color : UnityEngine.Color.white);

    // Position
    public static readonly WrappedConfigEntry<float, float> OffsetX =
        WrappedConfigEntry<float, float>.BasicFloat("Position", "X Offset", "The x offset of the light", Ranges.OffsetX.Default);

    public static readonly WrappedConfigEntry<float, float> OffsetY =
        WrappedConfigEntry<float, float>.BasicFloat("Position", "Y Offset", "The y offset of the light", Ranges.OffsetY.Default);

    public static readonly WrappedConfigEntry<float, float> OffsetZ =
        WrappedConfigEntry<float, float>.BasicFloat("Position", "Z Offset", "The z offset of the light", Ranges.OffsetZ.Default);

    public static readonly WrappedConfigEntry<int, int> Pitch =
        WrappedConfigEntry<float, float>.BasicInt("Position", "Pitch", "The x rotation offset of the light", Ranges.Pitch.Default);

    public static readonly WrappedConfigEntry<int, int> Yaw =
        WrappedConfigEntry<float, float>.BasicInt("Position", "Yaw", "The y rotation offset of the light", Ranges.Yaw.Default);
}
