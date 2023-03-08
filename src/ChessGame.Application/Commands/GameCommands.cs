using ChessGame.Domain;

namespace ChessGame.Application;

internal class GameCommands : IGameCommands
{
    public bool Move(IBoardManager boardManager, IChess item, int targetRank, int targetFile)
    {
        if (item.IsMoveable(boardManager.Tiles, targetRank, targetFile) is false)
            return false;

        // Check is oppponent
        if (boardManager.Tiles[targetRank, targetFile] is not null
            && boardManager.Tiles[targetRank, targetFile]?.Color != item?.Color)
        {
            KillOpponent(boardManager, boardManager.Tiles[targetRank, targetFile]);
        }

        boardManager.Remove(item.Rank, item.File);
        item.Set(targetRank, targetFile);
        boardManager.Add(item);

        return true;
    }

    private void KillOpponent(IBoardManager boardManager, IChess opponent)
    {
        boardManager.Remove(opponent.Rank, opponent.File);
        opponent.Kill();
    }
}
