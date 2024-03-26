namespace LessBright.Config;

internal static class Ranges
{
    public const string DefaultColorHex = "#FFFFFF";

    // Basic
    public static readonly IntRange Intensity = new(0, 3_000, 25_000);
    public static readonly IntRange Range = new(0, 99_999, 99_999);
    public static readonly IntRange SpotAngle = new(1, 130, 179);

    // Positioning
    public static readonly FloatRange OffsetX = new(-10F, 0F, 10F, 0.1F);
    public static readonly FloatRange OffsetY = new(-10F, 1.75F, 10F, 0.1F);
    public static readonly FloatRange OffsetZ = new(-10F, 0F, 10F, 0.1F);
    public static readonly IntRange Pitch = new(0, 0, 359);
    public static readonly IntRange Yaw = new(0, 0, 359);
}
