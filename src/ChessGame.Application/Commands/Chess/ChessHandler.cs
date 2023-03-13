using ChessGame.Domain;

namespace ChessGame.Application;

internal class ChessHandler : IChessHandler
{
    IChessBoard _board;

    public ChessHandler(IChessBoard board)
    {
        _board = board;
    }

    public IChess HandleCurrentTurn(IChess sourceChess, int newRank, int newFile)
    {
        if (sourceChess is null) return null;
        if (sourceChess.CanMove(_board.Tiles, (newRank, newFile)) is false)
            throw new InvalidOperationException("Chess is not moveable!");

        IChess opponent = _board[newRank, newFile];

        if (opponent is not null)
        {
            // opponent killing
            _board.Remove(opponent.Rank, opponent.File);
            opponent.Kill();
        }

        // Move source chess
        _board.Remove(sourceChess.Rank, sourceChess.File);
        _board.Put(sourceChess, newRank, newFile);
        sourceChess.Put(newRank, newFile);

        return opponent;
    }
}
