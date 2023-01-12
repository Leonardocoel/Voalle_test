namespace ConsoleProgram;

public static class Helpers
{
    private static readonly string ALPHABET = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
    public static string GetCharacters(char character)
    {
        var index = ALPHABET.IndexOf(character);
        var alpha = ALPHABET[..(index + 1)];

        return alpha;
    }
    public static string InvertString(string characters)
    {
        char[] alpha = characters.ToCharArray();
        Array.Reverse(alpha);
        return new string(alpha);
    }

    public static bool Confirmation()
    {
        var response = Console.ReadLine() ?? "";
        var affirmative = new List<string>() { "y", "yes", "s", "sim" };

        return affirmative.Contains(response.ToLower());
    }
}
