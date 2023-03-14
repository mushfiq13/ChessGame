namespace ChessGame.ConsoleUI;

public interface ILogger
{
    void LogError(string text);
    void LogInformation(string text);
    void LogWarning(string text);
}