using ChessGame.Domain;

namespace ChessGame.Application;

internal class PieceCommands
{
    private readonly IChessBoard _board;

    public PieceCommands(IChessBoard board)
    {
        _board = board;
    }

    public bool Move(IChess item, int targetRank, int targetFile)
    {
        var moved = item.Move(_board.Tiles, targetRank, targetFile);

        if (moved)
        {
            _board.Move(item, targetRank, targetFile);
        }

        return moved;
    }

    public void Kill(IChess item)
    {
        _board.Dead(item);

        item.Kill();
    }
}
