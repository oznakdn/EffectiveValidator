# Gleeman Effective Validator

| Package |  Version | Popularity |
| ------- | ----- | ----- |
| `Gleeman.EffectiveValidator` | [![NuGet](https://img.shields.io/nuget/v/Gleeman.EffectiveValidator.svg)](https://www.nuget.org/packages/Gleeman.EffectiveValidator) | [![Nuget](https://img.shields.io/nuget/dt/Gleeman.EffectiveValidator.svg)](https://www.nuget.org/packages/Gleeman.EffectiveValidator)
<br>

`dotnet` CLI
```
> dotnet add package Gleeman.EffectiveValidator --version 2.0.0
```

### Validation Attributes

##### Credit Card Validation
```csharp
[CheckCreditCard(CreditCardType creditCard)]
```
##### Date Validation
```csharp
[CheckDate(string startDate, string endDate)]
```
##### Email Validation
```csharp
 [CheckEmail]
```
##### Name Validation
```csharp
  [CheckName]
```
##### Passport Validation
```csharp
   [CheckPassport]
```
##### Phone Validation
```csharp
    [CheckPhone]
```
##### Number Range Validation
```csharp
     [CheckRange(int min, int max)]
```
##### Required Validation
```csharp
    [CheckRequired]
```
##### String Empty Validation
```csharp
     [CheckStringEmpty]
```
##### String Lenght Validation
```csharp
     [CheckStringLenght(int minLenght, int maxLenght)]
```
##### Zip Code Validation
```csharp
     [CheckZipCode]
```

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
        [HttpPost]
        public IActionResult PostPerson(CreatePersonDto createPerson)
        {
            Person person = new()
            {
                FirstName = createPerson.FirstName,
                LastName = createPerson.LastName,
                DateOfBirth = createPerson.DateOfBirth,
                Age = createPerson.Age,
                Email = createPerson.Email,
                PhoneNumber = createPerson.PhoneNumber,
                CreditCartNumber = createPerson.CreditCartNumber,
                PassportNumber = createPerson.PassportNumber,
                ZipCode = createPerson.ZipCode,
                IsActive = createPerson.IsActive
            };

            var validator = new EffectiveValidator<CreatePersonDto>();
            var validationResult = validator.Validate(createPerson);
            if (validationResult.IsValid)
            {
                using var dbContext = new AppDbContext();
                dbContext.Persons.Add(person);
                dbContext.SaveChanges();
                return Created("", createPerson);
            }

            return BadRequest(validationResult.ErrorMessages);
        }
```
