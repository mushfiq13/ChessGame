namespace ChessLib;

public static class PieceUtilities
{
    public static string GetUnicode(ChessPiece chessPiece, ChessPieceColor chessPieceColor)
    {
        return chessPiece switch
        {
            ChessPiece.King => chessPieceColor == ChessPieceColor.White ? "\u2654" : "\u265A",
            ChessPiece.Queen => chessPieceColor == ChessPieceColor.White ? "\u2655" : "\u265B",
            ChessPiece.Rook => chessPieceColor == ChessPieceColor.White ? "\u2656" : "\u265C",
            ChessPiece.Bishop => chessPieceColor == ChessPieceColor.White ? "\u2657" : "\u265D",
            ChessPiece.Knight => chessPieceColor == ChessPieceColor.White ? "\u2658" : "\u265E",
            ChessPiece.Pawns => chessPieceColor == ChessPieceColor.White ? "\u2659" : "\u265F",
            _ => string.Empty,
        };
    }
}
