namespace ChessGame.Domain;

internal static class Factory
{
    public static IChessPiece CreateWhiteKing() => new WhiteKing();

    public static IChessPiece CreateWhiteQueen() => new WhiteQueen();

    public static IChessPiece CreateWhiteBishop(int file) => new WhiteBishop(file);

    public static IChessPiece CreateWhiteRook(int file) => new WhiteRook(file);

    public static IChessPiece CreateWhiteKnight(int file) => new WhiteKnight(file);

    public static IChessPiece CreateWhitePawn(int file) => new WhitePawn(file);

    public static IChessPiece CreateBlackKing() => new BlackKing();

    public static IChessPiece CreateBlackQueen() => new BlackQueen();

    public static IChessPiece CreateBlackBishop(int file) => new BlackBishop(file);

    public static IChessPiece CreateBlackRook(int file) => new BlackRook(file);

    public static IChessPiece CreateBlackKnight(int file) => new BlackKnight(file);

    public static IChessPiece CreateBlackPawn(int file) => new BlackPawn(file);
}
