using ChessLib;

namespace ChessConsoleLibrary;

public partial class ChessGenerator
{
    private ChessBoard _chessBoard;
    public bool IsGameRunning { get; protected set; } = false;
    public string? ChessWinner { get; protected set; } = null;

    public ChessGenerator()
    {
        _chessBoard = new();
    }

    public void Start()
    {
        IsGameRunning = true;

        BoardDisplayer.ShowBoard(_chessBoard.Tiles);
        (int file, int rank) = UserInput();
    }

    private (int, int) UserInput()
    {
        Console.WriteLine("Please select from which cell you want to move a chess...");

        Console.Write("Select Row and press enter: ");
        var row = Console.Read() - '0';
        Console.ReadLine();

        Console.Write("Select Column and press enter: ");
        var col = Console.Read() - '0';
        Console.ReadLine();

        return (row, col);
    }
}
