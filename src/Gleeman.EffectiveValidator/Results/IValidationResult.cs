namespace Gleeman.EffectiveValidator.Results;

public interface IValidationResult
{
    List<string>? ErrorMessages { get; set; }
    bool IsValid { get; set; }
}
