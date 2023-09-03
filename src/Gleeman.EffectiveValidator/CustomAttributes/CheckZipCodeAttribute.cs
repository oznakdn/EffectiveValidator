namespace Gleeman.EffectiveValidator.CustomAttributes;

public class CheckZipCodeAttribute : AbstractAttribute<CheckZipCodeAttribute>
{
    public CheckZipCodeAttribute(string errorMessage) : base(errorMessage)
    {
    }
}
