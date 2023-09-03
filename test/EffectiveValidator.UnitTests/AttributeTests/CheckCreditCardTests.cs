namespace EffectiveValidator.UnitTests.AttributeTests;

public class CheckCreditCardTests
{
    class Test
    {
        [CheckCreditCard(CreditCardType.Visa,"format is wrong!")]
        //[CheckCreditCard(CreditCardType.Mastercard,"format is wrong!")]
        //[CheckCreditCard(CreditCardType.AmericanExpress, "format is wrong!")]

        public string CreditCardNumber { get; set; }
    }

    [Fact]
    void CheckCreditCard_When_Visa_Not_Valid_ShouldBe_Return_False()
    {
        Test test = new()
        {
            CreditCardNumber = "4506 3441 2435 4565"
        };

        var validator = new EffectiveValidator<Test>();
        var validationResult = validator.Validate(test);

        Assert.False(validationResult.IsValid);
        Assert.NotNull(validationResult.ErrorMessages);
        Assert.Equal<string>("CreditCardNumber format is wrong!", validationResult.ErrorMessages[0]);

    }

    [Fact]
    void CheckCreditCard_When_Mastercard_Not_Valid_ShouldBe_Return_False()
    {
        Test test = new()
        {
            CreditCardNumber = "4506 3441 2435 4565"
        };

        var validator = new EffectiveValidator<Test>();
        var validationResult = validator.Validate(test);

        Assert.False(validationResult.IsValid);
        Assert.NotNull(validationResult.ErrorMessages);
        Assert.Equal<string>("CreditCardNumber format is wrong!", validationResult.ErrorMessages[0]);
    }

    [Fact]
    void CheckCreditCard_When_AmericanExpress_Not_Valid_ShouldBe_Return_False()
    {
        Test test = new()
        {
            CreditCardNumber = "4506344124354565"
        };

        var validator = new EffectiveValidator<Test>();
        var validationResult = validator.Validate(test);

        Assert.False(validationResult.IsValid);
        Assert.NotNull(validationResult.ErrorMessages);
        Assert.Equal<string>("CreditCardNumber format is wrong!", validationResult.ErrorMessages[0]);
    }

    [Fact]
    void CheckCreditCard_When_Visa_Valid_ShouldBe_Return_True()
    {
        Test test = new()
        {
            CreditCardNumber = "4000123456789010"
        };

        var validator = new EffectiveValidator<Test>();
        var validationResult = validator.Validate(test);

        Assert.True(validationResult.IsValid);
        Assert.Null(validationResult.ErrorMessages);
    }

    [Fact]
    void CheckCreditCard_When_Mastercard_Valid_ShouldBe_Return_True()
    {
        Test test = new()
        {
            CreditCardNumber = "2412751234123456"
        };

        var validator = new EffectiveValidator<Test>();
        var validationResult = validator.Validate(test);

        Assert.True(validationResult.IsValid);
        Assert.Null(validationResult.ErrorMessages);
    }

    [Fact]
    void CheckCreditCard_When_AmericanExpress_Valid_ShouldBe_Return_True()
    {
        Test test = new()
        {
            CreditCardNumber = "375987654321001"
        };

        var validator = new EffectiveValidator<Test>();
        var validationResult = validator.Validate(test);

        Assert.True(validationResult.IsValid);
        Assert.Null(validationResult.ErrorMessages);
    }

}
