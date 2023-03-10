using System;
using System.Text;

namespace ConsoleProgram;

public static class Polygons
{

    public static string Diamond(char character)
    {
        var strBuilder = new StringBuilder("");

        var alpha = Helpers.GetCharacters(character);
        var alphaInverted = Helpers.InvertString(alpha)[1..^1];

        int lenght = alpha.Length;

        strBuilder.Append("A".PadLeft(lenght + 1) + "\n");
        strBuilder.Append("B".PadLeft(lenght - 1) + "   B\n");//min 1 space in B


        var alphaSliced = alpha[2..];
        foreach (var (c, i) in alphaSliced.Select((c, i) => (c.ToString(), i)))
        {
            var left = alphaSliced.Length - i;
            var initalSpacing = 6; // min 4
            var middle = initalSpacing + (2 * i);


            strBuilder.Append(c.PadLeft(left) + c.PadLeft(middle) + "\n");
        }

        foreach (var (c, i) in alphaInverted.Select((c, i) => (c.ToString(), i)))
        {
            var left = 2 + i;
            var initalSpacing = 2;//min 0
            var middle = (alphaInverted.Length - i) * 2 + initalSpacing;

            strBuilder.Append(c.PadLeft(left) + c.PadLeft(middle) + "\n");
        }

        strBuilder.Append("A".PadLeft(lenght + 1));


        return strBuilder.ToString();
    }

    public static string Square(char character)
    {
        var strBuilder = new StringBuilder("");

        var alpha = Helpers.GetCharacters(character);
        var alphaInverted = Helpers.InvertString(alpha)[1..^1];
        var squareSide = String.Concat(alpha, alphaInverted);
        var squareSize = squareSide.Length + 1;

        strBuilder.Insert(0, " A", squareSize);
        strBuilder.Append('\n');

        var squareSideSliced = squareSide[1..];
        foreach (var (c, i) in squareSideSliced.Select((c, i) => (c.ToString(), i)))
        {
            var spacing = squareSide.Length * 2;

            strBuilder.Append(" " + c + c.PadLeft(spacing) + "\n");
        }

        strBuilder.Insert(strBuilder.Length, " A", squareSize);

        return strBuilder.ToString();
    }
}
