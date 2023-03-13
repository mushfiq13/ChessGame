namespace ChessGame.ConsoleUI;

internal partial class ConsoleOutput : IConsoleOutput
{
    public IConsoleOutput PrintMenu()
    {
        Console.WriteLine("Commands: (N)ew game\t (M)ove \t(U)ndo \t(Q)uit ");

        return this;
    }

    public IConsoleOutput CurrentTurn(object value)
    {
        Console.WriteLine($"Current turn: {value}");

        return this;
    }

    public void ResetConsole() => Console.Clear();
}
