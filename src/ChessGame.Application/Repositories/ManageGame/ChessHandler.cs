using ChessGame.Domain;

namespace ChessGame.Application;

internal class ChessHandler : IChessHandler
{
    public bool Move(IChess item, int newRank, int newFile)
    {
        if (item is null) return false;

        Singleton.BoardManager.Remove(item.Rank, item.File);
        item.Set(newRank, newFile);
        Singleton.BoardManager.SetTo(item, newRank, newFile);

        return true;
    }

    public void Kill(IChess item)
    {
        if (item is null) return;

        Singleton.BoardManager.Remove(item.Rank, item.File);
        item.Kill();
    }
}
