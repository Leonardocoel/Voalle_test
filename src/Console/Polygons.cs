using System;
using System.Text;

namespace ConsoleProgram;

public static class Polygons
{

    public static string Diamond(char letter)
    {
        var strBuilder = new StringBuilder("");

        var alpha = Helpers.GetCharacters(letter);
        var alphaSelected = alpha[1..].Select((c, i) => (c, i));

        var LineA = new string(' ', alpha.Length) + "A" + "\n";
        strBuilder.Insert(0, LineA, 2);

        foreach (var (character, i) in alphaSelected)
        {
            int leftSpacingCount = alpha[1..^1].Length - i;
            string leftSpacing = new(' ', leftSpacingCount);

            int initialSpacing = 3; //B
            int middleSpacingCount = initialSpacing + 2 * i;
            string middleSpacing = new(' ', middleSpacingCount);


            var insertIndex = strBuilder.Length / 2;
            var diamondLine = leftSpacing + character + middleSpacing + character + '\n';
            int repeatN = (character == letter) ? 1 : 2;


            strBuilder.Insert(insertIndex, diamondLine, repeatN);
        }

        return strBuilder.ToString();
    }

    public static string Square(char letter)
    {
        var strBuilder = new StringBuilder("");

        var alpha = Helpers.GetCharacters(letter);
        var alphaSelected = alpha[1..].Select((c, i) => (c, i));

        int LineACount = alpha.Length * 2 - 2;// 2 => menos E , menos A
        var LineA = new StringBuilder("A");
        LineA.Insert(1, " A", LineACount);

        strBuilder.Insert(0, LineA.ToString() + "\n", 2);

        foreach (var (character, i) in alphaSelected)
        {
            int middleSpacingCount = LineACount * 2 - 1;
            string middleSpacing = new(' ', middleSpacingCount);

            var insertIndex = strBuilder.Length / 2;
            var squareLine = character + middleSpacing + character + '\n';
            int repeatN = (character == letter) ? 1 : 2;

            strBuilder.Insert(insertIndex, squareLine, repeatN);
        }

        return strBuilder.ToString();
    }
}
