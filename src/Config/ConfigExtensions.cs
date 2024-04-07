using LethalConfig.ConfigItems;
using LethalConfig.ConfigItems.Options;
using UnityEngine;

namespace LessBright.Config;

internal static class ConfigExtensions
{
    public static float Clamped(this Config<float> entry, Range range)
    {
        return Mathf.Clamp(entry, range.Min, range.Max);
    }

    public static BaseConfigItem ToConfigItem(this Config<float> entry, Range range, bool requiresRestart = false)
    {
        return new FloatStepSliderConfigItem(entry, new FloatStepSliderOptions
        {
            Min = range.Min,
            Max = range.Max,
            Step = range.Step,
            RequiresRestart = requiresRestart
        });
    }

    public static BaseConfigItem ToConfigItem(this Config<string> entry, int characterLimit = 0, bool requiresRestart = false)
    {
        return new TextInputFieldConfigItem(entry, new TextInputFieldOptions
        {
            CharacterLimit = characterLimit,
            RequiresRestart = requiresRestart
        });
    }

    public static BaseConfigItem ToConfigItem(this Config<bool> entry, bool requiresRestart = false)
    {
        return new BoolCheckBoxConfigItem(entry, new BoolCheckBoxOptions
        {
            RequiresRestart = requiresRestart
        });
    }
}
