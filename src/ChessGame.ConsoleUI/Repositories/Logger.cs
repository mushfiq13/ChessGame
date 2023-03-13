namespace ChessGame.ConsoleUI;

internal class Logger : ILogger
{
    public void Write(string text)
    {
        Console.Write(text);
    }

    public void Log(string text)
    {
        Console.WriteLine(text);
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
