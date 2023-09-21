namespace Gleeman.EffectiveValidator.CustomAttributes;

public class CheckDateAttribute : AbstractAttribute<CheckDateAttribute>
{
    public string StartDate { get; }
    public string EndDate { get; }
    public CheckDateAttribute(string startDate, string endDate, string errorMessage) : base(errorMessage)
    {
        StartDate = startDate;
        EndDate = endDate;
    }

    public CheckDateAttribute(string startDate, string endDate)
    {
        StartDate = startDate;
        EndDate = endDate;
    }
}
