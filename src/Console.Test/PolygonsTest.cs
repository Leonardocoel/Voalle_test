using Xunit;
using FluentAssertions;
using ConsoleProgram;

namespace ConsoleProgram.Test;

public class PolygonsTest
{
    [Theory(DisplayName = "Should return a diamond shaped polygon using the correct characters")]
    [InlineData('C', "   A\n B   B\nC     C\n B   B\n   A")]
    [InlineData('E', "     A\n   B   B\n  C     C\n D       D\nE         E\n D       D\n  C     C\n   B   B\n     A")]
    public void TestDiamond(char character, string expected)
    {
        var result = Polygons.Diamond(character);

        result.Should().Be(expected);
    }

    [Theory]
    [InlineData('C', " A A A A A\n B       B\n C       C\n B       B\n A A A A A")]
    [InlineData('E', " A A A A A A A A A\n B               B\n C               C\n D               D\n E               E\n D               D\n C               C\n B               B\n A A A A A A A A A")]
    public void TestSquare(char character, string expected)
    {
        var result = Polygons.Square(character);

        result.Should().Be(expected);
    }
}
