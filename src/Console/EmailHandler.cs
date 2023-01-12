using System.Text.RegularExpressions;

namespace ConsoleProgram;


public static class EmailHandler
{

    private static void Send(string email)
    {

        Console.WriteLine(email);
        Console.WriteLine("E-mail enviado com sucesso");

    }

    public static void Message()
    {
        Console.WriteLine("Gostaria de salvar o resultado e enviar para o seu e-mail? [Y/n]");
        var response = Console.ReadLine() ?? "";
        var affirmative = new List<string>() { "y", "yes", "s", "sim" };

        if (affirmative.Contains(response.ToLower()))
        {
            Console.WriteLine("Insira seu e-mail:");
            var email = Console.ReadLine() ?? "";

            while (!IsValidEmail(email))
            {
                Console.WriteLine("e-mail inválido! Insira novamente seu email:");
                email = Console.ReadLine() ?? "";
            }

            Send(email);
        }

    }

    private static bool IsValidEmail(string email)
    {
        if (string.IsNullOrWhiteSpace(email))
            return false;

        try
        {
            return Regex.IsMatch(email,
                @"^[^@\s]+@[^@\s]+\.[^@\s]+$",
                RegexOptions.IgnoreCase, TimeSpan.FromMilliseconds(250));
        }
        catch (Exception)
        {
            return false;
        }
    }
}