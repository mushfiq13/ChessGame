using ChessGame.ConsoleUI;

namespace ChessGame.Application;

internal class StandardMessages
{
    IConsoleOutput _consoleOutput = Factory.CreateConsoleOutput();

    public void WelcomeMessage()
    {
        _consoleOutput.WriteMessage("Welcome To Chess Game :)");
    }

    public void InvalidCaptureMessage()
    {
        _consoleOutput.WriteMessage("");
    }
}
