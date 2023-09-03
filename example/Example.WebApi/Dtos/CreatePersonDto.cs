using Gleeman.EffectiveValidator.CustomAttributes;
using Gleeman.EffectiveValidator.Enums;

namespace Example.WebApi.Dtos;

public record CreatePersonDto
{
    [CheckName("is invalid!")]
    [CheckStringLenght(3, 10, "should be between 3 and 10 characters!")]
    public string FirstName { get; init; }

    [CheckName("is invalid")]
    [CheckStringEmpty("should not be empty!")]
    public string LastName { get; init; }

    [CheckDate("1950/1/1", "2005/1/1", "is invalid!")]
    public DateTime DateOfBirth { get; init; }

    [CheckRange(18, 73, "is invalid!")]
    public int Age { get; init; }

    [CheckEmail("is invalid!")]
    public string Email { get; init; }

    [CheckPhone("is invalid")]
    public string PhoneNumber { get; init; }

    [CheckPassport("is invalid!")]
    public string PassportNumber { get; init; }

    [CheckCreditCard(CreditCardType.Visa, "is invalid!")]
    public string CreditCartNumber { get; init; }

    [CheckZipCode("is invalid!")]
    public string ZipCode { get; init; }

    [CheckRequired("is required!")]
    public bool? IsActive { get; init; }
}
