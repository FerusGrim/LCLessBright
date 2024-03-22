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

    public static readonly Preset Min = new()
    {
        Intensity = 0F,
        SpotAngle = 0F,
        InnerSpotAngle = 0F,
        BounceIntensity = 0F,
        ShadowStrength = 0F,
        OffsetX = -5F,
        OffsetY = -5F,
        OffsetZ = -5F
    };

    public static readonly Preset Max = new()
    {
        Intensity = 1_000F,
        SpotAngle = 120F,
        InnerSpotAngle = 90F,
        ShadowStrength = 1F,
        BounceIntensity = 1F,
        OffsetX = 5F,
        OffsetY = 5F,
        OffsetZ = 5F
    };

    public static readonly Preset Step = new()
    {
        Intensity = 10F,
        SpotAngle = 1F,
        InnerSpotAngle = 1F,
        ShadowStrength = 0.01F,
        BounceIntensity = 0.01F,
        OffsetX = 0.1F,
        OffsetY = 0.1F,
        OffsetZ = 0.1F
    };

    private static readonly Preset Default = new()
    {
        Intensity = 250F,
        SpotAngle = 75F,
        InnerSpotAngle = 30F,
        BounceIntensity = Max.BounceIntensity,
        ShadowType = LightShadows.Soft,
        ShadowStrength = Max.ShadowStrength,
        Color = PresetColor.White,
        OffsetX = 0F,
        OffsetY = 0.75F,
        OffsetZ = 0F
    };

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

    public class WrappedConfigEntry<T>(ConfigEntry<T> entry)
    {
        public ConfigEntry<T> Entry => entry;

        public T GetValue()
        {
            return entry.Value;
        }
    }

    [SuppressMessage("ReSharper", "MemberHidesStaticFromOuterClass")]
    public struct Preset
    {
        public float Intensity;
        public float SpotAngle;
        public float InnerSpotAngle;
        public float BounceIntensity;
        public LightShadows ShadowType;
        public float ShadowStrength;
        public PresetColor Color;
        public float OffsetX;
        public float OffsetY;
        public float OffsetZ;
    }
}
