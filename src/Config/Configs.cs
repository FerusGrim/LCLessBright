using UnityEngine;

namespace LessBright.Config;

public static class Configs
{
    private static Config<TType> Create<TType>(string section, string key, string description, TType defaultValue)
    {
        return new Config<TType>(section, key, description, defaultValue);
    }

    private static Config<TType>.Mapped<TMapped> Create<TType, TMapped>(string section, string key, string description, TType defaultValue,
        Func<TType, TMapped> mapper)
    {
        return new Config<TType>.Mapped<TMapped>(section, key, description, defaultValue, mapper);
    }

    internal static class Flashlight
    {
        public static readonly Config<float> Intensity = Create(
            "Flashlight", "Intensity",
            $"""
             Determines the intensity of the light. The higher the value, the brighter the light will be.
             Valid values are between {Ranges.Flashlight.Intensity.Min} and {Ranges.Flashlight.Intensity.Max}.
             """,
            Ranges.Flashlight.Intensity.Default
        );

        public static readonly Config<float> Range = Create(
            "Flashlight", "Range",
            $"""
             Determines the range of the light. The higher the value, the further the light will reach.
             Valid values are between {Ranges.Flashlight.Range.Min} and {Ranges.Flashlight.Range.Max}.
             """,
            Ranges.Flashlight.Range.Default
        );

        public static readonly Config<float> Spread = Create(
            "Flashlight", "Spread",
            $"""
             Determines the spread of the light. The higher the value, the wider the light will be.
             Valid values are between {Ranges.Flashlight.Spread.Min} and {Ranges.Flashlight.Spread.Max}.
             """,
            Ranges.Flashlight.Spread.Default
        );

        public static readonly Config<string>.Mapped<Color> Color = Create(
            "Flashlight", "Color",
            """
            Determines the color of the light. The color is represented as a hexadecimal string.
            An example of a valid color is #FF0000, which represents red.
            You can use a color picker by searching for 'color picker' on your favorite search engine:
            https://www.google.com/search?q=color+picker
            """,
            "#FFFFFF",
            str => ColorUtility.TryParseHtmlString(str, out var color) ? color : UnityEngine.Color.white
        );

        public static readonly Config<float> OffsetX = Create(
            "Flashlight", "X Offset",
            $"""
             Determines the offset of the light on the X-axis. A value of 1 will place the light 1 unit to the right of the player.
             The further the value is from 0, the further left or right the light will be.
             Valid values are between {Ranges.Flashlight.OffsetX.Min} and {Ranges.Flashlight.OffsetX.Max}.
             """,
            Ranges.Flashlight.OffsetX.Default
        );

        public static readonly Config<float> OffsetY = Create(
            "Flashlight", "Y Offset",
            $"""
             Determines the offset of the light on the Y-axis. A value of 0 will place the light at the player's eye level.
             The further the value is from 0, the higher or lower the light will be.
             Valid values are between {Ranges.Flashlight.OffsetY.Min} and {Ranges.Flashlight.OffsetY.Max}.
             """,
            Ranges.Flashlight.OffsetY.Default
        );

        public static readonly Config<float> OffsetZ = Create(
            "Flashlight", "Z Offset",
            $"""
             Determines the offset of the light on the Z-axis. A value of 1 will place the light 1 unit in front of the player.
             The further the value is from 0, the further in front or behind the light will be.
             Valid values are between {Ranges.Flashlight.OffsetZ.Min} and {Ranges.Flashlight.OffsetZ.Max}.
             """,
            Ranges.Flashlight.OffsetZ.Default
        );

        public static readonly Config<float> Pitch = Create(
            "Flashlight", "Pitch",
            $"""
             Determines the pitch of the light. The pitch is the side-to-side rotation of the light.
             A negative value will aim the light to the left, while a positive value will aim the light to the right.
             Valid values are between {Ranges.Flashlight.Pitch.Min} and {Ranges.Flashlight.Pitch.Max}.
             """,
            Ranges.Flashlight.Pitch.Default
        );

        public static readonly Config<float> Yaw = Create(
            "Flashlight", "Yaw",
            $"""
             Determines the yaw of the light. The yaw is the up-and-down rotation of the light.
             A negative value will aim the light down, while a positive value will aim the light up.
             Valid values are between {Ranges.Flashlight.Yaw.Min} and {Ranges.Flashlight.Yaw.Max}.
             """,
            Ranges.Flashlight.Yaw.Default
        );
    }

    internal static class Sun
    {
        public static readonly Config<float> InsideIntensity = Create(
            "Sun", "Inside Intensity",
            $"""
             Determines the intensity of the sun's light while inside the facility.
             The higher the value, the brighter the light will be.
             Valid values are between {Ranges.Sun.InsideIntensity.Min} and {Ranges.Sun.InsideIntensity.Max}.
             """,
            Ranges.Sun.InsideIntensity.Default
        );

        public static readonly Config<bool> EnablePositionOverride = Create(
            "Sun", "Enable Position Override",
            """
            Determines whether the sun's position should be overridden.
            If enabled, the sun's position will be determined by the 'Position Override' setting.
            """,
            true
        );

        public static readonly Config<float> PositionOverride = Create(
            "Sun", "Position Override",
            $"""
             Determines the lifecycle position of the sun. The higher the value, the closer the sun will be to the end of its lifecycle.
             The lowest lifecycle position is 0, but the day actually starts at around 0.092, which represents 7:40AM.
             The lifecycle position at 0.333 represents 12:00PM, which is the highest point of the sun.
             The highest lifecycle position is 1, which represents 12:00AM.
             Valid values are between {Ranges.Sun.PositionOverride.Min} and {Ranges.Sun.PositionOverride.Max}.
             """,
            Ranges.Sun.PositionOverride.Default
        );
    }
}
