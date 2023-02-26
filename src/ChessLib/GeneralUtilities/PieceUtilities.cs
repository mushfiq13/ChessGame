namespace ChessLib;

public static class PieceUtilities
{
    public static string GetUnicode(ChessPieceType chessPiece, ChessPieceColor chessPieceColor)
    {
        return chessPiece switch
        {
            ChessPieceType.King => chessPieceColor == ChessPieceColor.White ? "\u2654" : "\u265A",
            ChessPieceType.Queen => chessPieceColor == ChessPieceColor.White ? "\u2655" : "\u265B",
            ChessPieceType.Rook => chessPieceColor == ChessPieceColor.White ? "\u2656" : "\u265C",
            ChessPieceType.Bishop => chessPieceColor == ChessPieceColor.White ? "\u2657" : "\u265D",
            ChessPieceType.Knight => chessPieceColor == ChessPieceColor.White ? "\u2658" : "\u265E",
            ChessPieceType.Pawns => chessPieceColor == ChessPieceColor.White ? "\u2659" : "\u265F",
            _ => string.Empty,
        };
    }
}
