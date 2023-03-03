using ChessGame.Application;

namespace ChessGame.Presentation;

public class ChessGenerator
{
    private ChessBoard _chessBoard;
    private ConsoleIOMessager _iOMessager;
    private ConsoleInput _input;
    private ConsoleOutput _output;
    public bool IsGameRunning { get; protected set; } = false;
    public string? ChessWinner { get; protected set; } = null;

    public ChessGenerator()
    {
        _chessBoard = new();
        _iOMessager = new ConsoleIOMessager();
        _input = new ConsoleInput();
        _output = new ConsoleOutput();
    }

    public void Start()
    {
        IsGameRunning = true;

        _output.ShowBoard(_chessBoard.Tiles);

        _iOMessager.RequestToSelectChess();
        (int row, int col) = _input.ReadTilePosition();

        _iOMessager.RequestToMoveChess();
        (int destRow, int destCol) = _input.ReadTilePosition();
    }
}
