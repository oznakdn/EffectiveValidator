namespace Gleeman.EffectiveValidator.CustomAttributes.Abstract;

[AttributeUsage(AttributeTargets.Property | AttributeTargets.Field, AllowMultiple = false)]
public abstract class AbstractAttribute<T> : Attribute where T : class
{
    public string ErrorMessage { get; }
    public AbstractAttribute()
    {
       
    }
    public AbstractAttribute(string errorMessage) : this()
    {
        ErrorMessage = errorMessage;
    }
}
