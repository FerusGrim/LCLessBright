namespace LessBright.Config;

public class Range(float min, float @default, float max, float step = 1F)
{
    public readonly float Default = @default;
    public readonly float Max = max;
    public readonly float Min = min;
    public readonly float Step = step;
}
