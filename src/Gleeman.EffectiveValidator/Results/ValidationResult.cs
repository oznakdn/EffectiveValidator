namespace Gleeman.EffectiveValidator.Results;

public class ValidationResult : IValidationResult
{
    public List<string>? ErrorMessages { get; set; }
    public bool IsValid { get; set; }

    public ValidationResult()
    {

    }

    public ValidationResult(List<string> errorMessages, bool isValid) : this()
    {
        ErrorMessages = errorMessages;
        IsValid = isValid;
    }
}
