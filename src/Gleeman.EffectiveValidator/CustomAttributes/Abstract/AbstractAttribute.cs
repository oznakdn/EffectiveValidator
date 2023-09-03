namespace Gleeman.EffectiveValidator.CustomAttributes.Abstract;

[AttributeUsage(AttributeTargets.Property,AllowMultiple =false)]
public abstract class AbstractAttribute<T> : Attribute where T : class
{
    public string ErrorMessage { get; }
    public AbstractAttribute(string errorMessage)
    {
        ErrorMessage = errorMessage;
    }
}
