using ChessGame.Domain;

namespace ChessGame.Application;

internal class ChessManipulator : IChessManipulator
{
    public bool Move(IBoardManager boardManager, IChess source, int newRank, int newFile)
    {
        boardManager.Remove(source.Rank, source.File);
        source.Set(newRank, newFile);
        boardManager.SetTo(source, newRank, newFile);

        return true;
    }

    public void Kill(IBoardManager boardManager, IChess target)
    {
        boardManager.Remove(target.Rank, target.File);
        target.Kill();
    }
}
