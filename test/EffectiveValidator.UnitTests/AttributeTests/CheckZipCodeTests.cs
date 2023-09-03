namespace EffectiveValidator.UnitTests.AttributeTests;

public class CheckZipCodeTests
{
    class Test
    {
        [CheckZipCode("is invalid!")]
        public string PostalCode { get; set; }
    }

    [Fact]
    void CheckZipCode_When_Not_Valid_ShouldBe_Return_False_And_Not_Null_ErrorMessages()
    {
        Test test = new()
        {
            PostalCode = "554000"
        };

        var validator = new EffectiveValidator<Test>();
        var validationResult = validator.Validate(test);
        Assert.False(validationResult.IsValid);
        Assert.NotNull(validationResult.ErrorMessages);
        Assert.Equal<string>("PostalCode is invalid!", validationResult.ErrorMessages[0]);
    }

    [Fact]
    void CheckZipCode_When_Valid_ShouldBe_Return_True_And_Null_ErrorMessages()
    {
        Test test = new()
        {
            PostalCode = "55400"
        };

        var validator = new EffectiveValidator<Test>();
        var validationResult = validator.Validate(test);
        Assert.True(validationResult.IsValid);
        Assert.Null(validationResult.ErrorMessages);
    }
}
