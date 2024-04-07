using BepInEx.Configuration;

namespace LessBright.Config;

internal class Config<TType>(string section, string key, string description, TType defaultValue)
{
    private readonly ConfigEntry<TType> _configEntry = LessBright.Config.Bind(section, key, defaultValue, description);

    private TType Value => _configEntry.Value;

    public static implicit operator TType(Config<TType> config)
    {
        return config.Value;
    }

    public static implicit operator ConfigEntry<TType>(Config<TType> config)
    {
        return config._configEntry;
    }

    internal class Mapped<TMapped> : Config<TType>
    {
        private readonly Func<TType, TMapped> _mapper;

        internal Mapped(string section, string key, string description, TType defaultValue, Func<TType, TMapped> mapper) : base(section, key,
            description, defaultValue)
        {
            _mapper = mapper;
        }

        private TMapped MappedValue => _mapper(Value);

        public static implicit operator TMapped(Mapped<TMapped> config)
        {
            return config.MappedValue;
        }
    }
}
