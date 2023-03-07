using ChessGame.ConsoleUI;
using ChessGame.Domain;

namespace ChessGame.Application;

internal class OutputCommands : IOutputCommands
{
    IConsoleOutput _consoleOutput;

    public OutputCommands(IConsoleOutput consoleOutput)
    {
        _consoleOutput = consoleOutput;
    }

    public void WriteMessage(string message)
    {
        _consoleOutput.WriteMessage(message);
    }

    public void DrawTiles(in IChess[,] tiles)
    {
        _consoleOutput.DrawBoard(tiles);
    }

    public void ResetConsole()
    {
        _consoleOutput.ResetConsole();
    }
}
