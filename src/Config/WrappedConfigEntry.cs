using BepInEx.Configuration;

namespace LessBright.Config;

public class WrappedConfigEntry<TType, TMapped>
{
    private readonly ConfigEntry<TType> _configEntry;
    private readonly Func<TType, TMapped> _mapper;

    private WrappedConfigEntry(ConfigEntry<TType> configEntry, Func<TType, TMapped> mapper)
    {
        _configEntry = configEntry;
        _mapper = mapper;
    }

    private TMapped MappedValue => _mapper(_configEntry.Value);

    public static implicit operator ConfigEntry<TType>(WrappedConfigEntry<TType, TMapped> wrappedConfigEntry)
    {
        return wrappedConfigEntry._configEntry;
    }

    public static implicit operator TMapped(WrappedConfigEntry<TType, TMapped> wrappedConfigEntry)
    {
        return wrappedConfigEntry.MappedValue;
    }

    public static WrappedConfigEntry<int, int> BasicInt(string section, string key, string description, int defaultValue)
    {
        var configEntry = LessBright.Config.Bind(section, key, defaultValue, description);
        return new WrappedConfigEntry<int, int>(configEntry, x => x);
    }

    public static WrappedConfigEntry<float, float> BasicFloat(string section, string key, string description, float defaultValue)
    {
        var configEntry = LessBright.Config.Bind(section, key, defaultValue, description);
        return new WrappedConfigEntry<float, float>(configEntry, x => x);
    }

    public static WrappedConfigEntry<string, TTMapped> MappedString<TTMapped>(string section, string key, string description, string defaultValue,
        Func<string, TTMapped> mapper)
    {
        var configEntry = LessBright.Config.Bind(section, key, defaultValue, description);
        return new WrappedConfigEntry<string, TTMapped>(configEntry, mapper);
    }
}
