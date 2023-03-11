namespace ChessGame.ConsoleUI;

internal class ConsoleInput : IConsoleInput
{
    public string Reader()
    {
        return Console.ReadLine();
    }

    public string ReadText()
    {
        return Console.ReadLine();
    }
}
