namespace EffectiveValidator.UnitTests.AttributeTests;

public class CheckRequiredTests
{
    class Test
    {
        [CheckRequired("should not be null!")]
        public bool? IsActive { get; set; }

        [CheckRequired("should not be null!")]
        public string Name { get; set; }
    }

    [Fact]
    void CheckRequired_When_Not_Valid_ShouldBe_Return_False()
    {
        Test test = new()
        {
            IsActive = null,
            Name = null
        };

        var validator = new EffectiveValidator<Test>();
        var validationResult = validator.Validate(test);
        Assert.False(validationResult.IsValid);
        Assert.NotNull(validationResult.ErrorMessages);
        Assert.Equal<string>("IsActive should not be null!", validationResult.ErrorMessages[0]);
        Assert.Equal<string>("Name should not be null!", validationResult.ErrorMessages[1]);

    }

    [Fact]
    void CheckRequired_When_Valid_ShouldBe_Return_True()
    {
        Test test = new()
        {
            IsActive = true,
            Name = "Test name"
        };

        var validator = new EffectiveValidator<Test>();
        var validationResult = validator.Validate(test);
        Assert.True(validationResult.IsValid);
        Assert.Null(validationResult.ErrorMessages);
    }
}
