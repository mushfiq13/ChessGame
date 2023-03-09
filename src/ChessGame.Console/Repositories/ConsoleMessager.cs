namespace ChessGame.ConsoleUI;

internal class ConsoleMessager : IConsoleMessager
{
    public void Message(string message) => Console.WriteLine(message);

    public void IndexOutOfBound()
        => Console.WriteLine("Error! Index out of bound.");

    public void InvalidDataCapture()
        => Console.WriteLine("Error! Given data is invalid.");

    public void EndApplication()
    {
        Console.WriteLine("Press enter to close...");
        Console.ReadLine();
    }
}
