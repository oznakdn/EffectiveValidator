namespace EffectiveValidator.UnitTests.AttributeTests;

public class CommonTests
{
    class Test
    {

        [CheckName("is invalid!")]
        [CheckStringLenght(3, 10, "should be between 3 and 10 characters!")]
        public string FirstName { get; set; }

        [CheckStringEmpty("should not be empty!")]
        public string LastName { get; set; }

        [CheckDate("1950/1/1", "2005/1/1", "is invalid!")]
        public DateTime DateOfBirth { get; set; }

        [CheckRange(18, 73, "is invalid!")]
        public int Age { get; set; }

        [CheckEmail("is invalid!")]
        public string Email { get; set; }

        [CheckPhone("is invalid")]
        public string PhoneNumber { get; set; }

        [CheckPassport("is invalid!")]
        public string PassportNumber { get; set; }

        [CheckCreditCard(CreditCardType.Visa, "is invalid!")]
        public string CreditCartNumber { get; set; }

        [CheckZipCode("is invalid!")]
        public string ZipCode { get; set; }

        [CheckRequired("is required!")]
        public bool? IsActive { get; set; }

    }

    class Test2
    {
        [CheckName]
        public string name;
        [CheckEmail]
        public string email;
    }

    [Fact]
    void AllAttributes_When_Not_Valid_ShouldBe_Return_False_And_Not_Null_ErrorMessages()
    {
        Test test = new()
        {
            FirstName = "j1", //2
            LastName = "",
            DateOfBirth = new DateTime(1949, 1, 1), //1
            Age = 17,
            Email = "john.com",
            PhoneNumber = "123456",
            CreditCartNumber = "45064578124578",
            PassportNumber = "0000000011-A",
            ZipCode = "5542140645245",
            IsActive = null

        };


        var validator = new EffectiveValidator<Test>();
        var validationResult = validator.Validate(test);
        Assert.False(validationResult.IsValid);
        Assert.NotNull(validationResult.ErrorMessages);
        Assert.Equal<int>(11, validationResult.ErrorMessages.Count);

    }

    [Fact]
    void AllAttributes_Field_When_Not_Valid_ShouldBe_Return_False_And_Not_Null_ErrorMessages()
    {
        
        Test2 test = new()
        {
            name = "ads.4252",
            email = "mail.com"
        };


        var validator = new EffectiveValidator<Test2>();
        var validationResult = validator.Validate(test);
        Assert.False(validationResult.IsValid);
        Assert.NotNull(validationResult.ErrorMessages);
    }

    [Fact]
    void AllAttributes_When_Valid_ShouldBe_Return_True_And_Null_ErrorMessages()
    {
        Test test = new()
        {
            FirstName = "john",
            LastName = "Doe",
            DateOfBirth = new DateTime(2000, 1, 1),
            Age = 19,
            Email = "john.doe@mail.com",
            PhoneNumber = "+905004003020",
            CreditCartNumber = "4506344123547898",
            PassportNumber = "A1204578",
            ZipCode = "55400",
            IsActive = true

        };

        var validator = new EffectiveValidator<Test>();
        var validationResult = validator.Validate(test);
        Assert.Null(validationResult.ErrorMessages);
        Assert.True(validationResult.IsValid);
    }

    [Fact]
    void AllAttributes_Field_When_Valid_ShouldBe_Return_True_And_Null_ErrorMessages()
    {

        Test2 test = new()
        {
            name = "John",
            email = "john@mail.com"
        };

        var validator = new EffectiveValidator<Test2>();
        var validationResult = validator.Validate(test);
        Assert.Null(validationResult.ErrorMessages);
        Assert.True(validationResult.IsValid);
    }
}
