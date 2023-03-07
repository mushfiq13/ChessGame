namespace ChessGame.Domain;

public class ChessManager : IChessManager
{
    public IChessCore[,] Tiles { get; private set; }

    public ChessManager(IChessCore[,] tiles) => Tiles = tiles;

    public void Add(in IChessCore item) => Tiles[item.Rank, item.File] = item;

    public void Set(in IChessCore item, int targetRank, int targetFile)
        => Tiles[targetRank, targetFile] = item;

    public void Remove(int rank, int file) => Tiles[rank, file] = null;

    public bool Validate(IChessCore item)
        => ChessQuery.IsRankAndFileValid(item.Rank, item.File)
            && item.Unicode != string.Empty;
}
