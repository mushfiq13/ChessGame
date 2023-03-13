using ChessGame.Domain;

namespace ChessGame.Application;

internal class ChessHandler : IChessHandler
{
    private readonly IChessBoard _board;

    public ChessHandler(IChessBoard board)
    {
        _board = board;
    }

    public IChess HandleCurrentTurn(IChess sourceChess, int newRank, int newFile)
    {
        if (sourceChess is null) return null;

        IChess killedItem = null;

        if (sourceChess.IsMoveable(_board.Tiles, (newRank, newFile)) is false)
            throw new InvalidOperationException("Chess is not moveable!");

        if (_board[newRank, newFile] is not null)
        {
            killedItem = _board[newRank, newFile];
            Kill(_board[newRank, newFile]);
        }

        _board.Put(sourceChess, newRank, newFile);
        sourceChess.Put(newRank, newFile);

        return killedItem;
    }

    private void Kill(IChess item)
    {
        if (item is null) return;

        _board.Remove(item.Rank, item.File);
        item.Kill();
    }
}
