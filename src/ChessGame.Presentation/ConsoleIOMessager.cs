namespace ChessGame.Presentation;

internal class ConsoleIOMessager
{
    public static void WelcomeMessage()
    {
        Console.WriteLine("Welcome to Chess Game...\n");
    }

    public void Message(string message)
    {
        Console.WriteLine(message);
    }

    public void InvalidInputMessage()
    {
        Console.WriteLine("Invalid Input! Please give us the correct data.");
    }
}
