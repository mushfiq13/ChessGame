namespace ChessGame.Domain;

public interface IChessEntireSet
{
    IChess King { get; }
    IChess Queen { get; }
    (IChess, IChess) Knight { get; }
    (IChess, IChess) Bishop { get; }
    (IChess, IChess) Rook { get; }
    IList<IChess> Pawns { get; }
}
