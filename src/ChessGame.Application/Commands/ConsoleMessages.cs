using ChessGame.ConsoleUI;

namespace ChessGame.Application;

internal class ConsoleMessages : IConsoleMessages
{
    internal IConsoleManager _consoleManager = Factory.CreateConsoleManager();

    public void WriteMessage(string message)
        => _consoleManager.Messager.Message(message);

    public void InvalidDataCapture()
        => _consoleManager.Messager.InvalidDataCapture();

    public void EndApplication() => _consoleManager.Messager.EndApplication();
}
