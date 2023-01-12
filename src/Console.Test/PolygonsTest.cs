using Xunit;
using FluentAssertions;
using ConsoleProgram;

namespace Console.Test;

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


}

