namespace Gleeman.EffectiveValidator.CustomAttributes;

public class CheckPhoneAttribute : AbstractAttribute<CheckPhoneAttribute>
{
    public CheckPhoneAttribute(string errorMessage) : base(errorMessage)
    {
    }

    public CheckPhoneAttribute()
    {
    }
}
