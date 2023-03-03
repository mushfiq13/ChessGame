namespace ChessGame.Domain;

[Flags]
public enum ChessPieceType : byte
{
    King,
    Queen,
    Knight,
    Bishop,
    Rook,
    Pawns
}
