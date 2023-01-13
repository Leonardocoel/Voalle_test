using Xunit;
using FluentAssertions;
using ConsoleProgram;

namespace ConsoleProgram.Test;

public class HelpersTest
{
    [Theory(DisplayName = "Should get the all characters up to the selected one")]
    [InlineData('A', "A")]
    [InlineData('M', "ABCDEFGHIJKLM")]
    [InlineData('Z', "ABCDEFGHIJKLMNOPQRSTUVWXYZ")]

    public void TestGetCharacters(char character, string expected)
    {
        var result = Helpers.GetCharacters(character);
        result.Should().Be(expected);
    }

    [Theory(DisplayName = "Should invert all characters in the string")]
    [InlineData("ABC", "CBA")]
    [InlineData("ABCDEFGHIJKLM", "MLKJIHGFEDCBA")]
    [InlineData("ABCDEFGHIJKLMNOPQRSTUVWXYZ", "ZYXWVUTSRQPONMLKJIHGFEDCBA")]
    public void TestInvertString(string characters, string expected)
    {
        var result = Helpers.InvertString(characters);

        result.Should().Be(expected);
    }
}