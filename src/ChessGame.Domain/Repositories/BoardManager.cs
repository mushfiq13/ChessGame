namespace ChessGame.Domain;

public class BoardManager : IBoardManager
{
    public IChess[,] Tiles { get; private set; }

    public BoardManager(IChess[,] tiles) => Tiles = tiles;

    public void Add(in IChess item) => Tiles[item.Rank, item.File] = item;

    public void Set(in IChess item, int targetRank, int targetFile)
        => Tiles[targetRank, targetFile] = item;

    public void Remove(int rank, int file) => Tiles[rank, file] = null;
}
