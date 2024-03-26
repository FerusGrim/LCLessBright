namespace LessBright.Config;

internal static class Ranges
{
    public const string DefaultColorHex = "#FFFFFF";

    // Basic
    public static readonly FloatRange Intensity = new(0F, 3_000F, 25_000F, 1F);
    public static readonly FloatRange Range = new(0F, 99_999F, 99_999F, 1F);
    public static readonly FloatRange SpotAngle = new(1F, 130F, 179F, 1F);

    // Positioning
    public static readonly FloatRange PosOffsetX = new(-10F, 0F, 10F, 0.1F);
    public static readonly FloatRange PosOffsetY = new(-10F, 1.75F, 10F, 0.1F);
    public static readonly FloatRange PosOffsetZ = new(-10F, 0F, 10F, 0.1F);
    public static readonly FloatRange RotOffsetX = new(0F, 0F, 359F, 1F);
    public static readonly FloatRange RotOffsetY = new(0F, 0F, 359F, 1F);
    public static readonly FloatRange RotOffsetZ = new(0F, 0F, 359F, 1F);
}
