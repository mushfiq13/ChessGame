namespace ChessGame.ConsoleUI;

internal class Logger : ILogger
{
    private static readonly Logger _instance = new Logger();

    private Logger() { }

    public static ILogger GetInstance()
    {
        return _instance;
    }

    public void LogInformation(string text)
    {
        Console.WriteLine($"Info: {text}");
    }

    public void LogError(string text)
    {
        Console.WriteLine($"Error: {text}");
    }

    public void LogWarning(string text)
    {
        Console.WriteLine($"Warning: {text}");
    }
}
