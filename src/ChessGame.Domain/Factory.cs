namespace ChessGame.Domain;

public static class Factory
{
    public static IChessPiece CreateKing(ChessPieceColor color, int rank, int file)
        => new KingModel(color, rank, file);

    public static IChessPiece CreateQueen(ChessPieceColor color, int rank, int file)
        => new QueenModel(color, rank, file);

    public static IChessPiece CreateBishop(ChessPieceColor color, int rank, int file)
        => new BishopModel(color, rank, file);

    public static IChessPiece CreateKnight(ChessPieceColor color, int rank, int file)
        => new KnightModel(color, rank, file);

    public static IChessPiece CreateRook(ChessPieceColor color, int rank, int file)
        => new RookModel(color, rank, file);

    public static IChessPiece CreatePawns(ChessPieceColor color, int rank, int file)
        => new PawnsModel(color, rank, file);
}
