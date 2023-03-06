using ChessGame.Domain;
using ChessGame.Presentation;

namespace ChessGame.Application;

internal class OutputCommands : IOutputCommands
{
    IConsoleOutput _consoleOutput;

    public OutputCommands(IConsoleOutput consoleOutput)
    {
        _consoleOutput = consoleOutput;
    }

    public void DisplayWelcomeMessage()
    {
        _consoleOutput.DisplayWelcome();
    }

    public void DisplayTiles(in IChess[,] tiles)
    {
        _consoleOutput.ShowBoard(tiles);
    }
}
