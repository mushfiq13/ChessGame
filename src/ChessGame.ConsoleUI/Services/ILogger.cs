namespace ChessGame.ConsoleUI;

public interface ILogger
{
    void Write(string text);
    void Log(string text);
    void LogError(string text);
    void LogInformation(string text);
    void LogWarning(string text);
}