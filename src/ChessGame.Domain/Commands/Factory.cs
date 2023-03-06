namespace ChessGame.Domain;

internal static class Factory
{
    public static IChess[,] CreateTiles()
        => new IChess[ChessConstants.RANKS, ChessConstants.FILES];
}
