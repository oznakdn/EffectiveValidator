namespace EffectiveValidator.UnitTests.AttributeTests;

public class CheckRangeTests
{
    class Test
    {
        [CheckRange(18, 50, "is invalid!")]
        public int Age { get; set; }
    }

    [Fact]
    void CheckRange_When_Not_Valid_ShouldBe_Return_False_And_Not_Null_ErrorMessages()
    {
        Test test = new()
        {
            Age = 1
        };

        var validator = new EffectiveValidator<Test>();
        var validationResult = validator.Validate(test);
        Assert.False(validationResult.IsValid);
        Assert.NotNull(validationResult.ErrorMessages);
        Assert.Equal<string>("Age is invalid!", validationResult.ErrorMessages[0]);
    }

    [Fact]
    void CheckRange_When_Valid_ShouldBe_Return_True_And_Null_ErrorMessages()
    {
        Test test = new()
        {
            Age = 35
        };

        var validator = new EffectiveValidator<Test>();
        var validationResult = validator.Validate(test);
        Assert.True(validationResult.IsValid);
        Assert.Null(validationResult.ErrorMessages);
    }
}
