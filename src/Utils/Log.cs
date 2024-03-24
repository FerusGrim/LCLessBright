using System.Diagnostics.CodeAnalysis;
using BepInEx.Logging;

namespace LessBright.Utils;

[SuppressMessage("ReSharper", "UnusedMember.Global")]
[SuppressMessage("ReSharper", "UnusedType.Global")]
internal static class Log
{
    private static readonly ManualLogSource LogSource = Logger.CreateLogSource(Metadata.PluginGuid);

    public static void Debug(object data)
    {
        LogSource.LogDebug(data);
    }

    public static void Info(object data)
    {
        LogSource.LogInfo(data);
    }

    public static void Warning(object data)
    {
        LogSource.LogWarning(data);
    }

    public static void Error(object data)
    {
        LogSource.LogError(data);
    }
}
