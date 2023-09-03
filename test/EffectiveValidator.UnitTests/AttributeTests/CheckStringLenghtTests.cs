namespace EffectiveValidator.UnitTests.AttributeTests;

public class CheckStringLenghtTests
{
    class Test
    {
        [CheckStringLenght(10, 15, "should be between 10 and 15 characters!")]
        public string Description { get; set; }
    }

    [Fact]
    void CheckStringLenght_When_Valid_ShouldBe_Return_True()
    {
        Test test = new()
        {
            Description = "This is test"
        };

        var validator = new EffectiveValidator<Test>();
        var validationResult = validator.Validate(test);

        Assert.True(validationResult.IsValid);
        Assert.Null(validationResult.ErrorMessages);

    }

    [Fact]
    void CheckStringLenght_Than_Less_ShouldBe_Return_False()
    {
        Test test = new()
        {
            Description = "This is"
        };

        var validator = new EffectiveValidator<Test>();
        var validationResult = validator.Validate(test);

        Assert.False(validationResult.IsValid);
        Assert.NotNull(validationResult.ErrorMessages);
        Assert.Equal<string>("Description should be between 10 and 15 characters!", validationResult.ErrorMessages[0]);

    }

    [Fact]
    void CheckStringLenght_Than_Greater_ShouldBe_Return_False()
    {
        Test test = new()
        {
            Description = "This is test description"
        };

        var validator = new EffectiveValidator<Test>();
        var validationResult = validator.Validate(test);

        Assert.False(validationResult.IsValid);
        Assert.NotNull(validationResult.ErrorMessages);
        Assert.Equal<string>("Description should be between 10 and 15 characters!", validationResult.ErrorMessages[0]);


    }
}
