using ChessGame.ConsoleUI;
using ChessGame.Domain;

namespace ChessGame.Application;

internal class OutputHandler : IOutputHandler
{
    private readonly IConsoleOutput _consoleOutput;

    public OutputHandler(IConsoleOutput consoleOutput)
    {
        _consoleOutput = consoleOutput;
    }

    public void DisplayOutput(ChessColor movingColor,
        IChess[,] tiles,
        IChess[] captured)
    {
        _consoleOutput.PrintLogo();

        _consoleOutput.DrawBoard(tiles);

        _consoleOutput.PrintCapturedItems(
            GetSpecificCaptured(captured, ChessColor.White),
            "WHITE");

        _consoleOutput.PrintCapturedItems(
            GetSpecificCaptured(captured, ChessColor.Black),
            "BLACK");

        _consoleOutput.CurrentTurn(movingColor == ChessColor.White ? "White" : "Black");
    }

    private IChess[] GetSpecificCaptured(IChess[] captured, ChessColor color)
    {
        return captured.Where(item => item?.Color == color).ToArray();
    }
}
