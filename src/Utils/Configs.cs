using System.Diagnostics.CodeAnalysis;
using BepInEx.Configuration;
using LessBright.Integrations;
using UnityEngine;

namespace LessBright.Utils;

internal static class Configs
{
    public enum PresetColor
    {
        White,
        Black,
        Red,
        Green,
        Blue,
        Yellow,
        Cyan,
        Magenta,
        Gray
    }

    private static ConfigFile? _config;

    public static WrappedConfigEntry<float>? Intensity;
    public static WrappedConfigEntry<float>? SpotAngle;
    public static WrappedConfigEntry<float>? InnerSpotAngle;
    public static WrappedConfigEntry<float>? BounceIntensity;
    public static WrappedConfigEntry<LightShadows>? ShadowType;
    public static WrappedConfigEntry<float>? ShadowStrength;
    public static WrappedConfigEntry<PresetColor>? Color;
    public static WrappedConfigEntry<float>? OffsetX;
    public static WrappedConfigEntry<float>? OffsetY;
    public static WrappedConfigEntry<float>? OffsetZ;

    public static void Initialize(ConfigFile config)
    {
        _config = config;
        Intensity = CreateFloatEntry("Settings", "Intensity", "The intensity of the light", Default.Intensity);
        SpotAngle = CreateFloatEntry("Settings", "SpotAngle", "The spot angle of the light", Default.SpotAngle);
        InnerSpotAngle = CreateFloatEntry("Settings", "InnerSpotAngle", "The inner spot angle of the light",
            Default.InnerSpotAngle);
        BounceIntensity = CreateFloatEntry("Settings", "BounceIntensity", "The bounce intensity of the light",
            Default.BounceIntensity);
        ShadowType = new WrappedConfigEntry<LightShadows>(_config.Bind("Settings", "ShadowType",
            Default.ShadowType, "The shadow type of the light"));
        ShadowStrength = CreateFloatEntry("Settings", "ShadowStrength", "The shadow strength of the light",
            Default.ShadowStrength);
        Color = new WrappedConfigEntry<PresetColor>(_config.Bind("Settings", "Color", Default.Color,
            "The color of the light"));
        OffsetX = CreateFloatEntry("Settings", "OffsetX", "The offset X of the light", Default.OffsetX);
        OffsetY = CreateFloatEntry("Settings", "OffsetY", "The offset Y of the light", Default.OffsetY);
        OffsetZ = CreateFloatEntry("Settings", "OffsetZ", "The offset Z of the light", Default.OffsetZ);

        if (Compat.LethalConfig) LethalConfigIntegration.Initialize();
    }

    public static Color TranslateColor()
    {
        return Color!.GetValue() switch
        {
            PresetColor.White => UnityEngine.Color.white,
            PresetColor.Black => UnityEngine.Color.black,
            PresetColor.Red => UnityEngine.Color.red,
            PresetColor.Green => UnityEngine.Color.green,
            PresetColor.Blue => UnityEngine.Color.blue,
            PresetColor.Yellow => UnityEngine.Color.yellow,
            PresetColor.Cyan => UnityEngine.Color.cyan,
            PresetColor.Magenta => UnityEngine.Color.magenta,
            PresetColor.Gray => UnityEngine.Color.gray,
            _ => UnityEngine.Color.white
        };
    }

    private static WrappedConfigEntry<T> CreateFloatEntry<T>(string section, string key, string description,
        T defaultValue)
    {
        return new WrappedConfigEntry<T>(_config!.Bind(section, key, defaultValue, description));
    }

    [SuppressMessage("ReSharper", "MemberHidesStaticFromOuterClass")]
    public static class Min
    {
        public const float Intensity = 0F;
        public const float SpotAngle = 0F;
        public const float InnerSpotAngle = 0F;
        public const float BounceIntensity = 0F;
        public const float ShadowStrength = 0F;
        public const float OffsetX = -5F;
        public const float OffsetY = -5F;
        public const float OffsetZ = -5F;
    }

    [SuppressMessage("ReSharper", "MemberHidesStaticFromOuterClass")]
    public static class Max
    {
        public const float Intensity = 1_000F;
        public const float SpotAngle = 120F;
        public const float InnerSpotAngle = 90F;
        public const float BounceIntensity = 1F;
        public const float ShadowStrength = 1F;
        public const float OffsetX = 5F;
        public const float OffsetY = 5F;
        public const float OffsetZ = 5F;
    }

    [SuppressMessage("ReSharper", "MemberHidesStaticFromOuterClass")]
    public static class Step
    {
        public const float Intensity = 1F;
        public const float SpotAngle = 1F;
        public const float InnerSpotAngle = 1F;
        public const float BounceIntensity = 0.01F;
        public const float ShadowStrength = 0.01F;
        public const float OffsetX = 0.1F;
        public const float OffsetY = 0.1F;
        public const float OffsetZ = 0.1F;
    }

    [SuppressMessage("ReSharper", "MemberHidesStaticFromOuterClass")]
    public static class Default
    {
        public const float Intensity = 250F;
        public const float SpotAngle = 75F;
        public const float InnerSpotAngle = 30F;
        public const float BounceIntensity = Max.BounceIntensity;
        public const LightShadows ShadowType = LightShadows.Soft;
        public const float ShadowStrength = Max.ShadowStrength;
        public const PresetColor Color = PresetColor.White;
        public const float OffsetX = 0F;
        public const float OffsetY = 0.75F;
        public const float OffsetZ = 0F;
    }

    public class WrappedConfigEntry<T>(ConfigEntry<T> entry) : IWrappedConfigEntry
    {
        public ConfigEntry<T> Entry => entry;

        public T GetValue()
        {
            return entry.Value;
        }
    }

    public interface IWrappedConfigEntry;
}
