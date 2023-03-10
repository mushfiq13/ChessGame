namespace ChessGame.ConsoleUI;

internal class ConsoleInput : IConsoleInput
{
    public object ReadTileLocation()
    {
        return Console.ReadLine();
    }
}
