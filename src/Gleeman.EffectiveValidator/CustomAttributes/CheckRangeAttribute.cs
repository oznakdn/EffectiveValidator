namespace Gleeman.EffectiveValidator.CustomAttributes;

public class CheckRangeAttribute : AbstractAttribute<CheckRangeAttribute>
{
    public int Min { get; }
    public int Max { get; }

    public CheckRangeAttribute(int min, int max, string errorMessage) : base(errorMessage)
    {
        Min = min;
        Max = max;
    }

    public CheckRangeAttribute(int min, int max)
    {
        Min = min;
        Max = max;
    }
}
