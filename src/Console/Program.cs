using System;
using System.Reflection;

namespace ConsoleProgram;

public class Program
{

    public char Character { get; private set; }
    private enum Polygons { Diamond = 1, Square }

    public string Polygon { get; private set; } = "Diamond";
    public static void Main()
    {
        var Program = new Program();

        Program.Instructions();
        var (character, polygon) = (Program.Character, Program.Polygon);

        Type type = typeof(ConsoleProgram.Polygons);
        MethodInfo method = type.GetMethod(polygon);
        var obj = new object[] { character };
        var Polygon = (string)method.Invoke(null, obj);


        Console.WriteLine(Polygon);
        EmailHandler.Message(Polygon);

        if (polygon == "Square") Console.WriteLine("Exporting pdf for square is disabled due to bugs");
        else PdfHandler.Message(Polygon);

        Feedback();

    }

    public void Instructions()
    {
        Console.WriteLine("Olá usuário!");

        Console.WriteLine("Escolha o polígono a ser impresso:");
        Console.WriteLine("1 - Diamante/Losango");
        Console.WriteLine("2 - Quadrado");

        var isInt = int.TryParse(Console.ReadLine(), out int choice);

        if (!isInt || choice != 1 && choice != 2) choice = 1;

        Polygon = ((Polygons)choice).ToString();

        Console.WriteLine("Insira uma letra de C a Z:");

        var response = Console.ReadLine();

        bool isValid = char.TryParse(response, out char character);


        while (!isValid || !Char.IsLetter(character) || Char.ToUpper(character) == 'A' || Char.ToUpper(character) == 'B')
        {
            Console.WriteLine("Caracter inválido");
            Console.WriteLine("Insira uma letra de C a Z:");
            response = Console.ReadLine();
            isValid = char.TryParse(response, out character);
        }
        Character = Char.ToUpper(character);
    }
    private static void Feedback()
    {
        Console.WriteLine("Gostaria de nos enviar algum feedback ou sugestão? [Y/n]");

        var response = Helpers.Confirmation();

        if (response)
        {
            Console.WriteLine("Digite abaixo seu feedback:");
            var feedback = Console.ReadLine() ?? "";

            if (!string.IsNullOrEmpty(feedback) || !string.IsNullOrWhiteSpace(feedback))
            {
                EmailHandler.Send("leonardocoel98@gmail.com", feedback);
            }
        }

    }
}