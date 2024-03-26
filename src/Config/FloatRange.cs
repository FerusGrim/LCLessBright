namespace LessBright.Config;

public readonly struct FloatRange(float min, float @default, float max, float step)
{
    public float Min { get; } = min;
    public float Default { get; } = @default;
    public float Max { get; } = max;
    public float Step { get; } = step;
}
