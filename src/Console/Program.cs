namespace ConsoleProgram;

public class Program
{

    private char _character;

    public static void Main()
    {
        var Program = new Program();
        Program.Instructions();

        var Polygon = Polygons.Square(Program._character);
        Console.WriteLine("\n");
        Console.WriteLine(Polygon);
        Console.WriteLine("\n");
        EmailHandler.Message(Polygon);

        Feedback();


    }

    private void Instructions()
    {
        Console.WriteLine("Olá usuário!");
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
        _character = Char.ToUpper(character);
    }
    private static void Feedback()
    {
        Console.WriteLine("Gostaria de nos enviar algum feedback ou sugestão? [Y/n]");

        var response = Helpers.Confirmation();

        if (response)
        {
            var feedback = Console.ReadLine() ?? "";

            if (!string.IsNullOrEmpty(feedback) || !string.IsNullOrWhiteSpace(feedback))
            {
                EmailHandler.Send("leonardocoel98@gmail.com", feedback);
            }
        }

    }
}