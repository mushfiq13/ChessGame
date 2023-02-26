namespace ChessLib;

public partial class ChessBoard
{
    private void InitializeTiles()
    {
        for (var i = 2; i <= 5; ++i)
        {
            for (var j = 0; j < Ranks; ++j)
            {
                Tiles[i, j] = null;
            }
        }

        InitializePlayerPieces(Players.WhiteOpponent, 0, 1);
        InitializePlayerPieces(Players.BlackOpponent, 7, 6);
    }

    private void InitializePlayerPieces(IChessPlayer player, int kingsFile, int pawnsFile)
    {
        SetPositionIntoTileAndPiece(player.King,
            (kingsFile, (int)ChessBoardRanks.Fourth));
        SetPositionIntoTileAndPiece(player.Queen,
            (kingsFile, (int)ChessBoardRanks.Third));

        SetPositionIntoTileAndPiece(player.Rook.Item1,
            (kingsFile, (int)ChessBoardRanks.Zero));
        SetPositionIntoTileAndPiece(player.Rook.Item2,
            (kingsFile, (int)ChessBoardRanks.Seventh));

        SetPositionIntoTileAndPiece(player.Knight.Item1,
            (kingsFile, (int)ChessBoardRanks.First));
        SetPositionIntoTileAndPiece(player.Knight.Item2,
            (kingsFile, (int)ChessBoardRanks.Sixth));

        SetPositionIntoTileAndPiece(player.Bishop.Item1,
            (kingsFile, (int)ChessBoardRanks.Second));
        SetPositionIntoTileAndPiece(player.Bishop.Item2,
            (kingsFile, (int)ChessBoardRanks.Fifth));

        for (var rank = (int)ChessBoardRanks.Zero; rank < Ranks; ++rank)
        {
            SetPositionIntoTileAndPiece(player.Pawns.ElementAt(rank),
                (pawnsFile, rank));
        }
    }

    private IChessPiece SetPositionIntoTileAndPiece(IChessPiece piece, (int, int) tile)
    {
        Tiles[tile.Item1, tile.Item2] = piece;
        piece.Position = (tile.Item1, tile.Item2);

        return piece;
    }
}
