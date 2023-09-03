namespace EffectiveValidator.UnitTests.AttributeTests;

public class CheckEmailTests
{
    class Test
    {
        [CheckEmail("is invalid!")]
        public string Email { get; set; }
    }

    [Fact]
    void CheckEmail_When_Invalid_ShouldBe_Return_False_And_Not_Null_ErrorMessages()
    {
        Test test = new()
        {
            Email = "test@mailcom"
        };

        var validator = new EffectiveValidator<Test>();
        var validationResult = validator.Validate(test);
        Assert.False(validationResult.IsValid);
        Assert.NotNull(validationResult.ErrorMessages);
        Assert.Equal<string>("Email is invalid!", validationResult.ErrorMessages[0]);
    }

    [Fact]
    void CheckEmail_When_valid_ShouldBe_Return_True_And_Null_ErrorMessages()
    {
        Test test = new()
        {
            Email = "myemail@email.com"
        };

        var validator = new EffectiveValidator<Test>();
        var validationResult = validator.Validate(test);
        Assert.True(validationResult.IsValid);
        Assert.Null(validationResult.ErrorMessages);
    }
}
