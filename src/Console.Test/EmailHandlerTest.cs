using Xunit;
using FluentAssertions;
using ConsoleProgram;

namespace ConsoleProgram.Test;

public class TestEmailHandler
{
    [Theory(DisplayName = "Should validate if email is valid or not")]
    [InlineData("user@email.com", true)]
    [InlineData("user_999@someemail.com.br", true)]
    [InlineData("user@email", false)]
    [InlineData("useremail.com", false)]

    public void TestIsValidEmail(string email, bool expected)
    {
        var result = EmailHandler.IsValidEmail(email);

        result.Should().Be(expected);
    }

}

