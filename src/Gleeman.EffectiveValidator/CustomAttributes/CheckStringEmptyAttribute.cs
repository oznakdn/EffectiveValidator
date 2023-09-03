using Gleeman.EffectiveValidator.CustomAttributes.Abstract;

namespace Gleeman.EffectiveValidator.CustomAttributes;

public class CheckStringEmptyAttribute : AbstractAttribute<CheckStringEmptyAttribute>
{

    public CheckStringEmptyAttribute(string errorMessage) : base(errorMessage)
    {

    }
}
