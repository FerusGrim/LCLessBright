using UnityEngine;

namespace LessBright.Config;

internal static class Configs
{
    // Basic
    public static readonly WrappedConfigEntry<float, float> Intensity =
        WrappedConfigEntry<float, float>.BasicFloat("Basic", "Intensity", "The intensity of the light", Ranges.Intensity.Default);

    public static readonly WrappedConfigEntry<float, float> Range =
        WrappedConfigEntry<float, float>.BasicFloat("Basic", "Range", "The range of the light", Ranges.Range.Default);

    public static readonly WrappedConfigEntry<float, float> SpotAngle =
        WrappedConfigEntry<float, float>.BasicFloat("Basic", "SpotAngle", "The spot angle of the light", Ranges.SpotAngle.Default);

    public static readonly WrappedConfigEntry<string, Color> Color = WrappedConfigEntry<string, Color>.MappedString("Basic", "Color",
        "The color of the light", Ranges.DefaultColorHex,
        str => ColorUtility.TryParseHtmlString(str, out var color) ? color : UnityEngine.Color.white);

    // Position
    public static readonly WrappedConfigEntry<float, float> PosOffsetX =
        WrappedConfigEntry<float, float>.BasicFloat("Position", "PosOffsetX", "The x offset of the light", Ranges.PosOffsetX.Default);

    public static readonly WrappedConfigEntry<float, float> PosOffsetY =
        WrappedConfigEntry<float, float>.BasicFloat("Position", "PosOffsetY", "The y offset of the light", Ranges.PosOffsetY.Default);

    public static readonly WrappedConfigEntry<float, float> PosOffsetZ =
        WrappedConfigEntry<float, float>.BasicFloat("Position", "PosOffsetZ", "The z offset of the light", Ranges.PosOffsetZ.Default);

    public static readonly WrappedConfigEntry<float, float> RotOffsetX =
        WrappedConfigEntry<float, float>.BasicFloat("Position", "RotOffsetX", "The x rotation offset of the light", Ranges.RotOffsetX.Default);

    public static readonly WrappedConfigEntry<float, float> RotOffsetY =
        WrappedConfigEntry<float, float>.BasicFloat("Position", "RotOffsetY", "The y rotation offset of the light", Ranges.RotOffsetY.Default);

    public static readonly WrappedConfigEntry<float, float> RotOffsetZ =
        WrappedConfigEntry<float, float>.BasicFloat("Position", "RotOffsetZ", "The z rotation offset of the light", Ranges.RotOffsetZ.Default);
}
