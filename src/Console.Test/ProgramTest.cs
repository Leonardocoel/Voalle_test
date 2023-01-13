using Xunit;
using System;
using FluentAssertions;
// using ConsoleProgram;
using System.IO;

namespace ConsoleProgram.Test;

public class ProgramTest
{
    [Theory(DisplayName = "Should return a diamond shaped polygon using the correct characters")]
    [InlineData(new string[] { "1", "z" }, 'Z', "Diamond")]
    [InlineData(new string[] { "2", "m" }, 'M', "Square")]
    [InlineData(new string[] { "g", "M" }, 'M', "Diamond")]
    [InlineData(new string[] { "3", "m" }, 'M', "Diamond")]
    [InlineData(new string[] { "2", "b", "m" }, 'M', "Square")]
    [InlineData(new string[] { "2", "1", "m" }, 'M', "Square")]


    public void TestInstructions(string[] entrys, char expectedChar, string expectedStr)
    {
        var program = new Program();
        using var strWriter = new StringWriter();
        using var strReader = new StringReader(String.Join("\n", entrys));
        Console.SetOut(strWriter);
        Console.SetIn(strReader);


        program.Instructions();


        program.Character.Should().Be(expectedChar);
        program.Polygon.Should().Be(expectedStr);
    }


}
