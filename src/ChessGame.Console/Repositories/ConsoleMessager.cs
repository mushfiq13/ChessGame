namespace ChessGame.ConsoleUI;

public class ConsoleMessager : IConsoleMessager
{
    public void Message(string message) => Console.WriteLine(message);

    public void EndApplication()
    {
        Console.WriteLine("Press enter to close...");
        Console.ReadLine();
    }
}
