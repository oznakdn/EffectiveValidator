using Gleeman.EffectiveValidator.CustomAttributes;
using Gleeman.EffectiveValidator.Enums;

namespace Example.WebApi.Entity;


public class Person
{
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public DateTime DateOfBirth { get; set; }
    public int Age { get; set; }
    public string Email { get; set; }
    public string PhoneNumber { get; set; }
    public string PassportNumber { get; set; }
    public string CreditCartNumber { get; set; }
    public string ZipCode { get; set; }
    public bool? IsActive { get; set; }
}
