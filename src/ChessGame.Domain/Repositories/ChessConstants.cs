namespace ChessGame.Domain;

public static class ChessConstants
{
    public const int RANKS = 8; // rows
    public const int FILES = 8; // ranks

    // White Chess
    public static readonly (string unicode, int rank, int file) WHITE_KING
        = ("\u2654", 0, 4);
    public static readonly (string unicode, int rank, int file) WHITE_QUEEN
        = ("\u2655", 0, 3);
    public static readonly (string unicode, int rank, int file1, int file2) WHITE_ROOK
        = ("\u2656", 0, 0, 7);
    public static readonly (string unicode, int rank, int file1, int file2) WHITE_BISHOP
        = ("\u2657", 0, 2, 5);
    public static readonly (string unicode, int rank, int file1, int file2) WHITE_KNIGHT
        = ("\u2658", 0, 1, 6);
    public static readonly (string unicode, int rank) WHITE_PAWN
        = ("\u2659", 1);

    // Black Chess
    public static readonly (string unicode, int rank, int file) BLACK_KING
        = ("\u265A", 7, 4);
    public static readonly (string unicode, int rank, int file) BLACK_QUEEN
        = ("\u265B", 7, 3);
    public static readonly (string unicode, int rank, int file1, int file2) BLACK_ROOK
        = ("\u265C", 7, 0, 7);
    public static readonly (string unicode, int rank, int file1, int file2) BLACK_BISHOP
        = ("\u265D", 7, 2, 5);
    public static readonly (string unicode, int rank, int file1, int file2) BLACK_KNIGHT
        = ("\u265E", 7, 1, 6);
    public static readonly (string unicode, int rank) BLACK_PAWN
        = ("\u265F", 6);

    public static readonly int[] PAWN_FILE = { 0, 1, 2, 3, 4, 5, 6, 7 };
}
