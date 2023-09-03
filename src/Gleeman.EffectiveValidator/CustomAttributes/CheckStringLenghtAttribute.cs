namespace Gleeman.EffectiveValidator.CustomAttributes;

public class CheckStringLenghtAttribute : AbstractAttribute<CheckStringLenghtAttribute>
{
    public int MinLenght { get; }
    public int MaxLenght { get; }

    public CheckStringLenghtAttribute(int minLenght, int maxLenght, string errorMessage) : base(errorMessage)
    {
        MinLenght = minLenght;
        MaxLenght = maxLenght;
    }
}
