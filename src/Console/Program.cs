namespace ConsoleProgram;

public class Program
{

    private char _character;

    public static void Main()
    {
        var Program = new Program();
        Program.Instructions();

        var Polygon = Polygons.Diamond(Program._character);
        Console.WriteLine("\n");
        Console.WriteLine(Polygon);
        Console.WriteLine("\n");
        EmailHandler.Message();

    }

    private void Instructions()
    {
        Console.WriteLine("Olá usuário!");
        Console.WriteLine("Insira uma letra de C a Z:");

        var response = Console.ReadLine();

        bool isValid = char.TryParse(response, out char character);

        while (!isValid || !Char.IsLetter(character) || character == 'A' || character == 'B')
        {
            Console.WriteLine("Caracter inválido");
            Console.WriteLine("Insira uma letra de C a Z:");
            response = Console.ReadLine();
            isValid = char.TryParse(response, out character);
        }
        _character = Char.ToUpper(character);
    }
}