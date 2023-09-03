using Gleeman.EffectiveValidator.CustomAttributes.Abstract;
using Gleeman.EffectiveValidator.Enums;

namespace Gleeman.EffectiveValidator.CustomAttributes;

public class CheckCreditCardAttribute : AbstractAttribute<CheckCreditCardAttribute>
{
    public CreditCardType CreditCard { get; }
    public CheckCreditCardAttribute(CreditCardType creditCard, string errorMessage) : base(errorMessage)
    {
        CreditCard = creditCard;
    }
}
