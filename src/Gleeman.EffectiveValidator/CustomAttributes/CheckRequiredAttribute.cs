using Gleeman.EffectiveValidator.CustomAttributes.Abstract;

namespace Gleeman.EffectiveValidator.CustomAttributes;

public class CheckRequiredAttribute : AbstractAttribute<CheckRequiredAttribute>
{
    public CheckRequiredAttribute(string errorMessage) : base(errorMessage)
    {
    }
}
