namespace ChessGame.ConsoleUI;

internal class ConsoleIOMessager : IConsoleIOMessager
{
    public void Message(string message)
    {
        Console.WriteLine(message);
    }

    public void InvalidInputMessage()
    {
        Console.WriteLine("Invalid Input! Please give us the correct data.");
    }
}
