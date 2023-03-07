using ChessGame.Domain;

namespace ChessGame.Application;

internal class PieceCommands : IPieceCommands
{
    private readonly IChessBoard _board;

    public PieceCommands(IChessBoard board)
    {
        _board = board;
    }

    public bool Move(IChess item, int targetRank, int targetFile)
    {
        if (item.IsMoveable(_board.Tiles, targetRank, targetFile) is false)
            return false;

        _board.Remove(item);
        _board.Set(item, targetRank, targetFile);
        item.Move(targetRank, targetFile);

        return true;
    }

    public void Kill(IChess item)
    {
        _board.Remove(item);
        item.Kill();
    }
}
