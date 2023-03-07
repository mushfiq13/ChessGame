namespace ChessGame.ConsoleUI;

internal class ConsoleIOMessager
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
