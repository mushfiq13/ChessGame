using ChessGame.Domain;

namespace ChessGame.Application;

internal class PieceQueries
{
    public bool IsOpponents(IChess sourcePiece, IChess targetPiece)
         => sourcePiece.Color != targetPiece.Color;
}
