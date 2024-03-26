using LethalConfig.ConfigItems;
using LethalConfig.ConfigItems.Options;

namespace LessBright.Config;

public static class WrappedConfigEntryToConfigItemExtension
{
    public static BaseConfigItem ToFloatConfigItem<TMapped>(this WrappedConfigEntry<float, TMapped> entry, float min, float max, float step)
    {
        return new FloatStepSliderConfigItem(entry, new FloatStepSliderOptions
        {
            Min = min,
            Max = max,
            Step = step,
            RequiresRestart = false
        });
    }

    public static BaseConfigItem ToTextConfigItem<TMapped>(this WrappedConfigEntry<string, TMapped> entry)
    {
        return new TextInputFieldConfigItem(entry, new TextInputFieldOptions
        {
            CharacterLimit = 7,
            RequiresRestart = false
        });
    }
}
