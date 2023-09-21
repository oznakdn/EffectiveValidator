namespace Gleeman.EffectiveValidator.CustomAttributes;

public class CheckCreditCardAttribute : AbstractAttribute<CheckCreditCardAttribute>
{
    public CreditCardType CreditCard { get; }
    public CheckCreditCardAttribute(CreditCardType creditCard, string errorMessage) : base(errorMessage)
    {
        CreditCard = creditCard;
    }

    public CheckCreditCardAttribute(CreditCardType creditCard)
    {
        CreditCard = creditCard;
    }
}
