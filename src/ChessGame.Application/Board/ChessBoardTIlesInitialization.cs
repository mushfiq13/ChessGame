using ChessGame.Domain;

namespace ChessGame.Application;

public partial class ChessBoard
{
    private void InitializeTiles()
    {
        for (var i = 0; i < ChessConstants.RANKS; ++i)
        {
            for (var j = 0; j < ChessConstants.FILES; ++j)
            {
                Tiles[i, j] = default;
            }
        }

        InitializeTilesForPlayer(Players.WhitePlayer);
        InitializeTilesForPlayer(Players.BlackPlayer);
    }

    private void InitializeTilesForPlayer(IChessPlayer player)
    {
        SetChessIntoTile(player.King);
        SetChessIntoTile(player.Queen);

        SetChessIntoTile(player.Knight.Item1);
        SetChessIntoTile(player.Knight.Item2);

        SetChessIntoTile(player.Bishop.Item1);
        SetChessIntoTile(player.Bishop.Item2);

        SetChessIntoTile(player.Rook.Item1);
        SetChessIntoTile(player.Rook.Item2);

        foreach (var pawn in player.Pawns)
        {
            SetChessIntoTile(pawn);
        }
    }

    private void SetChessIntoTile(IChessPiece chessPiece)
    {
        Tiles[chessPiece.Position.Rank, chessPiece.Position.File] = chessPiece;
    }
}
