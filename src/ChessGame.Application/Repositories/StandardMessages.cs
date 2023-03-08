namespace ChessGame.Application;

internal class StandardMessages
{
    IConsoleUICommands _uICommands = Factory.CreateConsoleUICommands();

    public void WelcomeMessage() => _uICommands.DisplayMessage("\n\t\t\tWelcome To Chess Game\n");

    public void InvalidCaptureMessage() => _uICommands.DisplayMessage("");
}
