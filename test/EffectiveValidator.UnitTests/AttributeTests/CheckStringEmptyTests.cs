namespace EffectiveValidator.UnitTests.AttributeTests;

public class CheckStringEmptyTests
{
    class Test
    {

        [CheckStringEmpty("should not be empty!")]
        public string Name { get; set; }
    }

    [Fact]
    void CheckStringEmpty_When_Valid_ShouldBe_Return_True()
    {
        Test test = new()
        {
            Name = "Test Name"
        };

        var validator = new EffectiveValidator<Test>();
        var validationResult = validator.Validate(test);

        Assert.True(validationResult.IsValid);
        Assert.Null(validationResult.ErrorMessages);
    }

    [Fact]
    void CheckStringEmpty_When_Not_Valid_ShouldBe_Return_False()
    {
        Test test = new()
        {
            Name = string.Empty
        };

        var validator = new EffectiveValidator<Test>();
        var validationResult = validator.Validate(test);

        Assert.False(validationResult.IsValid);
        Assert.NotNull(validationResult.ErrorMessages);
        Assert.Equal("Name should not be empty!", validationResult.ErrorMessages[0]);
    }

}
