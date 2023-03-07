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

    public void DisplayValidationError()
    {

    }

    public void EndApplication()
    {
        Console.WriteLine("Press enter to close...");
        Console.ReadLine();
    }
}
