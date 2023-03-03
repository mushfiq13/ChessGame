namespace ChessGame.Domain;

public static class ChessConstants
{
    public const int RANKS = 8; // rows
    public const int FILES = 8; // ranks

    // Total Pieces
    public const int KING = 1;
    public const int QUEEN = 1;
    public const int KNIGHT = 2;
    public const int BISHOP = 2;
    public const int ROOK = 2;
    public const int PAWNS = 8;

    // Unicodes
    public const string WHITE_KING_UNICODE = "\u2654";
    public const string WHITE_QUEEN_UNICODE = "\u2655";
    public const string WHITE_ROOK_UNICODE = "\u2656";
    public const string WHITE_BISHOP_UNICODE = "\u2657";
    public const string WHITE_KNIGHT_UNICODE = "\u2658";
    public const string WHITE_PAWNS_UNICODE = "\u2659";
    public const string BLACK_KING_UNICODE = "\u265A";
    public const string BLACK_QUEEN_UNICODE = "\u265B";
    public const string BLACK_ROOK_UNICODE = "\u265C";
    public const string BLACK_BISHOP_UNICODE = "\u265D";
    public const string BLACK_KNIGHT_UNICODE = "\u265E";
    public const string BLACK_PAWNS_UNICODE = "\u265F";

    // Pieces Position
    public const int WHITE_KING_RANK = 0;
    public const int WHITE_PAWNS_RANK = 1;

    public const int BLACK_KING_RANK = 7;
    public const int BLACK_PAWNS_RANK = 6;

    public const int KING_POSITION_IN_FILE = 4;
    public const int QUEEN_POSITION_IN_FILE = 3;

    public static readonly (int File1, int File2) ROOK_POSITION = (0, 7);
    public static readonly (int File1, int File2) KNIGHT_POSITION = (1, 2);
    public static readonly (int File1, int File2) BISHOP_POSITION = (5, 6);

    public static readonly int[] PAWN_POSITION_IN_FILE = { 0, 1, 2, 3, 4, 5, 6, 7 };
}
