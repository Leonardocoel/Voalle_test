using System;
using MailKit;
using MimeKit;
using MailKit.Net.Smtp;
using System.Text.RegularExpressions;

namespace ConsoleProgram;


public static class EmailHandler
{

    private static void Send(string email, string shape)
    {
        var message = new MimeMessage();

        message.From.Add(new MailboxAddress("Leonardo Coelho", "coelho9.8@hotmail.com"));//! Alterar 
        message.To.Add(MailboxAddress.Parse(email));
        message.Subject = "Here is the result of your request";
        message.Body = new TextPart("plain")
        {
            Text = $"\n \n {shape} \n \n"
        };

        using var client = new SmtpClient();

        try
        {
            // MICROSOFT => https://support.microsoft.com/pt-br/office/configura%C3%A7%C3%B5es-pop-imap-e-smtp-8361e398-8af4-4e97-b147-6c6c4ac95353
            // GMAIL => https://support.google.com/mail/answer/7126229?hl=pt-BR#zippy=%2Cetapa-alterar-o-smtp-e-outras-configura%C3%A7%C3%B5es-no-seu-cliente-de-e-mail%2Cn%C3%A3o-consigo-fazer-login-no-meu-cliente-de-e-mail
            client.Connect("smtp.office365.com", 587, false);
            client.Authenticate("email", "senha");//! INSERIR EMAIL E SENHA AQUI

            client.Send(message);

            Console.WriteLine("E-mail enviado!");
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
        finally
        {
            client.Disconnect(true);
            client.Dispose();
        }

    }

    public static void Message(string shape)
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

            Send(email, shape);
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