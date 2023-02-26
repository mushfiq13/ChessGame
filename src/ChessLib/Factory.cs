namespace ChessLib;

public static class Factory
{
    public static IChessPiece CreateKing(ChessPieceColor color) => new KingModel(color);

    public static IChessPiece CreateQueen(ChessPieceColor color) => new QueenModel(color);

    public static IChessPiece CreateBishop(ChessPieceColor color) => new BishopModel(color);

    public static IChessPiece CreateKnight(ChessPieceColor color) => new KnightModel(color);

    public static IChessPiece CreateRook(ChessPieceColor color) => new RookModel(color);

    public static IChessPiece CreatePawns(ChessPieceColor color) => new PawnsModel(color);
}
