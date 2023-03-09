namespace ChessGame.Application;

internal class ConsoleMessages : IConsoleMessages
{
    public void WriteMessage(string message)
        => Singleton.ConsoleManager.Messager.Message(message);

    public void InvalidDataCapture()
        => Singleton.ConsoleManager.Messager.InvalidDataCapture();
}
