namespace ChessGame.Domain;

public class ChessBoard : IBoardManager
{
    public IChess[,] Tiles { get; private set; }

    public ChessBoard(IChess[,] tiles) => Tiles = tiles;

    public IBoardManager Add(in IChess item)
    {
        Tiles[item.Rank, item.File] = item;

        return this;
    }

    public IBoardManager SetTo(in IChess item, int newRank, int newFile)
    {
        Tiles[newRank, newFile] = item;

        return this;
    }

    public IBoardManager Remove(int rank, int file)
    {
        Tiles[rank, file] = null;

        return this;
    }

    public void Clear() => Tiles = default;
}
