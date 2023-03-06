namespace ChessGame.Domain;

public interface IChessEntireSet
{
    ChessColor PieceColor { get; }
    (IChess, IChess) Bishop { get; }
    IChess King { get; }
    (IChess, IChess) Knight { get; }
    IList<IChess> Pawns { get; }
    IChess Queen { get; }
    (IChess, IChess) Rook { get; }
}
