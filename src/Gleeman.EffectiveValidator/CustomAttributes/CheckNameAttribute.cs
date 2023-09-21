namespace Gleeman.EffectiveValidator.CustomAttributes;

public class CheckNameAttribute : AbstractAttribute<CheckNameAttribute>
{
    public CheckNameAttribute(string errorMessage) : base(errorMessage)
    {
    }

    public CheckNameAttribute()
    {
    }
}
