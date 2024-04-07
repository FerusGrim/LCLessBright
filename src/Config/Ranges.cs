namespace LessBright.Config;

internal static class Ranges
{
    internal static class Flashlight
    {
        public static readonly Range Intensity = new(0F, 800F, 25_000F);
        public static readonly Range Range = new(0F, 99_999F, 99_999F);
        public static readonly Range Spread = new(1F, 130F, 179F);
        public static readonly Range OffsetX = new(-10F, 0F, 10F, 0.1F);
        public static readonly Range OffsetY = new(-10F, 1.5F, 10F, 0.1F);
        public static readonly Range OffsetZ = new(-10F, 0F, 10F, 0.1F);
        public static readonly Range Pitch = new(-180F, 0F, 180F);
        public static readonly Range Yaw = new(-180F, 0F, 180F);
    }

    internal static class Sun
    {
        public static readonly Range InsideIntensity = new(0F, 4F, 10F);
        public static readonly Range PositionOverride = new(0F, 0.333F, 0.99F, 0.001F);
    }
}
