namespace ChessLib;

[System.Flags]
public enum ChessPieceType : byte
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

[System.Flags]
public enum ChessBoardRanks : byte
{
    Zero,
    First,
    Second,
    Third,
    Fourth,
    Fifth,
    Sixth,
    Seventh,
}

[System.Flags]
public enum ChessBoardFiles : byte
{
    Zero,
    First,
    Second,
    Third,
    Fourth,
    Fifth,
    Sixth,
    Seventh,
}