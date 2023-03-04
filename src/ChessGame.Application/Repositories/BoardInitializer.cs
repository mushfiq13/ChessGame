namespace ChessGame.Domain;

internal class BoardInitializer
{
    internal static void InitializeTiles(IChessPiece[,] tiles, (IChessPlayer, IChessPlayer) players)
    {
        for (var i = 0; i < ChessConstants.RANKS; ++i)
        {
            for (var j = 0; j < ChessConstants.FILES; ++j)
            {
                tiles[i, j] = null;
            }
        }

        InitializeTilesForPlayer(tiles, players.Item1);
        InitializeTilesForPlayer(tiles, players.Item2);
    }

    private static void InitializeTilesForPlayer(IChessPiece[,] tiles, IChessPlayer player)
    {
        SetChessIntoTile(tiles, player.King);
        SetChessIntoTile(tiles, player.Queen);

        SetChessIntoTile(tiles, player.Knight.Item1);
        SetChessIntoTile(tiles, player.Knight.Item2);

        SetChessIntoTile(tiles, player.Bishop.Item1);
        SetChessIntoTile(tiles, player.Bishop.Item2);

        SetChessIntoTile(tiles, player.Rook.Item1);
        SetChessIntoTile(tiles, player.Rook.Item2);

        foreach (var pawn in player.Pawns)
        {
            SetChessIntoTile(tiles, pawn);
        }
    }

    private static void SetChessIntoTile(IChessPiece[,] tiles, IChessPiece piece)
        => tiles[piece.Position.Rank, piece.Position.File] = piece;
}
