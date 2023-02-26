namespace ChessLib;

public interface IChessPlayer
{
    (IChessPiece, IChessPiece) Bishop { get; }
    IChessPiece King { get; }
    (IChessPiece, IChessPiece) Knight { get; }
    IList<IChessPiece> Pawns { get; }
    ChessPieceColor PieceColor { get; }
    IChessPiece Queen { get; }
    (IChessPiece, IChessPiece) Rook { get; }
}