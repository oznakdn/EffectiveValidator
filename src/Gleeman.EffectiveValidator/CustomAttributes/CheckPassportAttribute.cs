using Gleeman.EffectiveValidator.CustomAttributes.Abstract;

namespace Gleeman.EffectiveValidator.CustomAttributes;

public class CheckPassportAttribute : AbstractAttribute<CheckPassportAttribute>
{
    public CheckPassportAttribute(string errorMessage) : base(errorMessage)
    {
    }
}
