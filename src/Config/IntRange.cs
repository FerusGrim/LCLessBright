namespace LessBright.Config;

public readonly struct IntRange(int min, int @default, int max)
{
    public int Min { get; } = min;
    public int Default { get; } = @default;
    public int Max { get; } = max;
}
