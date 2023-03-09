namespace ChessGame.Domain;

public class ChessDataGetter
{
    public static (string unicode, int rank, int[] files) GetFixedData(ChessType type, ChessColor color)
    {
        return (type, color) switch
        {
            (ChessType.King, ChessColor.White) => ("\u2654", 0, new[] { 4 }),
            (ChessType.Queen, ChessColor.White) => ("\u2655", 0, new[] { 3 }),
            (ChessType.Rook, ChessColor.White) => ("\u2656", 0, new[] { 0, 7 }),
            (ChessType.Bishop, ChessColor.White) => ("\u2657", 0, new[] { 2, 5 }),
            (ChessType.Knight, ChessColor.White) => ("\u2658", 0, new[] { 1, 6 }),
            (ChessType.Pawn, ChessColor.White) => ("\u2659", 1, new[] { 0, 1, 2, 3, 4, 5, 6, 7 }),

            (ChessType.King, ChessColor.Black) => ("\u265A", 7, new[] { 4 }),
            (ChessType.Queen, ChessColor.Black) => ("\u265B", 7, new[] { 3 }),
            (ChessType.Rook, ChessColor.Black) => ("\u265C", 7, new[] { 0, 7 }),
            (ChessType.Bishop, ChessColor.Black) => ("\u265D", 7, new[] { 2, 5 }),
            (ChessType.Knight, ChessColor.Black) => ("\u265E", 7, new[] { 1, 6 }),
            (ChessType.Pawn, ChessColor.Black) => ("\u265F", 6, new[] { 0, 1, 2, 3, 4, 5, 6, 7 }),
        };
    }

    public static bool IsKingsUnicode(string unicode)
        => unicode == "\u2654" || unicode == "\u265A";
}
