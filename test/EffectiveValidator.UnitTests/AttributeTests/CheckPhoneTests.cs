namespace EffectiveValidator.UnitTests.AttributeTests;

public class CheckPhoneTests
{
    class Test
    {
        [CheckPhone("format is wrong!")]
        public string PhoneNumber { get; set; }
    }

    [Fact]
    void CheckPhoneNumber_When_Not_Valid_ShouldBe_Return_False_And_ErrorMessages_Not_Null()
    {
        Test test = new()
        {
            PhoneNumber = "123"
        };

        var validator = new EffectiveValidator<Test>();
        var validationResult = validator.Validate(test);
        Assert.False(validationResult.IsValid);
        Assert.NotNull(validationResult.ErrorMessages);
        Assert.Equal<string>("PhoneNumber format is wrong!", validationResult.ErrorMessages[0]);
    }

    [Fact]
    void CheckPhoneNumber_When_Valid_ShouldBe_Return_True_And_ErrorMessages_Null()
    {
        Test test = new()
        {
            //PhoneNumber = "0172 8622111"
            //PhoneNumber = "0157764123813"
            PhoneNumber = "+49 176 3123 8343"


        };

        var validator = new EffectiveValidator<Test>();
        var validationResult = validator.Validate(test);
        Assert.True(validationResult.IsValid);
        Assert.Null(validationResult.ErrorMessages);
    }
}
