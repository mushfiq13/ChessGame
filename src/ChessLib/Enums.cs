namespace ChessLib;

[System.Flags]
public enum ChessPiece : byte
{
    King,
    Queen,
    Knight,
    Bishop,
    Rook,
    Pawns
}

[System.Flags]
public enum ChessPieceColor : byte
{
    White,
    Black
}