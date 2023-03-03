namespace ChessGame.Domain;

public static class Factory
{
    public static IChessPiece CreateWhiteKing() => new WhiteKing();

    public static IChessPiece CreateWhiteQueen() => new WhiteQueen();

    public static IChessPiece CreateWhiteBishop(int bishopPositionInFile) => new WhiteBishop(bishopPositionInFile);

    public static IChessPiece CreateWhiteRook(int rookPositionInFile) => new WhiteRook(rookPositionInFile);

    public static IChessPiece CreateWhiteKnight(int knightPositionInFile) => new WhiteKnight(knightPositionInFile);

    public static IChessPiece CreateWhitePawn(int pawnPositionInFile) => new WhitePawn(pawnPositionInFile);

    public static IChessPiece CreateBlackKing() => new BlackKing();

    public static IChessPiece CreateBlackQueen() => new BlackQueen();

    public static IChessPiece CreateBlackBishop(int bishopPositionInFile) => new BlackBishop(bishopPositionInFile);

    public static IChessPiece CreateBlackRook(int rookPositionInFile) => new BlackRook(rookPositionInFile);

    public static IChessPiece CreateBlackKnight(int knightPositionInFile) => new BlackKnight(knightPositionInFile);

    public static IChessPiece CreateBlackPawn(int pawnPositionInFile) => new BlackPawn(pawnPositionInFile);
}
