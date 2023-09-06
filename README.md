# Gleeman Effective Validator

[![Nuget version](https://img.shields.io/nuget/v/JwtProducer.svg?logo=nuget)](https://www.nuget.org/packages/JwtProducer/)
[![Nuget downloads](https://img.shields.io/nuget/dt/JwtProducer?logo=nuget)](https://www.nuget.org/packages/JwtProducer/)
![Build & Test Main](https://github.com/Blazored/LocalStorage/workflows/Build%20&%20Test%20Main/badge.svg)

### How To Use?
```csharp

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

```
```csharp
var validator = new EffectiveValidator<CreatePersonDto>();
var validationResult = validator.Validate(createPerson);
if (validationResult.IsValid)
 {
     using var dbContext = new AppDbContext();
     dbContext.Persons.Add(person);
     dbContext.SaveChanges();
     return Created("", createPerson);
}


```
