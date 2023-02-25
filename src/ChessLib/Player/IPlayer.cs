namespace ChessLib;

public interface IPlayer
{
    BishopModel Bishop { get; }
    KingModel King { get; }
    KnightModel Knight { get; }
    PawnsModel Pawns { get; }
    QueenModel Queen { get; }
    RookModel Rook { get; }
    ChessPieceColor PieceColor { get; }
}