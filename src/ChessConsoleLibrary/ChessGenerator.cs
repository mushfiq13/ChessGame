using ChessLib;

namespace ChessConsoleLibrary;

public partial class ChessGenerator
{
    private ChessBoard _chessBoard;
    private BoardDisplayer _boardDisplayer;
    public bool IsGameRunning { get; protected set; } = false;
    public string? ChessWinner { get; protected set; } = null;

    public ChessGenerator()
    {
        _chessBoard = new();
        _boardDisplayer = new(_chessBoard.Tiles);
    }

    public void Start()
    {
        IsGameRunning = true;

        _boardDisplayer.ShowBoard();
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
