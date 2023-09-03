namespace EffectiveValidator.UnitTests.AttributeTests;

public class CheckPassportTests
{
    class Test
    {
        [CheckPassport("is invalid!")]
        public string PassportNumber { get; set; }
    }

    [Fact]
    void CheckPassportNumber_When_Valid_ShouldBe_Return_True()
    {
        Test test = new()
        {
            PassportNumber = "431276122"
        };

        var validator = new EffectiveValidator<Test>();
        var validationResult = validator.Validate(test);

        Assert.True(validationResult.IsValid);
        Assert.Null(validationResult.ErrorMessages);
    }

    [Fact]
    void CheckPassportNumber_When_Not_Valid_ShouldBe_Return_False()
    {
        Test test = new()
        {
            PassportNumber = "0007400 0000"
        };

        var validator = new EffectiveValidator<Test>();
        var validationResult = validator.Validate(test);

        Assert.False(validationResult.IsValid);
        Assert.NotNull(validationResult.ErrorMessages);
        Assert.Equal<string>("PassportNumber is invalid!", validationResult.ErrorMessages[0]);
    }
}
