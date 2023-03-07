namespace ChessGame.Domain;

public class ChessBoard : IChessBoard
{
    public IChess[,] Tiles { get; private set; }

    public ChessBoard(IChess[,] tiles) => Tiles = tiles;

    public void Add(in IChess item) => Tiles[item.Rank, item.File] = item;

    public bool Contains(in IChess item)
        => ChessQuery.IsRankAndFileValid(item.Rank, item.File)
            && Tiles[item.Rank, item.File].Equals(item);

    public void Set(in IChess item, int targetRank, int targetFile)
        => Tiles[targetRank, targetFile] = item;

    public void Remove(int rank, int file) => Tiles[rank, file] = null;
}
