using Gleeman.EffectiveValidator.CustomAttributes.Abstract;

namespace Gleeman.EffectiveValidator.CustomAttributes;

public class CheckNameAttribute : AbstractAttribute<CheckNameAttribute>
{
    public CheckNameAttribute(string errorMessage) : base(errorMessage)
    {
    }
}
