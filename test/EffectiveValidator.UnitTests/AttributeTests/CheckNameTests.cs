namespace EffectiveValidator.UnitTests.AttributeTests;

public class CheckNameTests
{
    class Test
    {
        [CheckName("is invalid!")]
        public string FirstName { get; set; }
    }

    [Fact]
    void CheckName_When_Not_Valid_ShouldBe_Return_False_And_Not_Null_ErrorMessage()
    {
        Test test = new()
        {
            FirstName = "john123"
        };

        var validator = new EffectiveValidator<Test>();
        var validationResult = validator.Validate(test);
        Assert.False(validationResult.IsValid);
        Assert.NotNull(validationResult.ErrorMessages);
        Assert.Equal<string>("FirstName is invalid!", validationResult.ErrorMessages[0]);
    }

    [Fact]
    void CheckName_When_Not_Valid_ShouldBe_Return_True_And_Null_ErrorMessage()
    {
        Test test = new()
        {
            FirstName = "john"
        };

        var validator = new EffectiveValidator<Test>();
        var validationResult = validator.Validate(test);
        Assert.True(validationResult.IsValid);
        Assert.Null(validationResult.ErrorMessages);
    }
}
