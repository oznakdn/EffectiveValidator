namespace EffectiveValidator.UnitTests.AttributeTests;

public class CheckDateTests
{
    class Test
    {
        [CheckDate("1900,1,1", "2005,1,1")]
        public DateTime DateOfBirth { get; set; }
    }

    [Fact]
    void ChecDate_When_Not_Valid_ShouldBe_Return_False_And_Not_Null_ErrorMessages()
    {
        Test test = new()
        {
            DateOfBirth = new DateTime(1889, 1, 15)
        };

        var validator = new EffectiveValidator<Test>();
        var validationResult = validator.Validate(test);
        Assert.False(validationResult.IsValid);
        Assert.NotNull(validationResult.ErrorMessages);
        Assert.Equal<string>("DateOfBirth should be equal or greater than 1900,1,1!", validationResult.ErrorMessages[0]);
    }

    [Fact]
    void ChecDate_When_Valid_ShouldBe_Return_True_And_Null_ErrorMessages()
    {
        Test test = new()
        {
            DateOfBirth = new DateTime(2000, 10, 15)
        };

        var validator = new EffectiveValidator<Test>();
        var validationResult = validator.Validate(test);
        Assert.True(validationResult.IsValid);
        Assert.Null(validationResult.ErrorMessages);
    }
}
